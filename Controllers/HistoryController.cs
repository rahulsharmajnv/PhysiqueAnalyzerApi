using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhysiqueAnalyzerApi.DTOs;
using PhysiqueAnalyzerApi.Services;
using System.Linq;
using System.Security.Claims;

namespace PhysiqueAnalyzerApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        [HttpGet]
        public IActionResult GetHistory()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var histories = _historyService.GetHistoryForUser(userId)
                .Select(h => new HistoryDto
                {
                    Date = h.Date,
                    Workout = h.Workout,
                    Recommendation = h.Recommendation,
                    FileAnalyzed = h.FileAnalyzed
                }).ToList();
            return Ok(histories);
        }
        [HttpPost]
        public IActionResult AddHistory(HistoryDto request)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var history = _historyService.AddHistoryForUser(userId, request.Date, request.Workout, request.Recommendation, request.FileAnalyzed);
            return Ok(new HistoryDto
            {
                Date = history.Date,
                Workout = history.Workout,
                Recommendation = history.Recommendation,
                FileAnalyzed = history.FileAnalyzed
            });
        }
    }
}