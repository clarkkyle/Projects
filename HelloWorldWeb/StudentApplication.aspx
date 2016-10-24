<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentApplication.aspx.cs" Inherits="HelloWorldWeb.StudentApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Application</title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="litMessage" runat="server" Visible="false"></asp:Literal>
        <asp:Panel ID="pnlApplication" runat="Server" Visible="true">
        <table>
            <tr>
                <td>First Name:</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" Width="345px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="txtFirstName" Display="Dynamic" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" Width="345px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="txtLastName" Display="Dynamic" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Email Address:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="345px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ErrorMessage="Email address is a required field." ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>                    <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ErrorMessage="Email address must follow standard formatting rules (no spaces, etc)" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ControlToValidate="txtEmail" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Phone Number:</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" Width="345px"></asp:TextBox><asp:RegularExpressionValidator ID="revPhone" runat="server" ErrorMessage="Phone must be in format xxx-xxx-xxxx" ValidationExpression="^[2-9]\d{2}-\d{3}-\d{4}$" ControlToValidate="txtPhone" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Intended Major:</td>
                <td>
                    <asp:DropDownList ID="ddlIntendedMajor" runat="server">
                        <asp:ListItem>Math</asp:ListItem>
                        <asp:ListItem>English</asp:ListItem>
                        <asp:ListItem>Biology</asp:ListItem>
                        <asp:ListItem>History</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Resident Status:</td>
                <td>
                    <asp:RadioButtonList ID="rbtnlResidentStatus" runat="server">
                        <asp:ListItem Value="R">Resident</asp:ListItem>
                        <asp:ListItem Value="C">Commuter</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>Essay:</td>
                <td>
                    <asp:TextBox ID="txtEssay" runat="server" Height="200px" TextMode="MultiLine" Width="345px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="pnlSummary" runat="Server" Visible = "false">
            <table>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                   <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                   <tr>
                    <td>Email Address</td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                    <tr>
                    <td>Phone Number</td>
                    <td>
                        <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                    <tr>
                    <td>Intended Major</td>
                    <td>
                        <asp:Label ID="lblIntendedMajor" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                    <tr>
                    <td>Resident Status</td>
                    <td>
                        <asp:Label ID="lblResidentStatus" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                    <tr>
                    <td>Essay</td>
                    <td>
                        <asp:Label ID="lblEssay" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
