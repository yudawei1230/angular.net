<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERPSellHouseBuildingReport.aspx.cs" Inherits="highsunMobileOA.ERPSellHouseBuildingReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>项目楼栋销售清表</title>
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
        var URL = location.href;
        var prjNo = URL.split("=")[1].split("+")[0];
        $.post('/json/PublicHandler.ashx?Method=SearchERPSellHouseAnlysisBuildingReport&projectNo=' + prjNo, function (item) {
            var result = item[0];
            var BuildingName = item[1];
            var SumTotal = item[2];
            var REST = item[3];
            var PrePurchase = item[4];
            var Purchase = item[5];
            var Signed = item[6];
            var projectName = item[7];
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
                        text: projectName
                    },
                    xAxis: {
                        categories: BuildingName,
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
                        data: SumTotal

                    }, {
                        name: '待售',
                        data: REST

                    }, {
                        name: '预定',
                        data: PrePurchase

                    }, {
                        name: '认购',
                        data: Purchase

                    }, {
                        name: '签约',
                        data: Signed
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
