using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sweet.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Sweet.Models;

namespace Sweet.Controllers
{
  public class AdministrationController : Controller 
  {
    private readonly RoleManager<IdentityRole> roleManager;
    public AdministrationController(RoleManager<IdentityRole> roleManager)
    {
      this.roleManager = roleManager;
    }

    public IActionResult CreateRole()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
    {
      if(ModelState.IsValid)
      {
        IdentityRole identityRole = new IdentityRole
        { 
          Name = model.RoleName
        };

        IdentityResult result = await roleManager.CreateAsync(identityRole);
        if(result.Succeeded)
        {
          return RedirectToAction("ListOfRoles", "Administration");
        }

        foreach(IdentityError error in result.Errors)
        {
          ModelState.AddModelError("", error.Description);
        }
      }

      return View(model);
    }
    
    public IActionResult ListOfRoles()
    {
      var roles = roleManager.Roles;
      return View(roles);
    }
  }
}