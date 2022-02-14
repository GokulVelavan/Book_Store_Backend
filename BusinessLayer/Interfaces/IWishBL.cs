using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
   public interface IWishBL
    {
        public bool AddWishList(long bookId, long jwtUserId);
        public bool RemoveWishList(long WishlistId, long jwtUserId);
    }
}
