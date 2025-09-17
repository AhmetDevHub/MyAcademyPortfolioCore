using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş Bırakılamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre  Boş Bırakılamaz")]
        public string Password { get; set; }
    }
}
