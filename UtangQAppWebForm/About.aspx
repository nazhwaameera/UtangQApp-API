<%@ Page Title="About Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="UtangQAppWebForm.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <div class="card custom-card">
            <div class="card-body">
                <h5 class="card-title">Get User by ID</h5>
                <asp:GridView ID="UserGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="UserID" HeaderText="User ID" />
                        <asp:BoundField DataField="Username" HeaderText="Username" />
                        <asp:BoundField DataField="UserEmail" HeaderText="Email" />
                        <asp:BoundField DataField="UserFullName" HeaderText="Full Name" />
                        <asp:BoundField DataField="UserPhoneNumber" HeaderText="Phone Number" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="card custom-card">
            <div class="card-body">
                <h5 class="card-title">Read User's Bills</h5>
                <asp:GridView ID="UserBillGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="BillID" HeaderText="Bill ID" />
                        <asp:BoundField DataField="UserID" HeaderText="User ID" />
                        <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="BillDate" HeaderText="Bill Date" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="BillDescription" HeaderText="Bill Description" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMessage" runat="server" Visible="true"></asp:Label>
            </div>
        </div>
        <div class="card custom-card">
            <div class="card-body">
                <h5 class="card-title">Read All Bills</h5>
                <asp:GridView ID="AllBillsGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="BillID" HeaderText="Bill ID" />
                        <asp:BoundField DataField="UserID" HeaderText="User ID" />
                        <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="BillDate" HeaderText="Bill Date" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="BillDescription" HeaderText="Bill Description" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMessageAllBills" runat="server" Visible="true"></asp:Label>
            </div>
        </div>
        <div class="card custom-card">
            <div class="card-body">
                <h5 class="card-title">Read All Wallets</h5>
                <asp:GridView ID="AllWalletsGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="WalletID" HeaderText="Wallet ID" />
                        <asp:BoundField DataField="UserID" HeaderText="User ID" />
                        <asp:BoundField DataField="WalletBalance" HeaderText="Wallet Balance"/>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMessageAllWallets" runat="server" Visible="true"></asp:Label>
            </div>
        </div>

    </main>
</asp:Content>

