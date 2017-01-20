<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_02.aspx.vb" Inherits="frmSignage_02" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="assets/bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery-2.0.3.min.js"></script>
    <script src="assets/js/jQuery.Marquee/jquery.marquee.js"></script>

    <style type="text/css">
        .classname {
            background: #e6e7e8;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
        }

        .Hdevice_name {
            font-family: Tahoma;
            font-size: 16px;
            font-weight: bold;
            color: #515151;
            color: #414042;
        }

        .headline {
            font-family: Tahoma;
            font-size: 16px;
            color: #31999a;
        }

        .device_name {
            font-family: Tahoma;
            font-size: 16px;
            color: #515151;
            color: #414042;
        }

        .Hper {
            font-family: Tahoma;
            font-size: 20px;
            color: #515151;
            color: #31999a;
        }

        .text_per {
            font-family: Tahoma;
            font-size: 35px;
            color: #515151;
            color: #414042;
        }

        .Hdevice_name1 {
            font-family: Tahoma;
            font-size: 16px;
            font-weight: bold;
            color: #515151;
            color: #414042;
        }

        .Hper1 {
            font-family: Tahoma;
            font-size: 20px;
            color: #515151;
            color: #31999a;
        }

        .device_name1 {
            font-family: Tahoma;
            font-size: 16px;
            color: #515151;
            color: #414042;
        }

        .text_per1 {
            font-family: Tahoma;
            font-size: 35px;
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

        .Hper2 {
            font-family: Tahoma;
            font-size: 20px;
            color: #515151;
            color: #31999a;
        }

        .device_name2 {
            font-family: Tahoma;
            font-size: 16px;
            color: #515151;
            color: #414042;
        }

        .text_per2 {
            font-family: Tahoma;
            font-size: 35px;
            color: #515151;
            color: #414042;
        }

        .Hdevice_name3 {
            font-family: Tahoma;
            font-size: 16px;
            font-weight: bold;
            color: #515151;
            color: #414042;
        }

        .Hper3 {
            font-family: Tahoma;
            font-size: 20px;
            color: #515151;
            color: #31999a;
        }

        .device_name3 {
            font-family: Tahoma;
            font-size: 16px;
            color: #515151;
            color: #414042;
        }

        .text_per3 {
            font-family: Tahoma;
            font-size: 35px;
            color: #515151;
            color: #414042;
        }

        .Hdevice_name4 {
            font-family: Tahoma;
            font-size: 16px;
            font-weight: bold;
            color: #515151;
            color: #414042;
        }

        .Hper4 {
            font-family: Tahoma;
            font-size: 20px;
            color: #515151;
            color: #31999a;
        }

        .device_name4 {
            font-family: Tahoma;
            font-size: 16px;
            color: #515151;
            color: #414042;
        }

        .text_per4 {
            font-family: Tahoma;
            font-size: 35px;
            color: #515151;
            color: #414042;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <table style="width: 100%; border: none; border-width: 1px; border-width: 1px;">

                    <tr>
                        <td style="width: 25%; border: none; border-width: 1px; height: 680px" align="center" >
                            <table width="99%" border="0" cellspacing="0" cellpadding="1" class="classname">
                                <tr>
                                    <td width="100%" align="center" height="66px">
                                        <img id="imgDevice1"  src="images/device_available.png" width="100%" height="66px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name"><span id="lblDeviceName1">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper">Availability</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name"><span id="lblDeviceIp1"></span></td>
                                                           <%-- <td width="100%" ><span >IP :</span><span id="lblDeviceIp1"  class="device_name"></span></td>--%>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name"><span id="lblDeviceOs1"></span></td>
                                                            <%--<td width="100%" ><span >OS:</span><span id="lblDeviceOs1"  class="device_name"></span></td>--%>

                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name"><span id="lblDeviceLocation1"></span></td>
                                                            <%-- <td width="100%" ><span >Location :</span><span id="lblDeviceLocation1"  class="device_name"></span></td>--%>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per"><span id="lblDevicePer1">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                 <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" width="95%" height="1px" /></td>
                                </tr>
                                 <tr>
                                    <td  width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name1"><span id="lblDeviceName2">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper1">Availability</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name1"><span id="lblDeviceIp2"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name1"><span id="lblDeviceOs2"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name1"><span id="lblDeviceLocation2"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per1"><span id="lblDevicePer2">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                               <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" width="95%" height="1px" /></td>
                                </tr>
                                 <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name2"><span id="lblDeviceName3">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper2">Availability</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name2"><span id="lblDeviceIp3"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name2"><span id="lblDeviceOs3"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name2"><span id="lblDeviceLocation3"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per2"><span id="lblDevicePer3">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" alt="" width="95%" height="1px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name3"><span id="lblDeviceName4">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper3">Availability</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name3"><span id="lblDeviceIp4"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name3"><span id="lblDeviceOs4"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name3"><span id="lblDeviceLocation4"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="text_per3"><span id="lblDevicePer4">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" alt="" width="95%" height="1px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="99%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name4"><span id="lblDeviceName5">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper4">Availability</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name4"><span id="lblDeviceIp5"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name4"><span id="lblDeviceOs5"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name4"><span id="lblDeviceLocation5"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="text_per4">0%</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr> <%----%>
                            </table>

                        </td>
                        <td style="width: 25%; border: none; border-width: 1px; height: 680px"  align="center" >
                            <table width="99%" border="0" cellspacing="0" cellpadding="1" class="classname">
                                <tr>
                                    <td width="100%" align="center" height="66px">
                                        <img src="images/cpu_utilization.png" width="100%" height="60px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name"><span id="lblCpuName1">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper">CPU</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name"><span id="lblCpuIp1"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name"><span id="lblCpuOs1"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name"><span id="lblCpuLocation1"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per"><span id="lblCpuPer1">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                 <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" width="95%" height="1px" /></td>
                                </tr>
                                 <tr>
                                    <td  width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name1"><span id="lblCpuName2">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper1">CPU</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name1"><span id="lblCpuIp2"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name1"><span id="lblCpuOs2"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name1"><span id="lblCpuLocation2"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per1"><span id="lblCpuPer2">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                               <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" width="95%" height="1px" /></td>
                                </tr>
                                 <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name2"><span id="lblCpuName3">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper2">CPU</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name2"><span id="lblCpuIp3"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name2"><span id="lblCpuOs3"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name2"><span id="lblCpuLocation3"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per2"><span id="lblCpuPer3">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" alt="" width="95%" height="1px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name3"><span id="lblCpuName4">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper3">CPU</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name3"><span id="lblCpuIp4"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name3"><span id="lblCpuOs4"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name3"><span id="lblCpuLocation4"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="text_per3"><span id="lblCpuPer4">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" alt="" width="95%" height="1px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="99%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name4"><span id="lblCpuName5">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper4">CPU</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name4"><span id="lblCpuIp5"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name4"><span id="lblCpuOs5"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name4"><span id="lblCpuLocation5"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="text_per4"><span id="lblCpuPer5">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr> <%----%>
                            </table>
                        </td>
                        <td style="width: 25%; border: none; border-width: 1px; height: 680px"  align="center" >
                               <table width="99%" border="0" cellspacing="0" cellpadding="1" class="classname">
                                <tr>
                                    <td width="100%" align="center" height="66px">
                                        <img src="images/ram_utilization.png" width="100%" height="60px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name"><span id="lblRamName1">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper">RAM</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name"><span id="lblRamIp1"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name"><span id="lblRamOs1"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name"><span id="lblRamLocation1"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per"><span id="lblRamPer1">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                 <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" width="95%" height="1px" /></td>
                                </tr>
                                 <tr>
                                    <td  width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name1"><span id="lblRamName2">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper1">RAM</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name1"><span id="lblRamIp2"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name1"><span id="lblRamOs2"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name1"><span id="lblRamLocation2"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per1"><span id="lblRamPer2">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                               <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" width="95%" height="1px" /></td>
                                </tr>
                                 <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name2"><span id="lblRamName3">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper2">RAM</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name2"><span id="lblRamIp3"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name2"><span id="lblRamOs3"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name2"><span id="lblRamLocation3"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per2"><span id="lblRamPer3">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" alt="" width="95%" height="1px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name3"><span id="lblRamName4">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper3">RAM</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name3"><span id="lblRamIp4"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name3"><span id="lblRamOs4"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name3"><span id="lblRamLocation4"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="text_per3"><span id="lblRamPer4">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" alt="" width="95%" height="1px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="99%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name4"><span id="lblRamName5">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper4">RAM</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name4"><span id="lblRamIp5"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name4"><span id="lblRamOs5"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name4"><span id="lblRamLocation5"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="text_per4"><span id="lblRamPer5">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr> <%----%>
                            </table>
                        </td>
                        <td style="width: 25%; border: none; border-width: 1px; height: 680px"  align="center" >
                            <table width="99%" border="0" cellspacing="0" cellpadding="1" class="classname">
                                <tr>
                                    <td width="100%" align="center" height="66px">
                                        <img src="images/disk_utilization.png" width="100%" height="60px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name"><span id="lblDiskName1">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper">Disk</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name"><span id="lblDiskIp1"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name"><span id="lblDiskOs1"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name"><span id="lblDiskLocation1"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per"><span id="lblDiskPer1">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                 <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" width="95%" height="1px" /></td>
                                </tr>
                                 <tr>
                                    <td  width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name1"><span id="lblDiskName2">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper1">Disk</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name1"><span id="lblDiskIp2"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name1"><span id="lblDiskOs2"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name1"><span id="lblDiskLocation2"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per1"><span id="lblDiskPer2">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                               <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" width="95%" height="1px" /></td>
                                </tr>
                                 <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name2"><span id="lblDiskName3">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper2">Disk</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name2"><span id="lblDiskIp3"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name2"><span id="lblDiskOs3"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name2"><span id="lblDiskLocation3"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="center" valign="middle" class="text_per2"><span id="lblDiskPer3">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" alt="" width="95%" height="1px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name3"><span id="lblDiskName4">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper3">Disk</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name3"><span id="lblDiskIp4"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name3"><span id="lblDiskOs4"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name3"><span id="lblDiskLocation4"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="text_per3"><span id="lblDiskPer4">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="center" valign="middle">
                                        <img src="images/rank_line.jpg" alt="" width="95%" height="1px" /></td>
                                </tr>
                                <tr>
                                    <td width="100%" height="105px">
                                        <table width="99%" border="0" cellspacing="0" cellpadding="1">
                                            <tr>
                                                <td width="261" class="Hdevice_name4"><span id="lblDiskName5">...</span></td>
                                                <td width="193" rowspan="2" align="center" class="Hper4">Disk</td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" class="headline">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                        <tr>
                                                            <td width="111">IP :</td>
                                                            <td width="146" class="device_name4"><span id="lblDiskIp5"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>OS:</td>
                                                            <td class="device_name4"><span id="lblDiskOs5"></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Location :</td>
                                                            <td class="device_name4"><span id="lblDiskLocation5"></span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle" class="text_per4"><span id="lblDiskPer5">0%</span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr> <%----%>
                            </table>

                        </td>

                    </tr>

                </table>

            </div>

        </div>
    </form>

      <script type="text/javascript">
        $(document).ready(function () {
            LoadDataDeviceALL();
            LoadDataCPUALL();
            LoadDataRAMALL();
            LoadDataDiskALL();
        });



        function LoadDataDeviceALL() {
            var dataurl = 'WebService/WebService.asmx/GetTopDevice';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {

                    var jsonobj = JSON.parse(data.d);
                    var index = 1;
                    $.each(jsonobj, function (key, val) {
                        
                        $("#lblDeviceName" + index).text(val.ServerName);
                        $("#lblDeviceIp" + index).text(val.ServerIP);
                        var strvalOs;
                        if (val.OS.length > 9) {
                            strvalOs = val.OS.substring(0, 9) + '...';
                        } else {
                            strvalOs = val.OS;
                        }
                        $("#lblDeviceOs" + index).text(strvalOs);
                        var strvalLocationServer;
                        if (val.LocationServer.length > 9) {
                            strvalLocationServer = val.LocationServer.substring(0, 9) + '...';
                        } else {
                            strvalLocationServer = val.LocationServer;
                        }
                        $("#lblDeviceLocation" + index).text(strvalLocationServer);
                        $("#lblDevicePer" + index).text(val.today_alailable + '%');

                        index = index + 1;
                    })

                   
                },
                error: function (xhr, status, error) {
                    // alert(xhr.responseText);
                   
                }
            });
        }

        function LoadDataCPUALL() {
            var dataurl = 'WebService/WebService.asmx/GetTopCPU';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {

                    var jsonobj = JSON.parse(data.d);
                    var index = 1;
                    $.each(jsonobj, function (key, val) {

                        $("#lblCpuName" + index).text(val.ServerName);
                        $("#lblCpuIp" + index).text(val.ServerIP);
                        var strvalOs;
                        if (val.OS.length > 9) {
                            strvalOs = val.OS.substring(0, 9) + '...';
                        } else {
                            strvalOs = val.OS;
                        }
                        $("#lblCpuOs" + index).text(strvalOs);
                        var strvalLocationServer;
                        if (val.LocationServer.length > 9) {
                            strvalLocationServer = val.LocationServer.substring(0, 9) + '...';
                        } else {
                            strvalLocationServer = val.LocationServer;
                        }
                        $("#lblCpuLocation" + index).text(strvalLocationServer);
                        $("#lblCpuPer" + index).text(val.CPUPercent + '%');

                        index = index + 1;
                    })


                },
                error: function (xhr, status, error) {
                    // alert(xhr.responseText);

                }
            });
        }

        function LoadDataRAMALL() {
            var dataurl = 'WebService/WebService.asmx/GetTopRAM';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {

                    var jsonobj = JSON.parse(data.d);
                    var index = 1;
                    $.each(jsonobj, function (key, val) {
                        $("#lblRamName" + index).text(val.ServerName);
                        $("#lblRamIp" + index).text(val.ServerIP);
                        var strvalOs;
                        if (val.OS.length > 9) {
                            strvalOs = val.OS.substring(0, 9) + '...';
                        } else {
                            strvalOs = val.OS;
                        }
                        $("#lblRamOs" + index).text(strvalOs);
                        var strvalLocationServer;
                        if (val.LocationServer.length > 9) {
                            strvalLocationServer = val.LocationServer.substring(0, 9) + '...';
                        } else {
                            strvalLocationServer = val.LocationServer;
                        }
                        $("#lblRamLocation" + index).text(strvalLocationServer);
                        $("#lblRamPer" + index).text(val.RAMPercent + '%');

                        index = index + 1;
                    })


                },
                error: function (xhr, status, error) {
                    // alert(xhr.responseText);

                }
            });
        }

        function LoadDataDiskALL() {
            var dataurl = 'WebService/WebService.asmx/GetTopDisk';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {

                    var jsonobj = JSON.parse(data.d);
                    var index = 1;
                    $.each(jsonobj, function (key, val) {
                        $("#lblDiskName" + index).text(val.ServerName);
                        $("#lblDiskIp" + index).text(val.ServerIP);
                        var strvalOs;
                        if (val.OS.length > 14) {
                            strvalOs = val.OS.substring(0, 14) + '...';
                        } else {
                            strvalOs = val.OS;
                        }
                        $("#lblDiskOs" + index).text(strvalOs);
                        var strvalLocationServer;
                        if (val.LocationServer.length > 14) {
                            strvalLocationServer = val.LocationServer.substring(0, 14) + '...';
                        } else {
                            strvalLocationServer = val.LocationServer;
                        }
                        $("#lblDiskLocation" + index).text(strvalLocationServer);
                        $("#lblDiskPer" + index).text(val.DiskPercent + '%');

                        index = index + 1;
                    })


                },
                error: function (xhr, status, error) {
                    // alert(xhr.responseText);

                }
            });
        }
    </script>

</body>
</html>
