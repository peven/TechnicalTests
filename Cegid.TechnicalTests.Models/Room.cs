namespace Cegid.TechnicalTests.Models
{
    public sealed class Room : EntityBase
    {
        public int Number { get; set; }
        public int Floor { get; set; }
        public RoomType RoomType { get; set; }
    }
}
