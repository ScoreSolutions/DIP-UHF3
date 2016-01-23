<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmImagePosition_old.aspx.vb" Inherits="frmImagePosition" %>
<!DOCTYPE html>
<html lang="en">
<head>


    <link href="assets/js/jquery.svg.package-1.5.0/jquery.svg.css" rel="stylesheet" />
    <script src="assets/js/jquery.svg.package-1.5.0/jquery.svg.js"></script>


    <style>
        #svgbasics { width: 800px; height: 500px; border: 1px solid #484; }
    </style>

    <script type="text/javascript">
        //Open page
        $(document).ready(function () {
            alert(1);


        });



       
    </script>


     
</head>
<body>

<%--    <desc>This graphic links to an external image</desc> 
<image x="100" y="50" width="200px" height="200px" 
    xlink:href="~/images/floor-plan-10.gif"> 
  <title>My image</title> 
</image> 
<image x="130" y="100" width="20px" height="20px" 
    xlink:href="~/images/Untitled_01.jpg"/>--%>
  <%--  <img id="floorplan" runat="server" alt="" src="~/images/floor-plan-10.gif" style="width: 800px; height: 500px" />--%>
    <div id="svgbasics"></div>

<%--<image x="130" y="100" width="20px" height="20px" 
    xlink:href="img/sun.png"/>--%>
<%--    <form id="form1" runat="server">
   <div class="center">
                                            <table style="width: 800px; height: 500px; border: none" border="0">
                                                <tr>

                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_01.jpg') no-repeat center;">
                                                        <img id="cell1" runat="server" alt="" src="~/images/Untitled_01.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_02.jpg') no-repeat center;">
                                                        <img id="cell2" runat="server" alt="" src="~/images/Untitled_02.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_03.jpg') no-repeat center;">
                                                        <img id="cell3" runat="server" alt="" src="~/images/Untitled_03.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_04.jpg') no-repeat center;">
                                                        <img id="cell4" runat="server" alt="" src="~/images/Untitled_04.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_05.jpg') no-repeat center;">
                                                        <img id="cell5" runat="server" alt="" src="~/images/Untitled_05.jpg" style="width: 160px; height: 100px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_06.jpg') no-repeat center;">
                                                        <img id="cell6" runat="server" alt="" src="~/images/Untitled_06.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_07.jpg') no-repeat center;">
                                                        <img id="cell7" runat="server" alt="" src="~/images/Untitled_07.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_08.jpg') no-repeat center;">
                                                        <img id="cell8" runat="server" alt="" src="~/images/Untitled_08.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_09.jpg') no-repeat center;">
                                                        <img id="cell9" runat="server" alt="" src="~/images/Untitled_09.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_10.jpg') no-repeat center;">
                                                        <img id="cell10" runat="server" alt="" src="~/images/Untitled_10.jpg" style="width: 160px; height: 100px" /></td>
                                                </tr>
                                                <tr>

                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_11.jpg') no-repeat center;">
                                                        <img id="cell11" runat="server" alt="" src="~/images/Untitled_11.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_12.jpg') no-repeat center;">
                                                        <img id="cell12" runat="server" alt="" src="~/images/Untitled_12.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_13.jpg') no-repeat center;">
                                                        <img id="cell13" runat="server" alt="" src="~/images/Untitled_13.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_14.jpg') no-repeat center;">
                                                        <img id="cell14" runat="server" alt="" src="~/images/Untitled_14.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_15.jpg') no-repeat center;">
                                                        <img id="cell15" runat="server" alt="" src="~/images/Untitled_15.jpg" style="width: 160px; height: 100px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_16.jpg') no-repeat center;">
                                                        <img id="cell16" runat="server" alt="" src="~/images/Untitled_16.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_17.jpg') no-repeat center;">
                                                        <img id="cell17" runat="server" alt="" src="~/images/Untitled_17.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_18.jpg') no-repeat center;">
                                                        <img id="cell18" runat="server" alt="" src="~/images/Untitled_18.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_19.jpg') no-repeat center;">
                                                        <img id="cell19" runat="server" alt="" src="~/images/Untitled_19.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_20.jpg') no-repeat center;">
                                                        <img id="cell20" runat="server" alt="" src="~/images/Untitled_20.jpg" style="width: 160px; height: 100px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_21.jpg') no-repeat center;">
                                                        <img id="cell21" runat="server" alt="" src="~/images/Untitled_21.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_22.jpg') no-repeat center;">
                                                        <img id="cell22" runat="server" alt="" src="~/images/Untitled_22.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_23.jpg') no-repeat center;">
                                                        <img id="cell23" runat="server" alt="" src="~/images/Untitled_23.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_24.jpg') no-repeat center;">
                                                        <img id="cell24" runat="server" alt="" src="~/images/Untitled_24.jpg" style="width: 160px; height: 100px" /></td>
                                                    <td style="width: 160px; height: 100px; align-content: center; background: url('images/Untitled_25.jpg') no-repeat center;">
                                                        <img id="cell25" runat="server" alt="" src="~/images/Untitled_25.jpg" style="width: 160px; height: 100px" /></td>
                                                </tr>
                                                <%--                  <tr>
                                        <td>17&nbsp;</td>
                                        <td>18&nbsp;</td>
                                        <td>19&nbsp;</td>
                                       <td>20&nbsp;</td>
                                    </tr>
                                                <tr>
                                        <td>21&nbsp;</td>
                                        <td>22&nbsp;</td>
                                        <td>24&nbsp;</td>
                                       <td>24&nbsp;</td>
                                    </tr>
                                            </table>
                                        </div>
    </form>--%>



      <%--<script type="text/javascript">


          //Open page
          $(document).ready(function () {
              alert($(1));
             // $('#svgbasics').svg({ onLoad: drawInitial });

              //setTimeout(function () {
              //    // Do something after 5 seconds
              //    alert(11111);
              //}, 5000);
            //  window.setInterval(yourfunction, 1000);

              
          });

          // function yourfunction() { alert('test'); }

          function drawInitial(svg) {
              alert(1);
              svg.describe('This graphic links to an external image');
              var img = svg.image(100, 50, 200, 200, 'mages/floor-plan-10.gif');
              svg.title(img, 'My image');
              svg.image(130, 100, 20, 20, 'images/Untitled_04.jpg');
          }

          //function drawInitial2(svg) {
          //    svg.circle(75, 75, 50, { fill: 'none', stroke: 'red', strokeWidth: 3 });
          //    var g = svg.group({ stroke: 'black', strokeWidth: 2 });
          //    svg.line(g, 15, 75, 135, 75);
          //    svg.line(g, 75, 15, 75, 135);
          //}

   </script>--%>


</body>
</html>
