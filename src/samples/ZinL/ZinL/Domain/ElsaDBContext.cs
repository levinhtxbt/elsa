using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Elsa.Models;
using Elsa.Persistence.EntityFrameworkCore.DbContexts;
using Elsa.Persistence.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using ZinL.Activities.Customer.Activities;

namespace ZinL.Domain
{
    public class ElsaDBContext : ElsaContext
    {
        public ElsaDBContext(DbContextOptions<ElsaDBContext> options) : base(options) { }
    }
}
