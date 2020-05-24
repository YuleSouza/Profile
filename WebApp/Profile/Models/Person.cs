using System;
using System.ComponentModel.DataAnnotations;

namespace Profile.Models
{
    public class Person
    {
        private int personEntityID;
        private string name;
        private string email;
        private string about;
        private string jobTitle;
        private DateTime dateBirth;
        private string phone;
        private int age;
        private bool freelance;
        private string imageProfile;
        private string imageProfileBackground;
        private string residence;
        private string address;
        private DateTime modifiedDate;
        private DateTime createdDate;

        public int PersonEntityID { get { return personEntityID; } set { personEntityID = value; } }

        [MinLength(5)]
        public string Name { get { return name; } set { name = value; } }

        [MinLength(5)]
        public string Email { get { return email; } set { email = value; } }

        [MinLength(5)]
        public string About { get { return about; } set { about = value; } }

        [MinLength(3)]
        public string JobTitle { get { return jobTitle; } set { jobTitle = value; } }

        public DateTime DateBirth { get { return dateBirth; } set { dateBirth = value; } }

        public string Phone { get { return phone; } set { phone = value; } }

        public int Age { get { return age; } set { age = value; } }

        [MinLength(10)]
        public bool Freelance { get { return freelance; } set { freelance = value; } }

        public string ImageProfile { get { return imageProfile; } set { imageProfile = value; } }

        public string ImageProfileBackground { get { return imageProfileBackground; } set { imageProfileBackground = value; } }

        [MinLength(10)]
        public string Residence { get { return residence; } set { residence = value; } }

        [MinLength(10)]
        public string Address { get { return address; } set { address = value; } }

        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }

        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
    }

    public class PersonSecurity
    {
        private int personSecurityEntityID;
        private int personEntityID;
        private string userName;
        private string password;
        private string passwordHash;
        private DateTime modifiedDate;
        private DateTime createdDate;

        public int PersonSecurityEntityID { get { return personSecurityEntityID; } set { personSecurityEntityID = value; } }

        public int PersonEntityID { get { return personEntityID; } set { personEntityID = value; } }

        [MinLength(5)]
        [Required]
        public string UserName { get { return userName; } set { userName = value; } }

        [MinLength(5)]
        [Required]
        public string Password { get { return password; } set { password = value; } }

        public string PasswordHash { get { return passwordHash; } set { passwordHash = value; } }

        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }

        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
    }
}