using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace curdoperation.Models
{

    public partial class Curd
    {
        public int Newid { get; set; }

        [RegularExpression(@"^[a-zA-Z]{3,30}$", ErrorMessage = "Please enter velid First Name")]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string Firstname { get; set; }

        [RegularExpression(@"^[a-zA-Z]{3,30}$", ErrorMessage = "Please enter velid  Last Name")]
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string Lastname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Zodiac { get; set; }

        [Required(ErrorMessage = "Please Phone No")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please Enter Valid Phone Number")]
        [StringLength(10, ErrorMessage = "Please Enter Valid Phone Number")]
        public string Mobileno { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Please enter velid email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        internal void Add(Curd curd)
        {
            throw new NotImplementedException();
        }
    }
}
