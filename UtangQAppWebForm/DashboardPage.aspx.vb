Imports UtangQAppBLL
Imports UtangQAppBLL.DTOs.User
Imports UtangQAppBLL.DTOs.Transaction
Public Class DashboardPage
    Inherits System.Web.UI.Page
    Dim billRecipientBLL As New BillRecipientBLL()
    Dim billRecipientDTO As New BillRecipientDTO
    Sub LoadDataBills()
        Dim billBLL As New BillBLL()
        Dim bills As IEnumerable(Of BillDTO) = billBLL.ReadUserBills(5)
        lvBillsCreated.DataSource = bills
        lvBillsCreated.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim userId As Integer = 5

            Dim totalBillAmount As Decimal = GetTotalBillAmountCreated(userId)
            lblTotalBillsCreated.Text = totalBillAmount.ToString("C")

            Dim totalBillAmountPaid As Decimal = GetTotalBillAmountCreatedPaid(userId)
            lblTotalBillsPaid.Text = totalBillAmountPaid.ToString("C")

            Dim totalBillAmountPending As Decimal = GetTotalBillAmountCreatedPending(userId)
            lblTotalBillsPending.Text = totalBillAmountPending.ToString("C")

            LoadDataBills()
        End If

    End Sub

    Private Function GetTotalBillAmountCreated(ByVal userId As Integer) As Decimal
        Dim billBLL As New BillBLL()
        Dim totalAmount As Decimal = billBLL.GetTotalBillAmountCreatedProcedure(userId)
        Return totalAmount
    End Function

    Private Function GetTotalBillAmountCreatedPaid(ByVal userId As Integer) As Decimal
        Dim billBLL As New BillBLL()
        Dim totalAmountPaid As Decimal = billBLL.GetTotalBillAmountCreatedPaidProcedure(userId)
        Return totalAmountPaid
    End Function

    Private Function GetTotalBillAmountCreatedPending(ByVal userId As Integer) As Decimal
        Dim billBLL As New BillBLL()
        Dim totalAmountPending As Decimal = billBLL.GetTotalBillAmountCreatedPendingProcedure(userId)
        Return totalAmountPending
    End Function

    Private Function CheckIfBillHasRecipients(ByVal billID As Integer) As Boolean
        Dim billRecipientBLL As New BillRecipientBLL()
        Dim billRecipients As IEnumerable(Of BillRecipientDTO) = billRecipientBLL.GetBillRecipientsByBillID(billID)
        Return billRecipients.Any()
    End Function

    Protected Sub btnAddBill_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalCreateBill').modal('show');})", True)
    End Sub

    Protected Sub btnCreateBill_Click(sender As Object, e As EventArgs)
        Try
            Dim billBLL As New BillBLL()
            Dim bill As New BillCreateDTO
            bill.UserID = 5
            bill.BillAmount = txtBillAmount.Text
            bill.BillDate = txtBillDate.Text
            bill.BillDescription = txtBillDescription.Text

            billBLL.Create(bill)

            ltMessageBill.Visible = True
            ltMessageBill.Text = "<span class='alert alert-success'>Bill created successfully</span><br/><br/>"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#myModalCreateBill').modal('hide');", True)
        Catch ex As Exception
            ltMessageBill.Visible = True
            ltMessageBill.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub lvBillsCreated_SelectedIndexChanging(sender As Object, e As ListViewSelectEventArgs)

    End Sub

    Protected Sub lvBillsCreated_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub lvBillsCreated_ItemCommand(sender As Object, e As ListViewCommandEventArgs)

    End Sub

    Protected Sub lvBillsCreated_ItemDataBound(sender As Object, e As ListViewItemEventArgs)
        If e.Item.ItemType = ListViewItemType.DataItem Then
            ' Find the buttons in the item
            Dim lnkSplitBill As LinkButton = CType(e.Item.FindControl("lnkSplitBill"), LinkButton)
            Dim lnkEditBill As LinkButton = CType(e.Item.FindControl("lnkEditBill"), LinkButton)

            ' Get the data item (bill) associated with the item
            Dim dto As UtangQAppBLL.DTOs.User.BillDTO = CType(e.Item.DataItem, UtangQAppBLL.DTOs.User.BillDTO)
            Dim billID As Integer = Convert.ToInt32(DataBinder.Eval(dto, "BillID"))

            ' Check if the bill has recipients
            Dim hasRecipients As Boolean = CheckIfBillHasRecipients(billID)

            ' Set visibility of buttons based on whether the bill has recipients
            If hasRecipients Then
                lnkSplitBill.Text = "View Split Details" ' Change the text of the button
                lnkEditBill.Visible = False ' Hide the Edit button
            Else
                lnkSplitBill.Text = "Split Bill" ' Reset the text of the button
                lnkEditBill.Visible = True ' Show the Edit button
            End If
        End If
    End Sub

End Class