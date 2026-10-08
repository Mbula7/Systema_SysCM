using System.ComponentModel.DataAnnotations.Schema;

namespace System_GMMunicipal.Models
{
    public class FiscalUtilizador
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NumeroIdentificacao { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Instituicao { get; set; }
        [ForeignKey("Municipio")]
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public string Estado { get; set; }
        public DateTime CreateDate { get; set; }

        public ICollection<Infracao> Infracaos { get; set; }

        public ICollection<Inspencao> Inspencaos {  get; set; }
    }
}
