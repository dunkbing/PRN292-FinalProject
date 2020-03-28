<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailArticle.aspx.cs" Inherits="Lab4.Lab4.DetailArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=article.Title %></title>
    <link href="../bootstrap-4.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="d-flex justify-content-center">
        <div class="col-1"></div>
        <div class="col-10">
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
                    <h3 class="card-title">
                        <asp:Label runat="server" ID="title" />
                    </h3>
                    <asp:Label runat="server" ID="user" CssClass="text-info" /><br />
                    <asp:Image runat="server" ID="image" CssClass="img-fluid" /><br />
                    <asp:Label runat="server" ID="content" /><br />
                    <form runat="server">
                        <asp:Button runat="server" ID="upvote" Text="upvote" CssClass="btn btn-primary mb-1" OnClick="upvote_Click" />
                        <asp:Button runat="server" ID="downvote" Text="downvote" CssClass="btn btn-primary mb-1" OnClick="downvote_Click" />
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="comment" CssClass="form-control mb-1" />
                        <asp:Button runat="server" ID="submitcmt" Text="comment" CssClass="btn btn-primary" OnClick="submitcmt_Click" />
                    </form>
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-2">
                                    <img src="https://image.ibb.co/jw55Ex/def_face.jpg" class="img img-rounded img-fluid" />
                                    <p class="text-secondary text-center">15 Minutes Ago</p>
                                </div>
                                <div class="col-md-10">
                                    <p>
                                        <a class="float-left" href="https://maniruzzaman-akash.blogspot.com/p/contact.html"><strong>Maniruzzaman Akash</strong></a>
                                        <span class="float-right"><i class="text-warning fa fa-star"></i></span>
                                        <span class="float-right"><i class="text-warning fa fa-star"></i></span>
                                        <span class="float-right"><i class="text-warning fa fa-star"></i></span>
                                        <span class="float-right"><i class="text-warning fa fa-star"></i></span>

                                    </p>
                                    <div class="clearfix"></div>
                                    <p>Lorem Ipsum is simply dummy text of the pr make  but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
                                    <p>
                                        <a class="float-right btn btn-outline-primary ml-2"><i class="fa fa-reply"></i>Reply</a>
                                        <a class="float-right btn text-white btn-danger"><i class="fa fa-heart"></i>Like</a>
                                    </p>
                                </div>
                            </div>
                            <div class="card card-inner">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <img src="https://image.ibb.co/jw55Ex/def_face.jpg" class="img img-rounded img-fluid" />
                                            <p class="text-secondary text-center">15 Minutes Ago</p>
                                        </div>
                                        <div class="col-md-10">
                                            <p><a href="https://maniruzzaman-akash.blogspot.com/p/contact.html"><strong>Maniruzzaman Akash</strong></a></p>
                                            <p>Lorem Ipsum is simply dummy text of the pr make  but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
                                            <p>
                                                <a class="float-right btn btn-outline-primary ml-2"><i class="fa fa-reply"></i>Reply</a>
                                                <a class="float-right btn text-white btn-danger"><i class="fa fa-heart"></i>Like</a>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-4">
                    <asp:Label runat="server" ID="vote" CssClass="text-info" />
                </div>
            </div>

        </div>
        <div class="col-1"></div>
    </div>
    <script src="../bootstrap-4.4.1-dist/js/bootstrap.min.js"></script>
</body>
</html>
