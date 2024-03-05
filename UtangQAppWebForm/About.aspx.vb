Imports UtangQAppBLL
Imports UtangQAppBLL.DTOs.User

Public Class About
    Inherits Page

    Dim userBLL As New UserBLL()
    Dim billBLL As New BillBLL()
    Dim walletBLL As New WalletBLL()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            UserBindGrid()
            UserBillBindGrid()
            AllBillsBindGrid()
            AllWalletsBindGrid()
        End If
    End Sub

    Private Sub UserBindGrid()
        'Dim users As IEnumerable(Of UserDTO) = userBLL.GetAll()
        Dim user As UserDTO = userBLL.Get(8)
        'UserGridView.DataSource = users
        Dim userList As New List(Of UserDTO)
        userList.Add(user)
        ' Bind the List(Of UserDTO) to the GridView
        UserGridView.DataSource = userList
        UserGridView.DataBind()
    End Sub

    Private Sub UserBillBindGrid()
        Dim bills As IEnumerable(Of BillDTO) = billBLL.ReadUserBills(8)
        UserBillGridView.DataSource = bills
        UserBillGridView.DataBind()


        If UserBillGridView.Rows.Count = 0 Then
            ' Show a message or perform any other action to indicate that there are no records
            lblMessage.Text = "No bills found for this user."
        End If
    End Sub

    Private Sub AllBillsBindGrid()
        Dim bills As IEnumerable(Of BillDTO) = billBLL.GetAll()
        AllBillsGridView.DataSource = bills
        AllBillsGridView.DataBind()

        If AllBillsGridView.Rows.Count = 0 Then
            ' Show a message or perform any other action to indicate that there are no records
            lblMessageAllBills.Text = "No bills found."
        End If
    End Sub

    Private Sub AllWalletsBindGrid()
        Dim wallets As IEnumerable(Of WalletDTO) = walletBLL.GetAll()
        AllWalletsGridView.DataSource = wallets
        AllWalletsGridView.DataBind()

        If AllWalletsGridView.Rows.Count = 0 Then
            ' Show a message or perform any other action to indicate that there are no records
            lblMessageAllWallets.Text = "No wallets found."
        End If
    End Sub

End Class