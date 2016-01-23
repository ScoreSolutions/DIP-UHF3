<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmSearchAmountFileByDuration.aspx.vb" Inherits="frmSearchAmountFileByDuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--cutomize styles-->
    <%--    <style>
        td.right {
        text-align: right;
            }
    </style>--%>
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
                <li class="active">จำนวนแฟ้มแยกตามระยะเวลาการครอบครอง</li>
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
                    <h3 class="header smaller lighter blue">จำนวนแฟ้มแยกตามระยะเวลาการครอบครอง</h3>
                    <div class="row-fluid">
                        <div class="span2">
                            <label class="control-label" for="lblDuration">ระยะเวลา :</label>

                        </div>
                        <div class="span10">
                            <div class="span2">
                                <select class="chzn-select " id="cbCondition" style="width:130px" >
                                   <%-- <option value="<">น้อยกว่า</option>
                                    <option value="<=">น้อยกว่าเท่ากับ</option>
                                    <option value="=">เท่ากับ</option>
                                    <option value=">=">มากกว่าเท่ากับ</option>
                                    <option value=">">มากกว่า</option>--%>
                                </select>
                            </div>
                            <div class="span1">
                                <input type="text" id="txtDay"  onkeypress="return Numbers(event);" onchange="CheckLength();" style="width:50px"  value="1"  />
                            </div>
                            <div class="span7">
                                <select class="chzn-select" id="cbTime" style="width:100px"  >
<%--                                    <option value="วัน">วัน</option>
                                    <option value="เดือน">เดือน</option>
                                    <option value="ปี">ปี</option>--%>
                                </select>
                            </div>


                          
                        </div>



                    </div>
                    <div class="space-2"></div>
                    <div class="row-fluid">
                        <div class="span2">
                            <label class="control-label" for="lblPatentType">ประเภทแฟ้ม :</label>
                        </div>
                        <div class="span10">
                            <select class="chzn-select" id="cbPatentType" data-placeholder="กรุณาเลือก ประเภทแฟ้ม...">
                            </select>
                            <span class="help-inline color red" id="lblvalidms_PatentType_id" style="display: none">กรุณาเลือก</span>
                        </div>

                    </div>
                    <div class="space-4"></div>
                    <div class="row-fluid">
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

                    <div class="row-fluid" id="divExport" style="display: none">
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


            $("#btnSearch").click(function () {
                localStorage['PagepostBack'] = 'false';
                LoadData(1);
            });

            $("#btnClear").click(function () {
                localStorage['PagepostBack'] = 'true';
                clearinput();
                LoadData(0);
            });

            $("#btnExport").click(function () {
                populateExport();
            });

            //Spinner
           // $('#txtDay').ace_spinner({ value: 1, min: 1, max: 10000, step: 1, icon_up: 'icon-caret-up', icon_down: 'icon-caret-down' });

        });



        //Call
        function LoadData(isshow) {
            var day = $("#txtDay").val();
            var condition = $("#cbCondition").val();
            var time = $("#cbTime").val();
            var patent_type_id = $("#cbPatentType").val();

            var param = "{'condition':" + JSON.stringify(condition)
                        + ",'day':" + JSON.stringify(day)
                        + ",'time':" + JSON.stringify(time)
                        + ",'patent_type_id':" + JSON.stringify(patent_type_id)
                        + ",'isshow':" + JSON.stringify(isshow)
                        + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadSearchAmountFileByDuration",
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
                                "sTitle": "ระยะเวลา",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "duration"
                            },
                            {
                                "sTitle": "ประเภทแฟ้ม",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "patent_type_name"

                            }
                            ,
                            {
                                "sTitle": "จำนวนแฟ้ม",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "amountfile",
                                "sClass": "right"
                            }


            ];

            oTable = $('#dt_out').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "35%", "aTargets": [1] },
                { "sWidth": "35%", "aTargets": [2] },
                { "sWidth": "20%", "aTargets": [3] }
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




        //clear control
        function clearinput() {
            $("#txtDay").val(1);
            $("#cbCondition").val("");
            $("#cbTime").val("วัน");
            populateSelect();
            $("#divNotFound").hide();
            $("#divExport").hide();
        }

        function populateExport() {
            var day = $("#txtDay").val();
            var condition = $("#cbCondition").val();
            var time = $("#cbTime").val();
            var patent_type_id = $("#cbPatentType").val();

            var para = '?condition=' + condition + '&day=' + day + '&time=' + time + '&patent_type_id=' + patent_type_id + '&isshow=1';
            var dataurl = 'frmSearchAmountFileByDuration_Report.ashx' + para;
            window.location.href = dataurl;
        }

        function populateSelect() {
            $selectCondition = $("#cbCondition");
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadConditionCompare",
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectCondition.html('');
                    //append a select Location
                    $.each(jsonobject, function (key, val) {
                        $selectCondition.append('<option value="' + val.id + '">' + val.name + '</option>');
                        $selectCondition.trigger("liszt:updated");//update select option
                    })
                }  ,
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });

            $selectTime = $("#cbTime");
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadConditionTime",
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectTime.html('');
                    //append a select Location
                    $.each(jsonobject, function (key, val) {
                        $selectTime.append('<option value="' + val.id + '">' + val.name + '</option>');
                        $selectTime.trigger("liszt:updated");//update select option
                    })
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
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
        //Check Number
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

            // 
      
            return numcheck.test(keychar);
       }

        function CheckLength() {
            if ($("#txtDay").val() != "") {

                var checkvalue = $.isNumeric($("#txtDay").val());
                if (checkvalue == true) {
                    if ($("#txtDay").val() == 0) {
                        $("#txtDay").val(1);
                    }

                }
            } else {
                $("#txtDay").val(1);
            }

        }

    </script>
</asp:Content>

