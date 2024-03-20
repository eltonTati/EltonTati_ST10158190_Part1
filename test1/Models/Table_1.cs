using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Session;
namespace test1.Models
{
    public class Table_1 
    {

        public static  string con_string = "Server=tcp:cdlv-sql-server.database.windows.net,1433;Initial Catalog=cldv-sql-DB;Persist Security Info=False;User ID=eltonTati;Password=Heltontatysam123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);
        public HttpContext HttpContext { get; set; }

        public Table_1()
        {
            // Set HttpContext to a non-null value if required
            HttpContext = new DefaultHttpContext();
        }
        public string Name { get; set; }
        //
        public string Surname {  get; set; }

        public string Email {  get; set; }

        public int insert_User(Table_1 m)

        {

            string sql = "INSERT INTO Table_1 (UserName, userSurname, userEmail) VALUES(@Name, @Surname, @Email)";

           
                 SqlCommand cmd = new SqlCommand(sql, con);  
                cmd.Parameters.AddWithValue("@Name", m.Name);
                cmd.Parameters.AddWithValue("@Surname", m.Surname);
                cmd.Parameters.AddWithValue("@Email", m.Email);
                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowAffected;
            
        }
       
    }
}
