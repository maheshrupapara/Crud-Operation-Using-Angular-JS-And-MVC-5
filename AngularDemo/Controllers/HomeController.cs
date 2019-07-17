using AngularDemo.Models;
using System.Linq;
using System.Web.Mvc;

namespace AngularDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Name, string Phone)
        {
            int rate = 0;
            Context _context = new Context();
            Angular angular = new Angular(){
                Name=Name,
                Phone=Phone
            };
            _context.Angulars.Add(angular);
            rate=_context.SaveChanges();
            if(rate==1) return Json(new { success = true, JsonRequestBehavior.AllowGet });
            else return Json(new { success = false, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult GetData()
        {
            Context _context = new Context();
            return Json(  _context.Angulars.ToList(), JsonRequestBehavior.AllowGet );
        }

        [HttpPost]
        public ActionResult EditData(int Id)
        {
            Context _context = new Context();
            return Json(_context.Angulars.Where(x=>x.Id==Id).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Editsave(string Name, string Phone,int Id)
        {
            Context _context = new Context();
            Angular angular = _context.Angulars.FirstOrDefault(x => x.Id == Id);
            angular.Name = Name;
            angular.Phone = Phone;
            _context.Entry(angular).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return Json(new { success = true, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Context _context = new Context();
            Angular angular = _context.Angulars.FirstOrDefault(x => x.Id == Id);
            _context.Entry(angular).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
            return Json(new { success = true, JsonRequestBehavior.AllowGet });
        }
    }
}