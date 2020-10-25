using Microsoft.VisualStudio.TestTools.UnitTesting;
using POOExceptions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOExceptions.Extensions.Tests
{
    [TestClass()]
    public class FloatExtensionsTests
    {

        //Valida que devuelva una excepcion al dividir por cero
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirPorCeroTest()
        {
            //Arrange
            int numero = 2;

            //Act
            numero.DividirPorCero();

            //Assert controlado por la excepcion
        }

        //Valdia que devuleva un resultado correspondiente a la division de dos numeros
        [TestMethod]
        public void DividirPorTest_DosNumerosReales()
        {
            //Arrange
            int dividendo = 2;
            int divisor = 3;
            decimal resultadoEsperado = (decimal)dividendo / divisor;

            //Act
            decimal resultado = dividendo.DividirPor(divisor);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        //Valida que devuelva un error al dividir por cero
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirPorTest_DivisiorIgualACero()
        {
            //Arrange
            int dividendo = 2;
            int divisor = 0;

            //Act y Assert
            dividendo.DividirPor(divisor);
        }

    }
}