using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveHT.Shared.Models.Habit
{
    public class HabitEdit
    {
        public int Id { get; set; }
        public string HabitTitle { get; set; }
        public string Description { get; set; }
    }
}
