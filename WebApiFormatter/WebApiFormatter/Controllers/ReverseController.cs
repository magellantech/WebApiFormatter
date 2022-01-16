using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebApiFormatter.Models;
using WebApiFormatter.Services.Interfaces;

namespace WebApiFormatter.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class ReverseController : ControllerBase
    {
        private readonly ILogger<ReverseController> _logger;
        private readonly IFormatterService _Formatter;

        public ReverseController(ILogger<ReverseController> logger, IFormatterService Formatter)
        {
            _logger = logger;
            _Formatter = Formatter;
        }

        [HttpGet]
        public async Task<ResultData> Get()
        {
            return  await _Formatter.FormatAsync(Request.Query,_logger);
        }
    }
}
