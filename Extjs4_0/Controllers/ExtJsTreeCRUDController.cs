using Extjs4_0.Models;
using ExtjsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Extjs4_0.Controllers
{
    public class ExtJsTreeCRUDController : Controller
    {
        // GET: ExtJsTreeCRUD
        public ActionResult Index()
        {

            return View();
        }
        NorthwindEntities db = new NorthwindEntities();

        public JsonResult read()
        {
            string node = Request["node"] ?? "";
            if (node == "NaN" || node == "")
            {
                node = "-1";
            }
            int count = int.Parse(node);
            var q = db.Ext_Tree.Where(u => u.parentId == count).ToList();
            List<ExtjsModel.Ext_Tree> ja = new List<ExtjsModel.Ext_Tree>();
            foreach (var c in q)
            {
                ja.Add(c);
            }
            return Json(ja, JsonRequestBehavior.AllowGet);

        }
        public JsonResult create( ) {
            string val=Server.HtmlDecode(Request["data"]);
            var obj=JsonConvert.DeserializeObject<List<ExtjsModel.Ext_Tree>>(val)[0];
            db.Ext_Tree.Add(obj);
            db.SaveChanges();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public void destroy() {
            string val = Server.HtmlDecode(Request["data"]);
            var obj = JsonConvert.DeserializeObject<List<ExtjsModel.Ext_Tree>>(val)[0];
            var node=db.Ext_Tree.Where(u => u.id == obj.id).FirstOrDefault();
            if (node != null)
            {
                db.Entry<ExtjsModel.Ext_Tree>(node).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void update() { }

    }
}