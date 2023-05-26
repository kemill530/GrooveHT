using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveHT.Shared.Models.Tracker
{
    public class TrackerHistoryList
    {
        [Required]
        public int ConfigurationId { get; set; }
    }
}
