using System;
using MySql.Data.MySqlClient;

using Profile.Models;

namespace Profile.DAL
{
    public class PersonDAL
    {
        #region Dependencys
        protected DbConnect db;
        private MySqlCommand command;
        private MySqlDataReader reader;
        Person person;
        PersonSecurity personSecurity;
        #endregion

        #region Get
        public Person GetPerson()
        {
            try
            {
                db = new DbConnect();

                command = new MySqlCommand("GetPerson", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        person = new Person
                        {
                            PersonEntityID = reader.GetInt32("PersonEntityID"),
                            Name = reader.GetString("Name"),
                            Email = reader.GetString("Email"),
                            About = reader.GetString("About"),
                            JobTitle = reader.GetString("JobTitle"),
                            DateBirth = Convert.ToDateTime(reader.GetString("DateBirth")),
                            Phone = reader.GetString("Phone"),
                            Age = Convert.ToInt32(reader.GetInt32("Age")),
                            Freelance = Convert.ToBoolean(reader.GetBoolean("Freelance")),
                            Residence = reader.GetString("Residence"),
                            ImageProfile = reader.GetString("ImageProfile"),
                            ImageProfileBackground = reader.GetString("ImageProfileBackground"),
                            Address = reader.GetString("Address"),
                            ModifiedDate = reader.GetDateTime("ModifiedDate")
                        };
                    }
                }

                reader.Close();
                reader.Dispose();

                return person;
            }

            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public Person GetPersonById(int personID)
        {
            db = new DbConnect();

            command = new MySqlCommand("GetPersonByID", db.GetConnection());
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@p_PersonID", MySqlDbType.Int32).Value = personID;

            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    person = new Person
                    {
                        PersonEntityID = reader.GetInt32("PersonEntityID"),
                        Name = reader.GetString("Name"),
                        Email = reader.GetString("Email"),
                        About = reader.GetString("About"),
                        JobTitle = reader.GetString("JobTitle"),
                        DateBirth = Convert.ToDateTime(reader.GetString("DateBirth")),
                        Phone = reader.GetString("Phone"),
                        Age = Convert.ToInt32(reader.GetInt32("Age")),
                        Freelance = Convert.ToBoolean(reader.GetBoolean("Freelance")),
                        Residence = reader.GetString("Residence"),
                        ImageProfile = reader.GetString("ImageProfile"),
                        ImageProfileBackground = reader.GetString("ImageProfileBackground"),
                        Address = reader.GetString("Address"),
                        ModifiedDate = reader.GetDateTime("ModifiedDate")
                    };
                }
            }

            reader.Close();
            reader.Dispose();

            return person;
        }

        public PersonSecurity GetPersonSecurity(string username, string password)
        {
            db = new DbConnect();

            command = new MySqlCommand("GetPersonSecurity", db.GetConnection());
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@p_UserName", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@p_PasswordHash", MySqlDbType.VarChar).Value = password;

            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    personSecurity = new PersonSecurity()
                    {
                        PersonSecurityEntityID = reader.GetInt32("PersonSecurityEntityID"),
                        PersonEntityID = reader.GetInt32("PersonEntityID"),
                        UserName = reader.GetString("UserName"),
                        Password = reader.GetString("Password"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        CreatedDate = Convert.ToDateTime(reader.GetString("CreatedDate")),
                        ModifiedDate = Convert.ToDateTime(reader.GetString("ModifiedDate"))
                    };
                }
            }

            reader.Close();
            reader.Dispose();

            return personSecurity;
        }

        #endregion

        #region Post

        public bool PostPerson(Person person)
        {
            bool status = false;

            try
            {
                db = new DbConnect();
                string query = "insert into ProjectWork(Name, Email, About, JobTitle, DateBirth, Phone, Age, Frelance, Residence, ImageProfile, ImageProfileBackground, Address, CreatedDate, ModifiedDate) values('" +
                                                        person.Name + "'," + " '" + person.Email + "'," + " '" + person.About + "'," + " '" + person.JobTitle + "'," + " '" + person.DateBirth + "'," + " '" +
                                                        person.Phone + "'," + " '" + person.CreatedDate + "'," + " '" + person.Age + "'," + " '" + person.Freelance + "'," + " '" + person.Residence + "'," + " '" +
                                                        person.ImageProfile + "'," + " '" + person.ImageProfileBackground + "'," + " '" + person.Address + "'," + " '" + DateTime.Now + "'," + DateTime.Now + "'" + ");";


                command = new MySqlCommand(query, db.GetConnection());
                int tresult = command.ExecuteNonQuery();

                if (tresult > 0)
                {
                    return true;
                }
                return status;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}