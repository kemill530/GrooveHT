using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrooveHT.Server.Models
{
    public class Tracker
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Configuration))]
        public int ConfigId { get; set; }
        public virtual Configuration Configuration { get; set; }

        [Required]
        public bool TaskCompleted { get; set; }

        public string Notes { get; set; }
    }
}
