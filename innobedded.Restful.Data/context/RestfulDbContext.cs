using innobedded.Restful.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innobedded.Restful.Data.context
{
   public    class RestfulDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

    }
}
