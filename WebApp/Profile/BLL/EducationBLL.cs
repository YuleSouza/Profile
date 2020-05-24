using System;
using System.Collections.Generic;

//Dependencys
using Profile.Models;
using Profile.DAL;

namespace Profile.BLL
{
    public class EducationBLL
    {
        #region Get
        public List<Education> GetCollectionEducation()
        {
            try
            {
                EducationDAL repository = new EducationDAL();
                List<Education> educations = new List<Education>();
                return educations = repository.GetCollectionEducation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Education GetEducationById(int Id)
        {
            try
            {
                EducationDAL repository = new EducationDAL();
                Education education = new Education();
                return education = repository.GetEducationById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}