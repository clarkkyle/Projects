<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBTest.aspx.cs" Inherits="HelloWorldWeb.DBTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div> 
        Student ID: <asp:TextBox ID="txtIDLookup" runat="server"></asp:TextBox> <br />
        Student Name: <asp:Label ID="lblDisplayData" runat="server"></asp:Label><br /> 
        <asp:Button ID="btnLookup" runat="server" Text="Lookup" OnClick="btnLookup_Click" />
    </div>
    </form>
</body>
</html>
