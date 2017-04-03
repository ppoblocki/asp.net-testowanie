using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        [DisplayName("First name")]
        [Required(ErrorMessage = "You have to enter first name.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "First name must have between 2-25 characters.")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "You have to enter last name.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Last name must have between 2-25 characters.")]
        public string LastName { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "You have to enter username.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Username must have between 2-25 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9_-]*$", ErrorMessage = "Username can contain only characters, numbers, dashes and underscores.")]
        public string Login { get; set; }

        public int CarID { get; set; }

        public virtual Car Car { get; set; }
    }
}