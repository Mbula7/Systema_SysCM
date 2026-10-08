using System.ComponentModel.DataAnnotations.Schema;

namespace System_GMMunicipal.Models
{
    public class EscolasCoducao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NUIT { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        [ForeignKey("Municipio")]
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public string Licencas { get; set; }
        public DateTime DataLicenciamento { get; set; }
        public string Estado { get; set; }
        public DateTime CreateDate { get; set; }

        public ICollection<Curso> Cursos { get; set; }
    }
}
