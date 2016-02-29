<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="canyinChart.aspx.cs" Inherits="highsunMobileOA.test" %>

<!DOCTYPE html>
<html lang='en'>
<head>
<meta charset='UTF-8'>
<title>ichartjs designer</title>
<script src='http://www.ichartjs.com/ichart.latest.min.js'></script>
<link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
<link href="css/default.css" rel="stylesheet" />
<script src="js/jquery.js"></script>
<script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
<script src="js/cookies_oper.js"></script>
<script type='text/javascript'>
    $(document).ready(function () {
        $('#day').change(function () {
            var vYear = $('#year').val();
            var vMon = $('#month').val();
            var vDay = $('#day').val();

            if (vMon < 10) {
                vMon = "0" + vMon;
            }

            if (vDay < 10) {
                vDay = "0" + vDay;
            }
            $.post('/json/PublicHandler.ashx?Method=SearchCanyinChartByDate&date=' + vYear + '-' + vMon + '-' + vDay, function (item) {
        var shop = item[0];
        var sale = item[1];
        var color = item[2];
        var arr = new Array();
        for (var i = 0; i < shop.length;i++){
        arr[i] = { name: shop[i], value: sale[i], color: color[i] };
        }
        var data =arr;
        var chart = new iChart.Pie3D({
            render: 'canvasDiv',
            data: data,
            sub_option: {
                mini_label_threshold_angle: 40,//迷你label的阀值,单位:角度
                mini_label: {//迷你label配置项
                    fontsize: 20,
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
                offsetx: 120,
                offsety: 10,
                color: '#3e576f',
                fontsize: 20,//文本大小
                sign_size: 20,//小图标大小
                line_height: 28,//设置行高
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
            width: 800,
            height: 400,
            radius: 150
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
            <div data-role="header" data-theme="b">
                <h1>餐饮日销售图形表</h1>
            </div>
            <div data-role="fieldcontain">
                <fieldset data-role="controlgroup" data-type="horizontal" style=" padding-top:0px; padding-bottom:0px">
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


        <div id='canvasDiv'></div>



        <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>

        </div>
    </form>
    <script type='text/javascript'>
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
        $.post('/json/PublicHandler.ashx?Method=SearchCanyinChartBySeason&year=2015&season=2' , function (item) {
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
                title: {
                    text: 'Mobile-Friendly Distribution',
                    height: 40,
                    fontsize: 30,
                    color: '#282828'
                },
                footnote: {
                    text: 'ichartjs.com',
                    color: '#486c8f',
                    fontsize: 12,
                    padding: '0 38'
                },
                sub_option: {
                    mini_label_threshold_angle: 40,//迷你label的阀值,单位:角度
                    mini_label: {//迷你label配置项
                        fontsize: 20,
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
                    offsetx: 120,
                    offsety: 50,
                    color: '#3e576f',
                    fontsize: 20,//文本大小
                    sign_size: 20,//小图标大小
                    line_height: 28,//设置行高
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
                width: 800,
                height: 400,
                radius: 150
            });
            //利用自定义组件构造右侧说明文本
            chart.plugin(new iChart.Custom({
                drawFn: function () {
                    //在右侧的位置，渲染说明文字
                    chart.target.textAlign('start')
                    .textBaseline('top')
                    .textFont('600 20px Verdana')
                    .fillText('Market Fragmentation:\nTop Mobile\nOperating Systems', 120, 80, false, '#be5985', false, 24)
                    .textFont('600 12px Verdana')
                    .fillText('Source:ComScore,2012', 120, 160, false, '#999999');
                }
            }));

            chart.draw();
        }, "json");
</script>
</body>
</html>   
