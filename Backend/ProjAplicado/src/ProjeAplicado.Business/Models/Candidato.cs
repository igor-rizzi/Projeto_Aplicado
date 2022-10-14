using ProjAplicado.Business.Models.Enums;

namespace ProjAplicado.Business.Models
{
    public class Candidato : Entity
    {

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public string Habilidades { get; set; }

        public string Objetivo { get; set; }

        public TipoFormacao TipoFormacao { get; set; }

        public string Idiomas { get; set; }

        public int AnosExperiencia { get; set; }


    }
}
