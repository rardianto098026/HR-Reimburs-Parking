Public Class Export
    Inherits System.Web.UI.Page
    Dim oInsert As New InsertBase
    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase


    Sub Searching()
        GridDataBind()
        dg_TRN_Reimburst.DataBind()
        dg_TRN_Reimburst.PageSize = 100
        dg_TRN_Reimburst.Visible = True
    End Sub

    Sub Export()
        Dim dg As New GridView
        Dim _EmplID As String = ""
        Dim _NameEmplo As String = ""
        Dim _Entity As String = ""
        Dim _Year As String = ""
        Dim _Range As String = ""

        Dim _flagEmplID As String
        Dim _flagNameEmplo As String
        Dim _flagEntity As String
        Dim _FlagYear As String
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
            'Label3.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity.SelectedItem.Text
            'Label3.Visible = False
        End If

        'If chkNoPol.Checked = False Then
        '    _flagNopol = "0"
        '    lblErrNoPol.Visible = False
        'Else
        '    _flagNopol = "1"
        '    _Nopol = txtNoPol.Text
        '    lblErrNoPol.Visible = False
        'End If

        If chkPeriod.Checked = False Then
            _FlagRange = "0"
            'lblErrPeriod.Visible = False
        Else
            _FlagRange = "1"
            _Range = ddlrangeperiod.SelectedValue
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


        Dim dtSelect As New DataTable

        dtSelect = oSelect.f_SEL_LIST_PARKING_REIMBURS(_EmplID, _NameEmplo, _Entity, _Range, _Year, _flagEmplID, _flagNameEmplo,
                                                        _flagEntity, _FlagRange, _FlagYear, StatKaryawan, "EXPORT_REPORT")


        dg.DataSource = dtSelect
        dg.DataBind()

        dg_TRN_Reimburst.DataBind()
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
        Dim _Range As String = ""

        Dim _flagEmplID As String
        Dim _flagNameEmplo As String
        Dim _flagEntity As String
        Dim _FlagYear As String
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
            'Label3.Visible = False
        Else
            _flagEntity = "1"
            _Entity = ddlEntity.SelectedItem.Text
            'Label3.Visible = False
        End If

        'If chkNoPol.Checked = False Then
        '    _flagNopol = "0"
        '    lblErrNoPol.Visible = False
        'Else
        '    _flagNopol = "1"
        '    _Nopol = txtNoPol.Text
        '    lblErrNoPol.Visible = False
        'End If

        If chkPeriod.Checked = False Then
            _FlagRange = "0"
            'lblErrPeriod.Visible = False
        Else
            _FlagRange = "1"
            _Range = ddlrangeperiod.SelectedValue
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


        Dim dtSelect As New DataTable

        dtSelect = oSelect.f_SEL_LIST_PARKING_REIMBURS(_EmplID, _NameEmplo, _Entity, _Range, _Year, _flagEmplID, _flagNameEmplo,
                                                        _flagEntity, _FlagRange, _FlagYear, StatKaryawan, "SEARCH_REPORT")

        dg_TRN_Reimburst.DataSource = dtSelect
        'dg_TRN_Reimburst.DataBind()
        dg_TRN_Reimburst.PageSize = 100
        dg_TRN_Reimburst.Visible = True
    End Sub

    Sub LoadQuarter()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GET_MONTH_QUARTER()
        If dtCrit2.Rows.Count > 0 Then

            ddlrangeperiod.DataSource = dtCrit2
            ddlrangeperiod.DataValueField = "Month"
            ddlrangeperiod.DataTextField = "Month"
            ddlrangeperiod.DataBind()

            ddlrangeperiod.Items.Insert(0, New ListItem("--Choose--", "0"))

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadQuarter()
        GridDataBind()
        dg_TRN_Reimburst.DataBind()
        dg_TRN_Reimburst.PageSize = 100

    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub

    Protected Sub lnkExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExport.Click
        Export()
    End Sub
End Class