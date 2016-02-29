<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERPSellHouseClueAnalysisReport.aspx.cs" Inherits="highsunMobileOA.ERPSellHouseClueAnalysisReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>在售项目来访表</title>
    <script src='http://www.ichartjs.com/ichart.latest.min.js'></script>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <style>
        * {font-family: "Microoft YaHei","iconfont","FontAwesome"  !important;}
    </style>
        <script type="text/javascript">
            function forward(obj) {
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
                var projectNo = obj.id;
                var dateStart = yearStart + '-' + monthStart + '-' + dayStart;
                var dateEnd = yearEnd + '-' + monthEnd + '-' + dayEnd;
                URL = "ERPSellHouseClueAnalysisDetailReport.aspx?projectNo=" + projectNo + "&dateStart=" + dateStart + "&dateEnd=" + dateEnd;
                location.href = URL;
            }
    </script> 
        <script>
            function getobj(id) {
                return document.getElementById(id);
            }

            function list() {
                var date = new Date();
                var le1 = date.getFullYear() + 1 - 2015;
                addlist('yearStart', 2015, le1);
                addlist('monthStart', 1, 12);
                addlist('dayStart', 1, 31);
                addlist('yearEnd', 2015, le1);
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
            </script>



           <script type="text/javascript">
               $(document).ready(function () {              //日期焦点改变
                   $('#dayStart').add($('#dayEnd')).change(function () {
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
                       var dateStart = (yearStart.toString() + '-' + monthStart.toString() + '-' + dayStart.toString()).toString();
                       var dateEnd = (yearEnd.toString() + '-' + monthEnd.toString() + '-' + dayEnd.toString()).toString();
                       $.post('/json/PublicHandler.ashx?Method=SearchERPSellHouseClueAnalysisReport&dateStart=' + dateStart + '&dateEnd=' + dateEnd, function (item) {
                           var text = "";
                           var result = item[0];
                           var ProjectID = item[1];
                           var ProjectName = item[2];
                           var VistCount = item[3];
                           if (result.length != 0) {
                               for (var i = 0; i < result.length; i++) {
                                   text = text + result[i];
                               }
                               $("#dayreport").html(text);
                               $("#container").highcharts({
                                   chart: {
                                       type: 'bar'
                                   },
                                   title: {
                                       text: '<b>在售项目来访表</b>'
                                   },
                                   subtitle: {
                                       text: '时间:' + dateStart + dateEnd
                                   },
                                   xAxis: {
                                       categories: ProjectName,
                                       title: {
                                           text: null
                                       }
                                   },
                                   yAxis: {
                                       min: 0,
                                       title: {
                                           text: '总来访人数',
                                           align: 'high'
                                       },
                                       labels: {
                                           overflow: 'justify'
                                       }
                                   },
                                   tooltip: {
                                       valueSuffix: ' 人'
                                   },
                                   plotOptions: {
                                       bar: {
                                           dataLabels: {
                                               enabled: true
                                           }
                                       }
                                   },
                                   legend: {
                                       layout: 'vertical',
                                       align: 'right',
                                       verticalAlign: 'top',
                                       x: -40,
                                       y: 100,
                                       floating: true,
                                       borderWidth: 1,
                                       backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
                                       shadow: true
                                   },
                                   credits: {
                                       enabled: false
                                   },
                                   series: [{
                                       data: VistCount
                                   }]
                               });
                           }
                           else {
                               alert("无可用数据！");
                           }
                       }, "json");
                   });
               });

        </script>
</head>
<body >
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
            </div>
            <div data-role="content">
                <img id="loading" src="images/loading.gif" style="padding-left:120px; "/>
                <div class="ui-grid-d" id="dayreport"></div><br/>
                <div id="container" style="min-width:280px;height:300px"></div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>
        </div>
    </form>
    <script>
        list();
        febday();
        febdayEnd();
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
        var dateStart = yearStart + '-' + monthStart + '-' + dayStart;
        var dateEnd = yearEnd + '-' + monthEnd + '-' + dayEnd;
        $.post('/json/PublicHandler.ashx?Method=SearchERPSellHouseClueAnalysisReport&dateStart=' + dateStart + '&dateEnd=' + dateEnd, function (item) {
            var text = "";
            var result = item[0];
            var ProjectID = item[1];
            var ProjectName = item[2];
            var VistCount = item[3];
            if (result.length != 0) {
                for (var i = 0; i < result.length; i++) {
                    text = text + result[i];
                }
                $("#dayreport").html(text);
                $("#container").highcharts({
                    chart: {
                        type: 'bar'
                    },
                    title: {
                        text: '<b>在售项目来访表</b>'
                    },
                    subtitle: {
                        text: '时间:' + dateStart + dateEnd
                    },
                    xAxis: {
                        categories: ProjectName,
                        title: {
                            text: null
                        }
                    },
                    yAxis: {
                        min: 0,
                        title: {
                            text: '总来访人数',
                            align: 'high'
                        },
                        labels: {
                            overflow: 'justify'
                        }
                    },
                    tooltip: {
                        valueSuffix: ' 人'
                    },
                    plotOptions: {
                        bar: {
                            dataLabels: {
                                enabled: true
                            }
                        }
                    },
                    legend: {
                        layout: 'vertical',
                        align: 'right',
                        verticalAlign: 'top',
                        x: -40,
                        y: 100,
                        floating: true,
                        borderWidth: 1,
                        backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
                        shadow: true
                    },
                    credits: {
                        enabled: false
                    },
                    series: [{
                        data: VistCount
                    }]
                });
            }
            else {
                alert("无可用数据！");
            }
            var loading = document.getElementById("loading");
            loading.style.display = "none";
        }, "json");
    </script>
</body>
</html>

