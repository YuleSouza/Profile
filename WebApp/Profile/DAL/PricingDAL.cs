using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Profile.Models;

namespace Profile.DAL
{
    public class PricingDAL
    {
        #region Dependencys
        protected DbConnect db;
        private MySqlCommand command;
        private MySqlDataReader reader;
        Pricing pricing;
        PricingSkill pricingSkill;
        #endregion

        #region Get

        public Pricing GetPricing()
        {
            try
            {
                db = new DbConnect();

                command = new MySqlCommand("GetPricing", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    pricing = new Pricing
                    {
                        PricingEntityID = reader.GetInt32("PricingEntityID"),
                        Price = reader.GetInt32("Price"),
                        PricingType = reader.GetString("PricingType"),
                        Period = reader.GetString("Period"),
                        ModifiedDate = reader.GetDateTime("ModifiedDate")
                    };
                }

                reader.Close();
                reader.Dispose();

                return pricing;
            }
            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }
        }

        public PricingSkill GetPricingByType(string pricingType)
        {
            try
            {
                db = new DbConnect();

                command = new MySqlCommand("GetPricingByType", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@p_PricingType", MySqlDbType.VarChar).Value = pricingType;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())

                        pricingSkill = new PricingSkill
                        {
                            PricingEntityID = reader.GetInt32("PricingEntityID"),
                            Price = reader.GetInt32("Price"),
                            PricingType = reader.GetString("PricingType"),
                            Period = reader.GetString("Period"),
                            ModifiedDate = reader.GetDateTime("ModifiedDate")
                        };
                }

                reader.Close();
                reader.Dispose();

                return pricingSkill;
            }
            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }
        }

        public List<PricingSkill> GetCollectionPricingSkillByType(string pricingSkillType)
        {
            try
            {
                List<PricingSkill> listPricingSkill = new List<PricingSkill>();
                db = new DbConnect();

                command = new MySqlCommand("GetPricingSkillByType", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@p_PricingSkillType", MySqlDbType.VarChar).Value = pricingSkillType;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pricingSkill = new PricingSkill()
                        {
                            PricingEntityID = reader.GetInt32("PricingEntityID"),
                            PricingSkillEntityID = reader.GetInt32("PricingSkillEntityID"),
                            Price = reader.GetInt32("Price"),
                            PricingType = reader.GetString("PricingType"),
                            PricingSkillDescription = reader.GetString("SkillDescription"),
                            PricingSkillEnabled = reader.GetBoolean("PricingSkillEnabled"),
                            Period = reader.GetString("Period"),
                            ModifiedDate = reader.GetDateTime("ModifiedDate")
                        };

                        listPricingSkill.Add(pricingSkill);
                    }
                }

                reader.Close();
                reader.Dispose();

                return listPricingSkill;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}