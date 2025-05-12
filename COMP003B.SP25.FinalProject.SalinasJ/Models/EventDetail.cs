namespace COMP003B.SP25.FinalProject.SalinasJ.Models
{
    public class EventDetail
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int OrganizerId { get; set; }
        public int VenueId { get; set; }  
        public int SpecialGuestId { get; set; }  

        public virtual Event? Events { get; set; }
        public virtual Organizer? Organizer { get; set; }
        public virtual Venue? Venue { get; set; }  
        public virtual SpecialGuest? SpecialGuest { get; set; } 
    }
}
