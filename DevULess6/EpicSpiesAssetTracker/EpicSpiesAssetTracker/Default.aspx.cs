using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] assets = new string[0];
                int[] elections = new int[0];
                double[] subterfuge = new double[0];
                
                ViewState.Add("Assets", assets);
                ViewState.Add("Elections", elections);
                ViewState.Add("Subterfuge", subterfuge);
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string[] assets = (string[])ViewState["Assets"];
            int[] elections = (int[])ViewState["Elections"];
            double[] subterfuge = (double[])ViewState["Subterfuge"];

            Array.Resize(ref assets, assets.Length + 1);
            Array.Resize(ref elections, elections.Length + 1);
            Array.Resize(ref subterfuge, subterfuge.Length + 1);

            int newestAdd = assets.GetUpperBound(0);

            assets[newestAdd] = assetNameTB.Text;
            elections[newestAdd] = int.Parse(electionsTB.Text);
            subterfuge[newestAdd] = double.Parse(subterfugeTB.Text);

            ViewState["Assets"] = assets;
            ViewState["Elections"] = elections;
            ViewState["Subterfuge"] = subterfuge;

            resultLabel.Text = String.Format("Total Elections Rigged: {0} </br>" +
                "Average Acts of Subterfuge per Asset: {1:N2} </br>" +
                "(Last Asset you Added: {2})", elections.Sum(), subterfuge.Average(), assets[newestAdd]);
        }
    }
}