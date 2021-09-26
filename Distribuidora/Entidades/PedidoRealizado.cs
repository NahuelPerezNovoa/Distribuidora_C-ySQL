using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PedidoRealizado : Documento, IFuncionalidades
    {
        public PedidoRealizado(DateTime fecha, string cliente, int nroEmpleado, List<Producto_pedido> pedido) : base(fecha, cliente, nroEmpleado, pedido)
        {
        }
        public PedidoRealizado()
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLIENTE: {this.Cliente}    FECHA:{Fecha.Date.ToShortDateString()}");
            sb.AppendLine("-----------------------------------------------");
            sb.AppendLine("COD   PRODUCTO                      CANTIDAD");
            foreach (var item in base.Pedido)
            {
                sb.AppendFormat($"{item.Cod,-6}{item.Nombre,-30}{item.CantPedida,4}\n");
            }
            sb.AppendLine("///////////////////////////////////////////////");
            return sb.ToString();
        }
    }
}
