using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace System_GMMunicipal.Models
{
    public class Acidente
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Local {  get; set; }
        public string Descricao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [ForeignKey("Condutor")]
        public int CondutorId { get; set; }
        public Condutor Condutor { get; set; }
        [ForeignKey("Motorizada")]
        public int MotorizadaId { get; set; }
        public Motorizada Motorizada { get; set; }
        public string TipoAcidente { get; set; }
        public string Gravidade { get; set; }
        public int NumeroFeridos { get; set; }
        public int NumeroMortos { get; set; }
        public int NumeroVeiculos { get; set; }
        public string CausaProvavel { get; set; }
        public string CondicoesClimaticas { get; set; }
        public string EstadoVia {  get; set; }
        public string RegistadoPor {  get; set; }
        public DateTime DataRegisto { get; set; } = DateTime.UtcNow;
    }
}