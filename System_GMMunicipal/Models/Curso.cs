using System.ComponentModel.DataAnnotations.Schema;

namespace System_GMMunicipal.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [ForeignKey("EscolasCoducao")]
        public int? EscolaId { get; set; }
        public EscolasCoducao EscolasCoducao { get; set; }
        public string? NomeCurso { get; set; }
        public string? Descricao { get; set; }
        public string? CargaHoraria { get; set; }
        public Decimal? Valor {  get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim {  get; set; }
        public string Estado { get; set; }
        public ICollection<FormacaoReciclagem> FormacaoReciclagems { get; set; }
    }
}
