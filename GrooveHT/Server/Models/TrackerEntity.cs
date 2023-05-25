using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrooveHT.Server.Models
{
    public class TrackerEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ConfigurationEntity))]
        public int ConfigurationId { get; set; }
        public virtual ConfigurationEntity Configuration { get; set; }
        //[ForeignKey(nameof(HabitEntity))]
        //public string HabitName { get; set; }
        //public virtual HabitEntity Habit { get; set;}

        //[ForeignKey(nameof(FrequencyEntity))]
        //public string FrequencyType { get; set; }
        //public virtual FrequencyEntity Frequency { get; set;}

        [Required]
        public bool TaskCompleted { get; set; }

        public string Notes { get; set; }
    }
}
