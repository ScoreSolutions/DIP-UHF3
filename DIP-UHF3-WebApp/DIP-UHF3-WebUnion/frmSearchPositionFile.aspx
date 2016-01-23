<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmSearchPositionFile.aspx.vb" Inherits="frmSearchPositionFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
        <style type="text/css" media="screen">
            .tbbackground {
                background: url(images/PlanFloor1.jpg);
                background-size: 100% auto;
            }
        </style>
        <style>
            .photo {
                width: 300px;
                text-align: center;
            }

                .photo .ui-widget-header {
                    margin: 1em 0;
                }

            .map {
                width: 150px;
                height: 150px;
            }

            .ui-tooltip {
                max-width: 150px;
            }
        </style>

        <script src="Demo/assets/js/jquery-blink/jquery-blink/jquery-blink.js"></script>

        <script type="text/javascript" language="javascript">

            $(document).ready(function () {
                $('.blink').blink(); // default is 500ms blink interval.
                //$('.blink').blink({delay:100}); // causes a 100ms blink interval.
            });

        </script>

        <script>
            $(function () {
                $(document).tooltip({
                    items: "img, [data-geo], [title]",
                    content: function () {
                        var element = $(this);
                        if (element.is("[data-geo]")) {
                            //var des="<table  style="width: 150px; height: 150px;" border="0">"
                            //     <tr>
                            //         <td style="width: 75px;">เลขที่แฟ้ม</td>
                            //         <td style="width: 75px;">1234567891</td>
                            //     </tr>
                            //             <tr>
                            //         <td style="width: 75px;">ผู้ครอบครอง</td>
                            //         <td style="width: 75px;">นาย วีระชัย มีดี</td>
                            //     </tr>
                            //                    <tr>
                            //         <td style="width: 75px;">สถานที่</td>
                            //         <td style="width: 75px;">ห้องแฟ้มชั้น 6 โต๊ะ /</td>
                            //     </tr>
                            // </table>
                            var text = element.text();

                            return "<img class='map' alt='" + text +
                              "' src='http://maps.google.com/maps/api/staticmap?" +
                              "zoom=11&size=150x150&maptype=terrain&sensor=false&center=" +
                              text + "'>";
                        }
                        if (element.is("[title]")) {
                            return element.attr("title");
                        }
                        if (element.is("img")) {
                            return element.attr("alt");
                        }
                    }
                });
            });
        </script>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="1000" Enabled="False"></asp:Timer>

        <div class="main-content">
            <div class="breadcrumbs" id="breadcrumbs">
                <ul class="breadcrumb">
                    <li>
                        <i class="icon-home home-icon"></i>
                        <a href="frmTagRoot.aspx">หน้าแรก</a>

                        <span class="divider">
                            <i class="icon-angle-right arrow-icon"></i>
                        </span>
                    </li>

                    <li class="active">ค้นหาตำแหน่งแฟ้ม</li>
                </ul>
                <!--.breadcrumb-->

                <%--            <div class="nav-search" id="nav-search">
                <form class="form-search" />
                <span class="input-icon">
                    <input type="text" placeholder="Search ..." class="input-small nav-search-input" id="nav-search-input" autocomplete="off" />
                    <i class="icon-search nav-search-icon"></i>
                </span>
                </form>
            </div>--%>
                <!--#nav-search-->
            </div>

            <div class="page-content">


                <div class="row-fluid">
                    <div class="span12">
                        <!--PAGE CONTENT BEGINS-->


                        <div class="row-fluid">
                            <h3 class="header smaller lighter blue">ค้นหาตำแหน่งแฟ้ม</h3>
                            <%--     <div class="table-header">
                            View Demo
                        </div>--%>


                            <div class="dt_out_actions" style="display: none">
                                <div class="btn-group pull-Left">
                                    <button class="btn btn-app btn-info btn-mini no-radius" id="btnPrint" name="btnPrint">
                                        <i class="icon-print bigger-100"></i>
                                        Print
                                    </button>
                                    <button class="btn btn-app btn-success btn-mini no-radius" id="btnAddnew" name="btnAddnew">
                                        <i class="icon-folder-open bigger-100"></i>
                                        Add New
                                    </button>
                                    <button class="btn btn-app btn-danger btn-mini no-radius" id="btnDelete" name="btnDelete">
                                        <i class="icon-trash bigger-100"></i>
                                        Delete
                                    </button>

                                </div>
                            </div>
                        </div>
                        <%-- <table class="table table-striped table-bordered table-hover" id="dt_out"></table>--%>
                        <!--/PAGE CONTENT BEGINS-->

                        <%--                 <div class="row-fluid">
						<div class="span12">
							

                    <iframe id="iFrame" runat="server" frameborder="0" style="overflow:hidden;height:450px;width:100%"  ></iframe>


                    <!--/PAGE CONTENT END-->

                </div>

            </div>--%>
                        <asp:UpdatePanel ID="updatepanel1" runat="server">
                            <ContentTemplate>
                                <div class="row-fluid">
                                    <div class="span1">
                                        <label class="control-label" for="lblAtendent">เลขที่แฟ้ม :</label>

                                    </div>
                                    <div class="span3">
                                        <input type="text" id="txtAppno" runat="server" placeholder="เลขที่แฟ้ม" />

                                    </div>
                                    <div class="span4">
                                        <button class="btn btn-small btn-primary" style="width: 100px" id="btnSearch" runat="server" onserverclick="btnSearch_ServerClick">
                                            <i class=" icon-search bigger-110"></i>ค้นหา
                                        </button>
                                        <button class="btn btn-danger btn-small" style="width: 100px" id="btnStop" runat="server" onserverclick="btnStop_ServerClick">
                                            <i class=" icon-stop bigger-110"></i>หยุด
                                        </button>
                                    </div>
                                    <div class="span3">
                                    </div>
                                    <div class="span1">
                                    </div>

                                </div>

                                <div class="row-fluid">
                                    <div class="span12">
                                        <!--PAGE CONTENT BEGINS-->
                                        <%--      <table  style="width: 150px; height: 150px;" border="0">
                                      <tr>
                                          <td style="width: 75px;">เลขที่แฟ้ม</td>
                                          <td style="width: 75px;">1234567891</td>
                                      </tr>
                                              <tr>
                                          <td style="width: 75px;">ผู้ครอบครอง</td>
                                          <td style="width: 75px;">นาย วีระชัย มีดี</td>
                                      </tr>
                                                     <tr>
                                          <td style="width: 75px;">สถานที่</td>
                                          <td style="width: 75px;">ห้องแฟ้มชั้น 6 โต๊ะ /</td>
                                      </tr>
                                  </table>--%>
                                        <div class="center">
                                            <table style="width: 800px; height: 500px; border: none" border="0">
                                                <tr>

                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_01.jpg') no-repeat center;">
                                                        <img id="cell1" runat="server" alt="" src="~/images/Untitled_01.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_02.jpg') no-repeat center;">
                                                        <img id="cell2" runat="server" alt="" src="~/images/Untitled_02.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_03.jpg') no-repeat center;">
                                                        <img id="cell3" runat="server" alt="" src="~/images/Untitled_03.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_04.jpg') no-repeat center;">
                                                        <img id="cell4" runat="server" alt="" src="~/images/Untitled_04.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_05.jpg') no-repeat center;">
                                                        <img id="cell5" runat="server" alt="" src="~/images/Untitled_05.jpg" style="width: 160px; height: 100px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_06.jpg') no-repeat center;">
                                                        <img id="cell6" runat="server" alt="" src="~/images/Untitled_06.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_07.jpg') no-repeat center;">
                                                        <img id="cell7" runat="server" alt="" src="~/images/Untitled_07.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_08.jpg') no-repeat center;">
                                                        <img id="cell8" runat="server" alt="" src="~/images/Untitled_08.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_09.jpg') no-repeat center;">
                                                        <img id="cell9" runat="server" alt="" src="~/images/Untitled_09.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_10.jpg') no-repeat center;">
                                                        <img id="cell10" runat="server" alt="" src="~/images/Untitled_10.jpg" style="width: 160px; height: 100px" /></td>
                                                </tr>
                                                <tr>

                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_11.jpg') no-repeat center;">
                                                        <img id="cell11" runat="server" alt="" src="~/images/Untitled_11.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_12.jpg') no-repeat center;">
                                                        <img id="cell12" runat="server" alt="" src="~/images/Untitled_12.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_13.jpg') no-repeat center;">
                                                        <img id="cell13" runat="server" alt="" src="~/images/Untitled_13.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_14.jpg') no-repeat center;">
                                                        <img id="cell14" runat="server" alt="" src="~/images/Untitled_14.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_15.jpg') no-repeat center;">
                                                        <img id="cell15" runat="server" alt="" src="~/images/Untitled_15.jpg" style="width: 160px; height: 100px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_16.jpg') no-repeat center;">
                                                        <img id="cell16" runat="server" alt="" src="~/images/Untitled_16.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_17.jpg') no-repeat center;">
                                                        <img id="cell17" runat="server" alt="" src="~/images/Untitled_17.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_18.jpg') no-repeat center;">
                                                        <img id="cell18" runat="server" alt="" src="~/images/Untitled_18.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_19.jpg') no-repeat center;">
                                                        <img id="cell19" runat="server" alt="" src="~/images/Untitled_19.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_20.jpg') no-repeat center;">
                                                        <img id="cell20" runat="server" alt="" src="~/images/Untitled_20.jpg" style="width: 160px; height: 100px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_21.jpg') no-repeat center;">
                                                        <img id="cell21" runat="server" alt="" src="~/images/Untitled_21.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_22.jpg') no-repeat center;">
                                                        <img id="cell22" runat="server" alt="" src="~/images/Untitled_22.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_23.jpg') no-repeat center;">
                                                        <img id="cell23" runat="server" alt="" src="~/images/Untitled_23.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_24.jpg') no-repeat center;">
                                                        <img id="cell24" runat="server" alt="" src="~/images/Untitled_24.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_25.jpg') no-repeat center;">
                                                        <img id="cell25" runat="server" alt="" src="~/images/Untitled_25.jpg" style="width: 160px; height: 100px" /></td>
                                                </tr>
                                                <%--                  <tr>
                                        <td>17&nbsp;</td>
                                        <td>18&nbsp;</td>
                                        <td>19&nbsp;</td>
                                       <td>20&nbsp;</td>
                                    </tr>
                                                <tr>
                                        <td>21&nbsp;</td>
                                        <td>22&nbsp;</td>
                                        <td>24&nbsp;</td>
                                       <td>24&nbsp;</td>
                                    </tr>--%>
                                            </table>
                                        </div>


                                        <!--PAGE CONTENT ENDS-->
                                    </div>
                                    <!--/.span-->
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <!--/.span-->
                    </div>
                    <!--/.row-fluid-->

                    <!--/.page-content-->

                    <div class="ace-settings-container" id="ace-settings-container">
                        <div class="btn btn-app btn-mini btn-warning ace-settings-btn" id="ace-settings-btn">
                            <i class="icon-cog bigger-150"></i>
                        </div>

                        <div class="ace-settings-box" id="ace-settings-box">
                            <div>
                                <div class="pull-left">
                                    <select id="skin-colorpicker" class="hide">
                                        <option data-class="default" value="#438EB9" />
                                        #438EB9
									<option data-class="skin-1" value="#222A2D" />
                                        #222A2D
									<option data-class="skin-2" value="#C6487E" />
                                        #C6487E
									<option data-class="skin-3" value="#D0D0D0" />
                                        #D0D0D0
                                    </select>
                                </div>
                                <span>&nbsp; Choose Skin</span>
                            </div>

                            <div>
                                <input type="checkbox" class="ace-checkbox-2" id="ace-settings-header" />
                                <label class="lbl" for="ace-settings-header">Fixed Header</label>
                            </div>

                            <div>
                                <input type="checkbox" class="ace-checkbox-2" id="ace-settings-sidebar" />
                                <label class="lbl" for="ace-settings-sidebar">Fixed Sidebar</label>
                            </div>

                            <div>
                                <input type="checkbox" class="ace-checkbox-2" id="ace-settings-breadcrumbs" />
                                <label class="lbl" for="ace-settings-breadcrumbs">Fixed Breadcrumbs</label>
                            </div>

                            <div>
                                <input type="checkbox" class="ace-checkbox-2" id="ace-settings-rtl" />
                                <label class="lbl" for="ace-settings-rtl">Right To Left (rtl)</label>
                            </div>
                        </div>
                    </div>
                    <!--/#ace-settings-container-->
                </div>
            </div>
            <input type="hidden" runat="server" id="Hidevalue" value="block" />

        </div>



        <script type="text/javascript">

            $("#btnSearch").click(function () {
                alert($("#td_cell1"));
                $("#td_cell1").effect("highlight", {}, 3000); return false;
            });

            function setcss(value) {
                if (value == '0') {
                    $("#btnRemove").hide();
                    $("#btnAdd").show();
                } else {
                    $("#btnRemove").show();
                    $("#btnAdd").hide();
                }
            }

            <%--            $(window).ready(function () {
                // executes when HTML-Document is loaded and DOM is ready
                alert($("#<%= Hidevalue.ClientID%>").css('display'));
                if ($("#<%= Hidevalue.ClientID%>").css('display') == 'block') {
                    alert('Xblock');
                    $('#btnRemove').css("display", "block");
                    $('#btnAdd').css("display", "none");
                } else {
                    alert('Xnone');
                    $('#btnRemove').css("display", "block");
                    $('#btnAdd').css("display", "none");
                }
            });--%>

   <%--         $(window).load(function () {
                //  $('#dvLoading').fadeOut(2000);
                if ($("#<%= Hidevalue.ClientID%>").css('display') == 'block') {
                    alert('Xblock');
                    $('#btnRemove').css("display", "block");
                    $('#btnAdd').css("display", "none");
                } else {
                    alert('Xnone');
                    $('#btnRemove').css("display", "block");
                    $('#btnAdd').css("display", "none");
                }

            });--%>


            // Standard Dialogs
            $("#btnAdd").on('click', function () {
                onConfirm();

            });

            $("#btnRemove").on('click', function () {
                onConfirmRemove();
            });


            // Alert
            function onAlert(msg) {

                var div = $("<div>" + msg + "</div>");
                div.dialog({
                    title: "Message",
                    modal: true,
                    buttons: [

                                {
                                    text: "Ok",
                                    click: function () {
                                        div.dialog("close");

                                    }
                                }
                    ]
                });

            }



            function getParameterByName(name) {
                name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
                var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                    results = regex.exec(location.search);
                return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
            }

            // Confirm
            function onConfirm() {

                var msg = 'Please confirm the add';
                var div = $("<div>" + msg + "</div>");
                div.dialog({
                    title: "Confirm",
                    modal: true,
                    buttons: [
                                {
                                    text: "Yes",
                                    click: function () {
                                        div.dialog("close");
                                        onSave();
                                    }
                                },
                                {
                                    text: "No",
                                    click: function () {
                                        div.dialog("close");
                                    }
                                }
                    ]
                });



            }

            function onConfirmRemove() {

                var msg = 'Please confirm the remove';
                var div = $("<div>" + msg + "</div>");
                div.dialog({
                    title: "Confirm",
                    modal: true,
                    buttons: [
                                {
                                    text: "Yes",
                                    click: function () {
                                        div.dialog("close");
                                        onSaveRemove();
                                    }
                                },
                                {
                                    text: "No",
                                    click: function () {
                                        div.dialog("close");
                                    }
                                }
                    ]
                });



            }


            function onSave() {

                var strTemp = '0,' + getParameterByName('id') + '#true';
                var param = "{'strID':" + JSON.stringify(strTemp) + "}";
                //var param = "{'strID':" + strTemp + "}";
                $.ajax({
                    type: "POST",
                    url: "WebSevice/WebService.asmx/SaveBlackList",
                    data: param,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: onSuccess,
                    error: onFailed
                });
            }

            function onSaveRemove() {
                <%-- var strTemp = $("#<%= txtKeepId.ClientID%>").val();--%>

                var strTemp = '0,' + getParameterByName('id') + '#false';
                var param = "{'strID':" + JSON.stringify(strTemp) + "}";
                //var param = "{'strID':" + strTemp + "}";
                $.ajax({
                    type: "POST",
                    url: "WebSevice/WebService.asmx/SaveBlackList",
                    data: param,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: onSuccessRemove,
                    error: onFailedRemove
                });
            }


            function onSuccess(result) {

                if (result.d == true) {
                    onAlert("Add Complete");
                    setcss(1);
                } else {
                    onAlert("Add Fail");
                }

            }

            function onFailed() {
                onAlert("Add Fail");
            }
            function onSuccessRemove(result) {

                if (result.d == true) {
                    onAlert("Remove Complete");
                    setcss(0);
                } else {
                    onAlert("Remove Fail");
                }

            }

            function onFailedRemove() {
                onAlert("Remove Fail");
            }

        </script>
    </form>
</asp:Content>

