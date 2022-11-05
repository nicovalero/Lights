using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using PhilipsHue.Models.Interfaces;
using PhilipsHue.Models.Classes;
using System.Collections.Generic;

namespace PhilipsHueTestProject
{
    [TestClass]
    public class BridgeV2FinderTests
    {
        [TestMethod]
        public void FindAll_WithNonNullPath_ReturnsNonNullBridgeList()
        {
            //Arrange
            var finder = new BridgeV2Finder("https://discovery.meethue.com");

            //Act
            var list = finder.FindAll();

            //Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list is List<Bridge>);
        }

        [TestMethod]
        public void FindAll_WithNullPath_ReturnsEmptyBridgeList()
        {
            //Arrange
            var finder = new BridgeV2Finder(null);

            //Act
            var list = finder.FindAll();

            //Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list is List<Bridge>);
        }

        [TestMethod]
        public void ParseResponseContent_WithNonNullContentString_ReturnsNonNullHueBridgeV2ResponseList()
        {
            //Arrange
            var content = "[{\"id\":\"ecb5fafffe056137\",\"internalipaddress\":\"192.168.1.213\",\"port\":443}]";
            var content2 = "hello";
            var finder = new BridgeV2Finder("");
            PrivateObject obj = new PrivateObject(finder);

            //Act
            var list = obj.Invoke("ParseResponseContent",content);
            var list2 = obj.Invoke("ParseResponseContent", content2);

            //Assert
            Assert.IsNotNull(list);
            Assert.IsNotNull(list2);
            Assert.IsTrue(list is List<HueBridgeV2Response>);
            Assert.IsTrue(list2 is List<HueBridgeV2Response>);
        }

        [TestMethod]
        public void ParseResponseContent_WithNullContentString_ReturnsNonNullHueBridgeV2ResponseList()
        {
            //Arrange
            string content = null;
            var finder = new BridgeV2Finder("");
            PrivateObject obj = new PrivateObject(finder);

            //Act
            var list = obj.Invoke("ParseResponseContent", content);

            //Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list is List<HueBridgeV2Response>);
        }
    }
}
