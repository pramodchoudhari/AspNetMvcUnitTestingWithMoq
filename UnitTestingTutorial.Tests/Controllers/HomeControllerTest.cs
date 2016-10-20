using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingTutorial;
using UnitTestingTutorial.Controllers;
using UnitTestingTutorial.Models;
using UnitTestingTutorial.ServiceAgent;
using Moq;
using System.Web;

namespace UnitTestingTutorial.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        Mock<ICommunityManager> _communityManager;
        HomeController _homeController;

        [TestInitialize]
        public void Init()
        {
            _homeController = new HomeController();
            var controllerContext = new Mock<ControllerContext>();
            _communityManager = new Mock<ICommunityManager>();
            _communityManager.Setup(init => init.GetCommunities()).Returns(GetCommunities());
            _homeController.ControllerContext = controllerContext.Object;
        }

        private List<CommunityModel> GetCommunities()
        {
            List<CommunityModel> result = new List<CommunityModel>();
            result.Add(new CommunityModel { ID = 1, Name = "Pramod" });
            result.Add(new CommunityModel { ID = 2, Name = "Pramod 1" });

            return result;
        }

        [TestMethod]
        public void Index()
        {
            _homeController = new HomeController(_communityManager.Object);
            // Act
            ViewResult result = _homeController.Index() as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var modelList = ((result as ViewResult).Model as List<CommunityModel>);
            Assert.AreEqual(modelList.Count, 2);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            var controllerContext = new Mock<ControllerContext>();

            controllerContext.Setup(m => m.HttpContext.Session).Returns(GetSessionValue());
            _homeController = new HomeController();
            _homeController.ControllerContext = controllerContext.Object;
            var sessionValue = (string)_homeController.Session["Test"];
            Assert.AreEqual("Test", sessionValue);

        }

        private HttpSessionStateBase GetSessionValue()
        {
            var session = new MockHttpSession();
            session["Test"] = "testd";
            return session;
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
    //Mock Session object
    public class MockHttpSession : HttpSessionStateBase
    {
        Dictionary<string, object> m_SessionStorage = new Dictionary<string, object>();

        public override object this[string name]
        {
            get { return m_SessionStorage[name]; }
            set { m_SessionStorage[name] = value; }
        }
    }
}
