using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model.BookModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookBL bookBL;

        public BooksController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        [HttpPost]
        public IActionResult CreateBookDetails(CreateBookModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (model == null)
                {
                    return NotFound(new { Success = false, message = "Not able to create book" });
                }
                BookResponseModel book = bookBL.CreateBookDetails(model, jwtUserId);
                return Ok(new { Success = true, message = "Book Created Successfully ", book });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


        [HttpGet("{bookId}")]
        public IActionResult GetBookById(long bookId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                BookResponseModel allBooks = bookBL.GetBookById(bookId, jwtUserId);
                if (allBooks == null)
                {
                    return NotFound(new { Success = false, message = "Invalid BookId" });
                }

                return Ok(new { Success = true, message = "Retrived Book BookId ", allBooks });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpPut("{bookId}")]
        public IActionResult UpdateBookDetails(long bookId, UpdateBookModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                BookResponseModel book = bookBL.UpdateBookDetails(bookId, model, jwtUserId);
                if (book == null)
                {
                    return NotFound(new { Success = false, message = "Invalid BookId to update" });
                }

                return Ok(new { Success = true, message = "Book Updated Successfully ", book });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpDelete("{bookId}")]
        public IActionResult DeletetBookByBookId(long bookId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                bool deleteBook = bookBL.DeletetBookByBookId(bookId, jwtUserId);
                if (deleteBook)
                {
                    return Ok(new { Success = true, message = "Book with Book Id Deleted " });
                }
                return NotFound(new { Success = false, message = "Invalid BookId" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
