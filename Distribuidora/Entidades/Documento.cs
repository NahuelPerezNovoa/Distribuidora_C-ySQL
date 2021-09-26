using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        DateTime fecha;
        string cliente;
        int nroEmpleado;
        List<Producto_pedido> pedido;

        public Documento(DateTime fecha, string cliente, int nroEmpleado, List<Producto_pedido> pedido)
        {
            this.Fecha = fecha;
            this.Cliente = cliente;
            this.NroEmpleado = nroEmpleado;
            this.Pedido = pedido;
        }

        public Documento()
        {
            this.Pedido = new List<Producto_pedido>();
        }

        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }
        }
        public string Cliente
        {
            get
            {
                return this.cliente;
            }
            set
            {
                this.cliente = value;
            }
        }
        public int NroEmpleado
        {
            get
            {
                return this.nroEmpleado;
            }
            set
            {
                this.nroEmpleado = value;
            }
        }
        public List<Producto_pedido> Pedido
        {
            get
            {
                return this.pedido;
            }
            set
            {
                this.pedido = value;
            }
        }
    }
}
