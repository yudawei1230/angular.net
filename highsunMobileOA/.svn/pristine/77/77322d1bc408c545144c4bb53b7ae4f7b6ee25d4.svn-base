<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baihuoTrend.aspx.cs" Inherits="highsunMobileOA.baihuoTrend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
    <script src="js/jquery.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <script>
        $(function () {
            $.post('/json/PublicHandler.ashx?Method=SearchBaihuoTrendbyDate', function (item) {
                var sale = item[0];
                var date = item[1];
                
            $('#container').highcharts({
                title: {
                    text: '番禺又一城销售额走势图',
                    x: 25 
                },
                xAxis: {
                    categories: date
                },
                yAxis: {
                    title: {
                        text: '销售额 (万元)'
                    },
                    plotLines: [{
                        value: 0,
                        width: 1,
                        color: '#808080'
                    }]
                },
                tooltip: {
                    valueDecimals: 2,
                    valueSuffix: '万元'
                },
                series: [{
                    name: '销售额',
                    data: sale
                }]
            });
            }, "json");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container" style="min-width:400px;height:400px"></div>
    </form>
</body>
</html>
