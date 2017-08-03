<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="PapaBobsMegaChallenge.OrderManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderId" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
                <Columns>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PizzaOrdersConnectionString1 %>" DeleteCommand="DELETE FROM [Order] WHERE [OrderId] = @OrderId" InsertCommand="INSERT INTO [Order] ([OrderId], [Size], [Crust], [First Topping], [Second Topping], [Third Topping], [Fourth Topping], [Name], [Address], [Zip], [Phone], [Payment], [Complete]) VALUES (@OrderId, @Size, @Crust, @First_Topping, @Second_Topping, @Third_Topping, @Fourth_Topping, @Name, @Address, @Zip, @Phone, @Payment, @Complete)" ProviderName="<%$ ConnectionStrings:PizzaOrdersConnectionString1.ProviderName %>" SelectCommand="SELECT [OrderId], [Size], [Crust], [First Topping] AS First_Topping, [Second Topping] AS Second_Topping, [Third Topping] AS Third_Topping, [Fourth Topping] AS Fourth_Topping, [Name], [Address], [Zip], [Phone], [Payment], [Complete] FROM [Order]" UpdateCommand="UPDATE [Order] SET [Size] = @Size, [Crust] = @Crust, [First Topping] = @First_Topping, [Second Topping] = @Second_Topping, [Third Topping] = @Third_Topping, [Fourth Topping] = @Fourth_Topping, [Name] = @Name, [Address] = @Address, [Zip] = @Zip, [Phone] = @Phone, [Payment] = @Payment, [Complete] = @Complete WHERE [OrderId] = @OrderId">
                <DeleteParameters>
                    <asp:Parameter Name="OrderId" Type="Object" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="OrderId" Type="Object" />
                    <asp:Parameter Name="Size" Type="String" />
                    <asp:Parameter Name="Crust" Type="String" />
                    <asp:Parameter Name="First_Topping" Type="String" />
                    <asp:Parameter Name="Second_Topping" Type="String" />
                    <asp:Parameter Name="Third_Topping" Type="String" />
                    <asp:Parameter Name="Fourth_Topping" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="Zip" Type="Int32" />
                    <asp:Parameter Name="Phone" Type="String" />
                    <asp:Parameter Name="Payment" Type="String" />
                    <asp:Parameter Name="Complete" Type="Boolean" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Size" Type="String" />
                    <asp:Parameter Name="Crust" Type="String" />
                    <asp:Parameter Name="First_Topping" Type="String" />
                    <asp:Parameter Name="Second_Topping" Type="String" />
                    <asp:Parameter Name="Third_Topping" Type="String" />
                    <asp:Parameter Name="Fourth_Topping" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="Zip" Type="Int32" />
                    <asp:Parameter Name="Phone" Type="String" />
                    <asp:Parameter Name="Payment" Type="String" />
                    <asp:Parameter Name="Complete" Type="Boolean" />
                    <asp:Parameter Name="OrderId" Type="Object" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
