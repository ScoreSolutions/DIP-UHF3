<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_06.aspx.vb" Inherits="frmSignage_06" %>

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
    <div class ="row">

        <div class="col-lg-12">
                    <table style="width: 100%; border: none;">
                         <tr>
                             <td style="width: 100%; border: none;  height: 680px;vertical-align: top;" align="center">
                                 <table style="width: 100%; border: none;  height: 680px">
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 50px" align="center"  >
                                           <img src="images/floor10_bar_head.png" width="100%" height="50px" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: none;  height: 620px" align="center" bgcolor="#e6e7e8" >
                                            <div id="container" style="min-width: 600px; height: 620px; margin: 0 auto;border:1px solid #ccc"></div>
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

             var dataurl = 'WebService/WebService.asmx/LoadComparePatentypeAmountFloor10BarChart';
             $.ajax({
                 "type": "POST",
                 "dataType": 'json',
                 "contentType": "application/json; charset=utf-8",
                 "url": dataurl,
                 "success": function (data) {
                     var tempvalue = data.d;
                     var tempsplit = tempvalue.split('|');
                     var data1 = tempsplit[0].split(',');
                     var data2 = tempsplit[1].split(',');
                     var data3 = tempsplit[2].split(',');
                     if (data1.length > 0) {//Check null value
                         var dataarr1 = [];
                         var dataarr2 = [];
                         var dataarr3 = [];
                         // var colors = [];
                         for (var i = 0; i < data1.length; ++i) {
                             dataarr1.push(parseInt(data2[i]));//add value to array
                             dataarr2.push(parseInt(data1[i]));
                             dataarr3.push(parseInt(data3[i]));
                             // colors.push(color1[i]);
                         }
                     }

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
                             categories: [
                                 'วันนี้',
                                 'เมื่อวาน'
                             ],
                             crosshair: true
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
                                 '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
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
                             name: 'สิทธิบัตรการประดิษฐ์',
                             color: '#3399FF',
                             data: dataarr1

                         }, {
                             name: 'คำขอ PCT',
                             color: '#9900FF',
                             data: dataarr2

                         }, {
                             name: 'อนุสิทธิบัตร',
                             color: '#660000',
                             data: dataarr3

                         }]
                     });

                 },
                 error: function (xhr, status, error) {

                 }
             });
         }

     </script>

</body>
</html>
