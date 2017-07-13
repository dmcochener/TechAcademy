<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengePhunWithStrings.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Reverse the name &quot;Deanna Cochener&quot;:<br />
    
        <asp:Label ID="resultLabelBT" runat="server"></asp:Label>
    
        <br />
        <br />
        Reverse sequence of names (Luke,Leia,Han,Chewbacca):<br />
        <asp:Label ID="resultLabelSW" runat="server"></asp:Label>
        <br />
        <br />
        Create ASCII Art from Names:<br />
        <asp:Label ID="resultLabelArt" runat="server"></asp:Label>
        <br />
        <br />
        Fix the following string--<br />
        NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.<br />
        <asp:Label ID="resultLabelFix" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
