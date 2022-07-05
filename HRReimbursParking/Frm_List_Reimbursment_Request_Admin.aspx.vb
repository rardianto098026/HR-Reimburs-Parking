Public Class Frm_List_Reimbursment_Request_Admin
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase

    Sub Searching()
        'lblCount.Visible = False

        'Validation


        If CheckEmpID.Checked = True And txtEmpID.Text = "" Then
            lblEmpID2.Visible = True
            lblEmpID2.Text = "* Please fill the Employee Number"

            Exit Sub
        End If

        If CheckEmpname.Checked = True And txtEmpname.Text = "" Then
            lblEmpname2.Visible = True
            lblEmpname2.Text = "* Please fill the Name Employee"

            Exit Sub
        End If

        'If chkTypeKend.Checked = True And ddl.SelectedItem.Text = "--Choose--" Then
        '    lblErrType.Visible = True
        '    lblErrType.Text = "* Please Choose Type Vehicle"

        '    Exit Sub
        'End If


        'If CheckRangePeriod.Checked = True And ddlrangeperiod.SelectedItem.Text = "--Choose--" Then
        '    lblrangeperiod2.Visible = True
        '    lblrangeperiod2.Text = "* Please Choose Range Period"

        '    Exit Sub
        'End If

        If CheckEntity.Checked = True And ddlEntity.SelectedItem.Text = "--Choose--" Then
            lblEntity2.Visible = True
            lblEntity2.Text = "* Please Choose Entity"

            Exit Sub
        End If

        If CheckEntity1.Checked = True And ddlEntity1.SelectedItem.Text = "--Choose--" Then
            lblEntity2.Visible = True
            lblEntity2.Text = "* Please Choose Entity"

            Exit Sub
        End If

        If CheckYear.Checked = True And ddlYear.SelectedItem.Text = "--Choose--" Then
            lblYear2.Visible = True
            lblYear2.Text = "* Please Choose Year"

            Exit Sub
        End If

        grid_Databinding()

        dgListReimbursEmployee.PageSize = 10
        dgListReimbursEmployee.CurrentPageIndex = 0
        dgListReimbursEmployee.DataBind()


        lblTotal.Text = dgListReimbursEmployee.PageCount
        txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1

        lblEmpID2.Visible = False
        lblEmpname2.Visible = False
        'lblrangeperiod2.Visible = False
        lblEntity2.Visible = False
        lblYear2.Visible = False
        'lblErrType.Visible = False

    End Sub

    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub
    Private Sub grid_Databinding()

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


        If CheckEmpID.Checked = False Then
            _flagEmployeeID = "0"
            lblEmpID2.Visible = False
        Else
            _flagEmployeeID = "1"
            _EmployeeID = txtEmpID.Text
            lblEmpID2.Visible = False
        End If

        If CheckEmpname.Checked = False Then
            _flagEmployeeName = "0"
            lblEmpname2.Visible = False
        Else
            _flagEmployeeName = "1"
            _EmployeeName = txtEmpname.Text
            lblEmpname2.Visible = False
        End If

        If CheckEntity.Checked = False Then
            _flagEntity = "0"
            lblEntity2.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity.SelectedItem.Text
            lblEntity2.Visible = False
        End If

        If CheckEntity1.Checked = False Then
            _flagEntity = "0"
            lblEntity2.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity1.SelectedItem.Text
            lblEntity2.Visible = False
        End If

        'If CheckRangePeriod.Checked = False Then
        '    _flagRangePeriod = "0"
        '    lblrangeperiod2.Visible = False
        'Else
        '    _flagRangePeriod = "1"
        '    _RangePeriod = ddlrangeperiod.SelectedItem.Text
        '    lblrangeperiod2.Visible = False
        'End If

        If CheckYear.Checked = False Then
            _flagYear = "0"
            lblYear2.Visible = False
        Else
            _flagYear = "1"
            _Year = ddlYear.SelectedItem.Text
            lblEntity2.Visible = False
        End If

        If Session("ROLES") = "ADMIN" Then
            _flagEntity = "1"
            Dim dt As New DataTable
            dt = oSelect.f_CHECK_MST_EMPLOYEE(Session("EMPLNUMBER").ToString, "")
            _Entity = dt.Rows(0)("ShortEntity").ToString
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

        dtSelect = oSelect.f_SEL_LIST_PARKING_REIMBURS(_EmployeeID, _EmployeeName, _Entity, _RangePeriod, _Year,
                                                    _flagEmployeeID, _flagEmployeeName, _flagEntity, _flagRangePeriod, _flagYear, StatKaryawan, "SEARCH_DATA")


        Session("dtSelect") = dtSelect
        dgListReimbursEmployee.PageSize = 100
        dgListReimbursEmployee.DataSource = dtSelect
        dgListReimbursEmployee.Visible = True


        lblTotalRecords.Text = dtSelect.Rows.Count.ToString & " record(s)"
    End Sub

    Protected Sub lbFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbFirst.Click
        'dgListReimbursEmployee.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgListReimbursEmployee.DataBind()
        dgListReimbursEmployee.CurrentPageIndex = 0
        dgListReimbursEmployee.DataBind()

        txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1
    End Sub

    Protected Sub lbPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbPrev.Click
        If dgListReimbursEmployee.CurrentPageIndex <> 0 Then
            'dgListReimbursEmployee.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgListReimbursEmployee.DataBind()
            dgListReimbursEmployee.CurrentPageIndex = dgListReimbursEmployee.CurrentPageIndex - 1
            dgListReimbursEmployee.DataBind()

            txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1
        End If
    End Sub

    Protected Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
        If dgListReimbursEmployee.CurrentPageIndex <> dgListReimbursEmployee.PageCount - 1 Then
            'dgListReimbursEmployee.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgListReimbursEmployee.DataBind()
            dgListReimbursEmployee.CurrentPageIndex = dgListReimbursEmployee.CurrentPageIndex + 1
            dgListReimbursEmployee.DataBind()

            txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1
        End If
    End Sub

    Protected Sub lnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLast.Click
        'dgListReimbursEmployee.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgListReimbursEmployee.DataBind()
        dgListReimbursEmployee.CurrentPageIndex = dgListReimbursEmployee.PageCount - 1
        dgListReimbursEmployee.DataBind()

        txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1
    End Sub

    Protected Sub lnkGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkGo.Click
        If IsNumeric(txtGO.Value) = True Then
            If txtGO.Value <= dgListReimbursEmployee.PageCount - 1 Then
                'dgListReimbursEmployee.DataSource = oSelect.f_SelRekeningKoran
                grid_Databinding()
                dgListReimbursEmployee.DataBind()
                dgListReimbursEmployee.CurrentPageIndex = Int32.Parse(txtGO.Value) - 1
                dgListReimbursEmployee.DataBind()

                txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1
            End If
        End If
    End Sub
    Protected Sub ddl_View_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_View.SelectedIndexChanged

        If ddl_View.SelectedValue = "10" Then
            grid_Databinding()
            dgListReimbursEmployee.PageSize = 10
            dgListReimbursEmployee.CurrentPageIndex = 0
            dgListReimbursEmployee.DataBind()

            lblTotal.Text = dgListReimbursEmployee.PageCount
            txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1
        ElseIf ddl_View.SelectedValue = "20" Then
            grid_Databinding()
            dgListReimbursEmployee.PageSize = 20
            dgListReimbursEmployee.CurrentPageIndex = 0
            dgListReimbursEmployee.DataBind()

            lblTotal.Text = dgListReimbursEmployee.PageCount
            txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1
        ElseIf ddl_View.SelectedValue = "50" Then
            grid_Databinding()
            dgListReimbursEmployee.PageSize = 50
            dgListReimbursEmployee.CurrentPageIndex = 0
            dgListReimbursEmployee.DataBind()

            lblTotal.Text = dgListReimbursEmployee.PageCount
            txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1
        ElseIf ddl_View.SelectedValue = "70" Then
            grid_Databinding()
            dgListReimbursEmployee.PageSize = 70
            dgListReimbursEmployee.CurrentPageIndex = 0
            dgListReimbursEmployee.DataBind()


            lblTotal.Text = dgListReimbursEmployee.PageCount
            txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1
        ElseIf ddl_View.SelectedValue = "100" Then
            grid_Databinding()
            dgListReimbursEmployee.PageSize = 100
            dgListReimbursEmployee.CurrentPageIndex = 0
            dgListReimbursEmployee.DataBind()

            lblTotal.Text = dgListReimbursEmployee.PageCount
            txtGO.Value = dgListReimbursEmployee.CurrentPageIndex + 1
        End If
    End Sub
    Protected Sub btn_Hidden_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Hidden.Click
        Searching()
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


        If CheckEmpID.Checked = False Then
            _flagEmployeeID = "0"
            lblEmpID2.Visible = False
        Else
            _flagEmployeeID = "1"
            _EmployeeID = txtEmpID.Text
            lblEmpID2.Visible = False
        End If

        If CheckEmpname.Checked = False Then
            _flagEmployeeName = "0"
            lblEmpname2.Visible = False
        Else
            _flagEmployeeName = "1"
            _EmployeeName = txtEmpname.Text
            lblEmpname2.Visible = False
        End If

        If CheckEntity.Checked = False Then
            _flagEntity = "0"
            lblEntity2.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity.SelectedItem.Text
            lblEntity2.Visible = False
        End If

        If CheckEntity1.Checked = False Then
            _flagEntity = "0"
            lblEntity2.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity1.SelectedItem.Text
            lblEntity2.Visible = False
        End If

        'If CheckRangePeriod.Checked = False Then
        '    _flagRangePeriod = "0"
        '    lblrangeperiod2.Visible = False
        'Else
        '    _flagRangePeriod = "1"
        '    _RangePeriod = ddlrangeperiod.SelectedItem.Text
        '    lblrangeperiod2.Visible = False
        'End If

        If CheckYear.Checked = False Then
            _flagYear = "0"
            lblYear2.Visible = False
        Else
            _flagYear = "1"
            _Year = ddlYear.SelectedItem.Text
            lblEntity2.Visible = False
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

        dtSelect = oSelect.f_SEL_LIST_PARKING_REIMBURS(_EmployeeID, _EmployeeName, _Entity, _RangePeriod, _Year,
                                                    _flagEmployeeID, _flagEmployeeName, _flagEntity, _flagRangePeriod, _flagYear, StatKaryawan, "EXPORT_DATA")



        Dim uploadid As Integer
        uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile("EXPORT PARKING", Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)

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



        Dim filename As String = "ExportParking" & Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0") & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day.ToString.PadLeft(2, "0") & ".xls"
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'LoadQuarter()
            Dim dt As New DataTable
            'Dim path As String = Request.Path.ToString
            Dim path As String = System.IO.Path.GetFileName(Request.Url.AbsolutePath)
            dt = oSelect.f_check_Access_Menu(path, Session("EMPLNUMBER").ToString)
            Session("ROLES") = dt.Rows(0)("Role").ToString()
            If dt.Rows.Count > 0 Then
            Else
                Response.Redirect("Frm_ErrorHandler.aspx")
            End If
        End If

    End Sub

End Class