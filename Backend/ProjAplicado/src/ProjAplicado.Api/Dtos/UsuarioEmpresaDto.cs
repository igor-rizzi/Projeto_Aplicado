using System.ComponentModel.DataAnnotations;

namespace ProjAplicado.Api.Dtos
{
    public class UsuarioEmpresaDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo de Usuário é obrigatório!")]
        [StringLength(30, MinimumLength = 4)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo de Email é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de Senha é obrigatório!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        [Required(ErrorMessage = "O campo de {0} é obrigatório!")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo Tipo Usuário é obrigatório!")]
        public int TipoUsuario { get; set; }
    }
}
