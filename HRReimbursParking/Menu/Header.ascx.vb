Public Partial Class Header
    Inherits System.Web.UI.UserControl
    Dim oUpdate As New UpdateBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Session("UserID").ToString = "Administrator" Then
                lblGreet.Text = Session("UserID").ToString
                LBLEmplNumber.Text = Session("EMPLNUMBER")
            Else
                lblGreet.Text = Session("UserID").ToString
                LBLEmplNumber.Text = Session("EMPLNUMBER")
            End If
            If Session("Entity") = "AMFS" Then
                imgAXA.Src = "mandiri-axa.png"
            Else
                imgAXA.Src = "AXA-Banner.png"
            End If
        Catch ex As Exception
            Response.Redirect("Frm_ErrorHandler.aspx")
        End Try
    End Sub

    Protected Sub LogOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LogOut.Click
        'Response.Redirect("Login.aspx")
        oUpdate.f_UpdateLogout(Session("UserID").ToString, Session("Entity"))
        Session.Remove("UserID")
        Session.Remove("Entity")
        Session.Remove("UserName")
        Session.Remove("EMPLNUMBER")
        'Session.Remove("EMPLNUMBER")
        Session.Remove("ROLES")
        Response.Redirect("Login.aspx")
    End Sub
End Class