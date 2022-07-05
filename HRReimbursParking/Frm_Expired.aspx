<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Expired.aspx.vb" Inherits="HRReimbursParking.Frm_Expired" %>
<%@ Register TagName="My" TagPrefix="Menu" Src="Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="Menu/Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title> 
    <link href="css/Surrounding.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="css/jquery-ui.css" />
    <script type="text/javascript" src="js/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="css/style4.css" />
        <script type="text/javascript">
        $('html').bind('keypress', function (e) {
            if (e.keyCode == 13) {
                return false;
            }
        });
    </script>
    <script type="text/javascript">
        $(function() {
            $("#txtDate").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "yy-mm-dd"
            });
        });
    </script>
    <script type="text/javascript">

        function Confirm_Upload() {

            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden";

            confirm_value.name = "confirm_value";

            if (confirm("Are you sure?")) {

                confirm_value.value = "Yes";

            } else {

                confirm_value.value = "No";

            }

            document.forms[0].appendChild(confirm_value);
        }
   </script>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            width: 695px;
            height: 30px;
        }
    </style>
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
                    <td background="Images/borderleft.gif" width="21" class="auto-style1">
                        </td>
                    <td class="auto-style2" align ="left">
                        <asp:Label ID="lblQuarter" runat="server" Text="Quarter"></asp:Label>
                        <asp:Dropdownlist ID="ddlQuater" AutoPostBack="true" OnSelectedIndexChanged="ddlQuater_SelectedIndexChanged" runat="server" style="margin-left:49px">

                        </asp:Dropdownlist>
                        </td>
                    <td background="Images/borderRight.gif" width="21" class="auto-style1">
                        </td>
              </tr>
                <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>
                        <asp:textbox ID="txtDate" runat="server" style="margin-left:62px"></asp:textbox>
        
                        <asp:label ID="lblErr" runat="server" style="margin-left:7px" Visible="false" Text="."></asp:label>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
            <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label ID="Label3" runat="server" Text="Range Period"></asp:Label>
                        <asp:Label ID="lblPeriod" runat="server" style="margin-left:23px"></asp:Label>
        
                        <asp:label ID="Label4" runat="server" style="margin-left:7px" Visible="false" Text="."></asp:label>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
            <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label ID="Label2" runat="server" Text="Year"></asp:Label>
                        <asp:Dropdownlist ID="ddlYear" runat="server" style="margin-left:62px">
                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                        <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                        <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                       <%-- <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                        <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                        <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                        <asp:ListItem Text="2023" Value="2023"></asp:ListItem>--%>
                        </asp:Dropdownlist>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr> 
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="Confirm_Upload()" OnClick="Alert" />
                      
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                       <asp:DataGrid ID="dgRekeningKoran" runat="server" 
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
                                <asp:TemplateColumn HeaderStyle-Width="10px" HeaderText="EDIT">
                                     <ItemTemplate>
                                        
                                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="cmdSelect"
                                            ImageUrl="~/images/Edit.jpg" Width="20px" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                	
                                <asp:BoundColumn  DataField="idx" HeaderText="idx" HeaderStyle-Width="10px" SortExpression="idx ASC" Visible="False">
                                <HeaderStyle Width="10px"></HeaderStyle>
                                </asp:BoundColumn>
                               
                                <asp:BoundColumn  DataField="Quarter" HeaderText="Quarter" HeaderStyle-Width="150px" SortExpression="Quarter ASC" Visible="true">
                                <HeaderStyle Width="50px"></HeaderStyle>
                                </asp:BoundColumn>

                                <asp:BoundColumn  DataField="RangePeriod" HeaderText="Range Period" HeaderStyle-Width="50px" SortExpression="RangePeriod ASC" Visible="true">
                                <HeaderStyle Width="50px"></HeaderStyle>
                                </asp:BoundColumn>
                               
								<asp:BoundColumn  DataField="Date" HeaderText="Date" HeaderStyle-Width="200px" SortExpression="Date ASC" Visible="true">
                                <HeaderStyle Width="200px"></HeaderStyle>
                                </asp:BoundColumn>
                                
                                <asp:BoundColumn  DataField="Year" HeaderText="Year" HeaderStyle-Width="50px" SortExpression="Year ASC" Visible="true">
                                <HeaderStyle Width="50px"></HeaderStyle>
                                </asp:BoundColumn>
                                
                           </Columns>
                           <PagerStyle CssClass="GridPaging" HorizontalAlign="Left" Visible="False" />
                       </asp:DataGrid>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr> 
                </table>
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
     
                </table>

        <div>
            <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
                </table>
        </div>
        <br />

                 <table id="Table4" runat="server" height="2px"  width="792px" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-color:#0055AA" align="center">
                            <asp:label ID="lbl2" runat="server" Text="© PT. AXA SERVICES INDONESIA – 2015, All right reserved" ForeColor="White"></asp:label>

                            </td>
                        </tr>
                    </table>
        
    </div>
        
    </form>

</body>
</html>
