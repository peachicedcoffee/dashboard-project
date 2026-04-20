using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DashboardApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        [HttpGet("summary")]
        public IActionResult GetSummary() 
        {
            return Ok(new
            {
                totalUsers = 1240,
                totalSales =85400,
                activeSession =73,
                errorRate =2.4
            });
        }

        [HttpGet("monthly")]
        public IActionResult GetMonthly()
        {
            var data = new[]
            {
                new { month = "1월", sales = 4200, visits = 3100 },
                new { month = "2월", sales = 5800, visits = 4200 },
                new { month = "3월", sales = 4900, visits = 3800 },
                new { month = "4월", sales = 7200, visits = 5500 },
                new { month = "5월", sales = 6100, visits = 4700 },
                new { month = "6월", sales = 8500, visits = 6200 },
            };
            return Ok(data);
        }


    }
}
