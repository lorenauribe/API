<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
        Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Login1.LabelStyle.ForeColor = System.Drawing.Color.Blue
        End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="Form1" runat="server">
            <asp:Login id="Login1" runat="server">
                <LabelStyle Font-Italic="True"></LabelStyle>
            </asp:Login>

        </form>
    </body>
</html>
<!-- </Snippet1> -->