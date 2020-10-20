using File.Import.Interfaces;
using File.Import.Util.Attributes;

namespace Apontamento.App.Application.Models
{
    public class ApontamentoModel : IImportModel
    {
        [TextImport(0)]
        public string IdApontamento { get; set; }

        [TextImport(1)]
        public string DataInicio { get; set; }

        [TextImport(2)]
        public string DataFim { get; set; }

        [TextImport(3)]
        public string NumeroLote { get; set; }

        [TextImport(4)]
        public string IdEvento { get; set; }

        [TextImport(5)]
        public string Quantidade { get; set; }
    }
}
