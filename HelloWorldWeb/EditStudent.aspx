<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="HelloWorldWeb.EditStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
        <asp:GridView ID="gvStudents" runat="server" DataKeyNames="StudentID" AutoGenerateColumns="False" OnRowCommand="gvStudents_RowCommand">
        <EmptyDataTemplate>
            No Students to Display.
        </EmptyDataTemplate>
            <Columns>
                <asp:ButtonField HeaderText="Student ID" Text="Student ID" DataTextField="StudentID" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            </Columns>
        </asp:GridView>
        <asp:Panel ID="pnlEditForm" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
