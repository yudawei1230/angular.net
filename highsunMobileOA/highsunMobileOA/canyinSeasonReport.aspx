<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="canyinSeasonReport.aspx.cs" Inherits="highsunMobileOA.canyinSeasonReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>餐饮销售季度报表</title>
    <script src='http://www.ichartjs.com/ichart.latest.min.js'></script>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#season').change(function () {
                $.post('/json/PublicHandler.ashx?Method=SearchCanyinReportBySeason&year=' + $('#year').val() +
                '&season=' + $('#season').val(), function (result) {
                    if (result.success) {
                        $("#seasonreport").html(result.msg);
                    }
                    else {

                        alert(result.msg);
                    }
                }, "json");

                $.post('/json/PublicHandler.ashx?Method=SearchCanyinChartBySeason&year=' + $('#year').val() +
                '&season=' + $('#season').val(), function (item) {
                    var shop = item[0];
                    var sale = item[1];
                    var color = item[2];
                    var arr = new Array();
                    for (var i = 0; i < shop.length; i++) {
                        arr[i] = { name: shop[i], value: sale[i], color: color[i] };
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
                    <label for="season">选择季度：</label>
                    <select name="season" id="season">
                        <option value="1">一</option>
                        <option value="2">二</option>
                        <option value="3">三</option>
                        <option value="4">四</option>
                    </select>
                </fieldset>
            </div>
            <div data-role="content">
                <div class="ui-grid-d" id="seasonreport"></div><br />
                <div style="color:red; font-weight:700">餐饮季度销售占比分析</div><br />
                <div id='canvasDiv' class="ui-grid-d"></div>
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
        var vMonth = d.getMonth();
        for (var i = 1; vMonth > 0; i++) {
            vMonth = vMonth - 3;
        }
        var vSeason = i-1;
        $('#year').val(vYear);
        $('#season').val(vSeason);
        $.post('/json/PublicHandler.ashx?Method=SearchCanyinReportBySeason&year=' + vYear + '&season=' + vSeason, function (result) {
            if (result.success) {
                $("#seasonreport").html(result.msg);
        }
        else {

                alert(result.msg);
        }

        }, "json");

        $.post('/json/PublicHandler.ashx?Method=SearchCanyinChartBySeason&year=' + $('#year').val() +
                '&season=' + $('#season').val(), function (item) {
                    var shop = item[0];
                    var sale = item[1];
                    var color = item[2];
                    var arr = new Array();
                    for (var i = 0; i < shop.length; i++) {
                        arr[i] = { name: shop[i], value: sale[i], color: color[i] };
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


                }, "json");

    </script>
</body>
</html>

