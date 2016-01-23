<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage2.master" AutoEventWireup="false" CodeFile="frmPortal.aspx.vb" Inherits="frmPortal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content">
        <div class="breadcrumbs" id="breadcrumbs">
            <ul class="breadcrumb">
                <li>
                    <i class="icon-home home-icon"></i>
                    <a href="frmPortal.aspx">Home</a>


                </li>

            </ul>
        </div>
        <div class="page-content">
            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">รายการแจ้งเตือน</h3>
                </div>

                <div class="tabbable">
                    <ul class="nav nav-tabs" id="myTab">
                        <li class="active">
                            <a data-toggle="tab" href="#home" id="tabborrow">
                                <i class="blue icon-list bigger-110"></i>
                                รายการยืม
                            </a>
                        </li>

                        <li>
                            <a data-toggle="tab" href="#profile" id="tabreserve">
                                <i class="blue icon-list bigger-110"></i>
                                รายการจอง
													
                            </a>
                        </li>
                         <li>
                            <a data-toggle="tab" href="#new" id="tabnew">
                                <i class="blue icon-list bigger-110"></i>
                                แฟ้มใหม่รอเข้าชั้น 6			
                            </a>
                        </li>
                        <li>
                            <a data-toggle="tab" href="#5year" id="tab5year">
                                <i class="blue icon-list bigger-110"></i>
                                แฟ้มชั้น 6 รอเข้าชั้น 1		
                            </a>
                        </li>

                        
                        <li>
                            <a data-toggle="tab" href="#publicBeforeMove" id="tabpublicBeforeMove">
                                <i class="blue icon-list bigger-110"></i>
                                แฟ้มชั้น 6 รอย้ายไปทรัพย์ศรีไทย		
                            </a>
                        </li>
                        
                        <li>
                            <a data-toggle="tab" href="#20year" id="tab20year">
                                <i class="blue icon-list bigger-110"></i>
                                แฟ้มชั้น 1 รอย้ายไปทรัพย์ศรีไทย
                            </a>
                        </li>
                        <li>
                            <a data-toggle="tab" href="#newBeforeMove" id="tabnewBeforeMove">
                                <i class="blue icon-list bigger-110"></i>
                                แฟ้มใหม่รอย้ายไปทรัพย์ศรีไทย			
                            </a>
                        </li>
                    </ul>


                    <div class="tab-content">
                        <div id="home" class="tab-pane in active">

                            <div class="row-fluid">
                                <div class="span12">
                                    <table class="table table-striped table-bordered table-hover" id="dt_out2"></table>
                                </div>
                            </div>

                        </div>

                        <div id="profile" class="tab-pane">
                            <div class="row-fluid">
                                <div class="span12">
                                    <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                                </div>
                            </div>

                        </div>
                        <div id="new" class="tab-pane">
                            <div class="row-fluid">
                                <div class="span12">
                                    แฟ้มที่เกิดใหม่ และรอเก็บเข้าห้องแฟ้มชั้น 6
                                    <table class="table table-striped table-bordered table-hover" id="dt_new"></table>
                                </div>
                            </div>

                        </div>
                        <div id="5year" class="tab-pane">
                            <div class="row-fluid">
                                <div class="span12">
                                    แฟ้มสิทธิบัตรการประดิษฐ์ที่อายุครบ 5 ปี และยังเก็บอยู่ที่ชั้น 6  รอจัดเก็บที่ห้องแฟ้มชั้น 1
                                    <table class="table table-striped table-bordered table-hover" id="dt_5year"></table>
                                </div>
                            </div>
                        </div>

                        <div id="publicBeforeMove" class="tab-pane">
                            <div class="row-fluid">
                                <div class="span12">
                                    แฟ้มที่ละทิ้งและสิ้นอายุ และยังเก็บอยู่ที่ชั้น 6  รอการเคลื่อนย้ายไปเก็บที่ทรัพย์ศรีไทย
                                    <table class="table table-striped table-bordered table-hover" id="dt_PubBMove"></table>
                                </div>
                            </div>
                        </div>
                        
                        <div id="20year" class="tab-pane">
                            <div class="row-fluid">
                                <div class="span12">
                                    แฟ้มที่ละทิ้งและสิ้นอายุ และยังเก็บอยู่ที่ชั้น 1 รอการเคลื่อนย้ายไปเก็บที่ทรัพย์ศรีไทย
                                    <table class="table table-striped table-bordered table-hover" id="dt_10year"></table>
                                </div>
                            </div>
                        </div>

                        <div id="newBeforeMove" class="tab-pane">
                            <div class="row-fluid">
                                <div class="span12">
                                    แฟ้มเกิดใหม่ที่ละทิ้ง รอการเคลื่อนย้ายไปเก็บที่ทรัพย์ศรีไทย
                                    <table class="table table-striped table-bordered table-hover" id="dt_newBMove"></table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <script type="text/javascript">
            //Open page
            $(document).ready(function () {
                //Load Data
                var oTable;
                //  LoadDataReserve();
                LoadDataBorrow();

                //
                $("#tabreserve").click(function () {
                    LoadDataReserve();
                });

                $("#tabborrow").click(function () {
                    LoadDataBorrow();
                });

                $("#tabnew").click(function () {
                    LoadDataNew();
                });

                $("#tab5year").click(function () {
                    LoadData5year();
                });

                $("#tabpublicBeforeMove").click(function () {
                    LoadDataPublicBMove();
                });

                $("#tab20year").click(function () {
                    LoadData10year();
                });

                $("#tabnewBeforeMove").click(function () {
                    LoadDataNewBMove();
                });


                HideTab();
            });

            function HideTab() {
                var FloorID = $('#' + '<%=Master.FindControl("lblFloorID").ClientID%>').text();
                if (FloorID == 4) {
                    $("#tab5year").show();
                    $("#tab20year").show();
                    $("#tabnew").show();
                    $("#tabpublicBeforeMove").show();
                    $("#tabnewBeforeMove").show();
                } else {
                    $("#tab5year").hide();
                    $("#tab20year").hide();
                    $("#tabnew").hide();
                    $("#tabpublicBeforeMove").hide();
                    $("#tabnewBeforeMove").hide();
                }

            }

            //Call
            function LoadDataReserve() {
                var memberid = $('#' + '<%=Master.FindControl("lblUserID").ClientID%>').text();
            var param = "{'memberid':" + JSON.stringify(memberid) + "}";
            var dataurl = 'WebService/WebService.asmx/LoadPortalReserve';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": PopulateGridReserve
            });
        }

        //Populate Grid
        function PopulateGridReserve(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [{
                "sTitle": "ลำดับ",
                "sType": "numeric",
                "mDataProp": "no",
                "bSortable": false,
                "bUseRendered": false

            },
                            {
                                "sTitle": "เลขที่คำขอ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "app_no"

                            },
                            {
                                "sTitle": "วันที่จอง",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "reserve_date"

                            },
                            {
                                "sTitle": "ประเภทแฟ้ม",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "patent_type_name"

                            },
                            {
                                "sTitle": "สถานะ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "reserve_status"

                            }
            ];

            oTable = $('#dt_out').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "20%", "aTargets": [1] },
                { "sWidth": "20%", "aTargets": [2] },
                { "sWidth": "30%", "aTargets": [3] },
                { "sWidth": "10%", "aTargets": [4] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }

        function LoadDataBorrow() {
            var memberid = $('#' + '<%=Master.FindControl("lblUserID").ClientID%>').text();
            var param = "{'memberid':" + JSON.stringify(memberid) + "}";
            var dataurl = 'WebService/WebService.asmx/LoadPortalBorrow';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": PopulateGridBorrow
            });
        }

        //Populate Grid
        function PopulateGridBorrow(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [{
                "sTitle": "ลำดับ",
                "sType": "numeric",
                "mDataProp": "no",
                "bSortable": false,
                "bUseRendered": false

            },
                            {
                                "sTitle": "เลขที่คำขอ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "app_no"

                            },
                            {
                                "sTitle": "วันที่ยืม",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "borrowdate"

                            },
                            {
                                "sTitle": "วันที่รับ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "receive_date"

                            },
                            {
                                "sTitle": "ระยะเวลาที่ยืม",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "strduration"

                            }
            ];

            oTable = $('#dt_out2').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "20%", "aTargets": [1] },
                { "sWidth": "20%", "aTargets": [2] },
                { "sWidth": "20%", "aTargets": [3] },
                { "sWidth": "30%", "aTargets": [4] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }


        function LoadDataNew() {
            var memberid = $('#' + '<%=Master.FindControl("lblUserID").ClientID%>').text();
            var dataurl = 'WebService/WebService.asmx/LoadPortalNew';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": PopulateGridNew
            });
        }

        //Populate Grid
            function PopulateGridNew(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [{
                "sTitle": "ลำดับ",
                "sType": "numeric",
                "mDataProp": "no",
                "bSortable": false,
                "bUseRendered": false

            },
                            {
                                "sTitle": "เลขที่คำขอ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "app_no"

                            },
                            {
                                "sTitle": "วันที่รับ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "receive_date"

                            },
                            {
                                "sTitle": "สถานะ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "status_name"

                            }
            ];

            oTable = $('#dt_new').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "iDisplayLength": 100,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "30%", "aTargets": [1] },
                { "sWidth": "30%", "aTargets": [2] },
                { "sWidth": "30%", "aTargets": [3] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }


            function LoadDataPublicBMove() {
                var memberid = $('#' + '<%=Master.FindControl("lblUserID").ClientID%>').text();
                var dataurl = 'WebService/WebService.asmx/LoadPortalPublicBMove';
                $.ajax({
                    "type": "POST",
                    "dataType": 'json',
                    "contentType": "application/json; charset=utf-8",
                    "url": dataurl,
                    "success": PopulateGridPublicBMove
                });
            }

            function PopulateGridPublicBMove(jsondata) {
                var jsonobject = JSON.parse(jsondata.d);
                var columns = [{
                    "sTitle": "ลำดับ",
                    "sType": "numeric",
                    "mDataProp": "no",
                    "bSortable": false,
                    "bUseRendered": false

                },
                                {
                                    "sTitle": "เลขที่คำขอ",
                                    "sType": "string",
                                    "sDefaultContent": "",
                                    "mDataProp": "app_no"

                                },
                                {
                                    "sTitle": "วันที่รับ",
                                    "sType": "string",
                                    "sDefaultContent": "",
                                    "mDataProp": "receive_date"

                                },
                                {
                                    "sTitle": "สถานะ",
                                    "sType": "string",
                                    "sDefaultContent": "",
                                    "mDataProp": "status_name"
                                }
                ];

                oTable = $('#dt_PubBMove').dataTable({
                    "aaData": jsonobject,
                    "bAutoWidth": false,
                    "iDisplayLength": 100,
                    "aoColumnDefs": [
                    { "sWidth": "10%", "aTargets": [0] },
                    { "sWidth": "30%", "aTargets": [1] },
                    { "sWidth": "30%", "aTargets": [2] },
                    { "sWidth": "30%", "aTargets": [3] }
                    ],
                    "aoColumns": columns,
                    "bDestroy": true,
                });
            }


        function LoadData5year() {
            var memberid = $('#' + '<%=Master.FindControl("lblUserID").ClientID%>').text();
            var dataurl = 'WebService/WebService.asmx/LoadPortal5year';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": PopulateGrid5year
            });
        }

        //Populate Grid
        function PopulateGrid5year(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [{
                "sTitle": "ลำดับ",
                "sType": "numeric",
                "mDataProp": "no",
                "bSortable": false,
                "bUseRendered": false

            },
                            {
                                "sTitle": "เลขที่คำขอ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "app_no"

                            },
                            {
                                "sTitle": "วันที่รับ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "receive_date"

                            },
                            {
                                "sTitle": "สถานะ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "status_name"

                            }
            ];

            oTable = $('#dt_5year').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "iDisplayLength": 100,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "30%", "aTargets": [1] },
                { "sWidth": "30%", "aTargets": [2] },
                { "sWidth": "30%", "aTargets": [3] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });
        }

            //Populate Grid
        function LoadData10year() {
            var memberid = $('#' + '<%=Master.FindControl("lblUserID").ClientID%>').text();
            var dataurl = 'WebService/WebService.asmx/LoadPortal10year';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": PopulateGrid10year
            });
        }
        function PopulateGrid10year(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [{
                "sTitle": "ลำดับ",
                "sType": "numeric",
                "mDataProp": "no",
                "bSortable": false,
                "bUseRendered": false
            },
                            {
                                "sTitle": "เลขที่คำขอ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "app_no"

                            },
                            {
                                "sTitle": "วันที่รับ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "receive_date"

                            },
                            {
                                "sTitle": "สถานะ",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "status_name"

                            }
            ];

            oTable = $('#dt_10year').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "iDisplayLength": 100,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "30%", "aTargets": [1] },
                { "sWidth": "30%", "aTargets": [2] },
                { "sWidth": "30%", "aTargets": [3] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }


        function LoadDataNewBMove() {
            var memberid = $('#' + '<%=Master.FindControl("lblUserID").ClientID%>').text();
            var dataurl = 'WebService/WebService.asmx/LoadPortalNewBMove';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": PopulateGridNewBMove
            });
        }

            function PopulateGridNewBMove(jsondata) {
                var jsonobject = JSON.parse(jsondata.d);
                var columns = [{
                    "sTitle": "ลำดับ",
                    "sType": "numeric",
                    "mDataProp": "no",
                    "bSortable": false,
                    "bUseRendered": false
                },
                    {
                        "sTitle": "เลขที่คำขอ",
                        "sType": "string",
                        "sDefaultContent": "",
                        "mDataProp": "app_no"

                    },
                    {
                        "sTitle": "วันที่รับ",
                        "sType": "string",
                        "sDefaultContent": "",
                        "mDataProp": "receive_date"

                    },
                    {
                        "sTitle": "สถานะ",
                        "sType": "string",
                        "sDefaultContent": "",
                        "mDataProp": "status_name"

                    }
                ];

                oTable = $('#dt_newBMove').dataTable({
                    "aaData": jsonobject,
                    "bAutoWidth": false,
                    "iDisplayLength": 100,
                    "aoColumnDefs": [
                    { "sWidth": "10%", "aTargets": [0] },
                    { "sWidth": "30%", "aTargets": [1] },
                    { "sWidth": "30%", "aTargets": [2] },
                    { "sWidth": "30%", "aTargets": [3] }
                    ],
                    "aoColumns": columns,
                    "bDestroy": true,
                });


            }



        </script>
</asp:Content>

