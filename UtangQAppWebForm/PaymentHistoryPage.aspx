<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PaymentHistoryPage.aspx.vb" Inherits="UtangQAppWebForm.PaymentHistoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col">
        <div class="card">
            <div class="card-header">
                Bill Recipient Details
            </div>
            <div class="card-body">
                <asp:Label ID="lblBillRecipientDetails" runat="server" Text="" Visible="false"></asp:Label>
                <table class="table table-hover">
                    <asp:ListView ID="lvBillRecipientbyUserID" runat="server" OnItemCommand="lvBillRecipientbyUserID_ItemCommand" OnItemDataBound="lvBillRecipientbyUserID_ItemDataBound">
                        <LayoutTemplate>
                            <thead>
                                <tr>
                                    <th>Num.</th>
                                    <th>Sent Date</th>
                                    <th>Recipient Status</th>
                                    <th>Tax Status</th>
                                    <th>Amount</th>
                                    <th>&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr id="itemPlaceholder" runat="server"></tr>
                            </tbody>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="lblBillRecipientID" runat="server" Value='<%# Eval("BillRecipientID") %>' />
                                <asp:HiddenField ID="lblBillID" runat="server" Value='<%# Eval("BillID") %>' />

                                <td><%# Container.DisplayIndex + 1 %></td>
                                <td><%# Eval("SentDate", "{0:MM/dd/yyyy}") %></td>
                                <td><%# GetBillStatusName(Eval("BillRecipientStatusID"))%></td>
                                <td><%# GetTaxStatusName(Eval("BillRecipientTaxStatusID")) %></td>
                                <td><%# Eval("BillRecipientAmount", "{0:N2}") %></td>
                                <td>
                                    <asp:Button ID="btnCreatePayment" runat="server" Text="Create Payment" CommandName="CreatePayment" CommandArgument='<%# Eval("BillRecipientID") %>' CssClass="btn btn-primary btn-sm" />
                                    <asp:Button ID="btnViewReceipt" runat="server" Text="View Receipt" CommandName="ViewReceipt" CommandArgument='<%# Eval("BillRecipientID") %>' CssClass="btn btn-secondary btn-sm" />
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
    </div>

    <!-- Modal Create Payment -->
    <div class="modal" id="myModalCreatePayment">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Create Payment</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <asp:HiddenField ID="hiddenBillRecipientID_Modal" runat="server" />
                <div class="modal-body">
                    <asp:Label ID="lblConfirmationMessageBillRecipient" runat="server" Text="Are you sure you want to create payment for this bill?"></asp:Label>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button Text="Create Payment" ID="btnCreatePaymentModal" CssClass="btn btn-primary btn-sm" runat="server" OnClick="btnCreatePayment_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
