using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : IFuncionalidades
    {
        string nombre;
        string cod;
        int stock;

        public Producto(string nombre, string cod, int stock)
        {
            this.nombre = nombre;
            this.cod = cod;
            this.stock = stock;
        }

        public Producto()
        {

        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Cod
        {
            get
            {
                return this.cod;
            }
            set
            {
                this.cod = value;
            }
        }

        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                this.stock = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{this.Cod,-6}{this.Nombre,-30}{this.Stock,4}\n");
            return sb.ToString();
        }
    }
}
