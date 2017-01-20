<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_03_3.aspx.vb" Inherits="frmSignage_03_3" %>

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
        <div class="row">
            <div class="center-block">
                <div class="col-lg-12">
                    <table style="width: 100%; border: none; border-width: 1px;">
                         <tr>
                          
                             <td style="width: 100%; border:none; border-width: 1px;  height: 680px;vertical-align: top;" align="center" >
                                  <table style="width: 99%; border: none; border-width: 1px;  height: 680px">
                                    <tr>
                                        <td style="width: 100%; border: none; border-width: 1px;  height: 50px" align="center" colspan="4">
                                            <img src="images/pie_header_full.png" width="100%" height="50px" />
                                        </td>

                                    </tr >
                                    <tr>
                                        <td style="width: 25%; border: none; border-width: 1px;  height: 290px;border-left:hidden" align="center" bgcolor="#e6e7e8"  >
                                         <table style="width: 99%; border: none; border-width: 1px;  height: 290px">
                                                <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                    <img src="images/floor1.png" width="40%" height="40px" />
                                                </td>
                                                </tr>
                                                 <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                    <%--<canvas id="cvspie1" width="300" height="170" !style="border:1px solid #ccc">[No canvas support]</canvas>--%>
                                                 <div id="containerpie1" style="min-width: 260px; height: 220px; margin: 0 auto"  ></div>
                                                </td>
                                                </tr>
                                        </table>
                                            
                                        </td>
                                        <td style="width: 25%; border: none; border-width: 1px;  height: 290px" align="center"  bgcolor="#e6e7e8"  >
                                         <table style="width: 99%; border: none; border-width: 1px;  height: 290px">
                                                <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="right">
                                                    <img src="images/floor1B.png" width="40%" height="40px" />
                                                </td>
                                                </tr>
                                                 <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                  <%--  <canvas id="cvspie2" width="300" height="170" !style="border:1px solid #ccc">[No canvas support]</canvas>--%>
                                                   <div id="containerpie2" style="min-width: 260px; height: 220px; margin: 0 auto;"   ></div>

                                                </td>
                                                </tr>
                                        </table>
                                        </td>
                                        <td style="width: 25%; border: none; border-width: 1px;  height: 290px" align="center"  bgcolor="#e6e7e8" >
                                         <table style="width: 99%; border: none; border-width: 1px;  height: 290px">
                                                <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                    <img src="images/floor10.png" width="40%" height="40px" />
                                                </td>
                                                </tr>
                                                 <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                    <%--<canvas id="cvspie3" width="300" height="170" !style="border:1px solid #ccc">[No canvas support]</canvas>--%>
                                                    <div id="containerpie3" style="min-width: 260px; height: 220px; margin: 0 auto;"   ></div>

                                                </td>
                                                </tr>
                                        </table>
                                        </td>
                                        <td style="width: 50%; border: none; border-width: 1px;  height: 290px" align="center"  bgcolor="#e6e7e8"  >
                                         <table style="width: 99%; border: none; border-width: 1px;  height: 290px">
                                                <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="right">
                                                    <img src="images/floor12.png" width="40%" height="40px" />
                                                </td>
                                                </tr>
                                                 <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                   <%-- <canvas id="cvspie4" width="300" height="170" !style="border:1px solid #ccc">[No canvas support]</canvas>--%>
                                                  <div id="containerpie4" style="min-width: 260px; height: 220px; margin: 0 auto"  ></div>

                                                </td>
                                                </tr>
                                        </table>
                                        </td>
                                    </tr>
                                    <tr >
                     <td style="width: 25%; border: none; border-width: 1px;  height: 290px;border-left:hidden" align="center" bgcolor="#e6e7e8"  >
                                         <table style="width: 99%; border: none; border-width: 1px;  height: 290px">
                                                <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                    <img src="images/floor3.png" width="40%" height="40px" />
                                                </td>
                                                </tr>
                                                 <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                    <%--<canvas id="cvspie1" width="300" height="170" !style="border:1px solid #ccc">[No canvas support]</canvas>--%>
                                                 <div id="containerpie5" style="min-width: 260px; height: 220px; margin: 0 auto"  ></div>
                                                </td>
                                                </tr>
                                        </table>
                                            
                                        </td>
                                        <td style="width: 25%; border: none; border-width: 1px;  height: 290px" align="center"  bgcolor="#e6e7e8"  >
                                         <table style="width: 99%; border: none; border-width: 1px;  height: 290px">
                                                <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="right">
                                                    <img src="images/floor6.png" width="40%" height="40px" />
                                                </td>
                                                </tr>
                                                 <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                  <%--  <canvas id="cvspie2" width="300" height="170" !style="border:1px solid #ccc">[No canvas support]</canvas>--%>
                                                   <div id="containerpie6" style="min-width: 260px; height: 220px; margin: 0 auto;"   ></div>

                                                </td>
                                                </tr>
                                        </table>
                                        </td>
                                        <td style="width: 25%; border: none; border-width: 1px;  height: 290px" align="center"  bgcolor="#e6e7e8" >
                                         <table style="width: 99%; border: none; border-width: 1px;  height: 290px">
                                                <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                    <img src="images/floor_none.png" width="40%" height="40px" />
                                                </td>
                                                </tr>
                                                 <tr>
                                                <td style="width: 100%; border: none; border-width: 1px;" align="left">
                                                    <%--<canvas id="cvspie3" width="300" height="170" !style="border:1px solid #ccc">[No canvas support]</canvas>--%>
                                                    <div id="containerpie7" style="min-width: 260px; height: 220px; margin: 0 auto;"   ></div>

                                                </td>
                                                </tr>
                                        </table>
                                        </td>
                                        <td style="width: 25%; border: none; border-width: 1px;  height: 290px" align="center"  bgcolor="#e6e7e8"  >
                         
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: none; border-width: 1px;  height: 50px" align="center" colspan="4" >
                                             <img src="images/pietext.png"  height="30px" />
                                        </td>

                                    </tr>
                                </table>
                             </td>
                         </tr>

                    </table>
                </div>

            </div>
        </div>

    </form>

    <script>
        $(document).ready(function () {
        
            ShowGraphPieFloor1();
            ShowGraphPieFloor10101();
            ShowGraphPieFloor10();
            ShowGraphPieFloor12();
            ShowGraphPieFloor3();
            ShowGraphPieFloor6();
            GetFileQtyAtDestroy();
            
        })


        function ShowGraphPieFloor1() {
            //var id = 1;
            var room_id = 1;
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountPieChartFloor1';
            var param = "{'room_id':" + JSON.stringify(room_id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var temp = data.d.split('|');
                    var data1 = temp[0].split(',');
                    var label1 = temp[1].split(',');
                    var color1 = temp[2].split(',');
                    var type1 = temp[3].split(',');
                    if (temp.length > 0) {//Check null value
                        var data = [];
                        var labels = [];
                        var colors = [];
                        var datapush = [];
                        var colorspush = [];
                        for (var i = 0; i < data1.length; ++i) {
                            datapush = [label1[i], parseInt(data1[i])]
                            data.push(datapush);
                            colors.push(color1[i]);
                        }
                        
                        if (data.length > 0) {//edit format value 
                            $('#containerpie1').highcharts({
                                chart: {
                                    plotBackgroundColor: null,
                                    plotBorderWidth: null,
                                    plotShadow: false
                                    ,
                                    backgroundColor: '#e6e7e8'
                                },
                                title: {
                                    text: ''
                                },
                                tooltip: {
                                    pointFormat: ''
                                },
                                plotOptions: {
                                    pie: {
                                        animation: false,
                                        enableMouseTracking: false,
                                        borderColor: 'transparent',
                                        colors: colors,
                                        borderWidth: 1,
                                        dataLabels: {
                                            enabled: true,
                                            format: '<b>{point.name}</b>'
                                            //format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                                        }
                                    }
                                },
                                series: [{
                                    type: 'pie',
                                    name: '',
                                    data: data
                                }]
                            });

                        }
                    }
                },
                error: function (xhr, status, error) {

                }
            });
        }

        function ShowGraphPieFloor10101() {
            //var id = 1;
            var room_id =2;
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountPieChartFloor1';
            var param = "{'room_id':" + JSON.stringify(room_id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var temp = data.d.split('|');
                    var data1 = temp[0].split(',');
                    var label1 = temp[1].split(',');
                    var color1 = temp[2].split(',');
                    var type1 = temp[3].split(',');
                    if (temp.length > 0) {//Check null value
                        var data = [];
                        var labels = [];
                        var colors = [];
                        var datapush = [];
                        var colorspush = [];
                        for (var i = 0; i < data1.length; ++i) {
                            datapush = [label1[i], parseInt(data1[i])]
                            data.push(datapush);
                            colors.push(color1[i]);
                        }

                        if (data.length > 0) {//edit format value 
                            $('#containerpie2').highcharts({
                                chart: {
                                    plotBackgroundColor: null,
                                    plotBorderWidth: null,
                                    plotShadow: false
                                    ,
                                    backgroundColor: '#e6e7e8'
                                },
                                title: {
                                    text: ''
                                },
                                tooltip: {
                                    pointFormat: ''
                                },
                                plotOptions: {
                                    pie: {
                                        animation: false,
                                        enableMouseTracking: false,
                                        borderColor: 'transparent',
                                        colors: colors,
                                        borderWidth: 1,
                                        dataLabels: {
                                            enabled: true,
                                            format: '<b>{point.name}</b>'
                                            //format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                                        }
                                    }
                                },
                                series: [{
                                    type: 'pie',
                                    name: '',
                                    data: data
                                }]
                            });
                        }
                    }
                },
                error: function (xhr, status, error) {

                }
            });
        }

        function ShowGraphPieFloor10() {
            //จำนวนแฟ้มชั้น 10
            var room_id = 8;
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountPieChartFloor1';
            var param = "{'room_id':" + JSON.stringify(room_id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var temp = data.d.split('|');
                    var data1 = temp[0].split(',');
                    var label1 = temp[1].split(',');
                    var color1 = temp[2].split(',');
                    var type1 = temp[3].split(',');
                    if (temp.length > 0) {//Check null value
                        var data = [];
                        var labels = [];
                        var colors = [];
                        var datapush = [];
                        var colorspush = [];
                        for (var i = 0; i < data1.length; ++i) {
                            datapush = [label1[i], parseInt(data1[i])]
                            data.push(datapush);
                            colors.push(color1[i]);
                        }
                        if (data.length > 0) {//edit format value 
                            $('#containerpie3').highcharts({
                                chart: {
                                    plotBackgroundColor: null,
                                    plotBorderWidth: null,
                                    plotShadow: false
                                    ,
                                    backgroundColor: '#e6e7e8'
                                },
                                title: {
                                    text: ''
                                },
                                tooltip: {
                                    pointFormat: ''
                                },
                                plotOptions: {
                                    pie: {
                                        animation: false,
                                        enableMouseTracking: false,
                                        borderColor: 'transparent',
                                        colors: colors,
                                        borderWidth: 1,
                                        dataLabels: {
                                            enabled: true,
                                            format: '<b>{point.name}</b>'
                                            //format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                                        }
                                    }
                                },
                                series: [{
                                    type: 'pie',
                                    name: '',
                                    data: data

                                }]
                            });

                        }
                    }

                },
                error: function (xhr, status, error) {

                }
            });

        }

        function ShowGraphPieFloor12() {
            //จำนวนแฟ้มชั้น 12
            
            var room_id = 9;
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountPieChartFloor1';
            var param = "{'room_id':" + JSON.stringify(room_id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var temp = data.d.split('|');
                    var data1 = temp[0].split(',');
                    var label1 = temp[1].split(',');
                    var color1 = temp[2].split(',');
                    var type1 = temp[3].split(',');
                    if (temp.length > 0) {//Check null value
                        var data = [];
                        var labels = [];
                        var colors = [];
                        var datapush = [];
                        var colorspush = [];
                        for (var i = 0; i < data1.length; ++i) {
                            datapush = [label1[i], parseInt(data1[i])]
                            data.push(datapush);
                            colors.push(color1[i]);
                        }
                        //if (data.length == 1) {
                        //}
                        if (data.length > 0) {//edit format value 



                            $('#containerpie4').highcharts({
                                chart: {
                                    plotBackgroundColor: null,
                                    plotBorderWidth: null,
                                    plotShadow: false
                                    ,
                                    backgroundColor: '#e6e7e8'
                                },
                                title: {
                                    text: ''
                                },
                                tooltip: {
                                    pointFormat: ''
                                },
                                plotOptions: {
                                    pie: {
                                        animation: false,
                                        enableMouseTracking: false,
                                        borderColor: 'transparent',
                                        colors: colors,
                                        borderWidth: 1,
                                        dataLabels: {
                                            enabled: true,
                                            format: '<b>{point.name}</b>'
                                            //format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                                        }
                                    }
                                },
                                series: [{
                                    type: 'pie',
                                    name: '',
                                    data: data

                                }]
                            });

                        }
                    }

                },
                error: function (xhr, status, error) {

                }
            });

        }

        function ShowGraphPieFloor3() {
            //จำนวนแฟ้มชั้น 3
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountPieChartFloor3';
            //var param = "{'id':" + JSON.stringify(id)
            //     + ",'room_id':" + JSON.stringify(room_id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                //"data": param,
                "success": function (data) {
                    var temp = data.d.split('|');
                    var data1 = temp[0].split(',');
                    var label1 = temp[1].split(',');
                    var color1 = temp[2].split(',');
                    var type1 = temp[3].split(',');
                    if (temp.length > 0) {//Check null value
                        var data = [];
                        var labels = [];
                        var colors = [];
                        var datapush = [];
                        var colorspush = [];
                        for (var i = 0; i < data1.length; ++i) {
                            datapush = [label1[i], parseInt(data1[i])]
                            data.push(datapush);
                            colors.push(color1[i]);
                        }
                        //if (data.length == 1) {
                        //}
                        if (data.length > 0) {//edit format value 
                            


                            $('#containerpie5').highcharts({
                                chart: {
                                    plotBackgroundColor: null,
                                    plotBorderWidth: null,
                                    plotShadow: false
                                    ,
                                    backgroundColor: '#e6e7e8'
                                },
                                title: {
                                    text: ''
                                },
                                tooltip: {
                                    pointFormat: ''
                                },
                                plotOptions: {
                                    pie: {
                                        animation: false,
                                        enableMouseTracking: false,
                                        borderColor: 'transparent',
                                        colors: colors,
                                        borderWidth: 1,
                                        dataLabels: {
                                            enabled: true,
                                            format: '<b>{point.name}</b>'
                                            //format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                                        }
                                    }
                                },
                                series: [{
                                    type: 'pie',
                                    name: '',
                                    data: data

                                }]
                            });

                        }
                    }



                },
                error: function (xhr, status, error) {

                }
            });

        }

        function ShowGraphPieFloor6() {
            //var id = 4;
            var room_id = 6;
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountPieChartFloor1';
            var param = "{'room_id':" + JSON.stringify(room_id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var temp = data.d.split('|');
                    var data1 = temp[0].split(',');
                    var label1 = temp[1].split(',');
                    var color1 = temp[2].split(',');
                    var type1 = temp[3].split(',');
                    if (temp.length > 0) {//Check null value
                        var data = [];
                        var labels = [];
                        var colors = [];
                        var datapush = [];
                        var colorspush = [];
                        for (var i = 0; i < data1.length; ++i) {
                            datapush = [label1[i], parseInt(data1[i])]
                            data.push(datapush);
                            colors.push(color1[i]);
                        }

                        if (data.length > 0) {//edit format value 
                            $('#containerpie6').highcharts({
                                chart: {
                                    plotBackgroundColor: null,
                                    plotBorderWidth: null,
                                    plotShadow: false
                                    ,
                                    backgroundColor: '#e6e7e8'
                                },
                                title: {
                                    text: ''
                                },
                                tooltip: {
                                    pointFormat: ''
                                },
                                plotOptions: {
                                    pie: {
                                        animation: false,
                                        enableMouseTracking: false,
                                        borderColor: 'transparent',
                                        colors: colors,
                                        borderWidth: 1,
                                        dataLabels: {
                                            enabled: true,
                                            format: '<b>{point.name}</b>'
                                            //format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                                        }
                                    }
                                },
                                series: [{
                                    type: 'pie',
                                    name: '',
                                    data: data

                                }]
                            });

                        }
                    }


                },
                error: function (xhr, status, error) {

                }
            });

        }

        function GetFileQtyAtDestroy() {
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountPieChartDestroy';
            //var param = "{'id':" + JSON.stringify(id)
            //     + ",'room_id':" + JSON.stringify(room_id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                //"data": param,
                "success": function (data) {
                    var temp = data.d.split('|');
                    var data1 = temp[0].split(',');
                    var label1 = temp[1].split(',');
                    var color1 = temp[2].split(',');
                    var type1 = temp[3].split(',');
                    if (temp.length > 0) {//Check null value
                        var data = [];
                        var labels = [];
                        var colors = [];
                        var datapush = [];
                        var colorspush = [];
                        for (var i = 0; i < data1.length; ++i) {
                            datapush = [label1[i], parseInt(data1[i])]
                            data.push(datapush);
                            colors.push(color1[i]);
                        }

                        if (data.length > 0) {//edit format value 
                            $('#containerpie7').highcharts({
                                chart: {
                                    plotBackgroundColor: null,
                                    plotBorderWidth: null,
                                    plotShadow: false
                                    ,
                                    backgroundColor: '#e6e7e8'
                                },
                                title: {
                                    text: ''
                                },
                                tooltip: {
                                    pointFormat: ''
                                },
                                plotOptions: {
                                    pie: {
                                        animation: false,
                                        enableMouseTracking: false,
                                        borderColor: 'transparent',
                                        colors: colors,
                                        borderWidth: 1,
                                        dataLabels: {
                                            enabled: true,
                                            format: '<b>{point.name}</b>'
                                            //format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                                        }
                                    }
                                },
                                series: [{
                                    type: 'pie',
                                    name: '',
                                    data: data
                                }]
                            });
                        }
                    }
                },
                error: function (xhr, status, error) {

                }
            });
        }
    </script>






</body>
</html>
