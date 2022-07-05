Public Partial Class Frm_ErrorHandler
    Inherits System.Web.UI.Page
    Dim oUpdate As New UpdateBase
    Protected Sub LogOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LogOut.Click
        'oUpdate.f_UpdateLogout(Session("UserID").ToString, Session("Entity"))
        Response.Redirect("Login.aspx")
    End Sub

End Class