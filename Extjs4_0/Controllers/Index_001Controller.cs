using COMM;
using Extjs4_0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExtjsModel;
namespace Extjs4_0.Controllers
{
    public class Index_001Controller : Controller
    {
        // GET: Index_001
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateExtClass()
        {
            return View();
        }
        public string ReturnString()
        {
            return "Hello";
        }
        public string up(string u, string p)
        {
            return "Yes";
        }
        [HttpPost]
        public JsonResult getUsers()
        {
            int start = int.Parse(Request["start"].ToString());
            int limit = int.Parse(Request["limit"].ToString());
            List<Users> list = new List<Users>();
            for (int i = 0; i < 100; i++)
            {
                Users us = new Users();
                us.id = i;
                us.name = (i * 11).ToString();
                us.age = i * 10;
                list.Add(us);
            }
            var listArray = list.Skip(start).Take(limit).ToList();
            return Json(new { count = list.Count, data = listArray });
        }
        [HttpPost]
        public JsonResult getUsers001()
        {
            int start = int.Parse(Request["start"].ToString());
            int limit = int.Parse(Request["limit"].ToString());
            List<Users> list = new List<Users>();
            for (int i = 0; i < 100; i++)
            {
                Users us = new Users();
                us.id = i;
                us.name = (i * 11).ToString();
                us.age = i * 10;
                list.Add(us);
            }

            return Json(new { count = list.Count, data = list });
        }
        [HttpPost]
        public JsonResult getUsers002()
        {
            int brandID = int.Parse(Request["brandID"].ToString());
            int start = int.Parse(Request["start"].ToString());
            int limit = int.Parse(Request["limit"].ToString());
            List<Users> list = new List<Users>();
            for (int i = 0; i < brandID; i++)
            {
                Users us = new Users();
                us.id = i;
                us.name = ((char)(i * 11)).ToString();
                us.age = i * 10;
                list.Add(us);
            }
            return Json(new { count = list.Count, data = list });
        }
        [HttpPost]
        public JsonResult getGridPanel()
        {
            int page = int.Parse(Request["page"].ToString());
            int start = int.Parse(Request["start"].ToString());
            int limit = int.Parse(Request["limit"].ToString());
            List<Users> list = new List<Users>();
            for (int i = 0; i < 100; i++)
            {
                Users us = new Users();
                us.id = i;
                us.name = (i * 11).ToString();
                us.age = i * 10;
                list.Add(us);
            }

            return Json(new { count = list.Count, data = list });
        }
        [HttpPost]
        public JsonResult getServerGrid()
        {
            string theName = Request["theName"].ToString();
            int start = int.Parse(Request["start"].ToString());
            int limit = int.Parse(Request["limit"].ToString());
            List<Model_10_5> list = new List<Model_10_5>();
            Model_10_5 theModel = new Model_10_5();
            theModel.id = 0;
            theModel.title = "ABC";
            theModel.artist = "abc";
            theModel.rate = 100;
            list.Add(theModel);
            for (int i = 0; i < 20; i++)
            {
                Model_10_5 theModel_10_5 = new Model_10_5();
                theModel_10_5.id = i + 1;
                theModel_10_5.title = RadomChar.GetRandomString(3, 5, true);
                theModel_10_5.artist = RadomChar.GetRandomString(3, 10, true);
                theModel_10_5.rate = RadomChar.GetRandomint(1, 100);
                theModel_10_5.price = RadomChar.GetRandomint(1, 100) * 0.25;
                theModel_10_5.date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                list.Add(theModel_10_5);
            }
            if (!String.IsNullOrWhiteSpace(theName))
            {
                var svb = (from a in list where a.title == theName select a).ToList();
                if (svb.Count > 0)
                {
                    list = svb;
                    return Json(new { count = list.Count, data = list });
                }

            }
            return Json(new { count = list.Count, data = list.Skip(start).Take(limit).ToList() });
        }
        public string GetDataObj()
        {

            return "OK";
        }
        public string GetDataObjJson()
        {
            string str = " [{ id: 1, name: 'Aitch', gender: 'M', dob: '1980/02/28', epaper: true },{ id: 2, name: 'David', gender: 'M', dob: '1981/03/01', epaper: true },{ id: 3, name: 'Johny', gender: 'F', dob: '1982/04/02', epaper: false },{ id: 4, name: 'Chris', gender: 'M', dob: '1983/05/03', epaper: true }, {id: 5, name: 'Kelly', gender: 'F', dob: '1984/06/04', epaper: false }]";
            var csk = Request["op"].ToString();
            switch (csk)
            {
                case "create": break;
                case "read": break;
                case "update": break;
                case "destroy": break;
                default: break;
            }
            return str;
        }
        public JsonResult retuTreeJson()
        {
            Extjs4_0.Models.Ext_Tree extTree = new Extjs4_0.Models.Ext_Tree();
            List<treeNode> listNode = new List<treeNode>();
            int nodeID = -99;
            if (Request["node"] != null && int.TryParse(Request["node"].ToString(), out nodeID))
            {
                for (int i = 0; i < nodeID; i++)
                {
                    treeNode node = new treeNode();
                    node.id = (i+1)*20;
                    node.leaf = i % 2 == 0 ? true : false;
                    node.loaded = true;
                    node.name = Guid.NewGuid().ToString();
                    listNode.Add(node);
                }
            }
            else
            {

              
                for (int i = 0; i < 10; i++)
                {
                    treeNode node = new treeNode();
                    node.id = i + 1;
                    node.leaf = i % 2 == 0 ? true : false;
                    node.name = Guid.NewGuid().ToString();
                    node.loaded = true;
                    listNode.Add(node);
                }
            }
            extTree.children = listNode;
            extTree.success = true;
            return Json(extTree, JsonRequestBehavior.AllowGet);
        }
    }
    //Index_001
}