using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using POOExceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOExceptionsTests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LogicExceptionTest()
        {
            //Nada que en el Arrange

            //Act 
            Logic.DispararExcepcion();

            //Arrange controlado por la excepcion
        }
    }
}
