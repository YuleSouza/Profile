using System;
using System.Collections.Generic;

//Dependencys
using Profile.Models;
using Profile.DAL;

namespace Profile.BLL
{
    public class SkillBLL
    {
        #region Get
        public List<Skill> GetCollectionSkillsByType(string type)
        {
            try
            {
                SkillDAL repository = new SkillDAL();
                List<Skill> skills = new List<Skill>();
                return skills = repository.GetCollectionSkillByType(type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}