<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DWYXReceiveWeekReport.aspx.cs" Inherits="highsunMobileOA.DWYXReceiveWeekReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="x-ua-compatible" content="ie=10" />
    <title>院线周收入明细表</title>
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
                <div class="ui-grid-d" id="report1"></div><br />
                <div class="ui-grid-d" id="report2"></div><br />
                <div id="container" style="min-width:280px;height:400px"></div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>
        </div>
    </form>
        <script>
            var DAY = '星期天,星期一,星期二,星期三,星期四,星期五,星期六'.split(',');
            var time = new Date(), msg = [];
            var startDate = new Date();
            var endDate = new Date();
            startDate.setDate(time.getDate() - time.getDay());
            endDate.setDate(time.getDate() + 7 - time.getDay());
            var startYear = startDate.getFullYear();
            var startMonth = startDate.getMonth() + 1 ;
            var startDay = startDate.getDate();
            if (startMonth < 10) {
                startMonth = "0" + startMonth;
            }
            if (startDay < 10) {
                startDay = "0" + startDay;
            }
            var endYear = endDate.getFullYear();
            var endMonth = endDate.getMonth() + 1;
            var endDay = endDate.getDate();
            if (endDate >= time) {
                endYear = time.getFullYear();
                endMonth = time.getMonth() + 1;
                endDay = time.getDate() - 1;
            }
            if (endMonth < 10) {
                endMonth = "0" + endMonth;
            }
            if (endDay < 10) {
                endDay = "0" + endDay;
            }
            startDate = startYear + "-" + startMonth + "-" + startDay + " " + "0600";
            endDate = endYear + "-" + endMonth + "-" + endDay + " " + "0600";
            $.post('/json/PublicHandler.ashx?Method=SearchDWYXReceiveWeekReport&dateStart=' + startDate + '&dateEnd=' + endDate, function (item) {
                var result = item[0];
                var showdate = item[1];
                var changciNum = item[2];
                var CumstomerNum = item[3];
                var Tongkan = item[4];
                var NewAddNum = item[5];
                var BoxOffice = item[6];
                var XiaoMB = item[7];
                var MemberAddMoney = item[8];
                var preShowdate = item[9];
                var preBoxOffice = item[10];
                var preMemberAddMoney = item[11];
                var result2 = item[12];
                var text1 = "";
                var text2 = "";
                if (result.length != 0) {
                    for (var i = 0; i < result.length; i++) {
                        text1 = text1 + result[i];
                    }
                    $("#report1").html(text1);
                    if (result2.length != 0) {
                        for (var i = 0; i < result2.length; i++) {
                            text2 = text2 + result2[i];
                        }
                        $("#report2").html(text2);
                    }
                    $('#container').highcharts({
                        title: {
                            text: '<b>电影院收入明细（元）</b>',
                            x: 0 //center
                        },
                        subtitle: {
                            text: startYear + "-" + startMonth + "-" + startDay + '----' + endYear + "-" + endMonth + "-" + endDay,
                            x: -20
                        },
                        xAxis: [{
                            categories: ["周日", "周一", "周二", "周三", "周四", "周五", "周六"],
                            title: {
                                text: '日期',
                                style: {
                                    color: '#89A54E'
                                }
                            }
                        }],
                        yAxis: {
                            min: 0,
                            title: {
                                text: '收入金额 （元）'
                            },
                            plotLines: [{
                                value: 0,
                                width: 1,
                                color: '#808080'
                            }]
                        },
                        tooltip: {
                            valueSuffix: '元'
                        },
                        series: [
                            {
                                name: '本周票房',
                                data: BoxOffice,
                            }, {
                                name: '本周会员充值',
                                data: MemberAddMoney,
                            }, {
                                name: '上周票房',
                                data: preBoxOffice,
                            }, {
                                name: '上周会员充值',
                                data: preMemberAddMoney,
                            }]
                    });
                }
                else {
                    alert("无数据");
                }
            }, "json");
        </script>
</body>
</html>
