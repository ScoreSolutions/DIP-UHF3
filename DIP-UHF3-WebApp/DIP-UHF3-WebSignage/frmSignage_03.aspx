<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_03.aspx.vb" Inherits="frmSignage_03" %>

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
                            <td style="width: 100%; border: none; border-width: 1px; height: 680px; vertical-align: top;" align="center">
                                <table style="width: 99%; border: none; border-width: 1px; height: 515px">
                                    <tr>
                                        <td style="width: 100%; border: none; border-width: 1px; height: 50px" align="center">
                                            <img src="images/glowup_header.png" width="100%" height="50px" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: none; border-width: 1px; height: 465px; vertical-align: top;" align="center" bgcolor="#e6e7e8">
                                            <%-- <canvas id="cvsline" width="620" height="300" !style="border:1px solid #ccc">[No canvas support]</canvas>--%>
                                            <div id="container" style="min-width: 620px; height: 465px; margin: 0 auto; border: 1px solid #ccc"></div>
                                        </td>

                                    </tr>
                                    <%--               <tr>
                                        <td style="width: 100%; border: none; border-width: 1px;  height: 23vh" align="center">
                                               <table style="width: 100%; border: none; border-width: 1px;  height: 23vh">
                                                <tr>
                                                <td style="width: 50%; border: none; border-width: 1px;  height: 23vh" align="center"></td>
                                                <td style="width: 50%; border: none; border-width: 1px;  height: 23vh" align="center"></td>
                                                </tr>
                                               </table>
                                        </td>
                                    </tr>--%>
                                </table>
                                <table style="width: 99%; border: none; border-width: 1px; height: 165px">
                                    <tr>
                                        <td style="width: 33%; border: none; border-width: 1px; height: 165px" align="left">
                                            <table width="99%" border="0" cellspacing="0" cellpadding="0" height="165px">
                                                <tr>
                                                    <td align="left">
                                                        <img src="images/pic_3_01.png" width="90px" height="135px" /></td>
                                                    <td align="right" bgcolor="#27a9e3" class="text_1" width="100%"><span id="lblborrow"></span></td>

                                                </tr>
                                                <tr>
                                                    <td height="30px" colspan="2" valign="top">
                                                        <img src="images/pic_3_03.png" width="100%" height="30px" />

                                                    </td>

                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 33%; border: none; border-width: 1px; height: 165px" align="center">
                                            <table width="99%" border="0" cellspacing="0" cellpadding="0" height="165px">
                                                <tr>
                                                    <td align="left">
                                                        <img src="images/pic_2_01.png" width="90px" height="135px" /></td>
                                                    <td align="right" bgcolor="#28b779" class="text_1" width="100%"><span id="lblreserve"></span></td>

                                                </tr>
                                                <tr>
                                                    <td height="30px" colspan="2" valign="top">
                                                        <img src="images/pic_2_03.png" width="100%" height="30px" />

                                                    </td>

                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 33%; border: none; border-width: 1px; height: 165px" align="right">
                                            <table width="99%" border="0" cellspacing="0" cellpadding="0" height="165px">
                                                <tr>
                                                    <td align="left">
                                                        <img src="images/pic_01.png" width="90px" height="135px" /></td>
                                                    <td align="right" bgcolor="#852b99" class="text_1" width="100%"><span id="lblreserveall"></span></td>

                                                </tr>
                                                <tr>
                                                    <td height="30px" colspan="2" valign="top">
                                                        <img src="images/pic_03.png" width="100%" height="30px" />

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
        </div>

    </form>

    <script>
        $(document).ready(function () {
            ShowGraphLine();
            ShowAmountBorrow();
            ShowAmountReserve();
            ShowAmountReserveAll();
        })



        function genGraphLine() {
            data = [0, 1, 1];
            labels = ['1', '2', '3'];
            var line = new RGraph.Line({ id: 'cvsline', data: data, options: { outofbounds: true } })

            //var line = new RGraph.Line({
            //    id: 'cvsline',
            //    data:data,
            //    options: {
            //        scale: {
            //            zerostart: true
            //        },
            //        labels: labels
            //    }
            //}).draw()

            line.set({
                numyticks: 6,
                ymax: 5000,
                //ylabels: {
                //    specific: [
                //               RGraph.numberFormat(line, 6000),
                //               RGraph.numberFormat(line, 5000),
                //               RGraph.numberFormat(line, 4000),
                //               RGraph.numberFormat(line, 3000),
                //               RGraph.numberFormat(line, 2000),
                //               RGraph.numberFormat(line, 1000),
                //               ''
                //    ]
                //},
                gutter: {
                    left: 65
                },
                labels: labels,
                numxticks: 7,
                background: {
                    grid: {
                        autofit: {
                            numhlines: 6,
                            numvlines: 7
                        }
                    }
                }
            }).draw()
        }

        var pie = new RGraph.Pie({ //bind data 
            id: 'cvspie1',
            data: data,
            options: {
                labels: {
                    self: labels
                    //,
                    //sticks: {
                    //    self: true,
                    //    length: 1
                    //}

                },
                tooltips: labels,
                colors: colors,
                strokestyle: 'white',
                linewidth: 0,
                shadow: {
                    offsetx: 2,
                    offsety: 2,
                    blur: 3
                },
                exploded: 0,
                title: ''
            }
        }).draw()

        function ShowGraphLine() {
            var dataurl = 'WebService/WebService.asmx/LoadDipGrowLineChart';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    //alert(data.d);
                    var temp = data.d.split('|');
                    var label1 = temp[0].split(',');
                    var data1 = temp[1].split(',');
                    var data2 = temp[2].split(',');
                    var data3 = temp[3].split(',');
                    var data4 = temp[4].split(',');
                    var data5 = temp[5].split(',');

                    if (temp.length > 0) {//Check null value
                        var dataarr1 = [];
                        var dataarr2 = [];
                        var dataarr3 = [];
                        var dataarr4 = [];
                        var dataarr5 = [];
                        var labels = [];
                        for (var i = 0; i < data1.length; ++i) {
                            // data1[i] = RGraph.log(data1[i], 10);
                            dataarr1.push(parseInt(data1[i]));//add value to array
                            dataarr2.push(parseInt(data2[i]));
                            dataarr3.push(parseInt(data3[i]));
                            dataarr4.push(parseInt(data4[i]));
                            dataarr5.push(parseInt(data5[i]));
                            labels.push(label1[i]);
                        }

                        var vDateNow = new Date();
                        var yy = vDateNow.getFullYear();

                        $('#container').highcharts({
                            chart: {
                                type: 'line'
                                ,
                                backgroundColor: '#e6e7e8'
                            },
                            title: {
                                text: ''
                            },
                            subtitle: {
                                text: ''
                            },
                            xAxis: {
                                categories: labels
                            },
                            yAxis: {
                                title: {
                                    text: 'จำนวนแฟ้ม'
                                }
                            },
                            plotOptions: {
                                line: {
                                    dataLabels: {
                                        enabled: true
                                    },
                                    enableMouseTracking: false
                                }
                            },
                            series: [{
                                name: yy, //'ปีปัจจุบัน',
                                //color: '#3399FF',
                                data: dataarr1

                            }, {
                                name: yy - 1,
                                data: dataarr2

                            }, {
                                name: yy - 2,
                                data: dataarr3

                            }, {
                                name: yy - 3,
                                data: dataarr4

                            }, {
                                name: yy - 4,
                                data: dataarr5

                            }]

                        });

                    }



                },
                error: function (xhr, status, error) {

                }
            });



            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

        function ShowAmountBorrow() {
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountBorrow';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    // alert(data.d);
                    $("#lblborrow").text(data.d);
                },
                error: function (xhr, status, error) {

                }
            });



            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

        function ShowAmountReserve() {
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountReserve';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    $("#lblreserve").text(data.d);
                },
                error: function (xhr, status, error) {

                }
            });
            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

        function ShowAmountReserveAll() {
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountReserveAll';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    $("#lblreserveall").text(data.d);
                },
                error: function (xhr, status, error) {

                }
            });
            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

    </script>






</body>
</html>
