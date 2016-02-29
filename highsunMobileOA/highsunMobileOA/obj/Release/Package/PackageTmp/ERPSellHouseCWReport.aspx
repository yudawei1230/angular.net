<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERPSellHouseCWReport.aspx.cs" Inherits="highsunMobileOA.ERPSellHouseCWReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>地产财务销售报表</title>
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
            var projectName = item[1];
            var SumChenjiaojia= item[2];
            var SumHetonghuikuan = item[3];
            var SumHetongqiankuan = item[4];
           
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
                        text: '地产销售财务报表'
                    },
                    xAxis: {
                        categories: projectName,
                        crosshair: true
                    },
                    yAxis: {
                        min: 0,
                        title: {
                            text: '销售（万元）'
                        }
                    },
                    series: [{
                        name: '成交额',
                        data: SumChenjiaojia,
                        color: '#87CEFF'

                    }, {
                        name: '合同回款',
                        data: SumHetonghuikuan,
                        color: '#76EE00'
                    }, {
                        name: '合同欠款',
                        data: SumHetongqiankuan,
                        color: '#EE0000'
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

