using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.BLL.RequestModels;
using KartAppBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KartAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController(ISessionService sessionService, IBookingUserService bookingUserService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSessions()
        {
            var sessions = await sessionService.GetAllSessions();
            return Ok(sessions);
        }

        [HttpGet("{sessionId}")]
        public async Task<IActionResult> GetSessionById(int sessionId)
        {
            var session = await sessionService.GetSessionById(sessionId);
            return Ok(session);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetSessionDetails(int sessionId)
        {
            var bookingUser = await bookingUserService.GetBookingUserBySessionId(sessionId);
            if (bookingUser == null)
            {
                return NotFound("No details found.");
            }

            var sessionDetailsView = bookingUser.Select(bu => new SessionDetailsView
            {
                SessionDate = bu.Booking.Session.StartTime.Date,
                SessionStartTime = bu.Booking.Session.StartTime,
                SessionEndTime = bu.Booking.Session.EndTime,
                FirstName = bu.User.FirstName,
                LastName = bu.User.LastName,
                KartNumber = bu.Kart.Number,
                BookingId = bu.Booking.Id
            }).ToList();

            return Ok(sessionDetailsView);
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetSessionsByDate(DateTime date)
        {
            var sessions = await sessionService.GetSessionsByDate(date);
            return Ok(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSessions(List<Session> sessions)
        {
            await sessionService.CreateSessions(sessions);
            return Ok();
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateSessions([FromBody] GenerateSessionsRequest request)
        {
            await sessionService.GenerateSessions(request);
            return Ok("Sessions generated successfully.");
        }
    }
}
