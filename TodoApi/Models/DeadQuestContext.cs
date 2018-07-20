using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class DeadQuestContext : DbContext
    {

        public DeadQuestContext(DbContextOptions<DeadQuestContext> options) : base(options)
        {

        }

        public DbSet<DeadQuest> DeadQuests { get; set; }
    }
}
