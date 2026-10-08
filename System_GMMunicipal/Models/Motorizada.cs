using System.ComponentModel.DataAnnotations.Schema;

namespace System_GMMunicipal.Models
{
    public class Motorizada
    {
        public int Id { get; set; }

        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime AnoFabrico { get; set; }
        public string Cor { get; set; }
        public string NumeroChassi { get; set; }
        public string NumeroMotor { get; set; }
        public string Cilindrada { get; set; }
        public string CapacidadeCarga { get; set; }
        public string Estado { get; set; }
        public DateTime DataRegisto { get; set; } = DateTime.UtcNow;
        [ForeignKey("Condutor")]
        public int condutorId { get; set; }
        public Condutor Condutor { get; set; }

        public ICollection<Acidente> Acidentes { get; set; }

        public ICollection<Infracao> infracaos { get; set; }

        public ICollection<Inspencao> Inspencaos { get; set; }

        public ICollection<Licenca> Licencas { get; set; }
    }
}
