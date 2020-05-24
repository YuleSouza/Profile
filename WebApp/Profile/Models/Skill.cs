using System;
using System.ComponentModel.DataAnnotations;

namespace Profile.Models
{
    public class Skill
    {
        private int skillEntityID;
        private string skillName;
        private int skillRating;
        private string skillType;
        private DateTime createdDate;
        private DateTime modifiedDate;

        public int SkillEntityID { get { return skillEntityID; } set { skillEntityID = value; } }

        [MinLength(5)]
        public string SkillName { get { return skillName; } set { skillName = value; } }

        public int SkillRating { get { return skillRating; } set { skillRating = value; } }

        public string SkillType { get { return skillType; } set { skillType = value; } }

        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }

        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
    }
}