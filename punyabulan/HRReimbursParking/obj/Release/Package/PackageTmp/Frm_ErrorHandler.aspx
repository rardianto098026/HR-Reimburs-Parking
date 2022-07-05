<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_ErrorHandler.aspx.vb" Inherits="HRReimbursParking.Frm_ErrorHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sorry for this unconvenience</title>
     <link rel="shortcut icon" href="Images/icon.ico" />
    <link href="Surrounding.css" rel="stylesheet" type="text/css" />
</head>

<body onbeforeUnload="bodyUnload();" onclick="clicked=true;" oncontextmenu="return false">
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <table id="Table2" runat="server" height="100px" width="500px" align="center">
                <tr>
                    <td width="100px">
                        <img src="Images/AXA-Banner.png" style="height: 100px; width: 500px" />
                    </td>
                </tr>
            </table>
             <table id="Table1" runat="server" height="500px" width="500px" align="center">
                <tr>
                    <td >
                        <img src="Images/ErrorPage.png" />
                    </td>
                    
                </tr>
                <tr>
                    <td align="center">
                         <asp:ImageButton ID="LogOut" ImageUrl="~/Images/logout.png" Width="80px" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
