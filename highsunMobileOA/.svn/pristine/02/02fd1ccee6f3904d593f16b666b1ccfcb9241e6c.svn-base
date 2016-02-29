<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERPSellHouseClueDayReport.aspx.cs" Inherits="highsunMobileOA.ERPSellHouseClueDayReport" %>

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
                var year = $('#year').val();
                var month = $('#month').val();
                var day = $('#day').val();
                if (month < 10) {
                    month = "0" + month;
                }
                if (day < 10) {
                    day = "0" + day;
                }
                var projectNo = obj.id;
                var date = year + '-' + month + '-' + day;
                URL = "ERPSellHouseClueDetailDayReport.aspx?projectNo=" + projectNo + "&date=" + date;
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
                addlist('year', 2015, le1);
                addlist('month', 1, 12);
                addlist('day', 1, 31);
            }

            function febday() {//判断不同的情况下二月的天数，并更改日的列表项中的内容
                var year = getobj('year').value;
                var month = getobj('month').value;
                var bigm = new Array('1', '3', '5', '7', '8', '10', '12');
                var bigstr = bigm.join('-');
                var smallm = new Array('4', '6', '9', '10');
                var smallstr = smallm.join('-');
                if (bigstr.indexOf(month) > -1)
                    addlist('day', 1, 31);
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
                    var list = getobj('day');
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
                   $('#day').change(function () {
                       var year = $('#year').val();
                       var month = $('#month').val();
                       var day = $('#day').val();
                       if (month < 10) {
                           month = "0" + month;
                       }
                       if (day < 10) {
                           day = "0" + day;
                       }
                       var date = (year.toString() + '-' + month.toString() + '-' + day.toString()).toString();
                       $.post('/json/PublicHandler.ashx?Method=SerachERPSellHouseClueDayReport&date=' + date, function (item) {
                           var text = "";
                           var result = item[0];
                           var ProjectID = item[1];
                           var ProjectName = item[2];
                           var VisitTimes = item[3];
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
                                       text: '时间:' + date
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
                                   credits: {
                                       enabled: false
                                   },
                                   series: [{
                                       name: "来访次数",
                                       data: VisitTimes
                                   }]
                               });
                           }
                           else {
                               alert("无可用数据！");
                           }
                           var loading = document.getElementById("loading");
                           loading.style.display = "none";
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
                    <label for="year">选择年份：</label>
                    <select name="year" id="year" class="year" onchange="febday();">
                    </select>
                    <label for="month">选择月份：</label>
                    <select name="month" id="month" class="month" onchange="febday();">
                    </select>
                    <label for="day">选择日期：</label>
                    <select name="day" id="day" class="day">
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
        var d = new Date();
        var vYear = d.getFullYear();
        var vMon = d.getMonth() + 1;
        var vDay = d.getDate();
        $('#year').val(vYear);
        $('#month').val(vMon);
        $('#day').val(vDay);
        var year = $('#year').val();
        var month = $('#month').val();
        var day = $('#day').val();
        if (month < 10) {
            month = "0" + month;
        }
        if (day < 10) {
            day = "0" + day;
        }
        var date = year + '-' + month + '-' + day;
        var URL = location.href;
        if (URL.indexOf("redoDate") > -1) {             //判断，如果是返回，则把返回的redoDate覆盖date，并改变select
            var redoDate = URL.split("=")[1];
            date = redoDate;
            var redoYear = URL.split("=")[1].split("-")[0];
            var redoMonth = URL.split("=")[1].split("-")[1];
            var redoDay = URL.split("=")[1].split("-")[2];
            $('#year').val(redoYear);
            if (redoMonth < 10) {
                redoMonth = redoMonth.substring(1, 2);
            };
            if (redoDay < 10) {
                redoDay = redoDay.substring(1, 2);
            };
            $('#month').val(redoMonth);
            $('#day').val(redoDay);
        }
        $.post('/json/PublicHandler.ashx?Method=SerachERPSellHouseClueDayReport&date=' + date, function (item) {
            var text = "";
            var result = item[0];
            var ProjectID = item[1];
            var ProjectName = item[2];
            var VisitTimes = item[3];
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
                        text: '时间:' + date
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
                    credits: {
                        enabled: false
                    },
                    series: [{
                        name: "来访次数",
                        data: VisitTimes
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

