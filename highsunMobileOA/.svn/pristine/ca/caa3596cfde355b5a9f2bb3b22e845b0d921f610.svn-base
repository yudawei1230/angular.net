<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SLreport.aspx.cs" Inherits="highsunMobileOA.SLreport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>商联交易流水报表</title>
    <script src='http://www.ichartjs.com/ichart.latest.min.js'></script>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="header" data-theme="b">
                <select name="SelectReport" id="SelectReport" onchange="content.location.href=this.options[this.selectedIndex].value">
                        <option value="SLTradingWaterReport.aspx">日报表</option>
                        <option value="SLTradingWaterMonthReport.aspx">月报表</option>
                        <option value="SLTradingWaterSeasonReport.aspx">季报表</option>
                        <option value="SLTradingWaterYearReport.aspx">年报表</option>
                </select>
            </div>
            <iframe name="content" id="content" src="SLTradingWaterReport.aspx" width="100%"  height="500px" scrolling=no></iframe>
        </div>
    </form>
</body>
</html>
