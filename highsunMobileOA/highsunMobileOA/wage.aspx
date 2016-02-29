<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wage.aspx.cs" Inherits="highsunMobileOA.wage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

            $('#month').change(function () {
                $('#name').text("");
                $('#basepay').text("");
                $('#payIncentive').text("");
                $('#serviceaward').text("");
                $('#bonus').text("");
                $('#affairsickleave').text("");
                $('#payrollsum').text("");
                $('#endowmentInsurance').text("");
                $('#housingFund').text("");
                $('#shouldMoney').text("");
                $('#taxDeduction').text("");
                $('#baoZhangFei').text("");
                $('#practicalMoney').text("");
                $.post('/json/PublicHandler.ashx?Method=SearchWage&name=' + getCookie("LoginName") + '&year=' + $('#year').val() + '&month=' + $('#month').val() + '&search=' + true, function (result) {

                    var arr = new Array();
                    arr = result.split('||');
                    $('#name').text(arr[0]);
                    $('#basepay').text(arr[1]);
                    $('#payIncentive').text(arr[2]);
                    $('#serviceaward').text(arr[3]);
                    $('#bonus').text(arr[4]);
                    $('#affairsickleave').text(arr[5]);
                    $('#payrollsum').text(arr[6]);
                    $('#endowmentInsurance').text(arr[7]);
                    $('#housingFund').text(arr[8]);
                    $('#shouldMoney').text(arr[9]);
                    $('#taxDeduction').text(arr[10]);
                    $('#baoZhangFei').text(arr[11]);
                    $('#practicalMoney').text(arr[12]);
                });
            });
        });
    </script>
</head>
<body>


    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="header" data-theme="b">
                <h1>我的工资</h1>
            </div>

            <div data-role="content">
                <div data-role="fieldcontain">
                    <fieldset data-role="controlgroup" data-type="horizontal">
                        <%--<legend>选择日期：</legend>--%>
                        <label for="year">选择年份：</label>
                        <select name="year" id="year">
                            <option value="2014">2014</option>
                            <option value="2015">2015</option>
                            <option value="2016">2016</option>
                            <option value="2017">2017</option>
                            <option value="2018">2018</option>
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
                <div class="ui-grid-b">
                    <div class="ui-block-a treven"><span>用户姓名</span></div>
                    <div class="ui-block-b treven"><span>基本工资</span></div>
                    <div class="ui-block-c treven"><span>激励奖金</span></div>
                    <div class="ui-block-a trodd"><span id="name"></span></div>
                    <div class="ui-block-b trodd"><span id="basepay"></span></div>
                    <div class="ui-block-c trodd"><span id="payIncentive"></span></div>
                    <div class="ui-block-a treven"><span>服务奖</span></div>
                    <div class="ui-block-b treven"><span>奖金</span></div>
                    <div class="ui-block-c treven"><span>事假扣款</span></div>
                    <div class="ui-block-a trodd"><span id="serviceaward"></span></div>
                    <div class="ui-block-b trodd"><span id="bonus"></span></div>
                    <div class="ui-block-c trodd"><span id="affairsickleave"></span></div>
                    <div class="ui-block-a treven"><span>薪酬合计</span></div>
                    <div class="ui-block-b treven"><span>社保</span></div>
                    <div class="ui-block-c treven"><span>住房公积金</span></div>
                    <div class="ui-block-a trodd"><span id="payrollsum"></span></div>
                    <div class="ui-block-b trodd"><span id="endowmentInsurance"></span></div>
                    <div class="ui-block-c trodd"><span id="housingFund"></span></div>
                    <div class="ui-block-a treven"><span>应发</span></div>
                    <div class="ui-block-b treven"><span>扣个税</span></div>
                    <div class="ui-block-c treven"><span>扣保障费</span></div>
                    <div class="ui-block-a trodd"><span id="shouldMoney"></span></div>
                    <div class="ui-block-b trodd"><span id="taxDeduction"></span></div>
                    <div class="ui-block-c trodd"><span id="baoZhangFei"></span></div>
                    <div class="ui-block-a treven"><span>实发</span></div>
                    <div class="ui-block-a trodd"><span id="practicalMoney"></span></div>
                </div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2014 海印股份</p>
            </div>

        </div>
    </form>
    <script>
        var d = new Date();
        var vYear = d.getFullYear();
        var vMon = d.getMonth() + 1;
        $('#year').val(vYear);
        $('#month').val(vMon);
        $.post('/json/PublicHandler.ashx?Method=SearchWage&name=' + getCookie("LoginName") + '&year=' + vYear + '&month=' + vMon + '&search=' + false, function (result) {

            var arr = new Array();
            arr = result.split('||');
            $('#name').text(arr[0]);
            $('#basepay').text(arr[1]);
            $('#payIncentive').text(arr[2]);
            $('#serviceaward').text(arr[3]);
            $('#bonus').text(arr[4]);
            $('#affairsickleave').text(arr[5]);
            $('#payrollsum').text(arr[6]);
            $('#endowmentInsurance').text(arr[7]);
            $('#housingFund').text(arr[8]);
            $('#shouldMoney').text(arr[9]);
            $('#taxDeduction').text(arr[10]);
            $('#baoZhangFei').text(arr[11]);
            $('#practicalMoney').text(arr[12]);
            $('#year').val(arr[14]).selectmenu("refresh");
            $('#month').val(arr[15]).selectmenu("refresh");
          
        });
    </script>
</body>
</html>
