Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Web.UI
Imports System.Web
Imports System.DirectoryServices
Imports System.Data.SqlClient
Partial Public Class AddMasterMenu
    Inherits System.Web.UI.Page
    Dim oInsert As New InsertBase

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If txtMenuName.Text = "" Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "Menu Name Must be Filled")
        Else
            oInsert.f_Insert_Mst_Menu(txtMenuName.Text, Session("Entity"))

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect", _
            "alert('Save Data Sukses'); window.location='~/AddMasterMenuChild.aspx';", True)

        End If
    End Sub

    Protected Sub btnChild_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChild.Click
        Response.Redirect("~/AddMasterMenuChild.aspx")
    End Sub


End Class