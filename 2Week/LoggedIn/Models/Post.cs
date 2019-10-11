using System;
using System.ComponentModel.DataAnnotations;

namespace LoggedIn.Models
{
    public class Post
    {
        [Key]
        public int PostId {get;set;}
        public int UserId {get;set;}
        public string Title {get;set;}
        public string Content {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        // NAVIGATION PROPERTIES
        public DashboardUser Author {get;set;} 
    }
}