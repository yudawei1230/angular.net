// JavaScript Document
function getCookie(name)
{
  var cookieValue = "";
  var search = name + "=";
  if(document.cookie.length > 0)
  {
    offset = document.cookie.indexOf(search);
    if (offset != -1)
    {	
      offset += search.length;
      end = document.cookie.indexOf(";", offset);
      if (end == -1) end = document.cookie.length;
      cookieValue = unescape(document.cookie.substring(offset, end))
    }
  }
  return cookieValue;
}

function setCookie(cookieName,cookieValue,DayValue)
{
	var expire = "";
	var day_value=1;
	if(DayValue!=null)
	{
		day_value=DayValue;
	}
    expire = new Date((new Date()).getTime() + day_value * 86400000);
    expire = "; expires=" + expire.toGMTString();
	document.cookie = cookieName + "=" + escape(cookieValue) +";path=/"+ expire;
}

function delCookie(cookieName)
{
	var expire = "";
    expire = new Date((new Date()).getTime() - 1 );
    expire = "; expires=" + expire.toGMTString();
	document.cookie = cookieName + "=" + escape("") +";path=/"+ expire;
}

function history_show(name) {
    var history_info = getCookie("history_info");
    var content = "";
    if (history_info != null) {
        history_arg = history_info.split("|");
        var i;
        for (i = 0; i <= 2; i++) {
            if (history_arg[i] != "null") {
                var wlink = history_arg[i].split("+");
                content += (wlink[0]);
            }
            document.getElementById("history").innerHTML = content;
        }
    }
    else {
        document.getElementById("history").innerHTML = "对不起，您没有任何浏览记录！";
    }
}