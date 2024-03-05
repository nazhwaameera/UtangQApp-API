<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ProfilePage.aspx.vb" Inherits="UtangQAppWebForm.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">User Profile</h5>
                        <br />
                        <asp:Label ID="ltMessage" runat="server" Visible="false"></asp:Label>
                        <asp:GridView ID="gvUserProfile" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Username" HeaderText="Username" />
                                <asp:BoundField DataField="UserEmail" HeaderText="Email" />
                                <asp:BoundField DataField="UserFullName" HeaderText="Full Name" />
                                <asp:BoundField DataField="UserPhoneNumber" HeaderText="Phone Number" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" CssClass="btn btn-primary mt-2" OnClick="btnEditProfile_Click" />
                        <asp:Button ID="btnDeleteAccount" runat="server" Text="Delete Account" CssClass="btn btn-danger mt-2" OnClick="btnDeleteAccount_Click" />
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-primary mt-2" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Edit -->
    <div class="modal" id="myModalEdit">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Edit Profile</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtUsername">Username :</label>
                        <asp:TextBox ID="txtUsernameEdit" runat="server" CssClass="form-control" placeholder="Enter Username" />
                    </div>
                    <div class="form-group">
                        <label for="txtUserEmail">Emails :</label>
                        <asp:TextBox ID="txtUserEmailEdit" runat="server" CssClass="form-control" placeholder="Enter Email" />
                    </div>
                    <div class="form-group">
                        <label for="txtUserFullName">Full Name :</label>
                        <asp:TextBox ID="txtUserFullNameEdit" runat="server" CssClass="form-control" placeholder="Enter Full Name" />
                    </div>
                    <div class="form-group">
                        <label for="txtUserPhoneNumber">Phone Number :</label>
                        <asp:TextBox ID="txtUserPhoneNumberEdit" runat="server" CssClass="form-control" placeholder="Enter Phone Number" />
                    </div>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Edit" ID="btnEdit" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnEdit_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Delete -->
    <div class="modal" id="myModalDelete">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Delete Account</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:Label ID="lblConfirmationMessage" runat="server" Text=""></asp:Label>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Delete Account" ID="btnDelete" CssClass="btn btn-danger btn-sm" runat="server" OnClick="btnDelete_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
