
namespace TaskManagerAPI.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int? userId { get; set; }
        public User? User { get; set; }

      
    }
}
