<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_03_2.aspx.vb" Inherits="frmSignage_03_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .text_1 {
            font-family: tahoma;
            color: #FFF;
            font-weight: bold;
            font-size: 50px;
        }
    </style>
    <%--  <link href="assets/js/RGraph/css/website.css" rel="stylesheet" />
    <link href="assets/js/RGraph/css/ModalDialog.css" rel="stylesheet" />
    <link href="assets/js/RGraph/css/animations.css" rel="stylesheet" />--%>

    <link href="assets/bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="assets/bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery-2.0.3.min.js"></script>
    <%--    <script src="assets/js/jQuery.Marquee/jquery.marquee.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.core.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.tooltips.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.dynamic.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.key.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.drawing.rect.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.pie.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.bar.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.line.js"></script>--%>
    <script src="assets/js/Highcharts-4.1.5/js/highcharts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="center-block">
                    <div class="col-lg-12">
                        <img src="images/glowup_header2.png" width="100%" height="50px" />
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="center-block">
                    <div class="col-lg-6">
                       <h5><strong>สิทธิบัตรการประดิษฐ์</strong> </h5>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="center-block">
                    <div class="col-lg-12">
                        <div id="divPatenType1"></div>
                    </div>

                </div>

        </div>
     
        <div class="row">
            <div class="center-block">
                <div class="col-lg-6">
                    <h5><strong>อนุสิทธิบัตร</strong></h5>
                </div>
            </div>

        </div>
     <div class="row">
                <div class="center-block">
                    <div class="col-lg-12">
                         <div id="divPatenType2"></div>
                    </div>

                </div>

        </div>
        <div class="row">
            <div class="center-block">
                 <div class="col-lg-1"></div>
                <div class="col-lg-4">
                    <h5><strong>สิทธิบัตรการประดิษฐ์</strong></h5>
                      <div id="divPatenTypeYear1"></div>
               
                </div>
                      <div class="col-lg-1"></div>
                <div class="col-lg-1"></div>
                <div class="col-lg-4">
                    <h5><strong>อนุสิทธิบัตร</strong></h5>
                     <div id="divPatenTypeYear2"></div>
                </div>
                <div class="col-lg-1"></div>

            </div>
        </div>
        </div>
    </form>

     <script>
        $(document).ready(function () {
            LoadDataMonthType1();
            LoadDataMonthType3();
            LoadDataYearType1();
            LoadDataYearType3();
        })


        function LoadDataMonthType1() {
            var patent_id = 1;
            var param = "{'patent_id':" + JSON.stringify(patent_id) + "}";
            var dataurl = 'WebService/WebService.asmx/LoadGrowMonthFile';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                 
                    $("#divPatenType1").html(data.d);
                },
                error: function (xhr, status, error) {

                }
            });
            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

        function LoadDataMonthType3() {
            var patent_id = 3;
            var param = "{'patent_id':" + JSON.stringify(patent_id) + "}";
            var dataurl = 'WebService/WebService.asmx/LoadGrowMonthFile';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {

                    $("#divPatenType2").html(data.d);
                },
                error: function (xhr, status, error) {

                }
            });
            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

        function LoadDataYearType1() {
            var patent_id = 1;
            var param = "{'patent_id':" + JSON.stringify(patent_id) + "}";
            var dataurl = 'WebService/WebService.asmx/LoadGrowYearFile';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {

                    $("#divPatenTypeYear1").html(data.d);
                },
                error: function (xhr, status, error) {

                }
            });
            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

        function LoadDataYearType3() {
            var patent_id = 3;
            var param = "{'patent_id':" + JSON.stringify(patent_id) + "}";
            var dataurl = 'WebService/WebService.asmx/LoadGrowYearFile';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {

                    $("#divPatenTypeYear2").html(data.d);
                },
                error: function (xhr, status, error) {

                }
            });
            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

    </script>
</body>
</html>
