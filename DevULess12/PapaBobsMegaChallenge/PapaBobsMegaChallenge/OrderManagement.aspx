<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="PapaBobsMegaChallenge.OrderManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="ordersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderId" OnRowCommand="ordersGridView_RowCommand">
                <Columns>
                    <asp:ButtonField CommandName="Edit" HeaderText="Complete" ShowHeader="True" Text="Complete" />
                    <asp:BoundField DataField="OrderId" HeaderText="OrderId" ReadOnly="True" SortExpression="OrderId" />
                    <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
                    <asp:BoundField DataField="Crust" HeaderText="Crust" SortExpression="Crust" />
                    <asp:BoundField DataField="First_Topping" HeaderText="First_Topping" SortExpression="First_Topping" />
                    <asp:BoundField DataField="Second_Topping" HeaderText="Second_Topping" SortExpression="Second_Topping" />
                    <asp:BoundField DataField="Third_Topping" HeaderText="Third_Topping" SortExpression="Third_Topping" />
                    <asp:BoundField DataField="Fourth_Topping" HeaderText="Fourth_Topping" SortExpression="Fourth_Topping" />
                    <asp:CheckBoxField DataField="Complete" HeaderText="Complete" SortExpression="Complete" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
