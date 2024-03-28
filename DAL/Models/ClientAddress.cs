namespace DBSD.CW2._13768._14055._13287.DAL.Models
{
    /// <summary>
    /// Defines the address entity for clients.
    /// </summary>
    public class ClientAddress
    {
        public int Id { get; set; }
        public required string City { get; set; }
        public required string HomeNumber { get; set; }
        public required string Street { get; set; }
        public int ClientId { get; set; }
    }
}
