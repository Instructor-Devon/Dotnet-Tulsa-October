using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoggedIn.Models
{
    public class Post
    {
        [Key]
        public int PostId {get;set;}
        public int UserId {get;set;}
        [Required]
        public string Title {get;set;}
        [Required]
        [MinLength(7)]
        public string Content {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // NAVIGATION PROPERTIES
        public DashboardUser Author {get;set;} 
        public List<Vote> VotesReceived {get;set;}
    }
}