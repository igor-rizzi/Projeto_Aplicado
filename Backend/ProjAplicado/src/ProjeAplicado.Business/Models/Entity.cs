namespace ProjAplicado.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        { 
        }

        public int Id { get; set; }
    }
}