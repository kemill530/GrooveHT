using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveHT.Shared.Models.Habit
{
    public class HabitCreate
    {
        [Required]
        public string HabitTitle { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
