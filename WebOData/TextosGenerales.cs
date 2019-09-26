using System.ComponentModel.DataAnnotations;

namespace WebOData
{
    public class TextosGenerales
    {
        [Key]
        public string Id { get; set; }
        [Key]
        public string Idioma { get; set; }
        public string Texto { get; set; }

    }
}
