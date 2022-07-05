Public Class Frm_Expired
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Dim oUpdateBase As New UpdateBase
    Dim oInsert As New InsertBase
    Sub Quarter()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_QUARTER_LOAD()
        If dtCrit2.Rows.Count > 0 Then
            'ddlPaymentDetails3.Items.Insert(0, New ListItem("--Choose--", "0"))
            ddlQuater.DataSource = dtCrit2
            ddlQuater.DataValueField = "Quarters"
            ddlQuater.DataTextField = "Quarters"
            ddlQuater.DataBind()

        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Quarter()
            loadData()
        End If
    End Sub
    Public Sub Alert()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Sub loadData()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_LIST_MST_EXPIRED()

        dgRekeningKoran.PageSize = 100
        dgRekeningKoran.DataSource = dtCrit2
        dgRekeningKoran.Visible = True

        dgRekeningKoran.DataBind()
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" Then
            If txtDate.Text = "" Then
                lblErr.Visible = True
                lblErr.Text = "Please Choose Date"
                Exit Sub
            End If

            oInsert.f_INSERT_MST_EXPIRED(ddlQuater.SelectedItem.Text, ddlYear.SelectedItem.Text, txtDate.Text, Session("UserID").ToString, lblPeriod.Text)

            Dim message As String
            message = "Save Data Sukses"

            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            loadData()
        End If

    End Sub

    Protected Sub dgRekeningKoran_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dgRekeningKoran.ItemCommand
        If e.CommandName = "cmdSelect" Then
            ddlQuater.SelectedIndex = ddlQuater.Items.IndexOf(ddlQuater.Items.FindByText(dgRekeningKoran.Items(e.Item.ItemIndex).Cells(2).Text))
            txtDate.Text = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(4).Text
            ddlYear.SelectedIndex = ddlYear.Items.IndexOf(ddlYear.Items.FindByText(dgRekeningKoran.Items(e.Item.ItemIndex).Cells(5).Text))
            lblPeriod.Text = dgRekeningKoran.Items(e.Item.ItemIndex).Cells(3).Text
        End If
    End Sub

    Protected Sub ddlQuater_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlQuater.SelectedIndexChanged
        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_QUARTER(ddlQuater.SelectedItem.Text)
        If dtSelect.Rows.Count > 0 Then
            lblPeriod.Text = dtSelect.Rows(0)("Month").ToString()
        End If
    End Sub
End Class