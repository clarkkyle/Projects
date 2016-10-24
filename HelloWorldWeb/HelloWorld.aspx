<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="HelloWorldWeb.HelloWorld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  
        <asp:Label ID="lblDisplayText" runat="server"></asp:Label> <br />
        <asp:TextBox ID="txtAddText" runat="server"></asp:TextBox> <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

    </div>
    </form>
</body>
</html>
