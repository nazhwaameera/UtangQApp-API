<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginPage.aspx.vb" Inherits="UtangQAppWebForm.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>
    <link href="~/Startbootstrap/css/sb-admin-2.min.css" rel="stylesheet" runat="server" />
    <style>
        /* Custom styles */
        .card {
            margin-top: 50px;
            max-width: 400px;
            margin-left: auto;
            margin-right: auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
        }
    </style>
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="container" runat="server">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-body">
                            <h2 class="card-title text-center">Login</h2>
                            <div class="mb-2">
                                <asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUsername">Username:</asp:Label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required" Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Required="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
                            </div>
                            <div class="mb-3">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
                            </div>
                            <!-- Link to login page -->
                            <div class="text-center">
                                <p>Don't have an account? <a href="RegistrationPage.aspx">Sign up here</a>.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
