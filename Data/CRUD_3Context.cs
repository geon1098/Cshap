using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_3.Models;

namespace CRUD_3.Data
{
    public class CRUD_3Context : DbContext
    {
        public CRUD_3Context (DbContextOptions<CRUD_3Context> options)
            : base(options)
        {
        }

        public DbSet<CRUD_3.Models.Language> Language { get; set; } = default!;
    }
}
