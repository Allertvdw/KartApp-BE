using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Models;
using KartAppBE.BLL.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.Tests.Services
{
	public class UserServiceTests
	{
		private readonly UserService _userService;
		private readonly Mock<IUserRepository> _mockUserRepository;

		public UserServiceTests()
		{
			_mockUserRepository = new Mock<IUserRepository>();
			_userService = new UserService(_mockUserRepository.Object);
		}

		[Fact]
		public async Task GetAllUsers_ShouldReturnAllUsers()
		{
			// Arrange
			var users = new List<User> { new() { Id = "GUID1" }, new() { Id = "GUID2" } };
			_mockUserRepository.Setup(repo => repo.GetAllUsers()).ReturnsAsync(users);

			// Act
			var result = await _userService.GetAllUsers();

			// Assert
			Assert.Equal(users.Count, result.Count);
			Assert.Equal(users[0].Id, result[0].Id);
		}

		[Fact]
		public async Task GetByEmail_ShouldReturnUser_WhenUserExists()
		{
			// Arrange
			var email = "test@example.com";
			var expectedUser = new User
			{
				Email = email,
				FirstName = "John",
				LastName = "Doe",
			};
			_mockUserRepository.Setup(repo => repo.GetByEmail(email)).ReturnsAsync(expectedUser);

			// Act
			var result = await _userService.GetByEmail(email);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedUser, result);
		}

		[Fact]
		public async Task GetByEmail_ShouldReturnNull_WhenUserDoesNotExist()
		{
			// Arrange
			var email = "test@example.com";
			_mockUserRepository.Setup(repo => repo.GetByEmail(email)).ReturnsAsync((User?)null);

			// Act
			var result = await _userService.GetByEmail(email);

			// Assert
			Assert.Null(result);
		}
	}
}
