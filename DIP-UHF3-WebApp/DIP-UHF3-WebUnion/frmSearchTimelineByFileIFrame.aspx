<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSearchTimelineByFileIFrame.aspx.vb" Inherits="frmSearchTimelineByFileIFrame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <link href="assets/js/vertical-timeline/css/reset.css" rel="stylesheet" />
    <link href="assets/js/vertical-timeline/css/style.css" rel="stylesheet" />
    <script src="assets/js/vertical-timeline/js/modernizr.js"></script>

  	
	<title>Responsive Vertical Timeline</title>
</head>
<body>
  <div id="showtimeline">

  </div>
    <script src="assets/js/jquery-2.0.3.min.js"></script>
    <script src="assets/js/vertical-timeline/js/main.js"></script>
    <script type="text/javascript">
        //Open page
        $(document).ready(function () {
            LoadData();
        });

        //Call
        function LoadData() {
            var datefrom = localStorage['datefrom'];
            var dateto = localStorage['dateto'];
            var patenttype = localStorage['patenttype'];
          //  var app_no = localStorage['appnodatatimeline']; //'0201001501';//$("#txtApp_no").val();
            var param = "{'patenttype':" + JSON.stringify(patenttype)
                        + ",'datefrom':" + JSON.stringify(datefrom)
                        + ",'dateto':" + JSON.stringify(dateto)  + '}';
            $selectCondition = $("#showtimeline");
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/LoadSearchFileStatus_ByTime_Type2",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#showtimeline").html(data.d);
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });

        }


    </script>


</body>
</html>
