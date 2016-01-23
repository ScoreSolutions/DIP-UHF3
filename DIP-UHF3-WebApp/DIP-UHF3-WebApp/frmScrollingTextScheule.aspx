<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmScrollingTextScheule.aspx.vb" Inherits="frmScollingTextScheule" %>

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
                <li class="active">Scrolling Text Schedule</li>
            </ul>

        </div>

        <div class="page-content">


            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">Scrolling Text Schedule</h3>

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
                    <div id="dialog-grid">
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
                                    <label class="control-label" id="lblScollingText">Scolling Text</label>
                                </div>
                                <div class="span10">
                                    <input type="text" class="input-mini" id="txtScollingText" style="width: 385px;" maxlength="255" />
                                    <span class="help-inline color red" id="lblvalidScollingText" style="display: none">This field is required</span>
                                </div>

                            </div>
                        </div>
                      
                      <%--  <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblSinageContent">Sinage Content</label>
                                </div>
                                <div class="span10">
                                    <select id="cbSinageContent" data-placeholder="Choose a Sinage Content..." style="width: 400px"></select>
                                    <span class="help-inline color red" id="lblvalid_SinageContent" style="display: none">This field is required</span>
                                </div>

                            </div>
                        </div>--%>
                     
                        <div class="row-fluid">
                            <div class="span12">

                                <div class="span2">
                                    <label class="control-label" id="lblLEDTV">LED TV</label>
                                </div>
                                <div class="span10">
                                    <select id="cbLEDTV" data-placeholder="Choose a LED TV..." style="width: 400px"></select>
                                    <span class="help-inline color red" id="lblvalid_LEDTV" style="display: none">This field is required</span>
                                </div>

                            </div>
                        </div>
                      
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblStart">Start</label>
                                </div>
                                <div class="span2 input-append">
                                    <input class="date-picker width-55" id="txtDateFrom" type="text" data-date-format="dd/mm/yyyy" />
                                    <span class="add-on">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                                <div class="span2" style="margin: 0px;">
                                    <div class="input-append bootstrap-timepicker">
                                        <input id="txtTimepickerstart" type="text" class="input-small width-50" />
                                        <span class="add-on">
                                            <i class="icon-time"></i>
                                        </span>
                                    </div>
                                   
                                </div>
                                <div class="span2">
                                    <span class="help-inline color red" id="lblvalidDateTimepickerstart" style="display: none">This field is required</span>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblEnd">End</label>
                                </div>
                                <div class="span2 input-append">
                                    <input class="date-picker width-55" id="txtDateEnd" type="text" data-date-format="dd/mm/yyyy" />
                                    <span class="add-on">
                                        <i class="icon-calendar"></i>
                                    </span>
                                </div>
                                <div class="span2" style="margin: 0px;">
                                    <div class="input-append bootstrap-timepicker">
                                        <input id="txtTimepickerend" type="text" class="input-small width-50" />
                                        <span class="add-on">
                                            <i class="icon-time"></i>
                                        </span>
                                    </div>
                                   
                                </div>
                                <div class="span2">
                                     <span class="help-inline color red" id="lblvalidDateTimepickerstop" style="display: none">This field is required</span>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblTextSpeed">Speed Level</label>
                                </div>
                                <div class="span10">
                                    <select id="cbTextSpeed" style="width: 272px;"></select>
                                    <span class="help-inline color red" id="lblvalid_TextSpeed" style="display: none">Text Speed is required</span>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblActive">Active</label>
                                </div>
                                <div class="span10">
                                    <div class="controls" id="divActive">
                                        <label class="inline">
                                            <input name="ckbActive" type="checkbox" id="ckbActive" />
                                        
                                        </label>

                                    </div>
                                    
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" id="lblSchedule">Schedule</label>
                            </div>
                            <div class="span10">
                                 <span class="help-inline color red" id="lblvalidScgeduleDetail" style="display: none">Please specify scedule detail.</span>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="border-top-width: 1px; border-left-width: 1px; border-bottom-width: 1px; border-top-style: solid; border-left-style: solid; border-bottom-style: solid; border-top-color: gray; border-left-color: gray; border-bottom-color: gray; height: 120px; width: 300px; padding-left: 10px; padding-top: 10px; margin: 0px;">                           
                                    <div class="control-group">
											<div class="controls">
												<label>
													<input name="form-field-radio" type="radio" id="rdDaily" checked="checked"/>
													<span > Daily</span>
												</label>
												<label>
													<input name="form-field-radio" type="radio"  id="rdWeekly"/>
													<span > Weekly</span>
												</label>
												<label>
													<input name="form-field-radio" type="radio"  id="rdMonthly"/>
													<span > Monthly</span>
												</label>
											</div>
									</div>
                            </div>
                            <div class="span6" style="border-width: 1px; border-style: solid; border-color: gray; height: 120px; width: 600px; padding-left: 10px; padding-top: 10px; margin: 0px;">
                               <div id="dialy" >
                                   <div class="span12">
                                       <div class="span2">
                                           <label class="control-label" id="lblDailyRecurEvery">Recur every :</label>
                                       </div>
                                       <div class="span2">
                                          <input type="text" id="txtDailyDay" style="width: 60px" onkeypress="return Numbers(event)" maxlength="5">
                                       </div>
                                        <div class="span7">
                                           <label class="control-label" id="lblDailyDay"> days</label>
                                       </div>
                                     
                                   </div>
                               </div>
                                <div id="Weekly">
                                    <div class="row-fluid">
                                        <div class="span12">
                                            <div class="span2">
                                                <label class="control-label" id="lblWeeklyRecurEvery">Recur every :</label>
                                            </div>
                                            <div class="span2">
                                                <input type="text" id="txtWeeklyOn" style="width: 60px" onkeypress="return Numbers(event)" maxlength="5">
                                            </div>
                                            <div class="span7">
                                                <label class="control-label" id="lblWeeklyOn">Weekly On :</label>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row-fluid">
                                        <div class="span12">
                                            <div class="span3">
                                                <div class="controls">
                                                    <label class="inline">
                                                        <input name="ckbSunday" type="checkbox" id="ckbSunday" />
                                                        
                                                        <span>Sunday</span>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="span3">
                                                <div class="controls">
                                                    <label class="inline">
                                                        <input name="ckbMonday" type="checkbox" id="ckbMonday" />
                                                        <span>Monday</span>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="span3">
                                                <div class="controls">
                                                    <label class="inline">
                                                        <input name="ckbTuesday" type="checkbox" id="ckbTuesday" />
                                                        <span>Tuesday</span>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="span3">
                                                <div class="controls">
                                                    <label class="inline">
                                                        <input name="ckbWednesday" type="checkbox" id="ckbWednesday" />
                                                        <span >Wednesday</span>
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span12">
                                            <div class="span3">
                                                <div class="controls">
                                                    <label class="inline">
                                                        <input name="ckbThursday" type="checkbox" id="ckbThursday" />
                                                        <span>Thursday</span>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="span3">
                                                <div class="controls">
                                                    <label class="inline">
                                                        <input name="ckbFriday" type="checkbox" id="ckbFriday" />
                                                        <span>Friday</span>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="span3">
                                                <div class="controls">
                                                    <label class="inline">
                                                        <input name="ckbSaturday" type="checkbox" id="ckbSaturday" />
                                                        <span>Saturday</span>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="span3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="Monthly">
                                    <div class="row-fluid">
                                        <div class="span12">
                                        <div class="span2">
                                            <label class="control-label" id="lblMonth">Month :</label>
                                        </div>
                                        <div class="span10" >
                                            <select  id="cbMonths" multiple="multiple" data-placeholder="Choose Months..." style="width: 350px">
                                            </select>
                                        </div>
                                    </div>
                                    </div>
                                    <div class="space-2" ></div>
                                    <div class="row-fluid">
                                        <div class="span12">
                                            <div class="span2">
                                                <label class="control-label" id="lblDays">Days :</label>
                                            </div>
                                            <div class="span10">
                                                <select id="cbDays" multiple="multiple" data-placeholder="Choose Days..." style="width: 350px;">
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    
                               </div>
                            </div>
                        </div>
                     

                        <div class="span-2"></div>
                         <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" id="lblScheduleTime">Schedule Time</label>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="span2">
                                    <label class="control-label" id="lblFrom">From</label>
                                </div>
                                <div class="span2" style="margin:0px">
                                     <div class="input-append bootstrap-timepicker">
                                        <input id="txtTimeScheduleStart" type="text" class="input-small width-50" />
                                        <span class="add-on">
                                            <i class="icon-time"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="span1" style="margin:0px">
                                    <label class="control-label" id="lblTo2">To</label>
                                </div>
                                <div class="span2" style="margin:0px">
                                     <div class="input-append bootstrap-timepicker">
                                        <input id="txtTimeScheduleEnd" type="text" class="input-small width-50" />
                                        <span class="add-on">
                                            <i class="icon-time"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="span2" style="margin:0px">
                                    <button class="btn btn-small btn-success" id="btnAddTime" name="btnAdd">
                                        <%--<i class=" icon-plus"></i>--%>
                                        Save 
                                    </button>
                                </div>
                            </div>
                        </div>
                         <div class="row-fluid">
                             <div class="span12">
                                 <span class="help-inline color red" id="lblvalidTime" style="display: none">Please specify time</span>
                                 <span class="help-inline color red" id="lblvalidTimeFormat" style="display: none">Schedule time is wrong.</span>
                                 <span class="help-inline color red" id="lblvalidTimePeriod" style="display: none">Can't save this time.</span>
                             </div>
                         </div>
                       
                        <div class="row-fluid">
                            <div class="span8">
                                <table class="table table-striped table-bordered table-hover" id="dt_outtime"></table>
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
        LoadData();

        localStorage['schedultime'] = '';


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

        $("#btnAddTime").click(function () {
            AddTimeClick();
        });

        //ปฎิธิน
        $('.date-picker').datepicker({ "autoclose": true }).next().on(ace.click_event, function () {
            $(this).prev().focus();
        });

        //time
        $("#txtTimepickerstart").timepicker({
            minuteStep: 1,
            showSeconds: false,
            showMeridian: false
        });
        //time
        $("#txtTimepickerend").timepicker({
            minuteStep: 1,
            showSeconds: false,
            showMeridian: false
        });
        //time
        $("#txtTimeScheduleStart").timepicker({
            minuteStep: 1,
            showSeconds: false,
            showMeridian: false
        });
        //time
        $("#txtTimeScheduleEnd").timepicker({
            minuteStep: 1,
            showSeconds: false,
            showMeridian: false
        });

        $('#cbSinageContent').change(function () {
            populateSelectLEDTVById();
        });


        $("#rdDaily").change(function () {
            $("#dialy").show();
            $("#Weekly").hide();
            $("#Monthly").hide();
        });
        $("#rdWeekly").change(function () {
            $("#dialy").hide();
            $("#Weekly").show();
            $("#Monthly").hide();
        });
        $("#rdMonthly").change(function () {
            $("#dialy").hide();
            $("#Weekly").hide();
            $("#Monthly").show();
        });


        //Hide div or other
        $("#dialog-edit").hide();
        $("#btnBack").hide();

        $("#dialy").show();
        $("#Weekly").show();
        $("#Monthly").show();
        $("#Weekly").hide();
        $("#Monthly").hide();


    });
</script>

<script type="text/javascript">
    //function AddTimeClick() {
    //    var ret = onValidTime();
    //    if (ret == true) {
    //        var id = $('#HiddenTimeId').val();
    //        onSaveTime(id);
    //    }
    //    return false;
    //}
    //Call
    function LoadData() {
        var dataurl = 'WebService/WebService.asmx/LoadScrollingTextScheduleAll';
        $.ajax({
            "type": "POST",
            "dataType": 'json',
            "contentType": "application/json; charset=utf-8",
            "url": dataurl,
            "success": PopulateGrid,
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
                            "sTitle": "Scrolling Text",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "scrolling_text"

                        },
                        {
                            "sTitle": "LED TV",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "tv_name"

                        },
                       {
                           "sTitle": "Floor Name",
                           "sType": "string",
                           "sDefaultContent": "",
                           "mDataProp": "floor_name"

                       },
                        {
                            "sTitle": "Trigger",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "trigger"

                        },
                        {
                            "sTitle": "Active",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "active_status"

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
            { "sWidth": "20%", "aTargets": [1] },
            { "sWidth": "15%", "aTargets": [2] },
            { "sWidth": "10%", "aTargets": [3] },
            { "sWidth": "30%", "aTargets": [4] },
            { "sWidth": "10%", "aTargets": [5] },
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
            url: "WebService/WebService.asmx/LoadScrollingTextScheduleID",
            data: param,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var strvalue = JSON.parse(data.d);

                if (strvalue.length == 1) {
                    $("#HiddenId").val(strvalue[0].id);
                    $("#txtScollingText").val(strvalue[0].scrolling_text);
                    $("#cbLEDTV").val(strvalue[0].ms_led_tv_id);
                    $("#txtDateFrom").val(strvalue[0].start_date);
                    $("#txtTimepickerstart").val(strvalue[0].start_time);
                    $("#txtDateEnd").val(strvalue[0].end_date);
                    $("#txtTimepickerend").val(strvalue[0].end_time);

                    populateSelect(strvalue[0].id);
                    populateSelectTextSpeed(strvalue[0].speed_level);
                    if (strvalue[0].active_status == "Y") {
                        $("#ckbActive").prop("checked", true);
                    } else {
                        $("#ckbActive").prop("checked", false);
                    }

                    localStorage['schedultime'] = '';
                    LoadSchedultime(strvalue[0].id)
                    LoadSchedul(strvalue[0].id);

                    if (strvalue[0].schedule_type == 'D') {
                        $("#rdDaily").prop("checked", true);
                        $("#rdWeekly").prop("checked", false);
                        $("#rdMonthly").prop("checked", false);
                        $("#dialy").show();
                        $("#Weekly").hide();
                        $("#Monthly").hide();
                    } else if (strvalue[0].schedule_type == 'W') {
                        $("#rdDaily").prop("checked", false);
                        $("#rdWeekly").prop("checked", true);
                        $("#rdMonthly").prop("checked", false);
                        $("#dialy").hide();
                        $("#Weekly").show();
                        $("#Monthly").hide();
                    } else if (strvalue[0].schedule_type == 'M') {
                        $("#rdDaily").prop("checked", false);
                        $("#rdWeekly").prop("checked", false);
                        $("#rdMonthly").prop("checked", true);
                        $("#dialy").hide();
                        $("#Weekly").hide();
                        $("#Monthly").show();
                    }


                } else {
                    clearInput();
                    $("#HiddenId").val(0);
                }
            },
            error: function (data) {
            }
        });

    }

    function LoadSchedul(id) {
        var param = "{'ms_text_scrolling_schedule_id':" + JSON.stringify(id) + "}";
        $.ajax({
            type: "POST",
            url: "WebService/WebService.asmx/LoadScrollingTextScheduleDailyByScheduleID",
            data: param,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var strvalue = JSON.parse(data.d);

                if (strvalue.length == 1) {
                    $("#txtDailyDay").val(strvalue[0].recur_every_days);
                } else {
                    $("#txtDailyDay").val('');
                }
            },
            error: function (data) {
            }
        });

        $.ajax({
            type: "POST",
            url: "WebService/WebService.asmx/LoadScrollingTextScheduleWeeklyByScheduleID",
            data: param,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var strvalue = JSON.parse(data.d);

                if (strvalue.length == 1) {
                    $("#txtWeeklyOn").val(strvalue[0].recur_every_week);
                    if (strvalue[0].sch_sun == "Y") {
                        $("#ckbSunday").prop("checked", true);
                    } else {
                        $("#ckbSunday").prop("checked", false);
                    }

                    if (strvalue[0].sch_mon == "Y") {
                        $("#ckbMonday").prop("checked", true);
                    } else {
                        $("#ckbMonday").prop("checked", false);
                    }

                    if (strvalue[0].sch_tue == "Y") {
                        $("#ckbTuesday").prop("checked", true);
                    } else {
                        $("#ckbTuesday").prop("checked", false);
                    }

                    if (strvalue[0].sch_wed == "Y") {
                        $("#ckbWednesday").prop("checked", true);
                    } else {
                        $("#ckbWednesday").prop("checked", false);
                    }

                    if (strvalue[0].sch_thu == "Y") {
                        $("#ckbThursday").prop("checked", true);
                    } else {
                        $("#ckbThursday").prop("checked", false);
                    }

                    if (strvalue[0].sch_fri == "Y") {
                        $("#ckbFriday").prop("checked", true);
                    } else {
                        $("#ckbFriday").prop("checked", false);
                    }

                    if (strvalue[0].sch_sat == "Y") {
                        $("#ckbSaturday").prop("checked", true);
                    } else {
                        $("#ckbSaturday").prop("checked", false);
                    }

                } else {
                    $("#txtWeeklyOn").val('');
                    $("#ckbSunday").prop("checked", false);
                    $("#ckbMonday").prop("checked", false);
                    $("#ckbTuesday").prop("checked", false);
                    $("#ckbWednesday").prop("checked", false);
                    $("#ckbThursday").prop("checked", false);
                    $("#ckbFriday").prop("checked", false);
                    $("#ckbSaturday").prop("checked", false);
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
            var scrolling_text = $('#txtScollingText').val();
            var ms_led_tv_id = $("#cbLEDTV").val();
            var start_date = $("#txtDateFrom").val();
            var end_date = $("#txtDateEnd").val();
            var start_time = $("#txtTimepickerstart").val();
            var end_time = $("#txtTimepickerend").val();
            var active_status = $('input[name="ckbActive"]:checked').length;
            var daily = $("#rdDaily").is(":checked")
            var weekly = $("#rdWeekly").is(":checked")
            var monthly = $("#rdMonthly").is(":checked")
            var recur_every_days = $("#txtDailyDay").val();
            var recur_every_week = $("#txtWeeklyOn").val();
            var sch_sun = $('input[name="ckbSunday"]:checked').length;
            var sch_mon = $('input[name="ckbMonday"]:checked').length;
            var sch_tue = $('input[name="ckbTuesday"]:checked').length;
            var sch_wed = $('input[name="ckbWednesday"]:checked').length;
            var sch_thu = $('input[name="ckbThursday"]:checked').length;
            var sch_fri = $('input[name="ckbFriday"]:checked').length;
            var sch_sat = $('input[name="ckbSaturday"]:checked').length;
            var speed_level = $("#cbTextSpeed").val();

            var month_no = '';
            $("#cbMonths>option:selected").each(function () {
                month_no += $(this).val() + ',';
            });

            var date_no = '';
            $("#cbDays>option:selected").each(function () {
                date_no += $(this).val() + ',';
            });

            var jsonobject_time = localStorage['schedultime'];

            var param = "{'id':" + JSON.stringify(id)
                + ",'scrolling_text':" + JSON.stringify(scrolling_text)
                + ",'ms_led_tv_id':" + JSON.stringify(ms_led_tv_id)
                + ",'start_date':" + JSON.stringify(start_date)
                + ",'end_date':" + JSON.stringify(end_date)
                + ",'start_time':" + JSON.stringify(start_time)
                + ",'end_time':" + JSON.stringify(end_time)
                + ",'active_status':" + JSON.stringify(active_status)
                + ",'daily':" + JSON.stringify(daily)
                + ",'weekly':" + JSON.stringify(weekly)
                + ",'monthly':" + JSON.stringify(monthly)
                + ",'recur_every_days':" + JSON.stringify(recur_every_days)
                + ",'recur_every_week':" + JSON.stringify(recur_every_week)
                + ",'sch_sun':" + JSON.stringify(sch_sun)
                + ",'sch_mon':" + JSON.stringify(sch_mon)
                + ",'sch_tue':" + JSON.stringify(sch_tue)
                + ",'sch_wed':" + JSON.stringify(sch_wed)
                + ",'sch_thu':" + JSON.stringify(sch_thu)
                + ",'sch_fri':" + JSON.stringify(sch_fri)
                + ",'sch_sat':" + JSON.stringify(sch_sat)
                + ",'month_no':" + JSON.stringify(month_no)
                + ",'date_no':" + JSON.stringify(date_no)
                + ",'speed_level':" + JSON.stringify(speed_level)
                + ",'jsonobject_time':" + JSON.stringify(jsonobject_time)
                + ",'login_username':" + JSON.stringify(login_username) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveScrollingTextSchedule",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onSuccess,
                error: onFailed
            });
        }

    function populateSelect(ms_text_scrolling_schedule_id) {

            var strselect;
            var param = "{'ms_text_scrolling_schedule_id':" + JSON.stringify(ms_text_scrolling_schedule_id) + "}";
            $selectMonths = $("#cbMonths");
            $selectTempMonths = $("#tempmonths");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadMonthByScrollingTextSchedule',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    var countall = 1;
                    var countrow = 0;
                    $selectMonths.html('');
                    var strselectmonth = [];
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            if (val.selected != "") {
                                strselectmonth.push(val.id);
                            }
                            //alert(strselect);
                            $selectMonths.append('<option value="' + val.id + '" ' + '>' + val.monthsthai + '</option>');
                        })
                    }
                    else {
                        $selectMonths.html('');
                    }

                    $selectMonths.multiselect({
                        maxHeight: 200,
                        includeSelectAllOption: true, //select all
                        numberDisplayed: 5,//number display
                        selectAllText: 'Select All' // text select all
                    });

                    $selectMonths.multiselect('select', strselectmonth);


                }
            });

            $selectDays = $("#cbDays");
            //$selectTempMonths = $("#tempmonths");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadDayByScrollingTextSchedule',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    var countall = 1;
                    var countrow = 0;
                    $selectDays.html('');
                    var strselectday = [];
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            if (val.selected != "") {
                                strselectday.push(val.d);
                            }
                            $selectDays.append('<option value="' + val.d + '" ' + '>' + val.d + '</option>');
                        })
                    }
                    else {
                        $selectDays.html('');
                    }
                    $selectDays.multiselect({
                        maxHeight: 200,
                        includeSelectAllOption: true, //select all
                        numberDisplayed: 5,//number display
                        selectAllText: 'Select All' // text select all
                    });
                    $selectDays.multiselect('select', strselectday);
                }
            });

            

            //var param = "{'desktop_id':" + JSON.stringify(desktop_id) + "}";
            $selectLEDTV = $("#cbLEDTV");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadLEDTVByScrollingTextSchedule',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectLEDTV.html('');
                    $selectLEDTV.append('<option value="">Choose a LED TV</option>');
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectLEDTV.append('<option value="' + val.id + '" ' + strselect + '>' + val.tv_name + '</option>');
                            $selectLEDTV.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectLEDTV.html('');
                        $selectLEDTV.append('<option value="">Choose a LED TV</option>');
                        $selectLEDTV.trigger("chosen:updated");//update select option
                    }

                    $selectLEDTV.chosen();
                }
            });


        }

    function populateSelectTextSpeed(text_speed) {
        var param = "{'text_speed':" + JSON.stringify(text_speed) + "}";
        $selectTextSpeed = $("#cbTextSpeed");
        $.ajax({
            type: "POST",
            url: 'WebService/WebService.asmx/LoadTextSpeedLevel',
            data: param,
            dataType: 'JSON',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var jsonobject = JSON.parse(data.d);
                //clear 
                $selectTextSpeed.html('');
                $selectTextSpeed.append('<option value="">Choose a Speed Level...</option>');
                $selectTextSpeed.trigger("chosen:updated");//update select option
                //append a select option
                if (jsonobject.length > 0) {
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (val.selected != "") {
                            strselect = ' selected="' + val.selected + '"';
                        }
                        $selectTextSpeed.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                        $selectTextSpeed.trigger("chosen:updated");//update select option
                    })
                }
                else {

                    $selectTextSpeed.html('');
                    $selectTextSpeed.append('<option value="">Choose a Speed Level...</option>');
                    $selectTextSpeed.trigger("chosen:updated");//update select option
                }

                $selectTextSpeed.chosen();
            }
        });

    }

        //Delete 
        function onDelete(id) {
            var param = "{'id':" + JSON.stringify(id) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/DeleteScollingTextSchedule",
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
                if (result.d == "DUPLICATESCROLLINGTEXT") {
                    onAlert("Scrolling Text already exists. Please modify Scrolling Text");
                    LoadData();
                }
                else {
                    var data = result.d;
                    var arr = data.split('|');

                    if (arr[0] == "DUPLICATESCHEDULETIME") {
                        onAlert("This schedule time can't save. [" + arr[1] + "]");
                        LoadData();
                    } else {
                        onAlert("Save Fail");
                    }

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
            $("#lblvalidScollingText").hide();
            $("#lblvalid_LEDTV").hide();
            $("#lblvalidDateTimepickerstart").hide();
            $("#lblvalidDateTimepickerstop").hide();
            $("#lblvalidScgeduleDetail").hide();
            $("#lblvalid_TextSpeed").hide();
        }

        //Check Valid
        function onValid() {

            var isValid;
            isValid = true;
            var ScrollingText = $('#txtScollingText').val();
            var LEDTV = $("#cbLEDTV").val();
            var DateForm = $("#txtDateFrom").val();
            var DateEnd = $("#txtDateEnd").val();
            var start_time = $("#txtTimepickerstart").val();
            var end_time = $("#txtTimepickerend").val();
            var daily = $("#rdDaily").is(":checked")//$('input[name="rdDaily"]:checked').length;
            var weekly = $("#rdWeekly").is(":checked")//$('input[name="rdWeekly"]:checked').length;
            var monthly = $("#rdMonthly").is(":checked")//$('input[name="rdMonthly"]:checked').length;
            var every_day = $("#txtDailyDay").val();
            var every_week = $("#txtWeeklyOn").val();
            var months = $("#cbMonths").val();
            var days = $("#cbDays").val();
            var speed_level = $("#cbTextSpeed").val();

            $("#lblvalidTimePeriod").hide();
            $("#lblvalidTimeFormat").hide();

            if (ScrollingText == '') {
                $("#lblvalidScollingText").show();
                isValid = false;
            } else {
                $("#lblvalidScollingText").hide();
            }

            if (LEDTV == '') {
                $("#lblvalid_LEDTV").show();
                isValid = false;
            } else {
                $("#lblvalid_LEDTV").hide();

            }

            if ((DateForm == '') || (start_time == '')) {
                $("#lblvalidDateTimepickerstart").show();
                isValid = false;
            } else {
                $("#lblvalidDateTimepickerstart").hide();
            }

            if ((DateEnd == '') || (end_time == '')) {
                $("#lblvalidDateTimepickerstop").show();
                isValid = false;
            } else {
                $("#lblvalidDateTimepickerstop").hide();
            }

            if (speed_level == '') {
                $("#lblvalid_TextSpeed").show();
                isValid = false;
                return;
            } else {
                $("#lblvalid_TextSpeed").hide();
            }

            if (localStorage['schedultime'] == '[]') {
                $("#lblvalidTime").show();
                isValid = false;
            } else {
                $("#lblvalidTime").hide();
            }


            if ((daily == false) && (weekly == false) && (monthly == false)) {
                $("#lblvalidScgeduleDetail").show();
                isValid = false;
            } else {
                $("#lblvalidScgeduleDetail").hide();
            }


            if (daily == true) {
                if (every_day == '') {
                    $("#lblvalidScgeduleDetail").show();
                    isValid = false;
                } else {
                    $("#lblvalidScgeduleDetail").hide();
                }
            }

            if (weekly == true) {
                if (every_week == '') {
                    $("#lblvalidScgeduleDetail").show();
                    isValid = false;
                } else {
                    $("#lblvalidScgeduleDetail").hide();
                }
            }

            if (monthly == true) {
                if ((months == '') || (days == '')) {
                    $("#lblvalidScgeduleDetail").show();
                    isValid = false;
                } else {
                    $("#lblvalidScgeduleDetail").hide();
                }
            }


            return isValid;
        }


        function clearInput() {
            localStorage['schedultime'] = '';
            $("#txtScollingText").val("");
            $("#txtDateFrom").val("");
            $("#txtTimepickerstart").val("");
            $("#txtDateEnd").val("");
            $("#txtTimepickerend").val("");
            $("#cbLEDTV").val("");
            $("#ckbActive").prop("checked", true);
            $("#rdDaily").prop("checked", true);
            $("#rdWeekly").prop("checked", false);
            $("#rdMonthly").prop("checked", false);
            $("#txtDailyDay").val("");
            $("#txtWeeklyOn").val("");
            $("#ckbSunday").prop("checked", false);
            $("#ckbMonday").prop("checked", false);
            $("#ckbTuesday").prop("checked", false);
            $("#ckbWednesday").prop("checked", false);
            $("#ckbThursday").prop("checked", false);
            $("#ckbFriday").prop("checked", false);
            $("#ckbSaturday").prop("checked", false);
            $("#cbMonths").val("");
            $("#cbDays").val("");
            $("#txtTimeScheduleStart").val("");
            $("#txtTimeScheduleEnd").val("");
            $("#dialy").show();
            $("#Weekly").hide();
            $("#Monthly").hide();
            populateSelect(0);
            populateSelectTextSpeed(0);
            LoadSchedultime(0)
            LoadSchedul(0);
        }

    </script>

 <%--schedul time--%>
<input id="HiddenTimeId" value="0" type="hidden" />
<input id="HiddenTemp" value="0" type="hidden" />
<script type="text/javascript">

    function AddTimeClick() {
        var ret = onValidTime();
        if (ret == true) {

            onValidTimePeriod();

        }
        return false;
    }

    function onSaveTime(id) {
        var time_from = $('#txtTimeScheduleStart').val();
        var time_to = $('#txtTimeScheduleEnd').val();

        //running no
        var rows = $("#dt_outtime").dataTable().fnGetNodes();

        //data in current session
        var jsonobject = JSON.parse(localStorage['schedultime']);
        var aaData = [];
        aaData = jsonobject;
        //add data in current session

        if (id == 0) {
            aaData.push({
                "no": parseInt(rows.length) + 1,
                "id": parseInt(rows.length) + 1,
                "strtime": time_from + '-' + time_to
            });

        } else {//edit data in current session
            for (var i = 0; i < aaData.length; i++) {
                if (aaData[i].id == id) {
                    aaData[i].strtime = time_from + '-' + time_to;
                    break;
                }
            }

        }

        //update data in session
        localStorage['schedultime'] = JSON.stringify(aaData);

        // Reload
        LoadSchedultime(0);
        clearTime();
    }

    function clearTime() {
        $('#txtTimeScheduleStart').val("");
        $('#txtTimeScheduleEnd').val("");
        $('#HiddenTimeId').val("");
    }

    function LoadSchedultime(id) {
        var param = "{'ms_text_scrolling_schedule_id':" + JSON.stringify(id) + "}";
        var dataurl = 'WebService/WebService.asmx/LoadScrollingTextScheduleTimeByScheduleID';
        $.ajax({
            "type": "POST",
            "dataType": 'json',
            "contentType": "application/json; charset=utf-8",
            "url": dataurl,
            "data": param,
            "success": PopulateGridSchedultime
        });
    }

    function PopulateGridSchedultime(jsondata) {
        var jsonobject = JSON.parse(jsondata.d);
        var yetVisited = localStorage['schedultime'];
        if (yetVisited.length > 0) {

        }
        else {
            localStorage['schedultime'] = jsondata.d;
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
                            "sTitle": "Schedule Time",
                            "sType": "string",
                            "sDefaultContent": "",
                            "mDataProp": "strtime"

                        },
                        {
                            "sTitle": "Action",
                            "bSortable": false,
                            "fnRender": function (obj) {
                                return '<div class="hidden-phone visible-desktop action-buttons">'
                                        + '&nbsp;'
                                        + '<a href="#"   class="Green"  title="Edit" onClick="onEditTime(' + obj.aData.id + '); return false;">'
                                        + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                        + '</a>'
                                        + '&nbsp;'
                                        + '<a href="#"   class="Red"  title="Delete" onclick="onConfirmDeleteTime(' + obj.aData.no + '); return false;" >'
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
                                        + '						<a href="#"    class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEditTime(' + obj.aData.id + '); return false;">'
                                        + '							<span class="green">'
                                        + '								<i class="icon-edit bigger-120"></i>'
                                        + '							</span>'
                                        + '						</a>'
                                        + '					</li>'
                                        + ''
                                        + '					<li>'
                                        + '						<a href="#"   class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDeleteTime(' + obj.aData.no + '); return false;">'
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

        var aaData = getDataTime();
        oTable = $('#dt_outtime').dataTable({
            "aaData": aaData,
            "bAutoWidth": false,
            "aoColumnDefs": [
            { "sWidth": "10%", "aTargets": [0] },
            { "sWidth": "60%", "aTargets": [1] },
            { "sWidth": "20%", "aTargets": [2] }
            ],
            "aoColumns": columns,
            "bDestroy": true,
            "fnDrawCallback": function () {

            }

        });
    }

    function getDataTime() {
        var jsonobject = JSON.parse(localStorage['schedultime']);
        var aaData = [];
        aaData = jsonobject;
        return aaData;
    }

    function onEditTime(id) {

        onValidTimeHide();
        //Find data in current session
        if (id > 0) {
            var jsonobject = JSON.parse(localStorage['schedultime']);
            var editjsonobject = getObjects(jsonobject, 'id', id);
            $.each(editjsonobject, function (key, val) {
                var data = val.strtime;
                var arr = data.split('-');
                $('#HiddenTimeId').val(val.id);
                $('#txtTimeScheduleStart').val(arr[0]);
                $('#txtTimeScheduleEnd').val(arr[1]);
            })

        } else {
            clearTime();

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

    function deleteDataTime(no) {
        var jsonobject = JSON.parse(localStorage['schedultime']);
        var aaData = [];
        aaData = jsonobject;
        aaData.splice(parseInt(no) - 1, 1);
        //running inndex bew
        var icount = 1;
        $.each(aaData, function (key, val) {
            aaData[icount - 1].no = icount;
            icount = icount + 1
        })
        localStorage['schedultime'] = JSON.stringify(aaData);
        LoadSchedultime(0);
    }

    function onConfirmDeleteTime(id) {
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
                                deleteDataTime(id);
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

    function onValidTimeHide() {
        $("#lblvalidTime").hide();
        $("#lblvalidTimePeriod").hide();
        $("#lblvalidTimeFormat").hide();
    }

    function onValidTime() {
        var isValid;
        isValid = true;
        var TimeScheduleStart = $('#txtTimeScheduleStart').val();
        var TimeScheduleEnd = $("#txtTimeScheduleEnd").val();

        if (TimeScheduleStart == '') {
            $("#lblvalidTime").show();
            isValid = false;
            return;
        } else {
            $("#lblvalidTime").hide();
        }

        if (TimeScheduleEnd == '') {
            $("#lblvalidTime").show();
            isValid = false;
            return;
        } else {
            $("#lblvalidTime").hide();
        }

        if (TimeScheduleStart > TimeScheduleEnd) {
            $("#lblvalidTimeFormat").show();
            isValid = false;
            return;
        } else {
            $("#lblvalidTimeFormat").hide();
        }

        //data in current session
        var jsonobject = JSON.parse(localStorage['schedultime']);
        var aaData = [];
        aaData = jsonobject;
        //add data in current session

        var ret;
        for (var i = 0; i < aaData.length; i++) {
            var data = aaData[i].strtime;
            var arr = data.split('-');

            if ($('#HiddenTimeId').val() != aaData[i].id) {
                if (((arr[0] >= TimeScheduleStart) && (arr[0] <= TimeScheduleEnd)) || ((arr[1] >= TimeScheduleStart) && (arr[1] <= TimeScheduleEnd))) {
                    $("#lblvalidTimePeriod").show();
                    isValid = false;
                    return;
                } else {
                    $("#lblvalidTimePeriod").hide();
                }

                if ((arr[0] <= TimeScheduleStart) && (arr[0] >= TimeScheduleEnd)) {
                    $("#lblvalidTimePeriod").show();
                    isValid = false;
                    return;
                } else {
                    $("#lblvalidTimePeriod").hide();
                }

                if ((TimeScheduleStart <= arr[0]) && (TimeScheduleEnd >= arr[0])) {
                    $("#lblvalidTimePeriod").show();
                    isValid = false;
                    return;
                } else {
                    $("#lblvalidTimePeriod").hide();
                }
            }


        }


        return isValid;
    }

    function onValidTimePeriod() {

        var id = $("#HiddenId").val();
        var ms_led_tv_id = $("#cbLEDTV").val();
        var start_date = $("#txtDateFrom").val();
        var end_date = $("#txtDateEnd").val();
        var start_time = $("#txtTimepickerstart").val();
        var end_time = $("#txtTimepickerend").val();
        var TimeScheduleStart = $('#txtTimeScheduleStart').val();
        var TimeScheduleEnd = $("#txtTimeScheduleEnd").val();

        var param = "{'MsSignageTemplateScheduleID':" + JSON.stringify(id)
            + ",'MsLedTvID':" + JSON.stringify(ms_led_tv_id)
            + ",'start_date':" + JSON.stringify(start_date)
            + ",'end_date':" + JSON.stringify(end_date)
            + ",'start_time':" + JSON.stringify(start_time)
            + ",'end_time':" + JSON.stringify(end_time)
            + ",'CheckTimeFrom':" + JSON.stringify(TimeScheduleStart)
            + ",'CheckTimeTo':" + JSON.stringify(TimeScheduleEnd) + "}";

        var dataurl = 'WebService/WebService.asmx/CheckTextScheduleTime';
        $.ajax({
            "type": "POST",
            "dataType": 'json',
            "contentType": "application/json; charset=utf-8",
            "url": dataurl,
            "data": param,
            "success": function (obj) {
                //alert(1);
                $("#HiddenTemp").val(obj.d);
                if ($('#HiddenTemp').val() == "false") {
                    $("#lblvalidTimePeriod").hide();
                    var id = $('#HiddenTimeId').val();
                    onSaveTime(id);
                } else {
                    $("#lblvalidTimePeriod").show();
                }
            }
        });
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

