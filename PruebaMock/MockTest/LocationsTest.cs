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

        private void LoadfakeData()
        {
            var fakeData = new List<LOCATIONS>
            {
                new LOCATIONS {ID = 1},
                new LOCATIONS {ID = 2},
                new LOCATIONS {ID = 3}
            }.AsQueryable();
            mockSet.As<IQueryable<LOCATIONS>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockSet.As<IQueryable<LOCATIONS>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockSet.As<IQueryable<LOCATIONS>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockSet.As<IQueryable<LOCATIONS>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());
        }

        [TestMethod]
        public void CreatesLocations_SaveValidLocation()
        {
            // ARRANGE
            mockContext.Setup(m => m.LOCATIONS).Returns(mockSet.Object);
            var newLocation = new LOCATIONS
            {
                ID = 1
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
            // Carga los datos de prueba
            LoadfakeData();

            mockContext.Setup(c => c.LOCATIONS).Returns(mockSet.Object);
            var location = new LocationsLogic(mockContext.Object);

            // ACT AND ASSERT
            Assert.AreEqual(3, location.GetAll().Count);
        }

        [TestMethod]
        public void GetOneLocations_Valid()
        {
            // ARRANGE
            LoadfakeData();
            int idExpected = 2;
            mockContext.Setup(c => c.LOCATIONS).Returns(mockSet.Object);
            var location = new LocationsLogic(mockContext.Object);

            // ACT AND ASSERT
            Assert.AreEqual(idExpected, location.GetOne(2).ID);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetOneLocations_Failed()
        {
            // ARRANGE
            LoadfakeData();
            mockContext.Setup(c => c.LOCATIONS).Returns(mockSet.Object);
            var location = new LocationsLogic(mockContext.Object);

            // ACT AND ASSERT
            location.GetOne(0);

        }
    }
}
