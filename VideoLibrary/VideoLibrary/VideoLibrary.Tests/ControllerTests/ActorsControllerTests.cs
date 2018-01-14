using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.Controllers;

namespace VideoLibrary.Tests.ControllerTests
{
    [TestFixture]
    public class ActorsControllerTests
    {
        private Mock<Client> _mockClient;

        private ActorsController _actorsController;

        [SetUp]
        public void SetUp()
        {
            _mockClient = new Mock<Client>();
            var _mockActorsService = new Mock<IActorService>();
            _actorsController = new ActorsController(_mockActorsService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _actorsController = null;
        }

        [Test]
        public void TestsMethod()
        {
            // arrange

            // act

            // assert
            Assert.True(true);
        }


    }
}
