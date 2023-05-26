﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrooveHT.Shared.Models.Tracker
{
    public class TrackerListItem
    {
        public int Id { get; set; }
        public string ConfigurationName { get; set; }
        public bool TaskCompleted { get; set; }
        public DateTime Date { get; set; }

        public string Notes { get; set; }
    }
}
