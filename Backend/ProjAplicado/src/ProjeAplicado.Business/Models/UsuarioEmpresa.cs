using ProjAplicado.Business.Models.Enums;

namespace ProjAplicado.Business.Models
{
    public class UsuarioEmpresa : Entity
    {
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
    }
}
