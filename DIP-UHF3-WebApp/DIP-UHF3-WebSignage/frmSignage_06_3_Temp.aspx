<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_06_3_Temp.aspx.vb" Inherits="frmSignage_06_3_Temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
            .grid_head {
                font-family: tahoma;
                font-size: 25px;
                color: #FFF;
            }

            .grid_head_2 {
                font-family: tahoma;
                font-size: 22px;
                color: #FFF;
            }

            .table_content {
                font-family: tahoma;
                color: #000;
                font-size: 20px;
            }
        </style>
    <link href="assets/bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="assets/bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery-2.0.3.min.js"></script>
    <script src="assets/js/Highcharts-4.1.5/js/highcharts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <table style="width: 100%; border: none;">
                <tr>
                    <td style="width: 100%; border: none; height: 680px; vertical-align: top;" align="center">
                        <table style="width: 100%; border: none; height: 280px">
                            <tr>
                                <td style="width: 100%; border: none; height: 50px" align="center">
                                    <img src="images/floor10_pie_head.png" width="100%" height="50px" />
                                </td>

                            </tr>
                            <tr>
                                <td style="width: 100%; border: none; height: 280px" align="center" bgcolor="#e6e7e8">
                                   

                                     <table style="width: 100%; border: none;">
                                         <tr>
                                             <td style="width: 50%;">
                                                 <img src="images/floor10_1.png" width="40%" height="40px" />
                                             </td>
                                             <td style="width: 50%;">
                                                 <img src="images/floor10_2.png" width="40%" height="40px" />
                                             </td>
                                         </tr>
                                          <tr>
                                             <td >
                                                  <div id="containerpie1" style="min-width: 600px; height: 250px; margin: 0 auto; border: 1px solid #ccc"></div>
                                             </td>
                                             <td >
                                                  <div id="containerpie2" style="min-width: 600px; height: 250px; margin: 0 auto; border: 1px solid #ccc"></div>
                                             </td>
                                         </tr>
                                        <%-- <tr>
                                             <td>
                                                  <img src="images/floor10_top5.png" width="100%" height="30px" />
                                             </td>
                                             <td></td>
                                         </tr>--%>
                                     </table>


                                </td>
                            </tr>

                        </table>
                        <table style="width: 100%; border: none; height: 200px">
                            <tr>
                                <td style="width: 100%; border: none; height: 50px" align="left">
                                    <img src="images/floor10_top5.png" width="60%" height="50px" />
                                </td>

                            </tr>
                            <tr>
                                <td style="width: 100%; border: none; height: 150px" align="center" >
                                    <table style="width: 100%; border: none;">
                                        <tr><td></br></td></tr>
                                        <tr>
                                            <td style="width: 33%;  padding-left:50px; ">
                                                <table width="350px" border="0" cellspacing="0" cellpadding="5">
                                                    <tr>
                                                        <td width="100%"  align="center" bgcolor="#660000" class="grid_head" colspan="2">อนุสิทธิบัตร</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px" bgcolor="#9c4c4d" class="table_content"><span id="patenttype3_seq_1"></span></td>
                                                        <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype3_appno_1"></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px" bgcolor="#9c4c4d" class="table_content"><span id="patenttype3_seq_2"></span></td>
                                                        <td align="center" class="table_content"><span id="patenttype3_appno_2"></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px" bgcolor="#9c4c4d" class="table_content"><span id="patenttype3_seq_3"></span></td>
                                                        <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype3_appno_3"></span></td>
                                                    </tr>
                                                   <tr>
                                                        <td align="center" width="15%" height="45px" bgcolor="#9c4c4d" class="table_content"><span id="patenttype3_seq_4"></span></td>
                                                        <td align="center" class="table_content"><span id="patenttype3_appno_4"></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px" bgcolor="#9c4c4d" class="table_content"><span id="patenttype3_seq_5"></span></td>
                                                        <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype3_appno_5"></span></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 33%; padding-left:50px;">
                                                <table width="350px" border="0" cellspacing="0" cellpadding="5">
                                                    <tr>
                                                        <%--<td width="20%"  bgcolor="#e6e7e8"></td>--%>
                                                        <td width="100%"  align="center" bgcolor="#3399FF" class="grid_head" colspan="2">สิทธิบัตรการประดิษฐ์</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px" bgcolor="#7ec4ff" class="table_content"><span id="patenttype1_seq_1"></span></td>
                                                        <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype1_appno_1"></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px" bgcolor="#7ec4ff" class="table_content"><span id="patenttype1_seq_2"></span></td>
                                                        <td align="center" class="table_content"><span id="patenttype1_appno_2"></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px" bgcolor="#7ec4ff" class="table_content"><span id="patenttype1_seq_3"></span></td>
                                                        <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype1_appno_3"></span></td>
                                                    </tr>
                                                   <tr>
                                                        <td align="center"  width="15%" height="45px" bgcolor="#7ec4ff" class="table_content"><span id="patenttype1_seq_4"></span></td>
                                                        <td align="center" class="table_content"><span id="patenttype1_appno_4"></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px" bgcolor="#7ec4ff" class="table_content"><span id="patenttype1_seq_5"></span></td>
                                                        <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype1_appno_5"></span></td>
                                                    </tr>
                                                </table>
                                            </td>
                                             <td style="width: 33%; padding-left:50px;">
                                                <table width="350px" border="0" cellspacing="0" cellpadding="5">
                                                    <tr>
                                                        <%--<td width="20%"  bgcolor="#e6e7e8"></td>--%>
                                                        <td width="100%"  align="center" bgcolor="#9900FF" class="grid_head" colspan="2">คำขอ PCT</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px" bgcolor="#996699" class="table_content"><span id="patenttype2_seq_1"></span></td>
                                                        <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype2_appno_1"></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px"  bgcolor="#996699" class="table_content"><span id="patenttype2_seq_2"></span></td>
                                                        <td align="center" class="table_content"><span id="patenttype2_appno_2"></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px"  bgcolor="#996699" class="table_content"><span id="patenttype2_seq_3"></span></td>
                                                        <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype2_appno_3"></span></td>
                                                    </tr>
                                                   <tr>
                                                        <td align="center" width="15%" height="45px"  bgcolor="#9966999" class="table_content"><span id="patenttype2_seq_4"></span></td>
                                                        <td align="center" class="table_content"><span id="patenttype2_appno_4"></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" width="15%" height="45px"  bgcolor="#996699"  class="table_content"><span id="patenttype2_seq_5"></span></td>
                                                        <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype2_appno_5"></span></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                    </td>

                </tr>
            </table>
        </div>
    </div>
    </form>
    <script>
        $(document).ready(function () {
            ShowGraphPie1();
            ShowGraphPie2();
            ShowTable1()
            ShowTable2()
            ShowTable3()
        })

        function ShowGraphPie1() {

            var type = '6';
            var dataurl = 'WebService/WebService.asmx/LoadPatentypeAmountFloor10PieChart';
            var param = "{'type':" + JSON.stringify(type) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var temp = data.d.split('|');
                    var data1 = temp[0].split(',');
                    var label1 = temp[3].split(',');
                    var color1 = temp[2].split(',');
                    //var type1 = temp[3].split(',');
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
                                            format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                                        },
                                        //showInLegend: true
                                    }
                                },
                                series: [{
                                    type: 'pie',
                                    name: ['www', 'eeeee', 'tttttt'],
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

        function ShowGraphPie2() {
            var type = 'more6';
            var dataurl = 'WebService/WebService.asmx/LoadPatentypeAmountFloor10PieChart';
            var param = "{'type':" + JSON.stringify(type) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var temp = data.d.split('|');
                    var data1 = temp[0].split(',');
                    var label1 = temp[3].split(',');
                    var color1 = temp[2].split(',');
                    //var type1 = temp[3].split(',');
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
                                            format: '<b>{point.name}</b>: {point.percentage:.1f} %'
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

        function ShowTable1() {
            var patent_type_id = '1';
            var dataurl = 'WebService/WebService.asmx/LoadTablePatentypeAmountTopTimeFloor10';
            var param = "{'patent_type_id':" + JSON.stringify(patent_type_id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var item = 1;
                    var qty1 = 0;
                    var qty2 = 0;
                    var jsonobject = JSON.parse(data.d);
                    $.each(jsonobject, function (key, val) {
                        $('#patenttype' + patent_type_id + '_seq_' + item).text(item);
                        $('#patenttype' + patent_type_id + '_appno_' + item).text(val.app_no);
                        item = item + 1;
                    })
                },
                error: function (xhr, status, error) {

                }
            });
        }
        function ShowTable2() {
            var patent_type_id = '2';
            var dataurl = 'WebService/WebService.asmx/LoadTablePatentypeAmountTopTimeFloor10';
            var param = "{'patent_type_id':" + JSON.stringify(patent_type_id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var item = 1;
                    var qty1 = 0;
                    var qty2 = 0;
                    var jsonobject = JSON.parse(data.d);
                    $.each(jsonobject, function (key, val) {
                        $('#patenttype' + patent_type_id + '_seq_' + item).text(item);
                        $('#patenttype' + patent_type_id + '_appno_' + item).text(val.app_no);
                        item = item + 1;
                    })
                },
                error: function (xhr, status, error) {

                }
            });
        }
        function ShowTable3() {
            var patent_type_id = '3';
            var dataurl = 'WebService/WebService.asmx/LoadTablePatentypeAmountTopTimeFloor10';
            var param = "{'patent_type_id':" + JSON.stringify(patent_type_id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var item = 1;
                    var qty1 = 0;
                    var qty2 = 0;
                    var jsonobject = JSON.parse(data.d);
                    $.each(jsonobject, function (key, val) {
                        $('#patenttype' + patent_type_id + '_seq_' + item).text(item);
                        $('#patenttype' + patent_type_id + '_appno_' + item).text(val.app_no);
                        item = item + 1;
                    })
                },
                error: function (xhr, status, error) {

                }
            });
        }
    </script>
</body>
</html>