using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Catch : DataEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Species { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? SessionId { get; set; }
        [ForeignKey("SessionId")]
        public Session? Session { get; set; }
    }
}
