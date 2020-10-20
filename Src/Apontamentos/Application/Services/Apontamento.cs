using System;
using System.Collections.Generic;
using System.Linq;
using Apontamento.App.Domain;
using Apontamento.App.Util;

namespace Apontamento.App.Application.Services
{
    public abstract class Apontamento
    {
        private readonly List<ApontamentoAggregate> _apontamentos = new List<ApontamentoAggregate>();

        protected Apontamento(List<ApontamentoAggregate> apontamentos)
        {
            _apontamentos.AddRange(apontamentos);
        }

        protected List<ApontamentoAggregate> GetPorEventos(int[] eventos)
        {
            return Apontamentos.Where(x => eventos.Contains(x.IdEvento)).ToList();
        }

        public IReadOnlyCollection<ApontamentoAggregate> Apontamentos => _apontamentos.AsReadOnly();

        public void GetGaps()
        {
            var list = new List<TimeSpan>();
            DateTime last = default;
            foreach (var apontamento in Apontamentos)
            {
                var start = apontamento.DataInicio;
                var diff = last == default ? default : start.Subtract(last);
                if (diff.Ticks != default)
                {
                    list.Add(diff);
                }

                last = apontamento.DataFim;
            }

            var quantidade = list.Count;
            var total = list.Sum(s => s.Duration());

            Console.WriteLine($"Quantidade de GAPs: {quantidade}");
            Console.WriteLine($"Período Total: {total.Format()}");
            Console.WriteLine("");

        }

        public void GetManutencoes()
        {
            var codigosManutencao = new int[] { 19 };

            var manutencoes = GetPorEventos(codigosManutencao);

            var duracao = manutencoes.Sum(x => x.DataFim.Subtract(x.DataInicio).Duration());

            Console.WriteLine($"Período Total De Manutenção: {duracao.Format()}");
        }
    }
}