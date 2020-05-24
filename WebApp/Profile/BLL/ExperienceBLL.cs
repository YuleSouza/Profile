using System;
using System.Collections.Generic;

//Dependencys
using Profile.Models;
using Profile.DAL;

namespace Profile.BLL
{
    public class ExperienceBLL
    {
        #region Get
        public List<Experience> GetCollectionExperience()
        {
            try
            {
                ExperienceDAL repository = new ExperienceDAL();
                List<Experience> experiences = new List<Experience>();
                return experiences = repository.GetCollectionExperience();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Experience GetExperienceById(int Id)
        {
            try
            {
                ExperienceDAL repository = new ExperienceDAL();
                Experience experience = new Experience();
                return experience = repository.GetExperienceById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}