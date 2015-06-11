using RentalReceiptOrganizer.Domain.Interface;

namespace RentalReceiptOrganizer.Domain
{
    public class Property : IEntity
    {
        /// <summary>
        ///     EF purposes for now
        /// </summary>
        protected Property()
        {
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }

        public static Property CreateProperty(string name, Address address)
        {
            return new Property
            {
                Name = name,
                Address = address
            };
        }
    }

    public class Address
    {
        protected Address()
        {
            
        }

        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }

        public static Address CreateAddress(string country, string postalCode, string state, string city,
            string addressLine1, string addressLine2 = null)
        {
            return new Address
            {
                AddressLine1 = addressLine1,
                AddressLine2 = addressLine2,
                City = city,
                State = state,
                PostalCode = postalCode,
                Country = country
            };
        }
    }
}