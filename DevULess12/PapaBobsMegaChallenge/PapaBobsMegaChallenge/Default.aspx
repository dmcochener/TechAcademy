<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBobsMegaChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Papa Bob's Pizza</h2>
            <h4>Pizza to Code By</h4>
            <p>Size: <br />
                <asp:DropDownList ID="sizeDropDownList" runat="server" OnSelectedIndexChanged="Ordering" AutoPostBack="True">
                    <asp:ListItem Value ="">Select One...</asp:ListItem>
                    <asp:ListItem Value="Small">Small (12 inch - $12)</asp:ListItem>
                    <asp:ListItem Value="Medium">Medium (14 inch - $14)</asp:ListItem>
                    <asp:ListItem Value="Large">Large (16 inch - $16)</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>Crust: <br />
                <asp:DropDownList ID="crustDropDownList" runat="server" OnSelectedIndexChanged="Ordering" AutoPostBack="True" >
                    <asp:ListItem Value="">Select One...</asp:ListItem>
                    <asp:ListItem Value="Regular"></asp:ListItem>
                    <asp:ListItem Value="Thin"></asp:ListItem>
                    <asp:ListItem Value="Thick">Thick (+$2)</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:CheckBoxList ID="toppingsCheckBoxList" runat="server" OnSelectedIndexChanged="Ordering" ViewStateMode="Enabled" AutoPostBack="True">
                    <asp:ListItem Value="Sausage">Sausage</asp:ListItem>
                    <asp:ListItem Value="Pepperoni">Pepperoni</asp:ListItem>
                    <asp:ListItem Value="Onions">Onions</asp:ListItem>
                    <asp:ListItem Value="Peppers">Green Peppers</asp:ListItem>
                </asp:CheckBoxList>
            </p>
            <h3>Deliver To:</h3>
            <p>Name: <br />
                <asp:TextBox ID="nameTextBox" runat="server" ViewStateMode="Enabled"></asp:TextBox>
            </p>
            <p>Address: <br />
                <asp:TextBox ID="addressTextBox" runat="server" ViewStateMode="Enabled"></asp:TextBox>
            </p>
            <p>Zip: <br />
                <asp:TextBox ID="zipTextBox" runat="server" ViewStateMode="Enabled"></asp:TextBox>
            </p>
            <p>Phone: <br />
                <asp:TextBox ID="phoneTextBox" runat="server" ViewStateMode="Enabled"></asp:TextBox>
            </p>
            <h3>Payment:</h3>
            <p><asp:RadioButton ID="cashRadioButton" runat="server" GroupName="paymentRadioGroup" Text="Cash" ViewStateMode="Enabled" /><br />
            <asp:RadioButton ID="creditRadioButton" runat="server" GroupName="paymentRadioGroup" Text="Credit" ViewStateMode="Enabled" /></p>
            <p>
                <asp:Button ID="orderButton" runat="server" Text="Order!" OnClick="orderButton_Click" /><br />
                <asp:Label ID="errorLabel" runat="server"></asp:Label>
            </p>
            <h2>Total Cost:<br />
                <asp:Label ID="costLabel" runat="server"></asp:Label></h2>
            
        </div>
    </form>
</body>
</html>
