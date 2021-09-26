using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operario : IFuncionalidades
    {
        string nombre;
        string apellido;
        int nroOperario;

        public Operario(string nombre, string apellido, int nroEmpleado)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nroOperario = nroEmpleado;
        }

        public Operario()
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

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }


        public int NroEmpleado
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.nroOperario,-6}{this.Nombre,-15}{this.Apellido,-15}");
            return sb.ToString();
        }
    }
}
