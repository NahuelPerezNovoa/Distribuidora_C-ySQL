using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;

namespace Test_Entidades
{
    [TestClass]
    public class Test_Distribuidora
    {
        [TestMethod]
        [DataRow("Juan","Sanchez")]
        public void Test_AgregarOperario_ParamValidos(string nombre, string apellido)
        {
            //ARRANGE
            Distribuidora distribuidora = new Distribuidora();
            distribuidora.NroOperario = 22;
            int cantAlIniciar = distribuidora.ListaDeEmpleados.Count;
            int cantAlFinalizar;
            bool resultado;
            //ACT
            distribuidora.AgregarOperario(nombre, apellido);
            cantAlFinalizar = distribuidora.ListaDeEmpleados.Count;
            resultado = (cantAlIniciar == (cantAlFinalizar - 1)) ? true : false;
            //ASSERT
            Assert.IsTrue(resultado);

        }

        [TestMethod]
        [DataRow(null, null)]
        [DataRow(null, "Sanchez")]
        [DataRow("Juan", null)]
        public void Test_AgregarOperario_ParamInvalidos(string nombre, string apellido)
        {
            //ARRANGE
            Distribuidora distribuidora = new Distribuidora();
            distribuidora.NroOperario = 22;
            int cantAlIniciar = distribuidora.ListaDeEmpleados.Count;
            int cantAlFinalizar;
            bool resultado;
            //ACT
            distribuidora.AgregarOperario(nombre, apellido);
            cantAlFinalizar = distribuidora.ListaDeEmpleados.Count;
            resultado = (cantAlIniciar == (cantAlFinalizar - 1)) ? true : false;
            //ASSERT
            Assert.IsFalse(resultado);

        }


        [TestMethod]
        [DataRow("Mercader, Juan")]
        public void Test_BuscarEmpleado_Valido(string nombre)
        {
            //ARRANGE
            Distribuidora distribuidora = new Distribuidora();
            distribuidora.ListaDeEmpleados.Add(new Operario("Juan", "Mercader", 111));
            distribuidora.ListaDeEmpleados.Add(new Operario("Sebastian", "Almada", 112));
            distribuidora.ListaDeEmpleados.Add(new Operario("Dario", "Lopreite", 113));
            int cod;
            bool resultado;
            //ACT
            cod = distribuidora.BuscarEmpleado(nombre);
            resultado = (cod != 0) ? true : false;
            //ASSERT
            Assert.IsTrue(resultado);

        }


        [TestMethod]
        [DataRow("MercadeR, Juan")]
        [DataRow(null)]
        public void Test_BuscarEmpleado_Invalido(string nombre)
        {
            //ARRANGE
            Distribuidora distribuidora = new Distribuidora();
            distribuidora.ListaDeEmpleados.Add(new Operario("Juan", "Mercader", 111));
            distribuidora.ListaDeEmpleados.Add(new Operario("Sebastian", "Almada", 112));
            distribuidora.ListaDeEmpleados.Add(new Operario("Dario", "Lopreite", 113));
            int cod;
            bool resultado;
            //ACT
            cod = distribuidora.BuscarEmpleado(nombre);
            resultado = (cod != 0) ? true : false;
            //ASSERT
            Assert.IsFalse(resultado);

        }
    }
}
