<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmSearchFilebyUser.aspx.vb" Inherits="frmTagRoot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                    <li class="active">ติดตามการครอบครองแฟ้ม</li>
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


                        <div class="row-fluid">
                            <h3 class="header smaller lighter blue">ติดตามการครอบครองแฟ้ม</h3>
                            <%--     <div class="table-header">
                            View Demo
                        </div>--%>


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
                        <%-- <table class="table table-striped table-bordered table-hover" id="dt_out"></table>--%>
                       
                        
                        
                        
                        
                        
                        
                         <!--/PAGE CONTENT BEGINS-->
                        <div class="row-fluid">
                            <table>
                                <tr>
                                    <td>
                                        <%--<asp:Label ID="lblUser" Text="ชื่อเจ้าหน้าที่ :" Height="30px" runat="server"></asp:Label>--%>
                                         <label class="control-label" for="lblAtendent">ชื่อเจ้าหน้าที่ :</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUser" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="vertical-align: top">
                                        <button class="btn btn-small btn-primary" style="width:100px" type="button" runat="server" id="btnSearch" onserverclick="btnSearch_ServerClick">
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
                            <table>
                                 <tr>
                                    <td>
                                        <br />
                                        <br />
                                    </td>
                                 </tr>

                                <tr>
                                    <td>
                                        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" EmptyDataText="Data Not Found"
                                            CssClass="table table-condensed table-bordered " BorderWidth="0" GridLines="None" Width="970px"
                                             AllowSorting="True" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="ลำดับ" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Label ID="lblseq" runat="server" Text='<%# bind("seq") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="ชื่อ" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("user")%>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="แผนก" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDevision" runat="server" Text='<%# Bind("devision")%>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="แฟ้ม" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFile" runat="server" Text='<%# Bind("file")%>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                             
                                            </Columns>
                                            <HeaderStyle BackColor="gray" ForeColor="#ffffff"></HeaderStyle>
                                            <PagerSettings Visible="false" />
                                        </asp:GridView>

                                    </td>
                              </tr>
                            </table>
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


