using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.NVC.Models
{
    public class UsarioRegistro()
    {
        [Required(ErrorMessage ="O campo{0} é obrigatório")]
        [EmailAddress(ErrorMessage ="O Campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength =2)]
        public string Senha{ get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [DisplayName("Confirma a sua senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }

    }
    public class UsuarioLogin
    {
        [Required(ErrorMessage = "O campo{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O Campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Senha { get; set; }
    }
}
