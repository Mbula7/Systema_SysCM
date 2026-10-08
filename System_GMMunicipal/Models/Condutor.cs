using System.ComponentModel.DataAnnotations.Schema;

namespace System_GMMunicipal.Models
{
    public class Condutor
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public string NumeroBI { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public int Telefone { get; set; }

        public string Email { get; set; }

        public string Endereco { get; set; }
        public string NumeroCartaConducao { get; set; }
        public string CategoriaCarta { get; set; }
        public DateTime DataEmissaoCarta { get; set; }
        public DateTime DataValidadeCarta { get; set; }
        public string Foto { get; set; }
        public string Estado { get; set; }

        public DateTime DataRegisto { get; set; } = DateTime.UtcNow;

        [ForeignKey("Municipio")]
        public int MunicipioId { get; set; }

        public Municipio Municipio { get; set; }

        public ICollection<Infracao> Infracaos { get; set; }

        public ICollection<Acidente> Acidentes { get; set; }

        public ICollection<Curso> Cursos { get; set; }

        public ICollection<FormacaoReciclagem> FormacaoReciclagems { get; set; }

        public ICollection<Licenca> Licencas { get; set; }

    }
}
