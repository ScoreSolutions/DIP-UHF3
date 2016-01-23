<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage2.master" AutoEventWireup="false" CodeFile="frmSignage.aspx.vb" Inherits="frmSignage" %>

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
                <li class="active">Sinage</li>
            </ul>

        </div>


        <div class="page-content">


            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->


                    <div class="row-fluid">
                        <h3 class="header smaller lighter blue">Signage</h3>

                    </div>

                    <!--/PAGE CONTENT BEGINS-->

                 
                </div>
              

                <div class="row-fluid">
                    <div class="span12">
                        <iframe id="myframe" src="" frameborder="0" height="600px" width="100%" scrolling="auto" runat="server"></iframe>
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
          
        });
       
    </script>
    
</asp:Content>

