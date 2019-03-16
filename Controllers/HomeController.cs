using Dapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.NetCore.Models;
using System.Data.SqlClient;
using System.Linq;

namespace SignalR.NetCore.Controllers
{
    public class HomeController : Controller
    {
        private const string connectionString = "PLACEHOLDER";

        public IActionResult Index()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = $"SELECT [UserName], [Content] " +
                       $"FROM [dbo].[Message]";

                return View(connection.Query<Message>(query).ToList());
            }
        }
    }
}
