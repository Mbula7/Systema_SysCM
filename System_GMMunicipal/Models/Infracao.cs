using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace System_GMMunicipal.Models
{
    public class Infracao
    {
        public int Id { get; set; }
        [ForeignKey("Condutor")]
        public int CondutorId { get; set; }
        public Condutor Condutor { get; set; }
        [ForeignKey("Motorizada")]
        public int MotorizadaId { get; set; }
        public Motorizada Motorizada { get; set; }
        [ForeignKey("FiscalUtilizador")]
        public int FiscalId { get; set; }
        public FiscalUtilizador FiscalUtilizador { get; set; }
        [ForeignKey("TiposInfracoe")]
        public int TipoInfracaoId { get; set; }
        public TiposInfracoe TiposInfracoe { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string  Descricao { get; set; }
        public Decimal ValorMulta { get; set; }
        public string Estado {  get; set; }
        public DateTime DataPagamento { get; set; }
        public string Observacoes { get; set; }
    }
}
