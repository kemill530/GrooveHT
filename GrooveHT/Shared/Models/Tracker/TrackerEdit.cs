using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveHT.Shared.Models.Tracker
{
    public class TrackerEdit
    {
        public int Id { get; set; }
        public int ConfigId { get; set; }
        public bool TaskCompleted { get; set; }
        public string Notes { get; set; }
    }
}
