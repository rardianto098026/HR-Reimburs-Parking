Imports System.Data.OleDb
Imports System.IO

Partial Public Class UploadDataKaryawan
    Inherits System.Web.UI.Page
    Dim uploadid As Integer
    Dim oSelect As New SelectBase
    Dim oInsert As New InsertBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub Alert()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" Then

            If txtUpload.PostedFile.FileName = "" Then
                lblErr_Upload.Visible = True
                lblErr_Upload.Text = "* Please choose the file you want to upload"

                Exit Sub
            End If

            Dim _total As String = UploadExcel()
            Dim message As String
            message = "Upload Data Sukses"

            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

        End If
    End Sub
    Private Function UploadExcel() As String
        Dim rows As Integer
        UploadData()
        Return rows
    End Function
    Public Function UploadData() As String
        Dim row, rows As Integer
        Dim da As New OleDbDataAdapter
        Dim dtImport As New DataTable
        Dim strFileName As String = txtUpload.PostedFile.FileName
        Dim filename As String = Path.GetFileName(strFileName)
        Dim new_path As String = Server.MapPath("Upload\") + filename
        ' Dim msgError As String
        'Dim row, rows, rowbsm, rowMCM As Integer
        row = 1
        rows = 0
        txtUpload.PostedFile.SaveAs(new_path)

        Dim strConn As String
        strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + new_path + ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;"""

        Dim conn As New OleDb.OleDbConnection(strConn)
        da = New OleDb.OleDbDataAdapter("Select * from [Sheet1$A1:P1000000]", conn)
        dtImport = New DataTable("ExcelFile")
        'Try
        'On Error Resume Next
        da.Fill(dtImport)

        lblErr_Upload.Visible = True
        lblErr_Upload.Text = "* Now Uploading..."

        Dim SINGLEORDOUBLE As String = "", SINGLEORDOUBLE_EXISTING As String = ""

        If dtImport.Rows.Count > 0 Then
            uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile(filename, Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)

            For Each dr As DataRow In dtImport.Rows
                If dr("NOPOL2 (FREE TEXT)").ToString <> "" Then
                    SINGLEORDOUBLE = "DOUBLE"
                Else
                    SINGLEORDOUBLE = ""
                End If

                If dr("NOPOL2 (EXISTING)").ToString <> "" Then
                    SINGLEORDOUBLE_EXISTING = "DOUBLE"
                Else
                    SINGLEORDOUBLE_EXISTING = "SINGLE"
                End If


                oInsert.f_INSERT_UPLOAD_DATA_REIMBURS(dr("ID").ToString, dr("NAMA").ToString, dr("NOPOL (EXISTING)").ToString,
                                                      dr("TYPE OF VEHICLE (EXISTING)").ToString, dr("NOPOL (FREE TEXT)").ToString, dr("NOPOL2 (FREE TEXT)").ToString, dr("TYPE OF VEHICLE (OTHER OPTION)").ToString, SINGLEORDOUBLE,
                                                      dr("PERIODE 1").ToString, dr("PERIODE 2").ToString, dr("PERIODE 3").ToString, dr("REMARKS").ToString,
                                                      Session("UserID").ToString, dr("ENTITY").ToString, uploadid, dr("RANGE_PERIODE").ToString, dr("NOPOL2 (EXISTING)").ToString, SINGLEORDOUBLE_EXISTING)
            Next
        End If
        'Catch ex As Exception
        'End Try

        Return row

    End Function
End Class