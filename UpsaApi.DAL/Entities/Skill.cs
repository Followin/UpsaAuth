using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpsaApi.DAL.Entities
{
    public class Skill
    {
        public Int64 Id { get; set; }

        public String Name { get; set; }

        public SkillCategory Category { get; set; }
    }
}
