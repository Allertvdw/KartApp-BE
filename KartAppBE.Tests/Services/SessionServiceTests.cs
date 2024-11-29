using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Models;
using KartAppBE.BLL.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.Tests.Services
{
	public class SessionServiceTests
	{
		private readonly SessionService _sessionService;
		private readonly Mock<ISessionRepository> _mockSessionRepository;

		public SessionServiceTests()
		{
			_mockSessionRepository = new Mock<ISessionRepository>();
			_sessionService = new SessionService(_mockSessionRepository.Object);
		}

		[Fact]
		public async Task GetAllSessions_ShouldReturnAllSessions()
		{
			// Arrange
			var sessions = new List<Session> { new() { Id = 1 }, new() { Id = 2 } };
			_mockSessionRepository.Setup(repo => repo.GetAllSessions()).ReturnsAsync(sessions);

			// Act
			var result = await _sessionService.GetAllSessions();

			// Assert
			Assert.Equal(sessions.Count, result.Count);
			Assert.Equal(sessions[0].Id, result[0].Id);
		}

		[Fact]
		public async Task GetSessionById_ShouldReturnSession_WhenSessionExists()
		{
			// Arrange
			var sessionId = 1;
			var session = new Session() { Id = sessionId };
			_mockSessionRepository.Setup(repo => repo.GetSessionById(sessionId)).ReturnsAsync(session);

			// Act
			var result = await _sessionService.GetSessionById(sessionId);

			// Arrange
			Assert.NotNull(result);
			Assert.Equal(sessionId, result.Id);
		}

		[Fact]
		public async Task GetSessionById_ShouldReturnNull_WhenSessionDoesNotExist()
		{
			// Arrange
			var sessionId = 1;
			_mockSessionRepository.Setup(repo => repo.GetSessionById(sessionId)).ReturnsAsync((Session?)null);

			// Act
			var result = await _sessionService.GetSessionById(sessionId);

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public async Task GetSessionsByDate_ShouldReturnSessions_WhenSessionsExistForGivenDate()
		{
			// Arrange
			var date = new DateTime(2024, 1, 1);
			var sessions = new List<Session> { new() { Id = 1 }, new() { Id = 2 } };
			_mockSessionRepository.Setup(repo => repo.GetSessionsByDate(date)).ReturnsAsync(sessions);

			// Act
			var result = await _sessionService.GetSessionsByDate(date);

			// Assert
			Assert.Equal(sessions.Count, result.Count);
			Assert.Equal(sessions[0].Id, result[0].Id);
		}

		[Fact]
		public async Task CreateSessions_ShouldInvokeRepositoryCreateSessions()
		{
			// Arrange
			var sessions = new List<Session> { new() { Id = 1 }, new() { Id = 2 } };

			// Act
			await _sessionService.CreateSessions(sessions);

			// Assert
			_mockSessionRepository.Verify(repo => repo.CreateSessions(sessions), Times.Once());
		}
	}
}
