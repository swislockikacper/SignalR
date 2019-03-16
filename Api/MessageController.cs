using Dapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.NetCore.Models;
using System.Data.SqlClient;

namespace SignalR.NetCore.Api
{
    public class MessageController : Controller
    {
        private const string connectionString = "PLACEHOLDER";

        [HttpPost]
        [Route("api/Message/Post")]
        public void Post([FromForm]Message message)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var insert = $"INSERT INTO [dbo].[Message] " +
                       $"([UserName], [Content]) " +
                       $"VALUES (@UserName, @Content)";

                var Content = message.Content;
                var UserName = message.UserName;

                connection.Execute(insert, new
                {
                    UserName,
                    Content
                });
            }
        }
    }
}
