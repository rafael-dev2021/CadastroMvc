using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace CadastroMvc.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é requirido")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required(ErrorMessage ="Senha é requirida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
