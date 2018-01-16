using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.MovieRepository;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;

namespace VideoLibrary.Tests.Services.MovieService
{
    [TestFixture]
    public class MovieServiceTests
    {
        private Mock<IMovieRepository> _mockMovieRepo;
        private IMovieService _movieService;

        [SetUp]
        public void SetUp()
        {
            _mockMovieRepo = new Mock<IMovieRepository>() { CallBase = true };
            _movieService = new BusinessLogic.Services.MovieCrudService.MovieService(_mockMovieRepo.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockMovieRepo = null;
            _movieService = null;
        }
        [Test]
        public void GetMoviesByTitleTest()
        {
            string title = "Hansen";
           var actual = _movieService.GetMovieByTitle(title);
            Assert.IsInstanceOf(typeof(Task<List<Movie>>), actual);
            Assert.IsNotNull(actual);
        }
    }
}
