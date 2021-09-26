using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FormsDistribuidora
{
    public partial class FormOperario : Form
    {
        Distribuidora distribuidora;
        Thread hilo;
        public FormOperario(Distribuidora distribuidora)
        {
            InitializeComponent();
            this.distribuidora = distribuidora;

        }

        /// <summary>
        /// Cargo los campos del formulario con los datos correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOperario_Load(object sender, EventArgs e)
        {
            if (distribuidora.ListaDeEmpleados.Count != 0)
            {
                foreach (var item in distribuidora.ListaDeEmpleados)
                {
                    cmbOperario.Items.Add(item.Apellido + ", " + item.Nombre);
                }
            }
            else
            {
                cmbOperario.Items.Add("No hay operarios en la nómina");
            }
        }

        /// <summary>
        /// Valido que haya un pedido asignado al operario seleccionado y cargo los campos del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (distribuidora.ListaDePedidosARealizar.Count != 0 && cmbOperario.SelectedItem != null)
                {
                    lstbxPedidos.Items.Clear();
                    foreach (var item in distribuidora.ListaDePedidosARealizar)
                    {
                        if (item.NroEmpleado == distribuidora.BuscarEmpleado(cmbOperario.SelectedItem.ToString()))
                        {
                            lstbxPedidos.Items.Add(item.MostrarDatos());
                        }
                    }
                    if (lstbxPedidos.Items.Count==0)
                    {
                        MessageBox.Show("Aún no hay pedidos asignados al operario seleccionado", "Operario", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Aún no hay pedidos cargados", "No hay pedidos", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Genera un documento txt del pedido seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstbxPedidos.SelectedItem != null && distribuidora.ListaDePedidosARealizar.Count != 0)
                {
                    foreach (var item in distribuidora.ListaDePedidosARealizar)
                    {
                        if (lstbxPedidos.SelectedItem.ToString() == item.MostrarDatos())
                        {
                            SerializacionYGuardado.ArchivoCreado += PedidoARealizarDocumentado;
                            List<Object> lista = new List<object>();
                            lista.Add(item);
                            lista.Add(AppDomain.CurrentDomain.BaseDirectory + item.Cliente + item.Fecha.ToString("dd'_'MM'_'yyyy") + " A REALIZAR.txt");
                            this.hilo = new Thread(new ParameterizedThreadStart(SerializacionYGuardado.GuardarEnTxt));
                            hilo.Start(lista);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Saca el pedido seleccionado de la lista de PedidosARealizar y lo pasa a la lista de pedidosRealizados de la Distribuidora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTerminado_Click(object sender, EventArgs e)
        {
            PedidoARealizar auxARealizar = null;
            PedidoRealizado auxRealizado;
            bool flag = false;
            if (lstbxPedidos.SelectedItem != null && distribuidora.ListaDePedidosARealizar.Count != 0)
            {
                foreach (var item in distribuidora.ListaDePedidosARealizar)
                {
                    if (lstbxPedidos.SelectedItem.ToString() == item.MostrarDatos())
                    {
                        auxARealizar = item;
                        auxRealizado = new PedidoRealizado(item.Fecha, item.Cliente, item.NroEmpleado, item.Pedido);
                        distribuidora.ListaDePedidosRealizados.Add(auxRealizado);

                        MessageBox.Show("Pedido Completado", "Realizado", MessageBoxButtons.OK);
                    }
                }
                if (auxARealizar != null)
                {
                    distribuidora.ListaDePedidosARealizar.Remove(auxARealizar);
                    lstbxPedidos.Items.Clear();
                    foreach (var item in distribuidora.ListaDePedidosARealizar)
                    {
                        if (item.NroEmpleado == distribuidora.BuscarEmpleado(cmbOperario.SelectedItem.ToString()))
                        {
                            //sb.AppendLine(item.ToString());
                            lstbxPedidos.Items.Add(item.MostrarDatos());
                            flag = true;
                        }
                    }
                }
                if (!flag)
                {
                    MessageBox.Show("No hay mas pedidos asignados al operario seleccionado", "Operario", MessageBoxButtons.OK);
                }
            }
        }

        private void PedidoARealizarDocumentado(object a)
        {
            Documento pedido = (Documento)a;
            MessageBox.Show("Documento txt generado correctamente en la siguiente ruta: "
                + AppDomain.CurrentDomain.BaseDirectory + pedido.Cliente
                + pedido.Fecha.ToString("dd'_'MM'_'yyyy") + " A REALIZAR.txt",
                "Documento exitoso", MessageBoxButtons.OK);
            SerializacionYGuardado.ArchivoCreado -= PedidoARealizarDocumentado;
        }
    }

}

