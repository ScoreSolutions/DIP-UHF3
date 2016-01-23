<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmImagePosition.aspx.vb" Inherits="frmImagePosition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!--page specific plugin styles-->

    <!--fonts-->

    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

    <!--page specific plugin styles-->

    <link rel="stylesheet" href="assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="assets/css/chosen.css" />
    <link rel="stylesheet" href="assets/css/datepicker.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-timepicker.css" />
    <link rel="stylesheet" href="assets/css/daterangepicker.css" />
    <link rel="stylesheet" href="assets/css/colorpicker.css" />
    <link rel="stylesheet" href="assets/css/jquery.gritter.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-editable.css" />



    <!--ace styles-->

    <link rel="stylesheet" href="assets/css/ace.min.css" />
    <link rel="stylesheet" href="assets/css/ace-responsive.min.css" />
    <link rel="stylesheet" href="assets/css/ace-skins.min.css" />


    <%--    <link href="assets/alertify.js-0.3.11/themes/alertify.core.css" rel="stylesheet" />
    <link href="assets/alertify.js-0.3.11/themes/alertify.default.css" rel="stylesheet" id="toggleCSS" />

    <script src="assets/js/jquery-1.11.1.min.js"></script>
    <script src="assets/alertify.js-0.3.11/lib/alertify.min.js"></script>--%>


    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

    <!--inline styles related to this page-->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <!--basic scripts-->



    <!--[if !IE]>-->

    <script type="text/javascript">
        window.jQuery || document.write("<script src='assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>

    <!--<![endif]-->

    <!--[if IE]>
<script type="text/javascript">
 window.jQuery || document.write("<script src='assets/js/jquery-1.10.2.min.js'>"+"<"+"/script>");
</script>
<![endif]-->

    <script type="text/javascript">
        if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
    </script>
    <script src="assets/js/bootstrap.min.js"></script>

    <%--<script src="assets/js/jquery-1.11.1.js"></script>--%>
    <script src="assets/js/jquery-ui-1.11.1.js"></script>
    <link href="assets/themes/start/jquery-ui.css" rel="stylesheet" />
    <!--alertify scripts-->



    <!--page specific plugin scripts-->

    <!--[if lte IE 8]>
		  <script src="assets/js/excanvas.min.js"></script>
		<![endif]-->



    <script src="assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="assets/js/jquery.slimscroll.min.js"></script>
    <script src="assets/js/jquery.easy-pie-chart.min.js"></script>
    <script src="assets/js/jquery.sparkline.min.js"></script>
    <script src="assets/js/flot/jquery.flot.min.js"></script>
    <script src="assets/js/flot/jquery.flot.pie.min.js"></script>
    <script src="assets/js/flot/jquery.flot.resize.min.js"></script>
    <script src="assets/js/chosen.jquery.min.js"></script>
    <script src="assets/js/fuelux/fuelux.spinner.min.js"></script>
    <script src="assets/js/date-time/bootstrap-timepicker.min.js"></script>
    <script src="assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <script src="assets/js/jquery.inputlimiter.1.3.1.min.js"></script>
    <script src="assets/js/chosen.jquery.min.js"></script>
    <%--   Browe File--%>
    <script src="assets/js/bootstrap-wysiwyg.min.js"></script>

    <script src="assets/js/jquery.gritter.min.js"></script>
    <script src="assets/js/x-editable/bootstrap-editable.min.js"></script>
    <script src="assets/js/x-editable/ace-editable.min.js"></script>



    <!--page specific plugin scripts-->

    <script src="assets/js/jquery.dataTables.min.js"></script>
    <script src="assets/js/jquery.dataTables.bootstrap.js"></script>

    <!--ace scripts-->

    <script src="assets/js/ace-elements.min.js"></script>
    <script src="assets/js/ace.min.js"></script>


   <script src="Demo/assets/js/jquery-blink/jquery-blink/jquery-blink.js"></script>

    <link href="assets/js/jquery.svg.package-1.5.0/jquery.svg.css" rel="stylesheet" />
    <script src="assets/js/jquery.svg.package-1.5.0/jquery.svg.js"></script>


        <style>
        #svgbasics { width: 800px; height: 500px; border: 1px solid #484; }
    </style>

    <style type="text/css" media="screen">

        .tbbackground {
            background: url(images/floor-plan-10.gif);background-size: 100% auto;background-repeat: no-repeat;align-content: center; border: 1px solid #484;
        }
    </style>

    
        <script type="text/javascript">

            $(document).ready(function () {
                $('.blink').blink(); // default is 500ms blink interval.
                //$('.blink').blink({delay:100}); // causes a 100ms blink interval.
            });

        </script>


</head>
<body>
    <form id="form1" runat="server">

        <div>
            <%-- <img id="Image1" runat="server" alt="" src="~/images/floor-plan-10.gif" style="width: 800px; height: 500px" />--%>
                        <div id="tbImage">
                <table  border="1" style=" background: url(images/floor-plan-10.gif);background-size: 100% auto;background-repeat: no-repeat;align-content: center; border: 1px solid #484;width:800px;height:460px" >
                    <tr>
                        <td id="cell1" >
                            1
                        </td>    <td>2</td>    <td>3</td>  <td>4</td>  <td>5</td>
                    </tr>
                    <tr>
                        <td>6</td>    <td class="blink" style="background-color:skyblue">7</td>    <td>8</td>  <td>9</td>  <td>10</td>
                    </tr>
                    <tr>
                        <td>11</td>    <td>12</td>    <td>13</td> <td>14</td>    <td>15</td>
                    </tr>
                                  <tr>
                        <td>16</td>    <td>17</td>    <td>18</td> <td>19</td>    <td>20</td>
                    </tr>
                </table>
            </div>
            <div id="svgbasics" style="display:none">
            </div>
        </div>
    </form>

    <script type="text/javascript">
           //Open page
                           $(document).ready(function () {
                               $('#svgbasics').svg({ onLoad: drawInitial });

                               //setTimeout(function () {
                               //    // Do something after 5 seconds
                               //    alert(11111);
                               //}, 5000);
                               // window.setInterval(onProcess, 10000);

                               //$('#svgbasics').bind("click", function (e) {
                               //    getImageXY(e, this);
                               //});

                               $("#svgbasics").click(function (e) {
                                   // alert(e.pageX + ', ' + e.pageY);
                                   var offset = $(this).offset();
                                   alert('X: ' + (e.clientX - offset.left) + '\nY: ' + (e.clientY - offset.top));
                               });

                           });

                           function onProcess() {
                               alert(localStorage['appno']);
                           }

                           function drawInitial(svg) {
                               svg.describe('This graphic links to an external image');
                               var img = svg.image(0, 0, 800, 500, 'images/floor-plan-10.gif');
                               svg.title(img, 'My image');
                               svg.script('function circleClick2(evt) { alert(999); }', 'text/ecmascript');
                               var img1 = svg.image(195, 45, 40, 40, 'images/DrawingPin1_Blue.png', { onclick: 'circleClick("888")' });
                               svg.title(img1, 'My image pin1');

                               img1 = svg.image(466 -10, 444 -35, 40, 40, 'images/DrawingPin1_Blue.png', { onclick: 'circleClick("777")' });
                               svg.title(img1, 'My image pin2');

                               img1 = svg.image(548-10, 291 -35, 40, 40, 'images/DrawingPin1_Blue.png', { onclick: 'circleClick("777")' });
                               svg.title(img1, 'My image pin3');

                               img1 = svg.image(372 - 20, 203 - 20, 40, 40, 'images/DrawingPin1_Blue.png', { onclick: 'circleClick("777")' });
                               svg.title(img1, 'My image pin4');

                               img1 = svg.image(225 - 10, 437 - 35, 40, 40, 'images/DrawingPin1_Blue.png', { onclick: 'circleClick("777")' });
                               svg.title(img1, 'My image pin5');

                               img1 = svg.image(241 -10 , 156 - 35, 40, 40, 'images/DrawingPin1_Blue.png', { onclick: 'circleClick("777")' });
                               svg.title(img1, 'My image pin6');

            
                               //var myrect = svg.circle(208, 75, 10, { fill: 'red' });
                               //var myrect2 = svg.circle(208, 75, 10, { fill: 'red' });
                               // svg.circle(parent, cx, cy, r, settings)
                               //svg.circle(208, 75, 10, { fill: 'red' });

            
                           }
                           function circleClick(evt) { 
                               alert(evt);
                           }
                           function onPush() {
                               alert(1);
                           }


                           </script>
                       </body>
</html>
