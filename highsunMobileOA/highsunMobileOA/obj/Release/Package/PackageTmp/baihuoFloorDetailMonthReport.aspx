<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baihuoFloorDetailMonthReport.aspx.cs" Inherits="highsunMobileOA.baihuoFloorDetailMonthReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>番禺又一城柜组月报表</title>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#month').change(function () {

                var loading = document.getElementById("loading");
                loading.style.display = "inline-block";

                var monthreport = document.getElementById("monthreport");
                monthreport.style.display = "none";

                var subhead = document.getElementById("subhead");
                subhead.style.display = "none";

                var url = location.href;
                var tmp1 = url.split("?")[1];
                var tmp2 = tmp1.split("&")[0];
                var tmp3 = tmp2.split("=")[1];
                var parm1 = tmp3;
                var vYear = $('#year').val();
                var vMon = $('#month').val();
                var vDay = "01";

                if (vMon < 10) {
                    vMon = "0" + vMon;
                }

                $.post('/json/PublicHandler.ashx?Method=SearchBaihuoMonthReportByFloorDetail&date=' + $('#year').val() +
                '-' + vMon + '-' + vDay + "&floor=" + parm1, function (result) {
                    if (result.success) {
                        $("#monthreport").html(result.msg);
                    }
                    else {
                        alert("无可用数据！");
                    }

                    loading.style.display = "none";
                    monthreport.style.display = "block";
                    subhead.style.display = "block";

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
                <div id="subhead" style="text-align:center;font-weight:700;display:none"><span id="mtitle"></span>柜组销售情况</div><br />
                <div class="ui-grid-d" id="monthreport">
                </div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>

        </div>
    </form>
    <script>
        var url = location.href;
        var parm1 = url.split("?")[1].split("&")[0].split("=")[1];
        var parm2 = decodeURI(url.split("?")[1].split("&")[1].split("=")[1]);
        var parm3 = url.split("?")[1].split("&")[2].split("=")[1];
        var mtitle = document.getElementById("mtitle");
        mtitle.innerHTML = parm2;
        var date = parm3.split("-");
        var vYear = date[0];
        var vMon = date[1];
        var vDay = date[2];
        $('#year').val(vYear);
        $('#month').val(vMon);
        if (vMon < 10) {
            vMon = "0" + vMon;
        }
        $.post('/json/PublicHandler.ashx?Method=SearchBaihuoMonthReportByFloorDetail&date=' + vYear + '-' + vMon + '-' + vDay + "&floor=" + parm1, function (result) {
            if (result.success) {
                $("#monthreport").html(result.msg);
            }
            else {
                alert("无可用数据！");
            }

            var loading = document.getElementById("loading");
            loading.style.display = "none";

            var subhead = document.getElementById("subhead");
            subhead.style.display = "block";
        }, "json");

    </script>
</body>
</html>
