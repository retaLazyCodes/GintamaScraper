using System.ComponentModel.DataAnnotations;

namespace GintamaArcsScrapper.Models
{
    public class Arc
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Episodes { get; set; }
        public int QuantityEpisodes { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ReleaseDate { get; set; }
    }
}