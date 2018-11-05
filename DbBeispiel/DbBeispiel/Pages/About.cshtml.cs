using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DbBeispiel.Pages
{
  public class AboutModel : PageModel
  {
    private readonly UserManager<IdentityUser> userManager;

    public AboutModel(UserManager<IdentityUser> userManager)
    {
      this.userManager = userManager;
    }
    public string Message { get; set; }

    public async Task OnGet()
    {
      Message = "Your application description page.";
      
      //var u = userManager.Users.First();
      var u = await userManager.FindByEmailAsync("a@b.de");
      await userManager.AddClaimAsync(u, new System.Security.Claims.Claim("hallo", "Welt"));

    }
  }
}
