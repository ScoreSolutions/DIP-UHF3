<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_01.aspx.vb" Inherits="frmSignage_01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .classname {
            background: #e6e7e8;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
        }

        .headline {
            font-family: Tahoma;
            font-size: 22px;
            color: #31999a;
        }
        .headline2 {
            font-family: Tahoma;
            font-size: 16px;
            color: #31999a;
        }
        .headlineoffline {
            font-family: Tahoma;
            font-size: 24px;
            color: red;
        }

        .Hdevice_name {
            font-family: Tahoma;
            font-size: 18px;
            font-weight: bold;
            color: #515151;
            color: #414042;
        }

        .Hdevice_name2 {
            font-family: Tahoma;
            font-size: 18px;
            font-weight: bold;
            color: #515151;
            color: #414042;
        }

        .device_name {
            font-family: Tahoma;
            font-size: 20px;
            color: #515151;
            color: #414042;
        }

        .server_per {
            font-family: Tahoma;
            font-size: 35px;
            font-weight: bold color: #515151;
            color: #414042;
        }

        .server_per2 {
            font-family: Tahoma;
            font-size: 18px;
            font-weight: bold color: #515151;
            color: #414042;
        }

        .tv_headline {
            font-family: Tahoma;
            font-size: 16px;
            color: #31999a;
        }

        .tv_per {
            font-family: Tahoma;
            font-size: 18px;
            color: #515151;
            color: #414042;
        }
    </style>


   
    <script src="assets/bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery-2.0.3.min.js"></script>
    <script src="assets/js/jQuery.Marquee/jquery.marquee.js"></script>
    <script src="assets/js/Highcharts-4.1.5/js/highcharts.js"></script>
    <script src="assets/js/Highcharts-4.1.5/js/highcharts-more.js"></script>
    <script src="assets/js/Highcharts-4.1.5/js/modules/solid-gauge.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
             <div class="center-block">
                <div class="col-lg-12">
<table style="width: 100%; border: none; border-width: 1px; height: 680px;vertical-align:top">
                <tr>
                    <td>
                        <table style="width: 100%; border: none; border-width: 1px; height: 310px">
                           <tr>
<td style="width: 100%; border: none; border-width: 1px; height: 310px" align="center" >
                            <table width="99%" height="310px" border="0" cellspacing="0" cellpadding="5" class="classname">
                                <tr>
                                    <td width="10%" height="150px" align="center" valign="middle">
                                        <img id="imgdipdbserver" src="images/server_online.png" width="70" height="120px" />

                                    </td>
                                 <td   width="22%"   align="left" valign="middle">
                                        <table width="100%"  border="0" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td height="21" colspan="2" ><span id="lbldipdbserverconnect" class="headlineonline">• Online</span></td>
                                            </tr>
                                            <tr>
                                                <td height="21" colspan="2" class="device_name"><span id="lbldipdbservername" class="Hdevice_name" >DIPDbServer</span></td>
                                            </tr>
                                            <tr>
                                               <td width="100%" ><span class="headline">IP :</span><span id="lbldipdbserverip" class="device_name">10.1.0.10</span></td>
                                            </tr>
                                            <tr>
                                              <td width="100%" ><span class="headline">Location :</span><span id="lbldipdbserverlocation" class="device_name">Server Room</span></td>
                                            </tr>
                                            <tr>
                                               <td width="100%" ><span class="headline">OS :</span><span id="lbldipdbserveros" class="device_name">Win 2008</span></td>

                                            </tr>
                                        </table>
                                    </td>
                                    <td width="2%"  height="300px" align="center" valign="middle">
                                        <img src="images/server_line.jpg" width="2" height="300px" /></td>
                                     <td width="15%" height="310px" valign="top">
                                        <table width="100%"  border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="121" align="center" valign="top"><span class="headline">Availability</span></td>
                                            </tr>
                                            <tr>
                                                <td height="100" align="center" valign="middle" class="server_per">
                                                  <%--  <span id="lbldipdbserveravailability" style="display:none">100%</span>--%>
                                                    <div id="container_sv1_avb" style="width:200px; height: 270px; margin: 0 auto"></div>
                                                </td>

                                            </tr>
                                               <tr style="display:none">
                                                <td width="121" align="center" valign="top">
                                                      <span class="headline2" id="lbldipdbserveravailability"></span></td>
                                            </tr>
                                        </table>
                                    </td>
                                      <td width="2%"  height="300px" align="center" valign="middle">
                                        <img src="images/server_line.jpg" width="2" height="300px" /></td>
                                    <td width="15%" height="310px" " valign="top">
                                        <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="121"  align="center" valign="top"><span class="headline">CPU</span></td>
                                            </tr>
                                            <tr>
                                                <td height="100" align="center" class="server_per">
                                                   <%-- <span id="lbldipdbservercpu" style="display:none" >100%</span>--%>
                                            <%--        <div id="container_sv1_cpu" style="width:110px; height: 130px; margin: 0 auto"></div>--%>
                                                    <div id="container_sv1_cpu" style="width: 200px; height: 270px; float: left"></div>

                                                </td>
                                            </tr>
                                                                <tr style="display:none">
                                                <td width="121" align="center" valign="top">
                                                      <span class="headline2" id="lbldipdbservercpu"></span> </td>
                                            </tr>
                                        </table>
                                    </td>
                                        <td width="2%" height="300px" align="center" valign="middle" >
                                        <img src="images/server_line.jpg" width="2" height="300px" /></td>
                                    <td width="15%" height="310px"  valign="top">
                                        <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="121"  align="center" valign="top"><span class="headline">RAM</span></td>
                                            </tr>
                                            <tr>
                                                <td height="100" align="center" class="server_per">
                                                  <%--  <span id="lbldipdbserverram" style="display:none">100%</span>--%>
                                                     <div id="container_sv1_ram" style="width:200px; height: 270px; margin: 0 auto"></div>
                                                </td>
                                            </tr>
                                                      <tr style="display:none">
                                                <td width="121" align="center" valign="top">
                                                      <span class="headline2" id="lbldipdbserverram"></span></td>
                                            </tr>
                                        </table>
                                    </td>

                                      <td width="2%" height="300px" align="center" valign="middle">
                                        <img src="images/server_line.jpg" width="2" height="300px" /></td>
                                      <td width="15%"  height="310px" " valign="top">
                                        <table width="100%"  border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="121" align="center" valign="top" ><span class="headline">Disk</span></td>
                                            </tr>
                                            <tr>
                                                <td height="100" align="center" class="server_per">
                                                <%--    <span id="lbldipdbserverdisk" style="display:none">100%</span>--%>
                                                        <div id="container_sv1_disk" style="width:200px; height: 270px; margin: 0 auto"></div>
                                                </td>
                                            </tr>
                                                              <tr style="display:none">
                                                <td width="121" align="center" valign="top">
                                                      <span class="headline2" id="lbldipdbserverdisk"></span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                           </tr>
                        <tr>
 <td style="width: 100%; border: none; border-width: 1px; height: 310px" align="center" >
                             <table width="99%" height="310px" border="0" cellspacing="0" cellpadding="5" class="classname">
                                <tr>
                                    <td width="10%" height="150px" align="center" valign="middle">
                                        <img id="imgdipwebserver" src="images/server_online.png" width="70" height="120px" />

                                    </td>
                                 <td width="22%"   align="left" valign="middle">
                                        <table width="100%"  border="0" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td height="21" colspan="2" class="headline"><span id="lbldipwebserverconnect">• Online</span></td>
                                            </tr>
                                            <tr>
                                                <td height="21" colspan="2" class="device_name"><span id="lbldipwebservername" class="Hdevice_name" >DIPWebserver</span></td>
                                            </tr>
                                            <tr>

                                             <td width="100%" ><span class="headline">IP :</span><span id="lbldipwebserverip" class="device_name">10.1.0.10</span></td>

                                            </tr>
                                            <tr>

                                             <td width="100%" ><span class="headline">Location :</span><span id="lbldipwebserverlocation" class="device_name">Server Room</span></td>

                                            </tr>
                                            <tr>
                                             
                                            <td width="100%" ><span class="headline">OS :</span><span id="lbldipwebserveros" class="device_name">Win 2008</span></td>

                                            </tr>
                                        </table>
                                    </td>
                                <td width="2%"  height="300px" align="center" valign="middle">
                                        <img src="images/server_line.jpg" width="2" height="300px" /></td>
                                     <td width="15%" height="310px" valign="top">
                                        <table width="100%"  border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="121" align="center" valign="top"><span class="headline">Availability</span></td>
                                            </tr>
                                            <tr>
                                                <td height="100" align="center" valign="middle" class="server_per">
                                                  <%--  <span id="lbldipwebserveravailability">100%</span>--%>
                                                      <div id="container_sv2_avb" style="width:200px; height: 270px; margin: 0 auto"></div>
                                                </td>
                                            </tr>
                                                                                         <tr style="display:none">
                                                <td width="121"  align="center" valign="top"><span  class="headline2" id="lbldipwebserveravailability"></span></td>
                                            </tr>
                                        </table>
                                    </td>
                                      <td width="2%"  height="300px" align="center" valign="middle">
                                        <img src="images/server_line.jpg" width="2" height="300px" /></td>
                                    <td width="15%" height="310px" " valign="top">
                                        <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="121"  align="center" valign="top"><span class="headline">CPU</span></td>
                                            </tr>
                                            <tr>
                                                <td height="100" align="center" class="server_per">
                                                   <%-- <span id="lbldipwebservercpu">100%</span>--%>
                                                    <div id="container_sv2_cpu" style="width:200px; height: 270px; margin: 0 auto"></div>
                                                </td>
                                            </tr>
                                             <tr style="display:none">
                                                <td width="121"  align="center" valign="top"><span class="headline2" id="lbldipwebservercpu"></span></td>
                                            </tr>
                                        </table>
                                    </td>
                                        <td width="2%" height="300px" align="center" valign="middle" >
                                        <img src="images/server_line.jpg" width="2" height="300px" /></td>
                                    <td width="15%" height="310px"  valign="top">
                                        <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="121"  align="center" valign="top"><span class="headline">RAM</span></td>
                                            </tr>
                                            <tr>
                                                <td height="100" align="center" class="server_per">
                                                 <%--   <span id="lbldipwebserverram">100%</span>--%>
                                                <div id="container_sv2_ram" style="width:200px; height: 270px; margin: 0 auto"></div>
                                                </td>
                                                  
                                            </tr>
                                                 <tr style="display:none">
                                                <td width="121"  align="center" valign="top"><span class="headline2" id="lbldipwebserverram"></span></td>
                                            </tr>
                                        </table>
                                    </td>

                                  <td width="2%" height="300px" align="center" valign="middle">
                                        <img src="images/server_line.jpg" width="2" height="300px" /></td>
                                      <td width="15%"  height="310px" " valign="top">
                                        <table width="100%"  border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="121" align="center" valign="top" ><span class="headline">Disk</span></td>
                                            </tr>
                                            <tr>
                                                <td height="100" align="center" class="server_per">
                                                    <%--<span id="lbldipwebserverdisk">100%</span>--%>
                                                   <div id="container_sv2_disk" style="width:200px; height: 270px; margin: 0 auto"></div>

                                                </td>
                                            </tr>
                                                                                         <tr style="display:none">
                                                <td width="121"  align="center" valign="top"><span class="headline2"  id="lbldipwebserverdisk"></span></td>
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
        </div>
                

    

      
    </form>
     <script type="text/javascript">
         $(document).ready(function () {
            LoadDataAllServer();
            //LoadDataSpeedwayAll();
            //LoadDataTVALL();
        });

        function LoadDataAllServer() {
            var dataurl = 'WebService/WebService.asmx/LoadDipAllServer';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    var jsonobj = JSON.parse(data.d);
                    //alert(jsonobj.length);
                    //1 Device
                    if (jsonobj.length == 1) {
                        //server 1
                        //alert(jsonobj[0].online_status);
                        if (jsonobj[0].online_status == 'Y') {
                            $("#imgdipdbserver").attr('src', 'images/server_online.png')
                            $("#lbldipdbserverconnect").removeClass('headlineoffline');
                            $("#lbldipdbserverconnect").addClass('headline')
                            $("#lbldipdbserverconnect").text('. Online');
                        } else {
                            $("#imgdipdbserver").attr('src', 'images/server_offline.png')
                            $("#lbldipdbserverconnect").removeClass('headline');
                            $("#lbldipdbserverconnect").addClass('headlineoffline')
                            $("#lbldipdbserverconnect").text('. Offline');
                        }

                        $("#lbldipdbservername").text(jsonobj[0].ServerName);
                        $("#lbldipdbserverip").text(jsonobj[0].ServerIP);
                        $("#lbldipdbserverlocation").text(jsonobj[0].LocationServer);
                        $("#lbldipdbserveros").text(jsonobj[0].OS);
                        $("#lbldipdbserveravailability").text(jsonobj[0].today_alailable + '%');              
                        $("#lbldipdbservercpu").text(jsonobj[0].CPUPercent + '%');
                        $("#lbldipdbserverram").text(jsonobj[0].RAMPercent + '%');
                        $("#lbldipdbserverdisk").text(jsonobj[0].DiskPercent + '%');

                        //server2
                        $("#imgdipwebserver").attr('src', 'images/server_offline.png')
                        $("#lbldipwebserverconnect").removeClass('headline');
                        $("#lbldipwebserverconnect").addClass('headlineoffline')
                        $("#lbldipwebserverconnect").text('. Offline');
                        $("#lbldipwebservername").text('');
                        $("#lbldipwebserverip").text('');
                        $("#lbldipwebserverlocation").text('');
                        $("#lbldipwebserveros").text('');
                        $("#lbldipwebserveravailability").text("0%");
                        $("#lbldipwebservercpu").text("0%");
                        $("#lbldipwebserverram").text("0%");
                        $("#lbldipwebserverdisk").text("0%");
              

                    }
                    //2 device
                    else if (jsonobj.length == 2) {
                        //server 1
                        if (jsonobj[0].online_status == 'Y') {
                            $("#imgdipdbserver").attr('src', 'images/server_online.png')
                            $("#lbldipdbserverconnect").removeClass('headlineoffline');
                            $("#lbldipdbserverconnect").addClass('headline')
                            $("#lbldipdbserverconnect").text('. Online');
                        } else {
                            $("#imgdipdbserver").attr('src', 'images/server_offline.png')
                            $("#lbldipdbserverconnect").removeClass('headline');
                            $("#lbldipdbserverconnect").addClass('headlineoffline')
                            $("#lbldipdbserverconnect").text('. Offline');
                        }

                        $("#lbldipdbservername").text(jsonobj[0].ServerName);
                        $("#lbldipdbserverip").text(jsonobj[0].ServerIP);
                        $("#lbldipdbserverlocation").text(jsonobj[0].LocationServer);
                        $("#lbldipdbserveros").text(jsonobj[0].OS);
                        $("#lbldipdbserveravailability").text(jsonobj[0].today_alailable + '%');
                        $("#lbldipdbservercpu").text(jsonobj[0].CPUPercent + '%');
                        $("#lbldipdbserverram").text(jsonobj[0].RAMPercent + '%');
                        $("#lbldipdbserverdisk").text(jsonobj[0].DiskPercent + '%');


                        gensv1_avb(jsonobj[0].today_alailable, jsonobj[0].AlarmMinorValueAvb, jsonobj[0].AlarmMajorValueAvb, jsonobj[0].AlarmCriticalValueAvb);
                        gensv1_cpu(jsonobj[0].CPUPercent, jsonobj[0].AlarmMinorValueCPU, jsonobj[0].AlarmMajorValueCPU, jsonobj[0].AlarmCriticalValueCPU);
                        gensv1_ram(jsonobj[0].RAMPercent, jsonobj[0].AlarmMinorValueRAM, jsonobj[0].AlarmMajorValueRAM, jsonobj[0].AlarmCriticalValueRAM);
                        gensv1_disk(jsonobj[0].DiskPercent, jsonobj[0].AlarmMinorValueDisk, jsonobj[0].AlarmMajorValueDisk, jsonobj[0].AlarmCriticalValueDisk);


                        //server 2
                        if (jsonobj[1].online_status == 'Y') {
                            $("#imgdipwebserver").attr('src', 'images/server_online.png')
                            $("#lbldipwebserverconnect").removeClass('headlineoffline');
                            $("#lbldipwebserverconnect").addClass('headline')
                            $("#lbldipwebserverconnect").text('. Online');
                        } else {
                            $("#imgdipwebserver").attr('src', 'images/server_offline.png')
                            $("#lbldipwebserverconnect").removeClass('headline');
                            $("#lbldipwebserverconnect").addClass('headlineoffline')
                            $("#lbldipwebserverconnect").text('. Offline');
                        }

                        $("#lbldipwebservername").text(jsonobj[1].ServerName);
                        $("#lbldipwebserverip").text(jsonobj[1].ServerIP);
                        $("#lbldipwebserverlocation").text(jsonobj[1].LocationServer);
                        $("#lbldipwebserveros").text(jsonobj[1].OS);
                        $("#lbldipwebserveravailability").text(jsonobj[1].today_alailable + '%');
                        $("#lbldipwebservercpu").text(jsonobj[1].CPUPercent + '%');
                        $("#lbldipwebserverram").text(jsonobj[1].RAMPercent + '%');
                        $("#lbldipwebserverdisk").text(jsonobj[1].DiskPercent + '%');

                        gensv2_avb(jsonobj[1].today_alailable, jsonobj[1].AlarmMinorValueAvb, jsonobj[1].AlarmMajorValueAvb, jsonobj[1].AlarmCriticalValueAvb);
                        gensv2_cpu(jsonobj[1].CPUPercent, jsonobj[1].AlarmMinorValueCPU, jsonobj[1].AlarmMajorValueCPU, jsonobj[1].AlarmCriticalValueCPU);
                        gensv2_ram(jsonobj[1].RAMPercent, jsonobj[1].AlarmMinorValueRAM, jsonobj[1].AlarmMajorValueRAM, jsonobj[1].AlarmCriticalValueRAM);
                        gensv2_disk(jsonobj[1].DiskPercent, jsonobj[1].AlarmMinorValueDisk, jsonobj[1].AlarmMajorValueDisk, jsonobj[1].AlarmCriticalValueDisk);




                    } else {
                        $("#lbldipdbserverconnect").text(". Offline");
                        $("#imgdipdbserver").attr('src', 'images/server_offline.png')
                        $("#lbldipdbserverconnect").removeClass('headline');
                        $("#lbldipdbserverconnect").addClass('headlineoffline')
                        $("#lbldipdbserveravailability").text("0%");
                        $("#lbldipdbservercpu").text("0%");
                        $("#lbldipdbserverram").text("0%");
                        $("#lbldipdbserverdisk").text("0%");

                        $("#lbldipwebserverconnect").text(". Offline");
                        $("#imgdipwebserver").attr('src', 'images/server_offline.png');
                        $("#lbldipwebserverconnect").removeClass('headline');
                        $("#lbldipwebserverconnect").addClass('headlineoffline');
                        $("#lbldipwebserveravailability").text("0%");
                        $("#lbldipwebservercpu").text("0%");
                        $("#lbldipwebserverram").text("0%");
                        $("#lbldipwebserverdisk").text("0%");
                    }
                },
                error: function (xhr, status, error) {
                    // alert(xhr.responseText);
                    $("#lbldipdbserverconnect").text(". Offline");
                    $("#imgdipdbserver").attr('src', 'images/server_offline.png')
                    $("#lbldipdbserverconnect").removeClass('headline');
                    $("#lbldipdbserverconnect").addClass('headlineoffline')
                    $("#lbldipdbserveravailability").text("0%");
                    $("#lbldipdbservercpu").text("0%");
                    $("#lbldipdbserverram").text("0%");
                    $("#lbldipdbserverdisk").text("0%");

                    $("#lbldipwebserverconnect").text(". Offline");
                    $("#imgdipwebserver").attr('src', 'images/server_offline.png');
                    $("#lbldipwebserverconnect").removeClass('headline');
                    $("#lbldipwebserverconnect").addClass('headlineoffline');
                    $("#lbldipwebserveravailability").text("0%");
                    $("#lbldipwebservercpu").text("0%");
                    $("#lbldipwebserverram").text("0%");
                    $("#lbldipwebserverdisk").text("0%");

                }


            });
        }

     

        function gensv1_avb(data, Minor, Major, Critical) {

            $('#container_sv1_avb').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: ''
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                        // default background
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                // the value axis
                yAxis: {
                    min: 0,
                    max: 100,

                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: ''
                    },
                    plotBands: [{
                        from: 0,
                        to: Minor,
                        color: '#DF5353' // red 
                    }, {
                        from: Minor,
                        to: Major ,
                        color: '#DDDF0D' // yellow
                    }, {
                        from: Major,
                        to: 100,
                        color: '#55BF3B' // green 
                    }]
                },

                series: [{
                    name: 'Speed',
                    data: [data],
                    tooltip: {
                        valueSuffix: ''
                    }
                }]

            });
        }
        function gensv1_cpu(data, Minor, Major, Critical) {
            $('#container_sv1_cpu').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: ''
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                        // default background
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                // the value axis
                yAxis: {
                    min: 0,
                    max: 100,

                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: ''
                    },
                    plotBands: [{
                        from: 0,
                        to: Minor,
                        color: '#55BF3B' // green
                    }, {
                        from: Minor,
                        to: Major,
                        color: '#DDDF0D' // yellow
                    }, {
                        from: Major,
                        to: 100,
                        color: '#DF5353' // red
                    }]
                },

                series: [{
                    name: 'Speed',
                    data: [data],
                    tooltip: {
                        valueSuffix: ''
                    }
                }]

            });



        }
        function gensv1_ram(data, Minor, Major, Critical) {

            $('#container_sv1_ram').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: ''
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                        // default background
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                // the value axis
                yAxis: {
                    min: 0,
                    max: 100,

                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: ''
                    },
                    plotBands: [{
                        from: 0,
                        to: Minor,
                        color: '#55BF3B' // green
                    }, {
                        from: Minor,
                        to: Major,
                        color: '#DDDF0D' // yellow
                    }, {
                        from: Major,
                        to: 100,
                        color: '#DF5353' // red
                    }]
                },

                series: [{
                    name: 'Speed',
                    data: [data],
                    tooltip: {
                        valueSuffix: ''
                    }
                }]

            });
        }
        function gensv1_disk(data, Minor, Major, Critical) {
            $('#container_sv1_disk').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: ''
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                        // default background
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                // the value axis
                yAxis: {
                    min: 0,
                    max: 100,

                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: ''
                    },
                    plotBands: [{
                        from: 0,
                        to: Minor,
                        color: '#55BF3B' // green
                    }, {
                        from: Minor,
                        to: Major,
                        color: '#DDDF0D' // yellow
                    }, {
                        from: Major,
                        to: 100,
                        color: '#DF5353' // red
                    }]
                },

                series: [{
                    name: 'Speed',
                    data: [data],
                    tooltip: {
                        valueSuffix: ''
                    }
                }]

            });
        }

        function gensv2_avb(data, Minor, Major, Critical) {
            $('#container_sv2_avb').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: ''
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                        // default background
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                // the value axis
                yAxis: {
                    min: 0,
                    max: 100,

                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: ''
                    },
                    plotBands: [{
                        from: 0,
                        to: Minor,
                        color: '#DF5353' // red 
                    }, {
                        from: Minor,
                        to: Major,
                        color: '#DDDF0D' // yellow
                    }, {
                        from: Major,
                        to: 100,
                        color: '#55BF3B' // green 
                    }]
                },

                series: [{
                    name: 'Speed',
                    data: [data],
                    tooltip: {
                        valueSuffix: ''
                    }
                }]

            });
        }
        function gensv2_cpu(data, Minor, Major, Critical) {
            $('#container_sv2_cpu').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: ''
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                        // default background
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                // the value axis
                yAxis: {
                    min: 0,
                    max: 100,

                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: ''
                    },
                    plotBands: [{
                        from: 0,
                        to: Minor,
                        color: '#55BF3B' // green
                    }, {
                        from: Minor,
                        to: Major,
                        color: '#DDDF0D' // yellow
                    }, {
                        from: Major,
                        to: 100,
                        color: '#DF5353' // red
                    }]
                },

                series: [{
                    name: 'Speed',
                    data: [data],
                    tooltip: {
                        valueSuffix: ''
                    }
                }]

            });



        }
        function gensv2_ram(data, Minor, Major, Critical) {
            $('#container_sv2_ram').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: ''
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                        // default background
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                // the value axis
                yAxis: {
                    min: 0,
                    max: 100,

                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: ''
                    },
                    plotBands: [{
                        from: 0,
                        to: Minor,
                        color: '#55BF3B' // green
                    }, {
                        from: Minor,
                        to: Major,
                        color: '#DDDF0D' // yellow
                    }, {
                        from: Major,
                        to: 100,
                        color: '#DF5353' // red
                    }]
                },

                series: [{
                    name: 'Speed',
                    data: [data],
                    tooltip: {
                        valueSuffix: ''
                    }
                }]

            });
        }
        function gensv2_disk(data, Minor, Major, Critical) {
            $('#container_sv2_disk').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: ''
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                        // default background
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                // the value axis
                yAxis: {
                    min: 0,
                    max: 100,

                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: ''
                    },
                    plotBands: [{
                        from: 0,
                        to: Minor,
                        color: '#55BF3B' // green
                    }, {
                        from: Minor,
                        to: Major,
                        color: '#DDDF0D' // yellow
                    }, {
                        from: Major,
                        to: 100,
                        color: '#DF5353' // red
                    }]
                },

                series: [{
                    name: 'Speed',
                    data: [data],
                    tooltip: {
                        valueSuffix: ''
                    }
                }]

            });
        }

      

    </script>

</body>
</html>
