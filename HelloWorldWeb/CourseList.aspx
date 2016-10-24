<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="HelloWorldWeb.CourseList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label><br />
        <asp:Repeater ID="rptCourseList" runat="server">
            <HeaderTemplate>
                <table> 
                    <tr>
                        <th>Course Code</th>
                        <th>Course Name</th>
                        <th>Description</th>
                    </tr>   
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "CourseCode", "<strong>{0}</strong>") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "CourseName") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "CourseDescription", "<i>{0}</i>") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background : silver">
                    <td><%# DataBinder.Eval(Container.DataItem, "CourseCode", "<strong>{0}</strong>") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "CourseName") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "CourseDescription", "<i>{0}</i>") %></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <asp:Repeater ID="rptCourseList2" runat="server">
            <HeaderTemplate>
                <p>
                    Course Code - Name <br />
                    <span style="font-size: small">Description</span>
                </p>
            </HeaderTemplate>
            <ItemTemplate>
                <p>
                    <%# DataBinder.Eval(Container.DataItem, "CourseCode", "<strong>{0}</strong>") %> - <%# DataBinder.Eval(Container.DataItem, "CourseName") %> <br />
                    <span style="font-size: small"><%# DataBinder.Eval(Container.DataItem, "CourseDescription", "<i>{0}</i>") %></span>
                </p>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
            <FooterTemplate>
                <hr />
            </FooterTemplate>
        </asp:Repeater>

        <asp:DataList ID="dlCourses" runat="server">
            <HeaderTemplate>
                <h4>Courses</h4>
            </HeaderTemplate>
            <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "CourseCode", "<strong>{0}</strong>") %> - <%# DataBinder.Eval(Container.DataItem, "CourseName") %> <br />
                    <span style="font-size: small"><%# DataBinder.Eval(Container.DataItem, "CourseDescription", "<i>{0}</i>") %></span>
            </ItemTemplate>
            <FooterTemplate>
                <hr />
            </FooterTemplate>
        </asp:DataList>

    </div>
    </form>
</body>
</html>
