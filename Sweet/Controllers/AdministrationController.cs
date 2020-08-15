using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Sweet.Models;
using System;
using Sweet.ViewModels;

namespace Sweet.Controllers
{
  public class AdministrationController : Controller 
  {
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<ApplicationUser> userManager;

    public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
      this.userManager = userManager;
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
          return RedirectToAction("Index", "Administration");
        }

        foreach(IdentityError error in result.Errors)
        {
          ModelState.AddModelError("", error.Description);
        }
      }
      return View(model);
    }
    
    public IActionResult Index()
    {
      var roles = roleManager.Roles;
      return View(roles);
    }

    public async Task<IActionResult> Edit (string Id)
    {
      var result = await roleManager.FindByIdAsync(Id);
      var model = new EditRoleViewModel{ Id = Id, RoleName= result.Name, };

      foreach (var user in await userManager.Users.ToListAsync())
      {                    
          if (await userManager.IsInRoleAsync(user, result.Name))
          {
              model.Users.Add(user.UserName);
          }         
      }
      return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditRoleViewModel model)
    {
      var role = await roleManager.FindByIdAsync(model.Id);
      role.Name = model.RoleName;
      var result = await roleManager.UpdateAsync(role);

      if (result.Succeeded)
      {
          return RedirectToAction("ListOfRoles");
      }

      foreach (var error in result.Errors)
      {
          ModelState.AddModelError("", error.Description);
      }
      return View(model);
    }
  }
}