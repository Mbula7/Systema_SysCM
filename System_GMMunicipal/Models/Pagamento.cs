using System.ComponentModel.DataAnnotations.Schema;

namespace System_GMMunicipal.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        [ForeignKey("Receita")]
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }
        public string Referencia { get; set; }
        public Decimal Valor {  get; set; }
        public DateTime DataPagamento { get; set; }
        public string MetodoPagamento { get; set; }
        public string NumeroTransacao { get; set; }
        public string Estado {  get; set; }
    }
}
