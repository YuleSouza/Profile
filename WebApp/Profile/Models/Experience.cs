using System;
using System.ComponentModel.DataAnnotations;

namespace Profile.Models
{
    public class Experience
    {
        private int experienceEntityID;
        private DateTime startDate;
        private DateTime endDate;
        private string experienceTitle;
        private string institutionName;
        private string experienceDescription;
        private DateTime createdDate;
        private DateTime modifiedDate;

        public int ExperienceEntityID { get { return experienceEntityID; } set { experienceEntityID = value; } }

        public DateTime StartDate { get { return startDate; } set { startDate = value; } }

        public DateTime EndDate { get { return endDate; } set { endDate = value; } }

        [MinLength(5)]
        public string ExperienceTitle { get { return experienceTitle; } set { experienceTitle = value; } }

        [MinLength(5)]
        public string InstitutionName { get { return institutionName; } set { institutionName = value; } }

        [MinLength(5)]
        public string ExperienceDescription { get { return experienceDescription; } set { experienceDescription = value; } }

        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }

        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
    }
}