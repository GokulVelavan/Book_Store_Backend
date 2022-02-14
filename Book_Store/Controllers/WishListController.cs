using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishBL wishBL;

        public WishListController(IWishBL wishBL)
        {
            this.wishBL = wishBL;
        }

        [HttpPost("{bookId}")]
        public IActionResult AddToWishList(long bookId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                bool wishList = this.wishBL.AddWishList(bookId, jwtUserId);
                if (wishList)
                {
                    return Ok(new { Success = true, message = "Book added to wish list" });
                }
                return NotFound(new { Success = false, message = "Cant add wish list!" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpDelete("{wishListId}")]
        public IActionResult DeleteWishById(long wishListId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                bool deleteWishList = this.wishBL.RemoveWishList(wishListId, jwtUserId);
                if (deleteWishList)
                {
                    return Ok(new { Success = true, message = "WishList Deleted " });
                }
                return NotFound(new { Success = false, message = "Invalid WishListId" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
