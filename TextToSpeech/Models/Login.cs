using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TextToSpeech.Models
{
    public class Login
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [RegularExpression("^[A-Z]+[A-z]{1,30}$")]
        public string FirstName { set; get; }
        [Required]
        [RegularExpression("^[a-zA-Z]{2,}$")]
        public string LastName { set; get; }
        [Required]
        [RegularExpression(@"^([A-z0-9\.]{5,30})@([A-z]{5,10})\.([a-z]{2,3})$")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[A-z0-9]{8,30}$")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[A-z0-9]{8,30}$")]
        public string ConfirmPassword { get; set; }

        public Login()
        {
            FirstName = "";
            LastName = "";
        }
        public Login(int id, string firstname, string lastname, string email, string password, string confirmpassword)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            ConfirmPassword = confirmpassword;
        }
    }

    //public class TextToSpeech : DbContext
    //{
    //    public DbSet<Login> Logins { get; set; }
    //}
}