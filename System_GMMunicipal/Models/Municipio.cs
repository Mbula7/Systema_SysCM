using System.ComponentModel.DataAnnotations.Schema;

namespace System_GMMunicipal.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        public string NameMunicipio { get; set; }
        public string? Codigo { get; set; }
        [ForeignKey("Provincia")]
        public int ProvinciaId { get; set; }
        public Provicia Provincia { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; } = default(DateTime?);
        public ICollection<Condutor> Condutors { get; set; } 
        public ICollection<FiscalUtilizador> FiscalUtilizadors { get; set; }
        public ICollection<Licenca> Licencas { get; set; }
        public ICollection<EscolasCoducao> EscolasCoducaos { get; set; }
        public ICollection<Receita> Receitas { get; set; }
    }
}
