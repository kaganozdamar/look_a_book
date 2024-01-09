using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace consoleapp
{
    class Program
    {

        static void Main(string[] args)
        {
            var books = GetAllBooks();
            foreach (var b in books)
            {
                Console.WriteLine($"Id: {b.BookId} Name: {b.BookName} Writer_Id: {b.BookWriterId} ImageUrl: {b.BookImageUrl} Stock: {b.BookStock} OnSale: {b.BookOnSale} Price: {b.BookPrice} OldPrice: {b.BookOldPrice}");
            }
        }

        static List<Book> GetAllBooks()
        {
            List<Book> books = null;

            using(var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();
                    
                    string sql = "select * from book";

                    MySqlCommand command = new MySqlCommand(sql,connection);

                    MySqlDataReader reader = command.ExecuteReader();
                    books = new List<Book>();

                    while(reader.Read())
                    {
                        books.Add(
                            new Book
                            {
                                BookId=int.Parse(reader["Id"].ToString()),
                                BookName = reader["Name"].ToString(),
                                BookWriterId = int.Parse(reader["Writer_Id"]?.ToString()),
                                BookImageUrl=reader["ImageUrl"].ToString(),
                                BookStock = int.Parse(reader["Stock"].ToString()),
                                BookOnSale = int.Parse(reader["OnSale"].ToString()),
                                BookPrice = double.Parse(reader["Price"]?.ToString()),
                                BookOldPrice = double.Parse(reader["OldPrice"]?.ToString())
                            }
                        );
                    }
                    reader.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return books;     
        }

        static MySqlConnection GetMySqlConnection()
        {
            string connectionString = @"server=localhost;port=3306;database=internship-project;user=root;password=mysql1234;";
            return new MySqlConnection(connectionString);
        }


    }
}
