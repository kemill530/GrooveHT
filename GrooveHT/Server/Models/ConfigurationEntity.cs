using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrooveHT.Server.Models
{
    public class ConfigurationEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(HabitEntity))]
        public int HabitId { get; set; }
        public virtual HabitEntity HabitEntity { get; set; }

        [ForeignKey(nameof(FrequencyEntity))]
        public int FrequencyId { get; set; }
        public virtual FrequencyEntity FrequencyEntity { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }
}
