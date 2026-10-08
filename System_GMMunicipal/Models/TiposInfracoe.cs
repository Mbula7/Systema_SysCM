namespace System_GMMunicipal.Models
{
    public class TiposInfracoe
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string  Descricao { get; set; }
        public Decimal ValorBase { get; set; }
        public string Gravidade  { get; set; }
        public string Estado { get; set; }

        public ICollection<Infracao> Infracaos { get; set; }
    }
}
