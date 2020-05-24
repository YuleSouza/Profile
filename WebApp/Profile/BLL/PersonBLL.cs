using System;

//Dependencys
using Profile.Models;
using Profile.DAL;

namespace Profile.BLL
{
    public class PersonBLL
    {
        #region Get
        public Person GetPerson()
        {
            try
            {
                PersonDAL repository = new PersonDAL();
                Person person = new Person();

                return person = repository.GetPerson();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Person GetPersonById(int personID)
        {
            try
            {
                PersonDAL repository = new PersonDAL();
                Person person = new Person();

                return person = repository.GetPersonById(personID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersonSecurity GetPersonSecurity(string username, string password)
        {
            try
            {
                PersonDAL repository = new PersonDAL();
                PersonSecurity personSecurity = new PersonSecurity();
                return personSecurity = repository.GetPersonSecurity(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}