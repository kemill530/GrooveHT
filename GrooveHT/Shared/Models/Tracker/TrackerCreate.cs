using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveHT.Shared.Models.Tracker
{
    public class TrackerCreate
    {
        public int ConfigurationId { get; set; }
        public bool TaskCompleted { get; set; }
        public string Notes { get; set; }
    }
}
