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
    public partial class FormAdmin_Pedidos : Form
    {
        Distribuidora distribuidora;
        Thread hilo;
        public FormAdmin_Pedidos(Distribuidora distribuidora)
        {
            InitializeComponent();
            this.distribuidora = distribuidora;
        }

        /// <summary>
        /// Cargo los campos del formulario con los datos correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAdmin_Pedidos_Load(object sender, EventArgs e)
        {
            CargarRtbARealizar();
            CargarRtbrealizados();
        }

        /// <summary>
        /// Funcion encargada de cargar rtbARealizar con los datos de la  ListaDePedidosARealizar de la distribuidora
        /// </summary>
        protected void CargarRtbARealizar()
        {
            if (distribuidora.ListaDePedidosARealizar.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in distribuidora.ListaDePedidosARealizar)
                {
                    sb.Append(item.ToString());
                }
                rtbARealizar.Text = sb.ToString();
            }
            else
            {
                rtbARealizar.Text = "No hay pedidos para realizar";
            }
        }

        /// <summary>
        /// Funcion encargada de cargar rtbRealizados con los datos de la  ListaDePedidosRealizados de la distribuidora
        /// </summary>
        protected void CargarRtbrealizados()
        {
            if (distribuidora.ListaDePedidosRealizados.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in distribuidora.ListaDePedidosRealizados)
                {
                    sb.Append(item.ToString());
                }
                rtbRealizados.Text = sb.ToString();
            }
            else
            {
                rtbRealizados.Text = "No hay pedidos realizados";
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
                if (rdbtnRealizado.Checked || rdbtnARealizar.Checked)
                {
                    if (cmbCliente.SelectedItem != null)
                    {
                        if (rdbtnRealizado.Checked)
                        {
                            GenerarTxtPedidosRealizados();
                        }
                        else if (rdbtnARealizar.Checked)
                        {
                            GenerarTxtPedidosARealizar();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe especificar el tipo de pedido", "ERROR", MessageBoxButtons.OK);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK);
            }
        }


        /// <summary>
        /// Carga el cmbCliente con los clientes de la lista de pedidos seleccionada
        /// </summary>
        protected void CargarCmbCliente()
        {
            cmbCliente.Items.Clear();
            if (rdbtnRealizado.Checked || rdbtnARealizar.Checked)
            {

                if (rdbtnRealizado.Checked)
                {
                    if (distribuidora.ListaDePedidosRealizados.Count != 0)
                    {
                        foreach (var item in distribuidora.ListaDePedidosRealizados)
                        {
                            cmbCliente.Items.Add(item.Cliente);
                        }
                    }
                }
                else
                {
                    if (distribuidora.ListaDePedidosARealizar.Count != 0)
                    {
                        foreach (var item in distribuidora.ListaDePedidosARealizar)
                        {
                            cmbCliente.Items.Add(item.Cliente);
                        }
                    }
                }


            }

        }

        /// <summary>
        /// Genera un txt de un PedidoARealizar
        /// </summary>
        protected void GenerarTxtPedidosARealizar()
        {
            bool flag = false;
            try
            {
                if (distribuidora.ListaDePedidosARealizar.Count != 0)
                {
                    foreach (var item in distribuidora.ListaDePedidosARealizar)
                    {
                        if (cmbCliente.SelectedItem.ToString() == item.Cliente)
                        {
                            SerializacionYGuardado.ArchivoCreado += PedidoARealizarDocumentado;
                            List<Object> lista = new List<object>();
                            lista.Add(item);
                            lista.Add(AppDomain.CurrentDomain.BaseDirectory + item.Cliente + item.Fecha.ToString("dd'_'MM'_'yyyy") + " A REALIZAR.txt");
                            this.hilo = new Thread(new ParameterizedThreadStart(SerializacionYGuardado.GuardarEnTxt));
                            hilo.Start(lista);
                            flag = true;


                        }
                    }
                    if (!flag)
                    {
                        MessageBox.Show("No existe el pedido", "ERROR", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Genera un txt de un PedidoRealizado
        /// </summary>
        protected void GenerarTxtPedidosRealizados()
        {
            bool flag = false;
            try
            {
                if (distribuidora.ListaDePedidosRealizados.Count != 0)
                {
                    foreach (var item in distribuidora.ListaDePedidosRealizados)
                    {
                        if (cmbCliente.SelectedItem.ToString() == item.Cliente)
                        {
                            SerializacionYGuardado.ArchivoCreado += PedidoRealizadoDocumentado;
                            List<Object> lista = new List<object>();
                            lista.Add(item);
                            lista.Add(AppDomain.CurrentDomain.BaseDirectory + item.Cliente + item.Fecha.ToString("dd'_'MM'_'yyyy") + " A REALIZAR.txt");
                            this.hilo = new Thread(new ParameterizedThreadStart(SerializacionYGuardado.GuardarEnTxt));
                            hilo.Start(lista);
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        MessageBox.Show("No existe el pedido", "ERROR", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Lanza un formulario FormAdmin_CrearPedido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            FormAdmin_CrearPedido formAdmin_CrearPedido = new FormAdmin_CrearPedido(distribuidora);
            formAdmin_CrearPedido.ShowDialog();
            CargarRtbARealizar();
        }

        private void rdbtnARealizar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnARealizar.Checked)
            {
                CargarCmbCliente();
            }
        }

        private void rdbtnRealizado_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnRealizado.Checked)
            {
                CargarCmbCliente();
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

        private void PedidoRealizadoDocumentado(object a)
        {
            Documento pedido = (Documento)a;
            MessageBox.Show("Documento txt generado correctamente en la siguiente ruta: "
                + AppDomain.CurrentDomain.BaseDirectory + pedido.Cliente
                + pedido.Fecha.ToString("dd'_'MM'_'yyyy") + " REALIZADO.txt",
                "Documento exitoso", MessageBoxButtons.OK);
            SerializacionYGuardado.ArchivoCreado -= PedidoRealizadoDocumentado;
        }

    }
}
