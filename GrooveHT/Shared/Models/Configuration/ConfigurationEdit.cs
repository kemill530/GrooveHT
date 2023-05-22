using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveHT.Shared.Models.Configuration
{
    public class ConfigurationEdit
    {
        public int Id { get; set; }
        public int HabitId { get; set; }
        public int FrequencyId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
