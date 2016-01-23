<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmRegisterFile.aspx.vb" Inherits="frmRegisterFile" %>

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
                <li class="active">Register File</li>
            </ul>

        </div>

        <div class="page-content">


            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">Register File</h3>

                    <div class="row-fluid">
                        <div class="span12" id="divbtnAdd">
                            <button class="btn btn-small btn-success" id="btnAdd" name="btnAdd">
                                <i class=" icon-plus"></i>
                                Add New
                            </button>
                            <button class="btn btn-small" id="btnBack" name="btnBack">
                                <i class=" icon-undo"></i>
                                Back
                            </button>    

                        </div>
                    </div>
                    <div class="space-2"></div>
                    <br />
                    <div id="dialog-grid">

                         <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblAppNo_ctr">App No</label>
                                </div>
                                <div class="span4">
                                    <input type="text" class="input-mini" id="txtAppNo_ctr" style="width: 200px;" maxlength="20" />
                                </div>
                                <div class="span2">
                                    <label class="control-label" id="lblAppName_ctr">App Name</label>
                                </div>
                                <div class="span4">
                                    <input type="text" class="input-mini" id="txtAppName_ctr" style="width: 200px;" maxlength="1000" />
                                </div>
                            </div>
                        </div>
                         <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblPatentType_ctr">Patent Type</label>
                                </div>
                                <div class="span4">
                                    <select id="cbPatentType_ctr" data-placeholder="Choose a Patent Type..." style="width: 300px"></select>
                                </div>
                                <div class="span2">
                                    <label class="control-label" id="lblShelf_ctr">Shelf</label>
                                </div>
                                <div class="span4">
                                    <input type="text" class="input-mini" id="txtShelf_ctr" style="width: 200px;" maxlength="255" />
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblLocation_ctr">Location</label>
                                </div>
                                <div class="span10">
                                    <select id="cbLocation_ctr" data-placeholder="Choose a Location..." style="width: 300px"></select>
                                    <span class="help-inline color red" id="lblvalid_Location_ctr" style="display: none">This field is required</span>
                                </div>
                            </div>
                        </div>  

                        <div class="space-4"></div>
                        <div class="row-fluid">
                            <div class="span4">
                            </div>
                            <div class="span8">
                                <button class="btn btn-primary" id="btnSearch" name="btnSearch">
                                    <i class="icon-search  bigger-110"></i>
                                    Search
                                </button>
                                <button class="btn" type="reset" id="btnClear_ctr" name="btnClear_ctr">
                                    <i class="icon-undo bigger-110"></i>
                                    Clear
                                </button>
                            </div>
                        </div>
                         <div class="space-4"></div>

                        <div class="row-fluid">
                            <div class="span12">
                                <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                            </div>
                        </div>
                    </div>




                    <div id="dialog-edit">
                       <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblAppNo">App No</label>
                                </div>
                                <div class="span10">
                                    <input type="text" class="input-mini" id="txtAppNo" style="width: 385px;" maxlength="20" />
                                    <span class="help-inline color red" id="lblvalidAppNo" style="display: none">This field is required</span>
                                </div>

                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblAppName">App Name</label>
                                </div>
                                <div class="span10">
                                    <input type="text" class="input-mini" id="txtAppName" style="width: 385px;" maxlength="1000" />
                                    <span class="help-inline color red" id="lblvalidAppName" style="display: none">This field is required</span>
                                </div>

                            </div>
                        </div>
                      
                        <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblPatentType">Patent Type</label>
                                </div>
                                <div class="span10">
                                    <select id="cbPatentType" data-placeholder="Choose a Patent Type..." style="width: 400px"></select>
                                    <span class="help-inline color red" id="lblvalid_PatentType" style="display: none">This field is required</span>
                                </div>

                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblQty">Qty</label>
                                </div>
                                <div class="span10">
                                    <input type="text" class="input-mini" id="txtQty" style="width: 100px;" onkeypress="return Numbers(event)" maxlength="10" />
                                    <span class="help-inline color red" id="lblvalidQty" style="display: none">This field is required</span>
                                </div>

                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblShelf">Shelf</label>
                                </div>
                                <div class="span10">
                                    <input type="text" class="input-mini" id="txtShelf" style="width: 385px;" maxlength="255" />
                                    <span class="help-inline color red" id="lblvalidShelf" style="display: none">This field is required</span>
                                </div>

                            </div>
                        </div>
                     
                        <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblLocation">Location</label>
                                </div>
                                <div class="span10">
                                    <select id="cbLocation" data-placeholder="Choose a Location..." style="width: 400px"></select>
                                    <span class="help-inline color red" id="lblvalid_Location" style="display: none">This field is required</span>
                                </div>
                            </div>
                        </div>                     

                        <div class="span-2"></div>
                        <div class="row-fluid">
                            <br />
                            <div>
                                <h3 class="header smaller lighter blue">Tag</h3>
                            </div>


                            <div class="row-fluid">
                                <div class="span12" id="divbtnAddTag">
                                    <button class="btn btn-small btn-success" id="btnAddTag" name="btnAddTag">
                                        <i class=" icon-plus"></i>
                                        Add New
                                    </button>
                                </div>
                            </div>
                            <div class="space-2"></div>
                            <span class="help-inline color red" id="lblvalid_Tag" style="display: none">Tag is required</span>
                            <div id="dialog-grid_tag">
                                <div class="row-fluid">
                                    <div class="span8">
                                        <table class="table table-striped table-bordered table-hover" id="dt_outtag"></table>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="dialog-edit-tag">
                            <div class="row-fluid">
                                <div class="span12">

                                    <div class="span2">
                                        <label class="control-label" id="lblTagNo">Tag No </label>
                                    </div>
                                    <div class="span10">
                                        <input type="text" class="input-mini" id="txtTagNo" style="width: 200px;" maxlength="20" />
                                        <span class="help-inline color red" id="lblvalid_TagNo" style="display: none">This field is required</span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="space-4"></div>
                        <div class="row-fluid">
                            <div class="span4">
                            </div>
                            <div class="span8">
                                <button class="btn btn-primary" id="btnSave" name="btnSave">
                                    <i class="icon-edit  bigger-110"></i>
                                    Save
                       
                                </button>
                                <button class="btn" type="reset" id="btnClear" name="btnClear">
                                    <i class="icon-undo bigger-110"></i>
                                    Clear
                                </button>
                            </div>
                        </div>
                    
                    </div>


                </div>
            </div>

        </div>
    </div>

   
    <%-- //Keep Path input file--%>
    <input id="HiddenId" type="hidden" />
<script type="text/javascript">
    //Open page
    $(document).ready(function () {
        var oTable;
        var isAddNew = false;
       // LoadData();
        populateSelect_ctr(0);
        localStorage['tag'] = '';


        //Add Click
        $("#btnAdd").click(function () {
            onEdit(0);
            clickEdit();
        });


        $("#btnBack").click(function () {
            onEdit(0);
            clickEndEdit();
        });


        $("#btnSave").click(function () {
            var ret = onValid();
            if (ret == true) {
                onSave();
            }

        });

        $("#btnClear").click(function () {
            clearInput();
        });

        $("#btnAddTag").click(function () {
            onEditTag(0); return false;
        });

        $("#btnClear_ctr").click(function () {
            clearInput_Ctr();
        });

        $("#btnSearch").click(function () {
            LoadData();
        });
       
        //Hide div or other
        $("#dialog-edit").hide();
        $("#dialog-edit-tag").hide();
        $("#btnBack").hide();

    });
</script>

<script type="text/javascript">
    //Call
    function LoadData() {
     
        var app_no = $('#txtAppNo_ctr').val();
        var app_name = $('#txtAppName_ctr').val();
        var shelf_name = $('#txtShelf_ctr').val();
        var patent_type_id = $('#cbPatentType_ctr').val();
        var location = $('#cbLocation_ctr').val();

        if ((app_no == '') && (app_name == '') && (shelf_name == '') && (patent_type_id == '') && (location == '')) {
            onAlert("Please specify condition.");
            return;
        }

        var param = "{'app_no':" + JSON.stringify(app_no)
                    + ",'app_name':" + JSON.stringify(app_name)
                    + ",'shelf_name':" + JSON.stringify(shelf_name)
                    + ",'patent_type_id':" + JSON.stringify(patent_type_id)
                    + ",'location':" + JSON.stringify(location) + "}";
        var dataurl = 'WebService/WebService.asmx/LoadRequisitionAll';
        $.ajax({
            "type": "POST",
            "dataType": 'json',
            "contentType": "application/json; charset=utf-8",
            "url": dataurl,
            "success": PopulateGrid,
            "data": param,
            "error": function () {
                alert('load data error!');
            }
        });
    }


    //Populate Grid
    function PopulateGrid(jsondata) {
        var jsonobject = JSON.parse(jsondata.d);
        var columns = [
                        {
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
                            "sTitle": "App Name",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "app_name"

                        },
                       {
                           "sTitle": "Patent Type",
                           "sType": "string",
                           "sDefaultContent": "",
                           "mDataProp": "patent_type_name"

                       },
                        {
                            "sTitle": "Qty",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "qty"
                        },
                        {
                            "sTitle": "Shelf",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "shelf_name"
                        },

                        {
                            "sTitle": "Action",
                            "bSortable": false,
                            "fnRender": function (obj) {
                                return '<div class="hidden-phone visible-desktop action-buttons">'
                                        + '<a href="#"  class="Green"  title="Edit" onClick="onEdit(' + obj.aData.id + ');clickEdit();  return false;">'
                                        + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                        + '</a>'
                                        + '&nbsp;'
                                        + '<a href="#"  class="Red"  title="Delete" onclick="onConfirmDelete(' + obj.aData.id + '); return false;" >'
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
                                        + '						<a href="#"   class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEdit(' + obj.aData.id + ');clickEdit(); return false;">'
                                        + '							<span class="green">'
                                        + '								<i class="icon-edit bigger-120"></i>'
                                        + '							</span>'
                                        + '						</a>'
                                        + '					</li>'
                                        + '					<li>'
                                        + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDelete(' + obj.aData.id + '); return false;">'
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
            "iDisplayLength": 100,
            "aoColumnDefs": [
            { "sWidth": "5%", "aTargets": [0] },
            { "sWidth": "15%", "aTargets": [1] },
            { "sWidth": "20%", "aTargets": [2] },
            { "sWidth": "20%", "aTargets": [3] },
            { "sWidth": "10%", "aTargets": [4] },
            { "sWidth": "20%", "aTargets": [5] },
            { "sWidth": "20%", "aTargets": [6] }

            ],
            "aoColumns": columns,
            "bDestroy": true,
        });


    }

    //Add or Edit 
    function clickEdit() {
        $("#btnAdd").hide();
        $("#btnBack").show();
        $("#dialog-grid").hide();
        $("#dialog-edit").show();
    }


    function clickEndEdit() {
        $("#btnAdd").show();
        $("#btnBack").hide();
        $("#dialog-grid").show();
        $("#dialog-edit").hide();
    }


    function onEdit(id) {
        clearInput();
        onValidHide();
        $("#HiddenId").val(id);
        var param = "{'id':" + JSON.stringify(id) + "}";

        $.ajax({
            type: "POST",
            url: "WebService/WebService.asmx/GetRequisitionById",
            data: param,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var strvalue = JSON.parse(data.d);

                if (strvalue.length == 1) {
                    $("#HiddenId").val(strvalue[0].id);
                    $("#txtAppNo").val(strvalue[0].app_no);
                    $("#txtAppName").val(strvalue[0].app_name);
                    $("#cbPatentType").val(strvalue[0].patent_type_id);
                    $("#txtQty").val(strvalue[0].qty);
                    $("#txtShelf").val(strvalue[0].shelf_name);
                    $("#cbLocation").val(strvalue[0].filelocation);

                    populateSelect(strvalue[0].id);
                    localStorage['tag'] = '';

                    LoadTag(strvalue[0].id);
                } else {
                    clearInput();
                    $("#HiddenId").val(0);
                }
            },
            error: function (data) {
            }
        });

    }

   

    //Save 
    function onSave() {
        var id = $("#HiddenId").val();
        var login_username = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
        var app_no = $("#txtAppNo").val();
        var app_name = $("#txtAppName").val();
        var patent_type_id = $("#cbPatentType").val();
        var qty = $("#txtQty").val();
        var Shelf_name = $("#txtShelf").val();
        var filelocation = $("#cbLocation").val();
        var jsonobject_tag = localStorage['tag'];

        var param = "{'id':" + JSON.stringify(id)
            + ",'app_no':" + JSON.stringify(app_no)
            + ",'app_name':" + JSON.stringify(app_name)
            + ",'patent_type_id':" + JSON.stringify(patent_type_id)
            + ",'qty':" + JSON.stringify(qty)
            + ",'shlef_name':" + JSON.stringify(Shelf_name)
            + ",'filelocation':" + JSON.stringify(filelocation)
            + ",'jsonobject_tag':" + JSON.stringify(jsonobject_tag)
            + ",'login_username':" + JSON.stringify(login_username) + "}";

        $.ajax({
            type: "POST",
            url: "WebService/WebService.asmx/SaveRequisition",
            data: param,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccess,
            error: onFailed
        });
    }

    function populateSelect_ctr(tb_requisition_id) {
        var strselect;
        var param = "{'tb_requisition_id':" + JSON.stringify(tb_requisition_id) + "}";
        $selectPatentType_ctr = $("#cbPatentType_ctr");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadPatentTypeByRequisition',
            data: param,
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                $selectPatentType_ctr.html('');
                $selectPatentType_ctr.append('<option value="">Choose a Patent Type</option>');
                //append a select option
                $.each(jsonobject, function (key, val) {
                    strselect = '';
                    if (val.selected != "") {
                        strselect = ' selected="' + val.selected + '"';
                    }

                    $selectPatentType_ctr.append('<option value="' + val.id + '" ' + strselect + '>' + val.patent_type_name + '</option>');
                    $selectPatentType_ctr.trigger("chosen:updated");//update select option

                })
                $selectPatentType_ctr.chosen();

            }
        });

        $selectLocation_ctr = $("#cbLocation_ctr");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadLocationByRequisition',
            data: param,
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                $selectLocation_ctr.html('');
                $selectLocation_ctr.append('<option value="">Choose a Location</option>');
                //append a select option
                $.each(jsonobject, function (key, val) {
                    strselect = '';
                    if (val.selected != "") {
                        strselect = ' selected="' + val.selected + '"';
                    }

                    $selectLocation_ctr.append('<option value="' + val.id + '" ' + strselect + '>' + val.LocationName + '</option>');
                    $selectLocation_ctr.trigger("chosen:updated");//update select option
                })
                $selectLocation_ctr.chosen();
            }
        });

    }

    function populateSelect(tb_requisition_id) {

            var strselect;
            var param = "{'tb_requisition_id':" + JSON.stringify(tb_requisition_id) + "}";
            $selectPatentType = $("#cbPatentType");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadPatentTypeByRequisition',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    $selectPatentType.html('');
                    $selectPatentType.append('<option value="">Choose a Patent Type</option>');
                    //append a select option
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (val.selected != "") {
                            strselect = ' selected="' + val.selected + '"';
                        }

                        $selectPatentType.append('<option value="' + val.id + '" ' + strselect + '>' + val.patent_type_name + '</option>');
                        $selectPatentType.trigger("chosen:updated");//update select option
                  
                    })
                    $selectPatentType.chosen();
                
                }
            });

            $selectLocation = $("#cbLocation");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadLocationByRequisition',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    $selectLocation.html('');
                    $selectLocation.append('<option value="">Choose a Location</option>');
                    //append a select option
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (val.selected != "") {
                            strselect = ' selected="' + val.selected + '"';
                        }

                        $selectLocation.append('<option value="' + val.id + '" ' + strselect + '>' + val.LocationName + '</option>');
                        $selectLocation.trigger("chosen:updated");//update select option
                    })
                    $selectLocation.chosen();
                }
            });


        }

       

        //Delete 
        function onDelete(id) {
            var param = "{'id':" + JSON.stringify(id) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/DeleteRequisition",
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


        //Room  Alert  True
        function onSuccess(result) {
            if (result.d == "YES") {
                onAlert("Save Complete");
                LoadData();
                clearInput();
                clickEndEdit();
            } else {
                if (result.d == "DUPLICATEREQUISITIONAPPNO") {
                    onAlert("app no already exists. Please modify app no");
                    LoadData();
                }
                else {                  
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
            if (result.d == 'True') {
                onAlert("Delete Complete");
                LoadData();

            } else {
                if (result.d == 'DELETEFILEFAIL') {
                    onAlert("Can't delete this file.");
                }
                else {
                    onAlert("Delete Fail");
                }
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
            $("#lblvalidAppNo").hide();
            $("#lblvalidAppName").hide();
            $("#lblvalid_PatentType").hide();
            $("#lblvalidQty").hide();
            $("#lblvalidShelf").hide();
            $("#lblvalid_Location").hide();
            $("#lblvalid_Tag").hide();
        }

        //Check Valid
        function onValid() {

            var isValid;
            isValid = true;
            var app_no = $("#txtAppNo").val();
            var app_name = $("#txtAppName").val();
            var patent_type_id = $("#cbPatentType").val();
            var qty = $("#txtQty").val();
            var Shelf_name = $("#txtShelf").val();
            var filelocation = $("#cbLocation").val();
            // var jsonobject_tag = localStorage['tag'];

            if (app_no == '') {
                $("#lblvalidAppNo").show();
                isValid = false;
            } else {
                $("#lblvalidAppNo").hide();
            }

            if (app_name == '') {
                $("#lblvalidAppName").show();
                isValid = false;
            } else {
                $("#lblvalidAppName").hide();
            }

            if (patent_type_id == '') {
                $("#lblvalid_PatentType").show();
                isValid = false;
            } else {
                $("#lblvalid_PatentType").hide();
            }

            if (qty == '') {
                $("#lblvalidQty").show();
                isValid = false;
            } else {
                $("#lblvalidQty").hide();
            }

            if (Shelf_name == '') {
                $("#lblvalidShelf").show();
                isValid = false;
            } else {
                $("#lblvalidShelf").hide();
            }

            if (filelocation == '') {
                $("#lblvalid_Location").show();
                isValid = false;
            } else {
                $("#lblvalid_Location").hide();
            }

            if (localStorage['tag'] == '[]') {
                $("#lblvalid_Tag").show();
                isValid = false;
            } else {
                $("#lblvalid_Tag").hide();
            }


            return isValid;
        }


        function clearInput() {
            localStorage['tag'] = '';
            $("#txtAppNo").val("");
            $("#txtAppName").val("");
            $("#cbPatentType").val("");
            $("#txtQty").val(1);
            $("#txtShelf").val("");
            $("#cbLocation").val("");
            $("#txtTagNo").val("");
            populateSelect(0);
            LoadTag(0);
        }

        function clearInput_Ctr() {
            $("#txtAppNo_ctr").val("");
            $("#txtAppName_ctr").val("");
            $("#txtShelf_ctr").val("");
            populateSelect_ctr(0);
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

<%--Tag--%>
<input id="HiddenTag" value="0" type="hidden" />
<script type="text/javascript">
    function onSaveTag(id) {
        var tag_no = $('#txtTagNo').val();
        //running no
        var rows = $("#dt_outtag").dataTable().fnGetNodes();

        //data in current session
        var jsonobject = JSON.parse(localStorage['tag']);
        var aaData = [];
        aaData = jsonobject;
        //add data in current session

        if (id == 0) {
            aaData.push({
                "no": parseInt(rows.length) + 1,
                "id": parseInt(rows.length) + 1,
                "tag_no": tag_no
            });

        } else {//edit data in current session
            for (var i = 0; i < aaData.length; i++) {
                if (aaData[i].id == id) {
                    aaData[i].tag_no = tag_no;
                    break;
                }
            }

        }


        //update data in session
        localStorage['tag'] = JSON.stringify(aaData);
        
        // Reload
        LoadTag(0);
        clearTag();
    }

    function clearTag() {
        $('#txtTagNo').val("");
        $('#HiddenTag').val("0");
    }


    function LoadTag(tb_requisition_id) {
        var param = "{'tb_requisition_id':" + JSON.stringify(tb_requisition_id) + "}";
        var dataurl = 'WebService/WebService.asmx/LoadRequisitionTag';
        $.ajax({
            "type": "POST",
            "dataType": 'json',
            "contentType": "application/json; charset=utf-8",
            "url": dataurl,
            "data": param,
            "success": PopulateGridTag
        });
    }


    function PopulateGridTag(jsondata) {
        var jsonobject = JSON.parse(jsondata.d);
        var yetVisited = localStorage['tag'];
        if (yetVisited.length > 0) {

        }
        else {
            localStorage['tag'] = jsondata.d;
        }

        var columns = [

                        {
                            "sTitle": "No",
                            "sType": "numeric",
                            "mDataProp": "no",
                            "bSortable": false,
                            "bUseRendered": false

                        },
                        {
                            "sTitle": "Tag No",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "tag_no"

                        },
                        {
                            "sTitle": "Action",
                            "bSortable": false,
                            "fnRender": function (obj) {

                                var IsDelete = obj.aData.IsDelete;
                                var str = "";
                                if (IsDelete == "T") {
                                    str = " style='display:none;'"
                                }

                                return '<div class="hidden-phone visible-desktop action-buttons">'
                                        + '&nbsp;'
                                        + '<a href="#"   class="Green"  title="Edit" onClick="onEditTag(' + obj.aData.id + '); return false;">'
                                        + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                        + '</a>'
                                        + '&nbsp;'
                                        + '<a href="#"   class="Red"  title="Delete" onclick="onConfirmDeleteTag(' + obj.aData.no + '); return false;"' + str + ' >'
                                        + '<span class="red"><i class="icon-trash bigger-130"></i></span>'
                                        + '</a>'
                                        + '</div>'
                                        + '<div class="hidden-desktop visible-phone">'
                                        + '			<div class="inline position-relative">'
                                        + '				<button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">'
                                        + '					<i class="icon-cog icon-only bigger-110"></i>'
                                        + '				</button>'
                                        + ''
                                        + '				<ul class="dropdown-menu dropdown-icon-only dropdown-yellow pull-right dropdown-caret dropdown-close">'


                                        + '					<li>'
                                        + '						<a href="#"  class="tooltip-info" data-rel="tooltip" title="View" ">'
                                        + '							<span class="blue">'
                                        + '								<i class="icon-zoom-in bigger-120"></i>'
                                        + '							</span>'
                                        + '						</a>'
                                        + '					</li>'


                                        + ''
                                        + '					<li>'
                                        + '						<a href="#"    class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEditTag(' + obj.aData.id + '); return false;">'
                                        + '							<span class="green">'
                                        + '								<i class="icon-edit bigger-120"></i>'
                                        + '							</span>'
                                        + '						</a>'
                                        + '					</li>'
                                        + ''
                                        + '					<li>'
                                        + '						<a href="#"   class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDeleteTag(' + obj.aData.no + '); return false;"' + str + ' >'
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

        var aaData = getDataTag();
        oTable = $('#dt_outtag').dataTable({
            "aaData": aaData,
            "bAutoWidth": false,
            "aoColumnDefs": [
            { "sWidth": "20%", "aTargets": [0] },
            { "sWidth": "50%", "aTargets": [1] },
            { "sWidth": "30%", "aTargets": [2] }
            ],
            "aoColumns": columns,
            "bDestroy": true,
            "fnDrawCallback": function () {

            }

        });
    }

    function getDataTag() {
        var jsonobject = JSON.parse(localStorage['tag']);
        var aaData = [];
        aaData = jsonobject;
        return aaData;
    }

    function onEditTag(id) {
        
        onValidTagHide();
        //Find data in current session
        if (id > 0) {
            var jsonobject = JSON.parse(localStorage['tag']);
            var editjsonobject = getObjects(jsonobject, 'id', id);

            $.each(editjsonobject, function (key, val) {
                $('#HiddenTag').val(val.id);
                $('#txtTagNo').val(val.tag_no);

            })

        } else {
            clearTag();

        }


        $("#dialog-edit-tag").dialog({
            autoOpen: false,
            resizable: false,
            width: "500px",
            modal: true,
            buttons: {
                "Save": function () {
                    var checkvalid = onValidTag();
                    if (checkvalid == true) {
                        if (checkid_duplicate_tag($('#txtTagNo').val(), $('#HiddenTag').val()) == false) {
                            $('#txtTagNo').focus();
                            onAlert("Tag no already exists. Please modify Tag no");
                        }
                        else {
                            onSaveTag(id);
                            //onAlert("Add Complete");
                            $(this).dialog("close");
                        }
                    }
                },
                "Close": function () {
                    $(this).dialog("close");
                }

            },
            show: {
                effect: 'fade',
                duration: 500
            },
            hide: {
                effect: 'fade',
                duration: 500
            }
        });

        var titledialog;
        if (id == 0) {
            titledialog = "Tag";
        } else {
            titledialog = "Edit Tag";
        }

        $("#dialog-edit-tag").dialog("option", "title", titledialog).dialog("open");
    }

    function checkid_duplicate_tag(tag_no, id) {
        var jsonobject = JSON.parse(localStorage['tag']);
        var checkjsonobject = getObjects(jsonobject, 'tag_no', tag_no);
        if (checkjsonobject.length == 0) {
            return true;
        } else {
            if (id != checkjsonobject[0].id) {
                return false;
            } else {
                return true;
            }

        }
    }

    function getObjects(obj, key, val) {
        var objects = [];
        for (var i in obj) {
            if (!obj.hasOwnProperty(i)) continue;
            if (typeof obj[i] == 'object') {
                objects = objects.concat(getObjects(obj[i], key, val));
            } else if (i == key && obj[key] == val) {
                objects.push(obj);
            }
        }
        return objects;
    }

    function onValidTagHide() {
        $("#lblvalid_TagNo").hide();
        //$("#lblvalid_Tag").hide();

    }

    function onValidTag() {

        var isValid;
        isValid = true;

        var tag_no = $('#txtTagNo').val();

        if (tag_no == '') {
            $("#lblvalid_TagNo").show();
            isValid = false;
        } else {

            $("#lblvalid_TagNo").hide();

        }


        return isValid;
    }

    function deleteDataTag(no) {
        var jsonobject = JSON.parse(localStorage['tag']);
        var aaData = [];
        aaData = jsonobject;
        aaData.splice(parseInt(no) - 1, 1);
        //running inndex bew
        var icount = 1;
        $.each(aaData, function (key, val) {
            aaData[icount - 1].no = icount;
            icount = icount + 1
        })
        localStorage['tag'] = JSON.stringify(aaData);
        LoadTag(0);
    }

    function onConfirmDeleteTag(id) {
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
                                deleteDataTag(id);
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
</script>



</asp:Content>

