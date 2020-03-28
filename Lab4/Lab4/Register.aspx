<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Lab4.Lab4.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="../bootstrap-4.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="d-flex justify-content-center">
        <div class="col-1"></div>
        <div class="col-10">
            <!-- #include file="Navbar.aspx" -->
            <form runat="server">
                <div class="form-group col-md-4">
                    email <asp:TextBox ID="email" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ControlToValidate="email" runat="server" ErrorMessage="this field can't be empty" /><br />
                    username <asp:TextBox ID="username" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ControlToValidate="username" runat="server" ErrorMessage="this field can't be empty" /><br />
                    password <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator ControlToValidate="password" runat="server" ErrorMessage="this field can't be empty" /><br />
                    confirm password <asp:TextBox ID="confirm" runat="server" TextMode="Password" CssClass="form-control" />
                    <asp:CompareValidator ControlToValidate="confirm" ControlToCompare="password" runat="server" ErrorMessage="password not match" /><br />
                    <asp:Button ID="register" runat="server" Text="Register" CssClass="btn-primary btn" />
                </div>
            </form>
            <asp:Label runat="server" ID="notify" />
        </div>
        <div class="col-1"></div>
    </div>
    <script src="../bootstrap-4.4.1-dist/js/bootstrap.min.js"></script>
</body>
</html>
