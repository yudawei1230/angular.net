<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERPSellHouseClueAnalysisDetailReport.aspx.cs" Inherits="highsunMobileOA.ERPSellHouseClueAnalysisDetailReport" %>

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
        <style>
        * {
           font-family: "Microsoft YaHei","iconfont","FontAwesome"  !important;
        }
        .ui-btn {
            height: 30px;
            margin:0px auto;
        }
        .redoBtn {
            background:url(images/redo_square.png);
            border-style:none;
            height:30px;
            background-repeat:no-repeat;
            background-size:cover;
            -moz-background-size:cover;
            -webkit-background-size:cover;
        }
    </style>  
    <script type="text/javascript">
        var URL = location.href;
        var prjNo = URL.split("=")[1].split("&")[0];
        var dateStart = URL.split("=")[2].split("&")[0];
        var dateEnd = URL.split("=")[3].split("&")[0];
        $.post('/json/PublicHandler.ashx?Method=SearchERPSellHouseClueAnalysisDetailReport&projectNo=' + prjNo + "&dateStart=" + dateStart + "&dateEnd=" + dateEnd, function (item) {
            var result = item[0];
            var ProjectName = item[1];
            var VisitSource = item[2];
            var VistCount = item[3];
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
                        text: dateStart + "——" + dateEnd
                    },
                    xAxis: {
                        categories: ["电话来访","现场参观","其他"],
                        crosshair: true
                    },
                    yAxis: {
                        title: {
                            text: '总来访人数',
                            align: 'high'
                        },
                        labels: {
                            overflow: 'justify'
                        }
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
                        name: '来访人数',
                        data: VistCount,
                        color: '#9BBB59'
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
                <div><h3 id="title" style="margin:0px;text-align:center;"></h3></div>
                <div style="margin-left:60%;float:left;line-height:30px">返回前一页</div>
                <div id="tips" style="width:30px;height:30px;float:left;margin:0 0 2px 5px"><input type="button" class="redoBtn" onclick='redo()' /></div>
                <div class="ui-grid-d" id="report"  style="clear:both"></div><br/>
                <div id="container" style="min-width:280px;height:400px"></div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>
        </div>
    </form>
        <script>
            $("#title").html(dateStart + "——" + dateEnd);
            function redo() {
                URL = "ERPSellHouseClueAnalysisReport.aspx?redoStartDate=" + dateStart + "&redoEndDate=" + dateEnd;
                location.href = URL;
            }
    </script>
</body>
</html>

