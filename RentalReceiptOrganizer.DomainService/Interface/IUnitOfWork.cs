using RentalReceiptOrganizer.Domain;

namespace RentalReceiptOrganizer.DomainService.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Property> PropertyRepository { get; }

        void Commit();

        void Dispose();
    }
}