using System;

namespace Cegid.TechnicalTests.Models
{
    public sealed class Reservation : EntityBase
    {
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public Room Room { get; set; }
        public string RoomId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
