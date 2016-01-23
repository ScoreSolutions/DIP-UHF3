/*
Javascript jscAutoComplete control
version 1.0
AdvanceByDesign.com

Copyright (C) 2011 Robert Rook
Released under the terms of the
ABD Free Source Code Licence
*/
ac_LIST_LENGTH = 0;
ac_DRAWN = false;
ac_LIST_MAX = 10;
ac_VISIBLE = false;
ac_TIMER = null;

function acAutoComplete(objID,e,aACList) {
	if(!e) { e = window.event; }
	tval = GetOBJ(objID).value;
	block = "[]{}().|?!$^*+=/\\";
	for(i=0;i<block.length;i++) {
		if(tval.indexOf(block.substr(i,1))!=-1) { acHide(); return; } }

	if(!ac_DRAWN) {
		document.body.innerHTML+= "<div id=\"auto_list\"></div>";
		window.setTimeout('GetOBJ("'+objID+'").focus(); GetOBJ("'+objID+'").value="'+tval+'";',100);
		ac_DRAWN = true;
	}

	if(tval.length<1) { acHide(); return; }

	if(e.keyCode==38 && ac_LIST_LENGTH) {
		GetOBJ("idac_opt"+ac_LIST_LENGTH).focus();
		return;
	} else if(e.keyCode==40 && ac_LIST_LENGTH) {
		GetOBJ("idac_opt1").focus();
		return;
	}
	
	alist = GetOBJ("auto_list");
	outHTML = "";

	ac_LIST_LENGTH = 0;

	treg = new RegExp(tval,"i");
	
	for(i=0;i<aACList.length;i++) {
		if(aACList[i].match(treg)!=null) {
			ac_LIST_LENGTH++;
			tmod = aACList[i];
			thtm = "<a href=\"#\" onmousedown=\"acSetValue('";
			thtm+= objID+"','"+tmod+"'); return false;\" ";
			thtm+= "id=\"idac_opt"+ac_LIST_LENGTH+"\" ";
			thtm+= "onfocus=\"window.clearTimeout(ac_TIMER);\" ";
			thtm+= "onblur=\"acDelayHide();\" ";
			thtm+= "onkeydown=\"if(event.keyCode==13){acSetValue('"+objID+"', '"+tmod+"');}";
			thtm+= "else{acMoveFocus("+ac_LIST_LENGTH+",event.keyCode);}\">";
			thtm+= tmod.substr(0,tmod.search(treg)) + "<span class=\"ac_match\">";
			thtm+= aACList[i].match(treg)[0] + "</span>";
			thtm+= tmod.substr((tmod.search(treg)+tval.length),tmod.length);
			outHTML+= thtm+"</a>";
			if(ac_LIST_MAX && ac_LIST_LENGTH>=ac_LIST_MAX) { break; }
		}
	}

	if(!ac_VISIBLE && ac_LIST_LENGTH) {
		ac_VISIBLE = true;
		alist.style.display = "block";
		tmp = GetPOS(GetOBJ(objID));

		alist.style.left = tmp['x']+"px";
		alist.style.top = (tmp['y']+tmp['h'])+"px";
	}

	if(!ac_LIST_LENGTH) { acHide(); }
	
	alist.innerHTML = outHTML;
	
	return;
}
function acMoveFocus(objIdx,keyCode) {
	if(keyCode==38) {
		if(objIdx==1) { GetOBJ("idac_opt"+ac_LIST_LENGTH).focus(); }
		else { GetOBJ("idac_opt"+(objIdx-1)).focus(); }
	}
	else if(keyCode==40) {
		if(objIdx==ac_LIST_LENGTH) { GetOBJ("idac_opt1").focus(); }
		else { GetOBJ("idac_opt"+(objIdx+1)).focus(); }
	}
	return;
}
function acDelayHide() {
	ac_TIMER = window.setTimeout('acHide();',80);
}
function acHide() {
	GetOBJ("auto_list").style.display = "none";
	ac_VISIBLE = false;
}
function acSetValue(objID,szValue) {
	GetOBJ(objID).value = szValue;
	acHide();
	return;
}

if(typeof GetOBJ!='function') {
	function GetOBJ(objID) {
		if(document.getElementById) {
			return document.getElementById(objID);
		} else if(document.all) {
			return document.all[objID];
		}
		return null;
	}
}
if(typeof GetPOS!='function') {
	function GetPOS(obj) {
		pos = new Array();
		pos['x'] = 0;
		pos['y'] = 0;
		pos['w'] = obj.offsetWidth;
		pos['h'] = obj.offsetHeight;

		tmpOBJ = obj;

		do {
			pos['x']+= tmpOBJ.offsetLeft;
			pos['y']+= tmpOBJ.offsetTop;
		} while (tmpOBJ = tmpOBJ.offsetParent);

		return pos;
	}
}