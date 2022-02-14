using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Interfaces
{
    public interface IWishRL
    {
        public bool AddWishList(long bookId, long jwtUserId);
        bool RemoveWishList(long WishlistId, long jwtUserId);
    }
}
