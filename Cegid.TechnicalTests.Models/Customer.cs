using System.Collections.Generic;

namespace Cegid.TechnicalTests.Models
{
    public sealed class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HashSet<Reservation> Reservations { get; set; }
        public override string ToString() => $"{Id}\t{FirstName} {LastName} registed {Creation}";
    }
}
