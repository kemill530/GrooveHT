using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrooveHT.Server.Models
{
    public class TrackerEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ConfigurationEntity))]
        public int ConfigurationId { get; set; }
        public virtual ConfigurationEntity Configuration { get; set; }

        [Required]
        public bool TaskCompleted { get; set; }
        [Required]
        public DateTime Date { get; set; }           

        public string Notes { get; set; }
    }
}
