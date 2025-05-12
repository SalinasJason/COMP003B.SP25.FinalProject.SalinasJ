using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.SalinasJ.Models
{
    public class SpecialGuest
    {
        public int SpecialGuestId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(250)]
        public string Bio { get; set; }

        public virtual ICollection<EventDetail>? EventDetails { get; set; }
    }
}
