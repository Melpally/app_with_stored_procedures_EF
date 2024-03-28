namespace DBSD.CW2._13768._14055._13287.DAL.Models
{
    /// <summary>
    /// Defines the entity for orders.
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } 
        public DateTime DeliveryDate { get; set; } 
        public float Price { get; set; }
        public int CourierId { get; set; }
        public int ClientId { get; set; }

    }
}
