<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_04_Temp.aspx.vb" Inherits="frmSignage_04_Temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <style type="text/css">
        .headline {
            font-family: Tahoma;
            font-size: 18px;
            color: #31999a;
        }

        .classname {
            background: #e6e7e8;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
        }
    </style>--%>
    <style type="text/css">
.grid_head {	font-family: tahoma;
	font-size: 30px;
	color: #FFF;
}
.grid_head_2 {	font-family: tahoma;
	font-size: 22px;
	color: #FFF;
}
.table_content {	font-family: tahoma;
	color: #000;
	font-size: 24px;
}
</style>
    <%--  <link href="assets/js/RGraph/css/website.css" rel="stylesheet" />
    <link href="assets/js/RGraph/css/ModalDialog.css" rel="stylesheet" />
    <link href="assets/js/RGraph/css/animations.css" rel="stylesheet" />--%>

    <link href="assets/bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="assets/bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery-2.0.3.min.js"></script>
    <script src="assets/js/jQuery.Marquee/jquery.marquee.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.core.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.tooltips.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.dynamic.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.key.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.drawing.rect.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.pie.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.bar.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.line.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="center-block">
                <div class="col-lg-12">
                    <table style="width: 100%; border: none;">
                         <tr>
                             <td style="width: 50%; border: none;  height: 680px;vertical-align: top;" align="center">
                                 <table style="width: 99%; border: none;  height: 680px">
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 50px" align="center" >
                                            <img src="images/graph_header.png" width="100%" height="50px" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 320px" align="center" >
                                              <canvas id="cvsbar" width="600px" height="260px" !style="border:1px solid #ccc">[No canvas support]</canvas>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                                <td style="width: 100%; border: none;  height: 290px" align="center">
                                                    <table width="100%" border="1" cellspacing="0" cellpadding="5">
                                                          <tr>
                                                            <td width="47%" rowspan="2" align="center" bgcolor="#be1e2d" class="grid_head" >ประเภทแฟ้มที่ครบอายุ</td>
                                                            <td height="45" colspan="2" align="center" bgcolor="#be1e2d" class="grid_head_2">จำนวน</td>
                                                          </tr>
                                                          <tr>
                                                            <td width="27%" height="45" align="center" bgcolor="#be1e2d" class="grid_head_2">ห้องเก็บแฟ้มชั้น 1</td>
                                                            <td width="26%" align="center" bgcolor="#be1e2d" class="grid_head_2">ทรัพย์ศรีไทย</td>
                                                          </tr>
                                                          <tr>
                                                            <td height="45" bgcolor="#e6e7e8" class="table_content">สิทธิบัตรการประดิษฐ์</td>
                                                            <td align="center" bgcolor="#e6e7e8" class="table_content">1,500</td>
                                                            <td align="center" bgcolor="#e6e7e8" class="table_content">2,300</td>
                                                          </tr>
                                                          <tr>
                                                            <td height="45" class="table_content">สิทธิบัตรการออกแบบผลิตภัณฑ์</td>
                                                            <td align="center" class="table_content">1,000</td>
                                                            <td align="center" class="table_content">2,000</td>
                                                          </tr>
                                                          <tr>
                                                            <td height="45" bgcolor="#e6e7e8" class="table_content">อนุสิทธิบัตร</td>
                                                            <td align="center" bgcolor="#e6e7e8" class="table_content">500</td>
                                                            <td align="center" bgcolor="#e6e7e8" class="table_content">1,700</td>
                                                          </tr>
                                                          <tr>
                                                            <td height="45" align="center" bgcolor="#be1e2d" class="grid_head">รวม</td>
                                                            <td align="center" bgcolor="#be1e2d" class="grid_head">3,000</td>
                                                            <td align="center" bgcolor="#be1e2d" class="grid_head">6,000</td>
                                                          </tr>
                                                    </table>
                                                </td>
                                                </tr>
                                </table>
                     <%--             <table style="width: 99%; border: none;  height: 42vh">
                                                 <tr>
                                                <td style="width: 100%; border: groove;  height: 42vh" align="center"></td>
                                                </tr>
                                  </table>--%>
                             </td>
                             <td style="width: 50%; border: none;  height: 680px;vertical-align: top;" align="center" >
                                 <table style="width: 99%; border: none;  height: 670px">
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 50px" align="center" >
                                            <img src="images/pie_header_2.png" width="100%" height="50px" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 610px" >
<%--                                           <canvas id="cvspie1" width="660" height="400" !style="border:1px solid #ccc">[No canvas support]</canvas>--%>
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
            ShowGraphBar();
            //ShowTableFileAge();
            //ShowGraphPie1();
           // ShowAmountBorrowKPI();
            //ShowAmountReturnKPI();
            //LoadDipAmountLocation(1);
            //LoadDipAmountLocation(2);
            //LoadDipAmountLocation(3);
            //LoadDipAmountLocation(4);           
        })

        function ShowGraphPie1() {
            var dataurl = 'WebService/WebService.asmx/LoadDipDepartmentPieChart';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    var temp = data.d.split('|');
                    var label1 = temp[0].split(',');
                    var data1 = temp[1].split(',');
                    //var color1 = temp[2].split(',');
                    if (temp.length > 0) {//Check null value
                        var data = [];
                        var labels = [];
                       // var colors = [];
                        for (var i = 0; i < data1.length; ++i) {
                            data.push(parseInt(data1[i]));//add value to array
                            labels.push(label1[i]);
                           // colors.push(color1[i]);
                        }

                        if (data.length > 0) {//edit format value 

                            //for (var i = 0; i < data.length; ++i) {
                            //    labels[i] = labels[i] + '(' + data[i] + '%)';
                            //}
                            var pie = new RGraph.Pie({ //bind data 
                                id: 'cvspie1',
                                data: data,
                                options: {
                                    labels: {
                                        self: labels,
                                        sticks: {
                                            self: true,
                                            length: 5
                                        }

                                    },
                                    tooltips: labels,
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
                        }
                    }



                },
                error: function (xhr, status, error) {

                }
            });

        }

        function ShowGraphBar() {

            var dataurl = 'WebService/WebService.asmx/LoadDipBarChart';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    var jsonobj = JSON.parse(data.d);
                    var dataall = [[300, 150], [100, 20]];
                    var line = new RGraph.Bar({
                        id: 'cvsbar',
                        data: dataall,
                        options: {
                            key: {
                                self: ['ยืม', 'คืน'],
                                interactive: true
                            }
                        }

                    })

                    line.set({

                        gutter: {
                            left: 65
                        },
                        labels: {
                            self: ['เมื่อวาน', 'วันนี้'],
                            above: true
                        },

                        colors: ['#FFCD00', '#00B869'],
                    }).draw();
                },
                error: function (xhr, status, error) {

                }
            });

            //var datafull = [];
            // var data = [999999, 5, 6, 4, 6, 8012, 12, 7];
            //var dataall = [[500, 400], [300, 200]];
            //var data = [80000, 40000];
            //for (var i = 0; i < data.length; ++i) {
            //    data[i] = RGraph.log(data[i], 10); // This function is in RGraph.common.core.js

            //}
            //var data2 = [40000, 80000];
            ////for (var i = 0; i < data2.length; ++i) {
            ////    data2[i] = RGraph.log(data2[i], 10); // This function is in RGraph.common.core.js

            ////}
            //var data3 = [1000000, 5000];
            ////for (var i = 0; i < data3.length; ++i) {
            ////    data3[i] = RGraph.log(data3[i], 10); // This function is in RGraph.common.core.js
            ////}
            //var datafull = [data, data2, data3];

            // var line = new RGraph.Bar({ id: 'cvs4', data: dataall })

            //var line = new RGraph.Bar({
            //    id: 'cvsbar',
            //    data: dataall,
            //    options: {
            //        key: {
            //            self: ['ยืม', 'คืน'],
            //            interactive: true
            //        }
            //    }

            //})

            //line.set({

            //    gutter: {
            //        left: 65
            //    },
            //    labels: {
            //        self: ['เมื่อวาน', 'วันนี้'],
            //        above: true
            //    },

            //    colors: ['#FFCD00', '#00B869'],
            //}).draw()

            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

        function ShowAmountBorrowKPI() {
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountBorrowKPI';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    alert(data.d);

                },
                error: function (xhr, status, error) {

                }
            });



            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

        function ShowAmountReturnKPI() {
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountReturnKPI';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    alert(data.d);
                },
                error: function (xhr, status, error) {

                }
            });
            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

        function LoadDipAmountLocation(id) {
            var dataurl = 'WebService/WebService.asmx/LoadDipAmountLocation';
            var param = "{'id':" + JSON.stringify(id) + "}";
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data" : param,
                "success": function (data) {
                    alert(data.d);

                },
                error: function (xhr, status, error) {

                }
            });

            //  RGraph.ISOLD ? line.draw() : line.trace()
        }

        function ShowTableFileAge() {
            var dataurl = 'WebService/WebService.asmx/LoadDipTableFileAge';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    var jsonobj = JSON.parse(data.d);
                    var index = 1;
                    $.each(jsonobj, function (key, val) {
                        alert(val.patenttypename);
                        index = index + 1;
                    })

                },
                error: function (xhr, status, error) {

                }
            });
        }
    </script>






</body>
</html>