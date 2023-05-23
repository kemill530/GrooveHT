using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveHT.Shared.Models.Configuration
{
    public class ConfigurationCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int HabitId { get; set; }

        [Required]
        public int FrequencyId { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

    }
}
