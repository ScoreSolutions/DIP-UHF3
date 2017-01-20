<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Signage.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" media="screen">
        .fixed-nav-bar-top {
            position: fixed;
            top: 0;
            left: 0;
            z-index: 9999;
            width: 100%;
            height: 50px;
            background-color: #31999a;
        }

        .fixed-nav-bar-bottom {
            position: fixed;
            bottom: 0;
            left: 0;
            z-index: 9999;
            width: 100%;
            height: 40px;
            background-color: #31999a;
        }
        .marquee {
            width: 100%;
            height: 100%;
            overflow: hidden;
            border: 1px solid #ccc;
            font-size: xx-large;
        }
    </style>

    <link href="assets/bootstrap-3.3.4-dist/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="assets/bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" />

    <script src="assets/bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery-2.0.3.min.js"></script>
    <script src="assets/js/jQuery.Marquee/jquery.marquee.js"></script>
</head>
<body style="margin: 0px; padding: 0px; overflow: hidden">
    <iframe id="myframe" src="" frameborder="0" style="overflow: hidden; overflow-x: hidden; overflow-y: hidden; height: 100%; width: 100%; position: absolute; top: 0px; left: 0px; right: 0px; bottom: 0px"></iframe>
    <div class="fixed-nav-bar-bottom">
        <div class="marquee" id="divbottom" style="font-size:27px;"></div>
        <%--<span id="divbottomtxt" style="font-size:27px;"></span>--%>
    </div>
    <div style="display:none">
    <input id="txtIP" type="text" value="" runat="server" />
        <input id="txtValue" type="text" value="10,3,5,7" />
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            //SetGraphBar();
            LoadDataTempleteSchedule();
            LoadDataText();     
        });

        setInterval(function () {
            //SetGraphBar();
            LoadDataTempleteSchedule();
            LoadDataText();
        }
         , 60000);


        function LoadDataText() {
            var ipvalue = $('#' + '<%=txtIP.ClientID%>').val();
            var txtText = $("#txtText").val();
            var dataurl = 'WebService/WebService.asmx/GetTextScrolling';
            var param = "{'ip':" + JSON.stringify(ipvalue) + "}";

            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data" : param,
                "success": function (data) {
                    var strtemp = data.d;
                    if (strtemp.length) {
                        var arr = [];
                        var strval1;
                        var strval2;
                        arr = strtemp.split('|');
                        strval1 = arr[0];
                        strval2 = arr[1];
                        //alert(strval1);
                        //alert(strval2);
                        $("#divbottom").text(strval1);
                        $('#divbottom').marquee({
                            //speed in milliseconds of the marquee
                            duration: strval2,
                            //gap in pixels between the tickers
                            gap: 50,
                            //time in milliseconds before the marquee will start animating
                            delayBeforeStart: 0,
                            //'left' or 'right'
                            direction: 'left',
                            //true or false - should the marquee be duplicated to show an effect of continues flow
                            duplicated: false
                           
                        });
                      
                    }


                },
                error: function (xhr, status, error) {
                   // alert(xhr.responseText);
                }
            });
        }

        function LoadDataTempleteSchedule() {
            var ipvalue = $('#' + '<%=txtIP.ClientID%>').val();
            var dataurl = 'WebService/WebService.asmx/GetTempleteSchedule';
            var param = "{'ip':" + JSON.stringify(ipvalue) + "}";

            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "data": param,
                "success": function (data) {
                    var strtemp = data.d;
                    if (strtemp.length > 0) {
                            $("#myframe").attr('src', strtemp);
                    }

                },
                error: function (xhr, status, error) {
                   // alert(xhr.responseText);
                }
            });
        }

        //function getParameterByName(name) {
        //    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        //    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        //        results = regex.exec(location.search);
        //    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        //}

        //function LoadDataSpeed() {
        //    var tvid = 1;
        //    var txtSpeed = $("#txtSpeed").val();
        //    var dataurl = 'WebService/WebService.asmx/CheckTextSpeed';
        //    var param = "{'tvid':" + JSON.stringify(tvid)
        //                 + ",'oldtextspeed':" + JSON.stringify(txtSpeed)
        //                 + "}";

        //    $.ajax({
        //        "type": "POST",
        //        "dataType": 'json',
        //        "contentType": "application/json; charset=utf-8",
        //        "url": dataurl,
        //        "data": param,
        //        "success": function (data) {
        //            var strtemp = data.d;
        //            if (strtemp.length) {
        //                var arr = [];
        //                var strval1;
        //                var strval2;
        //                arr = strtemp.split(',');
        //                strval1 = arr[0];
        //                strval2 = arr[1];

                  
                            
        //                    $('#divbottom').marquee({
        //                        //speed in milliseconds of the marquee
        //                        duration: strval2,
        //                        //gap in pixels between the tickers
        //                        gap: 50,
        //                        //time in milliseconds before the marquee will start animating
        //                        delayBeforeStart: 0,
        //                        //'left' or 'right'
        //                        direction: 'left',
        //                        //true or false - should the marquee be duplicated to show an effect of continues flow
        //                        duplicated: false
        //                    });
                    
        //            }


        //        },
        //        error: function (xhr, status, error) {
        //            alert(xhr.responseText);
        //        }
        //    });
        //}


        //signage 4
        function SetGraphBar() {

            var dataurl = 'WebService/WebService.asmx/LoadDipBarChart';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": function (data) {
                    //var data = JSON.parse(data.d);
                    //localStorage['graphdata'] = data;
                    //alert(localStorage['graphdata']);
                    //var tempvalue = "100,200|150,50";
                    //var tempsplit = tempvalue.split('|');
                    //var data1 = tempsplit[0].split(',');
                    //var data2 = tempsplit[1].split(',');
                    //if (data1.length > 0) {//Check null value
                    //    var dataarr1 = [];
                    //    var dataarr2 = [];
                    //    // var colors = [];
                    //    for (var i = 0; i < data1.length; ++i) {
                    //        dataarr1.push(parseInt(data1[i]));//add value to array
                    //        dataarr2.push(parseInt(data2[i]));
                    //        // colors.push(color1[i]);
                    //    }
                    //}
                    //var datafull = [dataarr1, dataarr2];
                    //localStorage['graphdata'] = datafull;
                    //localStorage['graphdata'] = data.d;
                    $("#txtValue").val(data.d);
                },
                error: function (xhr, status, error) {

                }
            });
        }
    </script>

</body>
</html>
