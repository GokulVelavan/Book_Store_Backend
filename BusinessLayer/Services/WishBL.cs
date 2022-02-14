using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
   public class WishBL:IWishBL
    {
        private IWishRL wishRL;

        public WishBL(IWishRL wishRL)
        {
            this.wishRL = wishRL;
        }
        public bool AddWishList(long bookId, long jwtUserId)
        {
            try
            {
                return this.wishRL.AddWishList(bookId, jwtUserId);
            }catch(Exception ex)
            {
                throw;
            }
        }
        public bool RemoveWishList(long WishlistId, long jwtUserId)
        {
            try
            {
                return this.wishRL.RemoveWishList(WishlistId, jwtUserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
