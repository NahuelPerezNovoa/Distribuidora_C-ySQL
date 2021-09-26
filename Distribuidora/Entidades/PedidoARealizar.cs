using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class PedidoARealizar : Documento, IFuncionalidades
    {
        public PedidoARealizar(DateTime fecha, string cliente, int nroEmpleado, List<Producto_pedido> pedido) : base(fecha, cliente, nroEmpleado, pedido)
        {
        }

        public PedidoARealizar()
        {

        }

        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Fecha.Date.ToShortDateString()}-------CLIENTE: {this.Cliente}         {this.Pedido.Count} ARTICULOS");
            return sb.ToString();
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLIENTE: {this.Cliente}    FECHA:{Fecha.Date.ToShortDateString()}");
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine("COD   PRODUCTO                      CANTIDAD");
            foreach (Producto_pedido item in base.Pedido)
            {
                sb.AppendFormat($"{item.Cod,-6}{item.Nombre,-30}{item.CantPedida,-6}\n");
            }
            sb.AppendLine("//////////////////////////////////////////////");
            return sb.ToString();
        }


    }
}
