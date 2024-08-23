using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; 
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MvcApp.Models;
using MvcApp.DataTransferObjects;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies; 



namespace MvcApp.Controller {

  [Route("api/users")]
  [ApiController]
  public class APIController: ControllerBase {


     private readonly UserManager<UserDetails> _userManager; 
     private readonly SignInManager<UserDetails> _signInManager;
     private readonly IConfiguration _configuration;

     public APIController(UserManager<UserDetails> userManager, SignInManager<UserDetails> signInManager, IConfiguration configuration) {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._configuration = configuration;
     }
     
     [HttpPost("register")]
     public async Task<IActionResult> Register([FromBody] RegisterModel registerDetails) {
            
           if (!ModelState.IsValid){
               return BadRequest(new {message="There is an error on the user details. Please check again"});      
           }
            
           
           Console.WriteLine(registerDetails.Username);
           
           var user = new UserDetails {UserName=registerDetails.Username,
                                           Email=registerDetails.Email };
          
           var result = await _userManager.CreateAsync(user, registerDetails.Password);

           if (result.Succeeded) {
              return Ok(new {message="User has been created!"});
           }

           return BadRequest(new {message=result.Errors}); 
     }


     [HttpPost("login")] 
     public async Task<IActionResult> Login([FromBody] LoginModel loginDetails) {
        
        Console.WriteLine(loginDetails.Email);
        Console.WriteLine(loginDetails.Password);
        Console.WriteLine(loginDetails.RememberMe);
        if (!ModelState.IsValid) {
            return BadRequest(new { message = "There is an error on your login details. Please check again your information" });
        }

        var user = await _userManager.FindByEmailAsync(loginDetails.Email);

         if (user == null) {
             return BadRequest(new { message = "Email cannot be found. Please try again" }); }

         var password_verification = await _userManager.CheckPasswordAsync(user, loginDetails.Password);

         if (!password_verification) {
                return BadRequest(new { message = "Login failed. Please try again", status=false }); }


         await _signInManager.SignInAsync(user, isPersistent: true); // if true, the cookie will be a session cookie (cookie will be deleted when browser session is closed),  a persistent cookie is created that will last beyond the current session. 
         Console.WriteLine(User.Identity.IsAuthenticated);

         return Ok(new { message = "Login successful", status=true});

      }
      
      [HttpGet("check-authentication")]
      public IActionResult UserAuthentication() {

       Console.WriteLine(User.Identity.IsAuthenticated);
       if (User.Identity.IsAuthenticated) {
         return Ok(new{message="User is currently authenticated", status=true});
       }
       
       return Unauthorized(new {message="User is not authenticated", status=false});

     }

 



     [HttpPost("logout")]
     public async Task<IActionResult> Logout() {

       Console.WriteLine(User.Identity.IsAuthenticated); 
       await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
       HttpContext.Response.Cookies.Delete("ronniersCookie", new CookieOptions {Path="/", Domain="localhost"});
       HttpContext.Session.Clear();
       return Ok(new {message="User Successfully logout"}); 

     }

    
 



  
  



}
}