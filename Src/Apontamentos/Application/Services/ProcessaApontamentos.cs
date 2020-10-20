using System;
using System.Linq;
using Apontamento.App.Application.Interfaces;
using Apontamento.App.Application.Models;
using Apontamento.App.Domain;
using File.Import.Interfaces;

namespace Apontamento.App.Application.Services
{
    public class ProcessaApontamentos : IProcessaApontamentos
    {
        private const char Separator = ';';

        private readonly IFileService _fileService;

        public ProcessaApontamentos(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Processar(string file)
        {
            var list = _fileService.Import<ApontamentoModel>(file, Separator);

            var apontamentoProducao = new ApontamentoProducao(list.Select(x => new ApontamentoAggregate(x.IdApontamento, x.DataInicio, x.DataFim, x.NumeroLote, x.IdEvento, x.Quantidade)).ToList());

            Console.WriteLine("** Gaps **");
            apontamentoProducao.GetGaps();

            Console.WriteLine("** Produção **");
            apontamentoProducao.CalcularProducao();

            Console.WriteLine("** Manutenções **");
            apontamentoProducao.GetManutencoes();
        }
    }
}