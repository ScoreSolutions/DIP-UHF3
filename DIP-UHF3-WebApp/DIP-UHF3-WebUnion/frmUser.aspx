<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage2.master" AutoEventWireup="false" CodeFile="frmUser.aspx.vb" Inherits="frmUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content">
        <div class="breadcrumbs" id="breadcrumbs">
            <ul class="breadcrumb">
                <li>
                    <i class="icon-home home-icon"></i>
                    <a href="frmPortal.aspx">Home</a>

                    <span class="divider">
                        <i class="icon-angle-right arrow-icon"></i>
                    </span>
                </li>
                <li class="active">User</li>
            </ul>

        </div>

        <div class="page-content">


            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->
                    <h3 class="header smaller lighter blue">User</h3>

                    <div class="row-fluid">
                        <div class="span12" id="divbtnAdd">
                            <button class="btn btn-small btn-success" id="btnAdd" name="btnAdd">
                                <i class=" icon-plus"></i>
                                Add New
                            </button>
                            <button class="btn btn-small" id="btnBack" name="btnBack">
                                <i class=" icon-undo"></i>
                                Back
                            </button>

                        </div>
                    </div>
                    <div class="space-2"></div>
                    <div id="dialog-grid">
                        <div class="row-fluid">
                            <div class="span12">
                                <table class="table table-striped table-bordered table-hover" id="dt_out"></table>
                            </div>
                        </div>
                    </div>




                    <div id="dialog-edit">
                        <div class="row-fluid" style="display: none">
                            <div class="span2">
                                <label class="control-label" id="lblImage">User Image</label>
                            </div>
                            <div class="span7">
                                <div class="row-fluid">
                                    <div class="span4">
                                        <a href="images/No_image.gif" id="aimg" style="display: none;"></a>
                                        <%--				<a href="images/No_image.gif" rel="prettyPhoto"   id="aimg"><img   id="img" src="images/No_image.gif"  style="height: 150px; width: 200px;" /></a>--%>
                                        <img id="img" src="images/No_image.gif" style="height: 150px; width: 200px; cursor: pointer;" />
                                        <div id="dialog-image" style="display: none">
                                            <img id="imgPopup" src="images/No_image.gif" style="height: 350px; width: 500px;" />
                                        </div>


                                        <div id="base" style="display: none"></div>
                                        <div id="basepath" style="display: none"></div>
                                        <div id="basename"></div>

                                        <div class="space-2"></div>
                                        <span class="btn btn-default btn-mini btn-file">Browse&hellip; 
                                    <input type='file' id="roomimagefile" class="ace-file-input" />
                                        </span>
                                        <button class="btn btn-danger btn-mini" id="btnClearImage">
                                            Clear
                                        </button>

                                    </div>
                                    <div class="span4">
                                        <span class="help-inline" id="lblvalidfiletype">file type : gif,png,jpg,jpeg</span>
                                        <span class="help-inline" id="lblvalidfilesize">file type : size less than 1MB</span>
                                    </div>
                                    <div class="span4"></div>
                                </div>

                            </div>
                        </div>
                       

                        <div class="space-2"></div>
                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" for="lblPrefixName">Prefix Name</label>
                            </div>
                            <div class="span10">
                                <select id="cbTitle" data-placeholder="Choose a Prefix..." style="width:250px"></select>
                                <span class="help-inline color red" id="lblvalidtitle_id" style="display: none">This field is required</span>
                            </div>
                        </div>
                        <div class="space-2"></div>

                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" id="lblName">Name</label>
                            </div>
                            <div class="span10">
                                <input type="text" id="txtName" class="limited" data-maxlength="50" maxlength="50" style="width:238px">
                                <span class="help-inline color red" id="lblvalidName" style="display: none">This field is required</span>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" id="lblSurname">Surname</label>
                            </div>
                            <div class="span10">
                                <input type="text" id="txtSurname" class="limited" data-maxlength="50" maxlength="50" style="width:238px">
                                <span class="help-inline color red" id="lblvalidSurname" style="display: none">This field is required</span>
                            </div>
                        </div>
                        
                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" id="lblEmail">Email</label>
                            </div>
                            <div class="span10">
                                <input type="email" name="txtEmail" id="txtEmail" class="limited" data-maxlength="150" maxlength="50" style="width:238px" />
                                <span class="help-inline color red" id="lblValidEmail" style="display: none">This email is incorrect format</span>
                            </div>
                        </div>
                        <div class="space-2"></div>
                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" for="lblDepartment">Department</label>
                            </div>
                            <div class="span10">
                                <select  id="cbDepartment" data-placeholder="Choose a Department..." style="width:350px"></select>
                                <span class="help-inline color red" id="lblvalidms_department_id" style="display: none">This field is required</span>
                            </div>
                        </div>
                        <div class="space-2"></div>
                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" for="lblPosition">Position</label>
                            </div>
                            <div class="span10">
                                <select  id="cbPosition" data-placeholder="Choose a Position..." style="width:350px"></select>
                                <span class="help-inline color red" id="lblvalidms_position_id" style="display: none">This field is required</span>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" for="lblRole">Role&Responsibility</label>
                            </div>
                            <div class="span10">
                                <textarea id="txtRole" style="width: 338px; height: 60px; resize: none;" readonly="true"></textarea>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" for="lblWorkStation">Work Station</label>
                            </div>
                            <div class="span10">
                                 <input type="text" id="txtWorkStation" class="limited" style="width:338px" readonly="true">
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" for="lblFloor">Floor</label>
                            </div>
                            <div class="span10">
                                 <input type="text" id="txtFloor" class="limited" style="width:338px" readonly="true">
                            </div>
                            
                        </div>
                       <div class="row-fluid">
                           <div class="span2">
                                <label class="control-label" for="lblRoom">Room</label>
                            </div>
                            <div class="span10">
                                 <input type="text" id="txtRoom" class="limited" style="width:338px" readonly="true">
                            </div>
                        </div>

                        <div class="row-fluid">
                            <h3 class="header smaller lighter blue">Username and Password</h3>
                        </div>
                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" id="lblUsername">Username</label>
                            </div>
                            <div class="span10">
                                <input type="text" id="txtUsername" class="limited" data-maxlength="50" maxlength="50" >
                                <span class="help-inline color red" id="lblvalidUsername" style="display: none">This field is required</span>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" id="lblPassword">Password</label>
                            </div>
                            <div class="span10">
                                <input type="password" id="txtPassword" class="limited" data-maxlength="50" maxlength="50" >
                                <span class="help-inline color red" id="lblvalidPassword" style="display: none">This field is required</span>

                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span2">
                                <label class="control-label" id="lblConfirmPassword">Confirm Password</label>
                            </div>
                            <div class="span10">
                                <input type="password" id="txtConfirmPassword" class="limited" data-maxlength="50" maxlength="50" >
                                <span class="help-inline color red" id="lblvalidConfrimPassword" style="display: none">This field is required</span>
                                <span class="help-inline color red" id="lblvalidComprePassword" style="display: none">Password and Confirm Password does not match</span>

                            </div>
                        </div>


                        <div class="row-fluid">
                            <div class="span2">
                            </div>
                            <div class="span10">
                                <button class="btn btn-primary" id="btnSave" name="btnSave">
                                    <i class="icon-edit  bigger-110"></i>
                                    Save
                       
                                </button>
                                <button class="btn" type="reset" id="btnClear" name="btnClear">
                                    <i class="icon-undo bigger-110"></i>
                                    Clear
                                </button>
                            </div>
                        </div>
                    </div>

                </div>

            </div>


        </div>
    </div>

   
    <%-- //Keep Path input file--%>
    <input id="HiddenId" type="hidden" />
    <script type="text/javascript">
        //Open page
        $(document).ready(function () {
            var oTable;
            var isAddNew = false;
            LoadData();

            //Add Click
            $("#btnAdd").click(function () {
                onEdit(0);
                clickEdit();
            });

            $("#btnBack").click(function () {
                onEdit(0);
                clickEndEdit();
            });

            $("#btnClearImage").click(function () {
                $("roomimagefile").val("");
                clearImage();
            });

            $("#btnSave").click(function () {
                var ret = onValid();
                if (ret == true) {
                    onConfirmSave();
                }

            });

            $("#btnClear").click(function () {
                clearInput();
            });
        
            //Input file

            $("#roomimagefile").change(function () {
                readImage(this);
            });

            $("#img").click(function () {
                imagePopup();
            });

     

            //Hide div or other
            $("#dialog-edit").hide();
            $("#btnBack").hide();



        });


        //Call
        function LoadData() {
            var dataurl = 'WebService/WebService.asmx/LoadUserAll';
            $.ajax({
                "type": "POST",
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "url": dataurl,
                "success": PopulateGrid,
                "error": function () {
                    alert('load data error!');
                }
            });
        }

 
        //Populate Grid
        function PopulateGrid(jsondata) {
            var jsonobject = JSON.parse(jsondata.d);
            var columns = [
                            {
                                "sTitle": "No",
                                "sType": "numeric",
                                "mDataProp": "no",
                                "bSortable": false,
                                "bUseRendered": false

                            },
                           
                            {
                                "sTitle": "Name - Surname",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "fullname"

                            },
                            {
                                "sTitle": "Department",
                                "sType": "string",
                                "sDefaultContent": "",
                                "mDataProp": "department_name"

                            },
                           {
                               "sTitle": "Position",
                               "sType": "string",
                               "sDefaultContent": "",
                               "mDataProp": "position_name"

                           },

                            {
                                "sTitle": "Action",
                                "bSortable": false,
                                "fnRender": function (obj) {
                                    return '<div class="hidden-phone visible-desktop action-buttons">'
                                            + '<a href="#"  class="Green"  title="Edit" onClick="onEdit(' + obj.aData.id + ');clickEdit();  return false;">'
                                            + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                            + '</a>'
                                            + '&nbsp;'
                                            + '<a href="#"  class="Red"  title="Delete" onclick="onConfirmDelete(' + obj.aData.id + '); return false;" >'
                                            + '<span class="red"><i class="icon-trash bigger-130"></i></span>'
                                            + '</a>'
                                            + '</div>'
                                            + '<div class="hidden-desktop visible-phone">'
                                            + '			<div class="inline position-relative">'
                                            + '				<button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">'
                                            + '					<i class="icon-cog icon-only bigger-110"></i>'
                                            + '				</button>'
                                            + '				<ul class="dropdown-menu dropdown-icon-only dropdown-yellow pull-right dropdown-caret dropdown-close">'
                                            + ''
                                            + '					<li>'
                                            + '						<a href="#"   class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEdit(' + obj.aData.id + ');clickEdit(); return false;">'
                                            + '							<span class="green">'
                                            + '								<i class="icon-edit bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + '					<li>'
                                            + '						<a href="#"  class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onConfirmDelete(' + obj.aData.id + '); return false;">'
                                            + '							<span class="red">'
                                            + '								<i class="icon-trash bigger-120"></i>'
                                            + '							</span>'
                                            + '						</a>'
                                            + '					</li>'
                                            + '				</ul>'
                                            + '			</div>'
                                            + '		</div>'


                                    ;
                                },
                                "sDefaultContent": "",
                                "bUseRendered": false
                            }
            ];
            
            oTable = $('#dt_out').dataTable({
                "aaData": jsonobject,
                "bAutoWidth": false,
                "iDisplayLength": 100,
                "aoColumnDefs": [
                { "sWidth": "10%", "aTargets": [0] },
                { "sWidth": "30%", "aTargets": [1] },
                { "sWidth": "20%", "aTargets": [2] },
                { "sWidth": "20%", "aTargets": [3] },
                { "sWidth": "20%", "aTargets": [4] }
                
                ],
                "aoColumns": columns,
                "bDestroy": true,
            });


        }

        //Add or Edit 
        function clickEdit() {
            $("#btnAdd").hide();
            $("#btnBack").show();
            $("#dialog-grid").hide();
            $("#dialog-edit").show();
        }


        function clickEndEdit() {
            $("#btnAdd").show();
            $("#btnBack").hide();
            $("#dialog-grid").show();
            $("#dialog-edit").hide();
        }


        function onEdit(id) {
            onValidHide();
            $("#HiddenId").val(id);
            var param = "{'id':" + JSON.stringify(id) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/GetUserById",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);

                    if (strvalue.length == 1) {
                        $("#HiddenId").val(strvalue[0].id);
                        $("#txtName").val(strvalue[0].fname);
                        $("#txtSurname").val(strvalue[0].lname);
                        $("#txtEmail").val(strvalue[0].email);
                        $("#txtUsername").val(strvalue[0].username);
                        $("#txtPassword").val(strvalue[0].password);
                        $("#txtConfirmPassword").val(strvalue[0].password);                    
                        populateSelect(strvalue[0].id);
                       
                    } else {
                        $("#HiddenId").val(0);
                        $("#txtName").val("");
                        $("#txtSurname").val("");
                        $("#txtUsername").val("");
                        populateSelect(0);
                    }
                },
                error: function (data) {
                }
            });

            var param = "{'officer_id':" + JSON.stringify(id) + "}";
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/GetDesktopNameByOfficer",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = JSON.parse(data.d);
                    if (strvalue.length == 1) {
                        $("#txtWorkStation").val(strvalue[0].desk_name);
                        $("#txtFloor").val(strvalue[0].floor_name);
                        $("#txtRoom").val(strvalue[0].room_name);
                    } else {
                        $("#txtWorkStation").val("");
                        $("#txtFloor").val("");
                        $("#txtRoom").val("");
                    }
                },
                error: function (data) {
                }
            });

            var param = "{'officer_id':" + JSON.stringify(id) + "}";
            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/GetPermissionByOfficer",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var strvalue = data.d;
                    if (strvalue.length > 0) {
                        $("#txtRole").val(strvalue);
                    } else {
                        $("#txtRole").val("");
                    }
                },
                error: function (data) {
                }
            });

        }

        //Save 
        function onSave() {
            var id = $("#HiddenId").val();
            //var login_userid = $('#' + '<%=Master.FindControl("lblUserID").ClientID%>').text();
            var login_username = $('#' + '<%=Master.FindControl("lblUserName").ClientID%>').text();
            var title_id = $('#cbTitle').val();
            var name = $("#txtName").val();
            var surname = $("#txtSurname").val();
            var email = $("#txtEmail").val();
            var position_id = $("#cbPosition").val();
            var department_id = $("#cbDepartment").val();
            var username = $("#txtUsername").val();
            var password = $("#txtPassword").val();

            var param = "{'id':" + JSON.stringify(id)
                + ",'title_id':" + JSON.stringify(title_id)
                + ",'name':" + JSON.stringify(name)
                + ",'surname':" + JSON.stringify(surname)
                + ",'email' : " + JSON.stringify(email)
                + ",'department_id':" + JSON.stringify(department_id)
                + ",'position_id':" + JSON.stringify(position_id)
                + ",'username':" + JSON.stringify(username)
                + ",'password':" + JSON.stringify(password)
                + ",'login_username':" + JSON.stringify(login_username) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/SaveUser",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onUserSuccess,
                error: onFailed
            });
        }
        //Delete 
        function onDelete(id) {
            var param = "{'id':" + JSON.stringify(id) + "}";

            $.ajax({
                type: "POST",
                url: "WebService/WebService.asmx/DeleteUser",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onDeleteSuccess,
                error: onDeleteFailed
            });
        }

        //Confirm delete 
        function onConfirmDelete(id) {

            var msg = 'Please confirm the delete';
            var div = $("<div>" + msg + "</div>");
            div.dialog({
                title: "Confirm",
                modal: true,
                buttons: [
                            {
                                text: "Yes",
                                click: function () {
                                    div.dialog("close");
                                    onDelete(id);

                                }
                            },
                            {
                                text: "No",
                                click: function () {
                                    div.dialog("close");
                                }
                            }
                ]
            });



        }

        //Confirm save 
        function onConfirmSave() {

            var msg = 'Please confirm the save';
            var div = $("<div>" + msg + "</div>");
            div.dialog({
                title: "Confirm",
                modal: true,
                buttons: [
                            {
                                text: "Yes",
                                click: function () {
                                    div.dialog("close");
                                    onSave();

                                }
                            },
                            {
                                text: "No",
                                click: function () {
                                    div.dialog("close");
                                }
                            }
                ]
            });



        }

        //Room  Alert  True
        function onUserSuccess(result) {
            if (result.d == "YES") {
                onAlert("Save Complete");
                LoadData();
                clearInput();
                clickEndEdit();
            } else {
                if (result.d == "DUPLICATEUSERNAME") {
                    onAlert("Username already exists. Please modify username");
                    LoadData();
                }
                else if (result.d == "DUPLICATE") {
                    onAlert("Name and suranme already exists. Please modify Name or suranme");
                    LoadData();
                }
                else {
                    onAlert("Save Fail");
                }

            }

        }

        //Alert Save when false
        function onFailed() {
            onAlert("Save Fail");
        }

        //Alert Delete when true
        function onDeleteSuccess(result) {

            if (result.d == true) {
                onAlert("Delete Complete");
                LoadData();

            } else {
                onAlert("Delete Fail");
            }

        }

        //Alert Delete when false
        function onDeleteFailed() {
            onAlert("Delete Fail");
        }


        // Alert Box
        function onAlert(msg) {

            var div = $("<div>" + msg + "</div>");
            div.dialog({
                title: "Message",
                modal: true,
                buttons: [

                            {
                                text: "Ok",
                                click: function () {
                                    div.dialog("close");
                                }
                            }
                ]
            });

        }



        //Hide Valid
        function onValidHide() {
            $("#lblvalidtitle_id").hide();
            $("#lblvalidName").hide();
            $("#lblvalidSurname").hide();
            $("#lblValidEmail").hide();
            $("#lblvalidms_department_id").hide();
            $("#lblvalidms_position_id").hide();
            $("#lblvalidUsername").hide();
            $("#lblvalidPassword").hide();
            $("#lblvalidConfrimPassword").hide();
            $("#lblvalidComprePassword").hide();
 
        }

        //Validate email
        function validateEmail(sEmail) {
            var filter = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
            if (filter.test(sEmail)) {
                return true;
            }
            else {
                return false;
            }
        }

        //Check Valid
        function onValid() {

            var isValid;
            isValid = true;
            var title_id = $('#cbTitle').val();
            var name = $("#txtName").val();
            var surname = $("#txtSurname").val();
            var email = $("#txtEmail").val();
            var position_id = $("#cbPosition").val();
            var department_id = $("#cbDepartment").val();
            var username = $("#txtUsername").val();
            var password = $("#txtPassword").val();
            var passwordconfirm = $("#txtConfirmPassword").val();

            if (title_id == '') {
                $("#lblvalidtitle_id").show();
                isValid = false;
            } else {
                $("#lblvalidtitle_id").hide();
            }
           
            if (name == '') {
                $("#lblvalidName").show();
                isValid = false;
            } else {
                $("#lblvalidName").hide();

            }

            if (surname == '') {
                $("#lblvalidSurname").show();
                isValid = false;
            } else {
                $("#lblvalidSurname").hide();
            }

            if (email != '') {
                if (validateEmail(email)==false){
                    $("#lblValidEmail").show();
                    isValid = false;
                }else{
                    $("#lblValidEmail").hide();
                }
            } else {
                $("#lblValidEmail").hide();
            }

            if (department_id == '') {
                $("#lblvalidms_department_id").show();
                isValid = false;
            } else {
                $("#lblvalidms_department_id").hide();
            }

            if (position_id == '') {
                $("#lblvalidms_position_id").show();
                isValid = false;
            } else {
                $("#lblvalidms_position_id").hide();
            }

            if (username == '') {
                $("#lblvalidUsername").show();
                isValid = false;
            } else {
                $("#lblvalidUsername").hide();
            }

            if (password == '') {
                $("#lblvalidPassword").show();
                isValid = false;
            } else {
                $("#lblvalidPassword").hide();
            }

            //if (passwordconfirm == '') {
            //    $("#lblvalidConfrimPassword").show();
            //    isValid = false;
            //} else {
            //    $("#lblvalidConfrimPassword").hide();
            //}

            if (password != passwordconfirm) {
                $("#lblvalidComprePassword").show();
                isValid = false;
            } else {
                $("#lblvalidComprePassword").hide();
            }
            
            return isValid;
        }
       

        function clearInput() {
            $("#txtName").val("");
            $("#txtSurname").val("");
            $("#txtUsername").val("");
            $("#txtPassword").val("");
            $("#txtConfirmPassword").val("");

            $("#txtRole").val("");
            $("#txtWorkStation").val("");
            $("#txtFloor").val("");
            $("#txtRoom").val("");
            populateSelect(0);
        }

        //Populate Option 
        function populateSelect(user_id) {
            var strselect;
            var param = "{'user_id':" + JSON.stringify(user_id) + "}";

            //Populate Check Select
            $select = $("#cbTitle");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadTitleByUser',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $select.html('');
                    $select.append('<option value="">Choose a Title</option>');
                    $select.trigger("chosen:updated");
                    //append a select option
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (val.selected != "") {
                            strselect = ' selected="' + val.selected + '"';
                        }

                        $select.append('<option value="' + val.id + '" ' + strselect + '>' + val.title_name + '</option>');
                        $select.trigger("chosen:updated");//update select option
                    })

                    $select.chosen();
                }
            });

            $selectPosition = $("#cbPosition");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadPositionByUser',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectPosition.html('');
                    $selectPosition.append('<option value="">Choose a Position</option>');
                    $selectPosition.trigger("chosen:updated");
                    //append a select option
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (val.selected != "") {
                            strselect = ' selected="' + val.selected + '"';
                        }
                        $selectPosition.append('<option value="' + val.id + '" ' + strselect + '>' + val.position_name + '</option>');
                        $selectPosition.trigger("chosen:updated");//update select option
                    })

                    $selectPosition.chosen();
                }
            });

            $selectDepartment = $("#cbDepartment");
            $.ajax({
                type: "POST",
                url: 'WebService/WebService.asmx/LoadDepartmentByUser',
                data: param,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobject = JSON.parse(data.d);
                    //clear 
                    $selectDepartment.html('');
                    $selectDepartment.append('<option value="">Choose a Department</option>');
                    $selectDepartment.trigger("chosen:updated");
                    //append a select option
                    $.each(jsonobject, function (key, val) {
                        strselect = '';
                        if (val.selected != "") {
                            strselect = ' selected="' + val.selected + '"';
                        }
                        $selectDepartment.append('<option value="' + val.id + '" ' + strselect + '>' + val.department_name + '</option>');
                        $selectDepartment.trigger("chosen:updated");//update select option
                    })

                    $selectDepartment.chosen();

                }
            });


        }



    </script>
</asp:Content>

