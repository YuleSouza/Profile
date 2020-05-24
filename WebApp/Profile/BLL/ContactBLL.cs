using System;
using System.Collections.Generic;

//Dependencys
using Profile.Models;
using Profile.DAL;

namespace Profile.BLL
{
    public class ContactBLL
    {
        #region Get
        public List<Contact> GetCollectionContact()
        {
            try
            {
                ContactDAL repository = new ContactDAL();
                List<Contact> contacts = new List<Contact>();
                return contacts = repository.GetCollectionContact();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contact GetContactById(int Id)
        {
            try
            {
                ContactDAL repository = new ContactDAL();
                Contact contact = new Contact();

                return contact = repository.GetContactById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        #endregion

        #region Put
        public bool PutContact(Contact contact)
        {
            try
            {
                ContactDAL repository = new ContactDAL();
                bool operation = repository.PutContact(contact);

                if (operation == true)
                {
                    //Util.Util mail = new Util.Util();
                    //mail.SendMail(contact.Name, contact.Email, contact.Message);
                }

                return operation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}