using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ConversionsController : ControllerBase
    {
        [HttpGet("convert")]
        public IActionResult Convert([FromQuery] int number, [FromQuery] int toBase)
        {
            if (toBase < 2 || toBase > 36)
            {
                return BadRequest("Invalid base. Please specify a value between 2 and 36.");
            }

            string result = ConvertNumberToBase(number, toBase);
            return Ok(result);
        }

        private static string ConvertNumberToBase(int number, int toBase)
        {
            if (number == 0)
            {
                return "0";
            }

            string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            bool isNegative = number < 0;

            number = Math.Abs(number);

            while (number > 0)
            {
                int remainder = number % toBase;
                result = digits[remainder] + result;
                number /= toBase;
            }

            return (isNegative ? "-" : "") + result;
        }
    }

}
