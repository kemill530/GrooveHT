using System.ComponentModel.DataAnnotations;

namespace GrooveHT.Server.Models
{
    public class HabitEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HabitTitle { get; set; }
        public string Description { get; set; }
    }
}
