using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Contract.Models.Mapping;

namespace Contract.Models
{
    public partial class ContractTransferContext : DbContext
    {
        static ContractTransferContext()
        {
            Database.SetInitializer<ContractTransferContext>(null);
        }

        public ContractTransferContext()
            : base("Name=ContractTransferContext")
        {
        }

        //public DbSet<Company> Companies { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Function> Functions { get; set; }
        //public DbSet<Module> Modules { get; set; }
        //public DbSet<Operation> Operations { get; set; }
        //public DbSet<Room> Rooms { get; set; }
        //public DbSet<RoomCategory> RoomCategories { get; set; }
        //public DbSet<RoomState> RoomStates { get; set; }
        //public DbSet<RoomType> RoomTypes { get; set; }
        //public DbSet<ServiceCenter> ServiceCenters { get; set; }
        //public DbSet<Tenancy> Tenancies { get; set; }
        //public DbSet<sysdiagram> sysdiagrams { get; set; }
        //public DbSet<CheckLog> CheckLogs { get; set; }
        //public DbSet<TenancyCheckLog> TenancyCheckLogs { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Process> Processes { get; set; }
        //public DbSet<Route> Routes { get; set; }
        //public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new FunctionMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new OperationMap());
            modelBuilder.Configurations.Add(new RoomMap());
            modelBuilder.Configurations.Add(new RoomCategoryMap());
            modelBuilder.Configurations.Add(new RoomStateMap());
            modelBuilder.Configurations.Add(new RoomTypeMap());
            modelBuilder.Configurations.Add(new ServiceCenterMap());
            modelBuilder.Configurations.Add(new TenancyMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new CheckLogMap());
            modelBuilder.Configurations.Add(new TenancyCheckLogMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ProcessMap());
            modelBuilder.Configurations.Add(new RouteMap());
            modelBuilder.Configurations.Add(new TaskMap());
        }
    }
}
