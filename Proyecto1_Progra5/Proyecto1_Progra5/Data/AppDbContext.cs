using Microsoft.EntityFrameworkCore;
using Proyecto1_Progra5.Models;
using System.Collections.Generic;

namespace Proyecto1_Progra5.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}
