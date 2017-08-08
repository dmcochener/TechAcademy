using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace PapaBobsMegaChallenge
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {

            //Grid view was throwing a weird exception, and I couldn't figure out how to handle it

            Exception ex = Server.GetLastError();
            string errorMessage = ex.InnerException.Message;
            if (errorMessage == "The GridView 'ordersGridView' fired event RowEditing which wasn't handled.")
            {
                Server.ClearError();
                Response.Redirect("OrderManagement.aspx");
            }

            //Tried to do global error handling, but couldn't figure out how to 
            // get the error message up to the display level.

        }
    }
}