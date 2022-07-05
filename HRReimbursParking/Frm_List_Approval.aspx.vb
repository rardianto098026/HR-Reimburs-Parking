Public Class Frm_List_Approval
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
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

    Sub Searching()
        'lblCount.Visible = False

        'Validation


        If ChkEmpl1.Checked = True And txtEmplID.Text = "" Then
            lblEmplID2.Visible = True
            lblEmplID2.Text = "* Please fill the Employee Number"

            Exit Sub
        End If

        If ChkName.Checked = True And txtName.Text = "" Then
            lblName.Visible = True
            lblName.Text = "* Please fill the Name Employee"

            Exit Sub
        End If

        'If chkTypeKend.Checked = True And ddl.SelectedItem.Text = "--Choose--" Then
        '    lblErrType.Visible = True
        '    lblErrType.Text = "* Please Choose Type Vehicle"

        '    Exit Sub
        'End If

        If chkEntity.Checked = True And ddlEntity.SelectedItem.Text = "--Choose--" Then
            Label3.Visible = True
            Label3.Text = "* Please Choose Entity"

            Exit Sub
        End If

        If chkEntity2.Checked = True And ddlEntity2.SelectedItem.Text = "--Choose--" Then
            Label3.Visible = True
            Label3.Text = "* Please Choose Entity"

            Exit Sub
        End If

        'If ChkUpdate.Checked = True And ddlUpdate.SelectedItem.Text = "--Choose--" Then
        '    Label6.Visible = True
        '    Label6.Text = "* Please Choose Update Vehicle"

        '    Exit Sub
        'End If


        grid_Databinding()

        dgListApproval2.PageSize = 10
        dgListApproval2.PageIndex = 0
        dgListApproval2.DataBind()


        lblTotal.Text = dgListApproval2.PageCount
        txtGO.Value = dgListApproval2.PageIndex + 1

        lblEmplID2.Visible = False
        lblName.Visible = False
        Label3.Visible = False
        'Label6.Visible = False
        'lblErrType.Visible = False

    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub


    Private Sub grid_Databinding()
        Dim _EmplID As String = ""
        Dim _NameEmplo As String = ""
        Dim _Entity As String = ""
        Dim _Year As String = ""
        Dim _Range As String = ""

        Dim _flagEmplID As String
        Dim _flagNameEmplo As String
        Dim _flagEntity As String
        Dim _FlagYear As String
        Dim _FlagRange As String = "0"
        Dim Command As String = ""

        If ChkEmpl1.Checked = False Then
            _flagEmplID = "0"
            lblEmplID2.Visible = False
        Else
            _flagEmplID = "1"
            _EmplID = txtEmplID.Text
            lblEmplID2.Visible = False
        End If

        If ChkName.Checked = False Then
            _flagNameEmplo = "0"
            lblName.Visible = False
        Else
            _flagNameEmplo = "1"
            _NameEmplo = txtName.Text
            lblName.Visible = False
        End If

        'If chkTypeKend.Checked = False Then
        '    _flagTypeVeh = "0"
        '    lblErrType.Visible = False
        'Else
        '    _flagTypeVeh = "1"
        '    _TypeVeh = ddl.SelectedItem.Text
        '    lblErrType.Visible = False
        'End If

        If chkEntity.Checked = False Then
            _flagEntity = "0"
            'Label3.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity.SelectedItem.Text
            'Label3.Visible = False
        End If

        If (Session("ROLES") = "ADMIN") Then
            If chkEntity2.Checked = False Then
                _flagEntity = "0"
                'Label3.Visible = False
            Else
                _flagEntity = "1"
                _Entity = ddlEntity2.SelectedItem.Text
                'Label3.Visible = False
            End If
        End If

        'If chkNoPol.Checked = False Then
        '    _flagNopol = "0"
        '    lblErrNoPol.Visible = False
        'Else
        '    _flagNopol = "1"
        '    _Nopol = txtNoPol.Text
        '    lblErrNoPol.Visible = False
        'End If

        If chkYear.Checked = False Then
            _FlagYear = "0"
            'lblErrPeriod.Visible = False
        Else
            _FlagYear = "1"
            _Year = ddlyear.SelectedValue
            'lblErrPeriod.Visible = False
        End If

        If Session("ROLES") = "ADMIN" Then
            _flagEntity = "1"
            Dim dt As New DataTable
            dt = oSelect.f_CHECK_MST_EMPLOYEE(Session("EMPLNUMBER").ToString, "")
            _Entity = dt.Rows(0)("ShortEntity").ToString
            If Session("WORKER_TYPE") = "FTE" Then
                Command = "SEARCH_APPROVAL_FTE"
            Else
                Command = "SEARCH_APPROVAL_NON_FTE"
            End If
        Else
            Command = "SEARCH_APPROVAL"
        End If

        Dim StatKaryawan As String = ""

        Dim dtSelect2 As New DataTable
        dtSelect2 = oSelect.f_SEL_STAT_KARYAWAN(Session("EMPLNUMBER").ToString())
        If dtSelect2.Rows.Count > 0 Then
            StatKaryawan = dtSelect2.Rows(0)("Status").ToString()
        Else
            StatKaryawan = "FTE"
        End If


        Dim dtSelect As New DataTable

        dtSelect = oSelect.f_SEL_LIST_PARKING_REIMBURS(_EmplID, _NameEmplo, _Entity, _Range, _Year, _flagEmplID, _flagNameEmplo,
                                                    _flagEntity, _FlagRange, _FlagYear, StatKaryawan, Command)

        dgListApproval2.DataSource = dtSelect
        'dg_TRN_Reimburst.DataBind()
        dgListApproval2.PageSize = 100
        dgListApproval2.Visible = True

        lblTotalRecords.Text = dtSelect.Rows.Count.ToString & " record(s)"
    End Sub

    Protected Sub lnkExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkExport.Click
        export()
    End Sub
    Sub export()
        Dim _EmployeeID As String = ""
        Dim _EmployeeName As String = ""
        Dim _Entity As String = ""
        Dim _RangePeriod As String = ""
        Dim _Year As String = ""

        Dim _flagEmployeeID As String
        Dim _flagEmployeeName As String
        Dim _flagEntity As String
        Dim _flagRangePeriod As String = "0"
        Dim _flagYear As String
        Dim Command As String


        If ChkEmpl1.Checked = False Then
            _flagEmployeeID = "0"
            'lblEmplID1.Visible = False
        Else
            _flagEmployeeID = "1"
            _EmployeeID = txtEmplID.Text
            'lblEmplID2.Visible = False
        End If

        If ChkName.Checked = False Then
            _flagEmployeeName = "0"
            lblEmplID2.Visible = False
        Else
            _flagEmployeeName = "1"
            _EmployeeName = txtName.Text
            'lblEmpname2.Visible = False
        End If

        If chkEntity.Checked = False Then
            _flagEntity = "0"
            'lblEntity2.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity.SelectedItem.Text
            'lblEntity2.Visible = False
        End If

        If (Session("ROLES") = "ADMIN") Then
            If chkEntity2.Checked = False Then
                _flagEntity = "0"
                'lblEntity2.Visible = False
            Else
                _flagEntity = "1"
                _Entity = ddlEntity2.SelectedItem.Text
                'lblEntity2.Visible = False
            End If
        End If
        'If CheckRangePeriod.Checked = False Then
        '    _flagRangePeriod = "0"
        '    lblrangeperiod2.Visible = False
        'Else
        '    _flagRangePeriod = "1"
        '    _RangePeriod = ddlrangeperiod.SelectedItem.Text
        '    lblrangeperiod2.Visible = False
        'End If

        If chkYear.Checked = False Then
            _flagYear = "0"
            'lblYear2.Visible = False
        Else
            _flagYear = "1"
            _Year = ddlyear.SelectedItem.Text
            'lblEntity2.Visible = False
        End If


        Dim StatKaryawan As String = ""

        Dim dtSelect2 As New DataTable
        dtSelect2 = oSelect.f_SEL_STAT_KARYAWAN(Session("EMPLNUMBER").ToString())
        If dtSelect2.Rows.Count > 0 Then
            StatKaryawan = dtSelect2.Rows(0)("Status").ToString()
        Else
            StatKaryawan = "FTE"
        End If

        If Session("ROLES") = "ADMIN" Then
            _flagEntity = "1"
            Dim dt As New DataTable
            dt = oSelect.f_CHECK_MST_EMPLOYEE(Session("EMPLNUMBER").ToString, "")
            _Entity = dt.Rows(0)("ShortEntity").ToString
            If Session("WORKER_TYPE") = "FTE" Then
                Command = "SEARCH_APPROVAL_FTE"
            Else
                Command = "SEARCH_APPROVAL_NON_FTE"
            End If
        Else
            Command = "SEARCH_APPROVAL"
        End If
        Dim dtSelect As New DataTable

        dtSelect = oSelect.f_SEL_LIST_PARKING_REIMBURS(_EmployeeID, _EmployeeName, _Entity, _RangePeriod, _Year,
                                                    _flagEmployeeID, _flagEmployeeName, _flagEntity, _flagRangePeriod, _flagYear, StatKaryawan, Command)



        Dim uploadid As Integer
        uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile("EXPORT PARKING APPROVAL", Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)

        ' Set the content type to Excel.
        ' Edit Data Grid To Gridview
        Dim dg As New GridView
        dg.DataSource = dtSelect
        dg.DataBind()


        For Each r As GridViewRow In dg.Rows
            If (r.RowType = DataControlRowType.DataRow) Then

                r.Cells(0).Attributes.Add("class", "text")
                r.Cells(1).Attributes.Add("class", "text")
                r.Cells(2).Attributes.Add("class", "text")
                r.Cells(3).Attributes.Add("class", "text")
                r.Cells(4).Attributes.Add("class", "text")
                r.Cells(5).Attributes.Add("class", "text")
                r.Cells(6).Attributes.Add("class", "text")
                r.Cells(7).Attributes.Add("class", "text")

            End If
        Next

        Dim filename As String = "Export List Reimbursement Approval" & Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0") & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day.ToString.PadLeft(2, "0") & ".xls"
        'Response.AddHeader("content-disposition", "attachment;filename=" & filename)

        Response.ContentType = "application/vnd.ms-excel"
        'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"

        'EDIT Himawan 26-06-2014 For File Name 
        Response.AddHeader("Content-Disposition", "inline; filename=" + filename)

        'Edit Himawan (25-06-2014) For Disable Open Button in save file dialog
        Response.AddHeader("X-Download-Options", "noopen")

        ' Remove the charset from the Content-Type header.
        Response.Charset = ""

        ' Turn off the view state.
        Me.EnableViewState = False

        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)

        dg.RenderControl(hw)

        If dg.Rows.Count > 0 Then

            Dim style As String = "<style> .text { mso-number-format:\@; } </style>"
            Response.Write(style)

            Response.Write(tw.ToString())

        Else
            Dim style As String = "NO DATA"
            Response.Write(style)
        End If
        Response.End()
    End Sub
    Protected Sub lbFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbFirst.Click
        'dgListApproval2.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgListApproval2.DataBind()
        dgListApproval2.PageIndex = 0
        dgListApproval2.DataBind()

        txtGO.Value = dgListApproval2.PageIndex + 1
    End Sub

    Protected Sub lbPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbPrev.Click
        If dgListApproval2.PageIndex <> 0 Then
            'dgListApproval2.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgListApproval2.DataBind()
            dgListApproval2.PageIndex = dgListApproval2.PageIndex - 1
            dgListApproval2.DataBind()

            txtGO.Value = dgListApproval2.PageIndex + 1
        End If
    End Sub

    Protected Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
        If dgListApproval2.PageIndex <> dgListApproval2.PageCount - 1 Then
            'dgListApproval2.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgListApproval2.DataBind()
            dgListApproval2.PageIndex = dgListApproval2.PageIndex + 1
            dgListApproval2.DataBind()

            txtGO.Value = dgListApproval2.PageIndex + 1
        End If
    End Sub

    Protected Sub lnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLast.Click
        'dgListApproval2.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgListApproval2.DataBind()
        dgListApproval2.PageIndex = dgListApproval2.PageCount - 1
        dgListApproval2.DataBind()

        txtGO.Value = dgListApproval2.PageIndex + 1
    End Sub

    Protected Sub lnkGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkGo.Click
        If IsNumeric(txtGO.Value) = True Then
            If txtGO.Value <= dgListApproval2.PageCount - 1 Then
                'dgListApproval2.DataSource = oSelect.f_SelRekeningKoran
                grid_Databinding()
                dgListApproval2.DataBind()
                dgListApproval2.PageIndex = Int32.Parse(txtGO.Value) - 1
                dgListApproval2.DataBind()

                txtGO.Value = dgListApproval2.PageIndex + 1
            End If
        End If
    End Sub
    Protected Sub ddl_View_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_View.SelectedIndexChanged

        If ddl_View.SelectedValue = "10" Then
            grid_Databinding()
            dgListApproval2.PageSize = 10
            dgListApproval2.PageIndex = 0
            dgListApproval2.DataBind()

            lblTotal.Text = dgListApproval2.PageCount
            txtGO.Value = dgListApproval2.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "20" Then
            grid_Databinding()
            dgListApproval2.PageSize = 20
            dgListApproval2.PageIndex = 0
            dgListApproval2.DataBind()

            lblTotal.Text = dgListApproval2.PageCount
            txtGO.Value = dgListApproval2.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "50" Then
            grid_Databinding()
            dgListApproval2.PageSize = 50
            dgListApproval2.PageIndex = 0
            dgListApproval2.DataBind()

            lblTotal.Text = dgListApproval2.PageCount
            txtGO.Value = dgListApproval2.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "70" Then
            grid_Databinding()
            dgListApproval2.PageSize = 70
            dgListApproval2.PageIndex = 0
            dgListApproval2.DataBind()


            lblTotal.Text = dgListApproval2.PageCount
            txtGO.Value = dgListApproval2.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "100" Then
            grid_Databinding()
            dgListApproval2.PageSize = 100
            dgListApproval2.PageIndex = 0
            dgListApproval2.DataBind()

            lblTotal.Text = dgListApproval2.PageCount
            txtGO.Value = dgListApproval2.PageIndex + 1
        End If
    End Sub
    Protected Sub btn_Hidden_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Hidden.Click
        Searching()
    End Sub
    Private Sub Frm_List_Approval_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dt As New DataTable
            'Dim path As String = Request.Path.ToString
            Dim path As String = System.IO.Path.GetFileName(Request.Url.AbsolutePath)
            Try
                dt = oSelect.f_check_Access_Menu(path, Session("EMPLNUMBER").ToString)
            Catch ex As Exception
                Response.Redirect("Frm_ErrorHandler.aspx")
            End Try
            Session("ROLES") = dt.Rows(0)("Role").ToString()
            Dim role As String = Session("ROLES").ToString
            If dt.Rows.Count > 0 Then
            Else
                Response.Redirect("Frm_ErrorHandler.aspx")
            End If
        Else

        End If
    End Sub

    Protected Sub dgListApproval2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dgListApproval2.RowCommand
        If e.CommandName = "cmdEdit" Then
            Dim rowIndex As Int32 = Convert.ToInt32(e.CommandArgument)

            Session("Preview") = "Approval"
            Dim idx As String = dgListApproval2.Rows(rowIndex).Cells(1).Text
            Response.Redirect("Frm_Approval.aspx?idx=" + idx)
        End If

    End Sub
End Class