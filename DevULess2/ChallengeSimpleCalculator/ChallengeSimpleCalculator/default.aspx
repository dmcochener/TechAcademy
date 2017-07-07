<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ChallengeSimpleCalculator._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            clip: rect(2px, 2px, auto, auto);
        }
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Simple Calculator</h1>

            <br />
            <span class="auto-style1">First Value: </span>&nbsp;&nbsp;<asp:TextBox ID="firstTextBox" runat="server"></asp:TextBox>
            <br />
            <span class="auto-style1">Second Value: </span>&nbsp;<asp:TextBox ID="secondTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addButton" runat="server" style="position: relative; width: 25px; margin: 2px" Text="+" OnClick="addButton_Click" />
            <asp:Button ID="subButton" runat="server" style="position: relative; width: 25px; margin: 2px" Text="-" OnClick="subButton_Click" />
            <asp:Button ID="multButton" runat="server" style="position: relative; width: 25px; margin: 2px" Text="*" OnClick="multButton_Click" />
            <asp:Button ID="divButton" runat="server" style="position: relative; width: 25px; margin: 2px" Text="/" OnClick="divButton_Click" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server" BackColor="#66FFCC" Font-Bold="True" Font-Size="Larger"></asp:Label>

        </div>
    </form>
</body>
</html>
