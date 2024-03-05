<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistrationPage.aspx.vb" Inherits="UtangQAppWebForm.RegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
    <!-- Bootstrap CSS -->
    <link href="~/Startbootstrap/css/sb-admin-2.min.css" rel="stylesheet" runat="server"/>
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
    <form id="formRegistration" runat="server">
        <div class="container" runat="server">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-body">
                            <h2 class="card-title text-center">Registration</h2>
                            <div class="mb-3">
                                <asp:Label ID="lblUsername" runat="server" Text="Username:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-1 mt-1">
                                <asp:Label ID="lblPasswordMatchError" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="lblFullName" runat="server" Text="Full Name:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3 text-center">
                                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-primary"></asp:Button>
                            </div>
                            <!-- Link to login page -->
                            <div class="text-center">
                                <p>Already have an account? <a href="LoginPage.aspx">Login here</a>.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
