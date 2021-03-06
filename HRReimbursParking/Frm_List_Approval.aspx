<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_List_Approval.aspx.vb" Inherits="HRReimbursParking.Frm_List_Approval" %>
<%@ Register TagName="My" TagPrefix="Menu" Src="~/Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="~/Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="~/Menu/Footer.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript">

    function openWindow(idx) {
        // Note: you cannot use ~/ at client side.
        var url = "Frm_Approval.aspx?idx=" + idx.toString();
        window.location.href = url;
        //window.open(url, "", "titlebar=no'");
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

<body onbeforeUnload="bodyUnload();" onclick="clicked=true;" oncontextmenu="return false">
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
                                            <asp:TextBox ID="txtEmplID" runat="server" CssClass="textbox" Width ="145px"></asp:TextBox>
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
                                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox" Width ="145px"></asp:TextBox>
                                            &nbsp; <asp:Label ID="lblName" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="chkYear" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                            Year <asp:Label ID="Label5" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
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
                                                <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                                <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                            </asp:dropdownlist>
                                            &nbsp; <asp:Label ID="Label7" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    
                                    <%--<tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="chkTypeKend" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                            Type Vehicle <asp:Label ID="lblCount" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:Dropdownlist ID="ddl" runat="server" CssClass="textbox">
                                            <asp:ListItem Text="--Chooese--"></asp:ListItem> 
                                            <asp:ListItem Text="Car"></asp:ListItem> 
                                            <asp:ListItem Text="Motorcycle"></asp:ListItem> 
                                            </asp:Dropdownlist>
                                            &nbsp; <asp:Label ID="lblErrType" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>--%>
                                    
                                    <% if(Session("ROLES") = "ADMIN") Then  %>
                                    <tr style="visibility:hidden">
                                        <td align ="right">
                                            <asp:CheckBox ID="chkEntity2" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                            Entity <asp:Label ID="Label4" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:Dropdownlist ID="ddlEntity2" runat="server" CssClass="textbox" Width ="145px">
                                            <asp:ListItem Text="--Choose--"></asp:ListItem> 
                                            <asp:ListItem Text="AAMI"></asp:ListItem> 
                                            <asp:ListItem Text="AFI"></asp:ListItem> 
                                            <asp:ListItem Text="ALI"></asp:ListItem> 
                                            <asp:ListItem Text="AMFS"></asp:ListItem> 
                                            <asp:ListItem Text="ASI"></asp:ListItem> 
                                            <asp:ListItem Text="AXATECH"></asp:ListItem> 
                                            <asp:ListItem Text="MAGI"></asp:ListItem> 
                                            </asp:Dropdownlist>
                                            &nbsp; <asp:Label ID="Label6" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <% Else %>
                                    <tr style="visibility:visible">
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
                                            <asp:Dropdownlist ID="ddlEntity" runat="server" CssClass="textbox" Width ="145px">
                                            <asp:ListItem Text="--Choose--"></asp:ListItem> 
                                            <asp:ListItem Text="AAMI"></asp:ListItem> 
                                            <asp:ListItem Text="AFI"></asp:ListItem> 
                                            <asp:ListItem Text="ALI"></asp:ListItem> 
                                            <asp:ListItem Text="AMFS"></asp:ListItem> 
                                            <asp:ListItem Text="ASI"></asp:ListItem> 
                                            <asp:ListItem Text="AXATECH"></asp:ListItem> 
                                            <asp:ListItem Text="MAGI"></asp:ListItem> 
                                            </asp:Dropdownlist>
                                            &nbsp; <asp:Label ID="Label3" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <% END IF %>
                                    
                                    
                                    <%--<tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="chkNoPol" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                            No Pol <asp:Label ID="Label4" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="txtNoPol" runat="server" CssClass="textbox"></asp:TextBox>
                                            &nbsp; <asp:Label ID="lblErrNoPol" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>--%>
                                    
                                   
                                    <tr>
                                        <td align ="right">
                                            &nbsp;</td>
                                        <td align ="left" height="20px" class="style2">
                                            &nbsp;</td>
                                         <td align ="left" width="100px">
                                            
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:LinkButton ID="Search" runat="server" Width="50px" >SEARCH</asp:LinkButton>
                                            <asp:LinkButton ID="lnkExport" runat="server" Width="50px" >EXPORT</asp:LinkButton>
                                            <asp:Button ID="btn_Hidden" runat="server" Text="Button" style="display:none" OnClick="btn_Hidden_Click" />
       
                                           
                                        </td>
                                     </tr>
                                    
                                 </table>
                                </td>
                                </tr>
                                    
                                </table>
                               <div style='height:200%;width:1200px;text-align:center;margin:0 auto';align="center" >
                 <asp:gridview ID="dgListApproval2" runat="server" 
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                            BorderStyle="None" BorderWidth="1px" CellPadding="1" CssClass="tDatagridITReview" 
                            Height="100%" AllowSorting="True" PageSize="10" AllowPaging="true" OnRowCommand="dgListApproval2_RowCommand"
                            Width="1200px">
                         
                            <HeaderStyle CssClass="GridHeader" ForeColor="White" Font-Bold="True" HorizontalAlign="Center" />
                            <FooterStyle BackColor="White" ForeColor="#000066"/>
                            <Columns>	
                                <asp:TemplateField HeaderStyle-Width="10px" HeaderText="Approval">
                                     <ItemTemplate>
                                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="cmdEdit" CommandArgument="<%# Container.DataItemIndex %>"
                                            ImageUrl="~/images/Edit.jpg" Width="20px"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField  DataField="idx" HeaderText="idx" HeaderStyle-Width="10px" SortExpression="idx ASC" Visible="true">
                                <HeaderStyle Width="10px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="Number" HeaderText="No." HeaderStyle-Width="5px" SortExpression="NUMBER ASC" Visible="true">
                                <HeaderStyle Width="5px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="Employee_ID" HeaderText="Employee ID" HeaderStyle-Width="150px" SortExpression="EmployeeID ASC" Visible="true">
                                <HeaderStyle Width="80px"></HeaderStyle>
                                </asp:BoundField>
                               
								<asp:BoundField  DataField="Employee_Name" HeaderText="Employee Name" HeaderStyle-Width="200px" SortExpression="EmployeeName ASC" Visible="true">
                                <HeaderStyle Width="200px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="Entity" HeaderText="Entity" HeaderStyle-Width="50px" SortExpression="Entity ASC" Visible="true">
                                <HeaderStyle Width="50px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="Type_Vehicle" HeaderText="Type Vehicle" HeaderStyle-Width="100px" SortExpression="Type_Vehicle ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                

                                <%--<asp:BoundField  DataField="Amount" HeaderText="Amount" HeaderStyle-Width="100px" SortExpression="Amount ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>--%>
                                
                                <asp:BoundField  DataField="NoPol_1" HeaderText="No Pol 1" HeaderStyle-Width="100px" SortExpression="NoPol_1 ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="NoPol_2" HeaderText="No Pol 2" HeaderStyle-Width="100px" SortExpression="NoPol_2 ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="SingleOrDouble" HeaderText="Single Or Double" HeaderStyle-Width="100px" SortExpression="SingleOrDouble ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                
                               <%-- <asp:BoundField  DataField="RangePeriod" HeaderText="Range Period" HeaderStyle-Width="100px" SortExpression="RangePeriod ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>--%>
                                
                                <asp:BoundField  DataField="Total_Amount" HeaderText="Total Amount" HeaderStyle-Width="100px" SortExpression="Total_Amount ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField  DataField="Date_From" HeaderText="Date From" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="100px" SortExpression="Date_From ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField  DataField="Date_To" HeaderText="Date To" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="100px" SortExpression="Date_To ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="Total_Days" HeaderText="Total Working Days" HeaderStyle-Width="700px" SortExpression="Total_Days ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField  DataField="Year" HeaderText="Year" HeaderStyle-Width="100px" SortExpression="Year ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField  DataField="Remarks" HeaderText="Remarks" HeaderStyle-Width="700px" SortExpression="Remarks ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                 
                                <asp:BoundField  DataField="Flag" HeaderText="Status" HeaderStyle-Width="700px" SortExpression="Flag ASC" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>                             
                           </Columns>
                       </asp:gridview>
              </div>
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
                            
    </form>
</body>
</html>
