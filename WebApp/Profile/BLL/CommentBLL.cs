using System;
using System.Collections.Generic;

//Dependencys
using Profile.Models;
using Profile.DAL;

namespace Profile.BLL
{
    public class CommentBLL
    {
        #region Get
        public List<Comment> GetCollectionComment()
        {
            try
            {
                CommentDAL repository = new CommentDAL();
                List<Comment> comments = new List<Comment>();

                return comments = repository.GetCollectionComment();
            }
            catch (Exception ex)
            {
                throw ex;
            }                
        }

        public Comment GetCommentById(int Id)
        {
            try
            {
                CommentDAL repository = new CommentDAL();
                Comment comment = new Comment();

                return comment = repository.GetCommentById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Put

        public bool PutComment(Comment comment)
        {
            try
            {
                CommentDAL repository = new CommentDAL();
                bool operation = repository.PutComment(comment);

                return operation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}