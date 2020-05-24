using System;
using System.ComponentModel.DataAnnotations;

namespace Profile.Models
{
    public class Pricing
    {
        private int pricingEntityID;
        private int price;
        private string pricingType;
        private string period;
        private DateTime createdDate;
        private DateTime modifiedDate;

        public int PricingEntityID { get { return pricingEntityID; } set { pricingEntityID = value; } }

        public int Price { get { return price; } set { price = value; } }

        public string PricingType { get { return pricingType; } set { pricingType = value; } }

        [MinLength(5)]
        public string Period { get { return period; } set { period = value; } }

        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }

        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
    }

    public class PricingSkill : Pricing
    {
        private int pricingSkillEntityID;
        private string pricingSkillDescription;
        private bool pricingSkillEnabled;

        public int PricingSkillEntityID { get { return pricingSkillEntityID; } set { pricingSkillEntityID = value; } }

        [MinLength(5)]
        public string PricingSkillDescription { get { return pricingSkillDescription; } set { pricingSkillDescription = value; } }

        public bool PricingSkillEnabled { get { return pricingSkillEnabled; } set { pricingSkillEnabled = value; } }

    }
}