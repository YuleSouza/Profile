using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Profile.Models;

namespace Profile.DAL
{
    public class ExperienceDAL
    {
        #region Dependencys
        protected DbConnect db;
        private MySqlCommand command;
        private MySqlDataReader reader;
        Experience experience;
        #endregion

        #region Get

        public List<Experience> GetCollectionExperience()
        {
            try
            {
                db = new DbConnect();

                List<Experience> experiences = new List<Experience>();
                command = new MySqlCommand("GetExperience", db.GetConnection()) { };
                command.CommandType = System.Data.CommandType.StoredProcedure;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        experience = new Experience
                        {
                            ExperienceEntityID = reader.GetInt32("ExperienceEntityID"),
                            StartDate = reader.GetDateTime("StartDate"),
                            EndDate = reader.GetDateTime("EndDate"),
                            ExperienceTitle = reader.GetString("ExperienceTitle"),
                            InstitutionName = reader.GetString("InstitutionName"),
                            ExperienceDescription = reader.GetString("ExperienceDescription"),
                            ModifiedDate = reader.GetDateTime("ModifiedDate"),
                        };

                        experiences.Add(experience);
                    }
                }

                reader.Close();
                reader.Dispose();

                return experiences;
            }
            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }
        }

        public Experience GetExperienceById(int experienceID)
        {
            try
            {
                command = new MySqlCommand("GetExperienceByID", db.GetConnection()) { };
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@p_EducationID", MySqlDbType.Int32).Value = experienceID;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        experience = new Experience
                        {
                            ExperienceEntityID = reader.GetInt32("ExperienceEntityID"),
                            StartDate = reader.GetDateTime("StartDate"),
                            EndDate = reader.GetDateTime("EndDate"),
                            ExperienceTitle = reader.GetString("ExperienceTitle"),
                            InstitutionName = reader.GetString("InstitutionName"),
                            ExperienceDescription = reader.GetString("ExperienceDescription"),
                            ModifiedDate = reader.GetDateTime("ModifiedDate"),
                        };
                    }
                }

                reader.Close();
                reader.Dispose();

                return experience;
            }
            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }
        }

        #endregion
    }
}