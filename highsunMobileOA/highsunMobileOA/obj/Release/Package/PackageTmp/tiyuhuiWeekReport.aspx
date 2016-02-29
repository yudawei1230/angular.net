<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tiyuhuiWeekReport.aspx.cs" Inherits="highsunMobileOA.tiyuhuiWeekReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>体育会周销售统计表</title>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="content">
                <div style="text-align:center"><img id="loading" src="images/loading.gif"/></div>
                <div class="ui-grid-d" id="report"></div>
                <br />
                <div id="container" style="min-width: 300px; height: 400px"></div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>

        </div>
    </form>
    <script>
        $.post('/json/PublicHandler.ashx?Method=SearchTiyuhuiWeekReport', function (item) {
            var result = item[0];
            var SaleType = item[1];
            var ThisWeek = item[2];
            var LastWeek = item[3];
            var TBIncrease = item[4];
            var text = "";
            if (result.length != 0) {
                for (var i = 0; i < result.length; i++) {
                    text = text + result[i];
                }
                $("#report").html(text);


                $('#container').highcharts({
                    chart: {
                        type: 'bar'
                    },
                    title: {
                        text: '体育会周销售情况'
                    },

                    xAxis: {
                        categories: SaleType,
                        title: {
                            text: null
                        },
                    },
                    yAxis: {
                        min: 0,
                        title: {
                            text: '金额（元）',
                            align: 'high'
                        },
                        labels: {
                            overflow: 'justify'
                        }
                    },
                    tooltip: {
                        valueSuffix: '元',
                    },
                    plotOptions: {
                        bar: {
                            dataLabels: {
                                enabled: true
                            }
                        }
                    },
                    legend: {
                        enabled:true,
                        layout: 'vertical',
                        align: 'right',
                        verticalAlign: 'middle',
                        x: -5,
                        y: 40,
                        floating: true,
                        borderWidth: 1,
                        backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
                        shadow: true
                    },
                    credits: {
                        enabled: false
                    },

                    series: [{
                        name: '本周',
                        data: ThisWeek,                      
                        color: '#EE4000'
                    }, {
                        name: '上周',
                        data: LastWeek,
                        color: '#76EE00'
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
