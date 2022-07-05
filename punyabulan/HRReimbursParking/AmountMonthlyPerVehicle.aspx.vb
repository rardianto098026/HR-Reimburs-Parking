Public Class AmountMonthlyPerVehicle
    Inherits System.Web.UI.Page

    Dim oInsert As New InsertBase
    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase
    Dim UploadId As Integer
    Sub LoadVehicle()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GET_TYPE_VEHICLE()
        If dtCrit2.Rows.Count > 0 Then

            ddl_type.DataSource = dtCrit2
            ddl_type.DataValueField = "Vehicle"
            ddl_type.DataTextField = "Vehicle"
            ddl_type.DataBind()

            ddl_type.Items.Insert(0, New ListItem("--Choose--", "0"))

        End If
    End Sub

    Sub GetAmount()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GET_AMOUNT_BY_VEHICLE(ddl_type.SelectedItem.Text)
        If dtCrit2.Rows.Count > 0 Then
            txtamount.Text = dtCrit2.Rows(0)("Amount").ToString()
        End If
    End Sub

    Sub LoadQuarter()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GET_MONTH_QUARTER()
        If dtCrit2.Rows.Count > 0 Then

            ddlquarter.DataSource = dtCrit2
            ddlquarter.DataValueField = "Quarter"
            ddlquarter.DataTextField = "Quarter"
            ddlquarter.DataBind()

            ddlquarter.Items.Insert(0, New ListItem("--Choose--", "0"))

        End If
    End Sub

    Sub GetMonth()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GETMONTH_BY_QUARTER(ddlquarter.SelectedItem.Text)
        If dtCrit2.Rows.Count > 0 Then
            txtrangeperiod.Text = dtCrit2.Rows(0)("Month").ToString()
        End If
    End Sub

    'Sub bindData(ByVal IDX As String)
    '    Dim dtSelect As New DataTable
    '    dtSelect = oSelect.f_SEL_LOADDATA_CALCULATION(IDX)
    '    If dtSelect.Rows.Count > 0 Then

    '        ddlyear.SelectedIndex = ddlyear.Items.IndexOf(ddlyear.Items.FindByText(dtSelect.Rows(0)("Year").ToString()))
    '        ddlquarter.SelectedIndex = ddlquarter.Items.IndexOf(ddlquarter.Items.FindByText(dtSelect.Rows(0)("Quarter").ToString()))
    '        txtrangeperiod.Text = dtSelect.Rows(0)("Range_Period").ToString()
    '    End If
    'End Sub

    'Private Shared Function GetIntOnly(ByVal value As String) As Integer
    '    Dim returnVal As String = String.Empty
    '    Dim collection As MatchCollection = Regex.Matches(value, "\d+")
    '    For Each m As Match In collection
    '        returnVal += m.ToString()
    '    Next
    '    Return Convert.ToInt32(returnVal)
    'End Function
    'Sub countData()
    '    Dim COUNTING_DATA As Integer
    '    Dim dtSelect As New DataTable
    '    dtSelect = oSelect.f_SEL_CHECK_DATA(Session("EMPLNUMBER").ToString)
    '    If dtSelect.Rows.Count > 0 Then
    '        COUNTING_DATA = Convert.ToInt32(dtSelect.Rows(0)("COUNTING").ToString())
    '        If COUNTING_DATA > 0 Then
    '            'Label7.Visible = True
    '        Else
    '            'Label7.Visible = False
    '        End If
    '    Else
    '        'Label7.Visible = False
    '    End If

    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadVehicle()
            LoadQuarter()
            'Session("_idx") = Request.QueryString("idx").ToString
            'bindData(Session("_idx"))
            'countData()
        End If
    End Sub

    Protected Sub Add_CheckedChanged(sender As Object, e As EventArgs) Handles Add.CheckedChanged
        If Add.Checked = True Then
            Edit.Checked = False
            ddl_type.Visible = False
            txttype.Visible = True
            type.Visible = True
            amount.Visible = True
            txtamount.Visible = True
            year.Visible = True
            ddlyear.Visible = True
            quarter.Visible = True
            ddlquarter.Visible = True
            rangeperiod.Visible = True
            txtrangeperiod.Visible = True
            btnSubmit.Visible = True
            'btnBack.Visible = True
            txtamount.Text = 0
            ddlyear.SelectedIndex = ddlyear.Items.IndexOf(ddlyear.Items.FindByText("--Choose--"))
            ddlquarter.SelectedIndex = ddlquarter.Items.IndexOf(ddlquarter.Items.FindByText("--Choose--"))
            txtrangeperiod.Text = ""
        Else
            Edit.Checked = False
            Add.Checked = False
            ddl_type.Visible = True
            txttype.Visible = False
            txttype.Text = ""
            type.Visible = True
            amount.Visible = True
            txtamount.Visible = True
            year.Visible = True
            ddlyear.Visible = True
            quarter.Visible = True
            ddlquarter.Visible = True
            rangeperiod.Visible = True
            txtrangeperiod.Visible = True
            btnSubmit.Visible = True
            'btnBack.Visible = True
            txtamount.Text = 0

        End If
    End Sub

    Protected Sub Edit_CheckedChanged(sender As Object, e As EventArgs) Handles Edit.CheckedChanged
        If Edit.Checked = False Then
            Add.Checked = True
            ddl_type.Visible = False
            txttype.Visible = False
            type.Visible = True
            amount.Visible = True
            txtamount.Visible = True
            year.Visible = True
            ddlyear.Visible = True
            quarter.Visible = True
            ddlquarter.Visible = True
            rangeperiod.Visible = True
            txtrangeperiod.Visible = True
            'btnBack.Visible = True
            txtamount.Text = 0
        Else
            Add.Checked = False
            Edit.Checked = True
            ddl_type.Visible = True
            txttype.Visible = False
            type.Visible = True
            amount.Visible = True
            txttype.Text = ""
            txtamount.Visible = True
            year.Visible = True
            ddlyear.Visible = True
            quarter.Visible = True
            ddlquarter.Visible = True
            rangeperiod.Visible = True
            txtrangeperiod.Visible = True
            btnSubmit.Visible = True
            'btnBack.Visible = True
            txtamount.Text = 0
            txtrangeperiod.Text = ""
            ddl_type.SelectedIndex = ddl_type.Items.IndexOf(ddl_type.Items.FindByText("--Choose--"))
            ddlyear.SelectedIndex = ddlyear.Items.IndexOf(ddlyear.Items.FindByText("--Choose--"))
            ddlquarter.SelectedIndex = ddlquarter.Items.IndexOf(ddlquarter.Items.FindByText("--Choose--"))
        End If
    End Sub

    Sub SubmitData()
        Dim message As String
        Dim sb As New System.Text.StringBuilder()

        If Add.Checked = True Then
            If txttype.Text = "" Then
                message = "Please Fill Type Vehicle"
                sb.Append("<script type='text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub

            End If

            If txtamount.Text = "" Then
                message = "Please Fill Amount"
                sb.Append("<script type='text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub

            End If

            If ddlyear.SelectedItem.Text = "--Choose--" Then
                message = "Please Choose Year"
                sb.Append("<script type='text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub

            End If

            If ddlquarter.SelectedItem.Text = "--Choose--" Then
                message = "Please Choose Quarter"
                sb.Append("<script type='text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub

            End If

            oInsert.f_INSERT_AMOUNT_VEHICLE(txttype.Text, txtamount.Text, ddlyear.SelectedItem.Text, ddlquarter.SelectedItem.Text, txtrangeperiod.Text, "ADD")

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect",
            "alert('Save Data Success'); window.location='AmountMonthlyPerVehicle.aspx';", True)
        End If

        If Edit.Checked = True Then

            If ddl_type.SelectedItem.Text = "--choose--" Then
                message = "Please Choose Type Vehicle"
                sb.Append("<script type='text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub

            End If

            If txtamount.Text = "" Then
                message = "Please Fill Amount"
                sb.Append("<script type='text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub

            End If

            If ddlyear.SelectedItem.Text = "--Choose--" Then
                message = "Please Choose Year"
                sb.Append("<script type='text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub

            End If

            If ddlquarter.SelectedItem.Text = "--Choose--" Then
                message = "Please Choose Quarter"
                sb.Append("<script type='text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                Exit Sub

            End If

            oInsert.f_INSERT_AMOUNT_VEHICLE(ddl_type.SelectedItem.Text, txtamount.Text, ddlyear.SelectedItem.Text, ddlquarter.SelectedItem.Text, txtrangeperiod.Text, "EDIT")

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect",
            "alert('Update Data Success'); window.location='AmountMonthlyPerVehicle.aspx';", True)
        End If

        txtamount.Text = ""
        txttype.Text = ""

    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        SubmitData()
    End Sub

    'Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

    'End Sub

    Protected Sub ddl_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_type.SelectedIndexChanged
        GetAmount()
    End Sub
    Protected Sub ddlquarter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlquarter.SelectedIndexChanged
        GetMonth()
    End Sub
End Class