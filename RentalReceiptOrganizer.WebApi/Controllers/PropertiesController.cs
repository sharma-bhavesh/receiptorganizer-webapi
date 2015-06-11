using System.Threading.Tasks;
using System.Web.Http;
using RentalReceiptOrganizer.Domain;
using RentalReceiptOrganizer.DomainService.Interface;
using RentalReceiptOrganizer.WebApi.Models;

namespace RentalReceiptOrganizer.WebApi.Controllers
{
    public class PropertiesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public Task<IHttpActionResult> PostProperty([FromBody] PropertyDto propertyDto)
        {
            var address = Address.CreateAddress(country: propertyDto.Address.Country,
                postalCode: propertyDto.Address.PostalCode,
                state: propertyDto.Address.State,
                city: propertyDto.Address.City,
                addressLine1: propertyDto.Address.AddressLine1,
                addressLine2: propertyDto.Address.AddressLine2);
            var property = Property.CreateProperty(propertyDto.Name, address);

            _unitOfWork.PropertyRepository.Add(property);
            _unitOfWork.Commit();
            return Task.FromResult( (IHttpActionResult) Ok());
        }

    }
}