<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Export.aspx.vb" Inherits="HRReimbursParking.Export" %>
<%@ Register TagName="My" TagPrefix="Menu" Src="~/Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="~/Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="~/Menu/Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript">

    function openWindow(idx) {
        // Note: you cannot use ~/ at client side.
        var url = "Frm_Approval.aspx?idx=" + idx.toString();
        window.open(url, "", "titlebar=no'");
    }
   
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Surrounding.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" href="css/jquery-ui.css" />
<link rel="stylesheet" href="css/style.css" />
<script type="text/javascript" src="js/jquery-1.10.2.js"></script>
<script type="text/javascript" src="js/jquery-ui.js"></script>
<link rel="stylesheet" href="css/style.css" />
  <link rel="shortcut icon" href="Images/icon.ico" />
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    <style type="text/css">
        .style1
        {
            width: 116px;
        }
        .style2
        {
            width: 158px;
        }
        </style>
    <script type="text/javascript">
        $(function() {
            $("#txtSearch_BankStatementDate_Start").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

        $(function() {
            $("#txtSearch_BankStatementDate_End").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

        $(function() {
        $("#txtPolExpDateFrom").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

        $(function() {
        $("#txtPolExpDateTo").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

        $(function() {
        $("#txtClaimRecFrom").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

        $(function() {
        $("#txtClaimRecTo").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

        $(function() {
        $("#txtPaymentDateFrom").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

        $(function() {
        $("#txtPaymentDateTo").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

        $(function() {
        $("#txtDeclineDateFrom").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

        $(function() {
        $("#txtDeclineDateTo").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });
        
</script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
         <table width="1200px" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td background="Images/borderleft.gif" width="21">
                </td>
                <td align="center">
                 <Head:My ID="head" runat="server" />
                 </td>
                <td background="Images/borderRight.gif" width="21">
                </td>
            </tr>
            <tr>
                 <td width="21px" background="Images/borderleft.gif">
                    </td>
                    <td align="left" bgcolor="#0055AA">
                        <Menu:My ID="My1" runat="Server" />
                    </td>
                    <td width="21px" background="Images/borderRight.gif">
                    </td>
            </tr>
            
              
             </table>
             
        <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td background="Images/borderleft.gif" width="21" style="height: 13px">
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                       
                                              <td align ="left" height="20px">
                                            SEARCH 
                                            </td>
                                       
                                    </tr>
                                    
                                    <tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="ChkEmpl1" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                            Employee ID <asp:Label ID="lblEmplID1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="txtEmplID" runat="server" CssClass="textbox" Width="145px"></asp:TextBox>
                                            &nbsp; <asp:Label ID="lblEmplID2" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="ChkName" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          Employee Name <asp:Label ID="Label2" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox" Width="145px"></asp:TextBox>
                                            &nbsp; <asp:Label ID="lblName" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>

                                    <tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="chkEntity" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          Entity <asp:Label ID="Label1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:dropdownlist ID="ddlEntity" runat="server" CssClass="textbox" Width="145px">
                                                <asp:ListItem Text="--Choose--"></asp:ListItem> 
                                                <asp:ListItem Text="AAMI"></asp:ListItem> 
                                                <asp:ListItem Text="AFI"></asp:ListItem> 
                                                <asp:ListItem Text="ALI"></asp:ListItem> 
                                                <asp:ListItem Text="AMFS"></asp:ListItem> 
                                                <asp:ListItem Text="ASI"></asp:ListItem> 
                                                <asp:ListItem Text="AXATECH"></asp:ListItem> 
                                                <asp:ListItem Text="MAGI"></asp:ListItem> 
                                            </asp:dropdownlist>
                                            &nbsp; <asp:Label ID="lblEntity" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>

                                    <tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="chkPeriod" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          Range Period <asp:Label ID="Label4" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:DropDownList ID="ddlrangeperiod" runat="server"  CssClass="textbox" Width="145px">
                                            </asp:DropDownList>
                                            &nbsp; <asp:Label ID="lblRangeP" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>

                                    <tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="chkYear" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          Year <asp:Label ID="Label6" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:dropdownlist ID="ddlyear" runat="server" CssClass="textbox" Width="145px">
                                                <asp:ListItem Text="--Choose--" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                            </asp:dropdownlist>
                                            &nbsp; <asp:Label ID="Label7" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td align="left">
                                        <asp:LinkButton ID="Search" runat="server" Width="50px" >SEARCH</asp:LinkButton>&nbsp;&nbsp;
                                        <asp:LinkButton ID="lnkExport" runat="server" Width="50px" >EXPORT</asp:LinkButton>
                                        </td>
                                    </tr>
                                    </table>
                                </td>
                            <td></td>
                            </tr>
            </table>
            <table width="1200px">
                <tr></tr>
                <tr>
                                    <td align ="left" height="20px" class="style2">
                                        </td>
                                    <td width="76%"  align ="left">
                                    </td>
                            </tr>
            </table>
        <div style='overflow:auto;height:200%;width:1200px;text-align:center;margin:0 auto';align="center" >
        <asp:DataGrid ID="dg_TRN_Reimburst" runat="server" 
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                            BorderStyle="None" BorderWidth="1px" CellPadding="1" CssClass="tDatagridITReview" 
                            Height="100%" AllowSorting="True" PageSize="10" AllowPaging="true"
                            Width="1200px">
                            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <AlternatingItemStyle CssClass="GridAltITReview" />
                            <ItemStyle CssClass="GridItemITReview" ForeColor="Black" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="GridHeader" ForeColor="White" Font-Bold="True" HorizontalAlign="Center" />
                            <FooterStyle BackColor="White" ForeColor="#000066"/>
                            <Columns>	
                                    
                                    <asp:BoundColumn  DataField="NUMBER" HeaderText="No." HeaderStyle-Width="5px" SortExpression="NUMBER ASC" Visible="true">
                                    <HeaderStyle Width="5px"></HeaderStyle>
                                    </asp:BoundColumn>
                                
                                    <asp:BoundColumn  DataField="EmployeeID" HeaderText="ID Pegawai" HeaderStyle-Width="150px" SortExpression="EmployeeID ASC" Visible="true">
                                    <HeaderStyle Width="50px"></HeaderStyle>
                                    </asp:BoundColumn>
                               
								    <asp:BoundColumn  DataField="EmployeeName" HeaderText="Nama Karyawan" HeaderStyle-Width="200px" SortExpression="EmployeeName ASC" Visible="true">
                                    <HeaderStyle Width="200px"></HeaderStyle>
                                    </asp:BoundColumn>
                                    
								    <asp:BoundColumn  DataField="Entity" HeaderText="Entity" HeaderStyle-Width="200px" SortExpression="Entity ASC" Visible="true">
                                    <HeaderStyle Width="200px"></HeaderStyle>
                                    </asp:BoundColumn>

                                    <asp:BoundColumn  DataField="Type_Vehicle" HeaderText="Jenis Kendaraan" HeaderStyle-Width="100px" SortExpression="Type_Vehicle ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>
                                
                                    <asp:BoundColumn  DataField="AMOUNT" HeaderText="Amount" HeaderStyle-Width="100px" SortExpression="AMOUNT ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>

                                    <asp:BoundColumn  DataField="NoPol_1" HeaderText="NoPol_1" HeaderStyle-Width="100px" SortExpression="NoPol_1 ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>

                                    <asp:BoundColumn  DataField="NoPol_2" HeaderText="NoPol_2" HeaderStyle-Width="100px" SortExpression="NoPol_2 ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>
                                
                                    <asp:BoundColumn  DataField="RangePeriod" HeaderText="Range Period" HeaderStyle-Width="100px" SortExpression="RangePeriod ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>
                                
                                    <asp:BoundColumn  DataField="Period_1" HeaderText="Period_1" HeaderStyle-Width="100px" SortExpression="Period_1 ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>
                                
                                    <asp:BoundColumn  DataField="Period_2" HeaderText="Period_2" HeaderStyle-Width="100px" SortExpression="Period_2 ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>
                                
                                    <asp:BoundColumn  DataField="Period_3" HeaderText="Period_3" HeaderStyle-Width="100px" SortExpression="Period_3 ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>
                                
                                    <asp:BoundColumn  DataField="TotalPeriod" HeaderText="TotalPeriod" HeaderStyle-Width="100px" SortExpression="TotalPeriod ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>

                                    <asp:BoundColumn  DataField="TOTAL_AMOUNT" HeaderText="Total Amount" HeaderStyle-Width="100px" SortExpression="TOTAL_AMOUNT ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>
                                
                                    <asp:BoundColumn  DataField="Year" HeaderText="Year" HeaderStyle-Width="100px" SortExpression="Year ASC" Visible="true">
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundColumn>
                                
                                 
                                </Columns>
                           <PagerStyle CssClass="GridPaging" HorizontalAlign="Left" Visible="False" />
                       </asp:DataGrid>
              </div>
               <div style='overflow:auto;width:1000px;text-align:center;margin:0 auto';align="center">
                    <asp:Panel ID="pnlfooter" runat="server">
                        <table id="tablepaging" runat="server" width="1000px">
                        <tr>
                            <td align="left" width="15px">
                                <asp:LinkButton ID="lbFirst" runat="server">First </asp:LinkButton>
                            </td>
                            <td align="left" width="10px">
                                <asp:LinkButton ID="lbPrev" runat="server">Prev </asp:LinkButton>
                            </td>
                            <td align="center" width="120px" valign="middle" >
                                <input type="text" class="textbox_2" runat="server" id="txtGO"/> OF 
                                <asp:Label ID="lblTotal" runat="server" Text="-"></asp:Label>
                                &nbsp; <asp:LinkButton ID="lnkGo" runat="server">GO </asp:LinkButton>
                            </td>
                            <td align="left" width="10px">
                                 <asp:LinkButton ID="lnkNext" runat="server">Next </asp:LinkButton>
                            </td>
                             <td align="left" width="10px">
                                 <asp:LinkButton ID="lnkLast" runat="server">Last </asp:LinkButton>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;Total Records : <asp:Label ID="lblTotalRecords" runat="server" Text="0 record(s)"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        
                    </table>
                   </asp:Panel>
                   
                   <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    
                    <td height="30" >
                        Data per View :
                        <asp:DropDownList ID="ddl_View" runat="server" AutoPostBack="true">
                            <asp:ListItem>-- Choose --</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>70</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td background="Images/borderRight.gif" width="21" style="height: 13px">
                    </td>
                </tr>
                
        </table>
                </div> 
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
                
     
                </table>
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
                <tr>
                    <td background="Images/borderleft.gif" width="21">
                    </td>
                    <td background="Images/bg_line.gif" class="style1">
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                    </td>
                </tr>
                
        </table>
        
              <br />
              <Footer:My ID="My3" runat="server" />
    </div>
                            
    </form>
</body>
</html>