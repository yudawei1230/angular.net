<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERPSellHouseCWAnalysisReport.aspx.cs" Inherits="highsunMobileOA.ERPSellHouseCWAnalysisReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="x-ua-compatible" content="ie=9" />
    <title>地产认购回款报表</title>
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
                <div class="ui-grid-d" id="report"></div><br />
                <div id="container" style="min-width:280px;height:400px"></div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>
        </div>
    </form>
    <script>
        $.post('/json/PublicHandler.ashx?Method=SearchERPSellHouseCWAnalysisReport', function (item) {
            var result = item[0];
            var contractSum = item[2];
            var ContractReceivable = item[3];
            var ContractBalance = item[4];
            var projectName = item[1];
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
                        text: '<b>项目合同财务表</b>'
                    },
                    subtitle: {

                        text: '合同资金情况图'

                    },
                    xAxis: {
                        categories: projectName,
                        crosshair: true
                    },
                    yAxis: {
                        min: 0,
                        title: {
                            text: '金额（万元）'
                        }
                    },
                    plotOptions: {
                        series: {
                            stacking: 'normal'
                        }
                    },
                    series: [{
                        name: '合同欠款',
                        data: ContractBalance,
                        color: '#9BBB59'
                    }, {
                        name: '合同回款',
                        data: ContractReceivable,
                        color: '#C0504D'
                    }, {
                        name: '合同总金额',
                        data: contractSum,
                        color: '#4F81BD'
                    }]
                });

            }
            else {
                alert("无可用数据！");
            }
        }, "json");
    </script>
</body>
</html>

