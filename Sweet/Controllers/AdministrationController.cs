using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sweet.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Sweet.Controllers
{
  public class AdministrationController : Controller 
  {
    private readonly RoleManager<IdentityRole> roleManager;
    public AdministrationController(RoleManager<IdentityRole> roleManager)
    {
      this.roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult CreateRole()
    {
      return View();
    }

    
  }
}