<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Reimbursment_Request.aspx.vb" Inherits="HRReimbursParking.Frm_Reimbursment_Request" %>
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
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
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

        function Confirm_Add() {

            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden";

            confirm_value.name = "confirm_value";

            if (confirm("Are you sure want to Add New Request?")) {

                confirm_value.value = "Yes";

            } else {

                confirm_value.value = "No";

            }

            document.forms[0].appendChild(confirm_value);
        }
   </script>
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

    <script type="text/javascript">
        $(function() {
            $("#txtdatefrom").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "yy-mm-dd",
                yearRange: "-100:+100"
            });
        });
    </script> 
    <script type="text/javascript">
        $(function() {
            $("#txtdateto").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "yy-mm-dd",
                yearRange: "-100:+100"
            });
        });
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
           
            <br />
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                          <asp:Label runat="server" ID="EmpID" Text="Employee ID :" width="100px" height="30px"></asp:Label> 
                          <asp:Label ID="lblEmplID" runat="server" STYLE="margin-left:30px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                       <asp:Label runat="server" ID="Name" Text="Name :" width="100px" height="30px"></asp:Label> 
                       <asp:Label ID="lblName" runat="server" STYLE="margin-left:30px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>

            <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label runat="server" ID="Entity" Text="Entity :" width="100px" height="30px"></asp:Label> 
                        <asp:Label ID="lblEntity" runat="server" STYLE="margin-left:30px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
             <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                          <asp:Label runat="server" width="100px"  height="30px" ID="lbltipe" Text="Type Vehicle :"></asp:Label> 
                          <asp:DropDownList ID="ddl_tipekendaraan" OnSelectedIndexChanged="ddl_tipekendaraan_SelectedIndexChanged" AutoPostBack="true"  runat="server" style="margin-left: 30px" Width="145px">
                          </asp:DropDownList>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
             <%--<tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label ID="amount" runat="server" Text="Amount :" width="100px" height="30px"></asp:Label>
                        <asp:TextBox ID="txtamount2"  runat="server" style="margin-left: 30px" Width="141px" Enabled = "false" ></asp:TextBox>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>--%>
             <tr id="trSingle" runat="server" visible="false">
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        &nbsp;</td>
                     <td class="style3" align ="left">
                        <asp:Label runat="server" ID="lblsingledouble" Text="Single or Double :" width="100px" height="30px"></asp:Label> 
                        <asp:dropdownlist ID="ddlsingledouble" OnSelectedIndexChanged="ddlsingledouble_SelectedIndexChanged" AutoPostBack="true" runat="server" style="margin-left: 30px" Width="145px">
                        <asp:ListItem Text="" Value="0"></asp:ListItem>
                        <asp:ListItem Text="SINGLE" Value="1"></asp:ListItem>
                        <asp:ListItem Text="DOUBLE" Value="2"></asp:ListItem>
                        </asp:dropdownlist>
                        <asp:Label style="margin-left:5px" ID="Label23" runat="server" ForeColor="Red" Text="* Please Choose Single/Double"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        &nbsp;</td>
              </tr>
              <tr id="trNoPol1" runat="server" visible="false">
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label ID="nopol1" runat="server" Text="NoPol 1:" width="100px" height="30px"></asp:Label>
                        <asp:TextBox ID="txtnopol1" runat="server" style="margin-left: 30px" Width="145px" AutoPostBack ="true" OnTextChanged ="txtnopol1_TextChanged"></asp:TextBox>
                        <asp:Textbox ID="NoPol4" Enabled="false" runat="server" STYLE="margin-left:5px"></asp:Textbox>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
            <tr id="trNoPol2" runat="server" visible="false">
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label ID="nopol2" runat="server" Text="NoPol 2:" width="100px" height="30px"></asp:Label>
                        <asp:TextBox ID="txtnopol2" runat="server" style="margin-left: 30px" Width="145px"  AutoPostBack ="true" OnTextChanged ="txtnopol2_TextChanged"></asp:TextBox>
                        
                        <asp:Textbox ID="Textbox2"  Enabled="false" runat="server"  STYLE="margin-left:5px;"></asp:Textbox>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
             <%-- <tr >
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                          <asp:Label runat="server" ID="rangeperiod" Text="Range period :" width="100px" height="30px"></asp:Label> 
                          <asp:DropDownList ID="ddlrangeperiod" runat="server" style="margin-left: 30px" Width="145px">
                          </asp:DropDownList>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>--%>
             <%-- <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        <asp:Checkbox runat="server" ID="period1" AutoPostBack ="true" OnCheckedChanged="period1_CheckedChanged" Text="Periode 1 Month" style="margin-left:125px" />
                        <asp:Checkbox runat="server" ID="period2" AutoPostBack ="true" OnCheckedChanged="period2_CheckedChanged" Text="Periode 2 Month" style="margin-left:5px" />
                        <asp:Checkbox runat="server" ID="period3" AutoPostBack ="true" OnCheckedChanged="period3_CheckedChanged" Text="Periode 3 Month" style="margin-left:5px" />
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>--%>
            <tr visible ="false">
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label ID="totalamount" runat="server" Text="Total Amount :" width="100px" height="30px"></asp:Label>
                        <asp:TextBox ID="txttotalamount"  runat="server" style="margin-left: 30px" Width="141px" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label ID="datefrom" runat="server" Text="Date From :" width="100px" height="30px"></asp:Label>
                        <asp:TextBox ID="txtdatefrom"  runat="server" style="margin-left: 30px" Width="141px" AutoPostBack ="true" OnTextChanged ="txtdatefrom_TextChanged" ></asp:TextBox>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label ID="dateto" runat="server" Text="Date To :" width="100px" height="30px"></asp:Label>
                        <asp:TextBox ID="txtdateto"  runat="server" style="margin-left: 30px" Width="141px" AutoPostBack ="true" OnTextChanged ="txtdateto_TextChanged" ></asp:TextBox>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
             <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label ID="totaldays" runat="server" Text="Total Working Days:" width="100px" height="30px"></asp:Label>
                        <asp:TextBox ID="txttotalday" enabled="false"   runat="server" style="margin-left: 30px" Width="141px" ></asp:TextBox>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>

             <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        &nbsp;</td>
                     <td class="style3" align ="left">
                        <asp:Label runat="server" ID="Year" Text="Year :" width="100px" height="30px"></asp:Label> 
                        <asp:dropdownlist ID="ddlyear" runat="server" style="margin-left: 30px" Width="145px">
                        <asp:ListItem Text="--Choose--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="2019" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2020" Value="2"></asp:ListItem>
                        <asp:ListItem Text="2021" Value="3"></asp:ListItem>
                        <asp:ListItem Text="2022" Value="4"></asp:ListItem>
                        <asp:ListItem Text="2023" Value="5"></asp:ListItem>
                        </asp:dropdownlist>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        &nbsp;</td>
              </tr>
             <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                        Attach Invoice Document : <asp:FileUpload ID="txtUpload" runat="server" CssClass="textbox" Width="300px" /> 
                         <asp:Button Visible="false" ID="Upload" runat="server" Text="Upload" style="margin-left: 10px" height="20px"/> 
                        &nbsp; 
                        <font size="2px"> <asp:Label ID="lblmandatory" runat="server" ForeColor="Red" Text="* Only PDF File" ></asp:Label></font>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
     
           
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Label ID="remarks" runat="server" Text="Remarks:" width="100px" height="30px"></asp:Label>
                        <asp:TextBox ID="txtremarks"  runat="server" style="margin-left: 30px" Width="141px" ></asp:TextBox>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
            
              <tr>
                    <td background="Images/borderleft.gif" width="21" class="style2">
                        </td>
                    <td class="style3" align ="left">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit"  OnClientClick="Confirm_Add()" OnClick="Alert_Add"/>
                    </td>
                    <td background="Images/borderRight.gif" width="21" class="style2">
                        </td>
              </tr>
             <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                       <font size="3px"><asp:Label ForeColor="Red" runat="server" ID="Label2" Text=" Disclaimer :" Visible="TRUE"></asp:Label></font>
                       <font size="3px"><asp:Label ForeColor="Red" runat="server" ID="Label3" Text="Please submit the original invoice to HR Services" Visible="TRUE"></asp:Label></font>  
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
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
