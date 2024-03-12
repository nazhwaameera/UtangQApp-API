Imports UtangQAppBLL
Imports UtangQAppBLL.DTOs.User
Imports UtangQAppBLL.DTOs.Transaction
Public Class DashboardPage
    Inherits System.Web.UI.Page

    Dim walletBll As New WalletBLL()
    Dim billBLL As New BillBLL()
    Dim billRecipientBLL As New BillRecipientBLL()
    Dim billRecipientDTO As New BillRecipientDTO

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim userId As Integer = Session("UserID")
            LoadDataWallet(userId)
            LoadDataBillSummary(userId)
            LoadDataBills(userId)
        End If
    End Sub

#Region "Binding Data"
    Sub LoadDataWallet(ByVal userId As Integer)
        Dim wallet As WalletDTO = walletBll.ReadWalletbyUserID(userId)
        If wallet IsNot Nothing Then
            lblWalletBalance.Text = wallet.WalletBalance.ToString("C")
            lblWalletBalance.Visible = True
            btnAddWalletBalance.Visible = True
            lnkViewTransactions.Visible = True
        Else
            btnAddWallet.Visible = True
        End If
    End Sub
    Sub LoadDataBillSummary(ByVal userId As Integer)
        Dim totalBillAmount As Decimal = GetTotalBillAmountCreated(userId)
        lblTotalBillsCreated.Text = totalBillAmount.ToString("C")

        Dim totalUnassignedBillAmount As Decimal = CalculateTotalUnassignedBillAmount(userId)
        lblTotalBillsUnassigned.Text = totalUnassignedBillAmount.ToString("C")

        Dim totalBillAmountPaid As Decimal = GetTotalBillAmountCreatedPaid(userId)
        lblTotalBillsPaid.Text = totalBillAmountPaid.ToString("C")

        Dim totalBillAmountPending As Decimal = GetTotalBillAmountCreatedPending(userId)
        lblTotalBillsPending.Text = totalBillAmountPending.ToString("C")

        Dim totalPendingAmountOwed As Decimal = GetTotalPendingAmountOwedProcedure(userId)
        lblBillsToBePaidTotal.Text = totalPendingAmountOwed.ToString("C")

        If (totalPendingAmountOwed > 0) Then
            btnCreatePayment.Visible = True
            btnCreatePayment.Enabled = True
            btnCreatePayment.Text = "Create Payment"
        Else
            btnCreatePayment.Visible = True
            btnCreatePayment.Enabled = True
            btnCreatePayment.Text = "View Payment History"
            btnCreatePayment.CssClass = "btn btn-secondary my-1 w-100"
        End If

    End Sub
    Sub LoadDataBills(ByVal userId As Integer)
        Dim bills As IEnumerable(Of BillDTO) = billBLL.ReadUserBills(userId)
        lvBillsCreated.DataSource = bills
        lvBillsCreated.DataBind()
    End Sub
    Sub GetEditBillModal(id As Integer)
        Try
            Dim billData As BillDTO = billBLL.Get(id)
            If billData IsNot Nothing Then
                hidBillID_Modal.Value = billData.BillID
                txtEditBillAmount.Text = String.Format("{0:0.00}", billData.BillAmount)
                txtEditBillDate.Text = billData.BillDate.ToString("yyyy-MM-dd")
                txtEditBillDescription.Text = billData.BillDescription
                txtEditOwnerContribution.Text = String.Format("{0:0.00}", billData.OwnerContribution)
            Else
                ltMessageBill.Visible = True
                ltMessageBill.Text = "<span class='alert alert-danger'>Error: Bill not found</span><br/><br/>"
            End If
        Catch ex As Exception
            ltMessageBill.Visible = True
            ltMessageBill.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Sub GetDeleteBillModal(id As Integer)
        hidBillID_ModalDelete.Value = id
    End Sub

#End Region

#Region "Handling Button"
    Protected Sub btnAddWallet_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalCreateWallet').modal('show');})", True)
    End Sub

    Protected Sub btnCreateWallet_Click(sender As Object, e As EventArgs)
        Try
            Dim wallet As New WalletCreateDTO
            wallet.UserID = Session("UserID")
            wallet.WalletBalance = txtWalletBalance.Text

            walletBll.Create(wallet)

            btnAddWallet.Visible = False
            LoadDataWallet(Session("UserID"))

            ltMessageWallet.Visible = True
            ltMessageWallet.Text = "<span class='alert alert-success'>Wallet created successfully</span><br/><br/>"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#myModalCreateWallet').modal('hide');", True)
        Catch ex As Exception
            ltMessageWallet.Visible = True
            ltMessageWallet.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub btnAddBill_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalCreateBill').modal('show');})", True)
    End Sub

    Protected Sub btnCreateBill_Click(sender As Object, e As EventArgs)
        Try
            Dim bill As New BillCreateDTO
            bill.UserID = Session("UserID")
            bill.BillAmount = txtBillAmount.Text
            bill.BillDate = txtBillDate.Text
            bill.BillDescription = txtBillDescription.Text
            bill.OwnerContribution = txtOwnerContribution.Text

            billBLL.Create(bill)

            lvBillsCreated.DataBind()
            LoadDataBills(Session("UserID"))
            LoadDataBillSummary(Session("UserID"))

            ltMessageBill.Visible = True
            ltMessageBill.Text = "<span class='alert alert-success'>Bill created successfully</span><br/><br/>"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#myModalCreateBill').modal('hide');", True)
        Catch ex As Exception
            ltMessageBill.Visible = True
            ltMessageBill.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub btnEditBill_Click(sender As Object, e As EventArgs)
        Try
            Dim bill As New BillDTO
            bill.BillID = hidBillID_Modal.Value
            bill.UserID = Session("UserID")
            bill.BillAmount = txtEditBillAmount.Text
            bill.BillDate = txtEditBillDate.Text
            bill.BillDescription = txtEditBillDescription.Text
            bill.OwnerContribution = txtEditOwnerContribution.Text

            billBLL.Update(bill)

            lvBillsCreated.DataBind()
            LoadDataBills(Session("UserID"))
            LoadDataBillSummary(Session("UserID"))

            ltMessageBill.Visible = True
            ltMessageBill.Text = "<span class='alert alert-success'>Bill updated successfully</span><br/><br/>"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#myModalUpdateBill').modal('hide');", True)
        Catch ex As Exception
            ltMessageBill.Visible = True
            ltMessageBill.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub btnAddWalletBalance_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalUpdateWalletBalance').modal('show');})", True)
    End Sub

    Protected Sub btnUpdateWalletBalance_Click(sender As Object, e As EventArgs)
        Try
            walletBll.UpdateWalletBalance(Session("UserID"), txtBalanceAmount.Text, "A")

            LoadDataWallet(Session("UserID"))

            ltMessageWallet.Visible = True
            ltMessageWallet.Text = "<span class='alert alert-success'>Wallet balance updated</span><br/><br/>"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#myModalUpdateWalletBalance').modal('hide');", True)
        Catch ex As Exception
            ltMessageWallet.Visible = True
            ltMessageWallet.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub btnDeleteBill_Click(sender As Object, e As EventArgs)
        Try
            billBLL.Delete(hidBillID_ModalDelete.Value)
            LoadDataBills(Session("UserID"))
            LoadDataBillSummary(Session("UserID"))
            ltMessageBill.Visible = True
            ltMessageBill.Text = "<span class='alert alert-success'>Bill deleted successfully</span><br/><br/>"
        Catch ex As Exception
            ltMessageBill.Visible = True
            ltMessageBill.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub btnCreatePayment_Click(sender As Object, e As EventArgs)
        ' Redirect to PaymentHistoryPage
        Response.Redirect("PaymentHistoryPage.aspx")
    End Sub
#End Region

#Region "Function"
    Private Function GetTotalBillAmountCreated(ByVal userId As Integer) As Decimal
        Dim totalAmount As Decimal = billBLL.GetTotalBillAmountCreatedProcedure(userId)
        Return totalAmount
    End Function

    Private Function CalculateTotalUnassignedBillAmount(ByVal userId As Integer) As Decimal
        Dim totalAmount As Decimal = billBLL.CalculateTotalUnassignedBillAmount(userId)
        Return totalAmount
    End Function

    Private Function GetTotalBillAmountCreatedPaid(ByVal userId As Integer) As Decimal
        Dim totalAmountPaid As Decimal = billBLL.GetTotalBillAmountCreatedPaidProcedure(userId)
        Return totalAmountPaid
    End Function

    Private Function GetTotalBillAmountCreatedPending(ByVal userId As Integer) As Decimal
        Dim totalAmountPending As Decimal = billBLL.GetTotalBillAmountCreatedPendingProcedure(userId)
        Return totalAmountPending
    End Function

    Private Function GetTotalPendingAmountOwedProcedure(ByVal RecipientUserID As Integer) As Decimal
        Dim totalAmountPending As Decimal = billBLL.GetTotalPendingAmountOwedProcedure(RecipientUserID)
        Return totalAmountPending
    End Function

    Private Function CheckIfBillHasRecipients(ByVal billID As Integer) As Boolean
        Dim billRecipients As IEnumerable(Of BillRecipientDTO) = billRecipientBLL.GetBillRecipientsByBillID(billID)
        Return billRecipients.Any()
    End Function
#End Region

#Region "Handling List View"
    Protected Sub lvBillsCreated_SelectedIndexChanging(sender As Object, e As ListViewSelectEventArgs)

    End Sub

    Protected Sub lvBillsCreated_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub lvBillsCreated_ItemCommand(sender As Object, e As ListViewCommandEventArgs)
        Dim billID As Integer = Convert.ToInt32(e.CommandArgument)
        If e.CommandName = "EditBill" Then
            GetEditBillModal(billID)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalUpdateBill').modal('show');})", True)
        ElseIf e.CommandName = "DeleteBill" Then
            GetDeleteBillModal(billID)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalDeleteBill').modal('show');})", True)
        ElseIf e.CommandName = "SplitBill" Then
            Response.Redirect($"BillRecipientPage.aspx?ID={billID}")
        End If
    End Sub

    Protected Sub lvBillsCreated_ItemDataBound(sender As Object, e As ListViewItemEventArgs)
        If e.Item.ItemType = ListViewItemType.DataItem Then
            ' Find the buttons in the item
            Dim lnkSplitBill As LinkButton = CType(e.Item.FindControl("lnkSplitBill"), LinkButton)
            Dim lnkEditBill As LinkButton = CType(e.Item.FindControl("lnkEditBill"), LinkButton)
            Dim lnkDeleteBill As LinkButton = CType(e.Item.FindControl("lnkDeleteBill"), LinkButton)

            ' Get the data item (bill) associated with the item
            Dim dto As UtangQAppBLL.DTOs.User.BillDTO = CType(e.Item.DataItem, UtangQAppBLL.DTOs.User.BillDTO)
            Dim billID As Integer = Convert.ToInt32(DataBinder.Eval(dto, "BillID"))

            ' Check if the bill has recipients
            Dim hasRecipients As Boolean = CheckIfBillHasRecipients(billID)

            ' Set visibility of buttons based on whether the bill has recipients
            If hasRecipients Then
                lnkSplitBill.Text = "View Split Details" ' Change the text of the button
                lnkEditBill.Visible = False ' Hide the Edit button
                lnkDeleteBill.Visible = False ' Hide the Delete button
            Else
                lnkSplitBill.Text = "Split Bill" ' Reset the text of the button
                lnkEditBill.Visible = True ' Show the Edit button
                lnkDeleteBill.Visible = True ' Show the Delete button
            End If
        End If
    End Sub
#End Region

End Class