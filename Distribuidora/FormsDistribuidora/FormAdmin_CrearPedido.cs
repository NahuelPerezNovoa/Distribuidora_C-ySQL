using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FormsDistribuidora
{
    public partial class FormAdmin_CrearPedido : Form
    {
        Distribuidora distribuidora;
        PedidoARealizar nuevoPedido;
        public FormAdmin_CrearPedido(Distribuidora distribuidora)
        {
            InitializeComponent();
            this.distribuidora = distribuidora;
            nuevoPedido = new PedidoARealizar();
        }

        /// <summary>
        /// Cargo los campos del formulario con los valores correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAdmin_CrearPedido_Load(object sender, EventArgs e)
        {
            CargarlstbxProductos();
            CargarlstbxPedido();
            CargarCmbNroOperario();
        }

        /// <summary>
        /// Funcion encargada de cargar rtbListaProductos con los valores de la lista StockDeProductos
        /// </summary>
        protected void CargarlstbxProductos()
        {
            if (distribuidora.StockDeProductos.Count != 0)
            {
                lstbxProductos.Items.Clear();
                
                lstbxProductos.CargarListBoxDesdeLista<Producto>(distribuidora.StockDeProductos);
            }
            else
            {
                lstbxProductos.Items.Clear();
                lstbxProductos.Items.Add("No hay productos en stock");
            }
        }

        /// <summary>
        /// Funcion encargada de cargar rtbNuevoPedido con los valores de la lista Pedido
        /// </summary>
        protected void CargarlstbxPedido()
        {
            if (nuevoPedido.Pedido != null)
            {
                lstbxPedido.Items.Clear();
                if (nuevoPedido.Pedido.Count != 0)
                {
                    lstbxPedido.CargarListBoxDesdeLista<Producto_pedido>(nuevoPedido.Pedido);
                }
                else
                {
                    lstbxPedido.Items.Clear();
                    lstbxPedido.Items.Add("No se ingresaron productos al pedido");
                }
            }
            else
            {
                lstbxPedido.Items.Clear();
                lstbxPedido.Items.Add("No hay productos en stock");
            }
        }

        /// <summary>
        /// Funcion encargada de cargar cmbOperario con los valores de la lista ListaDeEmpleados
        /// </summary>
        protected void CargarCmbNroOperario()
        {
            cmbOperario.Items.Clear();
            if (distribuidora.ListaDeEmpleados.Count != 0)
            {
                foreach (var item in distribuidora.ListaDeEmpleados)
                {
                    cmbOperario.Items.Add(item.Apellido + ", " + item.Nombre);
                }
            }
            else
            {
                cmbOperario.Enabled = false;
                cmbOperario.SelectedItem = null;
            }
        }


        /// <summary>
        /// Agrega un producto al pedido que se está realizando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int auxInt;
            Producto_pedido producto_Pedido = null;
            if (lstbxProductos.SelectedItem != null && txtCantidad.Text != null && Int32.TryParse(txtCantidad.Text, out auxInt))
            {
                producto_Pedido = BuscarProducto(distribuidora.StockDeProductos, lstbxProductos.SelectedItem.ToString(), auxInt);
                if (producto_Pedido != null)
                {
                    foreach (var item in distribuidora.StockDeProductos)
                    {
                        if (item.Cod == producto_Pedido.Cod && item.Nombre == producto_Pedido.Nombre)
                        {
                            if (item.Stock < producto_Pedido.CantPedida)
                            {
                                MessageBox.Show("No hay suficiente stock de ese producto.", "ERROR", MessageBoxButtons.OK);
                            }
                            else
                            {
                                nuevoPedido.Pedido.Add(producto_Pedido);
                                distribuidora.DescontarStock(BuscarProducto(distribuidora.StockDeProductos, lstbxProductos.SelectedItem.ToString(), auxInt));
                                CargarlstbxPedido();
                                CargarlstbxProductos();
                            }
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Parámetros invalidos o no ingresados.", "ERROR", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Busca en la lista StockDeProductos el producto que coincida con el cod pasado como parametro
        /// </summary>
        /// <param name="auxLista"></param>
        /// <param name="cod"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns> Devuelve un Producto_pedido con los valores asignados
        protected Producto_pedido BuscarProducto(List<Producto> auxLista, string cod, int cantidad)
        {
            Producto_pedido producto = null;
            foreach (var item in auxLista)
            {
                if (item.ToString() == cod)
                {
                    producto = new Producto_pedido();
                    producto.Nombre = item.Nombre;
                    producto.Stock = item.Stock;
                    producto.Cod = item.Cod;
                    producto.CantPedida = cantidad;
                }
            }
            return producto;
        }

        /// <summary>
        /// Remueve del pedido en preparacion el producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstbxPedido.Items != null && lstbxPedido.SelectedItem != null)
            {
                int auxInt = 0;
                if (lstbxPedido.Items.Count != 0)
                {
                    foreach (var item in nuevoPedido.Pedido)
                    {
                        if (item.ToString() == lstbxPedido.SelectedItem.ToString())
                        {
                            auxInt = item.CantPedida;
                        }
                    }
                    distribuidora.DevolverStock(BuscarProductoParaRemover(lstbxPedido.SelectedItem.ToString()));
                    nuevoPedido.Pedido.Remove(BuscarProductoParaRemover(lstbxPedido.SelectedItem.ToString()));
                }
                CargarlstbxPedido();
                CargarlstbxProductos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar el codigo del producto a remover.", "ERROR", MessageBoxButtons.OK);
            }
        }

        protected Producto_pedido BuscarProductoParaRemover(string descrip)
        {
            Producto_pedido auxProducto = null;
            if (nuevoPedido.Pedido != null && descrip != null && distribuidora.StockDeProductos != null)
            {
                foreach (var item in nuevoPedido.Pedido)
                {
                    if (item.ToString() == descrip)
                    {
                        auxProducto = item;
                    }
                }
            }
            return auxProducto;
        }


        /// <summary>
        /// Agrega el pedido completo a la lista de PedidosARealizar de la distribuidora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text != null && cmbOperario.SelectedItem != null && nuevoPedido.Pedido != null && nuevoPedido.Pedido.Count != 0)
            {
                nuevoPedido.Cliente = txtCliente.Text;
                nuevoPedido.Fecha = DateTime.Now;
                nuevoPedido.NroEmpleado = DevolverNroEmpleado(distribuidora.ListaDeEmpleados, cmbOperario.Text);
                distribuidora.ListaDePedidosARealizar.Add(nuevoPedido);
                nuevoPedido = new PedidoARealizar();
                txtCantidad.Text = null;
                txtCliente.Text = null;
                cmbOperario.SelectedItem = null;
                CargarlstbxPedido();
                MessageBox.Show("Pedido cargado.", "Exito", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Pedido incompleto, faltan parámetros", "ERROR", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Busca el empleado que coincide con el string pasado como parametro
        /// </summary>
        /// <param name="auxLista"></param>
        /// <param name="operario"></param>
        /// <returns></returns> Devuelve un entero con el codigo del operario correspondiente
        protected int DevolverNroEmpleado(List<Operario> auxLista, string operario)
        {
            foreach (var item in auxLista)
            {
                if ((item.Apellido + ", " + item.Nombre) == operario)
                {
                    return item.NroEmpleado;
                }
            }
            return 0;
        }

        protected void DeshacerPedido()
        {
            if (lstbxPedido.Items != null && lstbxPedido.Items.Count != 0)
            {
                foreach (var item in lstbxPedido.Items)
                {
                    distribuidora.DevolverStock(BuscarProductoParaRemover(item.ToString()));
                }
            }
        }

        private void FormAdmin_CrearPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeshacerPedido();
        }
    }
}
