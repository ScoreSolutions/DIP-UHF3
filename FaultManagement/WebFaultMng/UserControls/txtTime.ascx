<%@ Control Language="VB" AutoEventWireup="false" CodeFile="txtTime.ascx.vb" Inherits="UserControls_txtTime" %>

<style type="text/css">
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
<asp:TextBox ID="TextBox1" runat="server"  onkeypress="txtTime_OnKeyPress(this,event);" Width="60"   ></asp:TextBox>
<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>
