<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmFileLost.aspx.vb" Inherits="frmFileLost" %>

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
                <li class="active">File Lost</li>
            </ul>

            <!--#nav-search-->
        </div>

        <div class="page-content">


            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">File Lost</h3>

                    <form class="form-inline" />
                    <div class="row-fluid">
                        <div class="span1">
                            <label class="control-label">App No :</label>

                        </div>
                        <div class="span11">
                            <input type="text" id="txtApp_no" style="width: 205px" placeholder="Input and select.....">
                            <span class="help-inline color red" id="lblvalid_app0" style="display: none">This field is required</span>
                            <%--         <span id="linkroomdetail" class="help-button" data-placement="left">
                                   <i class=" icon-warning-sign"></i>
                               </span>--%>
                            <button id="btnSave"  class="btn btn-info btn-small">
                                <i class="icon-save bigger-110"></i>
                                Save
                            </button>
                        </div>
                    </div>


                    </form>

           
                       <div class="space-2"></div>
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

        <!--/#ace-settings-container-->

    </div>


    <script type="text/javascript">
        //Open page
        $(document).ready(function () {

            var oTable;
            LoadData();

            $("#btnSave").click(function () {
                onSave();; return false;
            });

            //Autocomplete Name - Surname
            $("#txtApp_no").autocomplete({
                //   source: data,
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "WebService/WebService.asmx/LoadFileByAppNo",
                        data: "{ 'appno': '" + request.term + "' }",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            var jsonobject = JSON.parse(data.d);
                            response(jsonobject);
                        }
                    });
                },
                select: function (event, ui) {
                    $("#txtApp_no").val(ui.item.app_no);
                    return false;
                }
            });

        });



        //Call
        function LoadData() {
            var dataurl = 'WebService/WebService.asmx/LoadFileLost';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": PopulateGrid
            });
        }

        //Populate Grid
        function PopulateGrid(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [{
                "sTitle": "No",
                "sType": "numeric",
                "mDataProp": "no",
                "bSortable": false,
                "bUseRendered": false

            },
                            {
                                "sTitle": "App No",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "app_no"

                            },


                            {
                                "sTitle": "Action",
                                "bSortable": false,
                                "fnRender": function (obj) {

                                    // var IsDelete = obj.aData.IsDelete;
                                    var str = "";
                                    // if (IsDelete == "T") {
                                    //     str = " style='display:none;'"
                                    // }

                                    return '<div class="hidden-phone visible-desktop action-buttons">'
                                            + '<a href="#"  class="Red"  title="Delete" onclick="onConfirmDelete(' + obj.aData.id + ');"' + str + ' >'
                                            + '<span class="red"><i class="icon-trash bigger-130"></i></span>'
                                            + '</a>'
                                            + '</div>'
                                            + '<div class="hidden-desktop visible-phone">'
                                            + '			<div class="inline position-relative">'
                                            + '				<button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">'
                                            + '					<i class="icon-cog icon-only bigger-110"></i>'
                                            + '				</button>'
                                            + '				<ul class="dropdown-menu dropdown-icon-only dropdown-yellow pull-right dropdown-caret dropdown-close">'
                                            + ''
                                            + '					<li>'
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDelete(' + obj.aData.id + ');"' + str + ' >'
                                            + '							<span class="red">'
                                            + '								<i class="icon-trash bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + '				</ul>'
                                            + '			</div>'
                                            + '		</div>'


                                    ;
                                },
                                "sDefaultContent": "",
                                "bUseRendered": false
                            }
            ];

            oTable = $('#dt_out').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "70%", "aTargets": [1] },
                { "sWidth": "20%", "aTargets": [2] }
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }



        //Save 
        function onSave() {


            var user_id = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
            var app_no = $('#txtApp_no').val();
    
            var param = "{'app_no':" + JSON.stringify(app_no)
                + ",'user_id':" + JSON.stringify(user_id) + "}";

           // alert(param);
            // return false;
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveFileLost",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onSuccess,
                error: onFailed
            });
        }





        //Delete 
        function onDelete(id) {
            var param = "{'id':" + JSON.stringify(id) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/DeleteFileLost",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onDeleteSuccess,
                error: onDeleteFailed
            });
        }



        //Confirm delete 
        function onConfirmDelete(id) {

            var msg = 'Please confirm the delete';
            var div = $("<div>" + msg + "</div>");
            div.dialog({
                title: "Confirm",
                modal: true,
                buttons: [
                            {
                                text: "Yes",
                                click: function () {
                                    div.dialog("close");
                                    onDelete(id);

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

        //Group  Alert  True
        function onSuccess(result) {

            if (result.d == "YES") {
                onAlert("Save Complete");
                LoadData();
            } else {
                if (result.d == "DUPLICATE") {
                    onAlert("App No already exists.");
                    LoadData();
                } else {
                    onAlert("Save Fail");
                }

            }

        }

        //Alert Save when false
        function onFailed() {
            onAlert("Save Fail");
        }

        //Alert Delete when true
        function onDeleteSuccess(result) {

            if (result.d == true) {
                onAlert("Delete Complete");
                LoadData();

            } else {
                onAlert("Delete Fail");
            }

        }

        //Alert Delete when false
        function onDeleteFailed() {
            onAlert("Delete Fail");
        }

        // Alert Box
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

        //Hide Valid
        function onValidHide() {
            $("#lblvalid_DesktopNo").hide();
            $("#lblvalid_floor_id").hide();
            $("#lblvalid_room_id").hide();
            $("#lblvalid_owner").hide();
        }

        //Check Valid
        function onValid() {
            var isValid;
            isValid = true;
            var desktop_no = $('#txtTagNo').val();
            var floor = $('#cblocationfrom').val();
            var room = $('#cblocationto').val();
            var owner = $('#txtUserId').val();
            if (desktop_no == '') {
                $("#lblvalid_DesktopNo").show();
                isValid = false;
            } else {
                $("#lblvalid_DesktopNo").hide();
            }

            if (floor == '') {
                $('#lblvalid_floor_id').show();
                isValid = false;
            } else {
                $('#lblvalid_floor_id').hide();
            }

            if (room == '') {
                $("#lblvalid_room_id").show();
                isValid = false;
            } else {
                $("#lblvalid_room_id").hide();
            }

            if (owner == '') {
                $("#lblvalid_owner").show();
                isValid = false;
            } else {
                $("#lblvalid_owner").hide();
            }


            return isValid;

        }

        function clearInput() {
            $("txtTagNo").val("");
            $("txtDescription").val("");
            $("txtUserId").val("");
            populateSelect(0);
            $("#ckbActive").prop("checked", false);
        }


    </script>
</asp:Content>

