﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrooveHT.Server.Models
{
    public class TrackerEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ConfigurationEntity))]
        public int ConfigId { get; set; }
        public virtual ConfigurationEntity ConfigurationEntity { get; set; }

        [Required]
        public bool TaskCompleted { get; set; }

        public string Notes { get; set; }
    }
}
