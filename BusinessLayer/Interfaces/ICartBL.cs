using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model.CartModel;

namespace BusinessLayer.Interfaces
{
   public  interface ICartBL
    {
       public CartResponseModel CreateCartDetails(AddCartModel model, long BookId, long jwtUserId);
        bool DeletetCArtById(long CartId, long jwtUserId);
    }
}
