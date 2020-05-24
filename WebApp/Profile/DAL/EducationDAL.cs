using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Profile.Models;

namespace Profile.DAL
{
    public class EducationDAL
    {
        #region Dependencys
        protected DbConnect db;
        private MySqlCommand command;
        private MySqlDataReader reader;
        Education education;
        #endregion

        #region Get

        public List<Education> GetCollectionEducation()
        {
            try
            {
                db = new DbConnect();

                List<Education> educations = new List<Education>();
                command = new MySqlCommand("GetEducation", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        education = new Education
                        {
                            EducationEntityID = reader.GetInt32("EducationEntityID"),
                            StartDate = Convert.ToDateTime(reader.GetDateTime("StartDate")),
                            EndDate = Convert.ToDateTime(reader.GetDateTime("EndDate")),
                            EducationTitle = reader.GetString("EducationTitle"),
                            InstitutionName = reader.GetString("InstitutionName"),
                            CourseDescription = reader.GetString("CourseDescription"),
                            ModifiedDate = Convert.ToDateTime(reader.GetDateTime("ModifiedDate"))
                        };

                        educations.Add(education);
                    }
                }

                reader.Close();
                reader.Dispose();

                return educations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Education GetEducationById(int educationID)
        {
            try
            {
                command = new MySqlCommand("GetEducationByID", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@p_EducationID", MySqlDbType.Int32).Value = educationID;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        education = new Education
                        {
                            EducationEntityID = reader.GetInt32("EducationEntityID"),
                            StartDate = Convert.ToDateTime(reader.GetDateTime("StartDate")),
                            EndDate = Convert.ToDateTime(reader.GetDateTime("EndDate")),
                            EducationTitle = reader.GetString("EducationTitle"),
                            InstitutionName = reader.GetString("InstitutionName"),
                            CourseDescription = reader.GetString("CourseDescription"),
                            ModifiedDate = Convert.ToDateTime(reader.GetDateTime("ModifiedDate"))
                        };
                    }
                }

                reader.Close();
                reader.Dispose();

                return education;
            }
            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }
        }

        #endregion
    }
}