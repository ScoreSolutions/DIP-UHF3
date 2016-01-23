<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmBorrowByDate.aspx.vb" Inherits="frmBorrowByDate" %>

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
                            <li class="active">รายงานการยืมแฟ้มประจำวัน</li>
                        </ul>
                        <!--.breadcrumb-->


                        <!--#nav-search-->
                    </div>

                    <div class="page-content">


                        <div class="row-fluid">
                            <div class="span12">
                                <!--PAGE CONTENT BEGINS-->


                                <div class="row-fluid">
                                    <h3 class="header smaller lighter blue">รายงานการยืมแฟ้มประจำวัน</h3>


                                    <div class="dt_out_actions" style="display: none">
                                        <div class="btn-group pull-Left">
                                            <button class="btn btn-app btn-info btn-mini no-radius" id="btnPrint" name="btnPrint">
                                                <i class="icon-print bigger-100"></i>
                                                Print
                                            </button>
                                            <button class="btn btn-app btn-success btn-mini no-radius" id="btnAddnew" name="btnAddnew">
                                                <i class="icon-folder-open bigger-100"></i>
                                                Add New
                                            </button>
                                            <button class="btn btn-app btn-danger btn-mini no-radius" id="btnDelete" name="btnDelete">
                                                <i class="icon-trash bigger-100"></i>
                                                Delete
                                            </button>

                                        </div>
                                    </div>
                                </div>

                                <!--/PAGE CONTENT BEGINS-->

                                <div class="row-fluid">
                                    <div class="span2">
                                        <label class="control-label" for="lblBrrowDate">วันที่ยืม</label>

                                    </div>
                                    <div class="span4">
                                        <div class="row-fluid input-append">
                                            <input class="date-picker" id="datefrom" type="text" data-date-format="dd/mm/yyyy" />
                                            <span class="add-on">
                                                <i class="icon-calendar"></i>
                                            </span>
                                        </div>
                                        <span id="lblvaliddatefrom" class="color red" style="display: none">กรุณากรอกข้อมูล</span>
                                        <span id="lblvaliddatecompare" class="color red" style="display: none">กรุณาตรวจสอบวันที่</span>
                                    </div>
                                    <div class="span1">
                                        <label class="control-label" for="lblMeetingTime">ถึง</label>

                                    </div>
                                    <div class="span4">
                                        <div class="row-fluid input-append">
                                            <input class="date-picker" id="dateto" type="text" data-date-format="dd/mm/yyyy" />
                                            <span class="add-on">
                                                <i class="icon-calendar"></i>
                                            </span>
                                        </div>
                                        <span id="lblvaliddateto" class="color red" style="display:none">กรุณากรอกข้อมูล</span>
                                    </div>
                                    
                                </div>

                                <div class="row-fluid">
                                    <div class="span2">
                                        <label class="control-label" for="lblBorrowType">ลักษณะการยืม</label>
                                    </div>
                                    <div class="span10">
                                        <div class="control-group">
											<div class="controls">
                                                <div class="span2">
                                                    <label>
                                                        <input name="form-field-radio" type="radio" id="rdByRoom"/>
                                                        <span >ยืมที่ห้องแฟ้ม</span>
                                                    </label>
                                                </div>

                                                <div class="span2">
                                                    <label>
                                                        <input name="form-field-radio" type="radio" id="rdByTransfer" />
                                                        <span >ยืมโดยการโอน</span>
                                                    </label>
                                                </div>

                                                <div class="span2">
                                                    <label>
                                                        <input name="form-field-radio" type="radio" id="rdByAll"  checked="checked" />
                                                        <span >ทั้งหมด</span>
                                                    </label>
                                                </div>
												
											</div>
										</div>
                                    </div>
                                </div>

                                <div class="row-fluid">
                                    <div class="span2">
                                        <label class="control-label" for="lblStatus">สถานะแฟ้ม</label>
                                    </div>
                                    <div class="span10">
                                        <div class="control-group">
											<div class="controls">
                                                <div class="span2">
                                                    <label>
                                                        <input name="form-field-radio2" type="radio" id="rdStatusReturned" />
                                                        <span >คืนแล้ว</span>
                                                    </label>
                                                </div>

                                                <div class="span2">
                                                    <label>
                                                        <input name="form-field-radio2" type="radio" id="rdStatusNoReturn" />
                                                        <span >ยังไม่ได้คืน</span>
                                                    </label>
                                                </div>

                                                <div class="span2">
                                                    <label>
                                                        <input name="form-field-radio2" type="radio" id="rdStatusAll" checked="checked" />
                                                        <span >ทั้งหมด</span>
                                                    </label>
                                                </div>
												
											</div>
										</div>
                                    </div>
                                </div>



                                <div class="row-fluid">
                                    <div class="span4">
                                        <label class="control-label" for="lblBuilding2"></label>
                                    </div>
                                    <div class="span8">
                                        <button class="btn btn-primary" type="button" id="btnSearch">
                                            <i class="icon-search  bigger-110"></i>
                                            ค้นหา
                                        </button>


                                        &nbsp; &nbsp; &nbsp;
									<button class="btn" type="reset" id="btnClear">
                                        <i class="icon-undo bigger-110"></i>
                                        ล้างข้อมูล
                                    </button>
                                    </div>

                                </div>
                            </div>
                            <div class="row-fluid">
                                <br />
                                <div>
                                    <h3 class="header smaller lighter blue"></h3>
                                </div>
                            </div>

                            <div class="row-fluid">
                                <div class="span12">
                                   <iframe id="myframe" src="" frameborder="0" height="600px" width="100%" scrolling="auto"></iframe>
                                </div>
                            </div>

                            <!--/PAGE CONTENT END-->
                        </div>


                        <!--/.span-->
                    </div>
                    <!--/.row-fluid-->

                    <!--/.page-content-->


                </div>

     <script type="text/javascript">
         $(document).ready(function () {
           
             //Search
             $("#btnSearch").click(function () {
                 if (onValid() == true) {
                     populateSearch();
                 }
             });


                $("#btnClear").click(function () {
                    clearInput();
                });

                //ปฎิธิน
                $('.date-picker').datepicker({ "autoclose": true }).next().on(ace.click_event, function () {

                    $(this).prev().focus();
                });



            });
        </script>
        <script type="text/javascript">
            function onValidHide() {
                $("#lblvaliddatefrom").hide();
                $("#lblvaliddateto").hide();

            }

            function onValid() {
                var isValid;
                isValid = true;
                var datefrom = $('#datefrom').val();
                var dateto = $('#dateto').val();
                if (datefrom == '') {
                    $("#lblvaliddatefrom").show();
                    isValid = false;
                } else {
                    $("#lblvaliddatefrom").hide();

                }
                if (dateto == '') {
                    $("#lblvaliddateto").show();
                    isValid = false;
                } else {
                    $("#lblvaliddateto").hide();

                }

                if (datefrom != '' && dateto != '') {
                    if (comparedate(datefrom, dateto) == false) {
                        $("#lblvaliddatecompare").show();
                        $("#lblvaliddateto").hide();
                        $("#lblvaliddatefrom").hide();
                        isValid = false;
                    } else {
                        $("#lblvaliddatecompare").hide();

                    }
                }


                return isValid;


            }

            function comparedate(strdatefrom, strdateto) {

                if (strdatefrom != '' && strdateto != '') {
                    var datefromarr = strdatefrom.split('/');
                    var datetoarr = strdateto.split('/');
                    var dfrom = Date.parse(datefromarr[2] + '-' + datefromarr[1] + '-' + datefromarr[0]);
                    var dto = Date.parse(datetoarr[2] + '-' + datetoarr[1] + '-' + datetoarr[0]);
                    ;
                    if (dfrom > dto) {
                        return false
                    } else {
                        return true
                    }
                } else {
                    return false
                }
            }

            function clearInput() {
                $("#datefrom").val("");
                $("#dateto").val("");
                $("#rdByRoom").prop("checked", false);
                $("#rdByTransfer").prop("checked", false);
                $("#rdByAll").prop("checked", true);
                $("#rdStatusReturned").prop("checked", false);
                $("#rdStatusNoReturn").prop("checked", false);
                $("#rdStatusAll").prop("checked", true);
                $('#myframe').attr('src', '');
            }

            function populateSearch() {
        
                var hostreport = $('#' + '<%=Master.FindControl("lblhostreport").ClientID%>').text();
                var reportname = 'frmBorrowByDate';
                var datefrom = $('#datefrom').val();
                var dateto = $('#dateto').val();
                var borrowbyRoom = $("#rdByRoom").is(":checked")
                var borrowbyTransfer = $("#rdByTransfer").is(":checked")
                var borrowbyAll = $("#rdByAll").is(":checked")
                var filestatusReturned = $("#rdStatusReturned").is(":checked")
                var filestatusNoReturned = $("#rdStatusNoReturn").is(":checked")
                var filestatusAll = $("#rdStatusAll").is(":checked")

                var filestatus = '';
                if (filestatusReturned == true) {
                    filestatus = 1;
                } else if (filestatusNoReturned == true) {
                    filestatus = 2;
                } else if (filestatusAll == true) {
                    filestatus = 3;
                }
                
                var borrowType = '';
                if (borrowbyRoom == true) {
                    borrowType = 1;
                } else if (borrowbyTransfer == true) {
                    borrowType = 2;
                } else if (borrowbyAll == true) {
                    borrowType = 3;
                }
             

                var fullname = encodeURIComponent($('#' + '<%=Master.FindControl("lblfullname").ClientID%>').text());

                var para = hostreport + '?reportname=' + reportname + '&statusreturntype=' + filestatus + '&borrowtype=' + borrowType + '&datefrom=' + datefrom + '&dateto=' + dateto + '&fullname=' + fullname;
              
                $("#myframe").attr('src', para);
            }

           
        </script>
</asp:Content>

