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
    public partial class FormAdministrativo : Form
    {
        Distribuidora distribuidora;
        public FormAdministrativo(Distribuidora distribuidora)
        {
            InitializeComponent();
            this.distribuidora = distribuidora;
        }

        /// <summary>
        /// Lanza un formulario FormAdmin_Operarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperarios_Click(object sender, EventArgs e)
        {
            FormAdmin_Operarios formAdmin_Operarios = new FormAdmin_Operarios(distribuidora);
            formAdmin_Operarios.ShowDialog();
        }

        /// <summary>
        /// Lanza un formulario FormAdmin_Productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProductos_Click(object sender, EventArgs e)
        {
            
            FormAdmin_Productos formAdmin_Productos = new FormAdmin_Productos(distribuidora);
            formAdmin_Productos.ShowDialog();
        }

        /// <summary>
        /// Lanza un formulario FormAdmin_Pedidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FormAdmin_Pedidos formAdmin_Pedidos = new FormAdmin_Pedidos(distribuidora);
            formAdmin_Pedidos.ShowDialog();
        }
    }
}
