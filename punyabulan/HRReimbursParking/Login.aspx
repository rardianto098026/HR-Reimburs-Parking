<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="HRReimbursParking.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta charset="UTF-8">
    <title>HR Application</title>
    <link rel="shortcut icon" href="Images/icon.ico" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel='stylesheet prefetch' href='css/jquery-ui.css'/>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/dist/css/bootstrap.min.css" />
     <link rel="stylesheet" href="css/font-awesome.min.css" />
</head>
<body>
  <form id="Form1" runat="server">
   <link href='http://fonts.googleapis.com/css?family=Ubuntu:500' rel='stylesheet' type='text/css'>
    
    <div class="body" id="bodyLogin"></div>
		<div class="grad"></div>
		<div class="header">
			<div>AXA <span class="span2">Indonesia</span></div>
            <div>Parking <span class="span1">Extended</span> <span>System</span></div>
		</div>
		<br>
		<div class="login">
          <form class="login-form">
              
              <div class="group-input">&nbsp;<i class="fa fa-user-o fa-fw white"></i><asp:TextBox runat="server" ID="txtUser" placeholder="Username" ></asp:TextBox></div>
              <div class="group-input">&nbsp;<i class="fa fa-key fa-fw white"></i><asp:TextBox runat="server" ID="txtPass" TextMode="Password" placeholder="Password"></asp:TextBox></div>
              <asp:Button runat="server" ID="btnSubmit" Text="Login" /><br />
              <asp:Label runat="server" ForeColor="Red" ID="lblLogin" style="margin-left:2px" Visible="false"></asp:Label>
          </form>
		</div>

<script src='js/jquery.min.js'></script>
<script src='js/jquery-ui.min.js'></script>
<script src="js/index.js"></script>

    
  </form>  
</body>
</html>
