<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentSearch.aspx.cs" Inherits="HelloWorldWeb.StudentSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
            <asp:Label ID="lblInstructions" runat="server" Text="Enter Part of the student's name:"></asp:Label>
            <asp:TextBox ID="txtSearchName" runat="server" Width="279px" AutoPostBack="True" OnTextChanged="txtSearchName_TextChanged"></asp:TextBox> <br />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Repeater ID="rptSearchResults" runat="server">
                <HeaderTemplate>
                    <h4>Results</h4>
                </HeaderTemplate>
                <ItemTemplate>
                    <p>
                        <%# DataBinder.Eval(Container.DataItem, "FirstName") %> <%# DataBinder.Eval(Container.DataItem, "LastName") %><br />
                        <%# DataBinder.Eval(Container.DataItem, "Email") %> <br />
                        <%# DataBinder.Eval(Container.DataItem, "Phone") %>
                    </p>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <p style="background-color: silver">
                        <%# DataBinder.Eval(Container.DataItem, "FirstName") %> <%# DataBinder.Eval(Container.DataItem, "LastName") %><br />
                        <%# DataBinder.Eval(Container.DataItem, "Email") %> <br />
                        <%# DataBinder.Eval(Container.DataItem, "Phone") %>
                    </p>
                </AlternatingItemTemplate>
            </asp:Repeater>
           </ContentTemplate>
         </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
