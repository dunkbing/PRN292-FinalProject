<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailArticle.aspx.cs" Inherits="Lab4.Lab4.DetailArticle" EnableEventValidation="false" %>

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
                            <a class="nav-link" href="#">Create post <span class="sr-only">(current)</span></a>
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
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="comment" CssClass="form-control mb-1" /><br />
                        <asp:Button runat="server" ID="submitcmt" Text="comment" CssClass="btn btn-primary" OnClick="submitcmt_Click" />
                        <asp:GridView ID="commentGrid" BorderStyle="None" CssClass="table-responsive" Width="100%" GridLines="None" runat="server" AutoGenerateColumns="False" ShowHeader="False">
                            <Columns>
                                <asp:BoundField DataField="ParentCommentID" Visible="false" HeaderText="ParentCommentID" />
                                <asp:TemplateField HeaderText="ParentMessage">
                                    <ItemTemplate>
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <table>
                                                        <tr>
                                                            <td style="width: 55px; vertical-align: top; padding-top: 10px">
                                                                <asp:Label ID="lblParentDate" runat="server" Text='<%#Bind("Time") %>'></asp:Label>
                                                                <br />
                                                                <asp:Label ID="Label4" Font-Bold="true" ForeColor="#cc0066" runat="server" Text='<%# Bind("username") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label1" runat="server" Text='<%# Bind("content") %>'></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="cmtIdLb" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                                                <a class="link" id='lnkReplyParent<%#Eval("id") %>' href="javascript:void(0)" onclick="showReply(<%#Eval("id") %>);return false;">Reply</a>&nbsp;
                                                                <a class="link" id="lnkCancle" href="javascript:void(0)" onclick="closeReply(<%#Eval("id") %>);return false;">Cancel</a>
                                                                <div id='divReply<%#Eval("id") %>' style="display: none; margin-top: 5px;">
                                                                    <asp:TextBox ID="replyTb" CssClass="input-group" runat="server" Width="400px" TextMode="MultiLine"></asp:TextBox>
                                                                    <br />
                                                                    <asp:Button ID="btnReply" runat="server" Text="Reply" CssClass="btn btn-primary" OnClick="btnReply_Click" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 100px; border-bottom: 1px solid #9fe3b1;">
                                                                <br />
                                                                <asp:GridView ID="replyGridview" BorderStyle="None" GridLines="None" runat="server" AutoGenerateColumns="False" DataSource='<%# Bind("replies") %>' ShowHeader="False">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="UserName">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblChildDate" runat="server" Text='<%#Bind("time") %>'></asp:Label>
                                                                                <br />
                                                                                <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="#ff0066" Text='<%#Bind("UserName") %>'></asp:Label>
                                                                                <br />
                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("content") %>'></asp:Label>
                                                                                <hr />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </form>
                    <br />
                </div>
                <div class="col-4">
                    <asp:Label runat="server" ID="vote" CssClass="text-info" />
                </div>
            </div>
        </div>
        <div class="col-1"></div>
    </div>
    <script src="../bootstrap-4.4.1-dist/js/bootstrap.min.js"></script>
    <script>
        function showReply(n) {
            document.getElementById("divReply" + n).style.display = "block";
        }
        function closeReply(n) {
            document.getElementById("divReply" + n).style.display = "none";
        }
    </script>
</body>
</html>
