Imports UtangQAppBLL
Imports UtangQAppBLL.DTOs.User

Public Class ProfilePage
    Inherits System.Web.UI.Page

    Dim walletBll As New WalletBLL()
    Dim billRecipientBLL As New BillRecipientBLL()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim userId As Integer = Session("UserID")
            gvUserProfileBind(userId)
            LoadDataWallet(userId)
        End If
    End Sub


#Region "Binding Data"
    Private Sub gvUserProfileBind(userId)
        Dim userBLL As New UserBLL()
        'Dim users As IEnumerable(Of UserDTO) = userBLL.GetAll()
        Dim user As UserDTO = userBLL.Get(userId)
        'UserGridView.DataSource = users
        Dim userList As New List(Of UserDTO)
        userList.Add(user)
        ' Bind the List(Of UserDTO) to the GridView
        gvUserProfile.DataSource = userList
        gvUserProfile.DataBind()
    End Sub

    Sub LoadDataWallet(userId)
        Dim wallet As WalletDTO = walletBll.ReadWalletbyUserID(userId)
        If wallet IsNot Nothing Then
            btnDeleteWallet.Visible = True
            hidWalletID_ModalDelete.Value = wallet.WalletID
            Label2.Text = hidWalletID_ModalDelete.Value
        End If
    End Sub

    Sub GetEditProfile(id As Integer)
        Dim userBLL As New UserBLL()
        Dim user As UserDTO = userBLL.Get(id)

        Try
            If user IsNot Nothing Then
                txtUsernameEdit.Text = user.Username
                txtUserEmailEdit.Text = user.UserEmail
                txtUserFullNameEdit.Text = user.UserFullName
                txtUserPhoneNumberEdit.Text = user.UserPhoneNumber
            Else
                ' Show a message or perform any other action to indicate that there are no records
                ltMessage.Visible = True
                ltMessage.Text = "<span class='alert alert-danger'>Error: No user found.</span><br/><br/>"
            End If
        Catch ex As Exception
            ltMessage.Visible = True
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

#End Region

#Region "Handling Button"
    Protected Sub btnEditProfile_Click(sender As Object, e As EventArgs)
        GetEditProfile(Session("UserID"))
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalEdit').modal('show');})", True)
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        Try
            Dim userBLL As New UserBLL()
            Dim user As UserDTO = userBLL.Get(Session("UserID"))
            Dim userUpdate As New UserDTO
            userUpdate.UserID = user.UserID
            userUpdate.Username = txtUsernameEdit.Text
            userUpdate.UserPassword = user.UserPassword
            userUpdate.UserEmail = txtUserEmailEdit.Text
            userUpdate.UserFullName = txtUserFullNameEdit.Text
            userUpdate.UserPhoneNumber = txtUserPhoneNumberEdit.Text
            userUpdate.IsLocked = user.IsLocked
            userBLL.Update(userUpdate)

            gvUserProfile.DataBind()
            gvUserProfileBind(Session("UserID"))

            ltMessage.Visible = True
            ltMessage.Text = "<span class='alert alert-success'>User profile updated successfully</span><br/><br/>"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#myModalEdit').modal('hide');", True)
        Catch ex As Exception
            ltMessage.Visible = True
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try

    End Sub

    Protected Sub btnDeleteAccount_Click(sender As Object, e As EventArgs)
        lblConfirmationMessage.Text = "Are you sure to delete this account? "
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalDelete').modal('show');})", True)
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs)
        Try
            Dim userBLL As New UserBLL()
            userBLL.Delete(Session("UserID"))

            Response.Redirect("LoginPage.aspx")
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub btnDeleteWallet_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalDeleteWallet').modal('show');})", True)
    End Sub

    Protected Sub btnDeleteWalletModal_Click(sender As Object, e As EventArgs)
        Try
            walletBll.Delete(hidWalletID_ModalDelete.Value)

            LoadDataWallet(Session("UserID"))
            ltMessage.Visible = True
            ltMessage.Text = "<span class='alert alert-success'>Bill deleted successfully</span><br/><br/>"
        Catch ex As Exception
            ltMessage.Visible = True
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
#End Region



End Class