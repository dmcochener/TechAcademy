using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapaBobsMegaChallenge.Persistence;

namespace PapaBobsMegaChallenge
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }


        protected void ordersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ordersGridView.Rows[index];
                var value = row.Cells[1].Text.ToString();
                var orderID = Guid.Parse(value);

                OrderProcess.CompleteOrder(orderID);
                refreshGrid();

        }

        private void refreshGrid ()
        {
            PizzaOrdersEntities db = new PizzaOrdersEntities();
            var orders = db.Orders.Where(p => p.Complete == false);

            ordersGridView.DataSource = orders.ToList();
            ordersGridView.DataBind();
        }

    }
}
