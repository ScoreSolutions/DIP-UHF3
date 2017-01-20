<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_06_2.aspx.vb" Inherits="frmSignage_06_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                             <%--<td style="width: 50%; border: none;  height: 680px;vertical-align: top;" align="center">
                                 <table style="width: 100%; border: none;  height: 680px">
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 50px" align="center"  >
                                            <img src="images/floor10_line_head1.png" width="100%" height="50px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 610px" align="center" bgcolor="#e6e7e8" >
                                            <div id="container" style="min-width: 600px; height: 610px; margin: 0 auto;border:1px solid #ccc"></div>
                                        </td>
                                    </tr>
                                </table>
                             </td>--%>
                             <td style="width: 100%; border: none;  height: 680px;vertical-align: top;" align="center">
                                 <table style="width: 100%; border: none;  height: 680px">
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 50px" align="center" >
                                            <img src="images/floor10_line_head2.png" width="100%" height="50px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 620px" bgcolor="#e6e7e8">
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
         })

         function ShowGraphBar() {
             var dataurl = 'WebService/WebService.asmx/LoadCompareReserveBorrowYieldAmountFloor10';
             $.ajax({
                 "type": "POST",
                 "dataType": 'json',
                 "contentType": "application/json; charset=utf-8",
                 "url": dataurl,
                 "success": function (data) {
                     var temp = data.d.split('|');
                     var data1 = temp[0].split(',');
                     var data2 = temp[1].split(',');
                     var label1 = temp[3].split(',');
                     if (temp.length > 0) {//Check null value
                         var dataarr1 = [];
                         var dataarr2 = [];
                         var labels = [];
                         for (var i = 0; i < data1.length; ++i) {
                             // data1[i] = RGraph.log(data1[i], 10);
                             dataarr1.push(parseInt(data1[i]));//add value to array
                             dataarr2.push(parseInt(data2[i]));//add value to array
                             labels.push(label1[i]);
                         }

                         if (data1.length > 0) {//edit format value 

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
                                     categories: labels,
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
                                     enabled: true
                                 },
                                 tooltip: {
                                     headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                     pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                         '<td style="padding:0"><b>{point.y:.0f} แฟ้ม</b></td></tr>',
                                     footerFormat: '</table>',
                                     shared: true,
                                     useHTML: true
                                 },
                                 series: [{
                                     name: 'แฟ้มที่ทำรายการจอง',
                                     color: '#3399FF',
                                     data: dataarr1,
                                     dataLabels: {
                                         enabled: true,
                                         rotation: -90,
                                         color: '#FFFFFF',
                                         align: 'right',
                                         format: '{point.y:.0f}', // one decimal
                                         y: -35, // 10 pixels down from the top
                                         style: {
                                             fontSize: '11px',
                                             fontFamily: 'Verdana, sans-serif'
                                         }
                                     }
                                 },{
                                     name: 'แฟ้มที่ส่งแล้ว',
                                     color: '#660000',
                                     data: dataarr2,
                                     dataLabels: {
                                         enabled: true,
                                         rotation: -90,
                                         color: '#FFFFFF',
                                         align: 'right',
                                         format: '{point.y:.0f}', // one decimal
                                         y: -35, // 10 pixels down from the top
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

         function ShowGraphLine() {
             var dataurl = 'WebService/WebService.asmx/LoadCompareReserveBorrowYieldAmountFloor10';
             $.ajax({
                 "type": "POST",
                 "dataType": 'json',
                 "contentType": "application/json; charset=utf-8",
                 "url": dataurl,
                 "success": function (data) {
                     //alert(data.d);
                     var temp = data.d.split('|');
                     var data1 = temp[2].split(',');
                     var label1 = temp[3].split(',');
                     if (temp.length > 0) {//Check null value
                         var data = [];
                         var labels = [];
                         for (var i = 0; i < data1.length; ++i) {
                             // data1[i] = RGraph.log(data1[i], 10);
                             data.push(parseInt(data1[i]));//add value to array
                             labels.push(label1[i]);
                         }

                         $('#container').highcharts({
                             chart: {
                                 //style: {
                                 //    fontFamily: 'serif',
                                 //    fontSize: '16px'
                                 //},
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
                                     text: 'ประสิทธิผล(%)'
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
                                 name: 'Yield',
                                 data: data
                             }]
                         });

                     }



                 },
                 error: function (xhr, status, error) {

                 }
             });



             //  RGraph.ISOLD ? line.draw() : line.trace()
         }

         function ShowGraphLine2() {
             var dataurl = 'WebService/WebService.asmx/LoadCompareReserveBorrowYieldAmountFloor10';
             $.ajax({
                 "type": "POST",
                 "dataType": 'json',
                 "contentType": "application/json; charset=utf-8",
                 "url": dataurl,
                 "success": function (data) {
                     //alert(data.d);
                     var temp = data.d.split('|');
                     var data1 = temp[0].split(',');
                     var data2 = temp[1].split(',');
                     var label1 = temp[3].split(',');
                     if (temp.length > 0) {//Check null value
                         var dataarr1 = [];
                         var dataarr2 = [];
                         var labels = [];
                         for (var i = 0; i < data1.length; ++i) {
                             // data1[i] = RGraph.log(data1[i], 10);
                             dataarr1.push(parseInt(data1[i]));//add value to array
                             dataarr2.push(parseInt(data2[i]));//add value to array
                             labels.push(label1[i]);
                         }

                         $('#container2').highcharts({
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
                                 name: 'แฟ้มที่ทำรายการจอง',
                                 color: '#3399FF',
                                 data: dataarr1

                             }, {
                                 name: 'แฟ้มที่ส่งแล้ว',
                                 color: '#660000',
                                 data: dataarr2

                             }]
                            
                         });

                     }



                 },
                 error: function (xhr, status, error) {

                 }
             });



             //  RGraph.ISOLD ? line.draw() : line.trace()
         }
     </script>

</body>
</html>
