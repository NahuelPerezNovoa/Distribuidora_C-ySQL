using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ReadFileErrorException : Exception
    {
        public ReadFileErrorException() : base("Error al momento de leer el archivo") { }
    }
}
