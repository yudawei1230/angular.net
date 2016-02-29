﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndustrialMaterialPrices.aspx.cs" Inherits="highsunMobileOA.IndustrialMaterialPrices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>工业物料价格报表</title>
    <script src='http://www.ichartjs.com/ichart.latest.min.js'></script>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <script src="js/jquery.fullPage.js"></script>
    <style>
        li {
            text-decoration: none;
            display: block;
            border: 1px solid #000;
            border-bottom: 0.5px solid #000;
            list-style: none;
            cursor: pointer;
            padding: 0px;
            margin: 0px;
        }

        ul {
            border-bottom: 1px solid #000;
            display: block;
            list-style: none;
            margin: 0px;
            padding: 0px;
        }

        #txtCode {
            padding: 0px;
            margin: 0px;
        }

        #divShowText {
            height:200px;
            width:100%;
            overflow:scroll;
            display:none;
            z-index:9999;
            position: relative;
        }
        .sureButton {
            -moz-box-shadow:inset 0px 1px 0px 0px #bbdaf7;
            -webkit-box-shadow:inset 0px 1px 0px 0px #bbdaf7;
            box-shadow:inset 0px 1px 0px 0px #bbdaf7;
            background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #79bbff), color-stop(1, #378de5));
            background:-moz-linear-gradient(top, #79bbff 5%, #378de5 100%);
            background:-webkit-linear-gradient(top, #79bbff 5%, #378de5 100%);
            background:-o-linear-gradient(top, #79bbff 5%, #378de5 100%);
            background:-ms-linear-gradient(top, #79bbff 5%, #378de5 100%);
            background:linear-gradient(to bottom, #79bbff 5%, #378de5 100%);
            filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#79bbff', endColorstr='#378de5',GradientType=0);
            background-color:#79bbff;
            -moz-border-radius:6px;
            -webkit-border-radius:6px;
            border-radius:6px;
            border:1px solid #84bbf3;
            display:inline-block;
            cursor:pointer;
            color:#ffffff;
            font-family:Arial;
            font-size:16px;
            font-weight:bold;
            padding:14px 8px;
            text-align:center;
            text-decoration:none;
            text-shadow:0px 1px 0px #528ecc;
        }
        .sureButton:hover {
            background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #378de5), color-stop(1, #79bbff));
            background:-moz-linear-gradient(top, #378de5 5%, #79bbff 100%);
            background:-webkit-linear-gradient(top, #378de5 5%, #79bbff 100%);
            background:-o-linear-gradient(top, #378de5 5%, #79bbff 100%);
            background:-ms-linear-gradient(top, #378de5 5%, #79bbff 100%);
            background:linear-gradient(to bottom, #378de5 5%, #79bbff 100%);
            filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#378de5', endColorstr='#79bbff',GradientType=0);
            background-color:#378de5;
        }
        .sureButton:active {
            position:relative;
            top:1px;
        }
        #report {
            font-size:10px;
        }


        .ui-field-contain div.ui-input-text {
            width: 100%;
            display: inline-block;
        }
        #searchtypeDiv .ui-select {
            width:100%; 
        }

    </style>
    <script>
        function getobj(id) {
            return document.getElementById(id);
        }

        function list() {
            var date = new Date();
            var le1 = date.getFullYear() + 1 - 2000;
            addlist('yearStart', 2000, le1);
            addlist('monthStart', 1, 12);
            addlist('dayStart', 1, 31);
            addlist('yearEnd', 2000, le1);
            addlist('monthEnd', 1, 12);
            addlist('dayEnd', 1, 31);

        }

        function febday() {//判断不同的情况下二月的天数，并更改日的列表项中的内容
            var year = getobj('yearStart').value;
            var month = getobj('monthStart').value;
            var bigm = new Array('1', '3', '5', '7', '8', '10', '12');
            var bigstr = bigm.join('-');
            var smallm = new Array('4', '6', '9', '10');
            var smallstr = smallm.join('-');
            if (bigstr.indexOf(month) > -1)
                addlist('dayStart', 1, 31);
            if (smallstr.indexOf(month) > -1)
                day(30);
            if (month == '2') {
                if (isRui(year)) {
                    day(29);
                } else {
                    day(28);
                }
            }
            function day(num) {//改变二月的天数
                var list = getobj('dayStart');
                var listlen = list.options.length;
                for (var i = listlen - 1; i >= num; i--) {
                    list.options[i] = null;
                }
            }
        }
        function febdayEnd() {//判断不同的情况下二月的天数，并更改日的列表项中的内容
            var year = getobj('yearEnd').value;
            var month = getobj('monthEnd').value;
            var bigm = new Array('1', '3', '5', '7', '8', '10', '12');
            var bigstr = bigm.join('-');
            var smallm = new Array('4', '6', '9', '10');
            var smallstr = smallm.join('-');
            if (bigstr.indexOf(month) > -1)
                addlist('dayEnd', 1, 31);
            if (smallstr.indexOf(month) > -1)
                dayEnd(30);
            if (month == '2') {
                if (isRui(year)) {
                    dayEnd(29);
                } else {
                    dayEnd(28);
                }
            }
            function dayEnd(num) {//改变二月的天数
                var list = getobj('dayEnd');
                var listlen = list.options.length;
                for (var i = listlen - 1; i >= num; i--) {
                    list.options[i] = null;
                }
            }
        }

        function isRui(year) {//是否是闰年
            if ((year % 400 == 0) || (year % 4 == 0 && year / 100 != 0))
                return true;
            return false;

        }

        function addlist(obj, begin, length) {//为列表项中批量添加项目
            var list = getobj(obj);
            for (var i = 0; i < length; i++) {
                var num = i + begin;
                list.options[i] = new Option(num, num);
            }
        }

        $(document).ready(function () {              //日期焦点改变
            $('#dayStart').add('#yearStart').add('#monthStart').add('#dayEnd').add('#yearEnd').add('#monthEnd').change(function () {
                var yearStart = $('#yearStart').val();
                var monthStart = $('#monthStart').val();
                var dayStart = $('#dayStart').val();
                var yearEnd = $('#yearEnd').val();
                var monthEnd = $('#monthEnd').val();
                var dayEnd = $('#dayEnd').val();
                if (monthStart < 10) {
                    monthStart = "0" + monthStart;
                }
                if (dayStart < 10) {
                    dayStart = "0" + dayStart;
                }
                if (monthEnd < 10) {
                    monthEnd = "0" + monthEnd;
                }
                if (dayEnd < 10) {
                    dayEnd = "0" + dayEnd;
                }
                dateStart = (yearStart.toString() + '-' + monthStart.toString() + '-' + dayStart.toString()).toString();
                dateEnd = (yearEnd.toString() + '-' + monthEnd.toString() + '-' + dayEnd.toString()).toString();
            });
        });




        $(document).ready(function () {
            //li点击时，将文本框内容改为li的内容

            $("li").live("click", function () {
                var materialNumber = $(this).attr("name");
                $("#materialNumber").val(materialNumber);
                $("#txtCode").val($(this).text().split("(")[0]);
                $("#divShowText").hide();
                checkMaterial(materialNumber);
            })
            $("li").live({
                mouseenter: function () {
                    $(this).css("background-color", "#39C0FA");//移入事件
                },
                mouseleave: function () {
                    $(this).css("background-color", "white");//移出事件
                }
            });
            $("body").bind("click", function () {       //区域外点击，冒泡
                $("#divShowText").hide();
            })

            $("#txtCode").focus(function () {
                if ($("#txtCode").val().length != 0) { SelectTip(); }
            });
        });

        function sureButtonDown() {
            if ($("#searchtype").val() == 1) {
                checkMaterial($("#txtCode").val());
            } else if ($("#searchtype").val() == 2) {
                SelectTip();
            } else if ($("#searchtype").val() == 3) {
                SelectTip();
            }

        }

        function checkMaterial(materialNumber) {
            $.post('/json/PublicHandler.ashx?Method=SearchMaterialPriceAndOutputAnylysisTrend&materialNumber=' + materialNumber + "&dateStart=" + dateStart + "&dateEnd=" + dateEnd, function (item) {
                var result = item[0];
                var Fnumber = item[1];
                var FmaterialName = item[2];
                var Fmodel = (item[3]);
                var PurchasingTime = (item[4]);
                var PurchasingAmount = item[5];
                var PurchasingPrice = (item[6]);
                var AvgPrice = (item[7]);
                var priceArr = [];
                for (var i = 0; i < AvgPrice.length; i++) {
                    priceArr.push(AvgPrice[i]);
                }
                var text = "";
                if (result.length != 0) {
                    for (var i = 0; i < result.length; i++) {
                        text = text + result[i];
                    }
                    $("#report").html(text);
                    $('#container').highcharts({
                        title: {
                            text: '<b>工业物料价格走势图</b>'
                        },
                        subtitle: {
                            text: "",
                            x: -20
                        },
                        xAxis: {
                            categories: PurchasingTime
                        },
                        yAxis: {
                            title: {
                                text: '元'
                            }
                        },
                        series: [{
                            name: FmaterialName[0],
                            data: AvgPrice,
                        }]
                    });
                }
                else {
                    alert("无可用数据！");
                    $("#report").html("");
                    $("#container").hide();
                }

            }, "json");
        }




</script>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="fieldcontain">
                <fieldset data-role="controlgroup" data-type="horizontal">
                    <label for="yearStart">选择年份：</label>
                    <select name="year" id="yearStart" class="year" onchange="febday();">
                    </select>
                    <label for="monthStart">选择月份：</label>
                    <select name="month" id="monthStart" class="month" onchange="febday();">
                    </select>
                    <label for="dayStart">选择日期：</label>
                    <select name="day" id="dayStart" class="day">
                    </select>
                </fieldset>
                <fieldset data-role="controlgroup" data-type="horizontal">
                    <label for="yearEnd">选择年份：</label>
                    <select name="year" id="yearEnd" class="year" onchange="febdayEnd();">
                    </select>
                    <label for="monthEnd">选择月份：</label>
                    <select name="month" id="monthEnd" class="month" onchange="febdayEnd();">
                    </select>
                    <label for="dayEnd">选择日期：</label>
                    <select name="day" id="dayEnd" class="day">
                    </select>
                </fieldset>

                

                <div id="searchtypeDiv" style="width:35%;float:left;margin-top:5px">
                    <select  name="searchtype" id="searchtype" style="width: 100%;display: inline-block" >                        
                        <option value="1">编号</option>
                        <option value="2" selected>名称</option>
                        <option value="3">规格</option>
                    </select>
                </div>
                <div  style="float:left;width:40%;margin-top:5px" >
                    <input type="text" ID="txtCode"  onkeyup="SelectTip()"  style="width:100%;display: inline-block;width:148px;height:40px" > 
                    <div id="divShowText" > </div>
                </div>
                <div style="float:left;width:25%;margin-top:5px"><a href="#" onclick="sureButtonDown()" style="margin-top:0px;"  data-role="button" >确定</a><div id="materialNumber" style="display:none"></div></div>
                <div class="ui-grid-d" id="report" style="clear:both;margin-top:50px"></div><br/>
                <div id="container"></div>
            </div>
        </div>
    </form>
    <script>
        list();
        var d = new Date();
        var vYear = d.getFullYear();
        var vMon = d.getMonth() + 1;
        var vDay = d.getDate();
        $('#yearStart').val(vYear);
        $('#monthStart').val(vMon);
        $('#dayStart').val(vDay);
        $('#yearEnd').val(vYear);
        $('#monthEnd').val(vMon);
        $('#dayEnd').val(vDay);
        var yearStart = $('#yearStart').val();
        var monthStart = $('#monthStart').val();
        var dayStart = $('#dayStart').val();
        var yearEnd = $('#yearEnd').val();
        var monthEnd = $('#monthEnd').val();
        var dayEnd = $('#dayEnd').val();
        var dateStart = yearStart + '-' + monthStart + '-' + dayStart;
        var dateEnd = yearEnd + '-' + monthEnd + '-' + dayEnd;


        function SelectTip() {
            var temp = $("#txtCode").val();
            if (($("#searchtype").val() == 1) && (temp.length >= 8)) {
                $.post('/json/PublicHandler.ashx?Method=SearchMaterialInfomationsByFnumber&prjFnumber=' + temp, function (item) {
                    var result = item[0];
                    var Fnumber = item[1];
                    var FmaterialName = item[2];
                    var Fmodel = item[3];
                    $(divShowText).html("");
                    var html = "<ul>";
                    for (var i = 0; i < Fnumber.length ; i++) {
                        html += "<li name=\"" + Fnumber[i] + "\">" + Fnumber[i] + "(" + FmaterialName[i] + ")" + "</li>";
                    }
                    html += "</ul>";
                    $('#divShowText').html("");
                    $('#divShowText').html(html);
                    if (html !== "<ul></ul>") {
                        $("#divShowText").show();
                    }
                }, "json");
            } else if (($("#searchtype").val() == 2) && (temp.length != 0)) {
                $.post('/json/PublicHandler.ashx?Method=SearchMaterialInfomationsByName&prjName=' + temp, function (item) {
                    var result = item[0];
                    var Fnumber = item[1];
                    var FmaterialName = item[2];
                    var Fmodel = item[3];
                    $(divShowText).html("");
                    var html = "<ul>";
                    for (var i = 0; i < Fnumber.length ; i++) {
                        html += "<li name=\"" + Fnumber[i] + "\">" + FmaterialName[i] + "(" + Fnumber[i] + ")" + "</li>";
                    }
                    html += "</ul>";
                    $('#divShowText').html("");
                    $('#divShowText').html(html);
                    if (html !== "<ul></ul>") {
                        $("#divShowText").show();
                    }
                }, "json");
            } else if ($("#searchtype").val() == 3) {
                $.post('/json/PublicHandler.ashx?Method=SearchMaterialInfomationsByFmodel&prjModel=' + temp, function (item) {
                    var result = item[0];
                    var Fnumber = item[1];
                    var FmaterialName = item[2];
                    var Fmodel = item[3];
                    $(divShowText).html("");
                    var html = "<ul>";
                    for (var i = 0; i < Fnumber.length ; i++) {
                        html += "<li name=\"" + Fnumber[i] + "\">" + Fmodel[i] + "(" + FmaterialName[i] + ")" + "</li>";
                    }
                    html += "</ul>";
                    $('#divShowText').html("");
                    $('#divShowText').html(html);
                    if (html !== "<ul></ul>") {
                        $("#divShowText").show();
                    }
                }, "json");
            }
        }


    </script>
</body>
</html>