<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baihuoYearReport.aspx.cs" Inherits="highsunMobileOA.baihuoYearReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#year').change(function () {
                var vYear = $('#year').val();

                $.post('/json/PublicHandler.ashx?Method=SearchBaihuoReportByYear&year=' + $('#year').val() , function (result) {
                    if (result.success) {
                        $("#yearreport").html(result.msg);
                    }
                    else {
                        alert(result.msg);
                    }
                }, "json");
            });
        });

    </script>
</head>
<body>



    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="header" data-theme="b">
                <h1>番禺又一城销售年报表</h1>
            </div>
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
                </fieldset>
            </div>
            <div data-role="content">
                <div class="ui-grid-d" id="yearreport">
                </div>
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
        $('#year').val(vYear);
        $.post('/json/PublicHandler.ashx?Method=SearchBaihuoReportByYear&year=' + vYear, function (result) {
            if (result.success) {
                $("#yearreport").html(result.msg);
            }
            else {
                alert(result.msg);
            }
        }, "json");

    </script>
</body>
</html>
