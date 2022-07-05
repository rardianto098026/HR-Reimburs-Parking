Imports System.Globalization
Imports System.IO
Imports System.Net
Public Class Frm_Reimbursment_Employee
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase
    Dim oInsert As New InsertBase

    Dim Checklist1 As Boolean
    Dim Checklist2 As Boolean
    Dim Checklist3 As Boolean
    Dim JumlahPeriod As String = ""

    Sub bindData(ByVal IDX As String)
        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LOAD_DATA_REIMBURSMENT_REQUEST(IDX)
        If dtSelect.Rows.Count > 0 Then
            lblEmplID.Text = dtSelect.Rows(0)("Employee_ID").ToString()
            lblName.Text = dtSelect.Rows(0)("Employee_Name").ToString()
            lblEntity.Text = dtSelect.Rows(0)("Entity").ToString()
            ddl_tipekendaraan.SelectedIndex = ddl_tipekendaraan.Items.IndexOf(ddl_tipekendaraan.Items.FindByText(dtSelect.Rows(0)("Type_Vehicle").ToString()))
            'txtamount2.Text = dtSelect.Rows(0)("Amount").ToString()
            txtnopol1.Text = dtSelect.Rows(0)("NoPol_1").ToString()
            txtnopol2.Text = dtSelect.Rows(0)("NoPol_2").ToString()
            ddlsingledouble.SelectedIndex = ddlsingledouble.Items.IndexOf(ddlsingledouble.Items.FindByText(dtSelect.Rows(0)("SingleOrDouble").ToString()))
            If ddl_tipekendaraan.SelectedItem.Text = "Car" Then
                trSingle.Visible = True
            ElseIf ddl_tipekendaraan.SelectedItem.Text = "Motorcycle" Then
                trNoPol1.Visible = True
                trSingle.Visible = False
                trNoPol2.Visible = False
                ddlsingledouble.SelectedIndex = ddlsingledouble.Items.IndexOf(ddlsingledouble.Items.FindByText("--Choose--"))
                txtnopol2.Text = ""
            End If

            Selected2()
            'ddlrangeperiod.SelectedIndex = ddlrangeperiod.Items.IndexOf(ddlrangeperiod.Items.FindByText(dtSelect.Rows(0)("RangePeriod").ToString()))

            'Dim Checklist1 As String = dtSelect.Rows(0)("Period_1").ToString()
            'Dim Checklist2 As String = dtSelect.Rows(0)("Period_2").ToString()
            'Dim Checklist3 As String = dtSelect.Rows(0)("Period_3").ToString()

            'If Checklist1 = True Then
            '    period1.Checked = True
            'End If
            'If Checklist2 = True Then
            '    period2.Checked = True
            'End If
            'If Checklist3 = True Then
            '    period3.Checked = True
            'End If

            txttotalamount.Text = dtSelect.Rows(0)("Total_Amount").ToString()
            Dim Date_From As Date = dtSelect.Rows(0)("Date_From")
            Dim Date_To As Date = dtSelect.Rows(0)("Date_To")
            txtdatefrom.Text = dtSelect.Rows(0)("date_from_2")
            txtdateto.Text = dtSelect.Rows(0)("Date_To_2")
            ddlyear.SelectedIndex = ddlyear.Items.IndexOf(ddlyear.Items.FindByText(dtSelect.Rows(0)("Year").ToString()))
            txttotalday.Text = dtSelect.Rows(0)("Total_Days").ToString()
            txtremarks.Text = dtSelect.Rows(0)("Remarks").ToString()

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

            LinkDwn1.Text = lblEmplID.Text + "_" + "Reimburs.pdf"
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
    
    Public Sub Alert_Edit()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Sub GetTotalDays()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GET_TOTAL_DAYS(txtdatefrom.Text, txtdateto.Text)
        If dtCrit2.Rows.Count > 0 Then
            txttotalday.Text = dtCrit2.Rows(0)("TotalDays").ToString()
        End If
    End Sub
    Sub cek_max_dateto()
        Dim DT_CHECK As New DataTable
        DT_CHECK = oSelect.f_CEK_DATE_TO(Session("EMPLNUMBER"), txtdateto.Text)
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
        DT_CHECK = oSelect.f_CEK_DATE_FROM(Session("EMPLNUMBER"), txtdatefrom.Text)
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
    Private Shared Function GetIntOnly(ByVal value As String) As Integer
        Dim returnVal As String = String.Empty
        Dim collection As MatchCollection = Regex.Matches(value, "\d+")
        For Each m As Match In collection
            returnVal += m.ToString()
        Next
        Return Convert.ToInt32(returnVal)
    End Function
    Sub countData()
        Dim COUNTING_DATA As Integer
        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_CHECK_DATA(Session("EMPLNUMBER").ToString)
        If dtSelect.Rows.Count > 0 Then
            COUNTING_DATA = Convert.ToInt32(dtSelect.Rows(0)("COUNTING").ToString())
            If COUNTING_DATA > 0 Then
                Label7.Visible = True
            Else
                Label7.Visible = False
            End If
        Else
            Label7.Visible = False
        End If

    End Sub

    'Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
    '    Dim path As String = Server.MapPath("~/Upload/" + lblEntity.Text + "/" + ddlyear.SelectedItem.Text + "/" + Session("EMPLNUMBER").ToString() + "_Reimburs.pdf")
    '    Dim url As String = "/Upload/" + lblEntity.Text + "/" + ddlyear.SelectedItem.Text + "/" + Session("EMPLNUMBER").ToString() + "_Reimburs.pdf"


    '    Dim sb As New StringBuilder()
    '    sb.Append(" <Script type = 'text/javascript'>")
    '    sb.Append("window.open('")
    '    sb.Append(url)
    '    sb.Append("');")
    '    sb.Append("</script>")
    '    ClientScript.RegisterStartupScript(Me.GetType(),
    '              "script", sb.ToString())

    '    'Dim client As New WebClient()
    '    'Dim buffer As [Byte]() = client.DownloadData(path)

    '    'If buffer IsNot Nothing Then
    '    '    Response.ContentType = "application/pdf"
    '    '    Response.AddHeader("content-length", buffer.Length.ToString())
    '    '    Response.BinaryWrite(buffer)

    '    'End If
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadVehicle()
            'LoadQuarter()
            Session("_idx") = Request.QueryString("idx").ToString
            bindData(Session("_idx"))
            countData()
            SINGLEDOUBLE()
            ddl_tipekendaraan_CHANGED()
            txtnopol1_TextChanged()
            txtnopol2_TextChanged()
        End If
    End Sub


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Try
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then
                Dim extension1 As String = (Path.GetExtension(txtUpload.PostedFile.FileName)).ToUpper
                Dim message2 As String
                Dim sb2 As New System.Text.StringBuilder()

                'If txtUpload.HasFile Then
                '    If extension1 <> ".PDF" Then
                '        message2 = "Please Choose PDF File Only"
                '        sb2.Append("<script type = 'text/javascript'>")
                '        sb2.Append("window.onload=function(){")
                '        sb2.Append("alert('")
                '        sb2.Append(message2)
                '        sb2.Append("')};")
                '        sb2.Append("</script>")
                '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                '        Exit Sub
                '    End If

                'ElseIf txtUpload.HasFile = False Then

                '    message2 = "Please Choose File"
                '    sb2.Append("<script type = 'text/javascript'>")
                '    sb2.Append("window.onload=function(){")
                '    sb2.Append("alert('")
                '    sb2.Append(message2)
                '    sb2.Append("')};")
                '    sb2.Append("</script>")
                '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

                '    Exit Sub
                'End If

                'lblmandatory.Visible = False

                If txtUpload.HasFile = True Then
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
                End If



                If ddl_tipekendaraan.SelectedItem.Text = "--Choose--" Then
                    Label13.Visible = True
                    Exit Sub
                End If


                If ddl_tipekendaraan.SelectedItem.Text = "MOTORCYCLE" Then
                    ddlsingledouble.SelectedItem.Text = ""
                End If

                If ddl_tipekendaraan.SelectedItem.Text = "CAR" Then
                    If ddlsingledouble.SelectedItem.Text = "" Then
                        Label23.Visible = True
                        Exit Sub
                    End If
                    If ddlsingledouble.SelectedItem.Text = "DOUBLE" And txtnopol2.Text = "" Then
                        Label21.Visible = True
                        Exit Sub
                    End If
                End If


                If ddl_tipekendaraan.SelectedItem.Text = "CAR" Then
                    If ddlsingledouble.SelectedItem.Text = "DOUBLE" Then

                        If (NoPol4.Text = "Even" And Textbox2.Text = "Even") Or (NoPol4.Text = "Odd" And Textbox2.Text = "Odd") Then
                            message2 = "Cannot Input double Even/Odd No. Pol"
                            sb2.Append("<script type = 'text/javascript'>")
                            sb2.Append("window.onload=function(){")
                            sb2.Append("alert('")
                            sb2.Append(message2)
                            sb2.Append("')};")
                            sb2.Append("</script>")
                            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                            Exit Sub
                        End If
                    End If
                End If



                Dim _total As String = EditData()

                Label7.Visible = False
                Label23.Visible = False
                Label13.Visible = False
                Label21.Visible = False

                'Dim message As String


                'message = "Save Data Success"
                'Dim sb As New System.Text.StringBuilder()
                'sb.Append("<script type = 'text/javascript'>")
                'sb.Append("window.onload=function(){")
                'sb.Append("alert('")
                'sb.Append(message)
                'sb.Append("')};")
                'sb.Append("</script>")
                'ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

                countData()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function EditData() As String
        Dim rows As Integer
        Submit()
        Return rows
    End Function
    Public Function Submit() As String
        Dim rows As String = ""
        'Dim P1 As String
        'Dim P2 As String
        'Dim P3 As String
        Try
            'If period1.Checked = True Then
            '    P1 = "Y"
            'Else
            '    P1 = "N"
            'End If

            'If period2.Checked = True Then
            '    P2 = "Y"
            'Else
            '    P2 = "N"
            'End If

            'If period3.Checked = True Then
            '    P3 = "Y"
            'Else
            '    P3 = "N"
            'End If


            oUpdate.f_EDIT_DATA_REIMBURS_PARKING(lblEmplID.Text, lblName.Text, lblEntity.Text, ddl_tipekendaraan.SelectedItem.Text,
                                   txtnopol1.Text, txtnopol2.Text, ddlsingledouble.SelectedItem.Text, Convert.ToDecimal(txttotalamount.Text),
                                   txtdatefrom.Text, txtdateto.Text, ddlyear.SelectedItem.Text, txttotalday.Text, 0.00,
                                   txtremarks.Text, Session("UserID").ToString, Session("UserID").ToString, "0", "", Request.QueryString("idx"), "EDIT")

            ScriptManager.RegisterStartupScript(Me, Me.GetType(),
            "alert",
            "alert('Update Data Success');window.location ='Frm_List_Reimbursment_Request.aspx';",
            True)

        Catch ex As Exception

        End Try
        Return rows
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("Frm_List_Reimbursment_Request.aspx")
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
    Sub ddl_tipekendaraan_CHANGED()
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
    Sub SINGLEDOUBLE()
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
    Sub txtnopol1_TextChanged()
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

    Sub txtnopol2_TextChanged()
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

    Protected Sub LinkDwn1_Click(sender As Object, e As EventArgs) Handles LinkDwn1.Click
        'Dim url As String = "/CellPhone/upload/" + Session("ShortEntity") + "/" + Session("Years") + "/" + CStr(txtQuarter.Text) + "/" + lblID2.Text + "_" + lblAttPeriod1.Text + ".pdf"
        Dim url As String = "/HRExtendedParkingSystem_UAT/Upload/" + lblEntity.Text + "/" + ddlyear.SelectedItem.Text + "/" + lblEmplID.Text + "_Reimburs.pdf"
        'http://wrbmdtapp01/HRExtendedParkingSystem_UAT/upload/ASI/2019/187196_Reimburs.pdf
        Dim sb As New StringBuilder()
        sb.Append(" <Script type = 'text/javascript'>")
        sb.Append("window.open('")
        sb.Append(url)
        sb.Append("');")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.GetType(),
                  "script", sb.ToString())
    End Sub
End Class