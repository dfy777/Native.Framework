using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.dfy.demo.Code;

namespace UnitTestProject1
{
    [TestClass]
    public class SimulatorTest
    {
        [TestMethod]
        public void Simulator_BuilElement_OK()
        {
            Simulator simulator = new Simulator();
            simulator.BuildElement(999, 999, 999, 999, 50);
        }
    }

    
}
