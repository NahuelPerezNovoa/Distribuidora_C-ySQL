using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Distribuidora
    {
        List<Operario> listaDeEmpleados;
        List<Producto> stockDeProductos;
        List<PedidoARealizar> listaDePedidosARealizar;
        List<PedidoRealizado> listaDePedidosRealizados;
        int nroOperario;

        public Distribuidora()
        {
            listaDeEmpleados = new List<Operario>();
            stockDeProductos = new List<Producto>();
            listaDePedidosARealizar = new List<PedidoARealizar>();
            listaDePedidosRealizados = new List<PedidoRealizado>();
            nroOperario = 111;
        }

        public List<Operario> ListaDeEmpleados
        {
            get
            {
                return this.listaDeEmpleados;
            }
            set
            {
                this.listaDeEmpleados = value;
            }
        }

        public List<Producto> StockDeProductos
        {
            get
            {
                return this.stockDeProductos;
            }
            set
            {
                this.stockDeProductos = value;
            }
        }

        public List<PedidoARealizar> ListaDePedidosARealizar
        {
            get
            {
                return this.listaDePedidosARealizar;
            }
            set
            {
                this.listaDePedidosARealizar = value;
            }
        }

        public List<PedidoRealizado> ListaDePedidosRealizados
        {
            get
            {
                return this.listaDePedidosRealizados;
            }
            set
            {
                this.listaDePedidosRealizados = value;
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
        /// Agrega un operario a la listaDeEmpleados de la distribuidora
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        public void AgregarOperario(string nombre, string apellido)
        {
            if (nombre != null && apellido != null)
            {
                this.listaDeEmpleados.Add(new Operario(nombre, apellido, nroOperario));
                nroOperario++;
            }
        }

        /// <summary>
        /// Busca en la listaDeEmpleados el empleado correspondiente al nombre pasado como parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns> Devuelve un entero con el nro de empleado del operario correspondiente
        public int BuscarEmpleado(string nombre)
        {
            if (nombre != null)
            {
                foreach (var item in this.listaDeEmpleados)
                {
                    if (nombre == (item.Apellido + ", " + item.Nombre))
                    {
                        return item.NroEmpleado;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Funcion encargada de descontar un producto de la lista de stock de productos
        /// </summary>
        /// <param name="producto"></param>
        public void DescontarStock (Producto_pedido producto)
        {
            if(producto!=null)
            {
                foreach (var item in this.stockDeProductos)
                {
                    if(producto.Cod==item.Cod && producto.Nombre==item.Nombre)
                    {
                        item.Stock -= producto.CantPedida;
                    }
                }
            }
        }

        /// <summary>
        /// Funcion encargada de devolver un producto a la lista de stock de productos
        /// </summary>
        /// <param name="producto"></param>
        public void DevolverStock(Producto_pedido producto)
        {
            if (producto != null)
            {
                foreach (var item in this.stockDeProductos)
                {
                    if (producto.Cod == item.Cod && producto.Nombre == item.Nombre)
                    {
                        item.Stock += producto.CantPedida;
                    }
                }
            }
        }

    }
}
