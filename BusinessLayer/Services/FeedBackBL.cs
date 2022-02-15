using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model.FeedBackModel;
using RepositaryLayer.Interfaces;
using RepositaryLayer.Services;

namespace BusinessLayer.Services
{
    public class FeedBackBL: IFeedBackBL
    {
        private IFeedBackRL feedBackRL;

        public FeedBackBL(IFeedBackRL feedBackRL)
        {
            this.feedBackRL = feedBackRL;
        }
        public FeedBackResponseModel AddFeedBack(long bookId, AddFeedBackModel model, long jwtUserId)
        {
            try
            {
                return this.feedBackRL.AddFeedBack(bookId,model,jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
