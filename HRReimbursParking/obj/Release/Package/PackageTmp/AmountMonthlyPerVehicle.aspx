<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AmountMonthlyPerVehicle.aspx.vb" Inherits="HRReimbursParking.AmountMonthlyPerVehicle" %>
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
      <!--
      function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

         return true;
      }
      function Comma(Num) { //function to add commas to textboxes
          Num += '';
          Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
          Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
          x = Num.split('.');
          x1 = x[0];
          x2 = x.length > 1 ? '.' + x[1] : '';
          var rgx = /(\d+)(\d{3})/;
          while (rgx.test(x1))
              x1 = x1.replace(rgx, '$1' + ',' + '$2');
          return x1 + x2;
      }

      //-->
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
                        <asp:CheckBox ID="Add" Text="Add" Height="25px" AutoPostBack ="true" OnCheckedChanged="Add_CheckedChanged" runat="server" />
                        <asp:CheckBox ID="Edit" Text="Edit" Height="25px" AutoPostBack ="true" OnCheckedChanged="Edit_CheckedChanged" style="margin-left: 20px" runat="server" />
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                          <asp:Label ID="type" runat="server" Text="Type :" width="75px" height="30px" Visible="false"></asp:Label>
                          <asp:TextBox ID="txttype" runat="server" style="margin-left: 10px" Width="140px" Visible="false"></asp:TextBox>
                          <asp:DropDownList ID="ddl_type" runat="server" style="margin-left: 10px" Width="140px" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged">
                          </asp:DropDownList>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label ID="amount" Visible="false" runat="server" Text="Amount :" width="75px" height="30px"></asp:Label>
                        <asp:TextBox ID="txtamount" Visible="false" runat="server" style="margin-left: 10px" Width="140px" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
            <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label ID="year" Visible="false" runat="server" Text="Year :" width="75px" height="30px"></asp:Label>
                        <asp:dropdownlist ID="ddlyear" runat="server" CssClass="textbox" Visible="false" style="margin-left: 10px" Width="140px">
                                                <asp:ListItem Text="--Choose--" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                        </asp:dropdownlist>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
            <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                       <asp:Label ID="quarter" Visible="false" runat="server" Text="Quarter :" width="75px" height="30px"></asp:Label>
                       <asp:dropdownlist ID="ddlquarter" runat="server" CssClass="textbox" Visible="false" style="margin-left: 10px" Width="140px" AutoPostBack="true" OnSelectedIndexChanged="ddlquarter_SelectedIndexChanged">
                        </asp:dropdownlist> 

                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
            <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                       <asp:Label ID="rangeperiod" Visible="false" runat="server" Text="Range Period :" width="75px" height="30px"></asp:Label>
                       <asp:TextBox ID="txtrangeperiod" Visible="false" Enabled ="false" runat="server" style="margin-left: 10px" Width="140px" ></asp:TextBox>
                         </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
            

            <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Visible="false" />
                       
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
        </table>
    </div>
    <br />
    <div>
     <footer:my ID="My3" runat="server" /> 
     </div>  
    </form>
</body>
</html>
