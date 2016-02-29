<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="canyinReport.aspx.cs" Inherits="highsunMobileOA.canyinReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
   <title>餐饮销售日报表</title>
    <script src='http://www.ichartjs.com/ichart.latest.min.js'></script>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#day').change(function () {
                var vYear = $('#year').val();
                var vMon = $('#month').val();
                var vDay = $('#day').val();

                if (vMon < 10) {
                    vMon = "0" + vMon;
                }

                if (vDay < 10) {
                    vDay = "0" + vDay;
                }
                $.post('/json/PublicHandler.ashx?Method=SearchCanyinReportByDate&date=' + $('#year').val() +
                '-' + vMon + '-' + vDay, function (result) {

                    $("#dayreport").html(result.msg);

                }, "json");

                $.post('/json/PublicHandler.ashx?Method=SearchCanyinChartByDate&date=' + vYear + '-' + vMon + '-' + vDay, function (item) {
                    var shop = item[0];
                    var sale = item[1];;
                    var shopchart = [];
                    var saleschart = [];
                    var dataTmp = "{";

                    for (var i = 0; i < (shop.length / 31) ; i++) {
                        // shopchart[i] = shop[i];                       
                        dataTmp += "\"item" + i + "\":{\"name\": \"" + shop[i] + "\",\"sales\":[";
                        for (var j = i; j < shop.length; j += (shop.length / 31)) {
                            // saleschart.push(sale[j]);
                            dataTmp += sale[j] + ",";
                        }
                        dataTmp = dataTmp.substring(0, dataTmp.length - 1);
                        dataTmp += "]},";
                    }
                    dataTmp = dataTmp.substring(0, dataTmp.length - 1);
                    dataTmp += "}";
                    var options = {
                        chart: {
                            renderTo: 'container',
                            type: 'line'
                        },
                        title: {
                            text: '<b>餐饮日销售走势图</b>'
                        },
                        //副标题
                        subtitle: {
                            text: ''

                        },
                        yAxis: {
                            min: 0,
                            title: {
                                text: '元'
                            }
                        },
                        xAxis: {
                            categories: []
                        },
                        series: [{}, {}, {}, {}, {}, {}, {}]
                    };
                    var jsonobj;
                    jsonobj = eval("(" + dataTmp + ")");
                    //赋值 series
                    for (var i = 1; i <= getJsonObjLength(jsonobj) ; i++) {
                        options.series[i - 1].data = jsonobj["item" + (i - 1)]["sales"];
                        options.series[i - 1].name = jsonobj["item" + (i - 1)]["name"];
                    }
                    var chart = new Highcharts.Chart(options);
                }, "json");
            });
        });
    </script>
</head>
<body>


    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="fieldcontain">

                <fieldset data-role="controlgroup" data-type="horizontal">
                    <label for="year">选择年份：</label>
                    <select name="year" id="year">
                        <option value="2015">2015</option>
                        <option value="2016">2016</option>
                        <option value="2017">2017</option>
                        <option value="2018">2018</option>
                        <option value="2019">2019</option>
                        <option value="2020">2020</option>
                    </select>
                    <label for="month">选择月份：</label>
                    <select name="month" id="month">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                    </select>
                    <label for="day">选择日期：</label>
                    <select name="day" id="day">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                        <option value="13">13</option>
                        <option value="14">14</option>
                        <option value="15">15</option>
                        <option value="16">16</option>
                        <option value="17">17</option>
                        <option value="18">18</option>
                        <option value="19">19</option>
                        <option value="20">20</option>
                        <option value="21">21</option>
                        <option value="22">22</option>
                        <option value="23">23</option>
                        <option value="24">24</option>
                        <option value="25">25</option>
                        <option value="26">26</option>
                        <option value="27">27</option>
                        <option value="28">28</option>
                        <option value="29">29</option>
                        <option value="30">30</option>
                        <option value="31">31</option>
                    </select>
                </fieldset>
            </div>
            <div data-role="content">
                <div class="ui-grid-d" id="dayreport">
                </div><br /> 
                <div id="container" style="min-width:280px;height:300px"></div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>

        </div>
    </form>
    <script>

        var d = new Date();
        var vYear = d.getFullYear();
        var vMon = d.getMonth() + 1;
        var vDay = d.getDate();
        $('#year').val(vYear);
        $('#month').val(vMon);
        $('#day').val(vDay);
        if (vMon < 10) {
            vMon = "0" + vMon;
        }

        if (vDay < 10) {
            vDay = "0" + vDay;
        }
        $.post('/json/PublicHandler.ashx?Method=SearchCanyinReportByDate&date=' + vYear + '-' + vMon + '-' + vDay, function (result) {
            if (result.success) {
                $("#dayreport").html(result.msg);
            }
            else {
                alert("无可用数据！");
            }
        }, "json");

        $.post('/json/PublicHandler.ashx?Method=SearchCanyinChartByDate&date=' + vYear + '-' + vMon + '-' + vDay, function (item) {
            var shop = item[0];
            var sale = item[1];;
            var shopchart = [];
            var saleschart = [];
            var dataTmp = "{";

            for (var i = 0; i < (shop.length / 31) ; i++) {
                // shopchart[i] = shop[i];                       
                dataTmp += "\"item" + i + "\":{\"name\": \"" + shop[i] + "\",\"sales\":[";
                for (var j = i; j < shop.length; j += (shop.length / 31)) {
                    // saleschart.push(sale[j]);
                    dataTmp += sale[j] + ",";
                }
                dataTmp = dataTmp.substring(0, dataTmp.length - 1);
                dataTmp += "]},";
            }
            dataTmp = dataTmp.substring(0, dataTmp.length - 1);
            dataTmp += "}";
            var options = {
                chart: {
                    renderTo: 'container',
                    type: 'line'
                },
                title: {
                    text: '<b>餐饮日销售走势图</b>'
                },
                //副标题
                subtitle: {
                    text: ''

                },
                yAxis: {
                    min: 0,
                    title: {
                        text: '元'
                    }
                },
                xAxis: {
                    categories: []
                },
                series: [{}, {}, {}, {}, {}, {}, {}]
            };
            var jsonobj;
            jsonobj = eval("(" + dataTmp + ")");
            //赋值 series
            for (var i = 1; i <= getJsonObjLength(jsonobj) ; i++) {
                options.series[i - 1].data = jsonobj["item" + (i - 1)]["sales"];
                options.series[i - 1].name = jsonobj["item" + (i - 1)]["name"];
            }
            var chart = new Highcharts.Chart(options);
        }, "json");

    </script>
    <script>
        function getJsonObjLength(jsonObj) {
            var Length = 0;
            for (var item in jsonObj) {
                Length++;
            }
            return Length;
        }
    </script>

</body>
</html>
