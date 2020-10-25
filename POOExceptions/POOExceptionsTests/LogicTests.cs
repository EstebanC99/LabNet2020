using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using POOExceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POOExceptions.Exceptions;

namespace POOExceptionsTests
{
    [TestClass()]
    public class LogicTests
    {
        //Valida que se dispare una excepcion al llamar al metodo de Logic
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LogicExceptionTest()
        {
            //Nada que en el Arrange

            //Act 
            Logic.DispararExcepcion();

            //Arrange controlado por la excepcion
        }


        //Valida que se dispare una excepcion personalizada al llamar al metodo de Logic
        [TestMethod()]
        [ExpectedException(typeof(CustomException))]
        public void LogicExceptionTest_CustomException()
        {
            //Arrange
            string mensajePersonalizado = "Prueba test";

            //Act 
            Logic.DispararExcepcionPersonalizada(mensajePersonalizado);

            //Assert controlado por la excepcion
        }
    }
}
