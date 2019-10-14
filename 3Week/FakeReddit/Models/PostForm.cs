using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoggedIn.Models
{
    public class PostForm
    {
        public int UserId {get;set;}
        [Required]
        public string Title {get;set;}
        [Required]
        [MinLength(7)]
        public string Content {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<DashboardUser> AvailableUsers {get;set;}
        public static Post CovertToPost(PostForm postForm)
        {
            return new Post()
            {
                Title = postForm.Title,
                Content = postForm.Content,
                UserId = postForm.UserId
            };
        }
    }
}