using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ConsolaDePrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            //PRUEBA MostrarDatos() IFuncionalidades

            List<Producto_pedido> listaProductosPedidos = new List<Producto_pedido>();
            listaProductosPedidos.Add(new Producto_pedido("Cabezal Peirano Mesada", "2114", 26, 4));
            listaProductosPedidos.Add(new Producto_pedido("Cabezal Peirano Lavatorio", "2115", 30, 4));
            listaProductosPedidos.Add(new Producto_pedido("Cabezal Peirano Ducha", "2116", 15, 4));
            listaProductosPedidos.Add(new Producto_pedido("Cabezal Peirano Bidet", "2117", 10, 4));
            PedidoARealizar pedidoARealizar = new PedidoARealizar(DateTime.Now, "Sanit. Dominguez", 134, listaProductosPedidos);
            Console.WriteLine(pedidoARealizar.ToString());

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------\n");


            List<Producto_pedido> listaProductosPedidos2 = new List<Producto_pedido>();
            listaProductosPedidos2.Add(new Producto_pedido("Cabezal Peirano Mesada", "2114", 26, 4));
            listaProductosPedidos2.Add(new Producto_pedido("Cabezal Peirano Lavatorio", "2115", 30, 4));
            listaProductosPedidos2.Add(new Producto_pedido("Cabezal Peirano Ducha", "2116", 15, 4));
            listaProductosPedidos2.Add(new Producto_pedido("Cabezal Peirano Bidet", "2117", 10, 4));
            PedidoRealizado pedidoRealizado = new PedidoRealizado(DateTime.Now, "Sanit. Dominguez", 134, listaProductosPedidos);
            Console.WriteLine(pedidoRealizado.ToString());

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------\n");

            Producto_pedido prodPedido = new Producto_pedido("Cabezal Peirano Mesada", "2114", 26, 4);
            Console.WriteLine(prodPedido.ToString());

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------\n");

            Producto producto = new Producto("Cabezal Peirano Mesada", "2114", 26);
            Console.WriteLine(producto.ToString());

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------\n");

            Operario operario = new Operario("Nahuel", "Perez Novoa", 111);
            Console.WriteLine(operario.ToString());

            //--------------------------------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------------------------
            //PRUEBA SerializaciónYGuardado
            try
            {
                List<Object> lista = new List<object>();
                lista.Add(pedidoARealizar);
                lista.Add(AppDomain.CurrentDomain.BaseDirectory + pedidoARealizar.Cliente + pedidoARealizar.Fecha.ToString("dd'_'MM'_'yyyy") + " A REALIZAR.txt");

                SerializacionYGuardado.GuardarEnTxt(lista);

                List<Object> lista2 = new List<object>();
                lista2.Add(pedidoARealizar.Pedido);
                lista2.Add(AppDomain.CurrentDomain.BaseDirectory + pedidoARealizar.Cliente + pedidoARealizar.Fecha.ToString("dd'_'MM'_'yyyy") + " A REALIZAR.txt");

                SerializacionYGuardado.GuardarEnXml<Producto_pedido>(lista2);

                Console.WriteLine("Presione una tecla para leer el archivo");
                Console.ReadKey();
                List<Producto_pedido> pedidoLevantado = new List<Producto_pedido>();
                pedidoLevantado = SerializacionYGuardado.LeerXml<Producto_pedido>(pedidoLevantado, AppDomain.CurrentDomain.BaseDirectory + pedidoARealizar.Cliente + pedidoARealizar.Fecha.ToString("dd'_'MM'_'yyyy") + ".xml");
                foreach (Producto_pedido item in pedidoLevantado)
                {
                    Console.WriteLine(item.ToString());
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("Error en pueba de SerializaciónYGuardado. Se produjo la siguiente excepción: ");
                Console.WriteLine(exc.Message);
            }


            //--------------------------------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------------------------

            Console.ReadKey();
        }
    }
}
