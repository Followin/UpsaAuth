using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpsaApi.DAL.Entities
{
    public class EmployeeSkills
    {
        public Int64 EmployeeId { get; set; }

        public Int64 SkillId { get; set; }

        public Int32 SkillLevelId { get; set; }
    }
}
