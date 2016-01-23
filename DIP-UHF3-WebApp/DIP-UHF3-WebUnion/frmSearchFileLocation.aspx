<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmSearchFileLocation.aspx.vb" Inherits="frmSearchFileLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content">
        <div class="breadcrumbs" id="breadcrumbs">
            <ul class="breadcrumb">
                <li>
                    <i class="icon-home home-icon"></i>
                    <a href="frmPortal.aspx">Home</a>

                    <span class="divider">
                        <i class="icon-angle-right arrow-icon"></i>
                    </span>
                </li>
                <li class="active">สืบย้อนกลับทางเดินของแฟ้ม</li>
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
                    <h3 class="header smaller lighter blue">สืบย้อนกลับทางเดินของแฟ้ม</h3>
                    <div class="row-fluid">
                        <div class="span2">
                            <%--<label class="control-label">เลขที่คำขอ :</label>--%>
                            <span class="help-inline">เลขที่คำขอ :</span>
                        </div>
                        <div class="span10">
                            <input type="text" id="txtApp_no" onkeypress="return Numbers(event)" maxlength="10"  />
                            <span class="help-inline color red" id="lblvalidtxtApp_no" style="display: none">กรุณากรอกข้อมูล</span>

                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span2">
                            <%--  <label class="control-label">วันที่เคลื่อนไหว :</label>--%>
                            <span class="help-inline">วันที่เคลื่อนไหว :</span>
                        </div>
                        <div class="span2">

                            <div class="row-fluid input-append">
                                <input class="date-picker width-55" id="txtDateFrom" type="text" data-date-format="dd/mm/yyyy" />
                                <span class="add-on">
                                    <i class="icon-calendar"></i>
                                </span>

                                <span class="help-inline">ถึง</span>
                            </div>
                            <span class="help-inline color red" id="lblvalidDateFrom" style="display: none">กรุณากรอกข้อมูล</span>


                        </div>
                        <%--           <div  class="span1">
                                <span class="help-inline">To</span>
                            </div>--%>

                        <div class="span2">
                            <div class="row-fluid input-append">
                                <input class="date-picker width-55" id="txtDateTo" type="text" data-date-format="dd/mm/yyyy" />
                                <span class="add-on">
                                    <i class="icon-calendar"></i>
                                </span>
                            </div>
                            <span class="help-inline color red" id="lblvalidDateTo" style="display: none">กรุณากรอกข้อมูล</span>

                        </div>
                        <div class="span6"></div>
                    </div>
                    <div class="row-fluid">
                        <div class="span2">
                            <%--    <label class="control-label">ผู้ยืม :</label>--%>
                            <span class="help-inline">ผู้ยืม :</span>
                        </div>
                        <div class="span10">
                            <input type="text" id="txtUserName" style="width: 200px" placeholder="พิมพ์และเลือก.....">
                            <%--         <span id="linkroomdetail" class="help-button" data-placement="left">
                                   <i class=" icon-warning-sign"></i>
                               </span>--%>
                            <input type="text" id="txtUserId" style="width: 200px; display: none;" placeholder="Id">
                        </div>
                    </div>
                             <div class="row-fluid">
                        <div class="span2">
                            <label class="control-label" for="lblLocation">สถานะ :</label>

                        </div>
                        <div class="span10">
                            <select class="chzn-select" id="cbStatus" data-placeholder="กรุณาเลือก สถานะ..."></select>
                            <span class="help-inline color red" id="lblvalidms_room_type_id" style="display: none">กรุณาเลือก</span>
                        </div>


                    </div>
                    <div class="space-4"></div>
                    <div class="row-fluid" style="display:none">
                        <div class="span2">
                            <label class="control-label" for="lblPatentType">ประเภทแฟ้ม :</label>
                        </div>
                        <div class="span10">
                            <select class="chzn-select" id="cbPatentType" data-placeholder="กรุณาเลือก ประเภทแฟ้ม...">
                            </select>
                            <span class="help-inline color red" id="lblvalidms_PatentType_id" style="display: none">กรุณาเลือก</span>
                        </div>

                    </div>
                      <div class="space-2"></div>
                    <div class="row-fluid" >
                        <div class="span2">
                        </div>
                        <div class="span10">
                            <button class="btn btn-primary" id="btnSearch" name="btnSearch">
                                <i class="icon-search  bigger-110"></i>
                                ค้นหา
                       
                            </button>
                            <button class="btn" type="reset" id="btnClear" name="btnClear">
                                <i class="icon-undo bigger-110"></i>
                                ล้างข้อมูล
                            </button>
                        </div>
                    </div>
                                  <div class="space-2"></div>
                    <div class="row-fluid" id="divNotFound" style="display: none">
                        <div class="span2">
                        </div>
                        <div class="span10">
                           <strong class="color red">ไม่พบข้อมูล</strong>
                   <%--         <label class="control-label " for="lblNotFound"></label>--%>
                        </div>
                    </div>
                    <div class="hr hr10"></div>
                    <div class="row-fluid" id="divExport" style="display:none">
                        <div class="span10">
                        </div>
                        <div class="span2">
                            <div class="pull-right">
                                <button class="btn btn-danger" id="btnExport" name="btnExport">
                                    <i class=" icon-print  bigger-110"></i>
                                    Export
                                </button>

                            </div>


                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="row-fluid">
                        <div class="span12">

                            <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                        </div>
                    </div>


                </div>

            </div>
            <!--/.span-->
        </div>
        <!--/.row-fluid-->

        <!--/.page-content-->



        <%--    <div class="ace-settings-container" id="ace-settings-container">
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
        </div>--%>
        <!--/#ace-settings-container-->
    </div>

    <script type="text/javascript">
        //Open page
        $(document).ready(function () {
            localStorage['PagepostBack'] = 'true';
            //populate compobox 
            populateSelect();
            //Load data
            var oTable;
            LoadData(0);
            //ปฎิธิน
            $('.date-picker').datepicker({ "autoclose": true }).next().on(ace.click_event, function () {
                $(this).prev().focus();
            });


            $("#btnSearch").click(function () {
                localStorage['PagepostBack'] = 'false';             
                var checkvalid = onValid();
                if (checkvalid == true) {
                    LoadData(1);
                }

            });

            $("#btnClear").click(function () {
                localStorage['PagepostBack'] = 'true';
                clearinput();
                LoadData(0);
            });

            $("#btnExport").click(function () {
                populateExport();
            });

            //Autocomplete Name - Surname
            $("#txtUserName").autocomplete({
                //   source: data,
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "WebService/WebService.asmx/LoadUserByName2",
                        data: "{ 'name': '" + request.term + "' }",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            var jsonobject = JSON.parse(data.d);
                            response(jsonobject);
                        }
                    });
                },
                select: function (event, ui) {
                    $("#txtUserName").val(ui.item.label);
                    $("#txtUserId").val(ui.item.label);
                    //  $( "#search" ).val( ui.item.label + " / " + ui.item.actor );
                    return false;
                }
            });


        });



        //Call


        function LoadData(isshow) {

            var app_no = $("#txtApp_no").val();
            var datefrom = $("#txtDateFrom").val();
            var dateto = $("#txtDateTo").val();
            var borrowername = $("#txtUserName").val();
            var statusname = $("#cbStatus").val();
            var patenttypeid = $("#cbPatentType").val();

            var param = "{'app_no':" + JSON.stringify(app_no)
                        + ",'datefrom':" + JSON.stringify(datefrom)
                        + ",'dateto':" + JSON.stringify(dateto)
                        + ",'borrowername':" + JSON.stringify(borrowername)
                        + ",'statusname':" + JSON.stringify(statusname)
                        + ",'patenttypeid':" + JSON.stringify(patenttypeid)
                        + ",'isshow':" + JSON.stringify(isshow)
                        + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadSearchFileLocation",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: PopulateGrid,
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });

        }

        //Populate Grid
        function PopulateGrid(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [{
                "sTitle": "ลำดับ",
                "sType": "numeric",
                "mDataProp": "no",
                "bUseRendered": false

            },
                            {
                                "sTitle": "วันที่-เวลา",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "move_date"
                            },
                            {
                                "sTitle": "เลขที่คำขอ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "app_no"
                            } ,
                            {
                                "sTitle": "ประเภทคำขอ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "patent_type_name"
                            } ,
                            {
                                "sTitle": "สถานะ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "status_name"
                            }
                            ,
                            {
                                "sTitle": "ผู้ยืม",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "borrowname"

                            },
                            {
                                "sTitle": "เส้นทาง",
                                "sType": "string",
                                "fnRender": function (obj) {                                 
                                    //var str = "background-color:#FFFFFF";
                                    //if (obj.aData.ms_floor_id == '0') {
                                    //    str = "background-color:#FFFFFF";
                                    //} else if (obj.aData.ms_floor_id == '1') {
                                    //    str = "background-color:#D1D0CE";
                                    //} else if (obj.aData.ms_floor_id == '2') {
                                    //    str = "background-color:#667C26";
                                    //} else if (obj.aData.ms_floor_id == '3') {
                                    //    str = "background-color:#254117";
                                    //} else if (obj.aData.ms_floor_id == '4') {
                                    //    str = "background-color:#B2C248";
                                    //} else if (obj.aData.ms_floor_id == '5') {
                                    //    str = "background-color:#F2BB66";
                                    //} else if (obj.aData.ms_floor_id == '6') {
                                    //    str = "background-color:#E238EC";
                                    //} else if (obj.aData.ms_floor_id == '7') {
                                    //    str = "background-color:#C9BE62";
                                    //} else if (obj.aData.ms_floor_id == '8') {
                                    //    str = "background-color:#D4A017";
                                    //} else if (obj.aData.ms_floor_id == '9') {
                                    //    str = "background-color:#786D5F";
                                    //} else if (obj.aData.ms_floor_id == '10') {
                                    //    str = "background-color:#6F4E37";
                                    //} else if (obj.aData.ms_floor_id == '11') {
                                    //    str = "background-color:#6F4E37";
                                    //} else if (obj.aData.ms_floor_id == '12') {
                                    //    str = "background-color:#98AFC7";
                                    //} else if (obj.aData.ms_floor_id == '13') {
                                    //    str = "background-color:#893BFF";
                                    //} else if (obj.aData.ms_floor_id == '14') {
                                    //    str = "background-color:#FFFFC2";
                                    //} else if (obj.aData.ms_floor_id == '15') {
                                    //    str = "background-color:#FFDB58";
                                    //} else { str = "background-color:#FFDB58"; }

                                    return '<div style="width:100%; height:40px; background-color:' + obj.aData.color + '">' + obj.aData.location_name + '</div>'
                                    ;
                                },
                                "sDefaultContent": "",
                                "mDataProp": "location_name"

                            }


            ];
            
            oTable = $('#dt_out').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "7%", "aTargets": [0] },
                { "sWidth": "12%", "aTargets": [1] },
                { "sWidth": "13%", "aTargets": [2] },
                { "sWidth": "15%", "aTargets": [3] },
                { "sWidth": "15%", "aTargets": [4] },
                { "sWidth": "15%", "aTargets": [5] },
                { "sWidth": "23%", "aTargets": [6] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
                "bFilter": false

            });

            
            if (localStorage['PagepostBack'] == 'false') {
                var oTablecheck = $('#dt_out').dataTable();
                // Get the length
                if (oTablecheck.fnGetData().length == 0) {
                    $("#divExport").hide();
                    $("#divNotFound").show();
                } else {
                    $("#divExport").show();
                    $("#divNotFound").hide();
                }
            } else {
                $("#divExport").hide();
                $("#divNotFound").hide();
            }
   


        }

        //Hide Valid
        function onValidHide() {
            $("#lblvalidtxtApp_no").hide();
        }
        //Check Valid
        function onValid() {
            var isValid;
            isValid = true;
            var app_no = $('#txtApp_no').val();
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
            $("#txtApp_no").val("");
            $("#txtDateFrom").val("");
            $("#txtDateTo").val("");
            $("#txtUserName").val("");
            $("#txtUserId").val("");
            $("#lblvalidtxtApp_no").hide();
            $("#divNotFound").hide();
            $("#divExport").hide();
        }

        function populateExport() {
            var app_no = $("#txtApp_no").val();
            var datefrom = $("#txtDateFrom").val();
            var dateto = $("#txtDateTo").val();
            var borrowername = $("#txtUserName").val();
            var statusname = $("#cbStatus").val();
            var patenttypeid = $("#cbPatentType").val();

            var para = '?app_no=' + app_no + '&datefrom=' + datefrom + '&dateto=' + dateto + '&borrowername=' + encodeURIComponent(borrowername) + '&statusname=' + encodeURIComponent(statusname) + '&patenttypeid=' + patenttypeid + '&isshow=1';
            var dataurl = 'frmSearchFileLocation_Report.ashx' + para;
            window.location.href = dataurl;
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

        function populateSelect() {
            $selectStatus = $("#cbStatus");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadActiveStatus',
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectStatus.html('');
                    $selectStatus.append('<option value="">กรุณาเลือก สถานะ</option>');
                    //append a select Location
                    $.each(jsonobject, function (key, val) {
                        $selectStatus.append('<option value="' + val.status_name + '">' + val.status_name + '</option>');
                        $selectStatus.trigger("liszt:updated");//update select option
                    })
                }
            });


            $selectPatentType = $("#cbPatentType");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadActivePatent',
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectPatentType.html('');
                    $selectPatentType.append('<option value="">กรุณาเลือก ประเภทแฟ้ม</option>');
                    //append a select option
                    $.each(jsonobject, function (key, val) {
                        $selectPatentType.append('<option value="' + val.id + '">' + val.patent_type_name + '</option>');
                        $selectPatentType.trigger("liszt:updated");//update select option
                    })
                }
            });

            //Combo Box  
            $(".chzn-select").chosen();

        }

    </script>
</asp:Content>

