using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.GenderRepository;
using VideoLibrary.BusinessLogic.Repositories.GenreRepository;
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
            var _mockGenderRepository = new Mock<IGenderRepository>();
            var _mockGenreRepository = new Mock<IGenreRepository>();
            _actorsController = new ActorsController(_mockActorsService.Object, _mockGenderRepository.Object, _mockGenreRepository.Object);
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
