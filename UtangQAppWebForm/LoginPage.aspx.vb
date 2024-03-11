Imports UtangQAppBLL.DTOs.User
Imports UtangQAppBLL
Public Class LoginPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        Dim userBLL As New UserBLL()
        ' Authenticate user
        Dim userLogin As UserDTO = userBLL.LoginUser(username, password)

        If userLogin IsNot Nothing Then
            If Not userLogin.IsLocked Then
                ' Authentication successful, set session variables and redirect to homepage
                Session("FailedLoginAttempts") = 0
                Session("UserID") = userLogin.UserID
                Session("Username") = userLogin.Username
                Session("IsLoggedIn") = True
                Session("LoginTime") = DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy")

                Response.Redirect("DashboardPage.aspx")
            Else
                lblErrorMessage.Text = "Your account has been locked. Please contact support."
                lblErrorMessage.Visible = True
            End If
        Else
            Dim failedAttempts As Integer = If(Session("FailedLoginAttempts") IsNot Nothing, Convert.ToInt32(Session("FailedLoginAttempts")), 0)

            ' Authentication failed, display error message
            lblErrorMessage.Text = "Invalid username or password. Please try again."
            lblErrorMessage.Visible = True

            ' Clear username and password fields
            txtUsername.Text = ""
            txtPassword.Text = ""

            'Increment the failedAttempts variable
            failedAttempts += 1
            Session("FailedLoginAttempts") = failedAttempts

            If failedAttempts >= 3 Then
                Session.Clear()
                ' Lock the user account
                Try
                    Dim user As UserDTO = userBLL.GetByUsername(username)
                    Dim userUpdate As New UserDTO
                    userUpdate.UserID = user.UserID
                    userUpdate.Username = user.Username
                    userUpdate.UserPassword = user.UserPassword
                    userUpdate.UserEmail = user.UserEmail
                    userUpdate.UserFullName = user.UserFullName
                    userUpdate.UserPhoneNumber = user.UserPhoneNumber
                    userUpdate.IsLocked = True

                    userBLL.Update(userUpdate)

                    lblErrorMessage.Text = "Your account has been locked. Please contact support."
                    lblErrorMessage.Visible = True

                Catch ex As Exception
                    Throw ex
                    lblErrorMessage.Text = "Your Username doesn't exist. Please create an account."
                    lblErrorMessage.Visible = True
                End Try
            End If
        End If

    End Sub

End Class