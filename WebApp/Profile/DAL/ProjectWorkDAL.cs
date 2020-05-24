using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Profile.Models;

namespace Profile.DAL
{
    public class ProjectWorkDAL
    {
        #region Dependencys
        protected DbConnect db;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private ProjectWork projectWork;
        #endregion

        #region Get
        public List<ProjectWork> GetCollectionProjectWork()
        {
            try
            {
                db = new DbConnect();
                List<ProjectWork> projectWorks = new List<ProjectWork>();

                command = new MySqlCommand("GetProjectWork", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProjectWork projectWork = new ProjectWork
                        {
                            ProjectWorkEntityID = reader.GetInt32("ProjectWorkEntityID"),
                            Title = reader.GetString("Title"),
                            SubTitle = reader.GetString("SubTitle"),
                            ProjectDescription = reader.GetString("ProjectDescription"),
                            ImagePath = reader.GetString("ImagePath"),
                            ImageDescription = reader.GetString("ImageDescription"),
                            ExternalUrl = reader.GetString("ExternalUrl"),
                            CreatedDate = reader.GetDateTime("CreatedDate"),
                            ModifiedDate = reader.GetDateTime("ModifiedDate")
                        };

                        projectWorks.Add(projectWork);
                    }
                }

                reader.Close();
                reader.Dispose();

                return projectWorks;
            }
            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }
        }

        public ProjectWork GetProjectWorkById(int projectWorkID)
        {
            db = new DbConnect();

            command = new MySqlCommand("GetProjectWorkByID", db.GetConnection());
            command.Parameters.Add("@p_ProjectWorkID", MySqlDbType.Int32).Value = projectWorkID;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    projectWork = new ProjectWork
                    {
                        ProjectWorkEntityID = reader.GetInt32("ProjectEntityID"),
                        Title = reader.GetString("Title"),
                        SubTitle = reader.GetString("SubTitle"),
                        ProjectDescription = reader.GetString("ProjectDescription"),
                        ImagePath = reader.GetString("ImagePath"),
                        ImageDescription = reader.GetString("ImageDescription"),
                        ExternalUrl = reader.GetString("ExternalUrl"),
                        CreatedDate = reader.GetDateTime("CreatedDate"),
                        ModifiedDate = reader.GetDateTime("ModifiedDate")

                    };
                }
            }

            reader.Close();
            reader.Dispose();

            return projectWork;
        }
        #endregion
    }
}