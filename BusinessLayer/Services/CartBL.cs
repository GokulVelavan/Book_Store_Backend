using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model.CartModel;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class CartBL:ICartBL
    {
        private ICartRL cartRL;

        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public CartResponseModel CreateCartDetails(AddCartModel model, long BookId, long jwtUserId)
        {
            try
            {
               return this.cartRL.CreateCartDetails(model,BookId,jwtUserId);
            }catch(Exception)
            {
                throw;
            }
        }

        public bool DeletetCArtById(long CartId, long jwtUserId)
        {
            try
            {
                return this.cartRL.DeletetCArtById(CartId,jwtUserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
