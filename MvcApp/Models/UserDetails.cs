using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcApp.Models
{
    // No need to set primary key explicitly; IdentityUser already has an Id property
    public class UserDetails : IdentityUser {
        // Additional properties can be added here
        [Column("ContactNumber", TypeName = "nvarchar(100)")]
        public string ContactNumber { get; set; } = string.Empty;

        [Column("BirthDate", TypeName = "datetime2")]
        public DateTime BirthDate { get; set; } = DateTime.MinValue;

        [Column("FacebookLink", TypeName = "nvarchar(100)")]
        public string FacebookLink { get; set; } = string.Empty;

        [Column("InstagramLink", TypeName = "nvarchar(100)")]
        public string InstagramLink { get; set; } = string.Empty;

        [Column("LastLogin", TypeName = "datetime2")]
        public DateTime LastLogin { get; set; } = DateTime.MinValue;
    }
}
