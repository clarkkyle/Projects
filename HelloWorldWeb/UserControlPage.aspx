<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserControlPage.aspx.cs" Inherits="HelloWorldWeb.UserControlPage" %>

<%@ Register Src="~/UserControl.ascx" TagPrefix="uc1" TagName="UserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UserControl runat="server" id="UserControl" />
        <br />
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
