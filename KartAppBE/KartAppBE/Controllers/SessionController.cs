using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.BLL.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KartAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController(ISessionService sessionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSessions()
        {
            var sessions = await sessionService.GetAllSessions();
            return Ok(sessions);
        }

        [HttpGet("{date}")]
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
