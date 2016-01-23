<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmSearchAmountFileByLocation.aspx.vb" Inherits="frmSearchAmountFileByLocation" %>

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
                <li class="active">จำนวนแฟ้มแยกตามพื้นที่</li>
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
                    <h3 class="header smaller lighter blue">จำนวนแฟ้มแยกตามพื้นที่</h3>
                    <div class="row-fluid">
                        <div class="span2">
                            <label class="control-label" for="lblLocation">พื้นที่ :</label>

                        </div>
                        <div class="span10">
                            <select class="chzn-select" id="cbLocation" data-placeholder="กรุณาเลือก พื้นที่..."></select>
                            <span class="help-inline color red" id="lblvalidms_room_type_id" style="display: none">กรุณาเลือก</span>
                        </div>


                    </div>
                    <div class="space-4"></div>
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
               // populateExport();
                localStorage['PagepostBack'] = 'true';
                clearinput();
                LoadData(0);
            });

            $("#btnExport").click(function () {
                populateExport();
            });

        });



        //Call
        function LoadData(isshow) {

            var floor_id = $("#cbLocation").val();
            var patent_type_id = $("#cbPatentType").val();

            var param = "{'floor_id':" + JSON.stringify(floor_id)
                        + ",'patent_type_id':" + JSON.stringify(patent_type_id)
                        + ",'isshow':" + JSON.stringify(isshow)
                        + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadSearchAmountFileByLocation",
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
                                "sTitle": "พื้นที่",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "floor_name"
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
            populateSelect();
            $("#divNotFound").hide();
            $("#divExport").hide();
        }

        function populateExport() {
            var floor_id = $("#cbLocation").val();
            var patent_type_id = $("#cbPatentType").val();
            var para = '?floor_id=' + floor_id + '&patent_type_id=' + patent_type_id  + '&isshow=1';
            var dataurl = 'frmSearchAmountFileByLocation_Report.ashx' + para;
            window.location.href = dataurl;
        }

        function populateSelect() {
            $selectLocation = $("#cbLocation");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadActiveFloor',
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectLocation.html('');
                    $selectLocation.append('<option value="">กรุณาเลือก พื้นที่</option>');
                    //append a select Location
                    $.each(jsonobject, function (key, val) {
                        $selectLocation.append('<option value="' + val.id + '">' + val.floor_name + '</option>');
                        $selectLocation.trigger("liszt:updated");//update select option
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

