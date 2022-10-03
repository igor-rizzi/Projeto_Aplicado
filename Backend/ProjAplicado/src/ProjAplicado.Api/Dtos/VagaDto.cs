using System.ComponentModel.DataAnnotations;

namespace ProjAplicado.Api.Dtos
{
    public class VagaDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo de {0} é obrigatório!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo de {0} é obrigatório!")]
        public string Requisitos { get; set; }

        [Required(ErrorMessage = "O campo de {0} é obrigatório!")]
        public string Salario { get; set; }

        [Required(ErrorMessage = "O campo de {0} é obrigatório!")]
        public string Habilidades { get; set; }
    }
}
