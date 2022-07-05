<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Header.ascx.vb" Inherits="HRReimbursParking.Header" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

 <link href="../Css/Surrounding.css" rel="stylesheet" type="../text/css"/>
<link rel="stylesheet" href="../css/jquery-ui.css" />
<link rel="stylesheet" href="../css/style4.css" />
<script type="text/javascript" src="../js/jquery-1.10.2.js"></script>
<script type="text/javascript" src="../js/jquery-ui.js"></script>
<link rel="stylesheet" href="../css/style4.css" />
  <link rel="shortcut icon" href="../Images/icon.ico" />
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
  <style type="text/css">
      .style1
      {
          width: 695px;
      }
  </style>
  <table style="margin-top:-12px" width="1200px" align="center" cellpadding="0" cellspacing="0">
                        <tr><td></td></tr>
                        <tr><td></td></tr>
                        <tr>
                           <td width="30px">
                           <img src="" align="left" 
                                   style="margin-top:10px; height: 47px; width: 186px;" id="imgAXA" runat="server" />
                              <%-- <img src="../Images/AXA-Banner.png" width="150px" height="40px" />--%>
                           
                           </td>
                           <td class="style1">
                            <%--<asp:ImageButton style="margin-left:600px"  ID="LogOut" ImageUrl="~/Images/logout.jpg" Width="30px" Height runat="server" />--%>
                           </td>
                           <td>
                            <asp:ImageButton style="margin-left:190px; margin-top:10px"  ID="LogOut" 
                                   ImageUrl="../Images/logout2.jpg" Width="87px" Height="35px" 
                                   runat="server" />   
                           </td>
                        </tr>
                       
                        
             </table>
                    <table width="1200px" align="left" height="2px" cellpadding="5" cellspacing="5">
                        <tr>
                            <td align="left" >
                            <asp:label style="margin-left:-5px" ID="lblWe" runat="server" Text="Welcome," ForeColor="#0055AA" Font-Bold="true"></asp:label>
                            <asp:Label runat="server" ID="lblGreet" ForeColor="#0055AA" Font-Bold="true"></asp:Label>
                            <asp:Label runat="server" ID="LBLEmplNumber" ForeColor="#0055AA" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />

