<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmPortal.aspx.vb" Inherits="frmPortal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                <h3 class="header smaller lighter blue">รายการยืมและจอง</h3>
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

                                    </ul>

                
                                    <div class="tab-content">
                                            <div id="home" class="tab-pane in active">

                                            <div class="row-fluid" >
                                                <div class="span12">
                                       <table class="table table-striped table-bordered table-hover" id="dt_out2"></table>
                                                </div>
                                            </div>
                                     
                                        </div>

                                        <div id="profile" class="tab-pane">
                                       <div class="row-fluid" >
                                                <div class="span12">
                                       <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                 </div>
            
              <%--      <div class="row-fluid">
                        <div class="span12">
                            <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                        </div>
                    </div>

                     <div class="row-fluid">
            <div class="span12">
                <!--PAGE CONTENT BEGINS-->
                <h4 class="header smaller lighter blue">รายการยืม</h4>
            </div>
        </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <table class="table table-striped table-bordered table-hover" id="dt_out2"></table>
                        </div>
                    </div>--%>

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

          

        });

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
                                "sTitle": "ประเภทแฟ้ม",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "patent_type_name"

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
        
    </script>
</asp:Content>

