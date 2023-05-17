using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrooveHT.Server.Models
{
    public class ProfileEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }

        [ForeignKey(nameof(TrackerEntity))]
        public int InProgress { get; set; }
        public virtual TrackerEntity TrackerEntity { get; set; }

    }
}
