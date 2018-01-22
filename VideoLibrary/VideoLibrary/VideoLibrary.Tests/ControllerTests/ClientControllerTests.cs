using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VideoLibrary.BusinessLogic.Repositories.ActorRepository;
using VideoLibrary.BusinessLogic.Repositories.ClientRepository;
using VideoLibrary.BusinessLogic.Services.ClientCrudService;
using VideoLibrary.Controllers;

namespace VideoLibrary.Tests.ControllerTests
{
    [TestFixture]
    public class ClientControllerTests
    {
        public class MoviesControllerTests
        {
            private Mock<IClientRepository> _moqClientRepository = null;

            private ClientsController _clientsController;

            [SetUp]
            public void SetUp()
            {
                _moqClientRepository = new Mock<IClientRepository>();
                _clientsController = new ClientsController(new ClientCrudService(_moqClientRepository.Object));
            }

            [TearDown]
            public void TearDown()
            {
                _moqClientRepository = null;
            }



            [Test]
            public async Task TestForValidListView()
            {
                //act...
                var result =  (await _clientsController.Index()) as ViewResult;

                //assert...
                Assert.AreEqual(string.Empty, result.ViewName);
            }
        }
    }
}
