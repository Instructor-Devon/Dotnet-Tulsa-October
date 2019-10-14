using System;
using System.ComponentModel.DataAnnotations;

namespace LoggedIn.Models
{
    public class Vote
    {
        [Key]
        public int VoteId {get;set;}
        public int PostId {get;set;}
        public int UserId {get;set;}
        public bool IsUpvote {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        // NAVIGATION PROPERTIES
        public DashboardUser Voter {get;set;}
        public Post VotedPost {get;set;}
    }
}