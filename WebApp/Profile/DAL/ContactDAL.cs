using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Profile.Models;

namespace Profile.DAL
{
    public class ContactDAL
    {
        #region Dependencys
        protected DbConnect db;
        private MySqlCommand command;
        private MySqlDataReader reader;
        Contact contact;
        #endregion

        #region Get
        public List<Contact> GetCollectionContact()
        {
            try
            {
                List<Contact> contacts = new List<Contact>();
                db = new DbConnect();

                command = new MySqlCommand("GetContact", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Contact contact = new Contact
                        {
                            ContactEntityID = reader.GetInt32("ContactEntityID"),
                            Email = reader.GetString("Email"),
                            Name = reader.GetString("Name"),
                            Message = reader.GetString("Message"),
                            DateContact =  Convert.ToDateTime(reader.GetMySqlDateTime("DateContact"))
                        };

                        contacts.Add(contact);
                    }
                }

                reader.Close();
                reader.Dispose();

                return contacts;
            }

            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }
        }

        public Contact GetContactById(int contactID)
        {
            try
            {
                command = new MySqlCommand("GetContactByID", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@p_ContactID", MySqlDbType.Int32).Value = contactID;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contact = new Contact
                        {
                            ContactEntityID = reader.GetInt32("ContactEntityID"),
                            Email = reader.GetString("Email"),
                            Name = reader.GetString("Name"),
                            Message = reader.GetString("Message"),
                            DateContact = Convert.ToDateTime(reader.GetMySqlDateTime("DateContact"))
                        };
                    }
                }

                reader.Close();
                reader.Dispose();

                return contact;
            }
            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }
        }

        #endregion

        #region Put
        public bool PutContact(Contact contact)
        {

            bool status = false;
            db = new DbConnect();

            try
            {
                string query = "insert into Contact (Name, Email, Message, DateContact) values('" + contact.Name + "'," + " '" + contact.Email + "'," + " '" + contact.Message + "', " + "now()" + ");";
                command = new MySqlCommand(query, db.GetConnection());
                int tstatus = command.ExecuteNonQuery();
                if (tstatus > 0)
                {
                    return status = true;
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