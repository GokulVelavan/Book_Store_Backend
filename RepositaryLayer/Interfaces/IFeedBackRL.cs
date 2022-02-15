using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model.FeedBackModel;

namespace RepositaryLayer.Interfaces
{
    public interface IFeedBackRL
    {
        public FeedBackResponseModel AddFeedBack(long bookId, AddFeedBackModel model, long jwtUserId);

    }
}
