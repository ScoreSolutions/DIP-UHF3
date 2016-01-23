<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage2.master" AutoEventWireup="false" CodeFile="frmHumidityTemperature.aspx.vb" Inherits="frmHumidityTemperature" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
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
                <li class="active">Humidity Temperature</li>
            </ul>

        </div>

        <div class="page-content">


            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">Humidity Temperature</h3>

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
                                <div class="span1" >
                                    <label class="control-label" id="lblRoom_ctr">Room</label>
                                </div>
                                <div class="span3" style="margin:0px">
                                    <select  id="cbroom_ctr" data-placeholder="Choose a Room..." style="width:200px"> </select>
                                </div>
                                <div class="span2" >
                                    <label class="control-label" id="lblRecordDate_ctr">Record Date</label>
                                </div>
                                <div class="span3" style="margin:0px">
                                     <input class="date-picker width-55" id="txtDateFrom" type="text" data-date-format="dd/mm/yyyy" />
                                    <span class="add-on">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                                <div class="span3" style="margin:0px">
                                    <span class="help-inline">To</span>
                                    <input class="date-picker width-55" id="txtDateEnd" type="text" data-date-format="dd/mm/yyyy" />
                                    <span class="add-on">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                         <div class="row-fluid">
                            <div class="span12">
                                <div class="span1" >
                                    <label class="control-label" id="lblDevice_ctr">Device</label>
                                </div>
                                <div class="span3" style="margin:0px">
                                    <select  id="cbdevice_ctr" data-placeholder="Choose a Device..." style="width:200px"> </select>
                                </div>
                                <div class="span2" >
                                    <label class="control-label" id="lblHumidity_ctr">Humidity(%RH)</label>
                                </div>
                                <div class="span1" style="margin:0px">
                                    <input type="text" class="input-mini" id="txtHumidityFrom" onkeypress="return Numbers(event)" maxlength="10" style="width: 60px;" maxlength="255" />
                                </div>
                                <div class="span5" >
                                    <span class="help-inline">To</span>
                                    <input type="text" class="input-mini" id="txtHumidityTo" onkeypress="return Numbers(event)" maxlength="10" style="width: 60px;" maxlength="255" />
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span1" >
                                   
                                </div>
                                <div class="span3" style="margin:0px">
                                    
                                </div>
                                <div class="span2" >
                                    <label class="control-label" id="lblTemperature_ctr">Temperature</label>
                                </div>
                                <div class="span1" style="margin:0px">
                                    <input type="text" class="input-mini" id="txtTemperatureFrom" onkeypress="return Numbers(event)" maxlength="10" style="width: 60px;" maxlength="255" />
                                </div>
                                <div class="span2" >
                                    <span class="help-inline">To</span>
                                    <input type="text" class="input-mini" id="txtTemperatureTo" onkeypress="return Numbers(event)" maxlength="10" style="width: 60px;" maxlength="255" />
                                </div>
                                <div class="span3" style="margin:0px">
                                    <select  id="cbTemperature"  style="width:80px"> </select>
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
                                    <label class="control-label" id="lblRoom">Room</label>
                                </div>
                                <div class="span10">
                                    <select  id="cbroom" data-placeholder="Choose a Room..." style="width:200px"> </select>
                                    <span class="help-inline color red" id="lblvalidRoom" style="display: none">This field is required</span>
                                </div>

                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblDevice">Device</label>
                                </div>
                                <div class="span10">
                                     <select  id="cbdevice" data-placeholder="Choose a Device..." style="width:200px"> </select>
                                    <span class="help-inline color red" id="lblvalidDevice" style="display: none">This field is required</span>
                                </div>
                            </div>
                        </div>
                      
                        <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblPatentType">Data File</label>
                                </div>
                                <div class="span3">
                                    <div id="base" style="display: none"></div>
                                   <input type="text" class="input-mini" id="txtfilename" style="width: 250px;" readonly="true" />
                                </div>
                                <div class="span3">
                                    <span class="btn btn-default btn-mini btn-file">Choose&hellip; 
                                        <input type="file" id="inputfile" class="ace-file-input" />
                                    </span>
                                </div>
                               <div class="span4">
                               </div>

                            </div>
                        </div>
                                           
                        <div class="row-fluid">
                            <div>
                                <h3 class="header smaller lighter blue">Data</h3>
                            </div>
                            <div class="space-2"></div>
                            <span class="help-inline color red" id="lblvalid_data" style="display: none">Data is required</span>
                            <div id="dialog-grid_data">
                                <div class="row-fluid">
                                    <div class="span8">
                                        <table class="table table-striped table-bordered table-hover" id="dt_outdata"></table>
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

   

<script type="text/javascript">
    //Open page
    $(document).ready(function () {
        var oTable;
        var isAddNew = false;
      
        populateSelect_ctr();
        populateSelectDeviceById_ctr();
        LoadData();

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

        $("#btnClear_ctr").click(function () {
            clearInput_Ctr();
        });

        $("#btnSearch").click(function () {
            LoadData();
        });

        $("#inputfile").change(function () {
            readFile(this);
        });

        $("#inputfile").click(function () {
            this.value = null;
        });

        $('#cbroom').change(function () {
            populateSelectDeviceById();
        });

        $('#cbroom_ctr').change(function () {
            populateSelectDeviceById_ctr();
        });

        //ปฎิธิน
        $('.date-picker').datepicker({ "autoclose": true }).next().on(ace.click_event, function () {
            $(this).prev().focus();
        });

        //$("#btnUpload").click(function () {
        //    UploadFile();
        //});
        

        //Hide div or other
        $("#dialog-edit").hide();
        $("#btnBack").hide();

    });
</script>

<%--File--%>
<script type="text/javascript">
    function readFile(input) {
        if (input.files && input.files[0]) {
            var FR = new FileReader();
            FR.onload = function (e) {
                var binaryString = [];
                var file = input.files[0];
                var fileName = file.name;
                var fileExt = fileName.split('.').pop().toLowerCase();
          
                var filesize = file.size;

                if ($.inArray(fileExt, ['xls', 'XLS']) == -1) {
                    onAlert("Please input file type xls");
                } else if ((filesize / 1024) > 1000) { //1Mb
                    onAlert("Please input file size less than 1MB");
                } else {
                    binaryString = e.target.result;
                    binaryString = binaryString.split(',');
                    $("#base").text(binaryString[1]);
                    $('#txtfilename').val(fileName);
                    // $('#txtfilepath').val($('input[type=file]').val());

                    UploadFile();
                }

            };
            FR.readAsDataURL(input.files[0]);
        }
    }

    function UploadFile() {
        var strfilebase64 = $("#base").text();
        var param = "{'strfilebase64':" + JSON.stringify(strfilebase64) + ",'filename':'file.xls'}";
        $.ajax({
            type: "POST",
            url: "WebService/WebService.asmx/UpLoadFile",
            data: param,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                GetDataFromFile();
            },
            error: function () {
                alert('upload error!');
            }
        });

        function GetDataFromFile() {
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadDataFromFile",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: PopulateGridData,
                error: function () {
                    alert('get data error!');
                }
            });
        }

        
    }

    function PopulateGridData(jsondata) {
        var jsonobject = JSON.parse(jsondata.d);
        localStorage['data'] = jsondata.d;
        var columns = [
                        {
                            "sTitle": "No",
                            "sType": "numeric",
                            "mDataProp": "no",
                            "bSortable": false,
                            "bUseRendered": false

                        },
                        {
                            "sTitle": "Record Date",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "record_datetime"
                        },
                        {
                            "sTitle": "Humidity(%RH)",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "humidity_value"
                        },
                        {
                            "sTitle": "Temperature",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "temp"
                        }
        ];

        oTable = $('#dt_outdata').dataTable({
            "aaData": jsonobject,
            "bAutoWidth": false,
            "iDisplayLength": 10,
            "aoColumnDefs": [
            { "sWidth": "20%", "aTargets": [0] },
            { "sWidth": "40%", "aTargets": [1] },
            { "sWidth": "20%", "aTargets": [2] },
            { "sWidth": "20%", "aTargets": [3] }
            ],
            "aoColumns": columns,
            "bDestroy": true,
        });


    }
</script>


<script type="text/javascript">

    function ClearDataFromFile() {
        var dataurl = 'WebService/WebService.asmx/ClearDataFromFile';
        $.ajax({
            "type": "POST",
            "dataType": 'json',
            "contentType": "application/json; charset=utf-8",
            "url": dataurl,
            "success": PopulateGridData,
            "error": function () {
                alert('load data error!');
            }
        });
    }

    function LoadData() {
        var room = $('#cbroom_ctr').val();
        var datefrom = $('#txtDateFrom').val();
        var dateto = $('#txtDateEnd').val();
        var device = $('#cbdevice_ctr').val();
        var humidityfrom = $('#txtHumidityFrom').val();
        var humidityto = $('#txtHumidityTo').val();
        var temperaturefrom = $('#txtTemperatureFrom').val();
        var temperatureto = $('#txtTemperatureTo').val();
        var temptype = $('#cbTemperature').val();

        if ((datefrom != '') || (dateto != '')) {
            if ((datefrom == '')) {
                onAlert("Please specify date from.");
                return;
            }
            else if ((dateto == '')) {
                onAlert("Please specify date to.");
                return;
            }
        }

        if ((humidityfrom != '') || (humidityto != '')) {
            if ((humidityfrom == '')) {
                onAlert("Please specify humidity from.");
                return;
            }
            else if ((humidityto == '')) {
                onAlert("Please specify humidity to.");
                return;
            }
        }

        if ((temperaturefrom != '') || (temperatureto != '')) {
            if ((temperaturefrom == '')) {
                onAlert("Please specify temperature from.");
                return;
            }
            else if ((temperatureto == '')) {
                onAlert("Please specify temperature to.");
                return;
            }
        }

        var param = "{'room':" + JSON.stringify(room)
                    + ",'datefrom':" + JSON.stringify(datefrom)
                    + ",'dateto':" + JSON.stringify(dateto)
                    + ",'device':" + JSON.stringify(device)
                    + ",'humidityfrom':" + JSON.stringify(humidityfrom)
                    + ",'humidityto':" + JSON.stringify(humidityto)
                    + ",'temperaturefrom':" + JSON.stringify(temperaturefrom)
                    + ",'temperatureto':" + JSON.stringify(temperatureto)
                    + ",'temptype':" + JSON.stringify(temptype) + "}";

        var dataurl = 'WebService/WebService.asmx/LoadTempertureHistory';
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
                            "sTitle": "Room",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "room_name"

                        },
                        {
                            "sTitle": "Device",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "serial_no"

                        },
                       //{
                       //    "sTitle": "Patent Type",
                       //    "sType": "string",
                       //    "sDefaultContent": "",
                       //    "mDataProp": "patent_type_name"

                       //},
                        {
                            "sTitle": "Record Date",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "record_datetime"
                        },
                        {
                            "sTitle": "Humidity(%RH)",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "humidity_value"
                        },
                        {
                            "sTitle": "Temperature",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "temp"
                        }
        ];

        oTable = $('#dt_out').dataTable({
            "aaData": jsonobject,
            "bAutoWidth": false,
            "iDisplayLength": 100,
            "aoColumnDefs": [
            { "sWidth": "5%", "aTargets": [0] },
            { "sWidth": "20%", "aTargets": [1] },
            { "sWidth": "20%", "aTargets": [2] },
            //{ "sWidth": "20%", "aTargets": [3] },
            { "sWidth": "20%", "aTargets": [4] },
            { "sWidth": "20%", "aTargets": [5] }

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
    }

    //Save 
    function onSave() {
        var login_username = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
        var deviceid = $("#cbdevice").val();

        var param = "{'MsHumidityTempID':" + JSON.stringify(deviceid)
         + ",'login_username':" + JSON.stringify(login_username) + "}";
          
        $.ajax({
            type: "POST",
            url: "WebService/WebService.asmx/SaveHumidity",
            data: param,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccess,
            error: onFailed
        });
    }

    function populateSelect_ctr() {
        var strselect;
        $selectRoom_ctr = $("#cbroom_ctr");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadRoomActive',
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                //clear 
                $selectRoom_ctr.html('');
                $selectRoom_ctr.append('<option value="">All</option>');
                //append a select option
                if (jsonobject.length > 0) {
                    $.each(jsonobject, function (key, val) {
                       
                        $selectRoom_ctr.append('<option value="' + val.id + '">' + val.room_name + '</option>');
                        $selectRoom_ctr.trigger("chosen:updated");//update select option
                    })
                }
                else {

                    $selectRoom_ctr.html('');
                    $selectRoom_ctr.append('<option value="">All</option>');
                    $selectRoom_ctr.trigger("chosen:updated");//update select option
                }

                $selectRoom_ctr.chosen();
            }
        });

        $selectTemperature = $("#cbTemperature");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadTemperature',
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                $selectTemperature.html('');
                $selectTemperature.append('<option value="">All</option>');
                if (jsonobject.length > 0) {
                    $.each(jsonobject, function (key, val) {
                        $selectTemperature.append('<option value="' + val.ID + '">' + val.Temp + '</option>');
                        $selectTemperature.trigger("chosen:updated");//update select option
                    })
                }
                else {

                    $selectTemperature.html('');
                    $selectTemperature.append('<option value="">All</option>');
                    $selectTemperature.trigger("chosen:updated");//update select option
                }
               
                $selectTemperature.chosen();
            }
        });
    }

    function populateSelect() {
        var strselect;

        $selectRoom = $("#cbroom");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadRoomActive',
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                //clear 
                $selectRoom.html('');
                $selectRoom.append('<option value="">Choose a Room</option>');
                //append a select option
                if (jsonobject.length > 0) {
                    $.each(jsonobject, function (key, val) {
                       
                        $selectRoom.append('<option value="' + val.id + '">' + val.room_name + '</option>');
                        $selectRoom.trigger("chosen:updated");//update select option
                    })
                }
                else {

                    $selectRoom.html('');
                    $selectRoom.append('<option value="">Choose a Room</option>');
                    $selectRoom.trigger("chosen:updated");//update select option
                }

                $selectRoom.chosen();
            }
        });

    }

    function populateSelectDeviceById() {
        var param = "{'ms_room_id':" + JSON.stringify($("#cbroom").val()) + "}";
        $selectDevice = $("#cbdevice");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadDeviceByMsTempRoom',
            data: param,
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                //clear 
                $selectDevice.html('');
                $selectDevice.append('<option value="">Choose a Device</option>');
                //append a select option

                if (jsonobject.length > 0) {
                    $.each(jsonobject, function (key, val) {
                        $selectDevice.append('<option value="' + val.id + '">' + val.serial_no + '</option>');
                        $selectDevice.trigger("chosen:updated");//update select option
                    })
                }
                else {

                    $selectDevice.html('');
                    $selectDevice.append('<option value="">Choose a Device</option>');
                    $selectDevice.trigger("chosen:updated");//update select option
                }

                $selectDevice.chosen();

            }
        });


    }

    function populateSelectDeviceById_ctr() {
        var param = "{'ms_room_id':" + JSON.stringify($("#cbroom_ctr").val()) + "}";
        $selectDevice = $("#cbdevice_ctr");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadDeviceByMsTempRoom',
            data: param,
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                //clear 
                $selectDevice.html('');
                $selectDevice.append('<option value="">All</option>');
                //append a select option

                if (jsonobject.length > 0) {
                    $.each(jsonobject, function (key, val) {
                      
                        $selectDevice.append('<option value="' + val.id + '">' + val.serial_no + '</option>');
                        $selectDevice.trigger("chosen:updated");//update select option
                    })
                }
                else {

                    $selectDevice.html('');
                    $selectDevice.append('<option value="">All</option>');
                    $selectDevice.trigger("chosen:updated");//update select option
                }

                $selectDevice.chosen();

            }
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
            if (result.d == "NOTFOUNDTEMPFILE") {
                onAlert("file not found.");
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
        $("#lblvalidRoom").hide();
        $("#lblvalidDevice").hide();
        $("#lblvalid_data").hide();
    }

    //Check Valid
    function onValid() {
        var isValid;
        isValid = true;
        var device = $("#cbdevice").val();
        var jsonobject = localStorage['data'];
        
        if (device == '') {
            $("#lblvalidDevice").show();
            isValid = false;
        } else {
            $("#lblvalidDevice").hide();
        }

        if (jsonobject == '[]') {
            $("#lblvalid_data").show();
            isValid = false;
        } else {
            $("#lblvalid_data").hide();
        }
        return isValid;
    }

    function clearInput() {
       localStorage['data'] = '[]';
       $("#txtfilename").val(""); 
        populateSelect();
        populateSelectDeviceById();
        ClearDataFromFile();
    }

    function clearInput_Ctr() {
        $("#txtDateFrom").val("");
        $("#txtDateEnd").val("");
        $("#txtHumidityFrom").val("");
        $("#txtHumidityTo").val("");
        $("#txtTemperatureFrom").val("");
        $("#txtTemperatureTo").val("");

        populateSelect_ctr();
        populateSelectDeviceById_ctr();
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

