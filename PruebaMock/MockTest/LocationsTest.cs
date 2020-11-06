using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaMock.Entities;
using Moq;
using PruebaMock.Data;
using PruebaMock.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MockTest
{
    [TestClass]
    public class LocationsTest
    {
        private readonly Mock<DbSet<LOCATIONS>> mockSet;
        private readonly Mock<EmpresaContext> mockContext;

        public LocationsTest()
        {
            mockSet = new Mock<DbSet<LOCATIONS>>();
            mockContext = new Mock<EmpresaContext>();
        }


        [TestMethod]
        public void CreatesLocations_SaveValidLocation()
        {
            // ARRANGE
            mockContext.Setup(m => m.LOCATIONS).Returns(mockSet.Object);
            var newLocation = new LOCATIONS
            {
                ID = 5
            };

            // ACT
            var location = new LocationsLogic(mockContext.Object);
            location.Insert(newLocation);

            // ASSERT
            mockSet.Verify(m => m.Add(It.IsAny<LOCATIONS>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());


        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreatesLocations_NullIdLocation()
        {
            // ARRANGE
            mockContext.Setup(m => m.LOCATIONS).Returns(mockSet.Object);

            var newLocation = new LOCATIONS(); 

            // ACT
            var location = new LocationsLogic(mockContext.Object);
            location.Insert(newLocation);

            // ASSERT manejado por la Excepcion

        }

        //Este todavia no funciona
        [TestMethod]
        public void GetAllLocations_Valid()
        {
            // ARRANGE
            mockContext.Setup(m => m.LOCATIONS).Returns(mockSet.Object);
            var data = new List<LOCATIONS>
            {
                new LOCATIONS {ID = 1},
                new LOCATIONS {ID = 2},
                new LOCATIONS {ID = 3}
            }.AsQueryable();
            var locationLogic = new LocationsLogic(mockContext.Object);

            //ACT
            var locations = locationLogic.GetAll();

            // ASSERT
            Assert.Equals(3, locations.Count);
        }
    }
}
