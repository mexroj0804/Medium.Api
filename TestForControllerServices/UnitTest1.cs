using MediatR;
using Medium.Api.Controllers;
using Medium.Application.UseCases.MediumUser.Commands;
using Medium.Application.UseCases.MediumUser.Queries;
using Medium.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestForControllerServices
{
    public class UnitTest1
    {
        private readonly Mock<IMediator> _mediator = new Mock<IMediator>();

        [Fact]
        public void TestCreatedCommandUser()
        {
            // Arrange
            var inputCommandUser = new CreatedCommandUser()
            {
                Name = "Mexroj",
                UserName = "Good_Boy",
                Email = "mexroj@gmail.com",
                Bio = "Simple is better than complex",
                PhotoPath = "string",
                FollowersCount = 200,
                Login = "Mexroj04",
                PasswordHash = "password"
            };

            _mediator.Setup(m => m.Send(It.IsAny<CreatedCommandUser>)).ReturnsAsync(inputCommandUser);

            var controller = new UserController(_mediator.Object);

            // Act
            var result = controller.CreateUser(inputCommandUser);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Ma'lumot yaratildi!", okResult.Value);
        }

        [Fact]
        public void TestGetAllUsersCommandQuery()
        {
            //Arrange
            var expectedUsers = new List<User>();
            var queryResult = new GetAllUsersCommandQuery();

            //Act
            _mediator.Setup(x => x.Send()).ReturnsAsync(queryResult);

            var controller = new UserController( _mediator.Object);

            var result = controller.GetAllUsers();

            //Assert

            var value = result.Result.Value;
            var users = Assert.IsAssignableFrom<List<User>>(value);
            Assert.Equal(expectedUsers, users);
        }

        [Fact]
        public async void TestDeleteUserCommand()
        {
            var id = Guid.NewGuid();
            var expectedResult = new DeleteUserCommand();

            _mediator.Setup(x => x.Send(id)).ReturnsAsync(expectedResult);

            var controller = new UserController(_mediator.Object);

            var result = await controller.DeleteUser(id);

            //Assert

            Assert.Equal("Foydalanuvchi o'chirildi!", result.Value);
        }

        [Fact]
        public async void TestForGetUserById()
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                UserName = "Test",
                Email = "Test",
                PasswordHash = "Test"
            };

            _mediator.Setup(x => x.Send(It.IsAny<GetByIdUserCommandQuery>)).ReturnsAsync(user);
            var controller = new UserController(_mediator.Object);

            var result = await controller.GetById(user.Id);

            var returnProduct = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user, returnProduct.Value);
        }
    }
}