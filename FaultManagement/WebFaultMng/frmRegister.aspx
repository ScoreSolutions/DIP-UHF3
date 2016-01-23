<%@ Page Title="" Language="VB" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="false" CodeFile="frmRegister.aspx.vb" Inherits="frmRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    //Show dialog
    function showModal(page, width, height, scroll) {
        showModalDialog(page, "", "dialogWidth:" + width + "px; dialogHeight:" + height + "px;help:no;status:no;center:yes;scroll:" + scroll);
    }

<%--    //function of Checkbox
    function ChkBox() {
        var Female = document.getElementById("<%=chkFemale.ClientID%>");
        var Male = document.getElementById("<%= chkMale.ClientID%>");

        if (Female.checked == true) {
            Male.checked = false
        }
    }--%>

<%--    function ChkBoxs() {
        var Female = document.getElementById("<%=chkFemale.ClientID%>");
             var Male = document.getElementById("<%= chkMale.ClientID%>");

             if (Male.checked == true) {
                 Female.checked = false
             }
         }--%>

<%--         function Chk() {
             var Female = document.getElementById("<%=chkFemale.ClientID%>");
             var Male = document.getElementById("<%= chkMale.ClientID%>");

             if (Female.checked == true) {
                 Male.checked = false
             }
         }--%>

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
             if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode != 46) && (charCode < 64 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode != 95))
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
    <script type="text/javascript">
        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table width="100%">
         <tr>
            <td style="font-family: quark; font-size: 20pt; font-weight: bold; color: #000000; border-radius:15px; ">&nbsp;&nbsp; Register</td>
        </tr>
        <tr><td style="background-color: #666666"></td></tr>
        <tr>
            <td></td>
        </tr>
    </table>
    
    <div id="divdata" style="display:none" runat="server">
    </div>
    <div id="divgrid" runat="server">
          <table width="100%">
               <tr>
                <td style="padding-left: 40px;" style="width: 10%">&nbsp;
                     <asp:Button ID="btnNew" CssClass="myButton" runat="server" Text="New" />
                   <%-- <asp:Button ID="btnBack" CssClass="myButton" runat="server" Text="Back" Visible="false" />--%>
                </td> 
                <td align="right" style="width: 85%; vertical-align: bottom;">
                    <asp:TextBox ID="txtSearch" runat="server" Width="170px" Height="24px"></asp:TextBox>
                </td>
                <td align="left" style="width: 15%; vertical-align: bottom;">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="myButton" />
                </td>
            </tr>
          </table>
        <table width="100%">
           
            <tr>
                <td style="padding-left: 40px;">
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
                            <asp:TemplateField HeaderText="Active Status" SortExpression="active_status" Visible="true">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkActiveRegister" runat="server" Checked='<%# IIf(Eval("Active_Status").ToString() = "Y", True, False)%>' Enabled="False" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField HeaderText="Edit" ImageUrl="~/Images/icon_Edit.png" CommandName="EditRow" ButtonType="Image" />
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton ID="Delete" runat="server" HeaderText="Delete" ImageUrl="~/Images/icon_Delete.png" OnClientClick="Confirm()" CommandName="DeleteRow" CommandArgument='<%# Bind("id")%>' />
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
            </tr>
        </table>
    </div>

</asp:Content>

