using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.ActorRepository;
using VideoLibrary.BusinessLogic.Repositories.MovieRepository;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;
using VideoLibrary.Controllers;

namespace VideoLibrary.Tests.ControllerTests
{
    [TestFixture]
    public class MoviesControllerTests
    {
        private Mock<IMovieRepository> _moqMovieRepository = null;
        private Mock<IActorRepository> _moqActorRepository = null;

        private MoviesController _moviesController;

        [SetUp]
        public void SetUp()
        {
            _moqMovieRepository = new Mock<IMovieRepository>();
            _moqActorRepository = new Mock<IActorRepository>();

            _moviesController = new MoviesController(new MovieService(_moqMovieRepository.Object), new ActorService(_moqActorRepository.Object));
        }

        [TearDown]
        public void TearDown()
        {
            _moqActorRepository = null;
            _moqMovieRepository = null;
        }

        [Test]
        public async Task Should_Call_GetMovies_Once()
        {
            //arrange...
            _moqMovieRepository.Setup(c => c.GetAll()).ReturnsAsync(new List<Movie>() {new Movie() {Id = 1, DateAdded = DateTime.Now, Genre = Genre.Kinigeria, Duration = 250, IsActive = true, Title = "Nigerian Movie"} });

            //act...
            await _moviesController.Index();

            //assert...
            _moqMovieRepository.Verify(x => x.GetAll(), Times.Once());
        }
    }
}
