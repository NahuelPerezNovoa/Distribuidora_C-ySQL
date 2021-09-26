using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test_Entidades
{
    [TestClass]
    public class Test_Excepciones
    {
        [TestMethod]
        [ExpectedExceptionAttribute(typeof(WriteFileErrorException))]
        public void Test_GuardarEnTxt_Excepcion()
        {
            List<string> lista = new List<string>();
            SerializacionYGuardado.GuardarEnTxt(lista);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(WriteFileErrorException))]
        public void Test_GuardarEnXml_Excepcion()
        {
            List<string> lista = new List<string>();
            SerializacionYGuardado.GuardarEnXml<string>(lista);
        }

       
    }
}
