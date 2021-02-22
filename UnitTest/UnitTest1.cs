using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmpireEye;
using WebApplication1.Services;
using WebApplication1;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {



        [TestMethod]
        public void GetRebelThenGetRebel()
        {
            var rebelService = new RebelService();
            Rebel mockRebel = new Rebel("Yoda", "Dagobah");

            Rebel rebel = rebelService.GetRebel("Yoda");

            Assert.AreEqual(mockRebel.Name, rebel.Name);
            Assert.AreEqual(mockRebel.Planet, rebel.Planet);

        }

        [TestMethod]
        public void GetRebelThenNotGetRebel()
        {
            var rebelService = new RebelService();
            Rebel mockRebel = new Rebel("YodaX", "DagobahX");


            Rebel rebel = rebelService.GetRebel("Yoda");

            Assert.AreNotEqual(mockRebel.Name, rebel.Name);
            Assert.AreNotEqual(mockRebel.Planet, rebel.Planet);
        }
    }
}
