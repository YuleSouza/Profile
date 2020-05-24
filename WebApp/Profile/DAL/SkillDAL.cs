using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Profile.Models;

namespace Profile.DAL
{
    public class SkillDAL
    {
        #region Dependencys
        protected DbConnect db;
        private MySqlCommand command;
        private MySqlDataReader reader;
        #endregion

        #region Get
        public List<Skill> GetCollectionSkillByType(string type)
        {
            try
            {
                db = new DbConnect();

                List<Skill> skillscoding = new List<Skill>();

                command = new MySqlCommand("GetSkillByType", db.GetConnection());
                command.Parameters.Add("@p_SkillType", MySqlDbType.VarChar).Value = type;
                command.CommandType = System.Data.CommandType.StoredProcedure;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Skill skill = new Skill
                        {
                            SkillEntityID = reader.GetInt32("SkillEntityID"),
                            SkillName = reader.GetString("SkillName"),
                            SkillRating = reader.GetInt32("SkillRating"),
                            ModifiedDate = reader.GetDateTime("ModifiedDate")
                        };

                        skillscoding.Add(skill);
                    }

                    reader.Close();
                    reader.Dispose();
                }

                return skillscoding;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}