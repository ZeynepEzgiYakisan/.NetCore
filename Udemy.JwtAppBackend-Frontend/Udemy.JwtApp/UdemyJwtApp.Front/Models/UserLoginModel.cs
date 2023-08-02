using System.ComponentModel.DataAnnotations;

namespace UdemyJwtApp.Front.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Gereklidir.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage ="Şifre Gereklidir.")]
        public string Password { get; set; } = null!;

    }
}
