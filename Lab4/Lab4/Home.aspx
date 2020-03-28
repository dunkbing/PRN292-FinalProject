<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Lab4.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="../bootstrap-4.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="d-flex justify-content-center">
        <div class="col-1"></div>
        <div class="col-10 container-fluid">
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <a class="navbar-brand" href="Home.aspx">Home</a>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="#">Forums <span class="sr-only">(current)</span></a>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="#">Link</a>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="#">Disabled</a>
                        </li>
                    </ul>
                    <asp:HyperLink runat="server" ID="currentAccount" CssClass="nav-link" />
                    <asp:HyperLink runat="server" ID="register" CssClass="nav-link" />
                </div>
            </nav>
            <div class="d-flex">
                <div class="col-8">
                    <asp:Repeater runat="server" ID="postRepeater">
                        <ItemTemplate>
                            <div class="card mb-3">
                                <div class="row no-gutters">
                                    <div class="col-md-4">
                                        <img src="<%#DataBinder.Eval(Container.DataItem, "ImageUrl") %>" class="card-img" alt="..." />
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h5 class="card-title"><a href="DetailArticle.aspx?id=<%#DataBinder.Eval(Container.DataItem,"ID") %>"><%#DataBinder.Eval(Container.DataItem, "Title") %></a></h5>
                                            <p class="card-text">
                                                <small class="text-muted">By <%#DataBinder.Eval(Container.DataItem, "Username") %> on <%#DataBinder.Eval(Container.DataItem, "DateCreated") %>
                                                </small>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-4">
                    <h3 class="modal-title">Most popular games</h3>
                    <asp:Repeater runat="server" ID="mostPopularGames">
                        <ItemTemplate>
                            <div class="card mb-3">
                                <div class="row no-gutters">
                                    <div class="col-md-6">
                                        <img src="<%#DataBinder.Eval(Container.DataItem, "ImageUrl") %>" class="card-img" alt="...">
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card-body">
                                            <h5 class="card-title"><%# DataBinder.Eval(Container.DataItem, "Title") %></h5>
                                            <p class="card-text"><small class="text-muted">Score: <%#DataBinder.Eval(Container.DataItem, "Score") %></small></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
            <nav class="pagination"><%= pager(4) %></nav>
        </div>
        <div class="col-1"></div>
    </div>
    <script src="../bootstrap-4.4.1-dist/js/bootstrap.min.js"></script>
</body>
</html>
