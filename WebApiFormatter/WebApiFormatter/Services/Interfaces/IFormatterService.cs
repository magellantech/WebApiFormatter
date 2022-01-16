using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebApiFormatter.Models;

namespace WebApiFormatter.Services.Interfaces
{
    public interface IFormatterService
    {
        Task<ResultData> FormatAsync(IQueryCollection query, ILogger logger);
    }
}
