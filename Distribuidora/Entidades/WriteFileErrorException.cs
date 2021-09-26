using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class WriteFileErrorException : Exception
    {
        public WriteFileErrorException() : base ("Error al momento de escribir el archivo") { }
    }
}
