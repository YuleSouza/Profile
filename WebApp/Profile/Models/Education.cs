using System;
using System.ComponentModel.DataAnnotations;

namespace Profile.Models
{
    public class Education
    {
        private int educationEntityID;
        private DateTime startDate;
        private DateTime endDate;
        private string educationTitle;
        private string institutionName;
        private string courseDescription;
        private DateTime createdDate;
        private DateTime modifiedDate;

        public int EducationEntityID { get { return educationEntityID; } set { educationEntityID = value; } }

        public DateTime StartDate { get { return startDate; } set { startDate = value; } }

        public DateTime EndDate { get { return endDate; } set { endDate = value; } }

        [MinLength(5)]
        public string EducationTitle { get { return educationTitle; } set { educationTitle = value; } }

        [MinLength(5)]
        public string InstitutionName { get { return institutionName; } set { institutionName = value; } }

        [MinLength(5)]
        public string CourseDescription { get { return courseDescription; } set { courseDescription = value; } }

        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }

        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
    }
}