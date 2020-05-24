using System;
using System.ComponentModel.DataAnnotations;

namespace Profile.Models
{
    public class Comment
    {
        private int commentEntityID;
        private string title;
        public string commentDescription;
        public string dayComment;
        public string monthComment;
        public string yearComment;
        private DateTime dateComment;

        public int CommentEntityID { get { return commentEntityID; } set { commentEntityID = value; } }

        [MinLength(5)]
        public string Title { get { return title; } set { title = value; } }

        [MinLength(5)]
        public string CommentDescription { get { return commentDescription; } set { commentDescription = value; } }

        [MinLength(5)]
        public string DayComment { get { return dayComment; } set { dayComment = value; } }

        [MinLength(5)]
        public string MonthComment { get { return monthComment; } set { monthComment = value; } }

        [MinLength(5)]
        public string YearComment { get { return yearComment; } set { yearComment = value; } }

        public DateTime DateComment { get { return dateComment; } set { dateComment = value; } }
    }
}