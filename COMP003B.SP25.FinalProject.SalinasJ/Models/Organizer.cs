using System.ComponentModel.DataAnnotations;
namespace COMP003B.SP25.FinalProject.SalinasJ.Models
{
    public class Organizer
    {
        public int OrganizerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string Role { get; set; }

        public virtual ICollection<EventDetail>? EventDetails { get; set; }
    }
}
