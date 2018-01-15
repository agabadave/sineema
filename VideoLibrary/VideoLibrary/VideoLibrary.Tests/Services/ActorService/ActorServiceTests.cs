using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.ActorRepository;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;

namespace VideoLibrary.Tests.Services.ActorService
{
    [TestFixture]
    public class ActorServiceTests
    {

        private Mock<IActorRepository> _mockActorRepo;
        private IActorService _actorService;

        [SetUp]
        public void SetUp()
        {
            _mockActorRepo = new Mock<IActorRepository>() { CallBase = true };
            _actorService = new BusinessLogic.Services.ActorCrudService.ActorService(_mockActorRepo.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockActorRepo = null;
            _actorService = null;
        }

        [Test]
        public async Task SavingActor_AddsActor_ThroughRepository()
        {
            // arrange
            var newActor = new Actor
            {
                DateOfBirth = DateTime.Now,
                Firstname = "First name",
                Lastname = "Last name"
            };

            // act
            await _actorService.SaveActorAsync(newActor);

            // assert
            _mockActorRepo.Verify(m => m.AddActorAsync(It.IsAny<Actor>()), Times.Once());
        }

        [Test]
        public async Task GettingActor_UsingId_QueriesRepository()
        {
            // arrange
            var actorId = Guid.NewGuid();

            // act
            await _actorService.GetActorByIdAsync(actorId);

            // assert
            _mockActorRepo.Verify(m => m.GetActorByIdAsync(It.IsAny<Guid>()), Times.Once());
        }

        [Test]
        public async Task GettingActors_QueriesRepository()
        {
            // act
            await _actorService.GetActorsAsync();

            // assert
            _mockActorRepo.Verify(m => m.GetAllActorsAsync(), Times.Once());
        }
    }
}
