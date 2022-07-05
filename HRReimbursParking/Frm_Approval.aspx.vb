Imports System.IO

Public Class Frm_Approval

    Inherits System.Web.UI.Page
    Dim oInsert As New InsertBase
    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase
    Dim UploadId As Integer

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

            'Dim Checklist1 As String = dtSelect.Rows(0)("Period_1").ToString()
            'Dim Checklist2 As String = dtSelect.Rows(0)("Period_2").ToString()
            'Dim Checklist3 As String = dtSelect.Rows(0)("Period_3").ToString()



            txttotalamount.Text = dtSelect.Rows(0)("Total_Amount").ToString()
            Dim Date_From As Date = dtSelect.Rows(0)("Date_From")
            Dim Date_To As Date = dtSelect.Rows(0)("Date_To")
            txtdatefrom.Text = dtSelect.Rows(0)("date_from_2")
            txtdateto.Text = dtSelect.Rows(0)("Date_To_2")
            ddlyear.SelectedIndex = ddlyear.Items.IndexOf(ddlyear.Items.FindByText(dtSelect.Rows(0)("Year").ToString()))
            txttotalday.Text = dtSelect.Rows(0)("Total_Days").ToString()
            txtremarks.Text = dtSelect.Rows(0)("Remarks").ToString()
            If Session("Preview") = "Preview" Then
                txttotalamountapprove2.Text = dtSelect.Rows(0)("Total_Amount_Approve").ToString()
                txtstatus.Text = dtSelect.Rows(0)("Flag").ToString()
                txtremarks2.Text = dtSelect.Rows(0)("Remarks").ToString()
            End If
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

        End If
        LinkDwn1.Text = lblEmplID.Text + "_" + "Reimburs.pdf"
    End Sub

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

    'Sub GetTotalAmount()
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
    Sub countData()
        Dim COUNTING_DATA As Integer
        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_CHECK_DATA(Session("EMPLNUMBER").ToString)
        If dtSelect.Rows.Count > 0 Then
            COUNTING_DATA = Convert.ToInt32(dtSelect.Rows(0)("COUNTING").ToString())
            If COUNTING_DATA > 0 Then
                'Label7.Visible = True
            Else
                'Label7.Visible = False
            End If
        Else
            'Label7.Visible = False
        End If

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
    Sub ddl_tipekendaraan_CHANGED()

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
            btnApprove.Enabled = False
            btnReject.Enabled = False
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
            btnApprove.Enabled = True
            btnReject.Enabled = True
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
            btnApprove.Enabled = False
            btnReject.Enabled = False
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
            btnApprove.Enabled = True
            btnReject.Enabled = True
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'txttotalamountapprove.Text = FormatNumber(CDbl(txttotalamountapprove.Text), 2)
            Dim querstr As String = Request.QueryString("idx")
            LoadVehicle()
            Session("_idx") = Request.QueryString("idx").ToString
            bindData(Session("_idx"))
            countData()
            SINGLEDOUBLE()
            ddl_tipekendaraan_CHANGED()
            txtnopol1_TextChanged()
            txtnopol2_TextChanged()
        End If
    End Sub
    Protected Sub ddl_tipekendaraan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_tipekendaraan.SelectedIndexChanged
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
        GetTotalDays()
    End Sub
    Protected Sub txtdateto_TextChanged(sender As Object, e As EventArgs) Handles txtdateto.TextChanged
        GetTotalDays()
    End Sub
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
            btnApprove.Enabled = False
            btnReject.Enabled = False
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
            btnApprove.Enabled = True
            btnReject.Enabled = True
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
            btnApprove.Enabled = False
            btnReject.Enabled = False
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
            btnApprove.Enabled = True
            btnReject.Enabled = True
        End If
    End Sub
    'Protected Sub Alert()
    '    Dim message2 As String
    '    If ((ddl_tipekendaraan.SelectedValue.ToString = "0")) Then

    '        message2 = "Please Choose Type Vehicle"
    '        Dim sb2 As New System.Text.StringBuilder()
    '        sb2.Append("<script type = 'text/javascript'>")
    '        sb2.Append("window.onload=function(){")
    '        sb2.Append("alert('")
    '        sb2.Append(message2)
    '        sb2.Append("')};")
    '        sb2.Append("</script>")
    '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
    '        Exit Sub
    '    End If
    'If ((txttotalamountapprove.Text = "")) Then

    '    message2 = "Please "
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
    'End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Try
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                Dim message2 As String
                Dim sb2 As New System.Text.StringBuilder()

                If txttotalamountapprove.Text = "" Then

                    message2 = "Please Fill Total Amount Approved"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

                    Exit Sub
                End If
                'Dim message2 As String
                'Dim query As String = EmpID.Text + Name.Text + Entity.Text + ddl_tipekendaraan.SelectedValue  + nopol1.Text + nopol2.Text + ddlsingledouble.SelectedValue + ddlrangeperiod.SelectedValue + " " + " " + " " + 0 + " " + " " + 0 + 0 + remarks.Text + " " + " " + "1" + Session("UserName").ToString + Request.QueryString("idx") + "APPROVAL"
                oUpdate.f_EDIT_DATA_REIMBURS_PARKING(lblEmplID.Text, lblName.Text, lblEntity.Text, "", "", "", "", Convert.ToDecimal(txttotalamount.Text), txtdatefrom.Text, txtdateto.Text, 0, 0, Convert.ToDecimal(txttotalamountapprove.Text), txtremarks.Text, "", "", "1", Session("UserName").ToString, Request.QueryString("idx"), "APPROVAL")

                'message2 = "Data has been Approved"
                'Dim sb2 As New System.Text.StringBuilder()
                'sb2.Append("<script type = 'text/javascript'>")
                'sb2.Append("window.onload=function(){")
                'sb2.Append("alert('")
                'sb2.Append(message2)
                'sb2.Append("')};")
                'sb2.Append("</script>")
                'ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

                ScriptManager.RegisterStartupScript(Me, Me.GetType(),
                    "alert",
                    "alert('Data has been Approved');window.location ='Frm_List_Approval.aspx';",
                    True)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Try
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then
                Dim message2 As String
                Dim sb2 As New System.Text.StringBuilder()

                If txttotalamountapprove.Text = "" Then

                    message2 = "Please Fill Total Amount Approved"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

                    Exit Sub
                End If

                oUpdate.f_EDIT_DATA_REIMBURS_PARKING(lblEmplID.Text, lblName.Text, lblEntity.Text, "", "", "", "", Convert.ToDecimal(txttotalamount.Text), txtdatefrom.Text, txtdateto.Text, 0, 0, Convert.ToDecimal(txttotalamountapprove.Text), txtremarks.Text, "", "", "2", Session("UserName").ToString, Request.QueryString("idx"), "APPROVAL")

                'message2 = "Data has been Rejected"
                'Dim sb2 As New System.Text.StringBuilder()
                'sb2.Append("<script type = 'text/javascript'>")
                'sb2.Append("window.onload=function(){")
                'sb2.Append("alert('")
                'sb2.Append(message2)
                'sb2.Append("')};")
                'sb2.Append("</script>")
                'ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

                ScriptManager.RegisterStartupScript(Me, Me.GetType(),
                    "alert",
                    "alert('Data has been Rejected');window.location ='Frm_List_Approval.aspx';",
                    True)
                End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("Frm_List_Approval.aspx")
    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click
        Response.Redirect("Frm_Export.aspx")
    End Sub

    Public Sub Alert_Approve()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Public Sub Alert_Reject()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub

    Protected Sub LinkDwn1_Click(sender As Object, e As EventArgs) Handles LinkDwn1.Click
        'Dim url As String = "/CellPhone/upload/" + Session("ShortEntity") + "/" + Session("Years") + "/" + CStr(txtQuarter.Text) + "/" + lblID2.Text + "_" + lblAttPeriod1.Text + ".pdf"
        Dim url As String = "/HRExtendedParkingSystem_UAT/upload/" + lblEntity.Text + "/" + ddlyear.SelectedItem.Text + "/" + lblEmplID.Text + "_Reimburs.pdf"

        Dim sb As New StringBuilder()
        sb.Append(" <Script type = 'text/javascript'>")
        sb.Append("window.open('")
        sb.Append(url)
        sb.Append("');")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.GetType(),
                  "script", sb.ToString())
    End Sub

    Protected Sub txttotalamountapprove_TextChanged(sender As Object, e As EventArgs) Handles txttotalamountapprove.TextChanged
        Dim totalAmount As Decimal
        Dim TotalApproved As Decimal
        Dim message2 As String

        totalAmount = txttotalamount.Text
        TotalApproved = txttotalamountapprove.Text

        If CDec(totalAmount) < CDec(TotalApproved) Then

            If txttotalamountapprove.Text = "" Then
                txttotalamountapprove.Text = 0
            Else
                txttotalamountapprove.Text = FormatNumber(CDbl(txttotalamountapprove.Text), 2)
            End If

            message2 = "Approved Amount Greater than Total Amount"
            Dim sb2 As New System.Text.StringBuilder()
            sb2.Append("<script type = 'text/javascript'>")
            sb2.Append("window.onload=function(){")
            sb2.Append("alert('")
            sb2.Append(message2)
            sb2.Append("')};")
            sb2.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
            btnApprove.Enabled = False
            btnReject.Enabled = False

            Exit Sub
        End If

        If txttotalamountapprove.Text = "" Then
            txttotalamountapprove.Text = 0
        Else
            txttotalamountapprove.Text = FormatNumber(CDbl(txttotalamountapprove.Text), 2)
        End If

        btnApprove.Enabled = True
        btnReject.Enabled = True

    End Sub
End Class