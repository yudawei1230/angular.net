<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERPSellHousePurchaseDateDetailReport.aspx.cs" Inherits="highsunMobileOA.ERPSellHousePurchaseDateDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>地产认购回款日报表（详细）</title>
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
        var dateStart = URL.split("=")[2].split("&")[0];
        var dateEnd = URL.split("=")[3].split("&")[0];
        $.post('/json/PublicHandler.ashx?Method=SearchERPSellHousePurchaseDateDetailReport&projectNo=' + prjNo + "&dateStart=" + dateStart + "&dateEnd=" + dateEnd , function (item) {
            var result = item[0];
            var BuildingName = item[1];
            var Purchase = item[2];
            var BuildingDealAmount = item[3];
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
                        text: '<b>地产认购回款日报表</b>'
                    },
                    subtitle: {
                        text: dateStart + "——" + dateEnd
                    },
                    xAxis: {
                        categories: BuildingName ,
                        title: {
                            text: null
                        }
                    },
                    yAxis: [{
                        min: 0,
                        title: {
                            text: '成交额 (元)',
                            align: 'high'
                        },
                        labels: {
                            overflow: 'justify'
                        }
                    }, {
                        min: 0,
                        title: {
                            align: 'high',
                            text: '认购数量（套）'
                        },
                        labels: {
                            overflow: 'justify'
                        },
                        lineWidth: 1,
                        opposite: true
                    }],
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
                        name: '成交额',
                        color: '#8FFF19',
                        data: BuildingDealAmount,
                        yAxis: 0
                    }, {
                        name: '认购数量',
                        color: '#FF5919',
                        data: Purchase,
                        yAxis: 1
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

