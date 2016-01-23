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
                    <div class="row-fluid">
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
                    <div class="hr hr10" id="divFoundLine" style="display: none"></div>
                                   <div class="row-fluid">
                            <div class="span12">


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
          });



          function setiframe() {
              localStorage['appnodatatimeline'] = $('#txtApp_No').val();
              $("#iFrame").attr('src', 'frmSearchTimelineByFileIFrame.aspx');
          }

          //Hide Valid
          function onValidHide() {
              $("#lblvalidtxtApp_no").hide();
          }
          //Check Valid
          function onValid() {
              var isValid;
              isValid = true;
              var app_no = $('#txtApp_No').val();
              if (app_no == '') {
                  $("#lblvalidtxtApp_no").show();
                  isValid = false;
              } else {
                  $("#lblvalidtxtApp_no").hide();
              }
              return isValid;
          }
      </script>
</asp:Content>

