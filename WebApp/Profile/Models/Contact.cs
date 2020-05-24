using System;
using System.ComponentModel.DataAnnotations;

namespace Profile.Models
{
    public class Contact
    {
        private int contactEntityID;
        private string email;
        private string name;
        private string message;
        private DateTime datecontact;
        private DateTime createdDate;
        private DateTime modifiedDate;

        public int ContactEntityID { get { return contactEntityID; } set { contactEntityID = value; } }

        [MinLength(5)]
        public string Email { get { return email; } set { email = value; } }

        [MinLength(4)]
        public string Name { get { return name; } set { name = value; } }

        [MinLength(10)]
        public string Message { get { return message; } set { message = value; } }

        public DateTime DateContact { get { return datecontact; } set { datecontact = value; } }

        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }

        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
    }
}