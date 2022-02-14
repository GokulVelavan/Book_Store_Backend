using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model.CartModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL cartBL;

        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        [HttpPost("{bookId}")]
        public IActionResult AddCart(long bookId, AddCartModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                CartResponseModel cart = cartBL.CreateCartDetails(model,bookId,jwtUserId);
                if (cart == null)
                {
                    return NotFound(new { Success = false, message ="Cant add to cart" });
                }
                return Ok(new { Success = true, message = "Book added to cart", cart });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpDelete("{cartId}")]
        public IActionResult DeleteCartByCartId(long cartId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                bool deleteBook = cartBL.DeletetCArtById(cartId, jwtUserId);
                if (deleteBook)
                {
                    return Ok(new { Success = true, message = "Cart Deleted " });
                }
                return NotFound(new { Success = false, message = "Invalid CartId" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
