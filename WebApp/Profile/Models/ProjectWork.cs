using System;
using System.ComponentModel.DataAnnotations;

namespace Profile.Models
{
    public class ProjectWork
    {
        private int projectWorkEntityID;
        private string title;
        private string subTitle;
        private string projectDescription;
        private string imagePath;
        private string imageDescription;
        private string externalUrl;
        private DateTime createdDate;
        private DateTime modifiedDate;

        public int ProjectWorkEntityID { get { return projectWorkEntityID; } set { projectWorkEntityID = value; } }

        [MinLength(5)]
        public string Title { get { return title; } set { title = value; } }

        [MinLength(5)]
        public string SubTitle { get { return subTitle; } set { subTitle = value; } }

        [MinLength(10)]
        public string ProjectDescription { get { return projectDescription; } set { projectDescription = value; } }

        [MinLength(10)]
        public string ImagePath { get { return imagePath; } set { imagePath = value; } }

        [MinLength(10)]
        public string ImageDescription { get { return imageDescription; } set { imageDescription = value; } }

        [MinLength(5)]
        public string ExternalUrl { get { return externalUrl; } set { externalUrl = value; } }

        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }

        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
    }
}