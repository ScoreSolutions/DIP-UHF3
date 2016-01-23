<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmSearchAmountFileByUser.aspx.vb" Inherits="frmSearchAmountFileByUser" %>

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
                <li class="active">จำนวนแฟ้มแยกตามชื่อผู้ครอบครอง</li>
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
                    <h3 class="header smaller lighter blue">จำนวนแฟ้มแยกตามชื่อผู้ครอบครอง</h3>
                    <div class="row-fluid">
                        <div class="span2">
                            <label class="control-label" for="lblDepartment">หน่วยงาน :</label>

                        </div>
                        <div class="span10">
                            <select class="chzn-select" id="cbDepartment" data-placeholder="กรุณาเลือก หน่วยงาน..."></select>
                            <span class="help-inline color red" id="lblvalidms_room_type_id" style="display: none">กรุณาเลือก</span>
                        </div>


                    </div>
                    <div class="space-4"></div>
                    <div class="row-fluid">
                        <div class="span2">
                                <label class="control-label">ผู้ยืมครอบครอง :</label>
                          
                        </div>
                        <div class="span10">
                            <input type="text" id="txtUserName" style="width: 205px" placeholder="พิมพ์และเลือก.....">
                            <%--         <span id="linkroomdetail" class="help-button" data-placement="left">
                                   <i class=" icon-warning-sign"></i>
                               </span>--%>
                            <input type="text" id="txtDepartment_Id" style="width: 205px; display: none;" placeholder="Id">
                        </div>
                    </div>
                    
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

            //Autocomplete Name - Surname
            $("#txtUserName").autocomplete({
                //   source: data,
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "WebService/WebService.asmx/LoadUserByDepartment",
                        data: "{ 'name': '" + request.term + "','department_id': '" + $("#cbDepartment").val() + "' }",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            var jsonobject = JSON.parse(data.d);
                            response(jsonobject);
                        }
                    });
                },
                select: function (event, ui) {
                    $("#txtUserName").val(ui.item.fullname);
                    $("#txtDepartment_Id").val(ui.item.department_id);
                    //  $( "#search" ).val( ui.item.label + " / " + ui.item.actor )
                    populateSelectDepartmentById(ui.item.department_id);
                    return false;
                }
            });


        });



        //Call
        function LoadData(isshow) {
            var username = $("#txtUserName").val();
            var department_id = $("#cbDepartment").val();
            var patent_type_id = $("#cbPatentType").val();

            var param = "{'department_id':" + JSON.stringify(department_id)
                        + ",'username':" + JSON.stringify(username)
                        + ",'patent_type_id':" + JSON.stringify(patent_type_id)
                        + ",'isshow':" + JSON.stringify(isshow)
                        + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadSearchAmountFileByDepartment",
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
                                "sTitle": "ผู้ครอบครอง",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "officer_name"
                            },
                            {
                                "sTitle": "หน่วยงาน",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "department_name"

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
                { "sWidth": "20%", "aTargets": [1] },
                { "sWidth": "30%", "aTargets": [2] },
                { "sWidth": "20%", "aTargets": [3] },
                { "sWidth": "20%", "aTargets": [4] }
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
            $("#txtUserName").val("");
            $("#txtDepartment_Id").val("");
            $("#divNotFound").hide();
            $("#divExport").hide();
        }

        function populateExport() {
            var department_id = $("#cbDepartment").val();
            var username = $("#txtUserName").val();
            var patent_type_id = $("#cbPatentType").val();
            var para = '?department_id=' + department_id + '&username=' + username + '&patent_type_id=' + patent_type_id + '&isshow=1';
            var dataurl = 'frmSearchAmountFileByUser_Report.ashx' + para;
            window.location.href = dataurl;
        }

        function populateSelect() {
            $selectDepartment = $("#cbDepartment");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadActiveDepartment',
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectDepartment.html('');
                    $selectDepartment.append('<option value="">กรุณาเลือก หน่วยงาน</option>');
                    //append a select Department
                    $.each(jsonobject, function (key, val) {
                        $selectDepartment.append('<option value="' + val.id + '">' + val.department_name + '</option>');
                        $selectDepartment.trigger("liszt:updated");//update select option
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

        function populateSelectDepartmentById(department_id) {
            var strselect;
            $selectDepartment = $("#cbDepartment");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadActiveDepartment',
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectDepartment.html('');
                    $selectDepartment.append('<option value="">กรุณาเลือก หน่วยงาน</option>');
                    //append a select Department
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (val.id == department_id) {
                            strselect = ' selected="selected"';
                        }
                        $selectDepartment.append('<option value="' + val.id + '" ' + strselect + '>' + val.department_name + '</option>');
                        $selectDepartment.trigger("liszt:updated");//update select option
                    })
                }
            });

            //Combo Box  
            $(".chzn-select").chosen();

        }

    </script>
</asp:Content>

