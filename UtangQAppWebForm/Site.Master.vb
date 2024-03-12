Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("IsLoggedIn") IsNot Nothing AndAlso Session("IsLoggedIn").ToString() = "True" Then
            If Not IsPostBack Then
                If Session("Username") IsNot Nothing Then
                    ' Set the username to the appropriate control
                    lblUsername.Text = Session("Username").ToString()
                End If
            End If
        Else
            Response.Redirect("LoginPage.aspx")
        End If
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs)
        ' Clear session variables
        Session.Clear()
        Session.Abandon()

        ' Redirect to login page
        Response.Redirect("LoginPage.aspx")
    End Sub
End Class