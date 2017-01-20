<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_01_2.aspx.vb" Inherits="frmSignage_01_2" %>

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
            font-size: 20px;
            color: #31999a;
        }
        .headline2 {
            font-family: Tahoma;
            font-size: 16px;
            color: #31999a;
        }
        .headlineoffline {
            font-family: Tahoma;
            font-size: 22px;
            color: red;
        }

        .Hdevice_name {
            font-family: Tahoma;
            font-size: 16px;
            font-weight: bold;
            color: #515151;
            color: #414042;
        }

        .Hdevice_name2 {
            font-family: Tahoma;
            font-size: 16px;
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
                 <table style="width: 100%; border: none; border-width: 1px; height: 660px;vertical-align:top;"  cellspacing="0" cellpadding="1" >
                
                   <tr>
                    <td style="vertical-align:top">
                       <table style="width: 100%; border: none; border-width: 1px; height: 330px;"  cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center" >
                            <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top"  height= "300px" >
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw1connect" class="headlineoffline">• Offline</span><span id="dipsw1flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw1"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw1name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw1ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw1os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                               <tr>
                                                   <td>
                                                    <div id="spw1" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>
                                          
                    <%--                  <tr>
                                        <td colspan="2"><span class="headline">Availability</span></td>
                                      </tr>
                                    <tr>
                                        <td  colspan="2"><span  id="dipsw1availability" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">CPU</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw1cpu" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">RAM</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw1ram" class="server_per2">0%</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span class="headline">Disk</span></td>
                                      </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw1disk" class="server_per2">0%</span></td>
                                        </tr>--%>
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
                        <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center">
                           <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "330px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw2connect" class="headlineoffline">• Offline</span><span id="dipsw2flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw2"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw2name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw2ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw2os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                        <tr>
                                                   <td>
                                                    <div id="spw2" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>

                                      <%--<tr>
                                        <td colspan="2"><span class="headline">Availability</span></td>
                                      </tr>
                                    <tr>
                                        <td  colspan="2"><span  id="dipsw2availability" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">CPU</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw2cpu" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">RAM</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw2ram" class="server_per2">0%</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span class="headline">Disk</span></td>
                                      </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw2disk" class="server_per2">0%</span></td>
                                        </tr>--%>
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
                        <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center">
                          <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "330px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw3connect" class="headlineoffline">• Offline</span><span id="dipsw3flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw3"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw3name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw3ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw3os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                            <tr>
                                                   <td>
                                                    <div id="spw3" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>
                                  <%--    <tr>
                                        <td colspan="2"><span class="headline">Availability</span></td>
                                      </tr>
                                    <tr>
                                        <td  colspan="2"><span  id="dipsw3availability" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">CPU</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw3cpu" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">RAM</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw3ram" class="server_per2">0%</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span class="headline">Disk</span></td>
                                      </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw3disk" class="server_per2">0%</span></td>
                                        </tr>--%>
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
                        <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center">
                             <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "300px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw4connect" class="headlineoffline">• Offline</span><span id="dipsw4flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw4"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw4name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw4ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw4os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                            <tr>
                                                   <td>
                                                    <div id="spw4" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>
                                    <%--  <tr>
                                        <td colspan="2"><span class="headline">Availability</span></td>
                                      </tr>
                                    <tr>
                                        <td  colspan="2"><span  id="dipsw4availability" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">CPU</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw4cpu" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">RAM</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw4ram" class="server_per2">0%</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span class="headline">Disk</span></td>
                                      </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw4disk" class="server_per2">0%</span></td>
                                        </tr>--%>
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
                        <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center">
                             <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "300px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw5connect" class="headlineoffline">• Offline</span><span id="dipsw5flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw5"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw5name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw5ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw5os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                            <tr>
                                                   <td>
                                                    <div id="spw5" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>
                                    <%--  <tr>
                                        <td colspan="2"><span class="headline">Availability</span></td>
                                      </tr>
                                    <tr>
                                        <td  colspan="2"><span  id="dipsw5availability" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">CPU</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw5cpu" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">RAM</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw5ram" class="server_per2">0%</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span class="headline">Disk</span></td>
                                      </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw5disk" class="server_per2">0%</span></td>
                                        </tr>--%>
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
                     <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center" >
                            <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "300px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw6connect" class="headlineoffline">• Offline</span><span id="dipsw6flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw6"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw6name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw6ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw6os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                            <tr>
                                                   <td>
                                                    <div id="spw6" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>
    <%--                                  <tr>
                                        <td colspan="2"><span class="headline">Availability</span></td>
                                      </tr>
                                    <tr>
                                        <td  colspan="2"><span  id="dipsw6availability" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">CPU</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw6cpu" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">RAM</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw6ram" class="server_per2">0%</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span class="headline">Disk</span></td>
                                      </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw6disk" class="server_per2">0%</span></td>
                                        </tr>--%>
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
          
                    </tr>
                </table>
                    </td>
                </tr>
                   <tr>
                    <td style="vertical-align:top">
                       <table style="width: 100%; border: none; border-width: 1px; height: 330px;" cellspacing="0" cellpadding="1">
                    <tr>

                       
                        <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center">
                             <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "300px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw7connect" class="headlineoffline">• Offline</span><span id="dipsw7flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw7"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw7name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw7ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw7os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                            <tr>
                                                   <td>
                                                    <div id="spw7" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>
                                      <%--<tr>
                                        <td colspan="2"><span class="headline">Availability</span></td>
                                      </tr>
                                    <tr>
                                        <td  colspan="2"><span  id="dipsw7availability" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">CPU</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw7cpu" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">RAM</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw7ram" class="server_per2">0%</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span class="headline">Disk</span></td>
                                      </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw7disk" class="server_per2">0%</span></td>
                                        </tr>--%>
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
                        <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center">
                             <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "300px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw8connect" class="headlineoffline">• Offline</span><span id="dipsw8flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw8"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw8name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw8ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw8os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                            <tr>
                                                   <td>
                                                    <div id="spw8" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>
                                      <%--<tr>
                                        <td colspan="2"><span class="headline">Availability</span></td>
                                      </tr>
                                    <tr>
                                        <td  colspan="2"><span  id="dipsw8availability" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">CPU</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw8cpu" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">RAM</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw8ram" class="server_per2">0%</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span class="headline">Disk</span></td>
                                      </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw8disk" class="server_per2">0%</span></td>
                                        </tr>--%>
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
                        <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center">
                           <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "300px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw9connect" class="headlineoffline">• Offline</span><span id="dipsw9flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw9"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw9name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw9ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw9os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                            <tr>
                                                   <td>
                                                    <div id="spw9" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>
                                     <%-- <tr>
                                        <td colspan="2"><span class="headline">Availability</span></td>
                                      </tr>
                                    <tr>
                                        <td  colspan="2"><span  id="dipsw9availability" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">CPU</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw9cpu" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">RAM</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw9ram" class="server_per2">0%</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span class="headline">Disk</span></td>
                                      </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw9disk" class="server_per2">0%</span></td>
                                        </tr>--%>
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
                        <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center">
                         <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "300px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw10connect" class="headlineoffline">• Offline</span><span id="dipsw10flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw10"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw10name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw10ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw10os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                            <tr>
                                                   <td>
                                                    <div id="spw10" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>
                                     <%-- <tr>
                                        <td colspan="2"><span class="headline">Availability</span></td>
                                      </tr>
                                    <tr>
                                        <td  colspan="2"><span  id="dipsw10availability" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">CPU</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw10cpu" class="server_per2">0%</span></td>
                                        </tr>
                                       <tr>
                                        <td colspan="2"><span class="headline">RAM</span></td>
                                        </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw10ram" class="server_per2">0%</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span class="headline">Disk</span></td>
                                      </tr>
                                      <tr>
                                        <td  colspan="2"><span id="dipsw10disk" class="server_per2">0%</span></td>
                                        </tr>--%>
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
                             <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center">
                             <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "300px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw11connect" class="headlineoffline">• Offline</span><span id="dipsw11flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw11"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw11name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw11ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw11os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                            <tr>
                                                   <td>
                                                    <div id="spw11" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
                                               </tr>
                                   
                                    </table>

                                    </td>
                                  </tr>
                            </table>
                        </td>
                        <td style="width: 16%; border: none; border-width: 1px; height: 330px" align="center">
                         <table width="98%" height: "330px" border="0" cellspacing="0" cellpadding="0"class="classname">
                                  <tr>
                                    <td width="100%"  align="left" valign="top" height= "300px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                      <tr>
                                        <td width="104" align="left"><span id="dipsw12connect" class="headlineoffline">• Offline</span><span id="dipsw12flor" class="device_name"></span></td>
                                       
                                      </tr>
                                     <tr>
                                        <td colspan="2" align="center"><img id="imagedipsw12"  src="images/speedway_offline.png" width="100%" height="30" /></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2"><span  id="dipsw12name" class="Hdevice_name2">...</span></td>
                                        </tr>
                                      <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                          <tr>
                                            <td width="53" height="21"><span  class="headline">IP :</span></td>
                                            <td width="146"><span id="dipsw12ip" class="device_name"></span></td>
                                          </tr>
                                          <tr>
                                            <td><span class="headline">OS :</span></td>
                                            <td><span id="dipsw12os" class="device_name"></span></td>
                                          </tr>
                                        </table>

                                        </td>
                                      </tr>
                                                            <tr>
                                                   <td>
                                                    <div id="spw12" style="width: 100%; height: 182px; margin: 0 auto"></div>
                                                   </td>
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
           // LoadDataAllServer();
            LoadDataSpeedwayAll();
             // LoadDataTVALL();

           // Genhbar();
        });

         function Genhbar(controlid, data) {
 
            //var data = [];
            //var datatemp = { 'y': 10, 'color': 'green' };
            //for (var i = 0; i < 4; ++i) {
            //    data.push(datatemp);
            //}
            $('#spw' + controlid).highcharts({
                chart: {
                    type: 'bar',
                    backgroundColor: '#e6e7e8'                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    categories: ['Availability', 'CPU', 'RAM', 'Disk'],
                    title: {
                        text: null
                    },
                    labels: {
                        style: {
                            fontSize: '11px',
                            "color": "#31999a"
                            , "fontWeight": "bold"
                        }

                    }
                },
                yAxis: {
                    min: 0,
                    max: 100,
                    title: {
                        text: '',
                        align: 'high'
                    },
                    labels: {
                        overflow: 'justify'
                    }
                },
                tooltip: {
                    valueSuffix: ' '
                },
                plotOptions: {
                    bar: {
                        dataLabels: {
                            enabled: true
                         }
                      
                        
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'top',
                    x: -40,
                    y: 100,
                    floating: true,
                    borderWidth: 1,
                    backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
                    shadow: true
                },
                credits: {
                    enabled: false
                },
                series: [{
                    showInLegend: false,
                    name: 'Speed Way',
                   // data: [10, 20, 35, 99],
                    data: data //[{ 'y': 10, 'color': 'green' }, { 'y': 20, 'color': 'yellow' }, { 'y': 35, 'color': 'red' }, { 'y': 99, 'color': 'red' }]
                }]
            });
        }


        function LoadDataSpeedwayAll() {
            var dataurl = 'WebService/WebService.asmx/LoadDipSpeedway';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    var jsonobj = JSON.parse(data.d);
                    var index =1;
                    $.each(jsonobj, function (key, val) {
                        if (val.online_status == 'Y') {
                            $("#imagedipsw" + index ).attr('src', 'images/speedway_online.png')
                            $("#dipsw" + index + "connect").removeClass('headlineoffline');
                            $("#dipsw" + index + "connect").addClass('headline')
                            $("#dipsw" + index + "connect").text('. Online');
                        } else {
                            $("#imagedipsw" + index).attr('src', 'images/speedway_offline.png')
                            $("#dipsw" + index + "connect").removeClass('headline');
                            $("#dipsw" + index + "connect").addClass('headlineoffline')
                            $("#dipsw" + index + "connect").text('. Offline');
                        }
                        var strservername;
                        if (val.ServerName.length > 20) {
                            strservername = val.ServerName.substring(0, 20) + '...';
                        } else {
                            strservername = val.ServerName;
                        }
                        $("#dipsw" + index + "flor").text('(' + val.floor_name +')');
                        $("#dipsw" + index + "name").text(strservername);
                        $("#dipsw" + index + "ip").text(val.ServerIP);
                        $("#dipsw" + index + "os").text(val.OS);
                        $("#dipsw" + index + "availability").text(val.today_alailable + '%');
                        $("#dipsw" + index + "cpu").text(val.CPUPercent + '%');
                        $("#dipsw" + index + "ram").text(val.RAMPercent + '%');
                        $("#dipsw" + index + "disk").text(val.DiskPercent + '%');

                        var datasend = [];
                        var dataavailability = { 'y': val.today_alailable, 'color': getcoloravalibality(val.today_alailable, val.AlarmMinorValueAvb, val.AlarmMajorValueAvb, val.AlarmCriticalValueAvb) };
                        var datacpu = { 'y': val.CPUPercent, 'color': getcolor(val.CPUPercent, val.AlarmMinorValueCPU, val.AlarmMajorValueCPU, val.AlarmCriticalValueCPU) };
                        var dataram = { 'y': val.RAMPercent, 'color': getcolor(val.RAMPercent, val.AlarmMinorValueRAM, val.AlarmMajorValueRAM, val.AlarmCriticalValueRAM) };
                        var datadisk = { 'y': val.DiskPercent, 'color': getcolor(val.DiskPercent, val.AlarmMinorValueDisk, val.AlarmMajorValueDisk, val.AlarmCriticalValueDisk) };

                        //gensv2_avb(jsonobj[1].today_alailable, jsonobj[1].AlarmMinorValueAvb, jsonobj[1].AlarmMajorValueAvb, jsonobj[1].AlarmCriticalValueAvb);
                        //gensv2_cpu(jsonobj[1].CPUPercent, jsonobj[1].AlarmMinorValueCPU, jsonobj[1].AlarmMajorValueCPU, jsonobj[1].AlarmCriticalValueCPU);
                        //gensv2_ram(jsonobj[1].RAMPercent, jsonobj[1].AlarmMinorValueRAM, jsonobj[1].AlarmMajorValueRAM, jsonobj[1].AlarmCriticalValueRAM);
                        //gensv2_disk(jsonobj[1].DiskPercent, jsonobj[1].AlarmMinorValueDisk, jsonobj[1].AlarmMajorValueDisk, jsonobj[1].AlarmCriticalValueDisk);


                        datasend.push(dataavailability);
                        datasend.push(datacpu);
                        datasend.push(dataram);
                        datasend.push(datadisk);
                    
                        Genhbar(index, datasend);

                        index = index + 1;
                    })

   
                },
                error: function (xhr, status, error) {
                    
                }
            });
        }

        function getcolor(value, Minor, Major, Critical) {
            
            if (Minor == 0) {
                Minor = 50;
            }
            if (Major == 0) {
                Major = 70;
            }
            if (Critical == 0) {
                Critical = 90;
            }
            if (value <= Major) {
                return 'green';
            } else if (value <= Critical) {
                return 'yellow';
            } else {
                return 'red';
            }
        }
        function getcoloravalibality(value, Minor, Major, Critical) {
            if (Minor == 0) {
                Minor = 50;
            }
            if (Major == 0) {
                Major = 70;
            }
            if (Critical == 0) {
                Critical = 90;
            }
        
            if (value <= Minor) {
                return 'red';
            } else if (value <= Major) {
                return 'yellow';
            } else {
                return 'green';
            }
        }

      
    </script>

</body>
</html>
