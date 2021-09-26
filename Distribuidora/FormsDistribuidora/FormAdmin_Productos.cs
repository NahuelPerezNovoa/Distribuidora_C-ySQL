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
    public partial class FormAdmin_Productos : Form
    {
        Distribuidora distribuidora;
        public FormAdmin_Productos(Distribuidora distribuidora)
        {
            InitializeComponent();
            this.distribuidora = distribuidora;
        }

        /// <summary>
        /// Cargo los campos del formulario con los datos correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAdmin_Productos_Load(object sender, EventArgs e)
        {
            CargarRtbListaProductos();
            CargarCmbCodigoProducto();
        }

        /// <summary>
        /// Agrega un producto a la lista StockDeProductos de la distribuidora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int auxInt;
            if (!(txtCodigo is null) && !(txtNombre is null) && !(txtStock is null) && Int32.TryParse(txtStock.Text, out auxInt))
            {
                Producto producto = new Producto(txtNombre.Text, txtCodigo.Text, auxInt);
                distribuidora.StockDeProductos.Add(producto);
                txtCodigo.Text = null;
                txtNombre.Text = null;
                txtStock.Text = null;
                CargarRtbListaProductos();
                CargarCmbCodigoProducto();
            }
            else
            {
                MessageBox.Show("Faltan ingresar datos o el stock no es un número válido", "ERROR", MessageBoxButtons.OK);
            }

        }

        /// <summary>
        /// Modifica el stock de un producto de la lista StockDeProductos de la distribuidora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarStock_Click(object sender, EventArgs e)
        {
            Producto auxProd = null;
            int auxInt;
            if (cmbCodigoProducto.SelectedItem != null && txtNuevoStock != null && Int32.TryParse(txtNuevoStock.Text, out auxInt))
            {
                if (auxInt < 0)
                {
                    MessageBox.Show("El stock no puede ser negativo", "ERROR", MessageBoxButtons.OK);
                }
                else
                {
                    foreach (var item in distribuidora.StockDeProductos)
                    {
                        if (item.Cod == cmbCodigoProducto.SelectedItem.ToString())
                        {
                            auxProd = item;
                        }
                    }
                    if (auxProd != null)
                    {
                        auxProd.Stock = auxInt;
                        CargarRtbListaProductos();
                        CargarCmbCodigoProducto();
                        txtNuevoStock.Text = null;
                    }
                }
            }
        }


        /// <summary>
        /// Funcion encargada de cargar rtbListaProductos con los datos de la lista StockDeProductos de la distribuidora
        /// </summary>
        protected void CargarRtbListaProductos()
        {
            if (distribuidora.StockDeProductos.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in distribuidora.StockDeProductos)
                {
                    sb.Append(item.ToString());
                }
                rtbListaProductos.Text = sb.ToString();
            }
            else
            {
                rtbListaProductos.Text = "No hay productos en stock";
            }
        }

        /// <summary>
        /// /// <summary>
        /// Funcion encargada de cargar cmbCodigoProducto con los datos de la lista StockDeProductos de la distribuidora
        /// </summary>
        /// </summary>
        protected void CargarCmbCodigoProducto()
        {
            cmbCodigoProducto.Items.Clear();
            if (distribuidora.StockDeProductos.Count != 0)
            {
                foreach (var item in distribuidora.StockDeProductos)
                {
                    cmbCodigoProducto.Items.Add(item.Cod);
                }
            }
            else
            {
                cmbCodigoProducto.Enabled = false;
                cmbCodigoProducto.SelectedItem = null;
            }
        }

    }


}
