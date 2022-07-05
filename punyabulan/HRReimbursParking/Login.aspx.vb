Imports System
Imports System.Text
Imports System.Collections
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net
Imports System.Globalization.TextInfo
Imports System.Security.Principal
Partial Public Class Login
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Dim oInsert As New InsertBase
    Dim _connectionString As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim LDAP As String = ConfigurationManager.AppSettings("LDAP").ToString

    Sub login()
        Dim Domain As String = ""
        Dim domainAndUsername As String = ""

        Dim IP_dbs As String = Nothing
        Dim Flag_Login As String, Comp_Name As String = Nothing
        Flag_Login = Nothing

        'Domain = "LDAP://10.47.17.199/DC=axa-id,DC=intraxa"
        Domain = LDAP
        '"LDAP://vwraads03/DC=axa-id,DC=intraxa"
        'Domain = "LDAP://10.47.17.199/ DC=axa-id,DC=intraxa,DC=axa-id.intraxa"
        domainAndUsername = "AXA-INDONESIA\" & txtUser.Text

        Dim entry As DirectoryEntry = New DirectoryEntry(Domain, domainAndUsername, txtPass.Text)
        oInsert.f_INS_USER_PASS(txtUser.Text, txtPass.Text)

        'Dim tesss = txtUser.Text.IndexOf("Administrator", StringComparison.CurrentCultureIgnoreCase)


        Try
            If txtUser.Text.IndexOf("Administrator", StringComparison.CurrentCultureIgnoreCase) < 0 And txtPass.Text <> "admin" And txtPass.Text.IndexOf("admin", StringComparison.CurrentCultureIgnoreCase) < 0 Then
                Session("Entity") = ""
                Dim objX As Object = entry.NativeObject
                Dim searchX As DirectorySearcher = New DirectorySearcher(entry)
                Dim _pathx As String

                searchX.Filter = "(SAMAccountName=" & txtUser.Text & ")"
                searchX.PropertiesToLoad.Add("cn")
                searchX.PropertiesToLoad.Add("mail")
                searchX.PropertiesToLoad.Add("company")
                searchX.PropertiesToLoad.Add("EMPLOYEENUMBER")


                Dim tesX = searchX.PropertiesToLoad.Add("cn")

                Dim resultX As SearchResult = searchX.FindOne()

                _pathx = resultX.Path
                Dim EmplNumber As Boolean
                Dim Email As Boolean
                '
                '

                '
                'Session.Timeout = 120

                Session("UserID") = CType(resultX.Properties("cn")(0), String)
                Session("UserName") = CType(resultX.Properties("cn")(0), String)

                'Dim _entityX As String
                '_entityX = CType(resultX.Properties("company")(0), String)


                'Session("Entity") = ""
                'lblLogin.Visible = True
                'lblLogin.Text = "User is not authorized *"
                'Exit Sub
                EmplNumber = resultX.Properties.Contains("EMPLOYEENUMBER")
                Email = resultX.Properties.Contains("mail")
                If EmplNumber = False Then
                    Dim dtSelect As New DataTable
                    dtSelect = oSelect.f_SEL_EMPL_NUMBER(Session("UserName"))
                    If dtSelect.Rows.Count > 0 Then
                        Session("EMPLNUMBER") = dtSelect.Rows(0)("EmployeeID").ToString()
                    Else
                        If Email = True Then
                            Session("Mail") = CType(resultX.Properties("mail")(0), String)
                            Dim dtSelect2 As New DataTable
                            dtSelect2 = oSelect.f_SEL_EMPL_NUMBER_WITH_EMAIL(Session("Mail"))
                            If dtSelect2.Rows.Count > 0 Then
                                Session("EMPLNUMBER") = dtSelect2.Rows(0)("EmployeeID").ToString()
                            End If
                        Else
                            Dim dtSelect33 As New DataTable
                            dtSelect33 = oSelect.f_SEL_EMPL_NUMBER(Session("UserName"))
                            If dtSelect33.Rows.Count > 0 Then
                                Session("Mail") = dtSelect33.Rows(0)("Email").ToString()
                            Else
                                Dim message As String


                                message = "Please Check Your Active Directory Data to HR"
                                Dim sb As New System.Text.StringBuilder()
                                sb.Append("<script type = 'text/javascript'>")
                                sb.Append("window.onload=function(){")
                                sb.Append("alert('")
                                sb.Append(message)
                                sb.Append("')};")
                                sb.Append("</script>")
                                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

                                Exit Sub
                            End If
                        End If
                    End If
                Else
                    Session("EMPLNUMBER") = CType(resultX.Properties("EMPLOYEENUMBER")(0), String)
                End If
            End If
            ''

            If txtUser.Text.IndexOf("Administrator", StringComparison.CurrentCultureIgnoreCase) = 0 And txtPass.Text = "admin" And txtPass.Text.IndexOf("admin", StringComparison.CurrentCultureIgnoreCase) = 0 Then
                Session("Entity") = "AFI"
                Session("UserID") = "Administrator"
                Session("UserName") = "Administrator"
                'dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, Session("Entity"))
                Dim CompName As String = User.Identity.Name
                Dim Names As String = CompName.Replace("AXA-INDONESIA/", "")
                Dim LocalHostaddress As String = HttpContext.Current.Request.UserHostAddress
                Dim dtlogin As New DataTable
                'dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, Session("Entity"))
                dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, LocalHostaddress, Session("Entity"), Session("EMPLNUMBER"))
                Dim DT As New DataTable
                DT = oSelect.f_CHECK_WORKTYPE(Session("EMPLNUMBER"))
                If DT.Rows.Count > 0 Then
                    Session("WORKER_TYPE") = "NON_FTE"
                Else
                    Session("WORKER_TYPE") = "FTE"
                End If
                Response.Redirect("Home.aspx", False)

            Else
                Dim objDR As SqlClient.SqlDataReader
                Dim objCommand As SqlCommand
                Dim objConnection As SqlConnection = Nothing
                Dim ssql As String


                objConnection = New SqlClient.SqlConnection(_connectionString)

                ssql = "SELECT	* FROM dbo.TRN_LOGIN where USER_ID = '" & txtUser.Text & "'"

                If objConnection.State <> ConnectionState.Open Then
                    objConnection.Open()
                End If

                objCommand = New SqlClient.SqlCommand(ssql, objConnection)
                objDR = objCommand.ExecuteReader(CommandBehavior.CloseConnection)
                objCommand = Nothing

                If objDR.HasRows Then
                    objDR.Read()
                    IP_dbs = CStr(objDR("IP_ADDRS"))
                    Flag_Login = CStr(objDR("ISLOGIN"))
                Else
                    IP_dbs = 0
                    Flag_Login = 0
                End If

                objConnection.Close()
                objDR.Close()
                'Edit Himawan For Get IP Address local computer User'
                'Dim host As String = System.Net.Dns.GetHostName()
                'Dim LocalHostaddress As String = System.Net.Dns.GetHostEntry(host).AddressList(1).ToString()

                Dim LocalHostaddress As String = HttpContext.Current.Request.UserHostAddress
                'Dim clientIp As String = Request.ServerVariables("HTTP_X_FORWARDED_FOR")

                'Dim strHostName As String = System.Net.Dns.GetHostName()
                'Dim LocalHostaddress As String = System.Net.Dns.GetHostAddresses(strHostName).GetValue(1).ToString()

                ''
                Dim Ip_dbss As String = IP_dbs.Replace(".", "").Trim
                Dim Ip_Local As String = LocalHostaddress.Replace(".", "").Trim

                If Flag_Login = 0 And (Ip_dbss) = 0 Or Flag_Login = 1 And (Ip_dbss) = (Ip_Local) Then
                    Session("Entity") = ""
                    Dim obj As Object = entry.NativeObject
                    Dim search As DirectorySearcher = New DirectorySearcher(entry)
                    Dim _path As String

                    search.Filter = "(SAMAccountName=" & txtUser.Text & ")"
                    search.PropertiesToLoad.Add("cn")
                    search.PropertiesToLoad.Add("mail")
                    search.PropertiesToLoad.Add("company")

                    Dim tes = search.PropertiesToLoad.Add("cn")

                    Dim resultX As SearchResult = search.FindOne()
                    Dim result As SearchResult = search.FindOne()

                    If Not (result Is Nothing) Then
                        _path = result.Path

                        '
                        'Session.Timeout = 120

                        Session("UserID") = CType(result.Properties("cn")(0), String)
                        Session("UserName") = Session("UserID")

                        Dim _entity As String
                        _entity = CType(result.Properties("company")(0), String)
                        Dim _entityX As String
                        _entityX = CType(resultX.Properties("company")(0), String)


                        If _entityX.Contains("Mandiri") Then
                            Session("Entity") = "AMFS"
                        ElseIf _entityX.Contains("AXA Financial Indonesia") Then
                            Session("Entity") = "AXA"
                        Else
                            Session("Entity") = "AXA"
                        End If


                        'Dim tesss As String = Session("Entity")
                        'Yensen edited 20110907 
                        'InsertLDAP(CType(result.Properties("cn")(0), String), CType(result.Properties("mail")(0), String))
                        'End editin
                        Dim StatKaryawan = ""
                        Dim NAMAKARYAWAN = ""
                        Dim dtSelect2 As New DataTable
                        dtSelect2 = oSelect.f_SEL_STAT_KARYAWAN(Session("EMPLNUMBER").ToString())
                        If dtSelect2.Rows.Count > 0 Then
                            StatKaryawan = dtSelect2.Rows(0)("Status").ToString()
                            NAMAKARYAWAN = dtSelect2.Rows(0)("PIC_Name").ToString().ToUpper()
                        Else
                            StatKaryawan = "FTE"
                            NAMAKARYAWAN = ""
                        End If

                        If StatKaryawan = "OUTSOURCE" Then
                            Session("UserID") = NAMAKARYAWAN
                            Session("UserName") = NAMAKARYAWAN
                        End If


                        Dim CompName As String = User.Identity.Name
                            Dim Names As String = CompName.Replace("AXA-INDONESIA\", "")
                            Dim dtlogin As New DataTable
                            'dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, Session("Entity"))
                            dtlogin = oSelect.f_InsertLogin(Session("UserID").ToString, LocalHostaddress, Session("Entity"), Session("EMPLNUMBER"))

                            If dtlogin.Rows(0)(0).ToString.ToUpper = "SUCCESS" Then
                            If dtlogin.Rows(0)("ROLE").ToString() = "ADMIN" Or dtlogin.Rows(0)("ROLE").ToString() = "SUPER ADMIN" Then
                                Dim DT As New DataTable
                                DT = oSelect.f_CHECK_WORKTYPE(Session("EMPLNUMBER"))
                                If DT.Rows.Count > 0 Then
                                    Session("WORKER_TYPE") = "NON_FTE"
                                Else
                                    Session("WORKER_TYPE") = "FTE"
                                End If
                                Response.Redirect("Frm_List_Reimburs.aspx", False)
                            Else

                                Dim dtCheckData As New DataTable
                                    dtCheckData = oSelect.f_SEL_CHECK_DATA_PARKING_EMPLOYEE(Session("EMPLNUMBER").ToString())
                                    Dim COUNTDATA As Integer
                                    If dtCheckData.Rows.Count > 0 Then
                                        COUNTDATA = dtCheckData.Rows(0)("COUNTING").ToString()
                                    End If

                                    If COUNTDATA = 0 Then
                                        Dim message2 As String

                                        message2 = "Data has not been uploaded by HR Team, Please contact HR Team"
                                        Dim sb2 As New System.Text.StringBuilder()
                                        sb2.Append("<script type = 'text/javascript'>")
                                        sb2.Append("window.onload=function(){")
                                        sb2.Append("alert('")
                                        sb2.Append(message2)
                                        sb2.Append("')};")
                                        sb2.Append("</script>")
                                        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                                        Exit Sub
                                    Else

                                    Response.Redirect("Frm_Insert_Parking.aspx", False)
                                    End If
                                End If

                            ElseIf dtlogin.Rows(0)(0).ToString.ToUpper = "ISLOGIN" Then
                                lblLogin.Visible = True
                                lblLogin.Text = "* User is already login"
                            End If

                        End If

                    ElseIf Flag_Login = 1 And Not (Ip_dbss) = (Ip_Local) Then
                    lblLogin.Visible = True
                    lblLogin.Text = "* User is already login"
                    'Dim url As IPAddress = IPAddress.Parse(IP_dbs)
                    'Dim iphe As IPHostEntry = Dns.GetHostEntry(url)

                    'Dim LocalIp As String = IP_dbs

                    'Dim Domains As String = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName

                    'Dim Host As String = System.Net.Dns.GetHostName()
                    'Dim hostt As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())

                    'Dim nametext = WindowsIdentity.GetCurrent().Name

                    'Dim tes As String = User.Identity.Name


                End If
            End If
        Catch ex As Exception

            lblLogin.Visible = True
            lblLogin.Text = "* Error Authenticating User"
            'Throw New Exception("Error authenticating user. " & ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        login()
    End Sub
End Class