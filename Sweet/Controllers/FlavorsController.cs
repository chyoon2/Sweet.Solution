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
  public class FlavorsController : Controller
  {
    private readonly SweetContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public FlavorsController(UserManager<ApplicationUser> userManager, SweetContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      var thisFlavors = _db.Flavors.ToList();
      return View(thisFlavors);
    }

     [Authorize]
    public ActionResult Edit(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      return View(thisFlavor);
    } 

    [HttpPost]
    public ActionResult Edit(Flavor flavor, int TreatId)
    {
      if(TreatId !=0)  
      {
        _db.FlavorTreat.Add(new FlavorTreat() {TreatId = TreatId, FlavorId = flavor.FlavorId});
      } 
        _db.Entry(flavor).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult Create()
    {
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor, int TreatId)
    {
    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var currentUser = await _userManager.FindByIdAsync(userId);
    flavor.User = currentUser;
    _db.Flavors.Add(flavor);
    if (TreatId != 0)
    {
        _db.FlavorTreat.Add(new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId });
    }
    _db.SaveChanges();
    return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors
        .Include(flavor => flavor.Treats)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }
    
    [Authorize]
    public ActionResult AddTreat(int id)
    {
    var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
    ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
    return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int TreatId)
    {
      if (TreatId != 0)
        {
        _db.FlavorTreat.Add(new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId });
        }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteTreat(int joinId)
    {
      var joinEntry = _db.FlavorTreat.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreat.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}