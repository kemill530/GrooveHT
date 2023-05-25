using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveHT.Shared.Models.Frequency
{
    public class FrequencyCreate
    {
        [Required]
        public string FrequencyType { get; set; }
    }
}
