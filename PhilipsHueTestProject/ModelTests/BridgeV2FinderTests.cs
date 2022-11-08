using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using PhilipsHue.Models.Interfaces;
using PhilipsHue.Models.Classes;
using System.Collections.Generic;
using System.Reflection;

namespace PhilipsHueTestProject.ModelTests
{
    [TestClass]
    public class BridgeV2FinderTests
    {
        private BridgeV2Finder _finder;

        [TestMethod]
        public void FindAll_WithNonNullPath_ReturnsNonNullBridgeList()
        {
            //Arrange
            _finder = new BridgeV2Finder("https://discovery.meethue.com");

            //Act
            var list = _finder.FindAll();

            //Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list is List<Bridge>);
        }

        [TestMethod]
        public void FindAll_WithNullPath_ReturnsEmptyBridgeList()
        {
            //Arrange
            _finder = new BridgeV2Finder(null);

            //Act
            var list = _finder.FindAll();

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
            _finder = new BridgeV2Finder("anything");
            PrivateObject obj = new PrivateObject(_finder);

            //Act
            var list = obj.Invoke("ParseResponseContent", content);
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
            _finder = new BridgeV2Finder(null);
            PrivateObject obj = new PrivateObject(_finder);

            //Act
            var list = obj.Invoke("ParseResponseContent", content);

            //Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list is List<HueBridgeV2Response>);
        }

        [TestMethod]
        public void ConvertToBridgeV2_WhenContentIsNotNull_ReturnsNonNullBridgeList()
        {
            //Arrange
            List<HueBridgeV2Response> content = new List<HueBridgeV2Response>();

            List<HueBridgeV2Response> content2 = new List<HueBridgeV2Response>();
            content2.Add(new HueBridgeV2Response());

            List<HueBridgeV2Response> content3 = new List<HueBridgeV2Response>();
            HueBridgeV2Response response = new HueBridgeV2Response();
            response.internalipaddress = "https://192.168.1.123";
            HueBridgeV2Response response2 = new HueBridgeV2Response();
            response2.internalipaddress = "hello.com";
            HueBridgeV2Response response3 = new HueBridgeV2Response();
            response3.internalipaddress = "anything";
            content3.Add(response);
            content3.Add(response2);
            content3.Add(response3);

            _finder = new BridgeV2Finder("");
            PrivateObject obj = new PrivateObject(_finder);

            //Act
            var list = obj.Invoke("ConvertToBridgeV2", content);
            var list2 = obj.Invoke("ConvertToBridgeV2", content2);
            var list3 = obj.Invoke("ConvertToBridgeV2", content3);

            //Assert
            Assert.IsNotNull(list);

            Assert.IsNotNull(list2);

            Assert.IsNotNull(list3);
        }

        [TestMethod]
        public void ConvertToBridgeV2_WhenContentIsNull_ReturnsNonNullBridgeList()
        {
            //Arrange
            List<HueBridgeV2Response> content = null;

            _finder = new BridgeV2Finder("");
            PrivateObject obj = new PrivateObject(_finder);

            //Act
            var list = obj.Invoke("ConvertToBridgeV2", content);

            //Assert
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void ConvertToBridgeV2_WhenContentIsNull_ReturnsBridgeList()
        {
            //Arrange
            List<HueBridgeV2Response> content = null;

            _finder = new BridgeV2Finder("");
            PrivateObject obj = new PrivateObject(_finder);

            //Act
            var list = obj.Invoke("ConvertToBridgeV2", content);

            //Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list is List<Bridge>);
        }

        [TestMethod]
        public void ConvertToBridgeV2_WhenContentIsNotNull_ReturnsBridgeList()
        {
            //Arrange
            List<HueBridgeV2Response> content = new List<HueBridgeV2Response>();

            _finder = new BridgeV2Finder("");
            PrivateObject obj = new PrivateObject(_finder);

            //Act
            var list = obj.Invoke("ConvertToBridgeV2", content);

            //Assert
            Assert.IsNotNull(list); 
            Assert.IsTrue(list is List<Bridge>);
        }
    }
}
