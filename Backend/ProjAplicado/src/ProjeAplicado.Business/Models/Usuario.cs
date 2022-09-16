namespace ProjAplicado.Business.Models
{
    public class Usuario : Entity
    {
        public Guid UsuarioId { get; set; }

        public string User { get; set; }

        public string UserEmail { get; set; }

        public string Password { get; set; }
    }
}
