using System;
using System.Collections.Generic;

//Dependencys
using Profile.Models;
using Profile.DAL;

namespace Profile.BLL
{
    public class PricingBLL
    {
        #region Get

        public Pricing GetPricing()
        {
            try
            {
                PricingDAL repository = new PricingDAL();
                Pricing pricingSkill = new Pricing();
                return pricingSkill = repository.GetPricing();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public PricingSkill GetPricingByType(string pricingType)
        {
            try
            {
                PricingDAL repository = new PricingDAL();
                PricingSkill pricingSkill = new PricingSkill();
                return pricingSkill = repository.GetPricingByType(pricingType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PricingSkill> GetCollectionPricingSkill(string pricingSkillType)
        {
            try
            {
                PricingDAL repository = new PricingDAL();
                List<PricingSkill> pricingSkillList = new List<PricingSkill>();
                return pricingSkillList = repository.GetCollectionPricingSkillByType(pricingSkillType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}