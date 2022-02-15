using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model.FeedBackModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedBackBL feedBackBL;

        public FeedbackController(IFeedBackBL feedBackBL)
        {
            this.feedBackBL = feedBackBL;
        }
        [HttpPost("{bookId}")]
        public IActionResult AddFeedBack(long bookId, AddFeedBackModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                FeedBackResponseModel feedBackList = feedBackBL.AddFeedBack(bookId, model, jwtUserId);
                if (feedBackList != null)
                {
                    return Ok(new { Success = true, message = "Feed Back Added", feedBackList });
                }
                return NotFound(new { Success = false, message = "Not able to Add Feed Back since bookId is wrong" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
