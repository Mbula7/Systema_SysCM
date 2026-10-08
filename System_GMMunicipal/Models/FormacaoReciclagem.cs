using System.ComponentModel.DataAnnotations.Schema;

namespace System_GMMunicipal.Models
{
    public class FormacaoReciclagem
    {
        public int Id { get; set; }
        [ForeignKey("Condutor")]
        public int CondutorId { get; set; }
        public Condutor Condutor { get; set; }
        [ForeignKey("Curso")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; } //Categoria carta ou Licenca
        public DateTime? DataInscricao { get; set; }
        public DateTime DataConclusao { get; set; }
        public string Nota {  get; set; }
        public string Resultado { get; set; }
        public string CertificadoNumero { get; set; }
        public string Estado {  get; set; }
    }
}
