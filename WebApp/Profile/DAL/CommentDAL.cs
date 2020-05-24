using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Profile.Models;

namespace Profile.DAL
{
    public class CommentDAL
    {
        #region Dependencys
        Comment comment;
        protected DbConnect db;
        private MySqlCommand command;
        private MySqlDataReader reader;
        #endregion

        #region Get
        public List<Comment> GetCollectionComment()
        {
            try
            {
                db = new DbConnect();

                List<Comment> comments = new List<Comment>();

                command = new MySqlCommand("GetComment", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Comment comment = new Comment
                        {
                            CommentEntityID = reader.GetInt32("CommentEntityID"),
                            Title = reader.GetString("Title"),
                            CommentDescription = reader.GetString("CommentDescription"),
                            DayComment = reader.GetMySqlDateTime("DateComment").Day.ToString(),
                            MonthComment = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(reader.GetDateTime("DateComment").Month).Substring(0, 3),
                            YearComment = reader.GetMySqlDateTime("DateComment").Year.ToString(),
                            DateComment = Convert.ToDateTime(reader.GetMySqlDateTime("DateComment"))
                        };

                        comments.Add(comment);
                    }
                }

                reader.Close();
                reader.Dispose();

                return comments;
            }

            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }
        }

        public Comment GetCommentById(int commentID)
        {
            try
            {
                db = new DbConnect();

                command = new MySqlCommand("GetCommentByID", db.GetConnection());
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@p_CommentID", MySqlDbType.Int32).Value = commentID;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comment = new Comment
                        {
                            CommentEntityID = reader.GetInt32("CommentEntityID"),
                            Title = reader.GetString("Title"),
                            CommentDescription = reader.GetString("CommentDescription"),
                            DayComment = reader.GetDateTime("DateComment").Day.ToString(),
                            MonthComment = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(reader.GetDateTime("DateComment").Month).Substring(0, 3),
                            YearComment = reader.GetMySqlDateTime("DateComment").Year.ToString(),
                            DateComment = Convert.ToDateTime(reader.GetMySqlDateTime("DateComment"))
                        };
                    }
                }

                reader.Close();
                reader.Dispose();

                return comment;
            }
            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }
        }

        public bool PutComment(Comment comment)
        {
            bool status = false;
            db = new DbConnect();

            try
            {
                string query = "insert into Comment (Title, CommentDescription, DateComment) values('" + comment.Title + "'," + " '" + comment.CommentDescription + "'," + " now()" + ");";
                command = new MySqlCommand(query, db.GetConnection());
                int tstatus = command.ExecuteNonQuery();
                if (tstatus > 0)
                {
                    return status = true;
                }

                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}