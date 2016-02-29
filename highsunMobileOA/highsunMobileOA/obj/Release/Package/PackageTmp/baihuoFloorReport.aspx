<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baihuoFloorReport.aspx.cs" Inherits="highsunMobileOA.baihuoFloorReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>番禺又一城楼层日报表</title>
    <script src='http://www.ichartjs.com/ichart.latest.min.js'></script>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#day').change(function () {

                var loading = document.getElementById("loading");
                loading.style.display = "inline-block";

                var subhead = document.getElementById("subhead");
                subhead.style.display = "none";

                var dayreport = document.getElementById("dayreport");
                dayreport.style.display = "none";

                var canvasDiv = document.getElementById("canvasDiv");
                canvasDiv.style.display = "none";

                var vYear = $('#year').val();
                var vMon = $('#month').val();
                var vDay = $('#day').val();

                if (vMon < 10) {
                    vMon = "0" + vMon;
                }

                if (vDay < 10) {
                    vDay = "0" + vDay;
                }
                $.post('/json/PublicHandler.ashx?Method=SearchBaihuoReportByFloor&date=' + $('#year').val() +
                '-' + vMon + '-' + vDay, function (result) {
                    if (result.success) {
                        $("#dayreport").html(result.msg);
                    }
                    else {
                        alert("无可用数据！");
                    }
                }, "json");

                $.post('/json/PublicHandler.ashx?Method=SearchBaihuoChartByDate&date=' + vYear + '-' + vMon + '-' + vDay, function (item) {
                    var shop = item[0];
                    var sale = item[1];
                    var color = item[2];
                    var arr = new Array();
                    if (item.length == 0) {
                        arr[0] = { name: "无数据", value: 100, color: "#3883bd" };
                    }
                    else {
                        for (var i = 0; i < shop.length; i++) {
                            arr[i] = { name: shop[i], value: sale[i], color: color[i] };
                        }
                    }
                    var data = arr;
                    var chart = new iChart.Pie3D({
                        render: 'canvasDiv',
                        data: data,
                        sub_option: {
                            mini_label_threshold_angle: 40,//迷你label的阀值,单位:角度
                            mini_label: {//迷你label配置项
                                fontsize: 10,
                                fontweight: 600,
                                color: '#ffffff'
                            },
                            label: {
                                background_color: null,
                                sign: false,//设置禁用label的小图标
                                padding: '0 4',
                                border: {
                                    enable: false,
                                    color: '#666666'
                                },
                                fontsize: 11,
                                fontweight: 600,
                                color: '#4572a7'
                            },
                            border: {
                                width: 2,
                                color: '#ffffff'
                            },
                            listeners: {
                                parseText: function (d, t) {
                                    return d.get('value') + "%";//自定义label文本
                                }
                            }
                        },
                        legend: {
                            enable: true,
                            padding: 0,
                            offsetx: 0,
                            offsety: 10,
                            color: '#3e576f',
                            fontsize: 10,//文本大小
                            sign_size: 20,//小图标大小
                            line_height: 10,//设置行高
                            sign_space: 10,//小图标与文本间距
                            border: false,
                            align: 'left',
                            background_color: null//透明背景
                        },
                        animation: true,//开启过渡动画
                        animation_duration: 800,//800ms完成动画 
                        shadow: true,
                        shadow_blur: 6,
                        shadow_color: '#aaaaaa',
                        shadow_offsetx: 0,
                        shadow_offsety: 0,
                        background_color: '#f1f1f1',
                        align: 'right',//右对齐
                        offsetx: -100,//设置向x轴负方向偏移位置60px
                        offset_angle: -90,//逆时针偏移120度
                        width: 400,
                        height: 235,
                        radius: "80%"
                    });
                    //利用自定义组件构造右侧说明文本


                    chart.draw();

                    loading.style.display = "none";
                    subhead.style.display = "block";
                    dayreport.style.display = "block";
                    canvasDiv.style.display = "block";

                }, "json");

            });
        });

    </script>
    <script type="text/javascript">
        function forward(obj) {
            var FNo = obj.id;
            var FName = encodeURI(obj.name);
            var date = $('#year').val() + "-" + $('#month').val() + "-" + $('#day').val();
            URL = "baihuoFloorDetailReport.aspx?FloorNo="+FNo+"&FloorName="+ FName +"&date="+date;
            location.href = URL;
        }
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
                    <label for="day">选择日期：</label>
                    <select name="day" id="day">
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
                        <option value="13">13</option>
                        <option value="14">14</option>
                        <option value="15">15</option>
                        <option value="16">16</option>
                        <option value="17">17</option>
                        <option value="18">18</option>
                        <option value="19">19</option>
                        <option value="20">20</option>
                        <option value="21">21</option>
                        <option value="22">22</option>
                        <option value="23">23</option>
                        <option value="24">24</option>
                        <option value="25">25</option>
                        <option value="26">26</option>
                        <option value="27">27</option>
                        <option value="28">28</option>
                        <option value="29">29</option>
                        <option value="30">30</option>
                        <option value="31">31</option>
                    </select>
                </fieldset>
            </div>
            <div data-role="content">
                <div style="text-align:center"><img id="loading" src="images/loading.gif"/></div>
                <div class="ui-grid-d" id="dayreport"></div><br />
                <div id="subhead" style="color:red; font-weight:700;display:none">楼层日销售占比分析</div><br />
                <div id='canvasDiv' class="ui-grid-d"></div>
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
        var vDay = d.getDate();
        $('#year').val(vYear);
        $('#month').val(vMon);
        $('#day').val(vDay);
        if (vMon < 10) {
            vMon = "0" + vMon;
        }

        if (vDay < 10) {
            vDay = "0" + vDay;
        }
        $.post('/json/PublicHandler.ashx?Method=SearchBaihuoReportByFloor&date=' + vYear + '-' + vMon + '-' + vDay, function (result) {
            if (result.success) {
                $("#dayreport").html(result.msg);
            }
            else {
                alert("无可用数据！");
            }
        }, "json");

        $.post('/json/PublicHandler.ashx?Method=SearchBaihuoChartByDate&date=' + vYear + '-' + vMon + '-' + vDay, function (item) {
            var shop = item[0];
            var sale = item[1];
            var color = item[2];
            var arr = new Array();
            if (item.length == 0) {
                arr[0] = { name: "无数据", value: 100, color: "#3883bd" };
            }
            else {
                for (var i = 0; i < shop.length; i++) {
                    arr[i] = { name: shop[i], value: sale[i], color: color[i] };
                }
            }
            var data = arr;
            var chart = new iChart.Pie3D({
                render: 'canvasDiv',
                data: data,
                sub_option: {
                    mini_label_threshold_angle: 40,//迷你label的阀值,单位:角度
                    mini_label: {//迷你label配置项
                        fontsize: 10,
                        fontweight: 600,
                        color: '#ffffff'
                    },
                    label: {
                        background_color: null,
                        sign: false,//设置禁用label的小图标
                        padding: '0 4',
                        border: {
                            enable: false,
                            color: '#666666'
                        },
                        fontsize: 11,
                        fontweight: 600,
                        color: '#4572a7'
                    },
                    border: {
                        width: 2,
                        color: '#ffffff'
                    },
                    listeners: {
                        parseText: function (d, t) {
                            return d.get('value') + "%";//自定义label文本
                        }
                    }
                },
                legend: {
                    enable: true,
                    padding: 0,
                    offsetx: 0,
                    offsety: 10,
                    color: '#3e576f',
                    fontsize: 10,//文本大小
                    sign_size: 20,//小图标大小
                    line_height: 10,//设置行高
                    sign_space: 10,//小图标与文本间距
                    border: false,
                    align: 'left',
                    background_color: null//透明背景
                },
                animation: true,//开启过渡动画
                animation_duration: 800,//800ms完成动画 
                shadow: true,
                shadow_blur: 6,
                shadow_color: '#aaaaaa',
                shadow_offsetx: 0,
                shadow_offsety: 0,
                background_color: '#f1f1f1',
                align: 'right',//右对齐
                offsetx: -100,//设置向x轴负方向偏移位置60px
                offset_angle: -90,//逆时针偏移120度
                width: 400,
                height: 235,
                radius: "80%"
            });
            //利用自定义组件构造右侧说明文本


            chart.draw();

            var loading = document.getElementById("loading");
            loading.style.display = "none";

            var subhead = document.getElementById("subhead");
            subhead.style.display = "block";

        }, "json");
    </script>
</body>
</html>
