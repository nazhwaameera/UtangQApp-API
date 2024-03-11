Imports UtangQAppBLL
Imports UtangQAppBLL.DTOs.Transaction
Imports UtangQAppBLL.DTOs.User

Public Class BillRecipientPage
    Inherits System.Web.UI.Page

    Dim userBLL As New UserBLL()
    Dim billBLL As New BillBLL()
    Dim billStatusBLL As New BillStatusBLL()
    Dim taxStatusBLL As New TaxStatusBLL()
    Dim billRecipientBLL As New BillRecipientBLL()
    Dim paymentReceiptBLL As New PaymentReceiptBLL()
    Dim userDTO As New UserDTO
    Dim billRecipientDTO As New BillRecipientDTO
    Dim billStatusDTO As New BillStatusDTO
    Dim taxStatusDTO As New TaxStatusDTO
    Dim paymentReceiptDTO As New PaymentReceiptDTO

    Dim userId As Integer = 6

#Region "Binding Data"
    Sub LoadDataBillRecipient(ByVal billID As Integer)
        Dim billRecipients As IEnumerable(Of BillRecipientDTO) = billRecipientBLL.GetBillRecipientsByBillID(billID)
        lvBillRecipients.DataSource = billRecipients
        lvBillRecipients.DataBind()
    End Sub
    Sub CreateConfirmPaymentModal(id As Integer)
        hiddenBillRecipientID_Modal.Value = id
    End Sub
    Sub LoadDropDownList()
        ' Populate the recipient user dropdown list
        ddlRecipientUser.DataSource = GetRecipientUsers()
        ddlRecipientUser.DataTextField = "Username"
        ddlRecipientUser.DataValueField = "UserID"
        ddlRecipientUser.DataBind()

        ' Populate the tax status dropdown list
        ddlTaxStatus.DataSource = GetTaxStatuses()
        ddlTaxStatus.DataTextField = "TaxStatusDescription"
        ddlTaxStatus.DataValueField = "TaxStatusID"
        ddlTaxStatus.DataBind()
    End Sub
#End Region
#Region "Handling Button"

#End Region
#Region "Function"
    Public Function GetBillStatusName(billStatusId As Integer) As String
        billStatusDTO = billStatusBLL.Get(billStatusId)
        Return billStatusDTO.BillStatusDescription
    End Function
    Public Function GetTaxStatusName(taxStatusId As Integer) As String
        taxStatusDTO = taxStatusBLL.Get(taxStatusId)
        Return taxStatusDTO.TaxStatusDescription
    End Function
    Public Function GetRecipientUsername(recipientUserId As Integer) As String
        userDTO = userBLL.Get(recipientUserId)
        Return userDTO.Username
    End Function
    Private Function CheckIfBillRecipientHasPayment(ByVal billRecipientId As Integer) As Boolean
        Dim paymentReceipts As PaymentReceiptDTO = paymentReceiptBLL.ReadPaymentReceiptbyBillRecipientID(billRecipientId)
        Dim hasPaymentReceipts As Boolean = (paymentReceipts IsNot Nothing)
        Return hasPaymentReceipts
    End Function
    Private Function GetRecipientUsers() As List(Of UserDTO)
        Dim users As List(Of UserDTO) = userBLL.GetAll()
        Return users
    End Function
    Private Function GetTaxStatuses() As List(Of TaxStatusDTO)
        Dim taxStatuses As List(Of TaxStatusDTO) = taxStatusBLL.GetAll()
        Return taxStatuses
    End Function
#End Region
#Region "Handling List View"

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("ID") IsNot Nothing Then
                Dim billId As String = Request.QueryString("ID")
                Session("BillID") = billId
                LoadDataBillRecipient(billId)
                LoadDropDownList()
            End If
        End If
    End Sub

    Protected Sub lvBillRecipients_ItemDataBound(sender As Object, e As ListViewItemEventArgs)
        If e.Item.ItemType = ListViewItemType.DataItem Then
            ' Get the data item (bill) associated with the item
            Dim dto As UtangQAppBLL.DTOs.Transaction.BillRecipientDTO = CType(e.Item.DataItem, UtangQAppBLL.DTOs.Transaction.BillRecipientDTO)
            Dim billRecipientID As Integer = Convert.ToInt32(DataBinder.Eval(dto, "BillRecipientID"))
            Dim billStatusId As Integer = Convert.ToInt32(DataBinder.Eval(dto, "BillRecipientStatusID"))

            'Check if the bill recipient has payment
            Dim hasPayment As Boolean = CheckIfBillRecipientHasPayment(billRecipientID)

            If hasPayment And billStatusId = 1 Then
                Dim btnConfirmPayment As Button = CType(e.Item.FindControl("btnConfirmPayment"), Button)
                btnConfirmPayment.Enabled = True
            ElseIf hasPayment And billStatusId = 2 Then
                Dim btnConfirmPayment As Button = CType(e.Item.FindControl("btnConfirmPayment"), Button)
                btnConfirmPayment.Enabled = False
            Else
                Dim btnConfirmPayment As Button = CType(e.Item.FindControl("btnConfirmPayment"), Button)
                btnConfirmPayment.Enabled = True
            End If
        End If
    End Sub

    Protected Sub lvBillRecipients_ItemCommand(sender As Object, e As ListViewCommandEventArgs)
        If e.CommandName = "ConfirmPayment" Then
            Dim billRecipientID As Integer = Convert.ToInt32(e.CommandArgument)
            CreateConfirmPaymentModal(billRecipientID)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalConfirmPayment').modal('show');})", True)
        End If
    End Sub

    Protected Sub btnConfirmPaymentModal_Click(sender As Object, e As EventArgs)
        Try
            billRecipientBLL.UpdateBillRecipientPaymentStatus(hiddenBillRecipientID_Modal.Value, 2)
            LoadDataBillRecipient(Session("BillID"))
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#myModalConfirmPayment').modal('hide');", True)

            lblBillRecipientDetails.Visible = True
            lblBillRecipientDetails.Text = "<span class='alert alert-success'>Payment confirmed</span><br/><br/>"
        Catch ex As Exception
            lblBillRecipientDetails.Visible = True
            lblBillRecipientDetails.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub lvBillRecipients_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub lvBillRecipients_SelectedIndexChanging(sender As Object, e As ListViewSelectEventArgs)

    End Sub

    Protected Sub btnCreateBillRecipient_Click(sender As Object, e As EventArgs)
        hiddenBillID_Modal.Value = Session("BillID")
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalCreateBillRecipient').modal('show');})", True)
    End Sub
    Protected Sub btnCreateBillRecipientModal_Click(sender As Object, e As EventArgs)
        Try
            Dim billRecipient As New BillRecipientCreateDTO
            billRecipient.BillID = Convert.ToInt32(hiddenBillID_Modal.Value)
            billRecipient.RecipientUserID = Convert.ToInt32(ddlRecipientUser.SelectedValue)
            billRecipient.TotalUsers = txtTotalUsers.Text
            billRecipient.IsSplitEvenly = chkSplitEvenly.Checked
            billRecipient.TaxStatusDescription = ddlTaxStatus.SelectedItem.Text
            billRecipient.TaxCharged = txtTaxCharged.Text

            billRecipientBLL.Create(billRecipient)

            LoadDataBillRecipient(Session("BillID"))

            lblBillRecipientDetails.Visible = True
            lblBillRecipientDetails.Text = "<span class='alert alert-success'>Bill recipient created</span><br/><br/>"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#myModalCreateBillRecipient').modal('hide');", True)
        Catch ex As Exception
            lblBillRecipientDetails.Visible = True
            lblBillRecipientDetails.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class