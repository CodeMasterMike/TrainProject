using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject.Tests
{
    [TestClass()]
    public class TrackControllerModuleTests
    {
        TrackControllerModule module = new TrackControllerModule();
        [TestMethod()]
        public void updateSpeedAndAuthorityTest()
        {
            module.dispatchNewTrain(0, new TrainModelProject.TrainModel(), 0.0, 0);
            module.updateSpeedAndAuthority(0, 15.0, 5);
            Assert.Fail();
        }

        [TestMethod()]
        public void closeBlockTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void updateBlockOccupancyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void openBlockTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void causeFailureTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void dispatchNewTrainTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void checkSafetyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void trainHeadingTowardsSwitchTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void shutdownTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void resumeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getSwitchStateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void initializeSwitchesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void initializeCrossingsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void initializeTrackControllersTest()
        {
            Assert.Fail();
        }
    }
}