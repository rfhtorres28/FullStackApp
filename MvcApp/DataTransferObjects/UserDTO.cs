using System;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.DataTransferObjects {
  
  public class RegisterModel {

    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

  }

  public class LoginModel {
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public bool RememberMe { get; set; } = false;

  }

  public class LogoutModel {

    [Required]
    public bool IsUserLogout { get; set; } = false;

  }

    public class CookieAuthenticationOptions
    {
        public TimeSpan ExpireTimeSpan { get; set; }
        public bool SlidingExpiration { get; set; }
    }

}