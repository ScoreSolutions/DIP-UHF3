<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmSearchFilePositonByFile.aspx.vb" Inherits="frmSearchFilePositonByFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div >
       <%-- <div class="breadcrumbs" id="breadcrumbs">
            <ul class="breadcrumb">
                <li>
                    <i class="icon-home home-icon"></i>
                    <a href="frmPortal.aspx">Home</a>

                    <span class="divider">
                        <i class="icon-angle-right arrow-icon"></i>
                    </span>
                </li>
                <li class="active">ตำแหน่งแฟ้มพร้อมรายชื่อผู้ครอบครองแฟ้ม</li>
            </ul>
         
        </div>--%>

        <div class="page-content">
            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">ตำแหน่งแฟ้มพร้อมรายชื่อผู้ครอบครองแฟ้ม</h3>
                    <div class="row-fluid">
                         <div class="span3"></div>
                        <div class="span1">
                            <label class="control-label" for="lblAtendent">เลขที่คำขอ :</label>

                        </div>
                        <div class="span8">
                            <input type="text" class="input-medium search-query" id="txtApp_No" onkeypress="return Numbers(event);" maxlength="10" />
                             <span class="color red" id="lblvalidtxtApp_no" style="display: none">กรุณาระบุเลขที่คำขอ</span>
                            <button id="btnSearch" class="btn btn-primary btn-small">
                                ค้นหา <i class="icon-search icon-on-left bigger-110"></i>
                            </button>
                        </div>
                    </div>

                    <div class="space-2"></div>
                    <div class="row-fluid" id="divNotMap" style="display: none">
                        <div class="span2">
                            <label class="control-label" >วันที่เคลื่อนไหวล่าสุด :</label>
                            <label class="control-label  color blue" id="lblDateTimeNotMap"></label>
                        </div>
                        <div class="span2">
                            <label class="control-label" >เลขที่คำขอ :</label>
                            <label class="control-label  color blue" id="lblAppNoNotMap"></label>
                        </div>
                        <div class="span2">
                            <label class="control-label" >ผู้ยืม :</label>
                            <label class="control-label  color blue" id="lblBorrowNameNotMap"></label>
                        </div>
                         <div class="span2">
                            <label class="control-label" >วันที่ยืม :</label>
                            <label class="control-label  color blue" id="lblBorrowDateNotMap"></label>
                        </div>
                        <div class="span4">
                            <label class="control-label" >ตำแหน่งแฟ้ม :</label>
                            <label class="control-label  color blue" id="lblLocationnotmap"></label>
                        </div>
                    </div>

                    <div class="row-fluid" id="divNotFound" style="display: none">
                        <div class="span10">
                            <strong class="color red">ไม่พบข้อมูล</strong>
                            <%--         <label class="control-label " for="lblNotFound"></label>--%>
                        </div>
                    </div>
                    <div class="hr hr10" id="divFoundLine" style="display: none"></div>
                    <div class="row-fluid" id="divFound" style="display: none">

                        <div class="span2">
                            <label class="control-label" >วันที่เคลื่อนไหวล่าสุด :</label>
                            <label class="control-label  color blue" id="lblDateTime"></label>
                        </div>
                        <div class="span2">
                            <label class="control-label" >เลขที่คำขอ :</label>
                            <label class="control-label  color blue" id="lblAppNo"></label>

                        </div>
                        <div class="span2">
                            <label class="control-label" >ผู้ยืม :</label>
                            <label class="control-label  color blue" id="lblBorrowName"></label>

                        </div>
                         <div class="span2">
                            <label class="control-label" >วันที่ยืม :</label>
                            <label class="control-label  color blue" id="lblBorrowDate"></label>

                        </div>
                        <div class="span4">
                            <label class="control-label" >ตำแหน่งแฟ้ม :</label>
                            <label class="control-label  color blue" id="lblLocation"></label>
                        </div>
                    </div>
                    <div class="hr hr10" id="divFoundPositionLine" style="display: none"></div>
                    <div class="row-fluid" id="divFoundPosition" style="display: none">
                        <div class="span12">
                            <label class="control-label  color blue" id="lblposition">ระบุที่อยู่ตำแห่งแฟ้ม</label>
                        </div>
                    </div>
                     <div class="row-fluid">
                         <center>
                               <div id="divGridShow"></div>
                         </center>
                     </div>     
                </div>

            </div>
            <!--/.span-->
        </div>


    </div>

    <script type="text/javascript">
        //Open page
        $(document).ready(function () {
   
            var oTable;
            $("#btnSearch").click(function () {
            var checkvalid = onValid();
                if (checkvalid == true) {
                    LoadData();
             }
            });

            $("#btnClear").click(function () {

            });
        });


        function LoadData() {
            var app_no = $("#txtApp_No").val();
            var login_username = 'Signage';
            var param = "{'app_no':" + JSON.stringify(app_no)
                        + ",'login_username':" + JSON.stringify(login_username)
                        + "}";
        
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadFloorPlanByApp_No",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    if (jsonobject.length > 0) {
                        
                        $("#lblDateTime").text(jsonobject[0].strmove_date);
                        $("#lblAppNo").text(jsonobject[0].app_no);
                        $("#lblBorrowName").text(jsonobject[0].borrowname);
                        $("#lblBorrowDate").text(jsonobject[0].borrowerdate);
                        $("#lblLocation").text(jsonobject[0].location_name);
                        $("#divGridShow").show();
                        $("#divGridShow").html(jsonobject[0].showdata);
                        //$('#' + jsonobject[0].showfound).blink();
                        var vShowFound = jsonobject[0].showfound.split(",");
                        for (k = 0; k < vShowFound.length; k++) {
                            $('#' + vShowFound[k]).blink();
                        }

                        $("#divFoundLine").show();
                        $("#divFound").show();
                        $("#divFoundPositionLine").show();
                        $("#divFoundPosition").show();
                        $("#divNotFound").hide();
                        $("#divNotMap").hide();
                    } else {
                        $("#divFoundLine").hide();
                        $("#divFound").hide();
                        $("#divFoundPositionLine").hide();
                        $("#divFoundPosition").hide();
                        $("#divGridShow").hide();
                        $("#divNotFound").show();
                        LoadDataDefalut();
                    }              
                    
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });

        }

        function LoadDataDefalut() {
            var app_no = $("#txtApp_No").val();
            var login_username = 'Signage';
            var param = "{'app_no':" + JSON.stringify(app_no)
                        + ",'login_username':" + JSON.stringify(login_username)
                        + "}";
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadFloorPlanByApp_No_NotMap",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);

                    if (jsonobject.length > 0) {
                        
                        $("#divNotMap").show();
                        $("#lblLocationnotmap").text(jsonobject[0].location_name);
                        $("#lblAppNoNotMap").text(app_no);
                        $("#lblDateTimeNotMap").text(jsonobject[0].move_date);
                        $("#lblBorrowNameNotMap").text(jsonobject[0].borrowname);
                        $("#lblBorrowDateNotMap").text(jsonobject[0].borrowerdate);

                        $("#divNotFound").hide();
                    } else {
                        $("#divNotMap").hide();

                    }

                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });

        }


        //Hide Valid
        function onValidHide() {
            $("#lblvalidtxtApp_no").hide();
        }
        //Check Valid
        function onValid() {
            var isValid;
            isValid = true;
            var app_no = $('#txtApp_No').val();
            if (app_no == '') {
                $("#lblvalidtxtApp_no").show();
                isValid = false;
            } else {
                $("#lblvalidtxtApp_no").hide();
            }

            return isValid;
        }

        //clear control
        function clearinput() {
            $("#txtApp_No").val("");
        }

        function Numbers(e) {
            var keynum;
            var keychar;
            var numcheck;
            if (window.event) {// IE
                keynum = e.keyCode;
            }
            else if (e.which) {// Netscape/Firefox/Opera
                keynum = e.which;
            }
            if (keynum == 13 || keynum == 8 || typeof (keynum) == "undefined") {
                return true;
            }
            keychar = String.fromCharCode(keynum);
            numcheck = /^[0-9]$/;
            return numcheck.test(keychar);
        }

    </script>
</asp:Content>



