using System.Collections.Generic;
using PIOL.Business.Notificacoes;

namespace PIOL.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}