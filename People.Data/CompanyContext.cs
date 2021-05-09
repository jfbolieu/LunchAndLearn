using People.Data.Entities;
using System.Data.Entity;

namespace People.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext()
            : base("CompanyContext")
        {

        }


        public IDbSet<Client> Clients { get; set; }
        public IDbSet<Agent> Agents { get; set; }
        public IDbSet<Meeting> Meetings { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<Province> Provinces { get => Set<Province>(); }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
