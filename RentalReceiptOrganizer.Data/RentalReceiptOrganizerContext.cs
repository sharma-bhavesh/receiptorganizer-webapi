using System.Data.Entity;
using RentalReceiptOrganizer.Domain;

namespace RentalReceiptOrganizer.Data
{
    public class RentalReceiptOrganizerContext : DbContext
    {
        static RentalReceiptOrganizerContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RentalReceiptOrganizerContext>());
        }

        public RentalReceiptOrganizerContext(string connectionString) : base(connectionString)
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().ToTable("Property");
        }


    }
}