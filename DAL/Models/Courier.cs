using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace DBSD.CW2._13768._14055._13287.DAL.Models
{
    /// <summary>
    /// Defines the entity for couriers in the database.
    /// </summary>
    public class Courier
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string City { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? TGUserName { get; set; }
        public required string PhoneNumber { get; set; }
        public byte[] ProfilePicture { get; set; } = new byte[0];
        public bool HasDrivingLicense { get; set; }
    }
}
