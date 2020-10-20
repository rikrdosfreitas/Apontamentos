using System;
using System.Collections.Generic;
using System.Linq;
using Apontamento.App.Domain;

namespace Apontamento.App.Application.Services
{
    public class ApontamentoProducao : Apontamento
    {
        public ApontamentoProducao(List<ApontamentoAggregate> apontamentos) : base(apontamentos)
        {
        }

        public void CalcularProducao()
        {
            var codigosProducao = new int[] { 1, 2 };

            var producao = GetPorEventos(codigosProducao);

            int totalProduzido = producao.Select(x => x.Quantidade).DefaultIfEmpty(0).Sum();

            var topProducao = GetLotesMaisProduzidos(producao, 3);

            Console.WriteLine($"Quantidade Total Produzida: {totalProduzido}");
            foreach (var top in topProducao.Select((value, i) => new { i, value }))
            {
                Console.WriteLine($"{top.i + 1}º Lote {top.value.Lote} produziu {top.value.Quantidade}");
            }
            Console.WriteLine("");
        }

        private LoteProducaoModel[] GetLotesMaisProduzidos(List<ApontamentoAggregate> producao, int top)
        {
            var topProducao = producao.GroupBy(x => x.NumeroLote)
                .Select(x => new LoteProducaoModel(x.Key, x.Select(x => x.Quantidade).DefaultIfEmpty(0).Sum()))
                .OrderByDescending(x => x.Quantidade)
                .Take(top)
                .ToArray();

            return topProducao;
        }

        private class LoteProducaoModel
        {
            public LoteProducaoModel(string lote, int quantidade)
            {
                Lote = lote;
                Quantidade = quantidade;
            }

            public string Lote { get; }

            public int Quantidade { get; }
        }
    }
}