
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Web.UI
Imports System.Web
Imports System.DirectoryServices
Imports System.Data.SqlClient
Partial Public Class AddMasterMenuChild
    Inherits System.Web.UI.Page
    Dim oInsert As New InsertBase

    Dim _connectionString_AFI As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim conn As SqlConnection
    Sub populate()
        Dim cmd As SqlCommand
        Dim ssql As String
        ssql = ("SELECT IDMenu,MenuName FROM MST_MENU")
        conn.Open()
        cmd = New SqlClient.SqlCommand(ssql, conn)
        Dim sdr As SqlDataReader = cmd.ExecuteReader()

        If sdr.HasRows Then
            ddl_Mst_Menu.DataSource = sdr
            ddl_Mst_Menu.DataValueField = "IDMenu"
            ddl_Mst_Menu.DataTextField = "MenuName"
            ddl_Mst_Menu.DataBind()
            ddl_Mst_Menu.Items.Insert(0, New ListItem("--Select--", "0"))
            'ddl_Mst_Menu.SelectedIndex = 0
        End If

        conn.Close()
        cmd.Dispose()
        sdr.Close()



    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If txtMenuChildName.Text = "" And txtPath.Text = "" Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "All Coloum Must be Filled")
        ElseIf txtMenuChildName.Text = "" And txtPath.Text <> "" Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "Menu Name Must be Filled")
        ElseIf txtMenuChildName.Text <> "" And txtPath.Text = "" Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "Path Must be Filled")
        Else
            If ddl_Mst_Menu.SelectedValue <> "0" Then
                oInsert.f_Insert_Mst_Menu_Child(txtMenuChildName.Text, txtPath.Text, ddl_Mst_Menu.SelectedValue, Session("Entity"))
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect", _
                "alert('Save Data Sukses'); window.location='/AddMasterMenuChild.aspx';", True)
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "Master Menu Must be Choosed")
            End If

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            conn = New SqlClient.SqlConnection(_connectionString_AFI)

            populate()
        End If

    End Sub

End Class
