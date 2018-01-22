using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VideoLibrary.BusinessLogic.Repositories.ActorRepository;
using VideoLibrary.BusinessLogic.Repositories.MovieActorRepository;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.Controllers;

namespace VideoLibrary.Tests.ControllerTests
{
    [TestFixture]
    public class MovieActorsControllerTests
    {
        public class MoviesControllerTests
        {
            private Mock<IMovieActorRepository> _moqMovieActorRepository = null;
            private Mock<IActorRepository> _moqActorRepository = null;

            private MovieActorController _moviesActorsController;

            [SetUp]
            public void SetUp()
            {
                _moqMovieActorRepository = new Mock<IMovieActorRepository>();
                _moqActorRepository = new Mock<IActorRepository>();
                _moviesActorsController = new MovieActorController(new ActorService(_moqActorRepository.Object), _moqMovieActorRepository.Object);
            }

            [TearDown]
            public void TearDown()
            {
                _moqActorRepository = null;
                _moqMovieActorRepository = null;
            }



            [Test]
            public void TestForShowActorsDetailsView()
            {
                //act...
                var result = (_moviesActorsController.Index(1)) as ViewResult;

                //assert...
                Assert.AreEqual(string.Empty, result.ViewName);
            }
        }
    }
}
