using System;
using Apontamento.App.Util;

namespace Apontamento.App.Domain
{
    public class ApontamentoAggregate
    {
        public ApontamentoAggregate(string idApontamento, string dataInicio, string dataFim, string numeroLote, string idEvento, string quantidade)
        {
            IdApontamento = idApontamento;
            DataInicio = dataInicio.ToDatetime("dd/MM/yyyy HH:mm:ss");
            DataFim = dataFim.ToDatetime("dd/MM/yyyy HH:mm:ss");
            NumeroLote = numeroLote;
            IdEvento = idEvento.ToInt();
            Quantidade = quantidade.ToInt();
        }

        public string IdApontamento { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataFim { get; private set; }

        public string NumeroLote { get; private set; }

        public int IdEvento { get; private set; }

        public int Quantidade { get; private set; }
    }
}
