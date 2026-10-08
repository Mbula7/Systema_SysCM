using System.ComponentModel.DataAnnotations.Schema;

namespace System_GMMunicipal.Models
{
    public class Receita
    {
        public int Id { get; set; }
        [ForeignKey("Condutor")]
        public int CondutorId { get; set; }
        public Condutor Condutor { get; set; }
        [ForeignKey("Municipio")]
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public string TipoReceita { get; set; }
        public string Referencia { get; set; }
        public Decimal ValorTotal { get; set; }
        public Decimal ValorMunicipio { get; set; }
        public Decimal ValorEscola {  get; set; }
        public DateTime DataPagamento { get; set; }
        public string MetodoPagamento { get; set; }
        public string Estado {  get; set; }
    }
}
