using System.Net.Sockets;

namespace RentalReceiptOrganizer.WebApi.Models
{
    public class PropertyDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }

    public class AddressDto
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}