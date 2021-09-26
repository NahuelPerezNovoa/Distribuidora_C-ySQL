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
using System.IO;
using System.Threading;

namespace FormsDistribuidora
{
    public partial class FormPrincipal : Form
    {
        Distribuidora distribuidora;
        int nroOperario;
        Thread SaveEmpleados;
        Thread SaveStockProductos;
        Thread SavePedidosARealizar;
        Thread SavePedidosRealizados;
        
        public FormPrincipal()
        {
            InitializeComponent();
        }

        public Distribuidora Distribuidora
        {
            get
            {
                return this.distribuidora;
            }
            set
            {
                this.distribuidora = value;
            }
        }
        public int NroOperario
        {
            get
            {
                return this.nroOperario;
            }
            set
            {
                this.nroOperario = value;
            }
        }

        /// <summary>
        ///Inicializo todos los valores de mi entidad principal -> Distribuidora
        ///Si no existen los archivos de respaldo, Distribuidora se inicializa con valores hardcodeados por defecto
        ///Si existen los archivos de respaldo, Distribuidora se inicializa con los valores allí guardados        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Distribuidora = new Distribuidora();

                
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_Operarios.xml"))
                {
                    Distribuidora.ListaDeEmpleados = SerializacionYGuardado.LeerXml<Operario>(Distribuidora.ListaDeEmpleados, AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_Operarios.xml");
                    distribuidora.NroOperario = DevolverMayorNumeroEmpleado();
                }
                else
                {
                    //Hardcodeo operarios.
                    Distribuidora.AgregarOperario("Carlos", "Ramadan");
                    Distribuidora.AgregarOperario("Jorge", "Estevez");
                    Distribuidora.AgregarOperario("Jose Maria", "Moreno");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_Productos.xml"))
                {
                    Distribuidora.StockDeProductos = SerializacionYGuardado.LeerXml<Producto>(Distribuidora.StockDeProductos, AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_Productos.xml");
                }
                else
                {
                    //Hardcodeo productos.
                    Distribuidora.StockDeProductos.Add(new Producto("Cabezal Peirano Mesada", "2114", 26));
                    Distribuidora.StockDeProductos.Add(new Producto("Cabezal Peirano Lavatorio", "2115", 30));
                    Distribuidora.StockDeProductos.Add(new Producto("Cabezal Peirano Ducha", "2116", 15));
                    Distribuidora.StockDeProductos.Add(new Producto("Cabezal Peirano Bidet", "2117", 10));
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_PedidosARealizar.xml"))
                {
                    Distribuidora.ListaDePedidosARealizar = SerializacionYGuardado.LeerXml<PedidoARealizar>(Distribuidora.ListaDePedidosARealizar, AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_PedidosARealizar.xml");
                }
                else
                {
                    //Hardcodeo pedido a realizar.
                    List<Producto_pedido> listaProductosPedidos = new List<Producto_pedido>();
                    listaProductosPedidos.Add(new Producto_pedido("Cabezal Peirano Mesada", "2114", 26, 4));
                    listaProductosPedidos.Add(new Producto_pedido("Cabezal Peirano Lavatorio", "2115", 30, 4));
                    listaProductosPedidos.Add(new Producto_pedido("Cabezal Peirano Ducha", "2116", 15, 4));
                    listaProductosPedidos.Add(new Producto_pedido("Cabezal Peirano Bidet", "2117", 10, 4));
                    PedidoARealizar pedidoARealizar = new PedidoARealizar(DateTime.Now, "Sanit. Dominguez", 111, listaProductosPedidos);
                    Distribuidora.ListaDePedidosARealizar.Add(pedidoARealizar);
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_PedidosRealizados.xml"))
                {
                    Distribuidora.ListaDePedidosRealizados = SerializacionYGuardado.LeerXml<PedidoRealizado>(Distribuidora.ListaDePedidosRealizados, AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_PedidosRealizados.xml");
                }
                else
                {
                    //Hardcodeo pedido realizado.
                    List<Producto_pedido> listaProductosPedidos2 = new List<Producto_pedido>();
                    listaProductosPedidos2.Add(new Producto_pedido("Cabezal Peirano Mesada", "2114", 26, 4));
                    listaProductosPedidos2.Add(new Producto_pedido("Cabezal FV Primera Marca", "2130", 32, 6));
                    listaProductosPedidos2.Add(new Producto_pedido("Cabezal Canilla Lavarropa", "2141", 17, 3));
                    PedidoRealizado pedidoRealizado = new PedidoRealizado(DateTime.Now, "Sanit. Troncoso", 112, listaProductosPedidos2);
                    Distribuidora.ListaDePedidosRealizados.Add(pedidoRealizado);
                }



            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Ejecuta un formAdministrativo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdministrativo_Click(object sender, EventArgs e)
        {
            FormAdministrativo formAdministrativo = new FormAdministrativo(distribuidora);
            formAdministrativo.ShowDialog();
        }

        /// <summary>
        /// Ejecuta un formOperario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperario_Click(object sender, EventArgs e)
        {
            FormOperario formOperario = new FormOperario(distribuidora);
            formOperario.ShowDialog();
        }

        /// <summary>
        ///Al cerrar el programa, los datos que componen a la Distribuidora son almacenados en archivos xml
        ///Si estos archivos no existen se crean, y si existen se reemplazan.        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Confirma que desea salir?", "Confirme", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    List<Object> objetoEmpleados = new List<object>();
                    objetoEmpleados.Add(distribuidora.ListaDeEmpleados);
                    objetoEmpleados.Add(AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_Operarios.xml");
                    this.SaveEmpleados = new Thread(new ParameterizedThreadStart(SerializacionYGuardado.GuardarEnXml<Operario>));
                    SaveEmpleados.Start(objetoEmpleados);

                    List<Object> objetoProductos = new List<object>();
                    objetoProductos.Add(distribuidora.StockDeProductos);
                    objetoProductos.Add(AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_Productos.xml");
                    this.SaveStockProductos = new Thread(new ParameterizedThreadStart(SerializacionYGuardado.GuardarEnXml<Producto>));
                    SaveStockProductos.Start(objetoProductos);

                    List<Object> objetoPedidosARealizar = new List<object>();
                    objetoPedidosARealizar.Add(distribuidora.ListaDePedidosARealizar);
                    objetoPedidosARealizar.Add(AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_PedidosARealizar.xml");
                    this.SavePedidosARealizar = new Thread(new ParameterizedThreadStart(SerializacionYGuardado.GuardarEnXml<PedidoARealizar>));
                    SavePedidosARealizar.Start(objetoPedidosARealizar);

                    List<Object> objetoPedidosRealizados = new List<object>();
                    objetoPedidosRealizados.Add(distribuidora.ListaDePedidosRealizados);
                    objetoPedidosRealizados.Add(AppDomain.CurrentDomain.BaseDirectory + "Distribuidora_PedidosRealizados.xml");
                    this.SavePedidosRealizados = new Thread(new ParameterizedThreadStart(SerializacionYGuardado.GuardarEnXml<PedidoRealizado>));
                    SavePedidosRealizados.Start(objetoPedidosRealizados);


                    if(! DataBaseControl.BackupearEmpleados(distribuidora.ListaDeEmpleados))
                    {
                        MessageBox.Show("Error al ejecutar el BackUp de empleados en la base de datos.", "ERROR", MessageBoxButtons.OK);
                    }
                    if (!DataBaseControl.BackupearStockProductos(distribuidora.StockDeProductos))
                    {
                        MessageBox.Show("Error al ejecutar el BackUp de stock de productos en la base de datos.", "ERROR", MessageBoxButtons.OK);
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK);
                    if(MessageBox.Show("Ha ocurrido un error al guardar los archivos. Realmente desea salir?","ERROR",MessageBoxButtons.YesNo)==DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Si la lista de empleados existe y no está vacía, busca el nro de empleado con valor mas alto.
        /// </summary>
        /// <returns></returns> Devuelve entero con el nro de empleado de valor mas alto
        protected int DevolverMayorNumeroEmpleado()
        {
            int auxInt = 0;
            if (distribuidora.ListaDeEmpleados != null && distribuidora.ListaDeEmpleados.Count != 0)
            {
                foreach (var item in distribuidora.ListaDeEmpleados)
                {
                    if (item.NroEmpleado > auxInt)
                    {
                        auxInt = item.NroEmpleado;
                    }
                }
            }
            return auxInt;
        }
    }
}
