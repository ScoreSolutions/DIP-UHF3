<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSignage_05.aspx.vb" Inherits="frmSignage_05" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .text_status {
            font-family: tahoma;
            color: #FFF;
            font-weight: bold;
            font-size: 95px;
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

</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="center-block">
                <div class="col-lg-12">
                    <table style="width: 100%; border: none;">
                        <tr>
                            <td style="width: 33%; border: none; height: 680px; vertical-align: top;" align="center">
                                <table style="width: 99%; border: none; height: 680px">
                                    <tr>
                                        <td style="width: 100%; border: none; height: 80px" align="left" colspan="3">
                                            <img src="images/gage_header.png" width="70%" height="80px" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 33%; border: none; height: 600px;vertical-align: middle;" align="center">
                                            <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td colspan="3">
                                                        <img src="images/floor1_header.png" width="100%" height="60px" /></td>
                                                </tr>
                                                <tr>
                                                    <td width="31%">
                                                        <img src="images/temp_1.png" width="100%" height="165px" /></td>
                                                    <td width="49%" align="right" bgcolor="#27a9e3" class="text_status"><span id="f1temp"></span></td>
                                                    <td width="20%" align="center" bgcolor="#27a9e3">
                                                        <img style="display:none" id="img1temp" src="images/c.png" width="100%" height="80px" /></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="center" bgcolor="#27a9e3" height="20">
                                                        <img src="images/line.jpg" width="100%" height="2px" /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <img src="images/moiture_1.png" width="100%" height="165px" /></td>
                                                    <td align="right" bgcolor="#27a9e3" class="text_status"><span id="f1hum"></span></td>
                                                    <td align="center" bgcolor="#27a9e3">
                                                        <img style="display:none" id="img1hum" src="images/percent.png" width="100%" height="80px" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="20" colspan="3" align="center" bgcolor="#27a9e3">
                                                        <img  src="images/line.jpg" width="100%" height="2px" /></td>
                                                </tr>
                                              <tr>
                                                    <td>
                                                        <img src="images/dust_1.png" width="100%" height="165px" /></td>
                                                    <td align="right" bgcolor="#27a9e3" class="text_status"><span id="f1eye"></span></td>
                                                    <td align="center" bgcolor="#27a9e3">
                                                        <img style="display:none" id="img1eye" src="images/percent.png" width="100%" height="80px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 33%; border: none; height: 600px" align="center">
                                           <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td colspan="3">
                                                        <img src="images/floor10101_header.png" width="100%" height="60px" /></td>
                                                </tr>
                                                <tr>
                                                    <td width="31%">
                                                        <img src="images/temp_2.png" width="100%" height="165px" /></td>
                                                    <td width="49%" align="right" bgcolor="#28b779" class="text_status"><span id="f2temp"></span></td>
                                                    <td width="20%" align="center" bgcolor="#28b779">
                                                        <img style="display:none" id="img2temp" src="images/c.png" width="100%" height="80px" /></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="center" bgcolor="#28b779" height="20">
                                                        <img src="images/line.jpg" width="100%" height="2px" /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <img src="images/moiture_2.png" width="100%" height="165px" /></td>
                                                    <td align="right" bgcolor="#28b779" class="text_status"><span id="f2hum"></span></td>
                                                    <td align="center" bgcolor="#28b779">
                                                        <img style="display:none" id="img2hum" src="images/percent.png" width="100%" height="80px" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="20" colspan="3" align="center" bgcolor="#28b779">
                                                        <img src="images/line.jpg" width="100%" height="2px" /></td>
                                                </tr>
                                              <tr>
                                                    <td>
                                                        <img src="images/dust_2.png" width="100%" height="165px" /></td>
                                                    <td align="right" bgcolor="#28b779" class="text_status"><span id="f2eye"></span></td>
                                                    <td align="center" bgcolor="#28b779">
                                                        <img style="display:none" id="img2eye" src="images/percent.png" width="100%" height="80px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 33%; border: none; height: 600px" align="center">
                                            <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td colspan="3">
                                                        <img src="images/floor6_header.png" width="100%" height="60px" /></td>
                                                </tr>
                                                <tr>
                                                    <td width="31%">
                                                        <img src="images/temp_3.png" width="100%" height="165px" /></td>
                                                    <td width="49%" align="right" bgcolor="#852b99" class="text_status"><span id="f3temp"></span></td>
                                                    <td width="20%" align="center" bgcolor="#852b99">
                                                        <img style="display:none" id="img3temp" src="images/c.png" width="100%" height="80px" /></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="center" bgcolor="#852b99" height="20">
                                                        <img src="images/line.jpg" width="100%" height="2px" /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <img src="images/moiture_3.png" width="100%" height="165px" /></td>
                                                    <td align="right" bgcolor="#852b99" class="text_status"><span id="f3hum"></span></td>
                                                    <td align="center" bgcolor="#852b99">
                                                        <img style="display:none" id="img3hum" src="images/percent.png" width="100%" height="80px" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="20" colspan="3" align="center" bgcolor="#852b99">
                                                        <img src="images/line.jpg" width="100%" height="2px" /></td>
                                                </tr>
                                              <tr>
                                                    <td>
                                                        <img src="images/dust_3.png" width="100%" height="165px" /></td>
                                                    <td align="right" bgcolor="#852b99" class="text_status"><span id="f3eye"></span></td>
                                                    <td align="center" bgcolor="#852b99">
                                                        <img style="display:none" id="img3eye" src="images/percent.png" width="100%" height="80px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                            <%--     <td style="width: 33%; border: none;  height: 680px;vertical-align: top;" align="center">
                                 <table style="width: 99%; border: none;  height: 680px">
                                    <tr>
                                        <td style="width: 100%; border: groove;  height: 60px" align="center" ></td>

                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: groove;  height: 420px" align="center">
                                        </td>
                                       
                                    </tr>

                                </table>
                             </td>
                                                          <td style="width: 33%; border: none;  height: 680px;vertical-align: top;" align="center">
                                 <table style="width: 99%; border: none;  height: 680px">
                                    <tr>
                                        <td style="width: 100%; border: groove;  height: 60px" align="center" ></td>

                                    </tr>
                                    <tr>
                                        <td style="width: 100%; border: groove;  height: 420px" align="center">
                                        </td>
                                       
                                    </tr>

                                </table>
                             </td>--%>
                        </tr>


                    </table>
                </div>

            </div>


        </div>
    </form>

    <script>
        $(document).ready(function () {
            //ShowGraphBar();
            //ShowTableFileAge();
            //ShowAmountBorrowKPI();
            //ShowAmountReturnKPI();
            //LoadDipAmountLocation(1);
            //LoadDipAmountLocation(2);
            //LoadDipAmountLocation(3);
            //LoadDipAmountLocation(4);   
            LoadDataLocationDeviceDataAll();
            LoadParticleValue();
        })

        function LoadDataLocationDeviceDataAll() {
            var dataurl = 'WebService/WebService.asmx/LoadDipLocationDeviceData';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    var jsonobj = JSON.parse(data.d);
                   // var index = 1;
                    $.each(jsonobj, function (key, val) {

                        if (val.id == 1) {
                        $("#f1temp").text(val.temp_value);
                        $("#f1hum").text(val.humidity_value);
                            // $("#f1eye").text('');
                        $("#img1temp").show();
                        $("#img1hum").show();
                        //$("#img1eye").show();
                        }
                        if (val.id == 2) {
                            $("#f2temp").text(val.temp_value);
                            $("#f2hum").text(val.humidity_value);
                            // $("#f1eye").text('');
                            $("#img2temp").show();
                            $("#img2hum").show();
                            //$("#img2eye").show();
                        }
                        if (val.id == 6) {
                            $("#f3temp").text(val.temp_value);
                            $("#f3hum").text(val.humidity_value);
                            // $("#f3eye").text('');
                            $("#img3temp").show();
                            $("#img3hum").show();
                            //$("#img3eye").show();
                        }


                        //$("#f" + index + "eye").text(val.ServerIP);

                        //$("#img" + index + "temp").text('(' + val.floor_name + ')');
                        //$("#img" + index + "hum").text(strservername);
                        //$("#img" + index + "eye").text(val.ServerIP);

                        //index = index + 1;
                    })


                },
                error: function (xhr, status, error) {

                }
            });
        }

        function LoadParticleValue() {
            var dataurl = 'WebService/WebService.asmx/LoadParticleValue';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    var jsonobj = JSON.parse(data.d);
                    // var index = 1;
                    $.each(jsonobj, function (key, val) {

                        if (val.id == 1) {
                            $("#f1eye").text(val.particle_value);
                            $("#img1eye").show();
                        }
                        if (val.id == 2) {
                            $("#f2eye").text(val.particle_value);
                            $("#img2eye").show();
                        }
                        if (val.id == 6) {
                            $("#f3eye").text(val.particle_value);
                            $("#img3eye").show();
                        }
                    })

                },
                error: function (xhr, status, error) {

                }
            });
        }
    </script>






</body>
</html>
