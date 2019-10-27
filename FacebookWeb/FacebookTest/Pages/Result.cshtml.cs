using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FacebookTest.Pages
{
    public class ResultModel : PageModel
    {
        public SqlSettings Settings { get; set; }
        public ResultModel(SqlSettings mySettings)
        {
            Settings = mySettings;
        }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(Request.Query["email"]))
            {
                string queryString = "INSERT INTO Results Values (@email)";
                string connectionString = Settings.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@email", Request.Query["email"].ToString());
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            

        }
    }
}
