using DnDRoom.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace DnDRoom.Tests
{
    public class RoomControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Create_CheckOnlyAuthUsers()
        {
            bool isDefined = typeof(RoomControllers).GetMethod(nameof(RoomControllers.Create)).IsDefined(typeof(AuthorizeAttribute), false);
            Assert.IsTrue(isDefined);
        }
    }
}