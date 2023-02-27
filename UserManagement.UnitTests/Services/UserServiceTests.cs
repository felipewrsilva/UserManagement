using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;
using UserManagement.Application.Services;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repositories;

namespace UserManagement.UnitTests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserRepository _userRepositoryMock;
        private IMapper _mapperMock;
        private IValidator<UserDTO> _userValidatorMock;
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = Mock.Of<IUserRepository>();
            _mapperMock = Mock.Of<IMapper>();
            _userValidatorMock = Mock.Of<IValidator<UserDTO>>();
            _userService = new UserService(_userRepositoryMock, _mapperMock, _userValidatorMock);
        }

        [Test]
        public async Task GetByIdAsync_WithExistingUser_ShouldReturnUserDTO()
        {
            // Arrange
            int userId = 1;
            var user = new User { Id = userId };
            var userDTO = new UserDTO { Id = userId };
            Mock.Get(_userRepositoryMock).Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);
            Mock.Get(_mapperMock).Setup(mapper => mapper.Map<UserDTO>(user)).Returns(userDTO);

            // Act
            var result = await _userService.GetByIdAsync(userId);

            // Assert
            result.Should().BeEquivalentTo(userDTO);
        }
    }
}
