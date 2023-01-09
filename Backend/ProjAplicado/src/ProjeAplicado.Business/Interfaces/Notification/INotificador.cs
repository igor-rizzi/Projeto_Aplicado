using ProjAplicado.Business.Notificacoes;

namespace ProjAplicado.Business.Intefaces.Notification
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}