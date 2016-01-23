<%@ Page Title="" Language="VB" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="false" CodeFile="frmAdmin.aspx.vb" Inherits="frmAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
         //Show dialog
         function showModal(page, width, height, scroll) {
             showModalDialog(page, "", "dialogWidth:" + width + "px; dialogHeight:" + height + "px;help:no;status:no;center:yes;scroll:" + scroll);
         }
    
        //function of Checkbox
    function ChkBox()
         {
              var Female = document.getElementById("<%=chkFemale.ClientID%>");
              var Male = document.getElementById("<%= chkMale.ClientID%>");

                if (Female.checked == true) {
                Male.checked = false
                }
         }
       
         function ChkBoxs() {
             var Female = document.getElementById("<%=chkFemale.ClientID%>");
             var Male = document.getElementById("<%= chkMale.ClientID%>");

             if (Male.checked == true) {
                 Female.checked = false
             }
         }
             
         function Chk() {
             var Female = document.getElementById("<%=chkFemale.ClientID%>");
             var Male = document.getElementById("<%= chkMale.ClientID%>");

               if (Female.checked == true) {
                   Male.checked = false
               }
           }

         //Refresh Tab
        function TabUser() {

            document.getElementById('css3-tabstrip-0-0').checked = true
        };
        function TabRole() {

            document.getElementById('css3-tabstrip-0-1').checked = true
        };
        function TabGroup() {

            document.getElementById('css3-tabstrip-0-2').checked = true
        };
        function TabRegister() {

            document.getElementById('css3-tabstrip-0-3').checked = true
        };

         //Confirm Delete 

        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you like to Delete item?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

         //Validate textbox only number

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

         //Validate Password
        function isPasswordKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode != 92))
                if (charCode > 31 && (charCode != 47))
                    if (charCode > 31 && (charCode != 58))
                        if (charCode > 31 && (charCode != 42))
                            if (charCode > 31 && (charCode != 63))
                                if (charCode > 31 && (charCode != 34))
                                    if (charCode > 31 && (charCode != 60))
                                        if (charCode > 31 && (charCode != 62))
                                            if (charCode > 31 && (charCode != 124))

                                                return true;
            return false;
        }

         //Validate textbox number'0-9' & decimal point '.'

        function isNumberPKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode != 46))
                return false;

            return true;
        }

        //Validate textbox email

        function isNumberEKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode != 46)&& (charCode < 64 || charCode > 90)&& (charCode < 97 || charCode > 122)&& (charCode != 95))
                return false;

            return true;
        }

        //Validate textbox name
        function isNameKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode != 46))
                if (charCode > 31 && (charCode < 65 || charCode > 90))
                    if (charCode > 31 && (charCode < 97 || charCode > 122))
                        if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))
                            return false;
            return true;

        }

        //Validate textbox Lastname & Nickname
        function isLNameKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
                if (charCode > 31 && (charCode < 65 || charCode > 90))
                    if (charCode > 31 && (charCode < 97 || charCode > 122))
                        if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))
                            return false;
            return true;

        }

        //Validate textbox Username & code & Description

        function isUsernameKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                if (charCode > 31 && (charCode < 65 || charCode > 90))
                    if (charCode > 31 && (charCode < 97 || charCode > 122))
                        if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))

                return false;

            return true;
        }

         //Validate textbox Data etc.
        function isDataKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                if (charCode > 31 && (charCode < 65 || charCode > 90))
                    if (charCode > 31 && (charCode < 97 || charCode > 122))
                        if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))
                            if (charCode > 31 && (charCode != 32))

                                return false;

            return true;
        }

         //Validate textbox ServerName
        function isServerNameKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                if (charCode > 31 && (charCode < 65 || charCode > 90))
                    if (charCode > 31 && (charCode < 97 || charCode > 122))
                        if (charCode > 31 && (charCode < 3585 || charCode > 3642) && (charCode < 3648 || charCode > 3660))
                            if (charCode > 31 && (charCode != 45))
                                if (charCode > 31 && (charCode != 32))
                                return false;

            return true;
        }

         //Validate textbox Mac Address & OS
        function isMacAddressKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                if (charCode > 31 && (charCode < 65 || charCode > 90))
                    if (charCode > 31 && (charCode < 97 || charCode > 122))
                        return false;
            return true;

        }

       
    </script>
    
    <style type="text/css">
  
        /*
 * @CSS3 Tabstrip
 * @author Martin Ivanov
 * @website http://wemakesites.net
 * @blog http://acidmartin.wordpress.com/
 * @twitter https://twitter.com/wemakesitesnet
 **/
        /*Credit css3-tabstip*/

        .css3-tabstrip ul,
        .css3-tabstrip li {
            margin: 0;
            padding: 0;
            list-style: none;
        }

        .css3-tabstrip,
        .css3-tabstrip input[type="radio"]:checked + label {
            position: relative;
        }

            .css3-tabstrip li,
            .css3-tabstrip input[type="radio"] + label {
                display: inline-block;
            }

                .css3-tabstrip li > div,
                .css3-tabstrip input[type="radio"] {
                    position: absolute;
                }

                    .css3-tabstrip li > div,
                    .css3-tabstrip input[type="radio"] + label {
                        border: solid 1px #ccc;
                    }

        .css3-tabstrip {
            font: bold 12px arial,quark;
            color: #ffffff;
            top: 0px;
            left: 0px;
            height: 940px;
        }

            .css3-tabstrip li {
                vertical-align: top;
            }

                .css3-tabstrip li:first-child {
                    margin-left: 8px;
                }

                .css3-tabstrip li > div {
                    top: 33px;
                    bottom: 0;
                    left: 0;
                    width: 100%;
                    padding: 8px;
                    overflow: auto;
                    background: #e5fff9;
                    -moz-box-sizing: border-box;
                    -webkit-box-sizing: border-box;
                    box-sizing: border-box;
                }

            .css3-tabstrip input[type="radio"] + label {
                margin: 0 2px 0 0;
                padding: 0 18px;
                line-height: 32px;
                background: #808080;
                text-align: center;
                border-radius: 5px 5px 0 0;
                cursor: pointer;
                -moz-user-select: none;
                -webkit-user-select: none;
                user-select: none;
            }

            .css3-tabstrip input[type="radio"]:checked + label {
                z-index: 1;
                background: #008080;
                border-bottom-color: #AFEEEE;
                cursor: default;
            }

            .css3-tabstrip input[type="radio"] {
                opacity: 0;
            }

                .css3-tabstrip input[type="radio"] ~ div {
                    display: none;
                }

                .css3-tabstrip input[type="radio"]:checked:not(:disabled) ~ div {
                    display: block;
                }

                .css3-tabstrip input[type="radio"]:disabled + label {
                    opacity: .5;
                    cursor: no-drop;
                }
        /*style css of button*/
        .myButton {
            -moz-box-shadow: inset 0px 1px 3px 0px #199993;
            -webkit-box-shadow: inset 0px 1px 3px 0px #199993;
            box-shadow: inset 0px 1px 3px 0px #199993;
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #11d6af), color-stop(1, #40998d));
            background: -moz-linear-gradient(top, #11d6af 5%, #40998d 100%);
            background: -webkit-linear-gradient(top, #11d6af 5%, #40998d 100%);
            background: -o-linear-gradient(top, #11d6af 5%, #40998d 100%);
            background: -ms-linear-gradient(top, #11d6af 5%, #40998d 100%);
            background: linear-gradient(to bottom, #11d6af 5%, #40998d 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#11d6af', endColorstr='#40998d',GradientType=0);
            background-color: #11d6af;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            border: 1px solid #139e7b;
            display: inline-block;
            cursor: pointer;
            color: #ffffff;
            font-family: Quark;
            font-size: 15px;
            font-weight: bold;
            padding: 5px 28px;
            text-decoration: none;
            text-shadow: 0px -1px 0px #0da16b;
        }

            .myButton:hover {
                background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #40998d), color-stop(1, #11d6af));
                background: -moz-linear-gradient(top, #40998d 5%, #11d6af 100%);
                background: -webkit-linear-gradient(top, #40998d 5%, #11d6af 100%);
                background: -o-linear-gradient(top, #40998d 5%, #11d6af 100%);
                background: -ms-linear-gradient(top, #40998d 5%, #11d6af 100%);
                background: linear-gradient(to bottom, #40998d 5%, #11d6af 100%);
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#40998d', endColorstr='#11d6af',GradientType=0);
                background-color: #40998d;
            }

            .myButton:active {
                position: relative;
                top: 1px;
            }


        .auto-style2 {
            width: 133px;
        }

        /*CSS of Textbox*/
        .textbox {
            height: 25px;
            width: 175px;
            border: 1px solid #20B2AA;
            color: #20B2AA;
            -moz-box-shadow: 0 2px 4px #66CDAA inset;
            -webkit-box-shadow: 0 2px 4px #66CDAA inset;
            box-shadow: 0 2px 4px #66CDAA inset;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
        }

            .textbox:focus {
                background-color: #E0FFFF;
                outline: 0;
            }

        </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table width="100%">
         <tr>
            <td style="font-family: quark; font-size: 20pt; font-weight: bold; color: #000000; border-radius:15px; ">&nbsp;&nbsp; Admin</td>
        </tr>
        <tr><td style="background-color: #666666"></td></tr>
        <tr>
            <td></td>
        </tr>
    </table>
    <div class="css3-tabstrip" >
    <ul>
        <li>
            <input type="radio" name="css3-tabstrip-0" checked="checked" id="css3-tabstrip-0-0" /><label for="css3-tabstrip-0-0">Create User</label> <%--tabstrip1 'User'--%>
            <div>
                <table width="100%"> 
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;" width="62%">
                            <table><tr><td>&nbsp; <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icon_User.png" Height="37" Width="37" /></td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;User Information</td></tr></table> 
                            <table width="100%" style="background-color: #AFEEEE">
                                <tr><td>&nbsp;</td></tr>
                                 <tr>
                                    
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">First Name : 
                                        <asp:Label ID="lbl1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td class="auto-style2">&nbsp;<asp:TextBox ID="txtFirstname" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="255" Onkeypress="return isNameKey(event)" ></asp:TextBox></td>
                                      <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">Last Name : 
                                          <asp:Label ID="lbl2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td>&nbsp;<asp:TextBox ID="txtLastname" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="255" Onkeypress="return isLNameKey(event)"  oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox></td>
                                </tr>
                              
                                 <tr>
                                    
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">Nickname :&nbsp; &nbsp;&nbsp; </td>
                                    <td class="auto-style2">&nbsp;<asp:TextBox ID="txtNickname" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="255" Onkeypress="return isLNameKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox></td>
                                      <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">Gender : 
                                          <asp:Label ID="lbl3" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                      &nbsp;</td>
                                    <td style="color: #006666;">
                                         <asp:CheckBox ID="chkMale" runat="server" type="checkbox" onclick="ChkBoxs()" Text="Male" Checked="True" Font-Bold="True" Font-Names="Quark" Font-Size="12pt" />
                                         <asp:CheckBox ID="chkFemale" runat="server" type="checkbox" onclick="ChkBox()" Text="Female" Font-Bold="True" Font-Names="Quark" Font-Size="12pt" />
                                    
                                    </td>
                                </tr>
                                
                                <tr>
                                    
                                    <td style="color: #006666; text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">ID Card : <asp:Label ID="lbl4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td class="auto-style2">
                                        &nbsp;<asp:TextBox ID="txtIDcard" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="13" onkeypress="return isNumberKey(event)" CssClass="textbox" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                                    </td>
                                      <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">Mobile No. :&nbsp;<asp:Label ID="lbl5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                          &nbsp; </td>
                                    <td>&nbsp;<asp:TextBox ID="txtMobile" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" MaxLength="10" onkeypress="return isNumberKey(event)" CssClass="textbox" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox></td>
                                </tr>
                                 <tr><td style="text-align: right; font-family: quark; font-size: 12pt; font-weight: bold; color: #006666">&nbsp;</td></tr>
                                <tr checked="False">
                                    
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">Role : <asp:Label ID="lbl9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;&nbsp;</td>
                                    <td class="auto-style2">&nbsp;<asp:DropDownList ID="drpRole" runat="server" CssClass="textbox"></asp:DropDownList></td>
                                </tr>
                               
                                <tr checked="False">
                                    
                                    <td style="color: #006666;text-align: right;"></td>
                                    <td class="auto-style2">&nbsp;<asp:CheckBox ID="chkActiveStatus" runat="server" Text="Active Status" Font-Names="Quark" ForeColor="#006666" Font-Size="12pt" Checked="True" Font-Bold="True" /></td>
                                </tr>
                                  <tr>
                                      <td style="color: #006666;text-align: right;">
                                          <asp:Label ID="lblUserRoleID" runat="server" Text="0" Visible="False"></asp:Label>
                                          <asp:Label ID="lblRoleID" runat="server" Text="0" Visible="False"></asp:Label>
                                          <asp:Label ID="lblRoleResID" runat="server" Text="0" Visible="False"></asp:Label>
                                      </td>
                                    <td>&nbsp;<asp:TextBox ID="txtIDUser" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Visible="False" >0</asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td width="2%"></td>
                        <td style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;" width="40%">
                             <table><tr><td>
                                 <br />
                                 <br />
                                 </td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;Login Information</td></tr></table> 
                             <table width="100%" style="background-color: #AFEEEE; height: 235px;">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">User Name : 
                                        <asp:Label ID="lbl6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td><asp:TextBox ID="txtUsername" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="100" Onkeypress="return isUsernameKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox></td>
                                </tr>
                                
                                <tr>
                                    
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">Password : 
                                        <asp:Label ID="lbl7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td><asp:TextBox ID="txtPassword" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" TextMode="Password" CssClass="textbox" MaxLength="30" oncopy="return false" oncut="return false" onpaste="return false" OnKeypress="return isPasswordKey(event)"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">Confirm Password : 
                                        <asp:Label ID="lbl8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;&nbsp;</td>
                                    <td><asp:TextBox ID="txtConpass" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" TextMode="Password" CssClass="textbox" MaxLength="30" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox></td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            </table>
                        </td>
                        <td width="2%"></td>
                    </tr>
                    <tr><td colspan="5">&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td colspan="4" style="text-align: center">
                            <asp:Button ID="btnSave" runat="server" CssClass="myButton" Text="Save" BackColor="#009999" Font-Bold="True" Font-Names="quark" Font-Size="12" ForeColor="White" />&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="myButton" Text="Cancel" BackColor="#009999" Font-Bold="True" Font-Names="quark" Font-Size="12" ForeColor="White" />
                        </td>
                    </tr>
                    <tr><td colspan="5">&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td colspan="4" style="text-align: center">
                            <asp:GridView ID="gvUser" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" Font-Names="Quark" Font-Size="12pt" Font-Bold="True"  OnRowCommand="gvUser_RowCommand" OnPageIndexChanging="gvUser_PageIndexChanging" PageSize="5" AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelID" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="No" HeaderText="No." >
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" >
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="gender" HeaderText="Gender" ReadOnly="True" >
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mobile_no" HeaderText="Mobile" ReadOnly="True" >
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                     <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkActiveUser" runat="server" Checked='<%# IIf(Eval("Active_Status").ToString() = "Y", True, False)%>'  Enabled="False" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                     
                                    <asp:ButtonField ButtonType="Image" CommandName="EditRow" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" />
                                     
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick="Confirm()" CommandName="DeleteRow" CommandArgument='<%# Bind("id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#333333" />
                                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                  <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="" PageButtonCount="5" Position="Bottom" PreviousPageText="" />
                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </li><li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-1" /><label for="css3-tabstrip-0-1">Create Role</label><%--tabstrip3 'Create Role'--%>
             <div>
                <table width="100%">
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width="45%" style="font-family: Quark; color: #FFFFFF; background-color: #009999; font-size: medium; font-weight: bold;border-top-left-radius:10px;border-top-right-radius:10px; text-align: center;">
                             <table><tr><td>&nbsp; <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/icon_Role.png" Height="37" Width="37" /></td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;Role Information</td></tr></table> 
                            
                            <table   style="background-color: #AFEEEE; width:100%">
                                 <tr>
                                    <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;" >
                                        Role Code :
                                        <asp:Label ID="lbll9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    </td>
                                    <td >
                                         <asp:TextBox ID="txtRoleCode" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" Onkeypress="return isDataKey(event)" MaxLength="50" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;" >
                                         Description :
                                        <asp:Label ID="lbl10" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    </td>
                                    <td >
                                         <asp:TextBox ID="txtRoleDesc" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox"  Onkeypress="return isDataKey(event)" MaxLength="255" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: #006666; text-align: right; font-family: Quark; font-size: 12pt;" >
                                        <asp:TextBox ID="txtIDRole" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Visible="False" Text="0">0</asp:TextBox>
                                    </td>
                                    <td >
                                         <asp:CheckBox ID="chkActiveStatusRole" runat="server" Text="Active Status" Font-Names="Quark" ForeColor="#006666" Font-Size="12pt" Checked="True" Font-Bold="True"/>
                                    </td>
                                </tr>
                                 <tr>
                                     
                                    <td>&nbsp;<asp:Label ID="lblidRes" runat="server" Text="Label" Visible="False"></asp:Label>
                                        <asp:Label ID="lbltbidrole" runat="server" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                     <td></td>
                                
                                </tr>
                                <tr>
                                    <td style="height:100px"></td>
                                    <td></td>
                                </tr>
                            </table>
                            
                            
                           
                        </td>
                        <td width="4%"></td>
                        <td style="vertical-align:top; font-family: Quark; color: #FFFFFF; background-color: #009999; font-size: medium; font-weight: bold;border-top-left-radius:10px;border-top-right-radius:10px; text-align: center;">
                             <table><tr><td>&nbsp; <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/icon_Respon.png" Height="37" Width="37" /></td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;Responsibility Information</td></tr></table> 
                            <table width="100%" style="background-color: #AFEEEE;  height:218px">
                                <tr>
                                    <td class="auto-style6" style=" vertical-align:top; text-align: center">

                                        <asp:GridView ID="gvResponsibility" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="464px">
                                            <Columns>
                                                <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkRespons" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="No" HeaderText="No.">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="responsibility_desc" HeaderText="Responsibility"></asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" ForeColor="#003399" />
                                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                            <SortedDescendingHeaderStyle BackColor="#002876" />
                                        </asp:GridView>

                                    </td>
                                    
                                </tr>
                                </table>
                           
                        </td>
                        <td width="2%"></td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                           
                             <asp:Button ID="btnSaveRole" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancelRole" CssClass="myButton" runat="server" Text="Cancel" />
                       
                            </td>
                   </tr>
                    <tr><td colspan="5">&nbsp;</td></tr>
                    <tr>
                        <td>&nbsp;</td>
                        
                        <td colspan="3" style="text-align: center">
                            <table width="100%">
                                <tr>
                                    <td width="20%"></td>
                                    <td style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;" class="auto-style5" width="60%" >
                             &nbsp; Role List
                            <table width="100%" style="background-color: #AFEEEE">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvRoleList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Font-Bold="True" Font-Names="Quark" Font-Size="12pt" GridLines="Horizontal" Width="719px" AllowPaging="True" OnPageIndexChanging="gvRoleList_PageIndexChanging" PageSize="20" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelID" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField DataField="No" HeaderText="No.">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="role_code" HeaderText="Role Code" />
                                                <asp:BoundField DataField="role_desc" HeaderText="Description" />
                                                 <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkActiveRole" runat="server" Checked='<%# IIf(Eval("Active_Status").ToString() = "Y", True, False)%>'  Enabled="False" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" CommandName="EditRow" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:ButtonField>
                                                 <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick ="Confirm()" CommandName ="DeleteRow" CommandArgument ='<%# Bind("id")%>'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                             <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="" PageButtonCount="20" Position="TopAndBottom" PreviousPageText="" />
                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="left" />
                                            <RowStyle BackColor="White" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                                    <td width="20%"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </li>
        <%--<li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-2" /><label for="css3-tabstrip-0-2">Create Group</label>
             <div>
                <table width="100%">
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td width="2%"></td>
                        <td width="41%" style="font-family: Quark; color: #FFFFFF; background-color: #009999; font-size: medium; font-weight: bold;border-top-left-radius:10px;border-top-right-radius:10px; text-align: center;">
                    <table><tr><td> <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/icon_Group.png" Height="37" Width="37" /></td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;Group Information</td></tr></table>
                            
                            <table width="100%" style="background-color: #AFEEEE; height: 314px;">
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">
                                        Group Code :
                                        <asp:Label ID="lbl11" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtGroupCode" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="50" oncopy="return false" oncut="return false" onpaste="return false" OnKeypress="return isDataKey(event)"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                </tr>
                                <tr><td style="font-family: quark; font-size: 12pt; font-weight: bold; color: #006666; text-align: right">&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;">
                                        Description :
                                        <asp:Label ID="lbl12" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtDesc" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="255" oncopy="return false" oncut="return false" onpaste="return false" OnKeypress="return isDataKey(event)"></asp:TextBox>
                                    </td>
                                   
                                </tr>
                                 <tr checked="False">
                                    
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;"></td>
                                    <td class="auto-style2" style="text-align: left">&nbsp;<asp:CheckBox ID="chkActiveStatusG" runat="server" Text="Active Status" Font-Names="Quark" ForeColor="#006666" Font-Size="12pt" Checked="True" Font-Bold="True" /></td>
                                
                                 </tr>
                                <tr>
                                      <td style="color: #006666;text-align: right;" class="auto-style4"></td>
                                    <td class="auto-style4">&nbsp;<asp:TextBox ID="txtIDGroup" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" Visible="False" Text="0">0</asp:TextBox></td>
                                
                                </tr>
                                <tr>
                                      <td style="color: #006666;text-align: right;" class="auto-style3"></td>
                                    <td class="auto-style3"></td>
                                
                                </tr>
                              
                            </table>
                           
                        </td>
                        <td width="4%"></td>
                        <td width="51%" style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;" width="36%">
                               <table><tr><td>
                                 <br />
                                 <br />
                                 </td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;Group List</td></tr></table> 
                            <table width="100%" style="background-color: #AFEEEE; height: 312px;">
                               
                                <tr>
                                    <td style="vertical-align: top">
                                        <asp:GridView ID="gvGroupList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Font-Bold="True" Font-Names="Quark" Font-Size="12pt" GridLines="Horizontal" Width="100%" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvGroupList_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelID" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField DataField="No" HeaderText="No.">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="group_code" HeaderText="Group Code" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:ButtonField DataTextField="group_desc" HeaderText="Group Name" CommandName="GroupName" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                </asp:ButtonField>
                                                 <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkActiveGroup" runat="server" Checked='<%# IIf(Eval("Active_Status").ToString() = "Y", True, False)%>'  Enabled="False" />
                                                    </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:ButtonField ButtonType="Image" HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" CommandName="EditRow" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:ButtonField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick ="Confirm()" CommandName ="DeleteRow" CommandArgument ='<%# Bind("id")%>'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelDesc" runat="server" Text='<%# Bind("group_desc")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                             <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="" PageButtonCount="5" PreviousPageText="" />
                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="White" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="2%"></td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <asp:Button ID="btnSaveGroup" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancelGroup" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                   </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr><td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align: center">
                            <asp:Panel ID="Panel1" runat="server" Visible="False"><table style="text-align: center" width="100%">
                                <tr><td></td><td style="text-align: left; font-family: Quark; font-size: 12pt; font-weight: bold">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                    </td><td></td></tr>
                                <tr>
                                    <td width="20%"></td>
                                    <td style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;" class="auto-style5" width="60%" >
                             &nbsp; Group "<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>"
                            <table style="background-color: #AFEEEE; width: 98%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvShowServer" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Font-Bold="True" Font-Names="Quark" Font-Size="12pt" GridLines="Horizontal" Width="700px" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvShowServer_PageIndexChanging">
                                            <Columns>
                                                 <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelID" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField DataField="No" HeaderText="No.">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ServerName" HeaderText="Server Name" />
                                                <asp:BoundField DataField="ServerIP" HeaderText="Server IP" />
                                                <asp:BoundField DataField="MacAddress" HeaderText="Mac Address" />
                                                <asp:BoundField DataField="Location" HeaderText="Location" />
                                                <asp:ButtonField ButtonType="Image" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" CommandName="DeleteRow" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:ButtonField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="" PageButtonCount="5" PreviousPageText="" />
                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="White" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                                     <td width="20%"></td>
                                </tr>
                            </table>
                                </asp:Panel> 
                        </td>
                    </tr>
                </table>
            </div>
        </li><li>
            <input type="radio" name="css3-tabstrip-0" id="css3-tabstrip-0-3" /><label for="css3-tabstrip-0-3">Register</label>
            <div>
                <table width="100%">
                    
                    <tr><td colspan="5">&nbsp;</td></tr>
                    <tr>
                        <td width="1%"></td>
                        <td style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;" width="47%">
                          <table><tr><td>&nbsp; <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/icon_Register.png" Height="37" Width="37" /></td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;Register</td></tr></table> 
                             <table width="100%" style="background-color : #AFEEEE; height: 309px">
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-family: Quark; font-weight: bold; font-size: 12pt;" class="auto-style3">Server IP :
                                        <asp:Label ID="lbl13" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;&nbsp;
                                    </td>
                                    <td class="auto-style3">
                                       <asp:TextBox ID="txtServerIP" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="15" onkeypress="return isNumberPKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                                    </td>
                                     <td style="color: #006666;text-align: right; font-family: Quark; font-size: 12pt; font-weight: bold;" class="auto-style3">Server Name :
                                        <asp:Label ID="lbl19" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                         &nbsp; </td>
                                    <td style="text-align: left" class="auto-style3"> <asp:TextBox ID="txtServerName" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="100" Onkeypress="return isServerNameKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox></td>
                                </tr>
                              
                                <tr>
                                      <td style="color: #006666;text-align: right; font-family: Quark; font-weight: bold; font-size: 12pt;">
                                        Mac Address :&nbsp;<asp:Label ID="lbl21" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtMacAddress" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="12" Onkeypress="return isMacAddressKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                                    </td>
                                     <td style="color: #006666;text-align: right; font-family: Quark; font-size: 12pt; font-weight: bold;">
                                        OS :&nbsp;<asp:Label ID="lbl20" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                         &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOS" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="255" Onkeypress="return isDataKey(event)" oncopy="return false" oncut="return false" onpaste="return false" ></asp:TextBox>
                                    </td> 
                                </tr>
                                
                                <tr><td style="font-family: Quark; font-weight: bold; color: #006666; text-align: right; font-size: 12pt;">&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-family: Quark; font-weight: bold; font-size: 12pt;">
                                        Project Name :&nbsp;<asp:Label ID="lbl22" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="txtSystem" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="100" oncopy="return false" oncut="return false" onpaste="return false" OnKeypress="return isDataKey(event)"></asp:TextBox>
                                    </td>
                                   
                                </tr>
                                 <tr>
                                      <td style="color: #006666;text-align: right; font-family: Quark; font-weight: bold; font-size: 12pt;">
                                        Location Server :&nbsp;&nbsp;&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtLacServer" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="100" oncopy="return false" oncut="return false" onpaste="return false" OnKeypress="return isDataKey(event)"></asp:TextBox>
                                    </td>
                                     
                                </tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-family: Quark; font-weight: bold; font-size: 12pt;">
                                        Location Number :&nbsp;
                                    &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtLacNumber" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="100" oncopy="return false" oncut="return false" onpaste="return false" OnKeypress="return isDataKey(event)"></asp:TextBox>
                                    </td> 
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                               
                            </table>
                        </td>
                        <td width="1%"></td>
                        <td style="background-color: #009999; color: #FFFFFF; font-weight: bold; font-family: Quark; font-size: medium;border-top-left-radius:10px;border-top-right-radius:10px;" width="25%">
                             <table><tr><td>
                                 <br />
                                 <br />
                                 </td><td style="font-family: quark; font-weight: bold; color: #FFFFFF; font-size: 14pt">&nbsp;Notification</td></tr></table> 
                              <table width="100%" style="background-color: #AFEEEE; height: 289px;">
                                <tr><td class="auto-style7">&nbsp;</td><td></td><td>&nbsp;</td></tr>
                                  <tr>
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;" class="auto-style7">
                                        First Name :
                                        <asp:Label ID="lbl16" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtFnameR" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="100" onkeypress="return isNameKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                                    </td>
                                   
                                </tr>
                                  <tr><td class="auto-style7" style="font-family: quark; font-size: 12pt; font-weight: bold; color: #006666; text-align: right">&nbsp;</td></tr>
                                  <tr>
                                       <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;" class="auto-style7">
                                        Last Name :
                                           <asp:Label ID="lbl17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="txtLnameR" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="100" onkeypress="return isNameKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                                    </td>
                                  </tr>
                                <tr><td class="auto-style7" style="font-family: quark; font-size: 12pt; font-weight: bold; color: #006666; text-align: right">&nbsp;</td></tr>
                                <tr>
                                     <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;" class="auto-style7">
                                        E-mail :
                                         <asp:Label ID="lbl18" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    &nbsp;</td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="txtEmail" runat="server" Font-Names="Quark" ForeColor="Black" Font-Size="11pt" CssClass="textbox" MaxLength="100" onkeypress="return isNumberEKey(event)" oncopy="return false" oncut="return false" onpaste="return false"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="'email@gmail.com'" Font-Names="Quark" Font-Size="12pt" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr><td class="auto-style7" style="font-family: quark; font-size: 12pt; font-weight: bold; color: #006666; text-align: right">&nbsp;</td></tr>
                                <tr>
                                    <td style="color: #006666;text-align: right; font-family: quark; font-size: 12pt; font-weight: bold;" class="auto-style7">
                                        Group :&nbsp; &nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpGroup" runat="server" Height="25px" Width="175px" CssClass="textbox"></asp:DropDownList>
                                    </td>
                                   
                                </tr>
                               
                                   <tr><td class="auto-style7">
                                     <asp:TextBox ID="txtIDRegister" runat="server" Visible="False">0</asp:TextBox>
                                     </td>
                                     <td class="auto-style2" style="text-align: left">&nbsp;<asp:CheckBox ID="chkActiveStatusR" runat="server" Text="Active Status" Font-Names="Quark" ForeColor="#006666" Font-Size="12pt" Checked="True" Font-Bold="True"/></td>
                                
                                 </tr>
                                <tr><td class="auto-style7">&nbsp;</td></tr>
                             </table>
                        </td>
                        <td width="1%"></td>
                    </tr>
                    
                    <tr><td colspan="5">&nbsp;</td></tr>
                    <tr>
                        
                        <td style="text-align: center"  colspan="5">
                            <asp:Button ID="btnSaveRegister" CssClass="myButton" runat="server" Text="Save" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancelRegister" CssClass="myButton" runat="server" Text="Cancel" />
                        </td>
                        
                   </tr>
                    
                    <tr>
                        <td colspan="5">
                            &nbsp;<table width="100%">
                                <tr><td>&nbsp;</td></tr>
                                <tr><td width="2%" >&nbsp;</td>
                                    <td width="96%" colspan="3" style="text-align: center">
                                        <asp:GridView ID="gvRegister" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="930px" Font-Bold="True" Font-Names="Quark" Font-Size="12pt" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvRegister_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelID" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="No" HeaderText="No." />
                                                <asp:BoundField DataField="ServerIP" HeaderText="Server IP" />
                                                <asp:BoundField DataField="ServerName" HeaderText="Server Name" />
                                                <asp:BoundField DataField="OS" HeaderText="OS" />
                                                <asp:BoundField DataField="System_Type" HeaderText="System" />
                                                <asp:BoundField DataField="name" HeaderText="Name" />
                                                <asp:BoundField DataField="E_mail" HeaderText="E-mail" />
                                                 <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true" >
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkActiveRegister" runat="server" Checked='<%# IIf(Eval("Active_Status").ToString() = "Y", True, False)%>'  Enabled="False" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:ButtonField HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" CommandName="EditRow" ButtonType="Image" />
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick ="Confirm()" CommandName ="DeleteRow" CommandArgument ='<%# Bind("id")%>'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="" PageButtonCount="5" PreviousPageText="" Position="TopAndBottom" />
                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="left" />
                                            <RowStyle BackColor="White" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                        </asp:GridView>
                                    </td>
                                    <td width="2%" >&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </li>--%>
    </ul>
</div>
 
</asp:Content>
   

