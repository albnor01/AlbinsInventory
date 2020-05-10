using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlbinsInventory.Models;

namespace AlbinsInventory.Data
{
    public class AlbinsInventoryContext : DbContext
    {
        public AlbinsInventoryContext (DbContextOptions<AlbinsInventoryContext> options)
            : base(options)
        {
        }

        public DbSet<AlbinsInventory.Models.Items> Items { get; set; }
    }
}
