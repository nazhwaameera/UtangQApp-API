Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if the username is stored in session
            If Session("Username") IsNot Nothing Then
                ' Set the username to the appropriate control
                lblUsername.Text = Session("Username").ToString()
            End If
        End If
    End Sub
End Class