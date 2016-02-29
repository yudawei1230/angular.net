<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="attendance.aspx.cs" Inherits="highsunMobileOA.attendance" %>

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
    <link href="js/fullcalendar-2.2.3/lib/cupertino/jquery-ui.min.css" rel="stylesheet" />
    <link href='js/fullcalendar-2.2.3/fullcalendar.css' rel='stylesheet' />
    <link href='js/fullcalendar-2.2.3/fullcalendar.print.css' rel='stylesheet' media='print' />
    <script src='js/fullcalendar-2.2.3/lib/moment.min.js'></script>
    <script src='js/fullcalendar-2.2.3/fullcalendar.js'></script>
    <script src="js/fullcalendar-2.2.3/lang/zh-cn.js"></script>
    <script src="js/fullcalendar-2.2.3/lib/jquery-ui.custom.min.js"></script>

</head>
<body>
    <script>

        $(document).ready(function () {

            $('#calendar').fullCalendar({
                theme: true,
                contentHeight: 370,
                //aspectRatio:1.8,
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: ''
                },
                events: <%=Str%>
                
                
                //events: function (callback) {
                //    $.ajax({
                //        url: '/json/PublicHandler.ashx',
                //        dataType: 'json',
                //        cache: false,
                //        data: {
                //            Method: "AttendanceLog",
                //            Name: "谢承东"
                //        },
                //        success: function (result) {

                //            var evs = [];
                //            var info = result.event;

                //            for (var i = 0; i < info.length; i++) {
                //                var ev = info[i];
                //                var evtitle = ev.Name;
                //                //var evstart = '2014-11-01';
                //                //var evstart = ev.CheckinTime;

                //                var evstart = ev.CheckYear + "-" + ev.CheckMonth + "-" + ev.CheckDay;

                //                evs.push({
                //                    title: 'Birthday Party',
                //                    start: '2014-12-13T07:00:00'
                //                    //start: $(this).attr('CheckYear') + $(this).attr('CheckMonth') + $(this).attr('CheckDay'),
                //                    //title: $(this).attr('CheckinTime'),
                //                    //rendering: 'background',
                //                    //color: $(this).attr('color'),
                //                });
                //            }
                //            callback(evs);
                //        },
                //        error: function () { alert('加载数据失败') }
                //    });
                //}
            });

        });

    </script>

    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="header" data-theme="b">
                <h1>我的考勤</h1>
            </div>

            <div data-role="content">
                <%--<div data-role="fieldcontain">
                    <fieldset data-role="controlgroup" data-type="horizontal">
                        <legend>选择日期：</legend>
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
                            <option value="01">01</option>
                            <option value="02">02</option>
                            <option value="03">03</option>
                            <option value="04">04</option>
                            <option value="05">05</option>
                            <option value="06">06</option>
                            <option value="07">07</option>
                            <option value="08">08</option>
                            <option value="09">09</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                        </select>
                    </fieldset>
                </div>--%>
                <div id='calendar'></div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2014 海印股份</p>
            </div>

        </div>
    </form>

</body>
</html>
