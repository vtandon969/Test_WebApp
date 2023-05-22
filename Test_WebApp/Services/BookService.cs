using Microsoft.Data.SqlClient;
using Test_WebApp.Model;
using Microsoft.Extensions.Configuration;

namespace Test_WebApp.Services
{
    public class BookService : IBookService 
    {
        
        public List<Book> GetBooks()
        {
            SqlConnection sqlConnection = GetConnection();

            List<Book> _books = new List<Book>();
            
            string stmt = "SELECT Book_Id,Book_Name,Price,Qty FROM Book";
            sqlConnection.Open();
            
            SqlCommand mySqlCommand = new SqlCommand(stmt, sqlConnection);
            using (SqlDataReader reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        Book_Id = reader.GetInt32(0),
                        Book_Name = reader.GetString(1),
                        Price = reader.GetInt32(2),
                        Qty = reader.GetInt32(2)
                    };
                    _books.Add(book);

                }
                sqlConnection.Close();
              sqlConnection.Dispose();
                return _books;
            }
        }


        private static SqlConnection GetConnection()
        {
            //string connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_SqlConnectionString");
            string connectionstring2 = "Data Source=DESKTOP-7GG6AMC\\SQLEXPRESS,1433;Initial Catalog=BookList;Integrated Security=True;Persist Security Info=False;";
            string connectionString = "Server=DESKTOP-7GG6AMC\\SQLEXPRESS;Database=BookList;Trusted_Connection=True;MultipleActiveResultSets=True";
            string connectionstring3 = "Server=tcp:vt-azure-sql.database.windows.net,1433;Initial Catalog=BookList;Persist Security Info=False;User ID=admin123;Password=Db@123456789;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return new SqlConnection(connectionstring3);
        }
    }
}


