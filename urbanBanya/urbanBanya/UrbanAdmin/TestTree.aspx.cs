using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestTree : System.Web.UI.Page
{
  
    string[] c = { "item1", "item1", "item1", "item1", "item1" };
    string[] s = { "S1", "S1", "S1", "S1", "S1" };
    int ch = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         for (int loop = 0; loop < 5; loop++)
            {
                TreeNode root = new TreeNode();
                root.Text = c[loop];
               ch=0;
                while (ch<s.Length)
                {
                    TreeNode child = new TreeNode();
                    child.Text = s[ch];
                    root.ChildNodes.Add(child);
                    ch++;
                }
                
                TreeView1.Nodes.Add(root);
            }
         TreeView1.CollapseAll();
    }
    }
}