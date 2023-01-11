using DnDRoom.Data;
using DnDRoom.Models;
using DnDRoom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Tests
{
    public class RoomServiceTests
    {
        [Test]
        public void Create_invalidInputParameters_Exception()
        {
            //arrange
            RoomService service = new RoomService(NSubstitute.Substitute.For<IUserService>(), 
                NSubstitute.Substitute.For<IRoomRepo>());
            //Act
            Assert.ThrowsAsync<Exception>(() => service.Create(null, "123"));
            Assert.ThrowsAsync<Exception>(() => service.Create(new RoomCreateRequest("test"), null));
            Assert.ThrowsAsync<Exception>(() => service.Create(new RoomCreateRequest("test"), string.Empty));
        }
    }
}
