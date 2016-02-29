<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERPSellHouseClueDetailDayReport.aspx.cs" Inherits="highsunMobileOA.ERPSellHouseClueDetailDayReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>在售项目来访表（详细）</title>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <script type="text/javascript">
        var URL = location.href;
        var prjNo = URL.split("=")[1].split("&")[0];
        var date = URL.split("=")[2];
        $.post('/json/PublicHandler.ashx?Method=SerachERPSellHouseClueDetailDayReport&projectNo=' + prjNo + "&date=" + date, function (item) {
            var result = item[0];
            var ProjectName = item[2];
            var VisitSource = item[4];
            var text = "";         
            if (result.length != 0) {
                for (var i = 0; i < result.length; i++) {
                    text = text + result[i];
                }
                $("#report").html(text);
                $("#container").highcharts({
                    chart: {
                        type: 'bar'
                    },
                    title: {
                        text: '<b>' + ProjectName[0] + '     来访统计表</b>'
                    },
                    subtitle: {
                        text: date
                    },
                    xAxis: {
                        categories: ["电话来访","现场参观","其他"],
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
                        name: "人数",
                        data: VisitSource,
                        color: "#7CFC00"
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
</head>
<body>



    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
           
            <div data-role="content">
                <div style="text-align:center"><img id="loading" src="images/loading.gif"/></div>
                <div class="ui-grid-d" id="report"></div><br/>
                <div id="container" style="min-width:280px;height:400px"></div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>
        </div>
    </form>

</body>
</html>

