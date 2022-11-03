using System.ComponentModel.DataAnnotations;

namespace ProjAplicado.Api.Dtos
{
    public class VagaDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de {0} é obrigatório!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo de {0} é obrigatório!")]
        public string Salario { get; set; }
    }
}
