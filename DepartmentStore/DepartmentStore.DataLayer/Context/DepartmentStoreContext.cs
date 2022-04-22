using System;
using System.Collections.Generic;
using System.Text;
using DepartmentStore.DataLayer.Entities.Permissions;
using DepartmentStore.DataLayer.Entities.Product;
using DepartmentStore.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace DepartmentStore.DataLayer.Context
{
    public class DepartmentStoreContext : DbContext
    {
        public DepartmentStoreContext(DbContextOptions<DepartmentStoreContext> options) : base(options)
        {

        }

        #region User

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Permission

        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }


        #endregion

        #region Product

        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<CountryMade> CountryMades { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubProduct> SubProducts { get; set; }



        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);

            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => !r.IsDelete);

            modelBuilder.Entity<ProductGroup>()
                .HasQueryFilter(g => !g.IsDelete);

            base.OnModelCreating(modelBuilder);
        }
    }
}
