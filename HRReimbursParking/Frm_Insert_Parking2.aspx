<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Insert_Parking2.aspx.vb" Inherits="HRReimbursParking.Frm_Insert_Parking2" %>
<%@ Register TagName="My" TagPrefix="Menu" Src="Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="Menu/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Surrounding.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="css/jquery-ui.css" />
    <script type="text/javascript" src="js/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="css/style4.css" />
    <style type="text/css">
        .style2
        {
            height: 30px;
        }
        .style3
        {
            width: 695px;
            height: 30px;
        }
        inputxxx {
            display: none;
        }
    </style>
    <script type="text/javascript">

        function Confirm_Upload() {

            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden";

            confirm_value.name = "confirm_value";

            if (confirm("Do you want to upload the data?")) {

                confirm_value.value = "Yes";

            } else {

                confirm_value.value = "No";

            }

            document.forms[0].appendChild(confirm_value);
        }
   </script>

   
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table width="100%" align="center" cellpadding="0" cellspacing="0">
            <tr>
               
                <td align="center">
                 <Head:My ID="head" runat="server" />
                 </td>
               
            </tr>
            
            <tr>
                
                    <td align="left" bgcolor="#0055AA">
                        <Menu:My ID="My1" runat="Server" />
                    </td>
                   
            </tr>
            
    </table>  
    </div>
    <div>
    
        <table width="1200px" align="center" cellpadding="0" cellspacing="0">
            
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label runat="server" ID="lblID" Text="Employee ID"></asp:Label> 
                        <asp:Label ID="lblID2" runat="server" STYLE="margin-left:70px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label runat="server" ID="Label1" Text="Name"></asp:Label> 
                        <asp:Label ID="lblNamaKaryawan" runat="server" STYLE="margin-left:102px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label runat="server" ID="Label3" Text="Entity"></asp:Label> 
                        <asp:Label ID="lblEntity" runat="server" STYLE="margin-left:102px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label runat="server" ID="Label5" Text="NoPol. Existing"></asp:Label> 
                        <asp:Label ID="lblNoPolExisting" runat="server" STYLE="margin-left:59px"></asp:Label>
                        <asp:Label ID="lblNoPolExisting2" runat="server" STYLE="margin-left:10PX"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
            <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label runat="server" ID="Label24" Text="Single or Double"></asp:Label> 
                        <asp:Label ID="Label25" runat="server" STYLE="margin-left:54px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label runat="server" ID="Label6" Text="Type Vehicle Existing"></asp:Label> 
                        <asp:Label ID="lblTypeKendExisting" runat="server" STYLE="margin-left:29px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label runat="server" ID="Label15" Text="Range Period"></asp:Label> 
                        <asp:Label ID="lblRange" runat="server" STYLE="margin-left:64px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Checkbox runat="server" Enabled="false" ID="chkP3" Text="Periode 1 Month" style="margin-left:125px" />
                        <asp:Checkbox runat="server" Enabled="false" ID="chkP4" Text="Periode 2 Month" style="margin-left:5px" />
                        <asp:Checkbox runat="server" Enabled="false" ID="chkP5" Text="Periode 3 Month" style="margin-left:5px" />
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                     
                        <asp:CheckBox runat="server" ID="chkUpdate" AutoPostBack ="true" OnCheckedChanged ="chkUpdate_CheckedChanged" Text="Change Type Vehicle and PolNo Vehicle" />
                         <asp:Label style="margin-left:5px"  Visible="true" ID="lb22" runat="server" ForeColor="Red" Text="*"></asp:label><u><b><font size="2px"><asp:Label style="margin-left:5px"  Visible="true" ID="lblErr_Upload" runat="server" ForeColor="Red" Text="Please checked to change or update vehicle and No Pol vehicle"></asp:Label></font></b></u>
                      
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label runat="server" ID="Label2" Text="Type Vehicle. Update"></asp:Label> 
                        <asp:dropdownlist ID="ddl" runat="server" STYLE="margin-left:26px" height="30px"  Width="161px" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        <asp:ListItem Text="--Choose--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="CAR" Value="1"></asp:ListItem>
                        <asp:ListItem Text="MOTORCYCLE" Value="2"></asp:ListItem>
                        </asp:dropdownlist>
                        <asp:Label style="margin-left:5px"  Visible="false" ID="Label13" runat="server" ForeColor="Red" Text="* Please Choose Vehicle Type"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
             <tr visible="false" id="trSingle" runat="server">
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label runat="server" ID="Label22" Text="Single/Double"></asp:Label> 
                        <asp:dropdownlist ID="ddlSingle"  runat="server" STYLE="margin-left:62px" height="30px"  Width="161px" Enabled="TRUE" AutoPostBack="true" OnSelectedIndexChanged="ddlSingle_SelectedIndexChanged">
                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                        <asp:ListItem Text="SINGLE" Value="1"></asp:ListItem>
                        <asp:ListItem Text="DOUBLE" Value="2"></asp:ListItem>
                        </asp:dropdownlist>
                        <asp:Label style="margin-left:5px"  Visible="false" ID="Label23" runat="server" ForeColor="Red" Text="* Please Choose Single/Double"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label runat="server" ID="Label8" Text="NoPol. Update"></asp:Label> 
                        <asp:Textbox ID="txtNoPolUpdate" runat="server" STYLE="margin-left:59px" 
                            Width="161px" Enabled="false" AutoPostBack ="true" OnTextChanged ="txtNoPolUpdate_TextChanged" ></asp:Textbox>
                        <%--<asp:Label ID="NoPol41" runat="server" STYLE="margin-left:5px"></asp:Label>--%>
                        <asp:Textbox ID="NoPol4" Enabled="false" runat="server" STYLE="margin-left:5px"></asp:Textbox>
                        <asp:Label style="margin-left:5px"  Visible="false" ID="Label12" runat="server" ForeColor="Red" Text="* Please fill Vehicle Number"></asp:Label>
                        
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
              <tr visible="false" id="trHide" runat="server">
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label runat="server" ID="Label20" Text="NoPol. Update 2"></asp:Label> 
                        <asp:Textbox ID="txtNoPolUpdate2" runat="server" STYLE="margin-left:49px; margin-bottom: 0px;" 
                            Width="161px" Enabled="TRUE"  AutoPostBack ="true" OnTextChanged ="txtNoPolUpdate2_TextChanged"></asp:Textbox>
                        <%--<asp:Label ID="Textbox21" runat="server"  STYLE="margin-left:5px;"></asp:Label>--%> 
                        <asp:Textbox ID="Textbox2"  Enabled="false" runat="server"  STYLE="margin-left:5px;"></asp:Textbox>
                        <asp:Label style="margin-left:5px"  Visible="false" ID="Label21" runat="server" ForeColor="Red" Text="* Please fill Vehicle Number"></asp:Label>
                        
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Label runat="server" ID="Label4" Text="Remarks"></asp:Label> 
                        <asp:Dropdownlist ID="txtRemarks" runat="server" STYLE="margin-left:86px" Width="161px" Enabled="true">
                        <asp:ListItem Text="--Choose--"  Value="0"></asp:ListItem>
                        <asp:ListItem Text="EXTENDED"  Value="1"></asp:ListItem>
                        <asp:ListItem Text="CHANGE VEHICLE-EXTENDED" Value="2"></asp:ListItem>
                        <asp:ListItem Text="CHANGE VEHICLE NUMBER-EXTENDED" Value="3"></asp:ListItem>
                        </asp:Dropdownlist>
                        <asp:Label style="margin-left:5px"  Visible="false" ID="Label14" runat="server" ForeColor="Red" Text="* Please Choose Remarks"></asp:Label>
                   
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
                
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Button ID="btnSubmit" runat="server" OnClientClick="Confirm_Upload()" OnClick="Alert" Text="Submit" />
                       &nbsp; &nbsp;
                       <font size="4px"><asp:Label ForeColor="Red" runat="server" ID="Label7" Text="* Save Data Sukses" Visible="false"></asp:Label></font> 
                       
                        </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
             <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                       
                       <font size="2px"><asp:Label ForeColor="Red" runat="server" ID="Label9" Text="* NOTE" Visible="TRUE"></asp:Label></font> 
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <font size="2px"><asp:Label ForeColor="Red" runat="server" ID="Label10" Text="English:" Visible="TRUE"></asp:Label></font>  
                       
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <font size="2px"><asp:Label ForeColor="Red" runat="server" ID="Label18" Text="- before you change your parking data, please ensure that you have made changes on the data to Secure parking Kuningan City if not then these data change are not valid.
" Visible="TRUE"></asp:Label></font>  
                       
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
                           
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <font size="2px"><asp:Label ForeColor="Red" runat="server" ID="Label16" Text="- For more information, please contact your HR Services Entities.
" Visible="TRUE"></asp:Label></font>  
                       
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              
               <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              
              
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <font size="2px"><asp:Label ForeColor="Red" runat="server" ID="Label11" Text="Bahasa:" Visible="TRUE"></asp:Label></font>     
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <font size="2px"><asp:Label ForeColor="Red" runat="server" ID="Label19" Text="- sebelum anda merubah data parkir, silahkan dipastikan bahwa anda sudah melakukan perubahan data ke Secure parking Kuningan City jika tidak maka perubahan data ini tidak berlaku.
" Visible="TRUE"></asp:Label></font>     
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <font size="2px"><asp:Label ForeColor="Red" runat="server" ID="Label17" Text="- Untuk informasi lebih lanjut, silahkan hubungi HR Services di Entity masing - masing." Visible="TRUE"></asp:Label></font>  
                       
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              
                </table>
               
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                

                
     
                </table>
    </div>
    <br />
    <div>
     <footer:my ID="My3" runat="server" /> 
     </div>  
    </form>
</body>
</html>