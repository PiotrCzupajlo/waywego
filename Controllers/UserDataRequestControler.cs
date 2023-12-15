using Microsoft.AspNetCore.Mvc;
using waywegoapi.Models;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Data.SqlTypes;
using Microsoft.Data.SqlTypes;

namespace waywegoapi.Controllers
{
    [Route("api/UserDataRequest")]
    [ApiController]
    public class UserDataRequestControler : ControllerBase
    {
        public string cs = "Data Source=DESKTOP-GN12VV1\\SQLEXPRESS01;Initial Catalog=waywego;Integrated Security=True;TrustServerCertificate=True";
        [HttpGet]
        public async Task<ActionResult<bool>> GetUsers(string username,string password) {
            DataTable dt = new DataTable();
            string base64username = Convert.ToBase64String(Encoding.UTF8.GetBytes(username));
            string base64password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

            string sql = "select count(id) as ids from Users where username=\'" + base64username + "\' and password =\'" + base64password + "\';";
            using (SqlConnection conn = new SqlConnection(cs))
            { 
                await conn.OpenAsync();
                SqlDataAdapter sda = new SqlDataAdapter(sql,conn);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    var val = dr["ids"];
                    if (Convert.ToInt32(val)>0)
                    {
                        return Ok(true);
                    }
                }
            
            }
            return NotFound();
        

        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser(string username, string password)
        {
            await Task.Delay(100);
            DataTable dataTable = new DataTable();
            string base64username = Convert.ToBase64String(Encoding.UTF8.GetBytes(username));
            string base64password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            string sql = "insert into Users values ('"+base64username+"','"+base64password+"')";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, conn);
                var result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    return Ok();
                }
                else
                    return BadRequest(result);
                    

            }
            

        }






    }
}
