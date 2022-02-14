using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model.UserModels
{
    public class SignUpModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Password Is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

       
        [Required(ErrorMessage = "Mobile Number Is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
    }
}
