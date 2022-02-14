using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model.BookModel
{
   public class BookResponseModel
    {
        public long BookId { get; set; }

      
        public string BookName { get; set; }

        
        public string BookAuthor { get; set; }

       
        public long TotalRating { get; set; }

        public long NoOfPeopleRated { get; set; }

        
        public long OriginalPrice { get; set; }

      
        public long DiscountPrice { get; set; }

        
        public string BookImage { get; set; }

       
        public long BookQuantity { get; set; }

        
        public string BookDetails { get; set; }

      
        public long UserId { get; set; }
    }
}
