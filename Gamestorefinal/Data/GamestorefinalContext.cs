using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GamesStore.Models;

namespace Gamestorefinal.Data
{
    public class GamestorefinalContext : DbContext
    {
        public GamestorefinalContext (DbContextOptions<GamestorefinalContext> options)
            : base(options)
        {
        }

        public DbSet<GamesStore.Models.Category> Category { get; set; }

        public DbSet<GamesStore.Models.Client> Client { get; set; }

        public DbSet<GamesStore.Models.Games> Games { get; set; }

        public DbSet<GamesStore.Models.OrderClient> OrderClient { get; set; }

        public DbSet<GamesStore.Models.OrdereSupplier> OrdereSupplier { get; set; }

        public DbSet<GamesStore.Models.Supplier> Supplier { get; set; }

        public DbSet<GamesStore.Models.Wishlist> Wishlist { get; set; }

        public DbSet<GamesStore.Models.Locations> Locations { get; set; }
    }
}
