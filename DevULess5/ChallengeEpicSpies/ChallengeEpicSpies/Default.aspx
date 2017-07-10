<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeEpicSpies.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" Height="190px" ImageUrl="~/epic-spies-logo.jpg" />
            <br />
            <br />
            <h1>Spy New Assignment Form</h1>
            <br />
            <br />
            Spy Code Name:
            <asp:TextBox ID="spyNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            New Assignment Name:
            <asp:TextBox ID="assignNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            End Date of Previous Assignment:<asp:Calendar ID="previousCalendar" runat="server"></asp:Calendar>
            <br />
            Start Date of New Assignment:<asp:Calendar ID="newCalendar" runat="server"></asp:Calendar>
            <br />
            Projected End Date of New Assignment:
            <asp:Calendar ID="endCalendar" runat="server"></asp:Calendar>
            <br />
            <asp:Button ID="assignButton" runat="server" OnClick="assignButton_Click" Text="Assign Spy" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
