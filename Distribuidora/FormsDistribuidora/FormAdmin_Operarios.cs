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
    public partial class FormAdmin_Operarios : Form
    {
        Distribuidora distribuidora;
        public FormAdmin_Operarios(Distribuidora distribuidora)
        {
            InitializeComponent();
            this.distribuidora = distribuidora;
        }

        /// <summary>
        /// Cargo los campos del formulario con los datos correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAdmin_Operarios_Load(object sender, EventArgs e)
        {
            CargarLstbxOperarios();
        }

        /// <summary>
        /// Agrega un nuevo operario a la ListaDeEmpleados de la distribuidora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!(txtApellido is null) && !(txtNombre is null))
            {
                Operario operario = new Operario(txtNombre.Text, txtApellido.Text, distribuidora.NroOperario);
                distribuidora.NroOperario++;
                distribuidora.ListaDeEmpleados.Add(operario);
                txtApellido.Text = null;
                txtNombre.Text = null;
                CargarLstbxOperarios();
            }
            else
            {
                MessageBox.Show("Faltan ingresar datos", "ERROR", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Elimina un operario de la ListaDeEmpleados de la distribuidora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Operario auxOperario = null;
            if (lstbxOperarios.SelectedItem != null )
            {
                foreach (var item in distribuidora.ListaDeEmpleados)
                {
                    if (item.ToString() == lstbxOperarios.SelectedItem.ToString())
                    {
                        auxOperario = item;
                    }
                }
                if (auxOperario != null && MessageBox.Show("Desea elmiminar al operario: "+auxOperario.ToString()+"?","Confirmar",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    distribuidora.ListaDeEmpleados.Remove(auxOperario);
                    CargarLstbxOperarios();
                    MessageBox.Show("Operario eliminado.", "Eliminado", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Funcion encargada de cargar rtbListaOperarios con los datos de la ListaDeEmpleados de la distribuidora
        /// </summary>
        protected void CargarLstbxOperarios()
        {
            if (distribuidora.ListaDeEmpleados.Count != 0)
            {
                lstbxOperarios.Items.Clear();
                
                lstbxOperarios.CargarListBoxDesdeLista<Operario>(distribuidora.ListaDeEmpleados);
            }
            else
            {
                lstbxOperarios.Items.Clear();
                lstbxOperarios.Items.Add("No hay operario en la nómina");
            }
        }

    }
}
