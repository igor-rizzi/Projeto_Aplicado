using System.ComponentModel.DataAnnotations;

namespace ProjAplicado.Api.Dtos
{
    public class EmpresaDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(30, MinimumLength = 4)]
        public string RazaoSocial { get; set; }

        [StringLength(150, MinimumLength = 4)]
        public string Visoes { get; set; }

        [StringLength(150, MinimumLength = 4)]
        public string Valores { get; set; }

        [StringLength(150, MinimumLength = 4)]
        public string Missoes { get; set; }

        [StringLength(300, MinimumLength = 4)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(18, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 18)]
        public string CNPJ { get; set; }

    }
}