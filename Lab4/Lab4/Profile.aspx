<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Lab4.Lab4.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=username %></title>
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
                            <a class="nav-link" href="#">Games<span class="sr-only">(current)</span></a>
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
            <div class="d-flex mt-3">
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
                    <img src="<%=a.Avatar %>" alt="" class="img-rounded img-fluid" />
                    <div class="col-md-6 details">
                        <blockquote>
                            <h5><%=a.Username %></h5>
                            <small><cite title="Source Title">Chicago, United States of America  <i class="icon-map-marker"></i></cite></small>
                        </blockquote>
                        <p>
                            <%=a.Email %>
                            <br />
                            www.bootsnipp.com
                            <br />
                            June 18, 1990
                        </p>
                    </div>
                </div>
            </div>
            <nav class="pagination"><%= pager(4) %></nav>
        </div>
        <div class="col-1"></div>
        <script src="../bootstrap-4.4.1-dist/js/bootstrap.min.js"></script>
    </div>
</body>
</html>
