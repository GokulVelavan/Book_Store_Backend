using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model.BookModel
{
    public class CreateBookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BookId { get; set; }

        [Display(Name = "BookName")]
        [DataType(DataType.Text)]
        public string BookName { get; set; }

        
        [Display(Name = "BookAuthor")]
        [DataType(DataType.Text)]
        public string BookAuthor { get; set; }


        [Display(Name = "OriginalPrice")]
        public long OriginalPrice { get; set; }

        [Display(Name = "DiscountPrice")]
        public long DiscountPrice { get; set; }

        
        [Display(Name = "BookQuantity")]
        public long BookQuantity { get; set; }

       
        [Display(Name = "BookDetails")]
        [DataType(DataType.Text)]
        public string BookDetails { get; set; }



    }
}
