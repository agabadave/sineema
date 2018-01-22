using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Mvc;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.Controllers;

namespace VideoLibrary.Tests.ControllerTests
{
    [TestFixture]
    public class ActorsControllerTests
    {
        private Mock<IActorService> _moqActorService;

        private ActorsController _actorsController;

        [SetUp]
        public void SetUp()
        {
            _moqActorService = new Mock<IActorService>();
            _actorsController = new ActorsController(_moqActorService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _actorsController = null;
        }

        [Test]
        public async Task TestForValidActorsIndexView()
        {
            //act...
            var result = (await _actorsController.Index()) as ViewResult;

            //assert...
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        //[Test]
        //public async Task TestsMethod()
        //{

        //    var result = await _actorsController.Details(2) as ViewResult;
        //    var client = (Client)result.ViewData.Model;
        //    Assert.AreEqual("Laptop", client.Name);
        //    Assert.AreEqual("Details", result.ViewName);
        //    Assert.IsInstanceOf(typeof(Client), client);
        //}


    }
}
