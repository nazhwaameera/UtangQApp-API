Imports UtangQAppBLL.DTOs.User
Imports UtangQAppBLL
Public Class RegistrationPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs)
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        Dim confirmPassword As String = txtConfirmPassword.Text
        Dim email As String = txtEmail.Text
        Dim fullName As String = txtFullName.Text
        Dim phoneNumber As String = txtPhoneNumber.Text

        If password = confirmPassword Then
            ' Passwords match, continue with registration process
            lblPasswordMatchError.Visible = False

            Dim userBLL As New UserBLL()
            Dim userCreateDTO As New UserCreateDTO() With
            {
                .Username = username,
                .UserPassword = password,
                .UserEmail = email,
                .UserFullName = fullName,
                .UserPhoneNumber = phoneNumber
            }
            userBLL.Create(userCreateDTO)
            Response.Redirect("LoginPage.aspx")
        Else
            ' Passwords don't match, display error message
            lblPasswordMatchError.Visible = True
            lblPasswordMatchError.Text = "Passwords do not match."
        End If


    End Sub
End Class