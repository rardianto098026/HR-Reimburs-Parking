Public Class Frm_Export
    Inherits System.Web.UI.Page
    Dim oInsert As New InsertBase
    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase


    Sub Searching()
        GridDataBind()
        dg_TRN_Reimburst2.DataBind()
        dg_TRN_Reimburst2.PageSize = 100
        dg_TRN_Reimburst2.Visible = True
    End Sub

    Sub Export()
        Dim dg As New GridView
        Dim _EmplID As String = ""
        Dim _NameEmplo As String = ""
        Dim _Entity As String = ""
        Dim _Year As String = ""
        Dim _Status As String = ""

        Dim _flagEmplID As String = "0"
        Dim _flagNameEmplo As String = "0"
        Dim _flagEntity As String = "0"
        Dim _FlagYear As String = "0"
        Dim _FlagStatus As String = "0"
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

        If Not (Session("ROLES") = "ADMIN") Then
            If CheckEntity1.Checked = False Then
                _flagEntity = "0"
                'Label3.Visible = False
            Else
                _flagEntity = "1"
                _Entity = ddlEntity1.SelectedItem.Text
                'Label3.Visible = False
            End If
        End If


        If Checkstat.Checked = False Then
            _FlagStatus = "0"
            'lblErrPeriod.Visible = False
        Else
            _FlagStatus = "1"
            _Status = ddlstatus.SelectedValue
            'lblErrPeriod.Visible = False
        End If

        If chkYear.Checked = False Then
            _FlagYear = "0"
            'lblErrPeriod.Visible = False
        Else
            _FlagYear = "1"
            _Year = ddlyear.SelectedValue
            'lblErrPeriod.Visible = False
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
                Command = "SEARCH_REPORT_FTE"
            Else
                Command = "SEARCH_REPORT_NON_FTE"
            End If
        Else
            Command = "SEARCH_REPORT"
        End If


        Dim dtSelect As New DataTable

        dtSelect = oSelect.f_SEL_LIST_PARKING_REIMBURS(_EmplID, _NameEmplo, _Entity, _Status, _Year, _flagEmplID, _flagNameEmplo,
                                                    _flagEntity, _FlagStatus, _FlagYear, StatKaryawan, Command)


        dg.DataSource = dtSelect
        dg.DataBind()

        dg_TRN_Reimburst2.DataBind()
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

    Sub GridDataBind()
        Dim _EmplID As String = ""
        Dim _NameEmplo As String = ""
        Dim _Entity As String = ""
        Dim _Year As String = ""
        Dim _Status As String = ""

        Dim _flagEmplID As String = "0"
        Dim _flagNameEmplo As String = "0"
        Dim _flagEntity As String = "0"
        Dim _FlagYear As String = "0"
        Dim _FlagStatus As String = "0"
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

        If Not (Session("ROLES") = "ADMIN") Then
            If CheckEntity1.Checked = False Then
                _flagEntity = "0"
                'Label3.Visible = False
            Else
                _flagEntity = "1"
                _Entity = ddlEntity1.SelectedItem.Text
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

        If Checkstat.Checked = False Then
            _FlagStatus = "0"
            'lblErrPeriod.Visible = False
        Else
            _FlagStatus = "1"
            _Status = ddlstatus.SelectedValue
            'lblErrPeriod.Visible = False
        End If

        If chkYear.Checked = False Then
            _FlagYear = "0"
            'lblErrPeriod.Visible = False
        Else
            _FlagYear = "1"
            _Year = ddlyear.SelectedValue
            'lblErrPeriod.Visible = False
        End If

        Dim StatKaryawan As String = ""

        Dim dtSelect2 As New DataTable
        Dim empnum As String = Session("EMPLNUMBER").ToString
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
                Command = "SEARCH_REPORT_FTE"
            Else
                Command = "SEARCH_REPORT_NON_FTE"
            End If
        Else
            Command = "SEARCH_REPORT"
        End If



        Dim dtSelect As New DataTable

        dtSelect = oSelect.f_SEL_LIST_PARKING_REIMBURS(_EmplID, _NameEmplo, _Entity, _Status, _Year, _flagEmplID, _flagNameEmplo,
                                                    _flagEntity, _FlagStatus, _FlagYear, StatKaryawan, Command)

        dg_TRN_Reimburst2.DataSource = dtSelect
        'dg_TRN_Reimburst2.DataBind()
        dg_TRN_Reimburst2.PageSize = 100
        dg_TRN_Reimburst2.Visible = True
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim dtx As New DataTable
            'Dim path As String = Request.Path.ToString
            Dim path As String = System.IO.Path.GetFileName(Request.Url.AbsolutePath)
            Try
                dtx = oSelect.f_check_Access_Menu(path, Session("EMPLNUMBER").ToString)
            Catch ex As Exception
                Response.Redirect("Frm_ErrorHandler.aspx")
            End Try
            Session("ROLES") = dtx.Rows(0)("Role").ToString()
            Dim role As String = Session("ROLES")
            If dtx.Rows.Count > 0 Then
            Else
                Response.Redirect("Frm_ErrorHandler.aspx")
            End If
            If Session("ROLES") = "ADMIN" Then
                Dim dt As DataTable
                dt = oSelect.f_CHECK_MST_EMPLOYEE(Session("EMPLNUMBER").ToString, "")
                ddlEntity1.SelectedItem.Text = dt.Rows(0)("ShortEntity").ToString
            End If
            'GridDataBind()
            dg_TRN_Reimburst2.DataBind()
            dg_TRN_Reimburst2.PageSize = 100
        End If
    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub
    Protected Sub btn_Hidden_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Hidden.Click
        Searching()
    End Sub
    Protected Sub lnkExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExport.Click
        Export()
    End Sub

    Protected Sub dg_TRN_Reimburst2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dg_TRN_Reimburst2.RowCommand
        If e.CommandName = "cmdEdit" Then
            Dim rowIndex As Int32 = Convert.ToInt32(e.CommandArgument)

            Session("Preview") = "Preview"
            Dim idx As String = dg_TRN_Reimburst2.Rows(rowIndex).Cells(1).Text
            Response.Redirect("Frm_Approval.aspx?idx=" + idx)
        End If

    End Sub
End Class