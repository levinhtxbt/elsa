using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa.Persistence.EntityFrameworkCore.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ZinL.Domain
{
    public class ElsaDBContext : ElsaContext
    {
        public ElsaDBContext(DbContextOptions<ElsaDBContext> options) : base(options)
        {

        }
    }
}
