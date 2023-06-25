using Microsoft.AspNetCore.JsonPatch;

namespace Soa.Models
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllBooksAsync();
        public Task<Book?> GetBookByIdAsync(int id);
        public Task<int> AddBookAsync(Book book);
        public Task UpdateBookAsync(int id, Book book);
        public Task UpdateBookByPatchAsync(int id, JsonPatchDocument jsonObject);
        public Task DeleteBookAsync(int id);

        /// the task method is used so it will let you create a task and run it asynchronously
    }
}
