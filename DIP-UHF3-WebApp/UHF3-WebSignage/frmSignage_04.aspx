<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_04.aspx.vb" Inherits="frmSignage_04" %>

<!DOCTYPE html>

<html>
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
            .grid_head {
                font-family: tahoma;
                font-size: 30px;
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
                font-size: 22px;
            }
        </style>
    <%--  <link href="assets/js/RGraph/css/website.css" rel="stylesheet" />
    <link href="assets/js/RGraph/css/ModalDialog.css" rel="stylesheet" />
    <link href="assets/js/RGraph/css/animations.css" rel="stylesheet" />--%>

    <link href="assets/bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="assets/bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery-2.0.3.min.js"></script>
<%--  //  <script src="assets/js/Chart.js-master/Chart.js"></script>--%>
<%--    <script src="assets/js/RGraph/libraries/RGraph.common.core.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.tooltips.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.dynamic.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.common.key.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.drawing.rect.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.pie.js"></script>
    <script src="assets/js/RGraph/libraries/RGraph.bar.js"></script>--%>
 <script src="assets/js/Highcharts-4.1.5/js/highcharts.js"></script>
    	


</head>
<body>
 
   
    <form id="form1" runat="server">
                <div class="row">
      
                <div class="col-lg-12">
                    <table style="width: 100%; border: none;">
                         <tr>
                             <td style="width: 50%; border: none;  height: 680px;vertical-align: top;" align="center">
                                 <table style="width: 99%; border: none;  height: 670px">
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 50px" align="center"  >
                                            <img src="images/graph_header.png" width="100%" height="50px" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 610px" align="center" bgcolor="#e6e7e8" >
                                             <%-- <canvas id="cvsbar" width="600" height="260" !style="border:1px solid #ccc">[No canvas support]</canvas>--%>


                                            <div id="container" style="min-width: 600px; height: 610px; margin: 0 auto;border:1px solid #ccc"></div>
                                        </td>
                                       
                                    </tr>
                                   <%-- <tr>
                                                <td style="width: 100%; border: none;  height: 290px; vertical-align:top;" align="center" >
                                                    <table width="100%" border="1" cellspacing="0" cellpadding="5">
                                                          <tr>
                                                            <td width="47%" rowspan="2" align="center" bgcolor="#be1e2d" class="grid_head" >ประเภทแฟ้มที่ครบอายุ</td>
                                                            <td height="45px" colspan="2" align="center" bgcolor="#be1e2d" class="grid_head_2">จำนวนแฟ้มที่ต้องเก็บ</td>
                                                          </tr>
                                                          <tr>
                                                            <td width="27%" height="45px" align="center" bgcolor="#be1e2d" class="grid_head_2">ห้องเก็บแฟ้มชั้น 1</td>
                                                            <td width="26%" align="center" bgcolor="#be1e2d" class="grid_head_2">ทรัพย์ศรีไทย</td>
                                                          </tr>
                                                          <tr>
                                                            <td height="45px" bgcolor="#e6e7e8" class="table_content"><span id="patenttype1_name"></span></td>
                                                            <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype1_f1"></span></td>
                                                            <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype1_f2"></span></td>
                                                          </tr>
                                                          <tr>
                                                            <td height="45px" class="table_content"><span id="patenttype2_name"></span></td>
                                                            <td align="center" class="table_content"><span id="patenttype2_f1"></span></td>
                                                            <td align="center" class="table_content"><span id="patenttype2_f2"></span></td>
                                                          </tr>
                                                          <tr>
                                                            <td height="45px" bgcolor="#e6e7e8" class="table_content"><span id="patenttype3_name"></span></td>
                                                            <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype3_f1"></span></td>
                                                            <td align="center" bgcolor="#e6e7e8" class="table_content"><span id="patenttype3_f2"></span></td>
                                                          </tr>
                                                          <tr>
                                                            <td height="45px" align="center" bgcolor="#be1e2d" class="grid_head">รวม</td>
                                                            <td align="center" bgcolor="#be1e2d" class="grid_head"><span id="patenttypesumf1"></span></td>
                                                            <td align="center" bgcolor="#be1e2d" class="grid_head"><span id="patenttypesumf2"></span></td>
                                                          </tr>
                                                    </table>
                                                </td>
                                                </tr>--%>
                                </table>
            
                             </td>
                             <td style="width: 50%; border: none;  height: 680px;vertical-align: top;" align="center">
                                 <table style="width: 99%; border: none;  height: 670px">
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 50px" align="center" >
                                            <img src="images/pie_header_2.png" width="100%" height="50px" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 610px" bgcolor="#e6e7e8">
                                         <div id="container2" style="min-width: 600px; height: 610px; margin: 0 auto;border:1px solid #ccc"></div>
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
           ShowGraphBar();
           ShowGraphBarDepartment();
           //ShowTable();
        })

        function ShowGraphBar() {

            var dataurl = 'WebService/WebService.asmx/LoadDipBarChart';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                
                    var tempvalue =data.d;
                    var tempsplit = tempvalue.split('|');
                    var data1 = tempsplit[0].split(',');
                    var data2 = tempsplit[1].split(',');
                    var label1 = tempsplit[2].split(',');

                    var today;
                    var yesterday;

                    if (data1.length > 0) {//Check null value
                        var dataarr1 = [];
                        var dataarr2 = [];
                        var labels = [];
                        for (var i = 0; i < data1.length; ++i) {
                            dataarr1.push(parseInt(data1[i]));//add value to array
                            dataarr2.push(parseInt(data2[i]));
                            labels.push(label1[i]);

                            if (i == 0) {
                                today = label1[i];
                            }
                            if (i == 1) {
                                yesterday = label1[i];
                            }
                        }
                    }
                    //var today = new Date();
                    //var dd = today.getDate();
                    //var mm = today.getMonth() + 1; //January is 0!
                    //var yyyy = today.getFullYear();
                    //var ddy = dd - 1;

                    //if (dd < 10) {
                    //    dd = '0' + dd
                    //}

                    //if (mm < 10) {
                    //    mm = '0' + mm
                    //}

                    //if (ddy < 10) {
                    //    ddy = '0' + ddy
                    //}

                    //today = dd + '/' + mm + '/' + yyyy;
                    //yesterday = ddy + '/' + mm + '/' + yyyy;

                    $('#container').highcharts({
                        chart: {
                            type: 'column'
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
                            //type: 'category',
                            //categories: labels,
                            categories: ['ยืม', 'คืน'],
                            above: true
                        },
                        yAxis: {
                            min: 0,
                            title: {
                                text: 'จำนวนแฟ้ม'
                            }
                        },
                        tooltip: {
                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                '<td style="padding:0"><b>{point.y:.0f} แฟ้ม</b></td></tr>',
                            footerFormat: '</table>',
                            shared: true,
                            useHTML: true
                        },
                        plotOptions: {
                            column: {
                                pointPadding: 0.2,
                                borderWidth: 0
                            }
                        },
                        series: [{
                            name: yesterday,
                            color: '#FFCD00',
                            data: dataarr1,
                            dataLabels: {
                                enabled: true,
                                rotation: -90,
                                color: '#FFFFFF',
                                align: 'right',
                                format: '{point.y:.0f}', // one decimal
                                y: -30, // 10 pixels down from the top
                                style: {
                                    fontSize: '11px',
                                    fontFamily: 'Verdana, sans-serif'
                                }
                            }

                        }, {
                            name: today,
                            color: '#00B869',
                            data: dataarr2,
                            dataLabels: {
                                enabled: true,
                                rotation: -90,
                                color: '#FFFFFF',
                                align: 'right',
                                format: '{point.y:.0f}', // one decimal
                                y: -30, // 10 pixels down from the top
                                style: {
                                    fontSize: '11px',
                                    fontFamily: 'Verdana, sans-serif'
                                }
                            }

                        }]
                    });

                },
                error: function (xhr, status, error) {

                }
            });
        }

        function ShowGraphBarDepartment() {
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
                        var datapush = [];
                       // var colors = [];
                        for (var i = 0; i < data1.length; ++i) {
                            datapush = [label1[i], parseInt(data1[i])];
                            data.push(datapush);
                        }

                        if (data.length > 0) {//edit format value 

                            //for (var i = 0; i < data.length; ++i) {
                            //    labels[i] = labels[i] + '(' + data[i] + '%)';
                            //}                        
                            $('#container2').highcharts({
                                chart: {
                                    type: 'column'
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
                                    type: 'category',
                                    labels: {
                                        rotation: -45,
                                        style: {
                                            fontSize: '11px',
                                            fontWeight: "bold"
                                        }
                                    }
                                },
                                yAxis: {
                                    min: 0,
                                    title: {
                                        text: 'จำนวนแฟ้ม'
                                    }
                                },
                                legend: {
                                    enabled: false
                                },
                                tooltip: {
                                    pointFormat: ''
                                },
                                series: [{
                                    name: 'Population',
                                    data: data,
                                    dataLabels: {
                                        enabled: true,
                                        rotation: -90,
                                        color: '#FFFFFF',
                                        align: 'right',
                                        format: '{point.y:.0f}', // one decimal
                                        y: -30, // 10 pixels down from the top
                                        style: {
                                            fontSize: '11px',
                                            fontFamily: 'Verdana, sans-serif'
                                        }
                                    }
                                }]
                            });

                        }
                    }



                },
                error: function (xhr, status, error) {

                }
            });

        }

        function ShowTable() {

            var dataurl = 'WebService/WebService.asmx/LoadDipTableFileAge';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    var item = 1;
                    var qty1 = 0;
                    var qty2 = 0;
                    var jsonobject = JSON.parse(data.d);
                    $.each(jsonobject, function (key, val) {
                        $('#patenttype' + item + '_name').text(val.patent_type_name);
                        $('#patenttype' + item + '_f1').text(val.location_1_qty);
                        $('#patenttype' + item + '_f2').text(val.location_sup_qty);

                        //if(item == 1){
                        //    $("#patenttype1_name").text(val.patent_type_name);
                        //    $("#patenttype1_f1").text(val.location_1_qty);
                        //    $("#patenttype1_f2").text(val.location_sup_qty);
                        //}else if (item ==2){
                        //    $("#patenttype2_name").text(val.patent_type_name);
                        //    $("#patenttype2_f1").text(val.location_1_qty);
                        //    $("#patenttype1_f2").text(val.location_sup_qty);
                        //}else if (item ==3){
                        //    $("#patenttype1_name").text(val.patent_type_name);
                        //    $("#patenttype1_f1").text(val.location_1_qty);
                        //    $("#patenttype1_f2").text(val.location_sup_qty);
                        //}
                        qty1 = qty1 + val.location_1_qty;
                        qty2 = qty2 + val.location_sup_qty;
                        if (item == 3) {
                            $("#patenttypesumf1").text(qty1);
                            $("#patenttypesumf2").text(qty2);
                        }
                        item = item + 1;


                    })

                },
                error: function (xhr, status, error) {

                }
            });

          
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