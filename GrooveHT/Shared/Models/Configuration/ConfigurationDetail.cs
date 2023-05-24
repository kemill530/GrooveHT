using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveHT.Shared.Models.Configuration
{
    public class ConfigurationDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HabitId { get; set; }
        public string HabitName { get; set; }
        public int FrequencyId { get; set; }
        public string Frequency { get; set; }
        public DateTimeOffset StartDate { get; set; }
    }
}
