using System;
using RentalReceiptOrganizer.Domain;
using RentalReceiptOrganizer.DomainService.Interface;

namespace RentalReceiptOrganizer.Data
{
    public class RentalReceiptOrganizerUnitOfWork : IUnitOfWork
    {
        private readonly RentalReceiptOrganizerContext _context;

        public RentalReceiptOrganizerUnitOfWork(string connectionString)
        {
            _context = new RentalReceiptOrganizerContext(connectionString);
        }

        public IRepository<Property> PropertyRepository
        {
            get { return new Repository<Property>(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        
        private bool _disposed;

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
            }
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}