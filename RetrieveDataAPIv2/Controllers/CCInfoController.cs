using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetrieveDataAPIv2.Models;
using System.Data.SqlClient;

namespace RetrieveDataAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCInfoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CCInfoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllSitrnTable")]

        public Response GetAllSitrnTable()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DataBaseConnection").ToString());
            Response response = new Response();
            DataAccessLink dataAccess = new DataAccessLink();
            response = dataAccess.GetAllSitrnTable(connection);

            return response;
        }
    }
}
