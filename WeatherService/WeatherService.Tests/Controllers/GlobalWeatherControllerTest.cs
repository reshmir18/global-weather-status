using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherService.Controllers;

namespace WeatherService.Tests.Controllers
{
    [TestClass]
    public class GlobalWeatherControllerTest
    {
        [TestMethod]
        public void Index()
        {
            GlobalWeatherController controller = new GlobalWeatherController();

            //Invokes controller action
            string result = controller.Index();

            //validation
            Assert.IsNotNull(result);
            Assert.AreEqual("Success", result);
        }
    }
}
