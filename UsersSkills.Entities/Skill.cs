using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersSkills.Entities
{
    public class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Skill() { }
        public Skill(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
        public Skill(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Skill(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{ID}. {Name}";

        }
    }
}
