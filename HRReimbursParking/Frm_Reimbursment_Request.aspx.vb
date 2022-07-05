Imports System.IO
Public Class Frm_Reimbursment_Request
    Inherits System.Web.UI.Page
    Dim oInsert As New InsertBase
    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase
    Dim UploadId As Integer

    Dim Checklist1 As Boolean
    Dim Checklist2 As Boolean
    Dim Checklist3 As Boolean
    Dim JumlahPeriod As String = ""

    Sub Get_Data_Employee()
        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LOAD_DATA_PARKING(Session("EMPLNUMBER").ToString)
        If dtSelect.Rows.Count > 0 Then
            lblEmplID.Text = dtSelect.Rows(0)("IDKaryawan").ToString()
            lblName.Text = dtSelect.Rows(0)("NamaKaryawan").ToString()
            lblEntity.Text = dtSelect.Rows(0)("Entity").ToString()
        End If
    End Sub
    Sub LoadVehicle()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GET_TYPE_VEHICLE()
        If dtCrit2.Rows.Count > 0 Then

            ddl_tipekendaraan.DataSource = dtCrit2
            ddl_tipekendaraan.DataValueField = "Vehicle"
            ddl_tipekendaraan.DataTextField = "Vehicle"
            ddl_tipekendaraan.DataBind()

            ddl_tipekendaraan.Items.Insert(0, New ListItem("--Choose--", "0"))

        End If
    End Sub
    'Sub GetAmount()
    '    Dim dtCrit2 As New DataTable
    '    dtCrit2 = oSelect.f_SEL_GET_AMOUNT_BY_VEHICLE(ddl_tipekendaraan.SelectedItem.Text)
    '    If dtCrit2.Rows.Count > 0 Then
    '        txtamount2.Text = dtCrit2.Rows(0)("Amount").ToString()
    '    End If
    'End Sub
    'Sub LoadQuarter()
    '    Dim dtCrit2 As New DataTable
    '    dtCrit2 = oSelect.f_SEL_GET_MONTH_QUARTER()
    '    If dtCrit2.Rows.Count > 0 Then

    '        ddlrangeperiod.DataSource = dtCrit2
    '        ddlrangeperiod.DataValueField = "Month"
    '        ddlrangeperiod.DataTextField = "Month"
    '        ddlrangeperiod.DataBind()

    '        ddlrangeperiod.Items.Insert(0, New ListItem("--Choose--", "0"))

    '    End If
    'End Sub

    'Sub GetTotalAmount()
    '    Checklist1 = period1.Checked
    '    Checklist2 = period2.Checked
    '    Checklist3 = period3.Checked

    '    If Checklist1 = True And Checklist2 = True And Checklist3 = True Then
    '        JumlahPeriod = 3
    '    End If

    '    If Checklist1 = True And Checklist2 = True And Checklist3 = False Then
    '        JumlahPeriod = 2
    '    End If

    '    If Checklist1 = True And Checklist2 = False And Checklist3 = False Then
    '        JumlahPeriod = 1
    '    End If

    '    If Checklist1 = False And Checklist2 = False And Checklist3 = False Then
    '        JumlahPeriod = 0
    '    End If


    '    Dim dtCrit2 As New DataTable
    '    dtCrit2 = oSelect.f_SEL_GET_TOTAL_AMOUNT(ddl_tipekendaraan.SelectedItem.Text, JumlahPeriod)
    '    If dtCrit2.Rows.Count > 0 Then
    '        txttotalamount.Text = dtCrit2.Rows(0)("TotalAmount").ToString()
    '    End If
    'End Sub
    Sub GetTotalDays()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GET_TOTAL_DAYS(txtdatefrom.Text, txtdateto.Text)
        If dtCrit2.Rows.Count > 0 Then
            txttotalday.Text = dtCrit2.Rows(0)("TotalDays").ToString()
        End If
    End Sub
    Sub cek_max_dateto()
        Dim DT_CHECK As New DataTable
        DT_CHECK = oSelect.f_CEK_DATE_TO(Session("EMPLNUMBER"), txtdateto.Text, "", "")
        If DT_CHECK.Rows(0)("COUNT_DATETO") = "0" Then
            Dim message2 As String
            Dim sb2 As New System.Text.StringBuilder()

            message2 = "PILIH TANGGAL DATE TO YANG LAIN"
            sb2.Append("<script type = 'text/javascript'>")
            sb2.Append("window.onload=function(){")
            sb2.Append("alert('")
            sb2.Append(message2)
            sb2.Append("')};")
            sb2.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
            txtdateto.Text = ""
            Exit Sub
        End If
    End Sub

    Sub cek_max_datefrom()
        Dim DT_CHECK As New DataTable
        DT_CHECK = oSelect.f_CEK_DATE_FROM(Session("EMPLNUMBER"), txtdatefrom.Text, "", "")
        If DT_CHECK.Rows(0)("COUNT_DATEFROM") = "0" Then
            Dim message2 As String
            Dim sb3 As New System.Text.StringBuilder()

            message2 = "PILIH TANGGAL DATE FROM YANG LAIN"
            sb3.Append("<script type = 'text/javascript'>")
            sb3.Append("window.onload=function(){")
            sb3.Append("alert('")
            sb3.Append(message2)
            sb3.Append("')};")
            sb3.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            txtdatefrom.Text = ""
            Exit Sub
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Get_Data_Employee()
            LoadVehicle()
            'LoadQuarter()
        End If
    End Sub
    Protected Sub ddl_tipekendaraan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_tipekendaraan.SelectedIndexChanged
        'GetAmount()

        If ddl_tipekendaraan.SelectedItem.Text = "Car" Then
            trSingle.Visible = True
        ElseIf ddl_tipekendaraan.SelectedItem.Text = "Motorcycle" Then
            trNoPol1.Visible = True
            trSingle.Visible = False
            trNoPol2.Visible = False
            ddlsingledouble.SelectedIndex = ddlsingledouble.Items.IndexOf(ddlsingledouble.Items.FindByText("--Choose--"))
            txtnopol2.Text = ""
        End If

        'GetTotalAmount()
    End Sub
    Protected Sub ddlsingledouble_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlsingledouble.SelectedIndexChanged
        If ddlsingledouble.SelectedItem.Text = "SINGLE" Then
            trNoPol1.Visible = True
            trNoPol2.Visible = False
            txtnopol2.Text = ""
        ElseIf ddlsingledouble.SelectedItem.Text = "DOUBLE" Then
            trNoPol1.Visible = True
            trNoPol2.Visible = True
            Exit Sub
        End If

        Selected2()
    End Sub
    Protected Sub txtdatefrom_TextChanged(sender As Object, e As EventArgs) Handles txtdatefrom.TextChanged
        cek_max_datefrom()
        If Not txtdatefrom.Text = "" Then
            GetTotalDays()
        End If
    End Sub
    Protected Sub txtdateto_TextChanged(sender As Object, e As EventArgs) Handles txtdateto.TextChanged
        cek_max_dateto()
        If Not txtdateto.Text = "" Then
            GetTotalDays()
        End If
    End Sub


    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                Dim extension1 As String = (Path.GetExtension(txtUpload.PostedFile.FileName)).ToUpper
                Dim message2 As String
                Dim sb2 As New System.Text.StringBuilder()
                Alert()

                'Dim Counting As String = ""
                'Dim dtCrit2 As New DataTable
                'dtCrit2 = oSelect.f_SEL_GET_COUNT_REIMBURS_EMPLOYEE(lblEmplID.Text, ddlyear.SelectedItem.Text)

                'If dtCrit2.Rows.Count > 0 Then
                '    Counting = dtCrit2.Rows(0)("Counting").ToString()
                'End If

                'If Counting >= 1 Then
                '    message2 = "Data Already Submit"
                '    sb2.Append("<script type = 'text/javascript'>")
                '    sb2.Append("window.onload=function(){")
                '    sb2.Append("alert('")
                '    sb2.Append(message2)
                '    sb2.Append("')};")
                '    sb2.Append("</script>")
                '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                '    Exit Sub
                'End If

                If txtUpload.HasFile Then
                    If extension1 <> ".PDF" Then
                        message2 = "Please Choose PDF File Only"
                        sb2.Append("<script type = 'text/javascript'>")
                        sb2.Append("window.onload=function(){")
                        sb2.Append("alert('")
                        sb2.Append(message2)
                        sb2.Append("')};")
                        sb2.Append("</script>")
                        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                        Exit Sub
                    End If

                ElseIf txtUpload.HasFile = False Then

                    message2 = "Please Choose File"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

                    Exit Sub
                End If

                'Dim dtval As New DataTable
                'Dim id As String = lblEmplID.Text
                'Dim name As String = lblName.Text
                ''Dim period As String = ddlrangeperiod.SelectedItem.Text
                'Dim year As String = ddlyear.SelectedItem.Text
                'dtval = oSelect.f_VALIDATION(lblEmplID.Text, lblName.Text, ddlyear.SelectedItem.Text)
                'If Not dtval.Rows.Count = 0 Then
                '    message2 = "Please Use Another Period or Year"
                '    sb2.Append("<script type = 'text/javascript'>")
                '    sb2.Append("window.onload=function(){")
                '    sb2.Append("alert('")
                '    sb2.Append(message2)
                '    sb2.Append("')};")
                '    sb2.Append("</script>")
                '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                '    Exit Sub
                'Else

                'lblmandatory.Visible = False

                Dim folders As String = Server.MapPath("~/Upload/" + lblEntity.Text + "/" + ddlyear.SelectedItem.Text)

                    If (Not System.IO.Directory.Exists(folders)) Then
                        System.IO.Directory.CreateDirectory(folders)
                    End If

                    Dim newfile As String = lblEmplID.Text + "_" + "Reimburs.pdf"

                    Dim theFileName As String = Path.Combine(Server.MapPath("~/Upload/" + lblEntity.Text + "/" + ddlyear.SelectedItem.Text + "/"), newfile)

                    If File.Exists(folders) And txtUpload.HasFile Then
                        My.Computer.FileSystem.DeleteFile(theFileName)
                    End If

                    txtUpload.SaveAs(theFileName)
                    oInsert.f_INSERT_TRN_REIMBURSMENT_PARKING_EMPLOYEE(lblEmplID.Text, lblName.Text, lblEntity.Text, ddl_tipekendaraan.SelectedItem.Text,
                                                                           txtnopol1.Text, txtnopol2.Text, ddlsingledouble.SelectedItem.Text,
                                                                           Convert.ToDecimal(txttotalamount.Text), txtdatefrom.Text, txtdateto.Text, ddlyear.SelectedItem.Text,
                                                                           txttotalday.Text, 0.00, txtremarks.Text, Session("UserID").ToString, "", "0", "")

                    'message2 = "Submitted Data Success"
                    'sb2.Append("<script type = 'text/javascript'>")
                    'sb2.Append("window.onload=function(){")
                    'sb2.Append("alert('")
                    'sb2.Append(message2)
                    'sb2.Append("')};")
                    'sb2.Append("</script>")
                    'ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

                    'Response.Redirect("Frm_List_Reimbursment_Request.aspx")

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(),
                    "alert",
                    "alert('Submitted Data Success');window.location ='Frm_List_Reimbursment_Request.aspx';",
                    True)
                End If
            'End If

        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub period1_CheckedChanged(sender As Object, e As EventArgs) Handles period1.CheckedChanged
    '    GetTotalAmount()
    'End Sub
    'Protected Sub period2_CheckedChanged(sender As Object, e As EventArgs) Handles period2.CheckedChanged
    '    GetTotalAmount()
    'End Sub
    'Protected Sub period3_CheckedChanged(sender As Object, e As EventArgs) Handles period3.CheckedChanged
    '    GetTotalAmount()
    'End Sub
    Private Shared Function GetIntOnly(ByVal value As String) As Integer
        Dim returnVal As String = String.Empty
        Dim collection As MatchCollection = Regex.Matches(value, "\d+")
        For Each m As Match In collection
            returnVal += m.ToString()
        Next
        Return Convert.ToInt32(returnVal)
    End Function
    Sub Selected2()
        If ddlsingledouble.SelectedItem.Text = "DOUBLE" Then
            trNoPol2.Visible = True
            Textbox2.Visible = True
            NoPol4.Visible = True
            If txtnopol2.Text = "" Then
                txtnopol2.Text = ""
                Textbox2.Text = ""
            End If

            txtnopol1.BackColor = Drawing.Color.White
            txtnopol2.BackColor = Drawing.Color.White
        Else
            Textbox2.Visible = False
            NoPol4.Visible = True
            trNoPol2.Visible = False
            txtnopol2.Text = ""
            Textbox2.Text = ""
            txtnopol1.BackColor = Drawing.Color.White
            txtnopol2.BackColor = Drawing.Color.White
        End If

        If ddlsingledouble.SelectedItem.Text.ToUpper() = "DOUBLE" Then

            Dim tabID2 As Integer = GetIntOnly(txtnopol1.Text)
            If Right(tabID2, 1) Mod 2 = 0 Then
                NoPol4.Text = "Even"
            Else
                NoPol4.Text = "Odd"
            End If
        End If
    End Sub
    Public Sub Alert_Add()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Protected Sub txtnopol1_TextChanged(sender As Object, e As EventArgs) Handles txtnopol1.TextChanged
        If txtnopol1.Text <> "" And ddl_tipekendaraan.SelectedItem.Text.ToUpper() = "CAR" Then
            NoPol4.Visible = True
            Dim tabID2 As Integer = GetIntOnly(txtnopol1.Text)
            If Right(tabID2, 1) Mod 2 = 0 Then
                NoPol4.Text = "Even"
            Else
                NoPol4.Text = "Odd"
            End If
            NoPol4.Visible = True
        Else
            NoPol4.Text = ""
            NoPol4.Visible = False
        End If

        If (NoPol4.Text = "Even" And Textbox2.Text = "Even") Or (NoPol4.Text = "Odd" And Textbox2.Text = "Odd") Then
            btnSubmit.Enabled = False
            txtnopol1.BackColor = Drawing.Color.Red
            txtnopol2.BackColor = Drawing.Color.Red

            Dim message2 As String

            message2 = "Cannot Input double Even/Odd No. Pol"
            Dim sb2 As New System.Text.StringBuilder()
            sb2.Append("<script type = 'text/javascript'>")
            sb2.Append("window.onload=function(){")
            sb2.Append("alert('")
            sb2.Append(message2)
            sb2.Append("')};")
            sb2.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
        Else
            txtnopol1.BackColor = Drawing.Color.White
            txtnopol2.BackColor = Drawing.Color.White
            btnSubmit.Enabled = True
        End If
    End Sub
    Protected Sub txtnopol2_TextChanged(sender As Object, e As EventArgs) Handles txtnopol2.TextChanged
        If txtnopol2.Text <> "" And ddl_tipekendaraan.SelectedItem.Text.ToUpper() = "CAR" And ddlsingledouble.SelectedItem.Text.ToUpper() = "DOUBLE" Then
            Dim tabID2 As Integer = GetIntOnly(txtnopol2.Text)
            If Right(tabID2, 1) Mod 2 = 0 Then
                Textbox2.Text = "Even"
            Else
                Textbox2.Text = "Odd"
            End If
            Textbox2.Visible = True
        Else
            Textbox2.Text = ""
            Textbox2.Visible = False
        End If

        If (NoPol4.Text = "Even" And Textbox2.Text = "Even") Or (NoPol4.Text = "Odd" And Textbox2.Text = "Odd") Then
            btnSubmit.Enabled = False
            txtnopol1.BackColor = Drawing.Color.Red
            txtnopol2.BackColor = Drawing.Color.Red

            Dim message2 As String

            message2 = "Cannot Input double Even/Odd No. Pol"
            Dim sb2 As New System.Text.StringBuilder()
            sb2.Append("<script type = 'text/javascript'>")
            sb2.Append("window.onload=function(){")
            sb2.Append("alert('")
            sb2.Append(message2)
            sb2.Append("')};")
            sb2.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
        Else
            txtnopol1.BackColor = Drawing.Color.White
            txtnopol2.BackColor = Drawing.Color.White
            btnSubmit.Enabled = True
        End If
    End Sub
    Protected Sub Alert()
        Dim message2 As String
        If ((ddl_tipekendaraan.SelectedValue.ToString = "0")) Then

            message2 = "Please Choose Type Vehicle"
            Dim sb2 As New System.Text.StringBuilder()
            sb2.Append("<script type = 'text/javascript'>")
            sb2.Append("window.onload=function(){")
            sb2.Append("alert('")
            sb2.Append(message2)
            sb2.Append("')};")
            sb2.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
            Exit Sub
        End If

        If ((ddlyear.SelectedValue.ToString = "0")) Then

            message2 = "Please Choose Year"
            Dim sb2 As New System.Text.StringBuilder()
            sb2.Append("<script type = 'text/javascript'>")
            sb2.Append("window.onload=function(){")
            sb2.Append("alert('")
            sb2.Append(message2)
            sb2.Append("')};")
            sb2.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
            Exit Sub
        End If
        'If period1.Checked = False Then

        '    message2 = "Please Choose Period"
        '    Dim sb2 As New System.Text.StringBuilder()
        '    sb2.Append("<script type = 'text/javascript'>")
        '    sb2.Append("window.onload=function(){")
        '    sb2.Append("alert('")
        '    sb2.Append(message2)
        '    sb2.Append("')};")
        '    sb2.Append("</script>")
        '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
        '    Exit Sub
        'End If

    End Sub

End Class