Public Partial Class Frm_Detail_Reimburs
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase
    Dim oInsert As New InsertBase
    Sub bindData(ByVal IDX As String)
        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LOAD_DATA_PARKING_ADMIN(IDX)
        If dtSelect.Rows.Count > 0 Then

            lblID2.Text = dtSelect.Rows(0)("IDKaryawan").ToString()
            lblNamaKaryawan.Text = dtSelect.Rows(0)("NamaKaryawan").ToString()
            lblEntity.Text = dtSelect.Rows(0)("Entity").ToString()
            lblNoPolExisting.Text = dtSelect.Rows(0)("NoPol_Existing").ToString()
            lblNoPolExisting2.Text = dtSelect.Rows(0)("NoPol_Existing2").ToString()
            lblTypeKendExisting.Text = dtSelect.Rows(0)("TypeKendaraan_Existing").ToString()
            txtNoPolUpdate.Text = dtSelect.Rows(0)("NoPol_Update").ToString()
            txtNoPolUpdate2.Text = dtSelect.Rows(0)("NoPol_Update2").ToString()
            ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByText(dtSelect.Rows(0)("TypeKendaraan_Update").ToString()))
            ddlSingle.SelectedIndex = ddlSingle.Items.IndexOf(ddlSingle.Items.FindByText(dtSelect.Rows(0)("SINGLEORDOUBLE").ToString()))
            lblRange.Text = dtSelect.Rows(0)("RangePeriod").ToString()
            Label17.Text = dtSelect.Rows(0)("SINGLEORDOUBLE_EXISTING").ToString()

            Dim ChkP3S As String = dtSelect.Rows(0)("Period_1").ToString()
            Dim ChkP4S As String = dtSelect.Rows(0)("Period_2").ToString()
            Dim ChkP5S As String = dtSelect.Rows(0)("Period_3").ToString()

            If ChkP3S = "Y" Then
                chkP3.Checked = True
            End If
            If ChkP4S = "Y" Then
                chkP4.Checked = True
            End If
            If ChkP5S = "Y" Then
                chkP5.Checked = True
            End If
            txtRemarks.SelectedIndex = txtRemarks.Items.IndexOf(txtRemarks.Items.FindByText(dtSelect.Rows(0)("Remarks").ToString()))


            Selected()
            Selected2()

            If txtNoPolUpdate.Text <> "" And ddl.SelectedItem.Text = "CAR" Then
                NoPol4.Visible = True
                Dim tabID2 As Integer = GetIntOnly(txtNoPolUpdate.Text)
                If Right(tabID2, 1) Mod 2 = 0 Then
                    NoPol4.Text = "Even"
                Else
                    NoPol4.Text = "Odd"
                End If
            Else
                NoPol4.Text = ""
                NoPol4.Visible = False
            End If

            If txtNoPolUpdate2.Text <> "" And ddl.SelectedItem.Text = "CAR" And ddlSingle.SelectedItem.Text = "DOUBLE" Then
                Dim tabID2 As Integer = GetIntOnly(txtNoPolUpdate2.Text)
                If Right(tabID2, 1) Mod 2 = 0 Then
                    Textbox2.Text = "Even"
                Else
                    Textbox2.Text = "Odd"
                End If
            Else
                Textbox2.Text = ""
                Textbox2.Visible = False
            End If

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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session("_idx") = Request.QueryString("idx").ToString
            bindData(Session("_idx"))
            countData()
        End If
    End Sub
    Public Sub Alert()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Try
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then
                If chkUpdate.Checked = True Then
                    If txtNoPolUpdate.Text = "" Then
                        Label12.Visible = True
                        Exit Sub
                    End If

                    If ddl.SelectedItem.Text = "--Choose--" Then
                        Label13.Visible = True
                        Exit Sub
                    End If


                    If ddl.SelectedItem.Text = "MOTORCYCLE" Then
                        ddlSingle.SelectedItem.Text = ""
                    End If

                    If ddl.SelectedItem.Text = "CAR" Then
                        If ddlSingle.SelectedItem.Text = "" Then
                            Label23.Visible = True
                            Exit Sub
                        End If
                        If ddlSingle.SelectedItem.Text = "DOUBLE" And txtNoPolUpdate2.Text = "" Then
                            Label21.Visible = True
                            Exit Sub
                        End If
                    End If


                    If ddl.SelectedItem.Text = "CAR" Then
                        If ddlSingle.SelectedItem.Text = "DOUBLE" Then

                            If (NoPol4.Text = "Even" And Textbox2.Text = "Even") Or (NoPol4.Text = "Odd" And Textbox2.Text = "Odd") Then
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
                                Exit Sub
                            End If
                        End If
                    End If
                End If


                Dim _total As String = EditData()

                Label7.Visible = False
                Label12.Visible = False
                Label23.Visible = False
                Label13.Visible = False
                Label21.Visible = False

                Dim message As String


                message = "Save Data Success"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                countData()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("Frm_List_Reimburs.aspx")
    End Sub
    Private Function EditData() As String
        Dim rows As Integer
        Submit()
        Return rows
    End Function
    Public Function Submit() As String
        Dim rows As String = ""
        Dim P3 As String
        Dim P4 As String
        Dim P5 As String
        Try
            If chkP3.Checked = True Then
                P3 = "Y"
            Else
                P3 = "N"
            End If

            If chkP4.Checked = True Then
                P4 = "Y"
            Else
                P4 = "N"
            End If

            If chkP5.Checked = True Then
                P5 = "Y"
            Else
                P5 = "N"
            End If


            oUpdate.f_EDITDATA_PARKING(lblID2.Text, lblNamaKaryawan.Text, lblNoPolExisting.Text, lblTypeKendExisting.Text,
                                       txtNoPolUpdate.Text, ddl.SelectedItem.Text, P3, P4, P5, txtRemarks.SelectedItem.Text,
                                       Session("UserID").ToString, lblEntity.Text, lblRange.Text, txtNoPolUpdate2.Text,
                                       lblNoPolExisting2.Text, ddlSingle.SelectedItem.Text, Label17.Text)

        Catch ex As Exception

        End Try
        Return rows
    End Function
    Protected Sub chkUpdate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUpdate.CheckedChanged
        If chkUpdate.Checked = True Then
            txtNoPolUpdate.Enabled = True
            ddl.Enabled = True
            ddlSingle.Enabled = True
            txtNoPolUpdate2.Enabled = True
        Else
            txtNoPolUpdate.Enabled = False
            ddl.Enabled = False
            ddlSingle.Enabled = False
            txtNoPolUpdate2.Enabled = False
        End If
    End Sub
    Sub Selected()
        If ddl.SelectedItem.Text = "CAR" Then
            trSingle.Visible = True
            Textbox2.Visible = False
            NoPol4.Visible = True
            If ddlSingle.SelectedItem.Text = "DOUBLE" Then
                trHide.Visible = True
                Textbox2.Visible = True
                NoPol4.Visible = True
            Else
                trHide.Visible = False
                Textbox2.Visible = False
                NoPol4.Visible = True

                btnSubmit.Enabled = True
            End If
        Else
            trSingle.Visible = False
            trHide.Visible = False
            Textbox2.Visible = False
            NoPol4.Visible = False
            txtNoPolUpdate2.Text = ""
            ddlSingle.SelectedIndex = ddlSingle.Items.IndexOf(ddlSingle.Items.FindByText(""))

            txtNoPolUpdate.BackColor = Drawing.Color.White
            btnSubmit.Enabled = True
        End If

        If ddlSingle.SelectedItem.Text.ToUpper() = "DOUBLE" Then
            txtNoPolUpdate.Text = lblNoPolExisting.Text
            Dim tabID2 As Integer = GetIntOnly(txtNoPolUpdate.Text)
            If Right(tabID2, 1) Mod 2 = 0 Then
                NoPol4.Text = "Even"
            Else
                NoPol4.Text = "Odd"
            End If
        End If
    End Sub
    Sub Selected2()
        If ddlSingle.SelectedItem.Text = "DOUBLE" Then
            trHide.Visible = True
            Textbox2.Visible = True
            NoPol4.Visible = True
            If txtNoPolUpdate2.Text = "" Then
                txtNoPolUpdate2.Text = ""

                Textbox2.Text = ""
            End If

            txtNoPolUpdate.BackColor = Drawing.Color.White
            txtNoPolUpdate2.BackColor = Drawing.Color.White
        Else
            Textbox2.Visible = False
            NoPol4.Visible = True
            trHide.Visible = False
            txtNoPolUpdate2.Text = ""
            Textbox2.Text = ""
            txtNoPolUpdate.BackColor = Drawing.Color.White
            txtNoPolUpdate2.BackColor = Drawing.Color.White
        End If

        If ddlSingle.SelectedItem.Text.ToUpper() = "DOUBLE" Then
            txtNoPolUpdate.Text = lblNoPolExisting.Text
            Dim tabID2 As Integer = GetIntOnly(txtNoPolUpdate.Text)
            If Right(tabID2, 1) Mod 2 = 0 Then
                NoPol4.Text = "Even"
            Else
                NoPol4.Text = "Odd"
            End If
        End If
    End Sub
    Protected Sub ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl.SelectedIndexChanged
        Selected()

    End Sub

    Protected Sub ddlSingle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSingle.SelectedIndexChanged
        Selected2()

    End Sub
    Protected Sub txtNoPolUpdate2_TextChanged(sender As Object, e As EventArgs) Handles txtNoPolUpdate2.TextChanged
        If txtNoPolUpdate2.Text <> "" And ddl.SelectedItem.Text = "CAR" And ddlSingle.SelectedItem.Text = "DOUBLE" Then
            Dim tabID2 As Integer = GetIntOnly(txtNoPolUpdate2.Text)
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
            txtNoPolUpdate.BackColor = Drawing.Color.Red
            txtNoPolUpdate2.BackColor = Drawing.Color.Red

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
            txtNoPolUpdate.BackColor = Drawing.Color.White
            txtNoPolUpdate2.BackColor = Drawing.Color.White
            btnSubmit.Enabled = True
        End If
    End Sub

    Protected Sub txtNoPolUpdate_TextChanged(sender As Object, e As EventArgs) Handles txtNoPolUpdate.TextChanged
        If txtNoPolUpdate.Text <> "" And ddl.SelectedItem.Text = "CAR" Then
            NoPol4.Visible = True
            Dim tabID2 As Integer = GetIntOnly(txtNoPolUpdate.Text)
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
            txtNoPolUpdate.BackColor = Drawing.Color.Red
            txtNoPolUpdate2.BackColor = Drawing.Color.Red

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
            txtNoPolUpdate.BackColor = Drawing.Color.White
            txtNoPolUpdate2.BackColor = Drawing.Color.White
            btnSubmit.Enabled = True
        End If
    End Sub
End Class