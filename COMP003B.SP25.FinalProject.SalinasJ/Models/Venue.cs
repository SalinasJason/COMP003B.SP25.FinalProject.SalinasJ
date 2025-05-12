using System.ComponentModel.DataAnnotations;
namespace COMP003B.SP25.FinalProject.SalinasJ.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string Owner { get; set; }

        [Required]
        [Phone]
        public string OwnerPhoneNumber { get; set; }

        public virtual ICollection<EventDetail>? EventDetails { get; set; }
    }
}
