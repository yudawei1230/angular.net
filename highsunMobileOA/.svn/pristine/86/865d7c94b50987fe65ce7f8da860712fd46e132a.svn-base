<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERPSellHouseReport.aspx.cs" Inherits="highsunMobileOA.ERPSellHouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>地产总体销售情况</title>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <script type="text/javascript">
        function forward(obj) {
            var projectNo = obj.id;
            URL = "ERPSellHouseBuildingReport.aspx?projectNo=" + projectNo;
            location.href = URL;
        }
    </script> 
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
        $.post('/json/PublicHandler.ashx?Method=SearchERPSellHouseAnalysisReport', function (item) {
            var result = item[0];
            var SumTotal = item[1];
            var REST = item[2];
            var PrePurchase = item[3];
            var Purchase = item[4];
            var Signed = item[5];
            var projectName = item[6];
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
                        text: '项目总体销售情况表'
                    },
                    xAxis: {
                        categories: projectName,
                        crosshair: true
                    },
                    yAxis: {
                        min: 0,
                        title: {
                            text: '销售（套）'
                        }
                    },
                    series: [{
                        name: '总套数',
                        data: SumTotal,
                        color: '#9AFF9A'

                    }, {
                        name: '待售',
                        data: REST,
                        color: '#EE0000'
                    }, {
                        name: '预定',
                        data: PrePurchase,
                        color: '#EEEE00'
                    }, {
                        name: '认购',
                        data: Purchase,
                        color: '#76EEC6'
                    }, {
                        name: '签约',
                        data: Signed,
                        color: '#228B22'
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

