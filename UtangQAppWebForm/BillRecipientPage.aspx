<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BillRecipientPage.aspx.vb" Inherits="UtangQAppWebForm.BillRecipientPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col">
                    <h5 class="card-title">Bill Recipients</h5>
                </div>
                <div class="col text-right">
                    <asp:Button ID="btnCreateBillRecipient" runat="server" Text="Create Bill Recipient" CssClass="btn btn-primary mb-2" OnClick="btnCreateBillRecipient_Click" />
                </div>
            </div>
            <asp:Label ID="lblBillRecipientDetails" runat="server" Text="" Visible="false"></asp:Label>
            <table class="table table-hover">
                <asp:ListView ID="lvBillRecipients" DataKeyNames="BillRecipientID" OnSelectedIndexChanged="lvBillRecipients_SelectedIndexChanged" OnSelectedIndexChanging="lvBillRecipients_SelectedIndexChanging" runat="server" OnItemDataBound="lvBillRecipients_ItemDataBound" OnItemCommand="lvBillRecipients_ItemCommand">
                    <LayoutTemplate>
                        <thead>
                            <tr>
                                <th>Bill Recipient ID</th>
                                <th>Bill ID</th>
                                <th>Recipient Username</th>
                                <th>Sent Date</th>
                                <th>Recipient Status</th>
                                <th>Tax Status</th>
                                <th>Bill Recipient Amount</th>
                                <th>&nbsp;</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="itemPlaceholder" runat="server"></tr>
                        </tbody>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("BillRecipientID") %></td>
                            <td><%# Eval("BillID") %></td>
                            <td><%# GetRecipientUsername(Eval("RecipientUserID")) %></td>
                            <td><%# Eval("SentDate", "{0:MM/dd/yyyy}") %></td>
                            <td><%# GetBillStatusName(Eval("BillRecipientStatusID")) %></td>
                            <td><%# GetTaxStatusName(Eval("BillRecipientTaxStatusID")) %></td>
                            <td><%# Eval("BillRecipientAmount", "{0:N2}") %></td>
                            <td>
                                <asp:Button ID="btnConfirmPayment" runat="server" Text="Confirm Payment" CommandName="ConfirmPayment" CommandArgument='<%# Eval("BillRecipientID") %>' CssClass="btn btn-primary btn-sm" Enabled="false" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <tr>
                            <td colspan="7">No bill recipients found.</td>
                        </tr>
                    </EmptyDataTemplate>
                </asp:ListView>
            </table>
        </div>
    </div>

    <!-- Modal Confirm Payment -->
    <div class="modal" id="myModalConfirmPayment">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Confirm Payment</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <asp:HiddenField ID="hiddenBillRecipientID_Modal" runat="server" />
                <div class="modal-body">
                    <asp:Label ID="lblConfirmationMessageBillRecipient" runat="server" Text="Are you sure you want to confirm payment for this bill?"></asp:Label>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Confirm Payment" ID="btnConfirmPaymentModal" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnConfirmPaymentModal_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Create Bill Recipient-->
    <div class="modal" id="myModalCreateBillRecipient">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Create Bill Recipient</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:HiddenField ID="hiddenBillID_Modal" runat="server" />
                    <div class="form-group">
                        <label for="ddlRecipientUser">Recipient User:</label>
                        <asp:DropDownList ID="ddlRecipientUser" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txtTotalUsers">Total Users:</label>
                        <asp:TextBox ID="txtTotalUsers" runat="server" CssClass="form-control" placeholder="Enter total users" />
                    </div>
                    <div class="form-group">
                        <label for="chkSplitEvenly">Split Evenly:</label>
                        <asp:CheckBox ID="chkSplitEvenly" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="ddlTaxStatus">Tax Status:</label>
                        <asp:DropDownList ID="ddlTaxStatus" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txtTaxCharged">Tax Charged:</label>
                        <asp:TextBox ID="txtTaxCharged" runat="server" CssClass="form-control" placeholder="Enter tax charged" />
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Create Bill Recipient" ID="btnCreateBillRecipientModal" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnCreateBillRecipientModal_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
