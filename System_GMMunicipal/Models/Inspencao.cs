using System.ComponentModel.DataAnnotations.Schema;

namespace System_GMMunicipal.Models
{
    public class Inspencao
    {
        public int Id { get; set; }
        [ForeignKey("Motorizada")]
        public int MotorizadaId { get; set; }
        public Motorizada Motorizada { get; set; }
        [ForeignKey("FiscalUtilizador")]
        public int FiscalId { get; set; }
        public FiscalUtilizador FiscalUtilizador { get; set; }

        public DateTime DataInspeccao { get; set; }
        public string EstadoMotorizada { get; set; }
        public string Travões { get; set; }
        public string Pneus { get; set; }
        public string Luzes { get; set; }
        public string Espelhos { get; set; }
        public string Documentacao { get; set; }
        public string Resultado { get; set; }
        public string Observacoes { get; set; }
    }
}
