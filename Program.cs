// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using Dapper.Contrib.Extensions;
using DapperContrib.Models;
using Microsoft.Data.SqlClient;
namespace DapperContrib
{
    class Program
    {
        static string ConnectionString = @"Data Source=DESKTOP-95SGKO8;Initial Catalog=BookStoreContext;Integrated Security=True;Encrypt=False";

        static void Main(string[] args)
        {
            // Console.WriteLine("Get All Authors : ");
            GetAllAuthors();

            // Console.WriteLine("Get Certain Author By Id : ");
            // GetAuthor(1);

            // Console.WriteLine("Add New Author : ");
            // InsertSingleAuthor();

            // Console.WriteLine("Add Muliple Books : ");
            // InsertMultipleBooks();

            // Console.WriteLine("Update Single Book : ");
            // UpdateSingleBook();

            // Console.WriteLine("Update Muliple Books : ");
            // UpdateMultipleBooks();

            // Console.WriteLine("Delete Single Book : ");
            // DeleteSingleBook();

            // Console.WriteLine("Delete Muliple Books : ");
            // DeleteMultipleBooks();

            // Console.WriteLine("Delete All Books : ");
            // DeleteAllBooks();
        }

        //The following example retrieves all the authors from the database using the GetAll<T>() method.
        private static void GetAllAuthors()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                List<Author> authors = db.GetAll<Author>().ToList();

                foreach (var author in authors)
                {
                    Console.WriteLine(author.FirstName + " " + author.LastName);
                }
            }
        }

        //If you want to retrieve any specific record from the database, you can use the Get method and pass the id as an argument.
        private static void GetAuthor(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                Author author = db.Get<Author>(id);

                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }

        //The following example inserts a single new record.
        private static void InsertSingleAuthor()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                Author author = new Author()
                {
                    FirstName = "William",
                    LastName = "Shakespeare"
                };
                db.Insert<Author>(author);
                Console.WriteLine("Added Successfully..");
                Console.WriteLine("Get All Authors...");
                GetAllAuthors();
            }
        }

        //You can also use the Insert method to insert multiple records.
        private static void InsertMultipleBooks()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                List<Book> books = new List<Book>(){
                    new Book {Title = "Romeo and Juliet", Category = "Humor & Entertainment", AuthorId = 4},
                    new Book {Title = "The Tempest", Category = "Fiction", AuthorId = 4},
                    new Book {Title = "The Winter's Tale : Third Series", Category = "Fiction", AuthorId = 4}
                };
                db.Insert<List<Book>>(books);
                Console.WriteLine("Added Successfully..");
                Console.WriteLine("Get All Books...");
                GetAllBooks();
            }
        }

        //If you retrieve all the books from the database.
        private static void GetAllBooks()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                List<Book> books = db.GetAll<Book>().ToList();
                foreach (var book in books)
                {
                    Console.WriteLine("Title: {0} \t Category: {1}", book.Title, book.Category);
                }
            }
        }

        //The following example updates a single new record.
        private static void UpdateSingleBook()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                Book book = new Book { Id = 1, Title = "Introduction to AI", Category = "Software", AuthorId = 1 };
                db.Update<Book>(book);
                Console.WriteLine("Updated Successfully..");
                Console.WriteLine("Get All Books...");
                GetAllBooks();
            }
        }

        //You can also use the Update method to update multiple records by passing the list as an argument.
        private static void UpdateMultipleBooks()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                List<Book> books = new List<Book>()
                {
                    new Book { Id = 2, Title = "Introduction to Algorithm", Category = "Software", AuthorId = 1 },
                    new Book { Id = 3, Title = "Basics of Statistics", Category = "Education", AuthorId = 2 },
                };
                db.Update<List<Book>>(books);
                Console.WriteLine("Updated Successfully..");
                Console.WriteLine("Get All Books...");
                GetAllBooks();
            }
        }

        //The following example deletes a single record using the Delete method.
        private static void DeleteSingleBook()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Delete<Book>(new Book { Id = 7 });
                Console.WriteLine("Deleted Successfully..");
                Console.WriteLine("Get All Books...");
                GetAllBooks();
            }
        }

        //You can also use the Delete method to delete multiple records by passing the list as an argument to the Delete method.
        private static void DeleteMultipleBooks()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                List<Book> books = new List<Book>()
                {
                    new Book { Id = 8 },
                    new Book { Id = 9 }
                };
                db.Delete<List<Book>>(books);
                Console.WriteLine("Deleted Successfully..");
                Console.WriteLine("Get All Books...");
                GetAllBooks();
            }
        }

        //If you want to delete all the records from a particular table, you can use the DeleteAll method.
        private static void DeleteAllBooks()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.DeleteAll<Book>();
            }
        }
    }
}
