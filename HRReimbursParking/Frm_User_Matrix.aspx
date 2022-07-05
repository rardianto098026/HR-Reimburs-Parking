<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_User_Matrix.aspx.vb" Inherits="HRReimbursParking.Frm_User_Matrix" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagName="My" TagPrefix="Menu" Src="~/Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="~/Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="~/Menu/Footer.ascx" %>


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
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
         <link rel="shortcut icon" href="Images/icon.ico" />
        <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
 
    <script>
        $(function() {

            $(".MyTreeView").find(":checkbox").change(function() {
                //check or uncheck childs
                var nextele = $(this).closest("table").next()[0];
                if (nextele && nextele.tagName == "DIV") {
                    $(nextele).find(":checkbox").prop("checked", $(this).prop("checked"));

                }
                //check nodes all with the recursive method
                CheckChildNodes($(".MyTreeView").find(":checkbox").first());

            });
            //method check filial nodes
            function CheckChildNodes(Parentnode) {

                var nextele = $(Parentnode).closest("table").next()[0];

                if (nextele && nextele.tagName == "DIV") {
                    $(nextele).find(":checkbox").each(function() {
                        CheckChildNodes($(this));
                    });

                    if ($(nextele).find("input:checked").length == 0) {
                        $(Parentnode).removeAttr("checked");
                    }
                    if ($(nextele).find("input:checked").length > 0) {
                        $(Parentnode).prop("checked", "checked");
                    }

                }
                else { return; }

            }

        }) 
    </script>
    <script type="text/javascript">
        (function($) {
            $.widget("custom.combobox", {
                _create: function() {
                    this.wrapper = $("<span>")
          .addClass("custom-combobox")
          .insertAfter(this.element);

                    this.element.hide();
                    this._createAutocomplete();
                    this._createShowAllButton();
                },

                _createAutocomplete: function() {
                    var selected = this.element.children(":selected"),
          value = selected.val() ? selected.text() : "";

                    this.input = $("<input>")
          .appendTo(this.wrapper)
          .val(value)
          .attr("title", "")
          .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
          .autocomplete({
              delay: 0,
              minLength: 0,
              source: $.proxy(this, "_source")
          })
          .tooltip({
              tooltipClass: "ui-state-highlight"
          });

                    this._on(this.input, {
                        autocompleteselect: function(event, ui) {
                            ui.item.option.selected = true;
                            this._trigger("select", event, {
                                item: ui.item.option
                            });
                        },

                        autocompletechange: "_removeIfInvalid"
                    });
                },

                _createShowAllButton: function() {
                    var input = this.input,
          wasOpen = false;

                    $("<a>")
          .attr("tabIndex", -1)
          .attr("title", "Show All Items")
          .tooltip()
          .appendTo(this.wrapper)
          .button({
              icons: {
                  primary: "ui-icon-triangle-1-s"
              },
              text: false
          })
          .removeClass("ui-corner-all")
          .addClass("custom-combobox-toggle ui-corner-right")
          .mousedown(function() {
              wasOpen = input.autocomplete("widget").is(":visible");
          })
          .click(function() {
              input.focus();

              // Close if already visible
              if (wasOpen) {
                  return;
              }

              // Pass empty string as value to search for, displaying all results
              input.autocomplete("search", "");
          });
                },

                _source: function(request, response) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response(this.element.children("option").map(function() {
                        var text = $(this).text();
                        if (this.value && (!request.term || matcher.test(text)))
                            return {
                                label: text,
                                value: text,
                                option: this
                            };
                    }));
                },

                _removeIfInvalid: function(event, ui) {

                    // Selected an item, nothing to do
                    if (ui.item) {
                        return;
                    }

                    // Search for a match (case-insensitive)
                    var value = this.input.val(),
          valueLowerCase = value.toLowerCase(),
          valid = false;
                    this.element.children("option").each(function() {
                        if ($(this).text().toLowerCase() === valueLowerCase) {
                            this.selected = valid = true;
                            return false;
                        }
                    });

                    // Found a match, nothing to do
                    if (valid) {
                        return;
                    }

                    // Remove invalid value
                    this.input
          .val("")
          .attr("title", value + " didn't match any item")
          .tooltip("open");
                    this.element.val("");
                    this._delay(function() {
                        this.input.tooltip("close").attr("title", "");
                    }, 2500);
                    this.input.data("ui-autocomplete").term = "";
                },

                _destroy: function() {
                    this.wrapper.remove();
                    this.element.show();
                }
            });
        })(jQuery);

        $(function() {
            $("#txtUserName").combobox();
            $("#toggle").click(function() {
                $("#txtUserName").toggle();
            });
        });
  </script>
<style>
#removecheckbox
{
    color: Gray;
}
#removecheckbox input
{
    display: none;
}
</style>
    <link href="Surroundings.css" rel="stylesheet" type="text/css"/>

</head>
<body onunload="bodyUnload();" onclick="clicked=true;" oncontextmenu="return false">
    <form id="form1" runat="server">
    <div>
        <table width="1200px" align="center" cellpadding="0" cellspacing="0" >
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
                        <Menu:My ID="menu1" runat="Server" />
                    </td>
                    <td width="21px" background="Images/borderRight.gif">
                    </td>
            </tr>
            <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="10">
                        &nbsp;</td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; UserName <asp:Label ID="lblErr_ATP" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                         &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp
                          <asp:DropDownList ID="txtUserName" runat="server" CssClass="ui-widget"> 
                         </asp:DropDownList>
                         &nbsp; &nbsp;&nbsp;<asp:Button ID="btnRetr" runat="server" Text="Retrieve Menu" />
                          &nbsp;</td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
               <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Role <asp:Label ID="Label1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp
                          <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ui-widget"> 
                          <asp:ListItem Text="--Choose--" Value="0"></asp:ListItem>
                          <asp:ListItem Text="ADMIN" Value="1"></asp:ListItem>
                          <asp:ListItem Text="SUPER ADMIN" Value="3"></asp:ListItem>
                          <asp:ListItem Text="User" Value="2"></asp:ListItem>
                         </asp:DropDownList>
                         &nbsp; &nbsp;&nbsp;&nbsp;</td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              
             <%-- <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Menu <asp:Label ID="Label1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="DropDownList1_SelectedIndexChanged">
                           </asp:DropDownList>
                        
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>--%>
                 <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Menu <asp:Label ID="Label2" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <br />
                            <%--<asp:CheckBoxList ID="CheckBoxList1" runat="server" style="margin-left:60px">
                            </asp:CheckBoxList>--%>
                            <asp:TreeView runat="server" ID="TreeView1" style="margin-left:120px"></asp:TreeView>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
                </tr>
               
                
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                        &nbsp; &nbsp;
                        <asp:Button ID="BtnDelete" runat="server" Text="Delete" />
                         &nbsp; &nbsp; <asp:Button ID="btnBack" runat="server" Text="Back" />
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>
              
                </table>
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
