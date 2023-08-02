using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy.Identity.Models
{
    public class UserAdminCreateModel
    {
        [Required(ErrorMessage ="Kullanıcı adı gereklidir")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email adresi gerekliidir")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cinsiyet gereklidir")]
        public string Gender { get; set; }
    }
}
