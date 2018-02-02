using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeVacationScheduler.Models
{
    public partial class User
    {
        [Required(ErrorMessage = "can't be empty", AllowEmptyStrings = false)]
        [System.Web.Mvc.Remote("IsUserNameAvailabler", "Manage",ErrorMessage ="Invalid Username")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "can't be empty", AllowEmptyStrings = false)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password Mismatch ")]
        [Required(ErrorMessage = "can't be empty", AllowEmptyStrings = false)]
        [Display(Name="Retype-Pasword")]
        public string Rpassword { get; set; }

    }
    [MetadataType(typeof(LoginMetaData))]
    public partial class Login
    {
        
        

    }
    public partial class LoginMetaData
    {

        public string Usename { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
    }
    