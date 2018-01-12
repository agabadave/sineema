using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
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
            _actorsController = new ActorsController();
        }

        [TearDown]
        public void TearDown()
        {
            _actorsController = null;
        }

        [Test]
        public void TestsMethod()
        {
            Assert.True(true);
        }


    }
}
