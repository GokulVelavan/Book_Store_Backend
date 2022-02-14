using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model.BookModel;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class BookBL:IBookBL
    {
        private IBookRL bookRL;

        public BookBL(IBookRL userRL)
        {
            this.bookRL = userRL;
        }
        public BookResponseModel CreateBookDetails(CreateBookModel model, long jwtUserId)
        {
            try
            {
                return this.bookRL.CreateBookDetails(model, jwtUserId);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public BookResponseModel UpdateBookDetails(long bookId, UpdateBookModel model, long jwtUserId)
        {
            try
            {
                return this.bookRL.UpdateBookDetails(bookId,  model, jwtUserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
       public BookResponseModel GetBookById(long bookId, long jwtUserId)
        {
            try
            {
                return this.bookRL.GetBookById(bookId,jwtUserId);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool DeletetBookByBookId(long bookId, long jwtUserId)
        {
            try
            {
                return this.bookRL.DeletetBookByBookId(bookId,jwtUserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
