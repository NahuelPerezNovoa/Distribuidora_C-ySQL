using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto_pedido : Producto, IFuncionalidades
    {
        int cantPedida;

        public Producto_pedido(string nombre, string cod, int stock, int cantPedida) : base(nombre, cod, stock)
        {
            this.CantPedida = cantPedida;
        }

        public Producto_pedido()
        {

        }

        public int CantPedida
        {
            get
            {
                return this.cantPedida;
            }
            set
            {
                this.cantPedida = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{this.Cod,-6}{this.Nombre,-30}{this.CantPedida,4}");
            return sb.ToString();
        }
    }
}
