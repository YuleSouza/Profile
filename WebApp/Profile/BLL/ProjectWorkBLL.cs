using System;
using System.Collections.Generic;

//Dependencys
using Profile.Models;
using Profile.DAL;

namespace Profile.BLL
{
    public class ProjectWorkBLL
    {
        #region Get

        public List<ProjectWork> GetCollectionProjectWorkFactory()
        {
            try
            {
                ProjectWorkDAL repository = new ProjectWorkDAL();
                List<ProjectWork> projectWorks = new List<ProjectWork>();
                return projectWorks = repository.GetCollectionProjectWork();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProjectWork GetProjectWorkById(int Id)
        {
            try
            {
                ProjectWorkDAL repository = new ProjectWorkDAL();
                ProjectWork projectWork = new ProjectWork();
                return projectWork = repository.GetProjectWorkById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion
    }
}