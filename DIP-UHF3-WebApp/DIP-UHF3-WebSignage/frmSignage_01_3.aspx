<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_01_3.aspx.vb" Inherits="frmSignage_01_3" %>

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
            font-size: 18px;
            color: #31999a;
        }
        .headline2 {
            font-family: Tahoma;
            font-size: 18px;
            color: #31999a;
        }
        .headlineoffline {
            font-family: Tahoma;
            font-size: 18px;
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
            font-size: 18px;
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
                        <td style="vertical-align:top">
                            <table style="width: 100%; border:none; border-width: 1px; height: 660px">
                           <tr>
                        <td style="width: 33%; border: none; border-width: 1px; height: 660px" align="center" valign="top"  >
                            <table width="99%" height="660px" border="0" cellspacing="0" cellpadding="1" class="classname">
                            <tr>
                                <td width="50%"  style="vertical-align:top" >
                                    <table width="100%" height="130px" border="0" cellspacing="0" cellpadding="1">
                                                          <tr>
                                    <td width="100%" align="left"><span id="diptv1connect" class="headlineoffline">• Offline</span><span id="diptv1floor" class="device_name"></span></td>
                                
                                  </tr>
                                 <tr>
                                    <td colspan="2" align="center" valign="top"><img id="imgdiptv1"  src="images/TV_offline.png" width="90%" height="90px" /></td>
                                    </tr>
                                    </table>
                                </td>
                                <td width="50%" height="130px" >
                                 <table width="100%"  border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td ><span id="diptv1name" class="Hdevice_name2">..</span></td>
                                        </tr>
                                      <tr>
                                        <td ><span class="headline">IP :</span><span id="diptv1ip" class="device_name"></span></td>
                                        
                                      </tr>
                                      <tr>
                                        <td><span class="headline">OS :</span><span id="diptv1os" class="device_name"></span></td>
                                       
                                      </tr>
                                    </table>
                                </td>
                            </tr>

                             <tr>
                           
                                <td width="50%" height="500px" align="center" valign="middle">
                                    <table width="100%" height="500px" border="0" cellpadding="1" cellspacing="0">
                         
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv1_avb" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>
                                  </tr>
                              
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv1_cpu" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>

                                  </tr>
                                </table>

                                </td>
                                <td width="50%" height="500px" align="center" valign="middle">
                                    <table width="100%" height="500px" border="0" cellspacing="0" cellpadding="1">
                                            
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv1_ram" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>
                                  </tr>
                              
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv1_disk" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>

                                  </tr>
                                </table></td>
                              </tr>

                            </table>
                        </td>
                             <td style="width: 33%; border: none; border-width: 1px; height: 660px" align="center" valign="top"  >
                            <table width="99%" height="660px" border="0" cellspacing="0" cellpadding="1" class="classname">
                            <tr>
                                <td width="50%"  style="vertical-align:top" >
                                    <table width="100%" height="130px" border="0" cellspacing="0" cellpadding="1">
                                                          <tr>
                                    <td width="100%" align="left"><span id="diptv2connect" class="headlineoffline">• Offline</span><span id="diptv2floor" class="device_name"></span></td>
                                
                                  </tr>
                                 <tr>
                                    <td colspan="2" align="center" valign="top"><img id="imgdiptv2"  src="images/TV_offline.png" width="90%" height="90px" /></td>
                                    </tr>
                                    </table>
                                </td>
                                <td width="50%" height="130px" >
                                 <table width="100%"  border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td ><span id="diptv2name" class="Hdevice_name2">..</span></td>
                                        </tr>
                                      <tr>
                                        <td ><span class="headline">IP :</span><span id="diptv2ip" class="device_name"></span></td>
                                        
                                      </tr>
                                      <tr>
                                        <td><span class="headline">OS :</span><span id="diptv2os" class="device_name"></span></td>
                                       
                                      </tr>
                                    </table>
                                </td>
                            </tr>

                             <tr>
                           
                                <td width="50%" height="500px" align="center" valign="middle">
                                    <table width="100%" height="500px" border="0" cellpadding="1" cellspacing="0">
                         
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv2_avb" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>
                                  </tr>
                              
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv2_cpu" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>

                                  </tr>
                                </table>

                                </td>
                                <td width="50%" height="500px" align="center" valign="middle">
                                    <table width="100%" height="500px" border="0" cellspacing="0" cellpadding="1">
                                            
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv2_ram" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>
                                  </tr>
                              
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv2_disk" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>

                                  </tr>
                                </table></td>
                              </tr>

                            </table>
                        </td>
                            <td style="width: 33%; border: none; border-width: 1px; height: 660px" align="center" valign="top"  >
                            <table width="99%" height="660px" border="0" cellspacing="0" cellpadding="1" class="classname">
                            <tr>
                                <td width="50%"  style="vertical-align:top" >
                                    <table width="100%" height="130px" border="0" cellspacing="0" cellpadding="1">
                                                          <tr>
                                    <td width="100%" align="left"><span id="diptv3connect" class="headlineoffline">• Offline</span><span id="diptv3floor" class="device_name"></span></td>
                                
                                  </tr>
                                 <tr>
                                    <td colspan="2" align="center" valign="top"><img id="imgdiptv3"  src="images/TV_offline.png" width="90%" height="90px" /></td>
                                    </tr>
                                    </table>
                                </td>
                                <td width="50%" height="130px" >
                                 <table width="100%"  border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td ><span id="diptv3name" class="Hdevice_name2">..</span></td>
                                        </tr>
                                      <tr>
                                        <td ><span class="headline">IP :</span><span id="diptv3ip" class="device_name"></span></td>
                                        
                                      </tr>
                                      <tr>
                                        <td><span class="headline">OS :</span><span id="diptv3os" class="device_name"></span></td>
                                       
                                      </tr>
                                    </table>
                                </td>
                            </tr>

                             <tr>
                           
                                <td width="50%" height="500px" align="center" valign="middle">
                                    <table width="100%" height="500px" border="0" cellpadding="1" cellspacing="0">
                         
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv3_avb" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>
                                  </tr>
                              
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv3_cpu" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>

                                  </tr>
                                </table>

                                </td>
                                <td width="50%" height="500px" align="center" valign="middle">
                                    <table width="100%" height="500px" border="0" cellspacing="0" cellpadding="1">
                                            
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv3_ram" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>
                                  </tr>
                              
                                  <tr>
                                    <td align="center" class="tv_per">
                                    
                                         <div id="container_sv3_disk" style="width:100%; height: 250px; margin: 0 auto"></div>
                                    </td>

                                  </tr>
                                </table></td>
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
             LoadDataTVALL();
        });
   
         function gentv_avb(controlid, data, Minor, Major, Critical) {
            $('#container_sv' + controlid + '_avb').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: 'Availability',
                    style: {
                        color: '#31999a'
                     }
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
         function gentv_cpu(controlid, data, Minor, Major, Critical) {
            $('#container_sv' + controlid + '_cpu').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: 'CPU',
                    style: {
                        color: '#31999a'
                    }
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
         function gentv_ram(controlid, data, Minor, Major, Critical) {
            $('#container_sv' + controlid + '_ram').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: 'RAM',
                    style: {
                        color: '#31999a'
                    }
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
         function gentv_disk(controlid, data, Minor, Major, Critical) {
            $('#container_sv' + controlid + '_disk').highcharts({

                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    backgroundColor: '#e6e7e8'
                },

                title: {
                    text: 'Disk',
                    style: {
                        color: '#31999a'
                    }
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

        function LoadDataTVALL() {
            var dataurl = 'WebService/WebService.asmx/LoadDipTV';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {

                    var jsonobj = JSON.parse(data.d);
                    var index = 1;
                    $.each(jsonobj, function (key, val) {
                        if (val.online_status == 'Y') {
                            $("#imgdiptv" + index).attr('src', 'images/TV_online.png')
                            $("#diptv" + index + "connect").removeClass('headlineoffline');
                            $("#diptv" + index + "connect").addClass('headline')
                            $("#diptv" + index + "connect").text('. Online');
                        } else {
                            $("#imgdiptv" + index).attr('src', 'images/TV_offline.png')
                            $("#diptv" + index + "connect").removeClass('headline');
                            $("#diptv" + index + "connect").addClass('headlineoffline')
                            $("#diptv" + index + "connect").text('. Offline');
                        }
                        var strservername;
                        if (val.ServerName.length > 18) {
                            strservername = val.ServerName.substring(0, 18) + '...';
                        } else {
                            strservername = val.ServerName;
                        }

                        $("#diptv" + index + "floor").text('(' + val.floor_name + ')');
                        $("#diptv" + index + "name").text(strservername);
                        $("#diptv" + index + "ip").text(val.ServerIP);
                        $("#diptv" + index + "os").text(val.OS);
                        //$("#diptv" + index + "availability").text(val.today_alailable + '%');
                        //$("#diptv" + index + "cpu").text(val.CPUPercent + '%');
                        //$("#diptv" + index + "ram").text(val.RAMPercent + '%');
                        //$("#diptv" + index + "disk").text(val.DiskPercent + '%');
                        gentv_avb(index, val.today_alailable, val.AlarmMinorValueAvb, val.AlarmMajorValueAvb, val.AlarmCriticalValueAvb);
                        gentv_cpu(index, val.CPUPercent, val.AlarmMinorValueCPU, val.AlarmMajorValueCPU, val.AlarmCriticalValueCPU);
                        gentv_ram(index, val.RAMPercent, val.AlarmMinorValueRAM, val.AlarmMajorValueRAM, val.AlarmCriticalValueRAM);
                        gentv_disk(index, val.DiskPercent, val.AlarmMinorValueDisk, val.AlarmMajorValueDisk, val.AlarmCriticalValueDisk);


                        index = index + 1;
                    })

                    //var jsonobj = JSON.parse(data.d);
                    //if (jsonobj.length > 0) {
                    //    if (jsonobj[0].imgdiptv == 1) {
                    //        $("#imgdiptv1").attr('src', 'images/TV_online.jpg')
                    //        $("#diptv1connect").removeClass('headlineoffline');
                    //        $("#diptv1connect").addClass('headline')
                    //    } else {
                    //        $("#imgdiptv1").attr('src', 'images/TV_offline.jpg')
                    //        $("#diptv1connect").removeClass('headline');
                    //        $("#diptv1connect").addClass('headlineoffline')
                    //    }
                    //    $("#diptv1connect").text(jsonobj[0].diptvconnect);
                    //    $("#diptv1floor").text(jsonobj[0].diptvfloor);
                    //    $("#diptv1name").text(jsonobj[0].diptvname);
                    //    $("#diptv1ip").text(jsonobj[0].diptvip);
                    //    $("#diptv1os").text(jsonobj[0].diptvos);
                    //    $("#diptv1availability").text(jsonobj[0].diptvavailability);
                    //    $("#diptv1ram").text(jsonobj[0].diptvram);
                    //    $("#diptv1cpu").text(jsonobj[0].diptvcpu);
                    //    $("#diptv1disk").text(jsonobj[0].diptvdisk);
                    //} else {
                    //    $("#diptv1connect").text(". Offline");
                    //    $("#imgdiptv1").attr('src', 'images/TV_offline.jpg')
                    //    $("#diptv1connect").removeClass('headline');
                    //    $("#diptv1connect").addClass('headlineoffline')
                    //    $("#diptv1availability").text("0%");
                    //    $("#diptv1ram").text("0%");
                    //    $("#diptv1cpu").text("0%");
                    //    $("#diptv1disk").text("0%");
                    //}
                },
                error: function (xhr, status, error) {
                    // alert(xhr.responseText);
                    $("#diptv1connect").text(". Offline");
                    $("#imgdiptv1").attr('src', 'images/TV_offline.jpg')
                    $("#diptv1connect").removeClass('headline');
                    $("#diptv1connect").addClass('headlineoffline')
                    $("#diptv1availability").text("0%");
                    $("#diptv1ram").text("0%");
                    $("#diptv1cpu").text("0%");
                    $("#diptv1disk").text("0%");
                }
            });
        }

    </script>

</body>
</html>
