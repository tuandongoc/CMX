using CMX.Entities.Models.UIModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Core
{
    public class CoreContext : DbContext
    {
        // Methods
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CWX_LoginAttemptsLog>().ToTable<CWX_LoginAttemptsLog>("CWX_LoginAttemptsLog");
        }

        // Properties
        public DbSet<CWX_LoginAttemptsLog> CWX_LoginAttemptsLog { get; set; }

        public DbSet<CWX_LoginAttemptsLog_ListView> CWX_LoginAttemptsLog_ListView { get; set; }
    }
}
