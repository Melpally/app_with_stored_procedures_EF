namespace DBSD.CW2._13768._14055._13287.DAL.Models
{
    /// <summary>
    /// Defines an entity for clients in the application.
    /// </summary>
    public class Client
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
