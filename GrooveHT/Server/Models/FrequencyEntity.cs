using System.ComponentModel.DataAnnotations;

namespace GrooveHT.Server.Models
{
    public class FrequencyEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FrequencyType { get; set; }
    }
}
