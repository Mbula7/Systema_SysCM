using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace System_GMMunicipal.Models
{
    public class Licenca
    {
        public int Id { get; set; }

        public string NumeroLicenca { get; set; }
        public string TipoLicenca { get; set; }
        public Decimal Valor { get; set; }
        public string Estado { get; set; }
        public string MotivoCancelamento { get; set; }
        public DateTime DataEmissao { get; set; } = DateTime.UtcNow;
        public DateTime DataInicio { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataCancelamento { get; set; }
        [ForeignKey("Municipio")]
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        [ForeignKey("Condutor")]
        public int CondutorId { get; set; }
        public Condutor Condutor { get; set; }
        [ForeignKey("Motorizada")]
        public int MotorizadaId { get; set; }
        public Motorizada Motorizada { get; set; }
    }
}
