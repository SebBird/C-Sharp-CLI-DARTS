using System;
using System.Collections.Generic;
using System.Text;

namespace CLI_Darts
{
    public enum Skill
    {
        Beginner,
        Novice,
        Professional,
        Expert
    }
    public class Player
    {
        public string name;
        public Skill playerSkill;

        public Player(string Name, Skill SkillLevel)
        {
            name = Name;
            SkillLevel = playerSkill;
        }
    }
}
