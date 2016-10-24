<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="HelloWorldWeb.UserControl" %>
<asp:TextBox ID="txtNumber" runat="server" ReadOnly="true"></asp:TextBox>
<asp:Button ID="btnUp" runat="server" Text="UP" OnClick="btnUp_Click" />
<asp:Button ID="btnDown" runat="server" Text="DOWN" OnClick="btnDown_Click" />