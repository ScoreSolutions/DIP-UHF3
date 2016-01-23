<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmTimeLine.aspx.vb" Inherits="frmTagRoot" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="JavaScript" src="js/jquery.balloon.js"> </script> 
    <script type="text/javascript" language="JavaScript" src="js/jquery.balloon.min.js"> </script> 

  <script type="text/javascript">
     
      $(function () {
          // $('selectors').balloon(options);
          //$('#div111').balloon({
          //    contents: '<a href="#">Any HTML!</a><br />'
          //      + '<input type="text" size="40" />'
          //      + '<input type="submit" value="Search" />'
          //});

          $('#divTimeLine').balloon({
              contents:  '<%= DisplayFunction()%>'
          });
      });
     
</script>


    <form id="form1" runat="server">
        <div class="main-content">
            <div class="breadcrumbs" id="breadcrumbs">
                <ul class="breadcrumb">
                    <li>
                        <i class="icon-home home-icon"></i>
                        <a href="frmDefault.aspx">หน้าหลัก</a>

                        <span class="divider">
                            <i class="icon-angle-right arrow-icon"></i>
                        </span>
                    </li>
                    <li class="active">สถานะการจดทะเบียนสิทธิบัตร/อนุสิทธิบัตร</li>
                </ul>
                <!--.breadcrumb-->

              
                <!--#nav-search-->
            </div>

            <div class="page-content">


                <div class="row-fluid">
                    <div class="span12">
                        <!--PAGE CONTENT BEGINS-->


                        <div class="row-fluid">
                            <h3 class="header smaller lighter blue">สถานะการจดทะเบียนสิทธิบัตร/อนุสิทธิบัตร</h3>
                         
              
                        
                         <!--/PAGE CONTENT BEGINS-->
                        
                        <div class="row-fluid">
                            <table>
                                <tr>
                                    <td>
                                       <%-- <asp:Label ID="lblTag" Text="เลขแฟ้ม :" Height="30px" runat="server" ></asp:Label>--%>
                                         <label class="control-label" for="lblAtendent">เลขที่แฟ้ม: </label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTag" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="vertical-align: top">
                                        <button class="btn btn-small btn-primary" style="width:100px"  type="button" runat="server" id="btnSearch" onserverclick="btnSearch_ServerClick">
                                            <i class=" icon-search bigger-110" ></i>
                                            ค้นหา
                                        </button>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                            <center>
                            
                            <table>
                                 <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                 </tr>
                                <tr>
                                    <td>
                                    <asp:Panel ID="pnl1" runat="server" >
                                        <asp:Label ID="Label1" runat="server" Text="สร้างคำขอใหม่เบื้องต้น	"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" Width="130" Text=" "></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text="ยื่นคำขอเบื้องต้น"></asp:Label>
                                        <asp:Label ID="Label5" runat="server" Width="190" Text=" "></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text="จดทะเบียน"></asp:Label>
                                    </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=" padding-left:20px">
                                      <div id="divTimeLine">
                                      <asp:Image ID="imgTimeLine" ImageUrl="images\0.png" runat="server"  ></asp:Image>
                                      </div>
                                    </td>
                              </tr>
                                 <tr>
                                    <td>
                                        <br />
                                        <br />
                                    </td>
                                 </tr>
                                <tr>
                                    <td style="padding-left:210px">
                                         <asp:Label ID="Label6" runat="server" Text="Document Life Cycle" Font-Bold="true" Font-Size="Larger"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            </center>
                            <center>
                                <table>
                                     <tr>
                                    <td>
                                       
                                        <br />
                                        <br />
                                    </td>
                                 </tr>
                                    <tr>
                                        <td >
                                           <asp:Literal runat="server" ID="Ltl1"></asp:Literal>
                                           
                                        </td>
                                    </tr>
                                     <tr>
                                    <td>
                                       
                                        <br />
                                        <br />
                                    </td>
                                 </tr>
                                    <tr>
                                        <td style=" padding-left:100px"> 
                                            <asp:Chart ID="Chart1" runat="server" Width="700px">
                                                <series>
                                                    <asp:Series Name="Series1">
                                                    </asp:Series>
                                                     <asp:Series Name="Series2">
                                                    </asp:Series>
                                                </series>
                                                <chartareas>
                                                    <asp:ChartArea Name="ChartArea1">
                                                        <AxisX IsStartedFromZero="true" Title="ชื่อเจ้าหน้าที่" titlefont="Arial, 10pt, style=Bold"></AxisX>
                                                        <AxisY Title="จำนวนวัน" titlefont="Arial, 10pt, style=Bold"></AxisY>
                                                    </asp:ChartArea>
                                                </chartareas>
                                            </asp:Chart >
                                        </td>
                                    <td style="vertical-align:text-top; padding-top:40px">
                                        <asp:Button runat="server" id="btnAvg" BackColor="Red" Width="30"  Enabled="false"  Visible="false"/>&nbsp;&nbsp;
                                        <asp:Label ID="lblAvgVal" runat="server" Text=""></asp:Label>
                                    </td>
                                    </tr>
                                    </table>

                            </center>
                        </div>



                    </div>

                </div>




                <!--/PAGE CONTENT END-->

            </div>

        </div>
        <!--/.span-->
       
        <!--/.row-fluid-->
               <!--/.page-content-->

        <div class="ace-settings-container" id="ace-settings-container">
            <div class="btn btn-app btn-mini btn-warning ace-settings-btn" id="ace-settings-btn">
                <i class="icon-cog bigger-150"></i>
            </div>

            <div class="ace-settings-box" id="ace-settings-box">
                <div>
                    <div class="pull-left">
                        <select id="skin-colorpicker" class="hide">
                            <option data-class="default" value="#438EB9" />
                            #438EB9
									<option data-class="skin-1" value="#222A2D" />
                            #222A2D
									<option data-class="skin-2" value="#C6487E" />
                            #C6487E
									<option data-class="skin-3" value="#D0D0D0" />
                            #D0D0D0
                        </select>
                    </div>
                    <span>&nbsp; Choose Skin</span>
                </div>

                <div>
                    <input type="checkbox" class="ace-checkbox-2" id="ace-settings-header" />
                    <label class="lbl" for="ace-settings-header">Fixed Header</label>
                </div>

                <div>
                    <input type="checkbox" class="ace-checkbox-2" id="ace-settings-sidebar" />
                    <label class="lbl" for="ace-settings-sidebar">Fixed Sidebar</label>
                </div>

                <div>
                    <input type="checkbox" class="ace-checkbox-2" id="ace-settings-breadcrumbs" />
                    <label class="lbl" for="ace-settings-breadcrumbs">Fixed Breadcrumbs</label>
                </div>

                <div>
                    <input type="checkbox" class="ace-checkbox-2" id="ace-settings-rtl" />
                    <label class="lbl" for="ace-settings-rtl">Right To Left (rtl)</label>
                </div>
            </div>
        </div>
        <!--/#ace-settings-container-->
        </div>
    <script type="text/javascript">
        $(function () {


            //Combo Box
            $(".chzn-select").chosen();

            //ปฎิธิน
            $('.date-picker').datepicker().next().on(ace.click_event, function () {
                $(this).prev().focus();
            });

            //Spinner
            $('#spinner1').ace_spinner({ value: 0, min: 0, max: 10000, step: 1, icon_up: 'icon-caret-up', icon_down: 'icon-caret-down' });




        });



        function NextPage() {
            var txtPurpose = $("#txtPurpose").val();
            // alert(txtPurpose);
            // window.location.href = "frmSelectRoom.aspx";
            SetUserName();
        }

        function SetUserName() {
            alert(23223);

            $.session.set("compareLeftContent", "value");
            alert($.session.get("compareLeftContent"));


        }

        function GetUserName() {


        }
    </script>
       
    </form>
    
</asp:Content>


