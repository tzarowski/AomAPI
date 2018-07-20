using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoMAPI.Models
{
    public abstract class Quest
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
    }
}
