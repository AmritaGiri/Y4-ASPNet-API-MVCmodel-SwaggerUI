using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Soa.Data;

namespace Soa.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly SoaContext context;
        private readonly IMapper mapper;

        public BookRepository(SoaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> AddBookAsync(Book book)
        {
            ///____________________________________________________
            // here you are adding the book information  and it will return the book by its id
            // once the book has been saved to the database
            var Book = new Book()
            {
                Name = book.Name,
                Description = book.Description
            };

            context.Book!.Add(book);
            await context.SaveChangesAsync();

            return Book.Id;
        }
        ///____________________________________________________
        // here you are telling the database to delete a book by its id and to make changes 
        //to the database
        public async Task DeleteBookAsync(int id)
        {
            var book = new Book() { Id = id };

            context.Book!.Remove(book);
            await context.SaveChangesAsync();
        }
        ///____________________________________________________
       // here you are getting all the books asynchronously from the database
       // and returning them in a list format
        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = await context.Book!.ToListAsync();
            return mapper.Map<List<Book>>(books);
        }
        ///____________________________________________________
        // here you are getting a particular book by its id 
        public async Task<Book?> GetBookByIdAsync(int id)
        {
            var book = await context.Book!.FindAsync(id);
            return mapper.Map<Book>(book); 
        }
        ///____________________________________________________
        // here you are changing the book title and the description and it will be updated to the 
        //the database, the id will remain the same
        public async Task UpdateBookAsync(int id, Book book)
        {
            var Book = new Book()
            {
                Id = id,
                Name = book.Name,
                Description = book.Description
            };

            context.Book!.Update(book);
            await context.SaveChangesAsync();
        }

        ///____________________________________________________
        
        // here you are displaying the changes made to the book information and it will be 
        // return in json
        public async Task UpdateBookByPatchAsync(int id, JsonPatchDocument jsonObject)
        {
            var book = await context.Book!.FindAsync(id);

            if (book != null)
            {
                jsonObject.ApplyTo(book);
                await context.SaveChangesAsync();
            }
        }
        ///____________________________________________________
    }
}
