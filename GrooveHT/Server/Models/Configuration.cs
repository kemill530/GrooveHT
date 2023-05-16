using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrooveHT.Server.Models
{
    public class Configuration
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Habit))]
        public int HabitId { get; set; }
        public virtual Habit Habit { get; set; }
       
        [Required]
        public DateTime StartDate { get; set; }
    }
}
