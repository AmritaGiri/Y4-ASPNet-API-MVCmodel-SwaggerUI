using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Soa.Data;
using Soa.Models;

namespace Soa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        //_______________________________________________________________
        // here we are getting all the books that are in the Database by its id
        // the async method runs synchronously until it gets all the books and then,
        // the method is suspended until the awaited task is complete
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookRepository.GetAllBooksAsync();
            return Ok(books);
        }
       // ________________________________________________________________
        [HttpGet("{id}")]
        // here you are getting a book by its id and if you enter an id with thats not in the database 
        // it will tell you that its not found
        // the async method runs synchronously until it gets the book by id and then,
        // the method will end once the  task is complete
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await bookRepository.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }
        //_______________________________________________________________

        [HttpPost]
        [Authorize]
        /// here you are entering the book details and adding it to the system 
        // the async method runs synchronously until it adds the book to the system and then,
        // the method will end once the  task is complete
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var id = await bookRepository.AddBookAsync(book);
            /// it returns the created book with its id 
            return CreatedAtAction(nameof(GetBookById), new { controller = "books", id }, id);
        }
        //_______________________________________________________________

        [HttpPut("{id}")]
        [Authorize]
        /// here you are allowing the user to change the book name and description but the id of the book stays the same
        /// // the async method runs synchronously until it updates the book information and then,
        // the method will end once the  task is complete
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] Book book)
        {
            await bookRepository.UpdateBookAsync(id, book);
            return Ok();
        }
        //_______________________________________________________________
        [HttpPatch("{id}")]
        [Authorize]
        // when the update has been done it then makes the changed information of the book in json so it is more readable for the
        
        public async Task<IActionResult> UpdateBookByPatch([FromRoute] int id, [FromBody] JsonPatchDocument jsonObject)
        {
            await bookRepository.UpdateBookByPatchAsync(id, jsonObject);
            return Ok();
        }
        //_______________________________________________________________

        [HttpDelete("{id}")]
        [Authorize]

        // here you are deleting the book by its id from the database
        // the async method runs synchronously until it deletes the book by its id and then,
        // the method will end once the  task is complete
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await bookRepository.DeleteBookAsync(id);
            return Ok();
        }

    }
}
