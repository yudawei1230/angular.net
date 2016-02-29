<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SLTradingWaterMonthReport.aspx.cs" Inherits="highsunMobileOA.SLTradingWaterMonthReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>商联交易流水报表</title>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#day').change(function () {

                var loading = document.getElementById("loading");
                loading.style.display = "inline-block";

                var vYear = $('#year').val();
                var vMon = $('#month').val();

                if (vMon < 10) {
                    vMon = "0" + vMon;
                }
                $.post('/json/PublicHandler.ashx?Method=SearchSLTradingWaterReportByMonth&year=' + vYear + "&month" + vMon, function (result) {

                    $("#monthreport").html(result.msg);

                    loading.style.display = "none";
                }, "json");

            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="fieldcontain">
                <fieldset data-role="controlgroup" data-type="horizontal">
                    <label for="year">选择年份：</label>
                    <select name="year" id="year">
                        <option value="2015">2015</option>
                        <option value="2016">2016</option>
                        <option value="2017">2017</option>
                        <option value="2018">2018</option>
                        <option value="2019">2019</option>
                        <option value="2020">2020</option>
                        <option value="2019">2021</option>
                        <option value="2020">2022</option>
                    </select>
                    <label for="month">选择月份：</label>
                    <select name="month" id="month">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                    </select>
                </fieldset>
            </div>
            <div data-role="content">
                <div style="text-align:center"><img id="loading" src="images/loading.gif"/></div>
                <div class="ui-grid-d" id="monthreport"></div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>
            </div>
    </form>

    <script>
        var d = new Date();
        var vYear = d.getFullYear();
        var vMon = d.getMonth() + 1;
        $('#year').val(vYear);
        $('#month').val(vMon);
        if (vMon < 10) {
            vMon = "0" + vMon;
        }
        $.post('/json/PublicHandler.ashx?Method=SearchSLTradingWaterReportByMonth&year=' + vYear + "&month=" + vMon, function (result) {
            if (result.success) {
                $("#monthreport").html(result.msg);
            }
            else {
                alert(result.msg);
            }

            var loading = document.getElementById("loading");
            loading.style.display = "none";

        }, "json");


        
        </script>
</body>
</html>
