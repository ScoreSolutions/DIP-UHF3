<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmSearchTimelineByFile.aspx.vb" Inherits="frmSearchTimelineByFile" %>

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
                <li class="active">Document life Cycle</li>
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
                    <h3 class="header smaller lighter blue">Document life Cycle</h3>
<%--                    <div class="row-fluid">
                        <div class="span2">
                            <label class="control-label" for="lblAtendent">เลขที่คำขอ :</label>

                        </div>
                        <div class="span10">
                            <input type="text" class="input-medium search-query" id="txtApp_No" onkeypress="return Numbers(event);" maxlength="10" />
                           
                            <button id="btnSearch" class="btn btn-primary btn-small">
                                ค้นหา <i class="icon-search icon-on-left bigger-110"></i>
                            </button> 
                            <span class="color red" id="lblvalidtxtApp_no" style="display: none">กรุณาระบุเลขที่คำขอ</span>
                        </div>
                    </div>--%>
                    
                    <div class="row-fluid">
                        <div class="span2">
                            <label class="control-label" for="lblBrrowDate">วันที่รับคำขอ</label>

                        </div>
                        <div class="span4">
                            <div class="row-fluid input-append">
                                <input class="date-picker" id="datefrom" type="text" data-date-format="dd/mm/yyyy" />
                                <span class="add-on">
                                    <i class="icon-calendar"></i>
                                </span>
                            </div>
                             <span  id="lblvaliddatefrom" class="color red" style="display:none">กรุณากรอกข้อมูล</span>
                              <span  id="lblvaliddatecompare" class="color red" style="display:none">กรุณาตรวจสอบวันที่</span>
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
                            <label class="control-label" for="lblBorrowType">ประเภทสิทธิบัตร</label>
                        </div>
                        <div class="span10">
                            <div class="control-group">
                                <div class="controls">
                                    <div class="span3">
                                        <label>
                                            <input name="form-field-radio" type="radio" id="rdByPatentType1"  checked="checked" />
                                            <span>สิทธิบัตรการประดิษฐ์</span>
                                        </label>
                                    </div>

                                    <div class="span4">
                                        <label>
                                            <input name="form-field-radio" type="radio" id="rdByPatentType3" />
                                            <span>อนุสิทธิบัตร</span>
                                        </label>
                                    </div>

                                    <div class="span3" style="display:none">
                                        <label>
                                            <input name="form-field-radio" type="radio" id="rdByPatentType2"/>
                                            <span>สิทธิบัตรการออกแบบผลิตภัณฑ์</span>
                                        </label>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="space-2"></div>
                                    <div class="row-fluid">
                        <div class="span4">
                            <label class="control-label" for="lblBuilding2"></label>
                        </div>
                        <div class="span8">
                            <button  class="btn btn-primary" type="button" id="btnSearch">
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

                    <div class="space-4"></div>
                    <div class="row-fluid" id="divNotFound" style="display: none">
                        <div class="span2">
                        </div>
                        <div class="span10">
                            <strong class="color red">ไม่พบข้อมูล</strong>
                            <%--         <label class="control-label " for="lblNotFound"></label>--%>
                        </div>
                    </div>
                    <div class="hr hr10" id="divFoundLine" style="display: none"></div>
                    
                                   <div class="row-fluid">
                            <div class="span12" >


                                <iframe id="iFrame" frameborder="0" style="overflow: hidden; height: 450px; width: 100%" src=""></iframe>


                                <!--/PAGE CONTENT END-->

                            </div>

                        </div>





                </div>
                <!--/.span-->
            </div>


        </div>
    </div>

    <script type="text/javascript">

          //Open page
          $(document).ready(function () {

              $("#btnSearch").on('click', function () {
                  var invalid = onValid();
                  //alert(invalid);
                      if (invalid == true) {
                          setiframe();
                         // alert(12345);
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


          function clearInput() {
              $("#datefrom").val("");
              $("#dateto").val("");
              $("#rdByPatentType1").prop("checked", true);
              $("#rdByPatentType2").prop("checked", false);
              $("#rdByPatentType3").prop("checked", false);
              $('#iFrame').attr('src', '');
          }


          function setiframe() {

              var datefrom = $('#datefrom').val();
              var dateto = $('#dateto').val();

              var PatentType1 = $("#rdByPatentType1").is(":checked")
              var PatentType2 = $("#rdByPatentType2").is(":checked")
              var PatentType3 = $("#rdByPatentType3").is(":checked")
              var vPatentType;
              var vPatentType2;
              var vPatentType3;
         
              if (PatentType1 == true) {
                  vPatentType = 1;
              } else if (PatentType2 == true) {
                  vPatentType = 2;
              } else if (PatentType3 == true) {
                  vPatentType = 3;
              }


              //localStorage['appnodatatimeline'] = $('#txtApp_No').val();

              if (onValid() == true) {
                  localStorage['datefrom'] = datefrom;
                  localStorage['dateto'] = dateto;
                  localStorage['patenttype'] = vPatentType;

                  //alert(localStorage['datefrom']);
                  //alert(localStorage['dateto']);
                  //alert(localStorage['patenttype']);
                    $("#iFrame").attr('src', 'frmSearchTimelineByFileIFrame.aspx');
              }
              
          }

          function onValidHide() {
              $("#lblvalidname").hide();
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


          //////Hide Valid
          ////function onValidHide() {
          ////    $("#lblvalidtxtApp_no").hide();
          ////}
          //////Check Valid
          ////function onValid() {
          ////    var isValid;
          ////    isValid = true;
          ////    var app_no = $('#txtApp_No').val();
          ////    if (app_no == '') {
          ////        $("#lblvalidtxtApp_no").show();
          ////        isValid = false;
          ////    } else {
          ////        $("#lblvalidtxtApp_no").hide();
          ////    }
          ////    return isValid;
          ////}
      </script>
</asp:Content>

