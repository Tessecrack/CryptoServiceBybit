using CryptoServiceBybit.ServiceBybit;
using Microsoft.AspNetCore.Mvc;

namespace CryptoServiceBybit.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        protected readonly BaseClient _client;

        public HomeController(BaseClient client)
        {
            _client = client;
        }

        [HttpGet("tickers/spot")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTickersSpot()
        {
            return Ok(await _client.GetTickersSpot());
        }

        [HttpGet("tickers/inverse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTickersInverse()
        {
            return Ok(await _client.GetTickersInverse());
        }

        [HttpGet("tickers/linear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTickersLinear()
        {
            return Ok(await _client.GetTickersLinear());
        }

        [HttpGet("tickers/option")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTickersOption()
        {
            return Ok(await _client.GetTickersOption());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
