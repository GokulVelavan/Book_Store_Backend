using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model.BookModel;

namespace RepositaryLayer.Interfaces
{
    public interface IBookRL
    {
        BookResponseModel CreateBookDetails(CreateBookModel model, long jwtUserId);
        public bool DeletetBookByBookId(long bookId, long jwtUserId);
       BookResponseModel UpdateBookDetails(long bookId, UpdateBookModel model, long jwtUserId);

        BookResponseModel GetBookById(long bookId, long jwtUserId);

    }
}
