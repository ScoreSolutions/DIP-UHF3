<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmRFIDConfigSchedule.aspx.vb" Inherits="frmRFIDConfigSchedule" %>

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
                        <li class="active">RFID Config Schedule</li>
                    </ul>
                </div>

                <div class="page-content">
                    <div class="row-fluid">
                        <div class="span12">
                            <!--PAGE CONTENT BEGINS-->
                            <h3 class="header smaller lighter blue">RFID Config Schedule</h3>

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
                                 <br />
                                    <div>
                                        <h3 class="header smaller lighter blue">Reader</h3>
                                    </div>
                                <div class="row-fluid">
                                    <div class="span2">
                                        <label class="control-label" for="lblSerialNo">Serial No</label>
                                    </div>
                                    <div class="span4">
                                        <input type="text" id="txtSerialNo" style="width: 200px" maxlength="50">
                                        <span class="help-inline color red" id="lblvalidSerialNo" style="display: none">This field is required</span>
                                    </div>
                                    <div class="span2">
                                        <label class="control-label" for="lblReaderID">Reader ID</label>
                                    </div>
                                    <div class="span4">
                                       <%-- <label class="control-label" for="lblReaderID" style="background-color: gray; width: 210px; height: 27px;"></label>--%>
                                        <input type="text" id="lblReaderID" style="width: 200px; background-color:gray;" readonly="readonly" maxlength="50">
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span2">
                                        <label class="control-label" for="lblIPAddress">IP Address</label>
                                    </div>
                                    <div class="span4">
                                        <input type="text" id="txtIPAddress" style="width: 200px"  ">
                                        <span class="help-inline color red" id="lblvalidIPAddress" style="display: none">This field is required</span>
                                        <span class="help-inline color red" id="lblvalidIPAddressFormat" style="display: none">Invalid IP Address</span>
                                    </div>
                                    <div class="span2">
                                        <label class="control-label" for="lblInstallPosition">Install Position</label>
                                    </div>
                                    <div class="span4">
                                        <input type="text" id="txtInstallPosition" style="width: 200px">
                                        <span class="help-inline color red" id="lblvalidInstallPosition" style="display: none">This field is required</span>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span2">
                                        <label class="control-label" for="lblFloor">Floor</label>
                                    </div>
                                    <div class="span4">
                                        <select  id="cbfloor" data-placeholder="Choose a Floor..."  style="width: 213px">
                                        </select>
                                        <span class="help-inline color red" id="lblvalid_floor_id" style="display: none">This field is required</span>

                                    </div>

                                    <div class="span2">
                                        <label class="control-label" for="lblObjective">Objective</label>
                                    </div>
                                    <div class="span4">
                                        <select  id="cbobjective" data-placeholder="Choose a Objective..." style="width: 213px">
                                        </select>
                                        <span class="help-inline color red" id="lblvalid_objective" style="display: none">This field is required</span>
                                    </div>
                                </div>
                                <div class="space-2"></div>
                                <div class="row-fluid">

                                    <div class="span2">
                                        <label class="control-label" for="lblRoom">Room</label>
                                    </div>
                                    <div class="span4">
                                        <select  id="cbroom" data-placeholder="Choose a Room..." style="width: 213px">
                                        </select>
                                        <span class="help-inline color red" id="lblvalid_room_id" style="display: none">This field is required</span>
                                    </div>
                                    <div class="span2">
                                        <label class="control-label" id="lblActive">Active</label>
                                    </div>
                                    <div class="span4">
                                        <div class="controls">
                                            <label class="inline">
                                                <input name="ckbActive" type="checkbox" id="ckbActive" />
                                                <span >&nbsp;</span>
                                            </label>

                                        </div>
                                    </div>
                                </div>

                                <div class="row-fluid">
                                    <div class="span2">
                                        <label class="control-label" for="lblFTPUser">FTP User</label>
                                    </div>
                                    <div class="span4">
                                        <input type="text" id="txtFtpUser" style="width: 200px" maxlength="100">
                                        <span class="help-inline color red" id="lblvalidFtpUser" style="display: none">This field is required</span>
                                    </div>
                                    <div class="span2">
                                        <label class="control-label" for="lblFtpPassword">FTP Password</label>
                                    </div>
                                    <div class="span4">
                                        <input type="password" id="txtFtpPassword" style="width: 200px" maxlength="100">
                                        <span class="help-inline color red" id="lblvalidFtpPassword" style="display: none">This field is required</span>
                                    </div>
                                </div>
                                 <div class="row-fluid">
                                    <div class="span2">
                                        <label class="control-label" for="lblFTPPort">FTP Port</label>
                                    </div>
                                    <div class="span4">
                                        <input type="text" id="txtFtpPort" style="width: 200px" maxlength="5" onkeypress="return Numbers(event)">
                                        <span class="help-inline color red" id="lblvalidFtpPort" style="display: none">This field is required</span>
                                    </div>
                                    <div class="span2">
                                        <label class="control-label" for="lblFtpPath">FTP Path</label>
                                    </div>
                                    <div class="span4">
                                        <input type="text" id="txtFtpPath" style="width: 200px" maxlength="255">
                                        <span class="help-inline color red" id="lblvalidFtpPath" style="display: none">This field is required</span>
                                    </div>
                                </div>

                                <div class="row-fluid">
                                    <br />
                                  <%--  <div>
                                        <h3 class="header smaller lighter blue">Setting</h3>
                                    </div>--%>
                                     <div class="row-fluid">
                                        <div class="span12">
                                            <div class="span2">
                                                <label class="control-label" for="lblFTPDataPath">FTP Data Path</label>
                                            </div>
                                            <div class="span10">
                                                <input type="text" id="txtFTPDataPath" style="width: 392px">
                                                <span class="help-inline color red" id="lblvalidFTPDataPath" style="display: none">This field is required</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span12">

                                            <div class="span2">
                                                <label class="control-label" id="lblReaderBrandName">Brand Name</label>
                                            </div>
                                            <div class="span10">
                                                <input type="text" class="input-mini" id="txtReaderBrandName" style="width: 392px;" maxlength="255" />
                                                <span class="help-inline color red" id="lblvalid_ReaderBrandName" style="display: none">This field is required</span>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span12">

                                            <div class="span2">
                                                <label class="control-label" id="lblReaderModelName">Model Name</label>
                                            </div>
                                            <div class="span10">
                                                <input type="text" class="input-mini" id="txtReaderModelName" style="width: 392px;" maxlength="255" />
                                                <span class="help-inline color red" id="lblvalid_ReaderModelName" style="display: none">This field is required</span>
                                            </div>

                                        </div>
                                    </div>


                                    <div class="row-fluid">
                                        <div class="span12">

                                            <div class="span2">
                                                <label class="control-label" id="lblEvent">Event</label>
                                            </div>
                                            <div class="span10">
                                                <div class="control-group">
                                                    <div class="controls">
                                                        
                                                        <div class="row-fluid">
                                                            <div class="span2">
                                                                <label>
                                                                    <input name="form-field-radio" type="radio" id="rdNow" checked="checked" />
                                                                    <span>Now</span>
                                                                </label>
                                                            </div>
                                                            <div class="span8">
                                                            </div>
                                                        </div>

                                                        <div class="row-fluid">
                                                            <div class="span2" style="margin:0px;">
                                                                <label>
                                                                    <input name="form-field-radio" type="radio" id="rdSchedule" />
                                                                    <span>Schedule</span>
                                                                </label>
                                                            </div>
                                                            <div class="span8" style="margin:0px; vertical-align:top">
                                                                <div class="span2 input-append" style="margin:0px">
                                                                    <input class="date-picker width-90" id="txtSchedule" type="text" data-date-format="dd/mm/yyyy"  />
                                                                    <span class="add-on">
                                                                        <i class="icon-calendar"></i>
                                                                    </span>
                                                                </div>
                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                 <span class="help-inline color red" id="lblvalid_Schedule" style="display: none">This field is required</span>
                                                            </div>
                                                           
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>


                                    <div class="row-fluid">
                                        <div class="span12">

                                            <div class="span2">
                                                <label class="control-label" id="lblLabel">Label</label>
                                            </div>
                                            <div class="span10">
                                                <input type="text" class="input-mini" id="txtLabel" style="width: 392px;" maxlength="255" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span12">

                                            <div class="span2">
                                                <label class="control-label" id="lblDescription">Description</label>
                                            </div>
                                            <div class="span10">
                                               <%-- <input type="text" class="input-mini" id="txtDescription" style="width: 392px;" maxlength="255" />--%>
                                                <textarea id="txtDescription" placeholder="Description" style="width: 392px; height: 60px; resize: none;" maxlength="255"></textarea>
                                                <span class="help-inline color red" id="lblvalid_Description" style="display: none">*</span>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span12">

                                            <div class="span2">
                                                <label class="control-label" id="lblSearchMode">Search Mode</label>
                                            </div>
                                            <div class="span10">
                                                <select  id="cbSearchMode" data-placeholder="Choose a Search Mode..." style="width: 404px;">
                                                </select>
                                                <span class="help-inline color red" id="lblvalid_SearchMode" style="display: none">*</span>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="space-4"></div>
                                    <div class="row-fluid">
                                        <div class="span12">
                                            <div class="span2">
                                                <label class="control-label" for="lblSession">Session</label>
                                            </div>
                                            <div class="span1">
                                                <input type="text" id="txtSession" style="width: 80px" onkeypress="return Numbers(event)" maxlength="10">
                                                <span class="help-inline color red" id="lblvalidSession" style="display: none; width:5px;">*</span>
                                            </div>
                                            <div class="span2" style="text-align: right">
                                                <label class="control-label" for="lblTagPopulationEstimate">Tag Population Estimate</label>
                                            </div>
                                            <div class="span6" style="text-align: left">
                                                <input type="text" id="txtTagPopulationEstimate" style="width: 100px" onkeypress="return Numbers(event)" maxlength="10">
                                                <span class="help-inline color red" id="lblvalidTagPopulationEstimate" style="display: none">*</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span2">
                                            <label class="control-label" id="lblTimeStamp"></label>
                                        </div>
                                        <div class="span10">
                                            <div class="controls">
                                                <label class="inline">
                                                    <input name="ckbTimeStamp" type="checkbox" id="ckbTimeStamp" />
                                                    <span >Timestamp Collection Enabled</span>
                                                </label>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span12">

                                            <div class="span2">
                                                <label class="control-label" id="lblFilterMode">Filter Mode</label>
                                            </div>
                                            <div class="span10">
                                                <select id="cbFilterMode" data-placeholder="Choose a Filter Mode..." style="width: 404px;">
                                                </select>
                                                <span class="help-inline color red" id="lblvalid_FilterMode" style="display: none">*</span>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="space-4"></div>
                                    <div class="row-fluid">
                                        <div class="span12">

                                            <div class="span2">
                                                <label class="control-label" id="lblKeepAlive">Keep Alive</label>
                                            </div>
                                            <div class="span10">

                                                <div id="div1" style="border-width: 1px; border-style: solid; border-color: gray; height: 130px; width: 400px; padding-left: 20px; padding-top: 20px;">
                                                    <div class="row-fluid">
                                                        <div class="span4">
                                                        </div>
                                                        <div class="span4">
                                                            <div class="row-fluid">
                                                                <div class="controls">
                                                                    <label class="inline">
                                                                        <input name="ckbKeepAliveEnabled" type="checkbox" id="ckbKeepAliveEnabled" />
                                                                        <span >Enabled</span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="span2">
                                                        </div>
                                                    </div>
                                                    <div class="row-fluid">
                                                        <div class="span4">
                                                            <label class="control-label" id="lblKeepAlivePeriod">Period</label>
                                                        </div>
                                                        <div class="span4">
                                                            <input type="text" class="input-mini" id="txtKeepAlivePeriod" style="width: 100px;" onkeypress="return Numbers(event)" maxlength="5" />
                                                        </div>
                                                        <div class="span2">
                                                            <label class="control-label" id="lblKeepAlivePeriodMS">ms</label>
                                                        </div>
                                                    </div>
                                                    <div class="row-fluid">
                                                        <div class="span4">
                                                            <label class="control-label" id="lblLinkDownThreshold">Link Down Threshold</label>
                                                        </div>
                                                        <div class="span4">
                                                            <input type="text" class="input-mini" id="txtDownThreshold" style="width: 100px;" onkeypress="return Numbers(event)" maxlength="5"  />
                                                        </div>
                                                        <div class="span2">
                                                            <label class="control-label" id="lblDownThresholdMS">ms</label>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="space-4"></div>
                                    <div class="row-fluid">
                                        <div class="span12">

                                            <div class="span2">
                                                <label class="control-label" id="lblLowDutyCycle">Low Duty Cycle</label>
                                            </div>
                                            <div class="span10">

                                                <div id="div2" style="border-width: 1px; border-style: solid; border-color: gray; height: 130px; width: 400px; padding-left: 20px; padding-top: 20px;">
                                                    <div class="row-fluid">
                                                        <div class="span4">
                                                        </div>
                                                        <div class="span4">
                                                            <div class="row-fluid">
                                                                <div class="controls">
                                                                    <label class="inline">
                                                                        <input name="ckbLowDutyCycleEnabled" type="checkbox" id="ckbLowDutyCycleEnabled" />
                                                                        <span >Enabled</span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="span2">
                                                        </div>
                                                    </div>
                                                    <div class="row-fluid">
                                                        <div class="span4">
                                                            <label class="control-label" id="lblFieldPingInterval">Field Ping Interval</label>
                                                        </div>
                                                        <div class="span4">
                                                            <input type="text" class="input-mini" id="txtFieldPingInterval" style="width: 100px;" onkeypress="return Numbers(event)" maxlength="5"  />
                                                        </div>
                                                        <div class="span2">
                                                            <label class="control-label" id="lblFieldPingIntervalMS">ms</label>
                                                        </div>
                                                    </div>
                                                    <div class="row-fluid">
                                                        <div class="span4">
                                                            <label class="control-label" id="lblEmptyFieldTimeout">Empty Field Timeout</label>
                                                        </div>
                                                        <div class="span4">
                                                            <input type="text" class="input-mini" id="txtEmptyFieldTimeout" style="width: 100px;" onkeypress="return Numbers(event)" maxlength="5" />
                                                        </div>
                                                        <div class="span2">
                                                            <label class="control-label" id="lblEmptyFieldTimeoutMS2">ms</label>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="space-4"></div>
                                    <div class="row-fluid">
                                        <div class="span12">

                                            <div class="span2">
                                                <label class="control-label" id="lblReport">Report</label>
                                            </div>
                                            <div class="span10">

                                                <div id="div3" style="border-width: 1px; border-style: solid; border-color: gray; height: 230px; width: 400px; padding-left: 20px; padding-top: 20px;">
                                                    <div class="row-fluid">
                                                        <div class="span4">
                                                            <label class="control-label" id="lblMode">Mode</label>
                                                        </div>
                                                        <div class="span6">
                                                            <select  id="cbMode" data-placeholder="Choose a Mode..." style="width: 200px;">
                                                            </select>
                                                        </div>

                                                    </div>
                                                    <div class="row-fluid">
                                                        <div class="span4">
                                                        </div>
                                                        <div class="span6">
                                                            <div class="row-fluid">
                                                                <div class="controls">
                                                                    <label class="inline">
                                                                        <input name="ckbPeakRssi" type="checkbox" id="ckbPeakRssi" />
                                                                        <span >Include Peak Rssi</span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="row-fluid">
                                                                <div class="controls">
                                                                    <label class="inline">
                                                                        <input name="ckbAntennaPortNo" type="checkbox" id="ckbAntennaPortNo" />
                                                                        <span >Include Antenna Port No</span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="row-fluid">
                                                                <div class="controls">
                                                                    <label class="inline">
                                                                        <input name="ckbFirstSeenTime" type="checkbox" id="ckbFirstSeenTime" />
                                                                        <span >Include First Seen Time</span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="row-fluid">
                                                                <div class="controls">
                                                                    <label class="inline">
                                                                        <input name="ckbLastSeenTime" type="checkbox" id="ckbLastSeenTime" />
                                                                        <span >Include Last Seen Time</span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="row-fluid">
                                                                <div class="controls">
                                                                    <label class="inline">
                                                                        <input name="ckbSeenCount" type="checkbox" id="ckbSeenCount" />
                                                                        <span >Include Seen Count</span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="row-fluid">
                                                                <div class="controls">
                                                                    <label class="inline">
                                                                        <input name="ckbChannel" type="checkbox" id="ckbChannel" />
                                                                        <span >Include Channel</span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="row-fluid">
                                                                <div class="controls">
                                                                    <label class="inline">
                                                                        <input name="ckbPhaseAngle" type="checkbox" id="ckbPhaseAngle" />
                                                                        <span >Include Phase Angle</span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="row-fluid">
                                                                <div class="controls">
                                                                    <label class="inline">
                                                                        <input name="ckbSerializedTid" type="checkbox" id="ckbSerializedTid" />
                                                                        <span >Include Serialized Tid</span>
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                              
                                </div>
                                

                                <div class="row-fluid">
                                    <br />
                                    <div>
                                        <h3 class="header smaller lighter blue">Antenna</h3>
                                    </div>


                                    <div class="row-fluid">
                                        <div class="span12" id="divbtnAddAntenna">
                                            <button class="btn btn-small btn-success" id="btnAddAntenna" name="btnAddAntenna">
                                                <i class=" icon-plus"></i>
                                                Add New
                                            </button>
                                        </div>
                                    </div>
                                    <div class="space-2"></div>
                                    <div id="dialog-grid_antenna">
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <table class="table table-striped table-bordered table-hover" id="dt_outantenna"></table>
                                            </div>
                                        </div>
                                    </div>

                                </div>





                                <div class="row-fluid">
                                    <br />
                                    <div>
                                        <h3 class="header smaller lighter blue">GPIO</h3>
                                    </div>


                                    <div class="row-fluid">
                                        <div class="span12" id="divbtnAddGPI">
                                            <button class="btn btn-small btn-success" id="btnAddGPI" name="btnAddGPI">
                                                <i class=" icon-plus"></i>
                                                Add New
                                            </button>
                                        </div>
                                    </div>
                                    <div class="space-2"></div>
                                    <div id="dialog-grid_GPI">
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <table class="table table-striped table-bordered table-hover" id="dt_outgpi" ></table>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row-fluid">
                                    <br />
                                    <div>
                                        <h3 class="header smaller lighter blue">Tag Filter</h3>
                                    </div>


                                    <div class="row-fluid">
                                        <div class="span12" id="divbtnAddTagFilter">
                                            <button class="btn btn-small btn-success" id="btnAddTagFilter" name="btnAddTagFilter">
                                                <i class=" icon-plus"></i>
                                                Add New
                                            </button>
                                        </div>
                                    </div>
                                    <div class="space-2"></div>
                                    <div id="dialog-grid_TagFilter">
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <table class="table table-striped table-bordered table-hover" id="dt_outtagfilter"></table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="space-2"></div>
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

                            <div id="dialog-edit-antenna">
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblPortNumber">Port Number</label>
                                        </div>
                                        <div class="span8">
                                            <input type="text" class="input-mini" id="txtPortNumber" style="width: 100px;" onkeypress="return Numbers(event)" maxlength="5" />
                                            <span class="help-inline color red" id="lblvalid_PortNumber" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblTxPower">Tx Power</label>
                                        </div>
                                        <div class="span8">
                                            <input type="text" class="input-mini" id="txtTxPower" style="width: 100px;" onkeypress="return FloatNumbers(event)" maxlength="20" />
                                            <span class="help-inline color red" id="lblvalid_TxPower" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>

                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblRxSensitivity">Rx Sensitivity</label>
                                        </div>
                                        <div class="span8">
                                            <input type="text" class="input-mini" id="txtRxSensitivity" style="width: 100px;" onkeypress="return ChkMinusDbl(txtRxSensitivity,event)" maxlength="20" />
                                            <span class="help-inline color red" id="lblvalid_RxSensitivity" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblAntennaBrandName">Brand Name</label>
                                        </div>
                                        <div class="span8">
                                            <input type="text" class="input-mini" id="txtAntennaBrandName" style="width: 250px;" maxlength="255" />
                                            <span class="help-inline color red" id="lblvalid_AntennaBrandName" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblAntennaModelName">Model Name</label>
                                        </div>
                                        <div class="span8">
                                            <input type="text" class="input-mini" id="txtAntennaModelName" style="width: 250px;" maxlength="255" />
                                            <span class="help-inline color red" id="lblvalid_AntennaModelName" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>

                                <div class="row-fluid">
                                    <div class="span4">
                                        <%--<label class="control-label" id="lblAntennaEnable">Enabled</label>--%>
                                    </div>
                                    <div class="span8">
                                        <div class="controls">
                                            <label class="inline">
                                                <input name="ckbAntennaEnable" type="checkbox" id="ckbAntennaEnable" />
                                                <span >Enabled</span>
                                            </label>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="dialog-edit-gpi">
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span3">
                                            <label class="control-label" id="lblPortNumberGPI">Port Number</label>
                                        </div>
                                        <div class="span9">
                                            <input type="text" class="input-mini" id="txtPortNumberGPI" style="width: 200px;" onkeypress="return Numbers(event)" maxlength="5" />
                                           
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span3">
                                            <label class="control-label" id="lblDebounce">Debounce</label>
                                        </div>
                                        <div class="span4">
                                            <input type="text" class="input-mini" id="txtDebounce" style="width: 200px;"  onkeypress="return Numbers(event)" maxlength="5" />
                                            
                                        </div>
                                        <div class="span5">
                                            <label class="control-label" id="lblDebounceMS">ms</label>
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span3">
                                            <label class="control-label" id="lblGPIBrandName">Brand Name</label>
                                        </div>
                                        <div class="span9">
                                            <input type="text" class="input-mini" id="txtGPIBrandName" style="width: 250px;" maxlength="255" />
                                           
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span3">
                                            <label class="control-label" id="lblGPIModelName">Model Name</label>
                                        </div>
                                        <div class="span9">
                                            <input type="text" class="input-mini" id="txtGPIModelName" style="width: 250px;" maxlength="255" />
                                           
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span3">
                                        <%--<label class="control-label" id="lblAntennaEnable">Enabled</label>--%>
                                    </div>
                                    <div class="span9">
                                        <div class="controls">
                                            <label class="inline">
                                                <input name="ckbGPIEnable" type="checkbox" id="ckbGPIEnable" />
                                                <span >Enabled</span>
                                            </label>

                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span6" style="width: 300px;">Auto Start</div>
                                    <div class="span1" ></div>
                                    <div class="span6" style="width: 300px;">Auto Stop</div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span6" style="border-width: 1px; border-style: solid; border-color: gray; height: 160px; width: 300px; padding-left: 10px; padding-top: 10px;">
                                        <div class="row-fluid">
                                            <div class="span4">
                                                <label class="control-label" id="lblAutoStartMode">Mode</label>
                                            </div>
                                            <div class="span6">
                                                <select  id="cbAutoStartMode" data-placeholder="Choose a Mode..." style="width: 120px;">                                                 
                                                </select>
                                            </div>
                                            <div class="span2">
                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span4">
                                                <label class="control-label" id="lblAutoStartGPILevel">GPIO Level</label>
                                            </div>
                                            <div class="span6">
                                                <select  id="cbAutoStartGPILevel" data-placeholder="Choose a GPIO Level..."  style="width: 120px;">
                                                </select>
                                            </div>
                                            <div class="span2">
                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span4">
                                                <label class="control-label" id="lblAutoStartFirstDelay">First Delay</label>
                                            </div>
                                            <div class="span6">
                                                <input type="text" class="input-mini" id="txtAutoStartFirstDelay" style="width: 100px;"  onkeypress="return Numbers(event)" maxlength="5" />
                                                
                                            </div>
                                            <div class="span2">
                                                <label class="control-label" id="lblAutoStartFirstDelayMS">ms</label>
                                                
                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span4">
                                                <label class="control-label" id="lblAutoStartPeriod">Period</label>
                                            </div>
                                            <div class="span6">
                                                <input type="text" class="input-mini" id="txtAutoStartPeriod" style="width: 100px;"  onkeypress="return Numbers(event)" maxlength="5" />
                                               
                                            </div>
                                            <div class="span2">
                                                <label class="control-label" id="lblAutoStartPeriodMS">ms</label>
                                                 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="span1">
                                    </div>


                                    <div class="span6" style="border-width: 1px; border-style: solid; border-color: gray; height: 160px; width: 300px; padding-left: 10px; padding-top: 10px;">
                                        <div class="row-fluid">
                                            <div class="span4">
                                                <label class="control-label" id="lblAutoStopMode">Mode</label>
                                            </div>
                                            <div class="span6">
                                                <select  id="cbAutoStopMode" data-placeholder="Choose a Mode..." style="width: 120px;">
                                                </select>
                                            </div>
                                            <div class="span2">
                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span4">
                                                <label class="control-label" id="lblAutoStopGPILevel">GPIO Level</label>
                                            </div>
                                            <div class="span6">
                                                <select  id="cbAutoStopGPILevel" data-placeholder="Choose a GPIO Level..." style="width: 120px;">
                                                </select>
                                            </div>
                                            <div class="span2">
                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span4">
                                                <label class="control-label" id="lblAutoStopDuration">Duration</label>
                                            </div>
                                            <div class="span6">
                                                <input type="text" class="input-mini" id="txtAutoStopDuration" style="width: 100px;"onkeypress="return Numbers(event)" maxlength="5"  />
                                             
                                            </div>
                                            <div class="span2">
                                                <label class="control-label" id="lblAutoStopDurationMS">ms</label>
                                            </div>
                                        </div>
                                        
                                    </div>
                                </div>

                                <div class="row-fluid">
                                    <br />
                                    <span class="help-inline color red" id="lblvalid_PortNumberGPI" style="display: none">Port Number is required</span>
                                    <span class="help-inline color red" id="lblvalid_Debounce" style="display: none">Debounce is required</span>
                                    <span class="help-inline color red" id="lblvalid_AutoStartFirstDelay" style="display: none">Auto Start First Delay is required</span>
                                    <span class="help-inline color red" id="lblvalid_AutoStartPeriod" style="display: none">Auto Start Period is required</span>
                                    <span class="help-inline color red" id="lblvalid_AutoStopDuration" style="display: none">Auto Stop Duration is required</span>
                                    <span class="help-inline color red" id="lblvalid_GPIModelName" style="display: none">Model Name is required</span>
                                    <span class="help-inline color red" id="lblvalid_GPIBrandName" style="display: none">Brand Name is required</span>
                                    <br />
                                    <br />
                                   
                                </div>
                            </div>
                            <div id="dialog-edit-tagfilter">
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblTagFilter">Tag Filter</label>
                                        </div>
                                        <div class="span8">
                                            <input type="text" class="input-mini" id="txtTagFilter" style="width: 100px;" onkeypress="return Numbers(event)" maxlength="5" />
                                            <span class="help-inline color red" id="lblvalid_TagFilter" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblMemoryBank">Memory Bank</label>
                                        </div>
                                        <div class="span8">
                                            <select  id="cbMemoryBank" data-placeholder="Choose a Memory Bank..." style="width: 220px;">
                                            </select>
                                            <span class="help-inline color red" id="lblvalid_MemoryBank" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblBitPointer">Bit Pointer</label>
                                        </div>
                                        <div class="span8">
                                            <input type="text" class="input-mini" id="txtBitPointer" style="width: 100px;" onkeypress="return Numbers(event)" maxlength="5" />
                                            <span class="help-inline color red" id="lblvalid_BitPointer" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblBitCount">Bit Count</label>
                                        </div>
                                        <div class="span8">
                                            <input type="text" class="input-mini" id="txtBitCount" style="width: 100px;" onkeypress="return Numbers(event)" maxlength="5" />
                                            <span class="help-inline color red" id="lblvalid_BitCount" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblTagMask">Tag Mask</label>
                                        </div>
                                        <div class="span8">
                                            <input type="text" class="input-mini" id="txtTagMask" style="width: 100px;" maxlength="5" />
                                            <span class="help-inline color red" id="lblvalid_TagMask" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">

                                        <div class="span4">
                                            <label class="control-label" id="lblFilterOp">Filter Op</label>
                                        </div>
                                        <div class="span8">
                                            <select  id="cbFilterOp" data-placeholder="Choose a Filter Op..." style="width: 220px;">
                                            </select>
                                            <span class="help-inline color red" id="lblvalid_FilterOp" style="display: none">This field is required</span>
                                        </div>

                                    </div>
                                </div>
                  
                            </div>
                        </div>
                    </div>

                </div>
            </div>

      <style type="text/css" media="screen">
        th {
            font-size: 8px;
        }

        /*td {
            font-size: 8px;
        }*/
    </style>
   
    <%-- //Keep Path input file--%>
    <input id="HiddenId" type="hidden" />
    
    <%--ready function--%>
    <script type="text/javascript">
        //Open page
        $(document).ready(function () {
            localStorage['antennadata'] = '';
            localStorage['gpidata'] = '';
            localStorage['tagfilterdata'] = '';
            var oTable;
            var isAddNew = false;
            LoadData();
            LoadDataAntenna(0);
            LoadDataGPI(0);
            LoadDataTagFilter(0);
            LoadSpeedwayDefaultMaxAnt();
            LoadSpeedwayDefaultMaxGPI();


            //Add Click
            $("#btnAdd").click(function () {
                onEdit(0);
                clickEdit();
            });

            $("#btnBack").click(function () {
                onEdit(0);
                clickEndEdit();
            });

            $("#btnClearImage").click(function () {
                $("roomimagefile").val("");
                clearImage();
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

            $("#btnAddAntenna").click(function () {
                onEditAntenna(0); return false;
            });

            $("#btnAddGPI").click(function () {
                onEditGPI(0); return false;
            });

            $("#btnAddTagFilter").click(function () {
                onEditTagFilter(0); return false;
            });

            $('#cbfloor').change(function () {
                populateSelectRoomById();
            });

            $('.date-picker').datepicker({ "autoclose": true }).next().on(ace.click_event, function () {
                $(this).prev().focus();
            });

            $("#txtSchedule").prop('disabled', true);
            $("#rdNow").change(function () {
                $("#txtSchedule").prop('disabled', true);
            });
            $("#rdSchedule").change(function () {
                $("#txtSchedule").prop('disabled', false);
            });

            //Hide div or other
            $("#dialog-edit").hide();
            $("#btnBack").hide();
            $("#dialog-edit-antenna").hide();
            $("#dialog-edit-gpi").hide();
            $("#dialog-edit-tagfilter").hide();

        });
    </script>

    <%--main page--%>
    <script type="text/javascript">

        function LoadData() {
            var dataurl = 'WebService/WebService.asmx/LoadRFIDConfigScheduleAll';
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
                                "sTitle": "Reader ID",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "ReaderID"

                            },
                            {
                                "sTitle": "Serial No",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "serial_no"

                            },
                           {
                               "sTitle": "IP Address",
                               "sType": "string",
                               "sDefaultContent": "",
                               "mDataProp": "ip_address"

                           },
                           {
                               "sTitle": "Install Position",
                               "sType": "string",
                               "sDefaultContent": "",
                               "mDataProp": "install_position"

                           },
                           {
                               "sTitle": "Floor",
                               "sType": "string",
                               "sDefaultContent": "",
                               "mDataProp": "floor_name"

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
                                    var IsDelete = obj.aData.IsDelete;
                                    var str = "";
                                    if (IsDelete == "T") {
                                        str = " style='display:none;'"
                                    }

                                    return '<div class="hidden-phone visible-desktop action-buttons">'
                                            + '<a href="#"  class="Green"  title="Edit" onClick="onEdit(' + obj.aData.id + ');clickEdit(); return false;">'
                                            + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                            + '</a>'
                                            + '&nbsp;'
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
                                            + '						<a href="#"   class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEdit(' + obj.aData.id + ');clickEdit(); return false;">'
                                            + '							<span class="green">'
                                            + '								<i class="icon-edit bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
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
                "iDisplayLength": 100,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "15%", "aTargets": [1] },
                { "sWidth": "15%", "aTargets": [2] },
                { "sWidth": "15%", "aTargets": [3] },
                { "sWidth": "15%", "aTargets": [4] },
                { "sWidth": "10%", "aTargets": [5] },
                { "sWidth": "10%", "aTargets": [6] }

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
            onValidHide();
            $("#HiddenId").val(id);

            var param = "{'speedway_id':" + JSON.stringify(id) + "}";
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadRFIDConfigScheduleByID",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);
                    if (strvalue.length == 1) {
                        $("#HiddenId").val(strvalue[0].id);
                        $("#txtSerialNo").val(strvalue[0].serial_no);

                        if (strvalue[0].ReaderID == '') {
                            $("#lblReaderID").val("New");
                        }
                        else {
                            $("#lblReaderID").val(strvalue[0].ReaderID);
                        }
                        
                        $("#txtIPAddress").val(strvalue[0].ip_address);
                        $("#txtInstallPosition").val(strvalue[0].install_position);

                        $("#txtLabel").val(strvalue[0].setting_label);
                        $("#txtDescription").val(strvalue[0].setting_description);

                        $("#txtReaderBrandName").val(strvalue[0].brand_name);
                        $("#txtReaderModelName").val(strvalue[0].model_name);

                        $("#txtFtpUser").val(strvalue[0].ftp_user);
                        $("#txtFtpPassword").val(strvalue[0].ftp_pwd);
                        $("#txtFtpPort").val(strvalue[0].ftp_port);
                        $("#txtFtpPath").val(strvalue[0].ftp_path);
                        $("#txtFTPDataPath").val(strvalue[0].ftp_data_path);

                        if (strvalue[0].setting_session == "0") {
                            $("#txtSession").val("");
                        }
                        else {
                            $("#txtSession").val(strvalue[0].setting_session);
                        }

                        if (strvalue[0].setting_tag_populate_estimate == "0") {
                            $("#txtTagPopulationEstimate").val("");
                        }
                        else {
                            $("#txtTagPopulationEstimate").val(strvalue[0].setting_tag_populate_estimate);
                        }

                        if (strvalue[0].keepalive_period_in_ms == "0") {
                            $("#txtKeepAlivePeriod").val("");
                        }
                        else {
                            $("#txtKeepAlivePeriod").val(strvalue[0].keepalive_period_in_ms);
                        }

                        if (strvalue[0].keepalive_link_down_threshold == "0") {
                            $("#txtDownThreshold").val("");
                        }
                        else {
                            $("#txtDownThreshold").val(strvalue[0].keepalive_link_down_threshold);
                        }

                        if (strvalue[0].field_ping_interval_in_ms == "0") {
                            $("#txtFieldPingInterval").val("");
                        }
                        else {
                            $("#txtFieldPingInterval").val(strvalue[0].field_ping_interval_in_ms);
                        }

                        if (strvalue[0].emptry_field_timeout_in_ms == "0") {
                            $("#txtEmptyFieldTimeout").val("");
                        }
                        else {
                            $("#txtEmptyFieldTimeout").val(strvalue[0].emptry_field_timeout_in_ms);
                        }

                        $("#cbfloor").val(strvalue[0].ms_floor_id);
                        $("#cbroom").val(strvalue[0].ms_room_id);

                        if (strvalue[0].active_status == "Y") {
                            $("#ckbActive").prop("checked", true);
                        } else {
                            $("#ckbActive").prop("checked", false);
                        }
                        if (strvalue[0].setting_time_correct_enabled == "true") {
                            $("#ckbTimeStamp").prop("checked", true);
                        } else {
                            $("#ckbTimeStamp").prop("checked", false);
                        }
                        if (strvalue[0].keepalive_is_enabled == "true") {
                            $("#ckbKeepAliveEnabled").prop("checked", true);
                        } else {
                            $("#ckbKeepAliveEnabled").prop("checked", false);
                        }
                        if (strvalue[0].mld_is_enable == "true") {
                            $("#ckbLowDutyCycleEnabled").prop("checked", true);
                        } else {
                            $("#ckbLowDutyCycleEnabled").prop("checked", false);
                        }
                        if (strvalue[0].include_peak_rssi == "true") {
                            $("#ckbPeakRssi").prop("checked", true);
                        } else {
                            $("#ckbPeakRssi").prop("checked", false);
                        }
                        if (strvalue[0].include_antenna_port_number == "true") {
                            $("#ckbAntennaPortNo").prop("checked", true);
                        } else {
                            $("#ckbAntennaPortNo").prop("checked", false);
                        }
                        if (strvalue[0].include_first_seen_time == "true") {
                            $("#ckbFirstSeenTime").prop("checked", true);
                        } else {
                            $("#ckbFirstSeenTime").prop("checked", false);
                        }
                        if (strvalue[0].include_last_seen_time == "true") {
                            $("#ckbLastSeenTime").prop("checked", true);
                        } else {
                            $("#ckbLastSeenTime").prop("checked", false);
                        }
                        if (strvalue[0].include_seen_count == "true") {
                            $("#ckbSeenCount").prop("checked", true);
                        } else {
                            $("#ckbSeenCount").prop("checked", false);
                        }
                        if (strvalue[0].include_channel == "true") {
                            $("#ckbChannel").prop("checked", true);
                        } else {
                            $("#ckbChannel").prop("checked", false);
                        }
                        if (strvalue[0].include_phase_angle == "true") {
                            $("#ckbPhaseAngle").prop("checked", true);
                        } else {
                            $("#ckbPhaseAngle").prop("checked", false);
                        }
                        if (strvalue[0].include_serialized_tid == "true") {
                            $("#ckbSerializedTid").prop("checked", true);
                        } else {
                            $("#ckbSerializedTid").prop("checked", false);
                        }

                        if (strvalue[0].schedule_type == 'N') {
                            $("#rdNow").prop("checked", true);
                            $("#rdSchedule").prop("checked", false);
                            $("#txtSchedule").val("");
                            $("#txtSchedule").prop('disabled', true);
                        }
                        if (strvalue[0].schedule_type == 'S') {
                            $("#rdNow").prop("checked", false);
                            $("#rdSchedule").prop("checked", true);
                            $("#txtSchedule").val(strvalue[0].schedule_date);
                            $("#txtSchedule").prop('disabled', false);
                        }
                        
                        

                        populateSelect(strvalue[0].id);
                        populateSelectSearchMode(strvalue[0].setting_search_mode);
                        populateSelectFilterMode(strvalue[0].filters_mode);
                        populateSelectReportMode(strvalue[0].report_mode);

                        localStorage['antennadata'] = '';
                        localStorage['gpidata'] = '';
                        localStorage['tagfilterdata'] = '';
                        LoadDataAntenna(strvalue[0].id)
                        LoadDataGPI(strvalue[0].id)
                        LoadDataTagFilter(strvalue[0].ms_speedway_setting_id)

                    } else {

                        clearInput();
                        $("#HiddenId").val(0);
                        $("#lblReaderID").val("New");
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
            var serial_no = $("#txtSerialNo").val();
            var ReaderID = $("#lblReaderID").val();
            var ip_address = $("#txtIPAddress").val();
            var install_position = $("#txtInstallPosition").val();

            var setting_label = $("#txtLabel").val();
            var setting_description = $("#txtDescription").val();
            var setting_session = $("#txtSession").val();
            var setting_tag_populate_estimate = $("#txtTagPopulationEstimate").val();
            var keepalive_period_in_ms = $("#txtKeepAlivePeriod").val();
            var keepalive_link_down_threshold = $("#txtDownThreshold").val();
            var field_ping_interval_in_ms = $("#txtFieldPingInterval").val();
            var emptry_field_timeout_in_ms = $("#txtEmptyFieldTimeout").val();
            var active_status = $('input[name="ckbActive"]:checked').length;
            var setting_time_correct_enabled = $('input[name="ckbTimeStamp"]:checked').length;
            var keepalive_is_enabled = $('input[name="ckbKeepAliveEnabled"]:checked').length;
            var mld_is_enable = $('input[name="ckbLowDutyCycleEnabled"]:checked').length;
            var include_peak_rssi = $('input[name="ckbPeakRssi"]:checked').length;
            var include_antenna_port_number = $('input[name="ckbAntennaPortNo"]:checked').length;
            var include_first_seen_time = $('input[name="ckbFirstSeenTime"]:checked').length;
            var include_last_seen_time = $('input[name="ckbLastSeenTime"]:checked').length;
            var include_seen_count = $('input[name="ckbSeenCount"]:checked').length;
            var include_channel = $('input[name="ckbChannel"]:checked').length;
            var include_phase_angle = $('input[name="ckbPhaseAngle"]:checked').length;
            var include_serialized_tid = $('input[name="ckbSerializedTid"]:checked').length;

            var jsonobject_antenna = localStorage['antennadata'];
            var jsonobject_gpi = localStorage['gpidata'];
            var jsonobject_tagfilter = localStorage['tagfilterdata'];

            var ms_speedway_objective_id = $("#cbobjective").val();
            var ms_room_id = $("#cbroom").val();
            var setting_search_mode = $("#cbSearchMode").val();
            var filters_mode = $("#cbFilterMode").val();
            var report_mode = $("#cbMode").val();

            var reader_brand_name = $("#txtReaderBrandName").val();
            var reader_model_name = $("#txtReaderModelName").val();
            var rdnow = $("#rdNow").is(":checked")
            var rdschedule = $("#rdSchedule").is(":checked")
            var schedule_date = $("#txtSchedule").val();
            var ftp_user = $("#txtFtpUser").val();
            var ftp_pwd = $("#txtFtpPassword").val();
            var ftp_port = $("#txtFtpPort").val();
            var ftp_path = $("#txtFtpPath").val();
            var ftp_data_path = $("#txtFTPDataPath").val();

            var param = "{'id':" + JSON.stringify(id)
                + ",'login_username':" + JSON.stringify(login_username)
                + ",'serial_no':" + JSON.stringify(serial_no)
                + ",'ip_address':" + JSON.stringify(ip_address)
                + ",'install_position':" + JSON.stringify(install_position)
                + ",'setting_label':" + JSON.stringify(setting_label)
                + ",'setting_description':" + JSON.stringify(setting_description)
                + ",'setting_session':" + JSON.stringify(setting_session)
                + ",'setting_tag_populate_estimate':" + JSON.stringify(setting_tag_populate_estimate)
                + ",'keepalive_period_in_ms':" + JSON.stringify(keepalive_period_in_ms)
                + ",'keepalive_link_down_threshold':" + JSON.stringify(keepalive_link_down_threshold)
                + ",'field_ping_interval_in_ms':" + JSON.stringify(field_ping_interval_in_ms)
                + ",'emptry_field_timeout_in_ms':" + JSON.stringify(emptry_field_timeout_in_ms)
                + ",'active_status':" + JSON.stringify(active_status)
                + ",'setting_time_correct_enabled':" + JSON.stringify(setting_time_correct_enabled)
                + ",'keepalive_is_enabled':" + JSON.stringify(keepalive_is_enabled)
                + ",'mld_is_enable':" + JSON.stringify(mld_is_enable)
                + ",'include_peak_rssi':" + JSON.stringify(include_peak_rssi)
                + ",'include_antenna_port_number':" + JSON.stringify(include_antenna_port_number)
                + ",'include_first_seen_time':" + JSON.stringify(include_first_seen_time)
                + ",'include_last_seen_time':" + JSON.stringify(include_last_seen_time)
                + ",'include_seen_count':" + JSON.stringify(include_seen_count)
                + ",'include_channel':" + JSON.stringify(include_channel)
                + ",'include_phase_angle':" + JSON.stringify(include_phase_angle)
                + ",'include_serialized_tid':" + JSON.stringify(include_serialized_tid)
                + ",'ms_speedway_objective_id':" + JSON.stringify(ms_speedway_objective_id)
                + ",'ms_room_id':" + JSON.stringify(ms_room_id)
                + ",'setting_search_mode':" + JSON.stringify(setting_search_mode)
                + ",'filters_mode':" + JSON.stringify(filters_mode)
                + ",'report_mode':" + JSON.stringify(report_mode)
                + ",'jsonobject_antenna':" + JSON.stringify(jsonobject_antenna)
                + ",'jsonobject_gpi':" + JSON.stringify(jsonobject_gpi)
                + ",'jsonobject_tagfilter':" + JSON.stringify(jsonobject_tagfilter)
                + ",'reader_brand_name':" + JSON.stringify(reader_brand_name)
                + ",'reader_model_name':" + JSON.stringify(reader_model_name) 
                + ",'rdnow':" + JSON.stringify(rdnow)
                + ",'rdschedule':" + JSON.stringify(rdschedule)
                + ",'schedule_date':" + JSON.stringify(schedule_date) 
                + ",'ftp_user':" + JSON.stringify(ftp_user)
                + ",'ftp_pwd':" + JSON.stringify(ftp_pwd)
                + ",'ftp_port':" + JSON.stringify(ftp_port)
                + ",'ftp_path':" + JSON.stringify(ftp_path)
                + ",'ftp_data_path':" + JSON.stringify(ftp_data_path) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveRFIDConfigSchedule",
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
                url: "WebService/WebService.asmx/DeleteRFIDConfigSchedul",
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

        function onSuccess(result) {
            if (result.d == "YES") {
                onAlert("Save Complete");
                LoadData();

                $("#HiddenId").val(0);
                $("#lblReaderID").val("New");
                clearInput();
                clickEndEdit();
            } else {
                if (result.d == "DUPLICATESPEEDWAYSERAILNO") {
                    onAlert("Serial No already exists. Please modify Serial No");
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
            $("#lblvalidSerialNo").hide();
            $("#lblvalidIPAddress").hide();
            $("#lblvalidInstallPosition").hide();
            $("#lblvalid_floor_id").hide();
            $("#lblvalid_objective").hide();
            $("#lblvalid_room_id").hide();
            $("#lblvalid_SearchMode").hide();
            $("#lblvalidSession").hide();
            $("#lblvalid_FilterMode").hide();
            $("#lblvalidTagPopulationEstimate").hide();
            $("#lblvalid_ReaderBrandName").hide();
            $("#lblvalid_ReaderModelName").hide();
            $("#lblvalid_Schedule").hide();
            $("#lblvalidFtpUser").hide();
            $("#lblvalidFtpPassword").hide();
            $("#lblvalidFtpPort").hide();
            $("#lblvalidFtpPath").hide();
            $("#lblvalidFTPDataPath").hide();
        }

        //Check Valid
        function onValid() {
            var isValid;
            isValid = true;
            var SerialNo = $('#txtSerialNo').val();
            var IPAddress = $("#txtIPAddress").val();
            var InstallPosition = $("#txtInstallPosition").val();
            var floor = $("#cbfloor").val();
            var objective = $("#cbobjective").val();
            var room = $("#cbroom").val();
            var Label = $("#txtLabel").val();
            var Description = $("#txtDescription").val();
            var SearchMode = $("#cbSearchMode").val();
            var Session = $("#txtSession").val();
            var TagPopulationEstimate = $("#txtTagPopulationEstimate").val();
            var FilterMode = $("#cbFilterMode").val();
            var reader_brand_name = $("#txtReaderBrandName").val();
            var reader_model_name = $("#txtReaderModelName").val();
            var rdschedule = $("#rdSchedule").is(":checked")
            var schedule_date = $("#txtSchedule").val();
            var ftp_user = $("#txtFtpUser").val();
            var ftp_pwd = $("#txtFtpPassword").val();
            var ftp_port = $("#txtFtpPort").val();
            var ftp_path = $("#txtFtpPath").val();
            var ftp_data_path = $("#txtFTPDataPath").val();

            if (SerialNo == '') {
                $("#lblvalidSerialNo").show();
                isValid = false;
            } else {
                $("#lblvalidSerialNo").hide();
            }

            if (IPAddress == '') {
                $("#lblvalidIPAddress").show();
                isValid = false;
            } else {
                $("#lblvalidIPAddress").hide();

            }

            if (InstallPosition == '') {
                $("#lblvalidInstallPosition").show();
                isValid = false;
            } else {
                $("#lblvalidInstallPosition").hide();

            }

            if (floor == '') {
                $("#lblvalid_floor_id").show();
                isValid = false;
            } else {
                $("#lblvalid_floor_id").hide();
            }

            if (objective == '') {
                $("#lblvalid_objective").show();
                isValid = false;
            } else {
                $("#lblvalid_objective").hide();
            }

            if (room == '') {
                $("#lblvalid_room_id").show();
                isValid = false;
            } else {
                $("#lblvalid_room_id").hide();
            }

            if (ftp_user == '') {
                $("#lblvalidFtpUser").show();
                isValid = false;
            } else {
                $("#lblvalidFtpUser").hide();
            }
            if (ftp_pwd == '') {
                $("#lblvalidFtpPassword").show();
                isValid = false;
            } else {
                $("#lblvalidFtpPassword").hide();
            }
            if (ftp_port == '') {
                $("#lblvalidFtpPort").show();
                isValid = false;
            } else {
                $("#lblvalidFtpPort").hide();
            }
            if (ftp_path == '') {
                $("#lblvalidFtpPath").show();
                isValid = false;
            } else {
                $("#lblvalidFtpPath").hide();
            }
            if (ftp_data_path == '') {
                $("#lblvalidFTPDataPath").show();
                isValid = false;
            } else {
                $("#lblvalidFTPDataPath").hide();
            }

            if (reader_brand_name == '') {
                $("#lblvalid_ReaderBrandName").show();
                isValid = false;
            } else {
                $("#lblvalid_ReaderBrandName").hide();
            }

            if (reader_model_name == '') {
                $("#lblvalid_ReaderModelName").show();
                isValid = false;
            } else {
                $("#lblvalid_ReaderModelName").hide();
            }

            //if (Description  == '') {
            //    $("#lblvalid_Description").show();
            //    isValid = false;
            //} else {
            //    $("#lblvalid_Description").hide();
            //}

            //if ( SearchMode == '') {
            //    $("#lblvalid_SearchMode").show();
            //    isValid = false;
            //} else {
            //    $("#lblvalid_SearchMode").hide();
            //}

            //if (Session == '') {
            //    $("#lblvalidSession").show();
            //    isValid = false;
            //} else {
            //    $("#lblvalidSession").hide();
            //}

            //if (TagPopulationEstimate == '') {
            //    $("#lblvalidTagPopulationEstimate").show();
            //    isValid = false;
            //} else {
            //    $("#lblvalidTagPopulationEstimate").hide();
            //}

            //if (FilterMode == '') {
            //    $("#lblvalid_FilterMode").show();
            //    isValid = false;
            //} else {
            //    $("#lblvalid_FilterMode").hide();
            //}

            $("#lblvalidIPAddressFormat").hide();
            if (IPAddress != '') {
                if (/^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/.test(IPAddress)) {

                }
                else {
                    $("#lblvalidIPAddressFormat").show();
                    // alert("You have entered an invalid IP address!");
                    isValid = false;
                }
            }

            if ((rdschedule == true) && (schedule_date == '')) {
                $("#lblvalid_Schedule").show();
                isValid = false;
            } else {
                $("#lblvalid_Schedule").hide();
            }

            return isValid;
        }

        function clearInput() {
            localStorage['antennadata'] = '';
            localStorage['gpidata'] = '';
            localStorage['tagfilterdata'] = '';
            //$("#HiddenId").val(0);
            $("#txtSerialNo").val("");
            // $("#lblReaderID").val("New");
            $("#txtIPAddress").val("");
            $("#txtInstallPosition").val("");

            $("#txtLabel").val("");
            $("#txtDescription").val("");
            $("#txtSession").val("");
            $("#txtTagPopulationEstimate").val("");
            $("#txtKeepAlivePeriod").val("");
            $("#txtDownThreshold").val("");
            $("#txtFieldPingInterval").val("");
            $("#txtEmptyFieldTimeout").val("");

            $("#ckbActive").prop("checked", true);
            $("#ckbTimeStamp").prop("checked", false);
            $("#ckbKeepAliveEnabled").prop("checked", false);
            $("#ckbLowDutyCycleEnabled").prop("checked", false);
            $("#ckbPeakRssi").prop("checked", false);
            $("#ckbAntennaPortNo").prop("checked", false);
            $("#ckbFirstSeenTime").prop("checked", false);
            $("#ckbLastSeenTime").prop("checked", false);
            $("#ckbSeenCount").prop("checked", false);
            $("#ckbChannel").prop("checked", false);
            $("#ckbPhaseAngle").prop("checked", false);
            $("#ckbSerializedTid").prop("checked", false);

            $("#txtReaderBrandName").val("");
            $("#txtReaderModelName").val("");
            $("#txtAntennaBrandName").val("");
            $("#txtAntennaModelName").val("");
            $("#txtGPIBrandName").val("");
            $("#txtGPIModelName").val("");

            $("#rdNow").prop("checked", true);
            $("#rdSchedule").prop("checked", false);
            $("#txtSchedule").val("");
            $("#txtSchedule").prop('disabled', true);

            $("#txtFtpUser").val("");
            $("#txtFtpPassword").val("");
            $("#txtFtpPort").val("");
            $("#txtFtpPath").val("");
            $("#txtFTPDataPath").val("");

            populateSelect(0);
            populateSelectSearchMode(0);
            populateSelectFilterMode(0);
            populateSelectReportMode(0);
            LoadDataAntenna(0)
            LoadDataGPI(0)
            LoadDataTagFilter(0)
        }

    </script>
   

   <%--populateselect--%>
    <script type="text/javascript">

        function FloatNumbers(event) {
            if (event.which < 46
           || event.which > 59) {
                event.preventDefault();
            } // prevent if not number/dot

            if (event.which == 46
            && $(this).val().indexOf('.') != -1) {
                event.preventDefault();
            } // prevent if already dot
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

        function populateSelect(cfid) {

            var strselect;
            var param = "{'cfid':" + JSON.stringify(cfid) + "}";

            $select = $("#cbfloor");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadFloorByRFIDConfig',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    $select.html('');
                    $select.append('<option value="">Choose a Floor</option>');
                    $select.trigger("chosen:updated");
                    //append a select option
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (val.selected != "") {
                            strselect = ' selected="' + val.selected + '"';
                        }

                        $select.append('<option value="' + val.id + '" ' + strselect + '>' + val.floor_name + '</option>');
                        $select.trigger("chosen:updated");//update select option
                    })

                    $select.chosen();
                }
            });

            var param = "{'cfid':" + JSON.stringify(cfid) + "}";
            $selectRoom = $("#cbroom");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadRoomByRFIDConfig',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectRoom.html('');
                    $selectRoom.append('<option value="">Choose a Room</option>');
                    $selectRoom.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectRoom.append('<option value="' + val.id + '" ' + strselect + '>' + val.room_name + '</option>');
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

            var param = "{'cfid':" + JSON.stringify(cfid) + "}";
            $selectObjective = $("#cbobjective");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadObjectveByRFIDConfig',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectObjective.html('');
                    $selectObjective.append('<option value="">Choose a Objective</option>');
                    $selectObjective.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectObjective.append('<option value="' + val.id + '" ' + strselect + '>' + val.objective_name + '</option>');
                            $selectObjective.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectObjective.html('');
                        $selectObjective.append('<option value="">Choose a Objective</option>');
                        $selectObjective.trigger("chosen:updated");//update select option
                    }

                    $selectObjective.chosen();

                }
            });

        }

        function populateSelectRoomById() {
            var param = "{'floor_id':" + JSON.stringify($("#cbfloor").val()) + "}";
            $selectRoom = $("#cbroom");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadRoomByFloor',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectRoom.html('');
                    $selectRoom.append('<option value="">Choose a Room</option>');
                    $selectRoom.trigger("chosen:updated");//update select option
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

        function populateSelectSearchMode(SearchMode) {
            var param = "{'SearchMode':" + JSON.stringify(SearchMode) + "}";
            $selectSearchMode = $("#cbSearchMode");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadSearchMode',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectSearchMode.html('');
                    $selectSearchMode.append('<option value="">Choose a  Mode</option>');
                    $selectSearchMode.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectSearchMode.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                            $selectSearchMode.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectSearchMode.html('');
                        $selectSearchMode.append('<option value="">Choose a Mode</option>');
                        $selectSearchMode.trigger("chosen:updated");//update select option
                    }

                    $selectSearchMode.chosen();
                }
            });

        }

        function populateSelectFilterMode(FilterMode) {
            var param = "{'FilterMode':" + JSON.stringify(FilterMode) + "}";
            $selectFilterMode = $("#cbFilterMode");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadFilterMode',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectFilterMode.html('');
                    $selectFilterMode.append('<option value="">Choose a  Mode</option>');
                    $selectFilterMode.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectFilterMode.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                            $selectFilterMode.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectFilterMode.html('');
                        $selectFilterMode.append('<option value="">Choose a Mode</option>');
                        $selectFilterMode.trigger("chosen:updated");//update select option
                    }

                    $selectFilterMode.chosen();;
                }
            });
        }

        function populateSelectReportMode(ReportMode) {
            var param = "{'ReportMode':" + JSON.stringify(ReportMode) + "}";
            $selectReportMode = $("#cbMode");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadReportMode',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectReportMode.html('');
                    $selectReportMode.append('<option value="">Choose a  Mode</option>');
                    $selectReportMode.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectReportMode.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                            $selectReportMode.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectReportMode.html('');
                        $selectReportMode.append('<option value="">Choose a Mode</option>');
                        $selectReportMode.trigger("chosen:updated");//update select option
                    }

                    $selectReportMode.chosen();

                }
            });
        }

        function populateSelectAutoStartMode(AutoStartMode) {
            var param = "{'AutoStartMode':" + JSON.stringify(AutoStartMode) + "}";
            $selectAutoStartMode = $("#cbAutoStartMode");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadAutoStartMode',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectAutoStartMode.html('');
                    // $selectAutoStartMode.append('<option value="">Choose a Mode</option>');
                    $selectAutoStartMode.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            //if (val.selected != "") {
                            //    strselect = ' selected="' + val.selected + '"';
                            //}
                            $selectAutoStartMode.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                            $selectAutoStartMode.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectAutoStartMode.html('');
                        //$selectAutoStartMode.append('<option value="">Choose a Mode</option>');
                        $selectAutoStartMode.trigger("chosen:updated");//update select option
                    }

                    $selectAutoStartMode.chosen();
                }
            });



        }

        function populateSelectAutoStartGPILevel(GPILevel) {
            var param = "{'GPILevel':" + JSON.stringify(GPILevel) + "}";
            $selectAutoStartGPILevel = $("#cbAutoStartGPILevel");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadGPILevel',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectAutoStartGPILevel.html('');
                    // $selectAutoStartGPILevel.append('<option value="">Choose a GPI Level</option>');
                    $selectAutoStartGPILevel.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectAutoStartGPILevel.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                            $selectAutoStartGPILevel.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectAutoStartGPILevel.html('');
                        //$selectAutoStartGPILevel.append('<option value="">Choose a GPI Level</option>');
                        $selectAutoStartGPILevel.trigger("chosen:updated");//update select option
                    }
                    $selectAutoStartGPILevel.chosen();
                }
            });

        }

        function populateSelectAutoStopMode(AutoStopMode) {
            var param = "{'AutoStopMode':" + JSON.stringify(AutoStopMode) + "}";
            $selectAutoStopMode = $("#cbAutoStopMode");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadAutoStopMode',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectAutoStopMode.html('');
                    // $selectAutoStopMode.append('<option value="">Choose a Mode</option>');
                    $selectAutoStopMode.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectAutoStopMode.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                            $selectAutoStopMode.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectAutoStopMode.html('');
                        //$selectAutoStopMode.append('<option value="">Choose a Mode</option>');
                        $selectAutoStopMode.trigger("chosen:updated");//update select option
                    }
                    $selectAutoStopMode.chosen();
                }
            });
        }

        function populateSelectAutoStopGPILevel(GPILevel) {
            var param = "{'GPILevel':" + JSON.stringify(GPILevel) + "}";
            $selectAutoStopGPILevel = $("#cbAutoStopGPILevel");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadGPILevel',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectAutoStopGPILevel.html('');
                    //$selectAutoStopGPILevel.append('<option value="">Choose a GPI Level</option>');
                    $selectAutoStopGPILevel.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectAutoStopGPILevel.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                            $selectAutoStopGPILevel.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectAutoStopGPILevel.html('');
                        //$selectAutoStopGPILevel.append('<option value="">Choose a GPI Level</option>');
                        $selectAutoStopGPILevel.trigger("chosen:updated");//update select option
                    }
                    $selectAutoStopGPILevel.chosen();
                }
            });
        }

        function populateSelectMemoryBank(MemoryBank) {
            var param = "{'MemoryBank':" + JSON.stringify(MemoryBank) + "}";
            $selectMemoryBank = $("#cbMemoryBank");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadMemoryBank',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectMemoryBank.html('');
                    //$selectMemoryBank.append('<option value="">Choose a Memory Bank</option>');
                    $selectMemoryBank.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectMemoryBank.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                            $selectMemoryBank.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectMemoryBank.html('');
                        //$selectMemoryBank.append('<option value="">Choose a Memory Bank</option>');
                        $selectMemoryBank.trigger("chosen:updated");//update select option
                    }

                    $selectMemoryBank.chosen();
                }
            });
        }

        function populateSelectFilterOp(FilterOp) {
            var param = "{'FilterOp':" + JSON.stringify(FilterOp) + "}";
            $selectFilterOp = $("#cbFilterOp");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadFilterOp',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectFilterOp.html('');
                    //$selectFilterOp.append('<option value="">Choose a Filter Op</option>');
                    $selectFilterOp.trigger("chosen:updated");//update select option
                    //append a select option
                    if (jsonobject.length > 0) {
                        $.each(jsonobject, function (key, val) {
                            strselect = '';
                            if (val.selected != "") {
                                strselect = ' selected="' + val.selected + '"';
                            }
                            $selectFilterOp.append('<option value="' + val.id + '" ' + strselect + '>' + val.name + '</option>');
                            $selectFilterOp.trigger("chosen:updated");//update select option
                        })
                    }
                    else {

                        $selectFilterOp.html('');
                        // $selectFilterOp.append('<option value="">Choose a Filter Op</option>');
                        $selectFilterOp.trigger("chosen:updated");//update select option
                    }

                    $selectFilterOp.chosen();

                }
            });
        }


    </script>


    <%--antenna--%>
    <input id="HiddenAntennaId" value="0" type="hidden" />
    <input id="HiddenSpeedwayDefaultMaxAnt" value="0" type="hidden" />
    <script type="text/javascript">
        function onSaveAntenna(id) {
            var port_number = $('#txtPortNumber').val();
            var tx_power = $('#txtTxPower').val();
            var rx_sensitivity = $('#txtRxSensitivity').val();
            var brand_name = $('#txtAntennaBrandName').val();
            var model_name = $('#txtAntennaModelName').val();
            var enable = $('input[name="ckbAntennaEnable"]:checked').length; //$('#ckbAntennaEnable').val();  
            if (enable == 1) {
                enable = "True";
            }
            else {
                enable = "False";
            }


            //running no
            var rows = $("#dt_outantenna").dataTable().fnGetNodes();

            //data in current session
            var jsonobject = JSON.parse(localStorage['antennadata']);
            var aaData = [];
            aaData = jsonobject;
            //add data in current session

            if (id == 0) {
                aaData.push({
                    "no": parseInt(rows.length) + 1,
                    "id": parseInt(rows.length) + 1,
                    "port_number": port_number,
                    "tx_power_in_dbm": tx_power,
                    "rx_sensitivity_in_dbm": rx_sensitivity,
                    "brand_name": brand_name,
                    "model_name": model_name,
                    "is_enabled": enable
                });

            } else {//edit data in current session
                for (var i = 0; i < aaData.length; i++) {
                    if (aaData[i].id == id) {
                        aaData[i].port_number = port_number;
                        aaData[i].tx_power_in_dbm = tx_power;
                        aaData[i].rx_sensitivity_in_dbm = rx_sensitivity;
                        aaData[i].brand_name = brand_name;
                        aaData[i].model_name = model_name;
                        aaData[i].is_enabled = enable;
                        break;
                    }
                }

            }


            //update data in session
            localStorage['antennadata'] = JSON.stringify(aaData);

            // Reload
            LoadDataAntenna(0);
            clearAntenna();
        }

        function clearAntenna() {
            $('#txtPortNumber').val("");
            $('#txtTxPower').val("");
            $('#txtRxSensitivity').val("");
            $('#txtAntennaBrandName').val("");
            $('#txtAntennaModelName').val("");
            $("#ckbAntennaEnable").prop("checked", false);
            $('#HiddenAntennaId').val("0");
        }

        function LoadSpeedwayDefaultMaxAnt() {
            var dataurl = 'WebService/WebService.asmx/GetSpeedwayDefaultMaxAnt';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (obj) {
                    $('#HiddenSpeedwayDefaultMaxAnt').val(obj.d);
                }
            });
        }

        function LoadDataAntenna(id) {
            var param = "{'id':" + JSON.stringify(id) + "}";
            var dataurl = 'WebService/WebService.asmx/LoadRFIDConfigScheduleAntenna';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": PopulateGridAntenna
            });
        }


        function PopulateGridAntenna(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var yetVisited = localStorage['antennadata'];
            if (yetVisited.length > 0) {

            }
            else {
                localStorage['antennadata'] = jsondata.d;
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
                                "sTitle": "Port Number",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "port_number"

                            },
                            {
                                "sTitle": "Tx Power(Dbm)",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "tx_power_in_dbm",
                            },
                            {
                                "sTitle": "Rx Sensitivity(Dbm)",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "rx_sensitivity_in_dbm",
                            },
                            {
                                "sTitle": "Enabled",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "is_enabled",
                            },
                            {
                                "sTitle": "Action",
                                "bSortable": false,
                                "fnRender": function (obj) {

                                    //var IsDelete = obj.aData.IsDelete;
                                    //var str = "";
                                    //if (IsDelete == "T") {
                                    //    str = " style='display:none;'"
                                    //}

                                    return '<div class="hidden-phone visible-desktop action-buttons">'
                                            + '&nbsp;'
                                            + '<a href="#"   class="Green"  title="Edit" onClick="onEditAntenna(' + obj.aData.id + '); return false;">'
                                            + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                            + '</a>'
                                            + '&nbsp;'
                                            + '<a href="#"   class="Red"  title="Delete" onclick="onConfirmDeleteAntenna(' + obj.aData.no + '); return false;" >'
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
                                            + '						<a href="#"    class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEditAntenna(' + obj.aData.id + '); return false;">'
                                            + '							<span class="green">'
                                            + '								<i class="icon-edit bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + ''
                                            + '					<li>'
                                            + '						<a href="#"   class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDeleteAntenna(' + obj.aData.no + '); return false;">'
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

            var aaData = getDataAntenna();
            oTable = $('#dt_outantenna').dataTable({
                "aaData": aaData,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "20%", "aTargets": [1] },
                { "sWidth": "20%", "aTargets": [2] },
                { "sWidth": "20%", "aTargets": [3] },
                { "sWidth": "10%", "aTargets": [4] },
                { "sWidth": "10%", "aTargets": [5] },
                ],
                "aoColumns": columns,
                "bDestroy": true,
                "fnDrawCallback": function () {

                }

            });
        }

        function getDataAntenna() {
            var jsonobject = JSON.parse(localStorage['antennadata']);
            var aaData = [];
            aaData = jsonobject;
            return aaData;
        }

        function onEditAntenna(id) {

            onValidAntennaHide();
            //Find data in current session
            if (id > 0) {
                var jsonobject = JSON.parse(localStorage['antennadata']);
                var editjsonobject = getObjects(jsonobject, 'id', id);

                $.each(editjsonobject, function (key, val) {
                    $('#HiddenAntennaId').val(val.id);
                    $('#txtPortNumber').val(val.port_number);
                    $('#txtTxPower').val(val.tx_power_in_dbm);
                    $('#txtRxSensitivity').val(val.rx_sensitivity_in_dbm);
                    $('#txtAntennaBrandName').val(val.brand_name);
                    $('#txtAntennaModelName').val(val.model_name);
                    if (val.is_enabled == "True") {
                        $("#ckbAntennaEnable").prop("checked", true);
                    } else {
                        $("#ckbAntennaEnable").prop("checked", false);
                    }
                })

            } else {
                clearAntenna();
                $("#ckbAntennaEnable").prop("checked", true);
            }


            $("#dialog-edit-antenna").dialog({
                autoOpen: false,
                resizable: false,
                width: "500px",
                modal: true,
                buttons: {
                    "Save": function () {
                        var checkvalid = onValidAntenna();
                        if (checkvalid == true) {

                            if (checkid_duplicate_antenna($('#txtPortNumber').val(), $('#HiddenAntennaId').val()) == false) {
                                $('#txtPortNumber').focus();
                                onAlert("Port number already exists. Please modify Port number");

                            }
                            else if ($('#HiddenSpeedwayDefaultMaxAnt').val() < $('#txtPortNumber').val()) {
                                $('#txtPortNumber').focus();
                                onAlert(" please specify port number less than " + $('#HiddenSpeedwayDefaultMaxAnt').val());
                            }
                            else {
                                onSaveAntenna(id);
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
                titledialog = "Antenna";
            } else {
                titledialog = "Edit Antenna";
            }

            $("#dialog-edit-antenna").dialog("option", "title", titledialog).dialog("open");
        }

        function checkid_duplicate_antenna(port_number, id) {
            var jsonobject = JSON.parse(localStorage['antennadata']);
            var checkjsonobject = getObjects(jsonobject, 'port_number', port_number);
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

        function onValidAntennaHide() {
            $("#lblvalid_PortNumber").hide();
            $("#lblvalid_TxPower").hide();
            $("#lblvalid_RxSensitivity").hide();
            $("#lblvalid_AntennaBrandName").hide();
            $("#lblvalid_AntennaModelName").hide();
        }

        function onValidAntenna() {

            var isValid;
            isValid = true;

            var port_number = $('#txtPortNumber').val();
            var tx_power = $('#txtTxPower').val();
            var rx_sensitivity = $('#txtRxSensitivity').val();
            var brand_name = $('#txtAntennaBrandName').val();
            var model_name = $('#txtAntennaModelName').val();

            if (port_number == '') {
                $("#lblvalid_PortNumber").show();
                isValid = false;
            } else {

                $("#lblvalid_PortNumber").hide();

            }
            if (tx_power == '') {
                $("#lblvalid_TxPower").show();
                isValid = false;
            } else {

                $("#lblvalid_TxPower").hide();

            }
            if (rx_sensitivity == '') {
                $("#lblvalid_RxSensitivity").show();
                isValid = false;
            } else {
                $("#lblvalid_RxSensitivity").hide();

            }
            if (brand_name == '') {
                $("#lblvalid_AntennaBrandName").show();
                isValid = false;
            } else {

                $("#lblvalid_AntennaBrandName").hide();

            }
            if (model_name == '') {
                $("#lblvalid_AntennaModelName").show();
                isValid = false;
            } else {

                $("#lblvalid_AntennaModelName").hide();

            }

            return isValid;
        }

        function deleteDataAntenna(no) {
            var jsonobject = JSON.parse(localStorage['antennadata']);
            var aaData = [];
            aaData = jsonobject;
            aaData.splice(parseInt(no) - 1, 1);
            //running inndex bew
            var icount = 1;
            $.each(aaData, function (key, val) {
                aaData[icount - 1].no = icount;
                icount = icount + 1
            })
            localStorage['antennadata'] = JSON.stringify(aaData);
            LoadDataAntenna(0);
        }

        function onConfirmDeleteAntenna(id) {
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
                                    deleteDataAntenna(id);
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

    <%--gpi--%>
    <input id="HiddenGPIId" value="0" type="hidden" />
    <input id="HiddenSpeedwayDefaultMaxGPI" type="hidden" />
    <script type="text/javascript">
        function LoadSpeedwayDefaultMaxGPI() {
            var dataurl = 'WebService/WebService.asmx/GetSpeedwayDefaultMaxGPI';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (obj) {
                    $('#HiddenSpeedwayDefaultMaxGPI').val(obj.d);
                }
            });
        }
        function onSaveGPI(id) {

            var port_number_gpi = $('#txtPortNumberGPI').val();
            var debounce = $('#txtDebounce').val();
            var enable = $('input[name="ckbGPIEnable"]:checked').length;
            if (enable == 1) {
                enable = "True";
            }
            else {
                enable = "False";
            }

            var auto_start_mode = $('#cbAutoStartMode').val();
            var auto_start_gpi_level = $('#cbAutoStartGPILevel').val();
            var auto_start_first_delay = $('#txtAutoStartFirstDelay').val();
            var auto_start_period = $('#txtAutoStartPeriod').val();
            var auto_stop_mode = $('#cbAutoStopMode').val();
            var auto_stop_gpi_level = $('#cbAutoStopGPILevel').val();
            var auto_stop_duration = $('#txtAutoStopDuration').val();
            var brand_name = $('#txtGPIBrandName').val();
            var model_name = $('#txtGPIModelName').val();

            //running no
            var rows = $("#dt_outgpi").dataTable().fnGetNodes();

            //data in current session
            var jsonobject = JSON.parse(localStorage['gpidata']);
            var aaData = [];
            aaData = jsonobject;
            //add data in current session

            if (id == 0) {
                aaData.push({
                    "no": parseInt(rows.length) + 1,
                    "id": parseInt(rows.length) + 1,
                    "port_number": port_number_gpi,
                    "debounce_in_ms": debounce,
                    "auto_start_mode": auto_start_mode,
                    "auto_start_gpi_level": auto_start_gpi_level,
                    "auto_start_first_delay": auto_start_first_delay,
                    "auto_start_period": auto_start_period,
                    "auto_stop_mode": auto_stop_mode,
                    "auto_stop_gpi_level": auto_stop_gpi_level,
                    "auto_stop_duration": auto_stop_duration,
                    "brand_name": brand_name,
                    "model_name": model_name,
                    "is_enabled": enable
                });
            } else {//edit data in current session
                for (var i = 0; i < aaData.length; i++) {
                    if (aaData[i].id == id) {
                        aaData[i].port_number = port_number_gpi;
                        aaData[i].debounce_in_ms = debounce;
                        aaData[i].auto_start_mode = auto_start_mode;
                        aaData[i].auto_start_gpi_level = auto_start_gpi_level;
                        aaData[i].auto_start_first_delay = auto_start_first_delay;
                        aaData[i].auto_start_period = auto_start_period;
                        aaData[i].auto_stop_mode = auto_stop_mode;
                        aaData[i].auto_stop_gpi_level = auto_stop_gpi_level;
                        aaData[i].auto_stop_duration = auto_stop_duration;
                        aaData[i].brand_name = brand_name;
                        aaData[i].model_name = model_name;
                        aaData[i].is_enabled = enable;
                        break;
                    }
                }

            }

            //update data in session
            localStorage['gpidata'] = JSON.stringify(aaData);

            // Reload
            LoadDataGPI(0);
            clearGPI();
        }

        function clearGPI() {
            $('#txtPortNumberGPI').val("");
            $('#txtDebounce').val("");
            //$('#cbAutoStartMode').val("");
            //$('#cbAutoStartGPILevel').val("");
            $('#txtAutoStartFirstDelay').val("");
            $('#txtAutoStartPeriod').val("");
            //$('#cbAutoStopMode').val("");
            //$('#cbAutoStopGPILevel').val("");
            $('#txtAutoStopDuration').val("");
            $("#ckbGPIEnable").prop("checked", false);
            $('#HiddenGPIId').val("0");
            $('#txtGPIBrandName').val("");
            $('#txtGPIModelName').val("");
            populateSelectAutoStartMode("");
            populateSelectAutoStartGPILevel("");
            populateSelectAutoStopMode("");
            populateSelectAutoStopGPILevel("");
        }

        function LoadDataGPI(id) {
            var param = "{'id':" + JSON.stringify(id) + "}";
            var dataurl = 'WebService/WebService.asmx/LoadRFIDConfigScheduleGPI';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": PopulateGridGPI
            });
        }

        function PopulateGridGPI(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var yetVisited = localStorage['gpidata'];

            if (yetVisited.length > 0) {

            }
            else {

                localStorage['gpidata'] = jsondata.d;
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
                                "sTitle": "Port Number",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "port_number"

                            },
                            {
                                "sTitle": "Debounce(ms)",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "debounce_in_ms",
                            },
                            {
                                "sTitle": "Auto Start Mode",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "auto_start_mode",
                            },
                            {
                                "sTitle": "Auto Start GPIO Level",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "auto_start_gpi_level",
                            },
                            {
                                "sTitle": "Auto Start First Delay(ms)",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "auto_start_first_delay",
                            },
                            {
                                "sTitle": "Auto Start Period(ms)",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "auto_start_period",
                            },
                            {
                                "sTitle": "Auto Stop Mode",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "auto_stop_mode",
                            },
                            {
                                "sTitle": "Auto Stop GPIO Level",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "auto_stop_gpi_level",
                            },
                            {
                                "sTitle": "Auto Stop Duration(ms)",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "auto_stop_duration",
                            },

                            {
                                "sTitle": "Enabled",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "is_enabled",
                            },
                            {
                                "sTitle": "Action",
                                "bSortable": false,
                                "fnRender": function (obj) {
                                    return '<div class="hidden-phone visible-desktop action-buttons">'
                                            + '&nbsp;'
                                            + '<a href="#"   class="Green"  title="Edit" onClick="onEditGPI(' + obj.aData.id + '); return false;">'
                                            + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                            + '</a>'
                                            + '&nbsp;'
                                            + '<a href="#"   class="Red"  title="Delete" onclick="onConfirmDeleteGPI(' + obj.aData.no + '); return false;" >'
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
                                            + '						<a href="#"    class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEditGPI(' + obj.aData.id + '); return false;">'
                                            + '							<span class="green">'
                                            + '								<i class="icon-edit bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + ''
                                            + '					<li>'
                                            + '						<a href="#"   class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDeleteGPI(' + obj.aData.no + '); return false;">'
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

            var aaData = getDataGPI();
            oTable = $('#dt_outgpi').dataTable({
                "aaData": aaData,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "5%", "aTargets": [0] },
                { "sWidth": "8%", "aTargets": [1] },
                { "sWidth": "5%", "aTargets": [2] },
                { "sWidth": "7%", "aTargets": [3] },
                { "sWidth": "10%", "aTargets": [4] },
                { "sWidth": "10%", "aTargets": [5] },
                { "sWidth": "10%", "aTargets": [6] },
                { "sWidth": "10%", "aTargets": [7] },
                { "sWidth": "10%", "aTargets": [8] },
                { "sWidth": "5%", "aTargets": [9] },
                { "sWidth": "5%", "aTargets": [10] },
                ],
                "aoColumns": columns,
                "bDestroy": true,
                "fnDrawCallback": function () {

                }

            });
        }

        function getDataGPI() {
            var jsonobject = JSON.parse(localStorage['gpidata']);
            var aaData = [];
            aaData = jsonobject;
            return aaData;
        }

        function onEditGPI(id) {

            onValidGPIHide();
            //Find data in current session
            if (id > 0) {
                var jsonobject = JSON.parse(localStorage['gpidata']);
                var editjsonobject = getObjects(jsonobject, 'id', id);

                $.each(editjsonobject, function (key, val) {
                    $('#HiddenGPIId').val(val.id);
                    $('#txtPortNumberGPI').val(val.port_number);
                    $('#txtDebounce').val(val.debounce_in_ms);
                    $('#cbAutoStartMode').val(val.auto_start_mode);
                    $('#cbAutoStartGPILevel').val(val.auto_start_gpi_level);
                    $('#txtAutoStartFirstDelay').val(val.auto_start_first_delay);
                    $('#txtAutoStartPeriod').val(val.auto_start_period);
                    $('#cbAutoStopMode').val(val.auto_stop_mode);
                    $('#cbAutoStopGPILevel').val(val.auto_stop_gpi_level);
                    $('#txtAutoStopDuration').val(val.auto_stop_duration);
                    $("#ckbGPIEnable").prop("checked", false);

                    $('#txtGPIBrandName').val(val.brand_name);
                    $('#txtGPIModelName').val(val.model_name);

                    populateSelectAutoStartMode(val.auto_start_mode);
                    populateSelectAutoStartGPILevel(val.auto_start_gpi_level);
                    populateSelectAutoStopMode(val.auto_stop_mode);
                    populateSelectAutoStopGPILevel(val.auto_stop_gpi_level);
                    if (val.is_enabled == "True") {
                        $("#ckbGPIEnable").prop("checked", true);
                    } else {
                        $("#ckbGPIEnable").prop("checked", false);
                    }
                })

            } else {
                clearGPI();
                $("#ckbGPIEnable").prop("checked", true);
            }


            $("#dialog-edit-gpi").dialog({
                autoOpen: false,
                resizable: false,
                width: "720px",
                modal: true,
                buttons: {
                    "Save": function () {
                        var checkvalid = onValidGPI();
                        if (checkvalid == true) {

                            if (checkid_duplicate_gpi($('#txtPortNumberGPI').val(), $('#HiddenGPIId').val()) == false) {
                                $('#txtPortNumberGPI').focus();
                                onAlert("Port number already exists. Please modify Port number");
                            }
                            else if ($('#HiddenSpeedwayDefaultMaxGPI').val() < $('#txtPortNumberGPI').val()) {
                                $('#txtPortNumberGPI').focus();
                                onAlert(" please specify port number less than " + $('#HiddenSpeedwayDefaultMaxGPI').val());
                            }
                            else {
                                onSaveGPI(id);
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
                titledialog = "GPIO";
            } else {
                titledialog = "Edit GPIO";
            }

            $("#dialog-edit-gpi").dialog("option", "title", titledialog).dialog("open");
        }

        function checkid_duplicate_gpi(port_number, id) {
            var jsonobject = JSON.parse(localStorage['gpidata']);
            var checkjsonobject = getObjects(jsonobject, 'port_number', port_number);
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

        function onValidGPIHide() {
            $("#lblvalid_PortNumberGPI").hide();
            $("#lblvalid_Debounce").hide();
            $("#lblvalid_AutoStartFirstDelay").hide();
            $("#lblvalid_AutoStartPeriod").hide();
            $("#lblvalid_AutoStopDuration").hide();
            $("#lblvalid_GPIBrandName").hide();
            $("#lblvalid_GPIModelName").hide();
        }

        function onValidGPI() {

            var isValid;
            isValid = true;

            var port_number = $('#txtPortNumberGPI').val();
            var debounce = $('#txtDebounce').val();
            var AutoStartFirstDelay = $('#txtAutoStartFirstDelay').val();
            var AutoStartPeriod = $('#txtAutoStartPeriod').val();
            var AutoStopDuration = $('#txtAutoStopDuration').val();
            var brand_name = $('#txtGPIBrandName').val();
            var model_name = $('#txtGPIModelName').val();


            if (port_number == '') {
                $("#lblvalid_PortNumberGPI").show();
                isValid = false;
                return;
            } else {

                $("#lblvalid_PortNumberGPI").hide();

            }
            if (debounce == '') {
                $("#lblvalid_Debounce").show();
                isValid = false;
                return;
            } else {

                $("#lblvalid_Debounce").hide();

            }
            if (AutoStartFirstDelay == '') {
                $("#lblvalid_AutoStartFirstDelay").show();
                isValid = false;
                return;
            } else {
                $("#lblvalid_AutoStartFirstDelay").hide();

            }
            if (AutoStartPeriod == '') {
                $("#lblvalid_AutoStartPeriod").show();
                isValid = false;
                return;
            } else {
                $("#lblvalid_AutoStartPeriod").hide();

            }
            if (AutoStopDuration == '') {
                $("#lblvalid_AutoStopDuration").show();
                isValid = false;
                return;
            } else {
                $("#lblvalid_AutoStopDuration").hide();

            }
            if (brand_name == '') {
                $("#lblvalid_GPIBrandName").show();
                isValid = false;
                return;
            } else {

                $("#lblvalid_GPIBrandName").hide();

            }

            if (model_name == '') {
                $("#lblvalid_GPIModelName").show();
                isValid = false;
                return;
            } else {

                $("#lblvalid_GPIModelName").hide();

            }

            return isValid;
        }

        function deleteDataGPI(no) {
            var jsonobject = JSON.parse(localStorage['gpidata']);
            var aaData = [];
            aaData = jsonobject;
            aaData.splice(parseInt(no) - 1, 1);
            //running inndex bew
            var icount = 1;
            $.each(aaData, function (key, val) {
                aaData[icount - 1].no = icount;
                icount = icount + 1
            })
            localStorage['gpidata'] = JSON.stringify(aaData);
            LoadDataGPI(0);
        }

        function onConfirmDeleteGPI(id) {
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
                                    deleteDataGPI(id);
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

    <%--tag filter--%>
    <input id="HiddenTagFilterId" value="0" type="hidden" />
    <script type="text/javascript">
        function onSaveTagFilter(id) {
            var tag_filter_no = $('#txtTagFilter').val();
            var memory_bank = $('#cbMemoryBank').val();
            var bit_pointer = $('#txtBitPointer').val();
            var bit_count = $('#txtBitCount').val();
            var tag_mask = $('#txtTagMask').val();
            var filter_op = $('#cbFilterOp').val();

            //running no
            var rows = $("#dt_outtagfilter").dataTable().fnGetNodes();

            //data in current session
            var jsonobject = JSON.parse(localStorage['tagfilterdata']);
            var aaData = [];
            aaData = jsonobject;
            //add data in current session

            if (id == 0) {
                aaData.push({
                    "no": parseInt(rows.length) + 1,
                    "id": parseInt(rows.length) + 1,
                    "tag_filter_no": tag_filter_no,
                    "memory_bank": memory_bank,
                    "bit_pointer": bit_pointer,
                    "bit_count": bit_count,
                    "tag_mask": tag_mask,
                    "filter_op": filter_op
                });
            } else {//edit data in current session
                for (var i = 0; i < aaData.length; i++) {
                    if (aaData[i].id == id) {
                        aaData[i].tag_filter_no = tag_filter_no;
                        aaData[i].memory_bank = memory_bank;
                        aaData[i].bit_pointer = bit_pointer;
                        aaData[i].bit_count = bit_count;
                        aaData[i].tag_mask = tag_mask;
                        aaData[i].filter_op = filter_op
                        break;
                    }
                }

            }


            //update data in session
            localStorage['tagfilterdata'] = JSON.stringify(aaData);

            // Reload
            LoadDataTagFilter(0);
            clearTagFilter();
        }

        function clearTagFilter() {
            $('#txtTagFilter').val("");
            //$('#cbMemoryBank').val("");
            $('#txtBitPointer').val("");
            $('#txtBitCount').val("");
            $('#txtTagMask').val("");
            //$('#cbFilterOp').val("");
            $('#HiddenTagFilterId').val("0");
            populateSelectMemoryBank("");
            populateSelectFilterOp("");
        }

        function LoadDataTagFilter(id) {
            var param = "{'id':" + JSON.stringify(id) + "}";
            var dataurl = 'WebService/WebService.asmx/LoadRFIDConfigScheduleTagFilter';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": PopulateGridTagFilter
            });
        }

        function PopulateGridTagFilter(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var yetVisited = localStorage['tagfilterdata'];
            if (yetVisited.length > 0) {

            }
            else {
                localStorage['tagfilterdata'] = jsondata.d;
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
                                "sTitle": "Tag Filter",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "tag_filter_no"

                            },
                            {
                                "sTitle": "Memory Bank",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "memory_bank",
                            },
                            {
                                "sTitle": "Bit Pointer",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "bit_pointer",
                            },
                            {
                                "sTitle": "Bit Count",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "bit_count",
                            },
                            {
                                "sTitle": "Tag Mask",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "tag_mask",
                            },
                            {
                                "sTitle": "Filter Op",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "filter_op",
                            },
                            {
                                "sTitle": "Action",
                                "bSortable": false,
                                "fnRender": function (obj) {
                                    return '<div class="hidden-phone visible-desktop action-buttons">'
                                            + '&nbsp;'
                                            + '<a href="#"   class="Green"  title="Edit" onClick="onEditTagFilter(' + obj.aData.id + '); return false;">'
                                            + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                            + '</a>'
                                            + '&nbsp;'
                                            + '<a href="#"   class="Red"  title="Delete" onclick="onConfirmDeleteTagFilter(' + obj.aData.no + '); return false;" >'
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
                                            + '						<a href="#"    class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEditTagFilter(' + obj.aData.id + '); return false;">'
                                            + '							<span class="green">'
                                            + '								<i class="icon-edit bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + ''
                                            + '					<li>'
                                            + '						<a href="#"   class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDeleteTagFilter(' + obj.aData.no + '); return false;">'
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

            var aaData = getDataTagFilter();
            oTable = $('#dt_outtagfilter').dataTable({
                "aaData": aaData,
                "bAutoWidth": false,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "20%", "aTargets": [1] },
                { "sWidth": "20%", "aTargets": [2] },
                { "sWidth": "10%", "aTargets": [3] },
                { "sWidth": "10%", "aTargets": [4] },
                { "sWidth": "10%", "aTargets": [5] },
                { "sWidth": "10%", "aTargets": [6] },
                ],
                "aoColumns": columns,
                "bDestroy": true,
                "fnDrawCallback": function () {

                }

            });
        }

        function getDataTagFilter() {
            var jsonobject = JSON.parse(localStorage['tagfilterdata']);
            var aaData = [];
            aaData = jsonobject;
            return aaData;
        }

        function onEditTagFilter(id) {

            onValidTagFilterHide();
            //Find data in current session
            if (id > 0) {
                var jsonobject = JSON.parse(localStorage['tagfilterdata']);
                var editjsonobject = getObjects(jsonobject, 'id', id);
                $.each(editjsonobject, function (key, val) {
                    $('#HiddenTagFilterId').val(val.id);
                    $('#txtTagFilter').val(val.tag_filter_no);
                    $('#cbMemoryBank').val(val.memory_bank);
                    $('#txtBitPointer').val(val.bit_pointer);
                    $('#txtBitCount').val(val.bit_count);
                    $('#txtTagMask').val(val.tag_mask);
                    $('#cbFilterOp').val(val.filter_op);

                    populateSelectMemoryBank(val.memory_bank);
                    populateSelectFilterOp(val.filter_op);
                })

            } else {
                clearTagFilter();
            }


            $("#dialog-edit-tagfilter").dialog({
                autoOpen: false,
                resizable: false,
                width: "500px",
                modal: true,
                buttons: {
                    "Save": function () {
                        var checkvalid = onValidTagFilter();
                        if (checkvalid == true) {

                            if (checkid_duplicate_tag_filter($('#txtTagFilter').val(), $('#HiddenTagFilterId').val()) == false) {
                                onAlert("Tag Filter already exists. Please modify Tag Filter ");
                            } else {
                                onSaveTagFilter(id);
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
                titledialog = "Tag Filter";
            } else {
                titledialog = "Edit Tag Filter";
            }

            $("#dialog-edit-tagfilter").dialog("option", "title", titledialog).dialog("open");
        }

        function checkid_duplicate_tag_filter(tag_filter_no, id) {
            var jsonobject = JSON.parse(localStorage['tagfilterdata']);
            var checkjsonobject = getObjects(jsonobject, 'tag_filter_no', tag_filter_no);
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

        function onValidTagFilterHide() {
            $("#lblvalid_TagFilter").hide();
            $("#lblvalid_MemoryBank").hide();
            $("#lblvalid_BitPointer").hide();
            $("#lblvalid_BitCount").hide();
            $("#lblvalid_TagMask").hide();
            $("#lblvalid_FilterOp").hide();
        }

        function onValidTagFilter() {
            var isValid;
            isValid = true;

            var tag_filter_no = $('#txtTagFilter').val();
            var memory_bank = $('#cbMemoryBank').val();
            var bit_pointer = $('#txtBitPointer').val();
            var bit_counter = $('#txtBitCount').val();
            var tag_mask = $('#txtTagMask').val();
            var filter_op = $('#cbFilterOp').val();

            if (tag_filter_no == '') {
                $("#lblvalid_TagFilter").show();
                isValid = false;
            } else {

                $("#lblvalid_TagFilter").hide();

            }
            if (memory_bank == '') {
                $("#lblvalid_MemoryBank").show();
                isValid = false;
            } else {

                $("#lblvalid_MemoryBank").hide();

            }
            if (bit_pointer == '') {
                $("#lblvalid_BitPointer").show();
                isValid = false;
            } else {
                $("#lblvalid_BitPointer").hide();

            }
            if (bit_counter == '') {
                $("#lblvalid_BitCount").show();
                isValid = false;
            } else {
                $("#lblvalid_BitCount").hide();

            }
            if (tag_mask == '') {
                $("#lblvalid_TagMask").show();
                isValid = false;
            } else {
                $("#lblvalid_TagMask").hide();

            }
            if (filter_op == '') {
                $("#lblvalid_FilterOp").show();
                isValid = false;
            } else {
                $("#lblvalid_FilterOp").hide();

            }

            return isValid;
        }

        function deleteDataTagFilter(no) {
            var jsonobject = JSON.parse(localStorage['tagfilterdata']);
            var aaData = [];
            aaData = jsonobject;
            //delete position 1 to 1 record
            aaData.splice(parseInt(no) - 1, parseInt(no));
            //running inndex bew
            var icount = 1;
            $.each(aaData, function (key, val) {
                aaData[icount - 1].no = icount;
                icount = icount + 1
            })
            localStorage['tagfilterdata'] = JSON.stringify(aaData);
            LoadDataTagFilter(0);
        }

        function onConfirmDeleteTagFilter(id) {
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
                                    deleteDataTagFilter(id);
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

