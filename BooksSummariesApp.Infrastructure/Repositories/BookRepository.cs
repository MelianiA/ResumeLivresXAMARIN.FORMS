using BooksSummariesApp.Models;
using Couchbase.Lite;
using Couchbase.Lite.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSummariesApp.Infrastructure.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        IEnumerable<Book> GetBooks();

    }
    public class BookRepository : IBookRepository
    {
        private readonly Database _database;
        public DataBaseManager DataBaseManager { get; set; } = new DataBaseManager();

        public BookRepository()
        {
            _database = DataBaseManager.GetDatabase();
        }
        public void Add(Book book)
        {
            try
            {
                if (book != null)
                {
                    var database = DataBaseManager.GetDatabase();
                    string bookId = Guid.NewGuid().ToString();
                    book.CreateAt = DateTime.Now;

                    MutableDocument mutableDocument = new MutableDocument(bookId);

                    mutableDocument.SetString("Id", book.Id);
                    mutableDocument.SetString("Title", book.Title);
                    mutableDocument.SetString("ShortDescription", book.ShortDescription);
                    mutableDocument.SetString("LongDescription", book.LongDescription);
                    mutableDocument.SetString("CreateAt", book.CreateAt.ToString("g"));
                    mutableDocument.SetString("Type", "book");

                    database.Save(mutableDocument);


                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception : {ex.Message}");
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            using (var query = QueryBuilder.Select(
                SelectResult.Expression(Expression.Property("Id")),
                SelectResult.Expression(Expression.Property("Title")),
                SelectResult.Expression(Expression.Property("ShortDescription")),
                SelectResult.Expression(Expression.Property("LongDescription")),
                SelectResult.Expression(Expression.Property("CreateAt"))).From(DataSource.Database(_database)).
               Where(Expression.Property("type").EqualTo(Expression.Value("book"))))
            {
                IResultSet result = query.Execute();
                string json = JsonConvert.SerializeObject(result);

                return JsonConvert.DeserializeObject<IEnumerable<Book>>(json);

            }
        }
    }
}
