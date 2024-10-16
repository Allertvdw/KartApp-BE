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
	public class BookingServiceTests
	{
		private readonly BookingService _bookingService;
		private readonly Mock<IBookingRepository> _mockBookingRepository;

		public BookingServiceTests()
		{
			_mockBookingRepository = new Mock<IBookingRepository>();
			_bookingService = new BookingService(_mockBookingRepository.Object);
		}

		[Fact]
		public async Task GetAllBookings_ShouldReturnAllBookings()
		{
			// Arrange
			var bookings = new List<Booking> { new() { Id = 1 }, new() { Id = 2 } };
			_mockBookingRepository.Setup(repo => repo.GetAllBookings()).ReturnsAsync(bookings);

			// Act
			var result = await _bookingService.GetAllBookings();

			// Assert
			Assert.Equal(bookings.Count, result.Count);
			Assert.Equal(bookings[0].Id, result[0].Id);
		}

		[Fact]
		public async Task GetBookingById_ShouldReturnBooking_WhenBookingExists()
		{
			// Arrange
			var bookingId = 1;
			var booking = new Booking { Id = bookingId };
			_mockBookingRepository.Setup(repo => repo.GetBookingById(bookingId)).ReturnsAsync(booking);

			// Act
			var result = await _bookingService.GetBookingById(bookingId);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(bookingId, result.Id);
		}

		[Fact]
		public async Task GetBookingById_ShouldReturnNull_WhenBookingDoesNotExist()
		{
			// Arrange
			var bookingId = 1;
			_mockBookingRepository.Setup(repo => repo.GetBookingById(bookingId)).ReturnsAsync((Booking?)null);

			// Act
			var result = await _bookingService.GetBookingById(bookingId);

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public async Task CreateBooking_ShouldInvokeRepositoryCreateBooking()
		{
			// Arrange
			var booking = new Booking { Id = 1 };

			// Act
			await _bookingService.CreateBooking(booking);

			// Assert
			_mockBookingRepository.Verify(repo => repo.CreateBooking(booking), Times.Once);
		}
	}
}
