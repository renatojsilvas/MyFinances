using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace RJSilvas.MyFinances.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet(Name = "GetUser")]
        public string Get()
        {
            string connectionString = "datasource=mysqldb;port=3306;username=renatojsilvas;password=admin";            
            string query = "select * from myfinances.user;";
            
            var connection = new MySqlConnection(connectionString);
            var command = new MySqlCommand(query, connection);           
            
            connection.Open();
            
            var reader = command.ExecuteReader();

            var id = 0;
            var email = "";
            var password = "";

            if (reader.Read())
            {
                id = reader.GetInt32(0);
                email = reader.GetString(1);
                password = reader.GetString(2);
            }

            reader.Close();

            return email;
        }
    }
}
