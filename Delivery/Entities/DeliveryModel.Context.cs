//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Delivery.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EditionsCatalogEntities : DbContext
    {
        private static EditionsCatalogEntities _context;
        public EditionsCatalogEntities()
            : base("name=EditionsCatalogEntities")
        {
        }

        public static EditionsCatalogEntities GetContext()
        {
            if (_context == null)
                _context = new EditionsCatalogEntities();
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DeliveryType> DeliveryType { get; set; }
        public virtual DbSet<Edition> Edition { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Subscribtion> Subscribtion { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
