<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lab4.Lab4.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../bootstrap-4.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="d-flex justify-content-center">
        <div class="col-1"></div>
        <div class="col-10">
            <!-- #include file="Navbar.aspx" -->
            <form runat="server">
                <div class="form-group col-md-4">
                    username <asp:TextBox ID="username" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="username" ErrorMessage="enter username" /><br />
                    password <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="password" ErrorMessage="enter password"/><br />
                    <asp:Label runat="server" ID="error" CssClass="text-danger" /><br />
                    <asp:Button ID="login" runat="server" Text="Login" CssClass="btn-primary btn" OnClick="login_Click" />
                </div>
            </form>
        </div>
        <div class="col-1"></div>
    </div>
    <script src="../bootstrap-4.4.1-dist/js/bootstrap.min.js"></script>
</body>
</html>
