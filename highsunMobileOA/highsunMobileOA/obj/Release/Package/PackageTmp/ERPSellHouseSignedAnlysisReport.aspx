<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERPSellHouseSignedAnlysisReport.aspx.cs" Inherits="highsunMobileOA.ERPSellHouseSignedAnlysisReport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>累计签约情况表</title>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <style>
        * {font-family: "Microsoft YaHei","iconfont","FontAwesome"  !important;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="content">
                <img id="loading" src="images/loading.gif" style="padding-left:120px; "/>
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
        $.post('/json/PublicHandler.ashx?Method=SearchERPSellHouseSignedAnlysisReport', function (item) {
            var result = item[0];
            var ProjectName = item[1];
            var Signed = item[2];
            var SignedDealAmount = item[3];
            var Purchase = item[4];
            var SignedPersent = item[4];
            text = "";
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
                        text: '<b>累计签约情况表</b>（数量）'
                    },
                    xAxis: {
                        categories: ProjectName,
                        title: {
                            text: null
                        },
                    },
                    yAxis: {
                        min: 0,
                        title: {
                            text: '数量（份）',
                            align: 'high'
                        },
                        labels: {
                            overflow: 'justify'
                        }
                    },
                    tooltip: {
                        valueSuffix: '份',
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
                        name: '签约+认购',
                        data: Purchase,
                        color: '#8FFF19'
                    }, {
                        name: '签约',
                        data: Signed,
                        color: '#FF5919'
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
