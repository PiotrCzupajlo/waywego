using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace waywego.Model
{
    public class Databasehandler
    {
        public string cs { get; set; }
        public Databasehandler() {
            cs = "Data Source=DESKTOP-GN12VV1\\SQLEXPRESS01;Initial Catalog=waywego;Integrated Security=True";
        }
        public async Task<DataTable> loguser(string username, string password)
        { 
            DataTable dt = new DataTable();
            string base64username = Convert.ToBase64String(Encoding.UTF8.GetBytes(username));
            string base64password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            string sql = "select * from Users where username = \'" + base64username + "\' and password = \'" + base64password+"\'";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                await conn.OpenAsync();
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(dt);
            }
            return dt;
        
        }
        public async Task<User> reguser(string username,string password) {
            string base64username = Convert.ToBase64String(Encoding.UTF8.GetBytes(username));
            string base64password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

            string sql = "insert into Users values ('" + base64username + "','" + base64password +"')";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            
            }
            User user = new User();
            user.Username = base64password;
            user.Password = base64username;
            return user;
        
        }


    }
}
