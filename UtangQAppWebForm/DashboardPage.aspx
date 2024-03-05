<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DashboardPage.aspx.vb" Inherits="UtangQAppWebForm.DashboardPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <!-- Money Owned Card -->
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <h2>Money Owned</h2>
                    </div>
                    <div class="card-body">
                        <!-- Display money owned details -->
                        <asp:Label ID="lblMoneyOwnedTotal" runat="server" Text="Total Amount: $XXX"></asp:Label>
                        <!-- Placeholder for list of details -->
                        <asp:ListView ID="lvMoneyOwnedDetails" runat="server">
                            <ItemTemplate>
                                <div><%# Eval("DetailInfo") %></div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
            <!-- Bills to be Paid Card -->
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <h2>Bills to be Paid</h2>
                    </div>
                    <div class="card-body">
                        <!-- Display bills to be paid details -->
                        <asp:Label ID="lblBillsToBePaidTotal" runat="server" Text="Total Number of Bills: XX"></asp:Label>
                        <!-- Placeholder for list of details -->
                        <asp:ListView ID="lvBillsToBePaidDetails" runat="server">
                            <ItemTemplate>
                                <div><%# Eval("DetailInfo") %></div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <!-- Bills Created Card -->
            <div class="col-lg-12">
                <div class="card">
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
                                                    <asp:LinkButton ID="lnkSplitBill" Text="Split Bill" CssClass="btn btn-primary btn-sm" CommandName="SplitBill" CommandArgument='<%# Eval("BillID") %>' runat="server" />
                                                    <asp:LinkButton ID="lnkEditBill" Text="Edit Bill" CssClass="btn btn-secondary btn-sm" CommandName="EditBill" CommandArgument='<%# Eval("BillID") %>' runat="server" />
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
                        <label for="txtBillAmount">Bill Amount :</label>
                        <asp:TextBox ID="txtBillAmount" runat="server" CssClass="form-control" placeholder="Enter Bill Amount" />
                    </div>
                    <div class="form-group">
                        <label for="txtBillDate">Bill Date :</label>
                        <asp:TextBox ID="txtBillDate" runat="server" CssClass="form-control" TextMode="Date" placeholder="Enter Bill Date" />
                        <!-- You can use a date picker control here if needed -->
                    </div>
                    <div class="form-group">
                        <label for="txtBillDescription">Bill Description :</label>
                        <asp:TextBox ID="txtBillDescription" runat="server" CssClass="form-control" placeholder="Enter Bill Description" />
                    </div>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Create" ID="btnCreateBill" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnCreateBill_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
