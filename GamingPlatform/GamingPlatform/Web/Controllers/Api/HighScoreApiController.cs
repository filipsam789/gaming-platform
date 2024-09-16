using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service.Interface;

namespace IntegratedSystems.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighScoreApiController : ControllerBase
    {
        private readonly IHighScoreService _highScoreService;

        public HighScoreApiController(IHighScoreService highScoreService)
        {
            _highScoreService = highScoreService;
        }

        // GET: HighScores
        [HttpGet]
        public IActionResult Index()
        {
            var highScores = _highScoreService.GetHighScores()
                .OrderByDescending(h => h.Score)
                .Take(10)
                .ToList();
            return Ok(highScores);
        }
    }
}
