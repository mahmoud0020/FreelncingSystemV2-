using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreelancerSystem.Models
{
    public class Post
    {
        [Key]
        public string postId { get; set; }
        public string ClientName { get; set; }
        public string ClientId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string JopType { get; set; }
        
        [Required]
        public int JobBudget { get; set; }
        public DateTime Creation_Date { get; set; }
        public int? NumProposal { get; set; }
        public Boolean? IsAprroved { get; set; }
        [Required]
        public string postDescription { get; set; }
        public ApplicationUser User { get; set; }
    }
    
}