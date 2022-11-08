using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Interfaces;
using System;

namespace PhilipsHueTestProject.ModelTests
{
    [TestClass]
    public class HueBridgeV2Tests
    {
        [TestMethod]
        public void AddGroup_WhenGroupIsNotNull_AddsToGroupsSuccessfully()
        {
            //Arrange
            var bridge = new HueBridgeV2(null);
            var bridge2 = new HueBridgeV2(new Uri("https://anything.com"));

            //Need to implement the groups first to pass this test
            //Act
            //bridge.AddGroup(1, new Group());
            //bridge2.AddGroup(1, new Group());

            //Assert
            Assert.IsTrue(bridge.Groups.Count == 1);
            Assert.IsTrue(bridge2.Groups.Count == 1);
        }

        [TestMethod]
        public void AddGroup_WhenGroupIsNull_DoesNotAddToGroups()
        {
            //Arrange
            var bridge = new HueBridgeV2(null);
            var bridge2 = new HueBridgeV2(new Uri("https://anything.com"));
            var groupCountBefore = bridge.Groups.Count;
            var group2CountBefore = bridge2.Groups.Count;

            //Need to implement the groups first to pass this test
            //Act
            bridge.AddGroup(1, null);
            bridge2.AddGroup(1, null);

            //Assert
            Assert.AreEqual(bridge.Groups.Count, groupCountBefore);
            Assert.AreEqual(bridge2.Groups.Count, group2CountBefore);
        }
    }
}
