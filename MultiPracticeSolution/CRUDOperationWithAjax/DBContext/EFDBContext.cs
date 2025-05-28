using CRUDOperationWithAjax.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDOperationWithAjax.DBContext
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions options) : base(options) { }
        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
