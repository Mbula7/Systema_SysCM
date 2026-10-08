namespace System_GMMunicipal.Models
{
    public class Provicia
    {
        public int Id { get; set; }

        public string? NameProvincia { get; set; }

        public string? Codigo { get; set; }

        public DateTime? CreatedDate { get; set; } = default(DateTime?);

        public ICollection<Municipio> Municipios { get; set; } 
    }
}
