using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Extjs4_0.Models
{
    public class Ext_Tree
    {
        public bool success { get; set; }
       public List<treeNode> children { get; set; }

    }
    public class treeNode {
        public int id { get; set; }
        public string name { get; set; }
        public bool leaf { get; set; }
        public bool loaded { get; set; }
    }
}