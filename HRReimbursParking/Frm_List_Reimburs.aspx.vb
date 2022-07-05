Public Partial Class Frm_List_Reimburs
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
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
            Label8.Visible = True
            Label8.Text = "* Please Choose Entity"

            Exit Sub
        End If

        If ChkUpdate.Checked = True And ddlUpdate.SelectedItem.Text = "--Choose--" Then
            Label6.Visible = True
            Label6.Text = "* Please Choose Update Vehicle"

            Exit Sub
        End If

        If chkPeriod.Checked = True And txtPeriod.Text = "" Then
            lblErrPeriod.Visible = True
            lblErrPeriod.Text = "* Please Fill Range Period"

            Exit Sub
        End If

        grid_Databinding()

        dgRekeningKoran2.PageSize = 10
        dgRekeningKoran2.PageIndex = 0
        dgRekeningKoran2.PagerSettings.Visible = False

        dgRekeningKoran2.DataBind()


        lblTotal.Text = dgRekeningKoran2.PageCount
        txtGO.Value = dgRekeningKoran2.PageIndex + 1

        lblEmplID2.Visible = False
        lblName.Visible = False
        lblErrPeriod.Visible = False
        Label3.Visible = False
        Label6.Visible = False
        'lblErrType.Visible = False

    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub
    Private Sub grid_Databinding()

        Dim _EmplID As String = ""
        Dim _NameEmplo As String = ""
        Dim _TypeVeh As String = ""
        Dim _Entity As String = ""
        Dim _Nopol As String = ""
        Dim _Update As String = ""
        Dim _Range As String = ""

        Dim _flagEmplID As String
        Dim _flagNameEmplo As String
        Dim _flagTypeVeh As String = "0"
        Dim _flagEntity As String
        Dim _flagNopol As String = "0"
        Dim _FlagUpdate As String
        Dim _FlagRange As String

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
            Label3.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity.SelectedItem.Text
            Label3.Visible = False
        End If

        If chkEntity2.Checked = False Then
            _flagEntity = "0"
            Label8.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity2.SelectedItem.Text
            Label8.Visible = False
        End If

        'If chkNoPol.Checked = False Then
        '    _flagNopol = "0"
        '    lblErrNoPol.Visible = False
        'Else
        '    _flagNopol = "1"
        '    _Nopol = txtNoPol.Text
        '    lblErrNoPol.Visible = False
        'End If

        If ChkUpdate.Checked = False Then
            _FlagUpdate = "0"
            Label6.Visible = False
        Else
            _FlagUpdate = "1"
            _Update = ddlUpdate.SelectedItem.Text
            Label6.Visible = False
        End If

        If chkPeriod.Checked = False Then
            _FlagRange = "0"
            lblErrPeriod.Visible = False
        Else
            _FlagRange = "1"
            _Range = txtPeriod.Text
            lblErrPeriod.Visible = False
        End If

        Dim StatKaryawan As String = ""

        If Session("ROLES") = "ADMIN" Then
            _flagEntity = "1"
            Dim dt As New DataTable
            dt = oSelect.f_CHECK_MST_EMPLOYEE(Session("EMPLNUMBER").ToString, "")
            _Entity = dt.Rows(0)("ShortEntity").ToString
            If Session("WORKER_TYPE") = "FTE" Then
                StatKaryawan = "SEARCH_PARKING_FTE"
            Else
                StatKaryawan = "SEARCH_PARKING_NON_FTE"
            End If
        Else
            If chkEntity.Checked = True Then
                _flagEntity = "1"
            Else
                _flagEntity = "0"
            End If
            StatKaryawan = "FTE"
            End If

            'Dim dtSelect2 As New DataTable
            'dtSelect2 = oSelect.f_SEL_STAT_KARYAWAN(Session("EMPLNUMBER").ToString())
            'If dtSelect2.Rows.Count > 0 Then
            '    StatKaryawan = dtSelect2.Rows(0)("Status").ToString()
            'Else
            '    StatKaryawan = "FTE"
            'End If


            Dim dtSelect As New DataTable

        dtSelect = oSelect.f_SEL_LIST_PARKING_ADMIN(_EmplID, _NameEmplo, _TypeVeh, _Entity, _Nopol, _Update, _Range,
                                                        _flagEmplID, _flagNameEmplo, _flagTypeVeh, _flagEntity, _flagNopol,
                                                        _FlagUpdate, _FlagRange, StatKaryawan)


        Session("dtSelect") = dtSelect
        dgRekeningKoran2.PageSize = 10
        dgRekeningKoran2.DataSource = dtSelect
        dgRekeningKoran2.Visible = True

        dgRekeningKoran2.PagerSettings.Visible = False

        lblTotalRecords.Text = dtSelect.Rows.Count.ToString & " record(s)"
    End Sub
    Protected Sub lbFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbFirst.Click
        'dgRekeningKoran.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgRekeningKoran2.DataBind()
        dgRekeningKoran2.PageIndex = 0
        dgRekeningKoran2.DataBind()

        txtGO.Value = dgRekeningKoran2.PageIndex + 1
    End Sub

    Protected Sub lbPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbPrev.Click
        If dgRekeningKoran2.PageIndex <> 0 Then
            'dgRekeningKoran.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgRekeningKoran2.DataBind()
            dgRekeningKoran2.PageIndex = dgRekeningKoran2.PageIndex - 1
            dgRekeningKoran2.DataBind()

            txtGO.Value = dgRekeningKoran2.PageIndex + 1
        End If
    End Sub

    Protected Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
        'If dgRekeningKoran.CurrentPageIndex <> dgRekeningKoran.PageCount - 1 Then
        '    'dgRekeningKoran.DataSource = oSelect.f_SelRekeningKoran
        '    grid_Databinding()
        '    dgRekeningKoran.DataBind()
        '    dgRekeningKoran.CurrentPageIndex = dgRekeningKoran.CurrentPageIndex + 1
        '    dgRekeningKoran.DataBind()

        '    txtGO.Value = dgRekeningKoran.CurrentPageIndex + 1
        'End If

        'dgListApproval2.DataSource = oSelect.f_SelRekeningKoran
        If dgRekeningKoran2.PageIndex <> dgRekeningKoran2.PageCount - 1 Then
            'dgListReimbursEmployee2.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgRekeningKoran2.DataBind()
            dgRekeningKoran2.PageIndex = dgRekeningKoran2.PageIndex + 1
            dgRekeningKoran2.DataBind()

            txtGO.Value = dgRekeningKoran2.PageIndex + 1
        End If
    End Sub

    Protected Sub lnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLast.Click
        'dgRekeningKoran.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgRekeningKoran2.DataBind()
        dgRekeningKoran2.PageIndex = dgRekeningKoran2.PageCount - 1
        dgRekeningKoran2.DataBind()

        txtGO.Value = dgRekeningKoran2.PageIndex + 1
    End Sub

    Protected Sub lnkGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkGo.Click
        If IsNumeric(txtGO.Value) = True Then
            If txtGO.Value <= dgRekeningKoran2.PageCount - 1 Then
                'dgRekeningKoran.DataSource = oSelect.f_SelRekeningKoran
                grid_Databinding()
                dgRekeningKoran2.DataBind()
                dgRekeningKoran2.PageIndex = Int32.Parse(txtGO.Value) - 1
                dgRekeningKoran2.DataBind()

                txtGO.Value = dgRekeningKoran2.PageIndex + 1
            End If
        End If
    End Sub
    Protected Sub ddl_View_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_View.SelectedIndexChanged

        If ddl_View.SelectedValue = "10" Then
            grid_Databinding()
            dgRekeningKoran2.PageSize = 10
            dgRekeningKoran2.PageIndex = 0
            dgRekeningKoran2.DataBind()

            lblTotal.Text = dgRekeningKoran2.PageCount
            txtGO.Value = dgRekeningKoran2.PageIndex + 1

        ElseIf ddl_View.SelectedValue = "20" Then
            grid_Databinding()
            dgRekeningKoran2.PageSize = 20
            dgRekeningKoran2.PageIndex = 0
            dgRekeningKoran2.DataBind()

            lblTotal.Text = dgRekeningKoran2.PageCount
            txtGO.Value = dgRekeningKoran2.PageIndex + 1

        ElseIf ddl_View.SelectedValue = "50" Then
            grid_Databinding()
            dgRekeningKoran2.PageSize = 50
            dgRekeningKoran2.PageIndex = 0
            dgRekeningKoran2.DataBind()

            lblTotal.Text = dgRekeningKoran2.PageCount
            txtGO.Value = dgRekeningKoran2.PageIndex + 1

        ElseIf ddl_View.SelectedValue = "70" Then
            grid_Databinding()
            dgRekeningKoran2.PageIndex = 0
            dgRekeningKoran2.DataBind()


            lblTotal.Text = dgRekeningKoran2.PageCount
            txtGO.Value = dgRekeningKoran2.PageIndex + 1

        ElseIf ddl_View.SelectedValue = "100" Then
            grid_Databinding()
            dgRekeningKoran2.PageSize = 100
            dgRekeningKoran2.PageIndex = 0
            dgRekeningKoran2.DataBind()

            lblTotal.Text = dgRekeningKoran2.PageCount
            txtGO.Value = dgRekeningKoran2.PageIndex + 1
        End If
    End Sub
    Protected Sub btn_Hidden_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Hidden.Click
        Searching()
    End Sub

    Protected Sub Frm_List_Reimburs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Protected Sub lnkExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkExport.Click
        export()
    End Sub
    Sub export()
        Dim _EmplID As String = ""
        Dim _NameEmplo As String = ""
        Dim _TypeVeh As String = ""
        Dim _Entity As String = ""
        Dim _Nopol As String = ""
        Dim _Update As String = ""
        Dim _Range As String = ""

        Dim _flagEmplID As String
        Dim _flagNameEmplo As String
        Dim _flagTypeVeh As String = "0"
        Dim _flagEntity As String
        Dim _flagNopol As String = "0"
        Dim _FlagUpdate As String
        Dim _FlagRange As String

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
            Label3.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity.SelectedItem.Text
            Label3.Visible = False
        End If

        If chkEntity2.Checked = False Then
            _flagEntity = "0"
            Label8.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity2.SelectedItem.Text
            Label8.Visible = False
        End If

        'If chkNoPol.Checked = False Then
        '    _flagNopol = "0"
        '    lblErrNoPol.Visible = False
        'Else
        '    _flagNopol = "1"
        '    _Nopol = txtNoPol.Text
        '    lblErrNoPol.Visible = False
        'End If

        If ChkUpdate.Checked = False Then
            _FlagUpdate = "0"
            Label6.Visible = False
        Else
            _FlagUpdate = "1"
            _Update = ddlUpdate.SelectedItem.Text
            Label6.Visible = False
        End If

        If chkPeriod.Checked = False Then
            _FlagRange = "0"
            lblErrPeriod.Visible = False
        Else
            _FlagRange = "1"
            _Range = txtPeriod.Text
            lblErrPeriod.Visible = False
        End If


        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_EXPORT_PARKING_ADMIN(_EmplID, _NameEmplo, _TypeVeh, _Entity, _Nopol, _Update, _Range,
                                                    _flagEmplID, _flagNameEmplo, _flagTypeVeh, _flagEntity, _flagNopol,
                                                    _FlagUpdate, _FlagRange)

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

    Protected Sub dgRekeningKoran2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dgRekeningKoran2.RowCommand
        If e.CommandName = "cmdEdit" Then
            Dim rowIndex As Int32 = Convert.ToInt32(e.CommandArgument)

            'Session("Preview") = "Approval"
            Dim idx As String = dgRekeningKoran2.Rows(rowIndex).Cells(1).Text
            Response.Redirect("Frm_Detail_Reimburs.aspx?idx=" + idx)
        End If

    End Sub
End Class