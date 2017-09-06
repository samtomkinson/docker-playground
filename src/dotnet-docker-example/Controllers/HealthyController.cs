using System.Data.SqlClient;
using dotnet_docker_example.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace dotnet_docker_example.Controllers
{
    [Route("api/[controller]")]
    public class HealthyController : Controller
    {
        private readonly SqlSettings _sqlSettings;

        public HealthyController(IOptions<SqlSettings> options)
        {
            _sqlSettings = options.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using (var connection = new SqlConnection(_sqlSettings.ConnectionString))
            {
                connection.Open();

                return Ok(connection.State.ToString());
            }
        }
    }
}