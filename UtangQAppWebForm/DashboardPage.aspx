<%@ Page Title="Dashboard Page" EnableSessionState="True" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DashboardPage.aspx.vb" Inherits="UtangQAppWebForm.DashboardPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <!-- Wallet Balance Card -->
            <div class="col-lg-6">
                <div class="card h-100 shadow-sm">
                    <div class="card-header">
                        <div class="d-flex justify-content-between align-items-center">
                            <h2>Wallet Balance</h2>
                            <asp:Label ID="ltMessageWallet" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="card-body">
                        <!-- Display wallet balance -->
                        <div class="row justify-content-center">
                            <div class="col text-center">
                                <asp:Label ID="lblWalletBalance" runat="server" Text="Total Amount: $XXX" Visible="false"></asp:Label>
                            </div>
                        </div>

                        <!-- Button to create a wallet if not exists -->
                        <div class="row justify-content-center mt-3">
                            <div class="col text-center">
                                <asp:Button ID="btnAddWallet" runat="server" Text="Create Wallet" CssClass="btn btn-primary" Visible="false" OnClick="btnAddWallet_Click" />
                            </div>
                        </div>

                        <!-- Second row for Add Balance and View Wallet Transactions -->
                        <div class="row justify-content-between mt-3">
                            <div class="col-6">
                                <!-- Button to add balance -->
                                <asp:Button ID="btnAddWalletBalance" runat="server" Text="Add Balance" CssClass="btn btn-primary my-1 w-100" Visible="false" OnClick="btnAddWalletBalance_Click" />
                            </div>
                            <div class="col-6">
                                <!-- Hyperlink to view wallet transactions -->
                                <asp:HyperLink ID="lnkViewTransactions" runat="server" Text="View Wallet Transactions" NavigateUrl="#" CssClass="btn my-1 w-100" Visible="false" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <!-- Bills to be Paid Card -->
            <div class="col-lg-6">
                <div class="card h-100 shadow-sm">
                    <div class="card-header">
                        <h2>Bills to be Paid</h2>
                    </div>
                    <div class="card-body">
                        <!-- Display the amount of bills to be paid -->
                        <div class="row justify-content-center">
                            <div class="col text-center">
                                <asp:Label ID="lblBillsToBePaidTotal" runat="server" Text="Total Amount: $XXX" Visible="True"></asp:Label>
                            </div>
                        </div>
                        <br />
                        <!-- Second row for Create Payment and View Payment Details -->
                        <div class="row justify-content-between mt-3">
                            <div class="col text-center">
                                <!-- Button to create payment -->
                                <asp:Button ID="btnCreatePayment" runat="server" Text="Add Balance" CssClass="btn btn-primary my-1 w-75" Visible="False" OnClick="btnCreatePayment_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-3">
            <!-- Bills Created Card -->
            <div class="col-lg-12">
                <div class="card shadow-sm">
                    <div class="card-header d-flex justify-content-between align-items-center">
                        <h2>Bills Created</h2>
                        <asp:Button ID="btnAddBill" runat="server" Text="Add Bill" CssClass="btn btn-primary mt-2" OnClick="btnAddBill_Click" />
                    </div>
                    <div class="card-body">
                        <!-- First Row: Total amount of bills created -->
                        <div class="row mb-3">
                            <div class="col">
                                <h4>Total Amount of Bills Created</h4>
                                <asp:Label ID="lblTotalBillsCreated" runat="server" Text="Total Amount: $XXX"></asp:Label>
                            </div>
                        </div>

                        <!-- Second Row: Bills paid and Bills pending -->
                        <div class="row mb-3">
                            <div class="col">
                                <h5>Bills Paid</h5>
                                <asp:Label ID="lblTotalBillsPaid" runat="server" Text="Total Amount: $XXX"></asp:Label>
                            </div>
                            <div class="col">
                                <h5>Bills Pending</h5>
                                <asp:Label ID="lblTotalBillsPending" runat="server" Text="Total Amount: $XXX"></asp:Label>
                            </div>
                            <div class="col">
                                <h5>Bills Unassigned</h5>
                                <asp:Label ID="lblTotalBillsUnassigned" runat="server" Text="Total Amount: $XXX"></asp:Label>
                            </div>
                        </div>

                        <!-- Third Row: ListView for bill details -->
                        <div class="row">
                            <div class="col">
                                <h5>Bill Details</h5>
                                <asp:Label ID="ltMessageBill" runat="server" Visible="false"></asp:Label>
                                <table class="table table-hover">
                                    <asp:ListView ID="lvBillsCreated" DataKeyNames="BillID" OnItemDataBound="lvBillsCreated_ItemDataBound" OnSelectedIndexChanging="lvBillsCreated_SelectedIndexChanging"
                                        OnSelectedIndexChanged="lvBillsCreated_SelectedIndexChanged" OnItemCommand="lvBillsCreated_ItemCommand" runat="server">
                                        <LayoutTemplate>
                                            <thead>
                                                <tr>
                                                    <th>Num.</th>
                                                    <th>Amount</th>
                                                    <th>Owner Contribution</th>
                                                    <th>Date</th>
                                                    <th>Description</th>
                                                    <th>&nbsp;</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr id="itemPlaceholder" runat="server"></tr>
                                            </tbody>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Container.DisplayIndex + 1 %></td>
                                                <td><%# String.Format("{0:0.00}", Eval("BillAmount")) %></td>
                                                <td><%# String.Format("{0:0.00}", Eval("OwnerContribution")) %></td>
                                                <td><%# Eval("BillDate") %></td>
                                                <td><%# Eval("BillDescription") %></td>
                                                <td>
                                                    <asp:HiddenField ID="hidBillID" runat="server" Value='<%# Eval("BillID") %>' />
                                                    <asp:LinkButton ID="lnkSplitBill" Text="Split Bill" CssClass="btn btn-primary btn-sm" CommandName="SplitBill" CommandArgument='<%# Eval("BillID") %>' runat="server" />
                                                    <asp:LinkButton ID="lnkEditBill" Text="Edit Bill" CssClass="btn btn-warning btn-sm" CommandName="EditBill" CommandArgument='<%# Eval("BillID") %>' runat="server" />
                                                    <asp:LinkButton ID="lnkDeleteBill" Text="Delete Bill" CssClass="btn btn-danger btn-sm" CommandName="DeleteBill" CommandArgument='<%# Eval("BillID") %>' runat="server" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyItemTemplate>
                                            <tr>
                                                <td colspan="5">No bills created yet. Click the "Add Bill" button to create a new bill.</td>
                                            </tr>
                                        </EmptyItemTemplate>
                                    </asp:ListView>
                                </table>
                            </div>
                        </div>
    </div>
    </div>
            </div>

        </div>
    </div>

    <!-- Modal Create Wallet -->
    <div class="modal" id="myModalCreateWallet">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Create Wallet</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtModalCreateWallet">By clicking this button, you have agreed to all the terms and conditions for creating a Wallet account that will be connected to your account.</label>
                    </div>
                    <div class="form-group">
                        <label for="txtBillDate">Enter the nominal initial balance of your Wallet account:</label>
                        <asp:TextBox ID="txtWalletBalance" runat="server" CssClass="form-control" placeholder="Enter initial balance" />
                    </div>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Create" ID="btnCreateWallet" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnCreateWallet_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Create Bill -->
    <div class="modal" id="myModalCreateBill">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Create Bill</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtBillDate">Bill Date :</label>
                        <asp:TextBox ID="txtBillDate" runat="server" CssClass="form-control" TextMode="Date" placeholder="Enter bill date" />
                    </div>
                    <div class="form-group">
                        <label for="txtBillAmount">Bill Amount :</label>
                        <asp:TextBox ID="txtBillAmount" runat="server" CssClass="form-control" placeholder="Enter bill amount" />
                    </div>
                    <div class="form-group">
                        <label for="txtOwnerContribution">Your Share :</label>
                        <asp:TextBox ID="txtOwnerContribution" runat="server" CssClass="form-control" placeholder="Enter your share on the bill amount" />
                    </div>
                    <div class="form-group">
                        <label for="txtBillDescription">Bill Description :</label>
                        <asp:TextBox ID="txtBillDescription" runat="server" CssClass="form-control" placeholder="Enter bill description" />
                    </div>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Create" ID="btnCreateBill" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnCreateBill_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Update Bill -->
    <div class="modal" id="myModalUpdateBill">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Edit Bill</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:HiddenField ID="hidBillID_Modal" runat="server" />
                    <div class="form-group">
                        <label for="txtEditBillDate">Bill Date :</label>
                        <asp:TextBox ID="txtEditBillDate" runat="server" CssClass="form-control" TextMode="Date" placeholder="dd/mm/yyyy" />
                    </div>
                    <div class="form-group">
                        <label for="txtEditBillAmount">Bill Amount :</label>
                        <asp:TextBox ID="txtEditBillAmount" runat="server" CssClass="form-control" placeholder="Enter bill amount" />
                    </div>
                    <div class="form-group">
                        <label for="txtEditOwnerContribution">Your Share :</label>
                        <asp:TextBox ID="txtEditOwnerContribution" runat="server" CssClass="form-control" placeholder="Enter your share on the bill amount" />
                    </div>
                    <div class="form-group">
                        <label for="txtEditBillDescription">Bill Description :</label>
                        <asp:TextBox ID="txtEditBillDescription" runat="server" CssClass="form-control" placeholder="Enter bill description" />
                    </div>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Edit" ID="btnEditBill" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnEditBill_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Update Wallet Balance -->
    <div class="modal" id="myModalUpdateWalletBalance">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Add Wallet Balance</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtBalanceAmount">Balance Amount :</label>
                        <asp:TextBox ID="txtBalanceAmount" runat="server" CssClass="form-control" placeholder="Enter the amount of balance you want to add." />
                    </div>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Add Wallet Balance" ID="btnUpdateWalletBalance" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnUpdateWalletBalance_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Delete Bill-->
    <div class="modal" id="myModalDeleteBill">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Delete Bill</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <asp:HiddenField ID="hidBillID_ModalDelete" runat="server" />
                <div class="modal-body">
                    <asp:Label ID="lblConfirmationMessageBill" runat="server" Text="Are you sure you want to delete this bill?"></asp:Label>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Delete Bill" ID="btnDeleteBill" CssClass="btn btn-danger btn-sm" runat="server" OnClick="btnDeleteBill_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
