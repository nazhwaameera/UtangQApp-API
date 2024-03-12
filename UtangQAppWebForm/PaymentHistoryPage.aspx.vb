Imports UtangQAppBLL
Imports UtangQAppBLL.DTOs.Transaction

Public Class PaymentHistoryPage
    Inherits System.Web.UI.Page

    Dim billBLL As New BillBLL()
    Dim billStatusBLL As New BillStatusBLL()
    Dim taxStatusBLL As New TaxStatusBLL()
    Dim billRecipientBLL As New BillRecipientBLL()
    Dim paymentReceiptBLL As New PaymentReceiptBLL()
    Dim billRecipientDTO As New BillRecipientDTO
    Dim billStatusDTO As New BillStatusDTO
    Dim taxStatusDTO As New TaxStatusDTO
    Dim paymentReceiptDTO As New PaymentReceiptDTO

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim userId As Integer = Session("UserID")
            LoadDataBillRecipients(userId)
        End If
    End Sub

#Region "Binding Data"
    Sub LoadDataBillRecipients(userId)
        Dim billRecipients As IEnumerable(Of BillRecipientDTO) = billRecipientBLL.ReadBillRecipientByRecipientUserID(userId)
        lvBillRecipientbyUserID.DataSource = billRecipients
        lvBillRecipientbyUserID.DataBind()
    End Sub

    Sub CreatePaymentModal(id As Integer)
        hiddenBillRecipientID_Modal.Value = id
    End Sub
#End Region

#Region "Handling Button"
    Protected Sub btnCreatePayment_Click(sender As Object, e As EventArgs)
        Try
            paymentReceiptBLL.CreatePaymentReceiptAndUpdateStatus(hiddenBillRecipientID_Modal.Value, "example.com")
            LoadDataBillRecipients(Session("UserID"))
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#myModalCreatePayment').modal('hide');", True)
        Catch ex As Exception
            lblBillRecipientDetails.Visible = True
            lblBillRecipientDetails.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
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
    Private Function CheckIfBillRecipientHasPayment(ByVal billRecipientId As Integer) As Boolean
        Dim paymentReceipts As PaymentReceiptDTO = paymentReceiptBLL.ReadPaymentReceiptbyBillRecipientID(billRecipientId)
        Dim hasPaymentReceipts As Boolean = (paymentReceipts IsNot Nothing)
        Return hasPaymentReceipts
    End Function
#End Region

#Region "Handling List View"
    Protected Sub lvBillRecipientbyUserID_ItemCommand(sender As Object, e As ListViewCommandEventArgs)
        If e.CommandName = "CreatePayment" Then
            Dim billRecipientID As Integer = Convert.ToInt32(e.CommandArgument)
            CreatePaymentModal(billRecipientID)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalCreatePayment').modal('show');})", True)
        End If
    End Sub
    Protected Sub lvBillRecipientbyUserID_ItemDataBound(sender As Object, e As ListViewItemEventArgs)
        If e.Item.ItemType = ListViewItemType.DataItem Then
            ' Get the data item (bill) associated with the item
            Dim dto As UtangQAppBLL.DTOs.Transaction.BillRecipientDTO = CType(e.Item.DataItem, UtangQAppBLL.DTOs.Transaction.BillRecipientDTO)
            Dim billRecipientID As Integer = Convert.ToInt32(DataBinder.Eval(dto, "BillRecipientID"))

            'Check if the bill recipient has payment
            Dim hasPayment As Boolean = CheckIfBillRecipientHasPayment(billRecipientID)

            If hasPayment Then
                Dim btnCreatePayment As Button = CType(e.Item.FindControl("btnCreatePayment"), Button)
                btnCreatePayment.Enabled = False
            End If
        End If
    End Sub
#End Region


End Class