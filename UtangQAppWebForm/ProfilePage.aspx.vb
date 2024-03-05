Imports UtangQAppBLL
Imports UtangQAppBLL.DTOs.User

Public Class ProfilePage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gvUserProfileBind()
        End If
    End Sub
    Private Sub gvUserProfileBind()
        Dim userBLL As New UserBLL()
        'Dim users As IEnumerable(Of UserDTO) = userBLL.GetAll()
        Dim user As UserDTO = userBLL.Get(8)
        'UserGridView.DataSource = users
        Dim userList As New List(Of UserDTO)
        userList.Add(user)
        ' Bind the List(Of UserDTO) to the GridView
        gvUserProfile.DataSource = userList
        gvUserProfile.DataBind()
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
    Protected Sub btnEditProfile_Click(sender As Object, e As EventArgs)
        GetEditProfile(8)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalEdit').modal('show');})", True)
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        Try
            Dim userBLL As New UserBLL()
            Dim user As UserDTO = userBLL.Get(8)
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
            gvUserProfileBind()

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
            userBLL.Delete(11)

            Response.Redirect("LoginPage.aspx")
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class