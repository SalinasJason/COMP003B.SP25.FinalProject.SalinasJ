using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.SalinasJ.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        [Required]
        [StringLength(15)]
        public string Date { get; set; }

        [Required]
        [StringLength(15)]
        public string Time { get; set; }

        public virtual ICollection<EventDetail>? EventDetails { get; set; }
    }
}
