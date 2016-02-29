<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baihuoPanelChart.aspx.cs" Inherits="highsunMobileOA.PanelChart" %>

<!doctype html>
<html>
<head>
    <title>百货销售达成情况(万元)</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/jquery.fullPage.css">
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <script src="js/jquery.fullPage.js"></script>
    <script>
        $(document).ready(function () {
            $('#month').change(function () {

                var loading = document.getElementById("loading");
                loading.style.display = "inline-block";


                var vYear = $('#year').val();
                var vMon = $('#month').val();
                var topic1 = 'A座销售达成情况';
                var topic2 = 'A+B座销售达成情况';
                if (vMon < 10) {
                    vMon = "0" + vMon;
                }
                $.post('/json/PublicHandler.ashx?Method=SearchBaihuoTaskByMonth&year=' + vYear + "&month=" + vMon, function (item) {
                    var target = item[1];
                    var date = item[0];
                    var CST = item[2];
                    var CR = item[3];
                    if (vMon == "02") {
                        var tmax1 = 1.8 * target[0];
                        var tmax2 = 1.8 * target[1];
                    }
                    else {
                        var tmax1 = 1.25 * target[0];
                        var tmax2 = 1.25 * target[1];
                    }
                    document.getElementById("cst1").innerHTML = CST[0]  + "%";
                    document.getElementById("cst2").innerHTML = CST[1]  + "%";
                    document.getElementById("cr1").innerHTML = CR[0]  + "%";
                    document.getElementById("cr2").innerHTML = CR[1]  + "%";
                    $('#container1').highcharts({
                        chart: {
                            type: 'gauge',
                            plotBackgroundColor: null,
                            plotBackgroundImage: null,
                            plotBorderWidth: 0,
                            plotShadow: false,
                            marginTop: 22,
                            marginBottom: 0
                        },

                        title: {
                            text: topic1 + "(销售目标：" + target[0] + "万元)",
                            style: {
                                fontSize: '14px'
                            }
                        },

                        pane: {
                            startAngle: -150,
                            endAngle: 150,
                            background: [{
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#FFF'],
                                        [1, '#333']
                                    ]
                                },
                                borderWidth: 0,
                                outerRadius: '109%'
                            }, {
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#333'],
                                        [1, '#FFF']
                                    ]
                                },
                                borderWidth: 1,
                                outerRadius: '107%'
                            }, {

                            }, {
                                backgroundColor: '#DDD',
                                borderWidth: 0,
                                outerRadius: '105%',
                                innerRadius: '103%'
                            }]
                        },

                        yAxis: {
                            min: 0,
                            max: tmax1,
                            minorTickInterval: 'auto',
                            minorTickWidth: 1,
                            minorTickLength: 10,
                            minorTickPosition: 'inside',
                            minorTickColor: '#666',

                            tickPixelInterval: 30,
                            tickWidth: 2,
                            tickPosition: 'inside',
                            tickLength: 10,
                            tickColor: '#666',
                            labels: {
                                step: 2,
                                rotation: 'auto'
                            },
                            title: {
                                text: '万元'
                            },
                            plotBands: [{
                                from: 0,
                                to: target[0] * 0.25,
                                color: '#DF5353'
                            }, {
                                from: target[0] * 0.25,
                                to: target[0] * 0.5,
                                color: '#DDDF0D'
                            }, {
                                from: target[0] * 0.5,
                                to: target[0] * 0.75,
                                color: '#FF9900'
                            }, {
                                from: target[0] * 0.75,
                                to: target[0],
                                color: '#55BF3B'
                            }, {
                                from: target[0],
                                to: tmax1,
                                color: '#66FF33'
                            }]
                        },

                        series: [{
                            name: '销售额',
                            data: [date[0] * 1],
                            tooltip: {
                                valueSuffix: '万元'
                            }
                        }]

                    },
                function (chart) {
                });

                    $('#container2').highcharts({
                        chart: {
                            type: 'gauge',
                            plotBackgroundColor: null,
                            plotBackgroundImage: null,
                            plotBorderWidth: 0,
                            plotShadow: false,
                            marginTop: 22,
                            marginBottom: 0
                        },

                        title: {
                            text: topic2 + "(销售目标：" + target[1] + "万元)",
                            style: {
                                fontSize: '14px'
                            }
                        },

                        pane: {
                            startAngle: -150,
                            endAngle: 150,
                            background: [{
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#FFF'],
                                        [1, '#333']
                                    ]
                                },
                                borderWidth: 0,
                                outerRadius: '109%'
                            }, {
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#333'],
                                        [1, '#FFF']
                                    ]
                                },
                                borderWidth: 1,
                                outerRadius: '107%'
                            }, {
                            }, {
                                backgroundColor: '#DDD',
                                borderWidth: 0,
                                outerRadius: '105%',
                                innerRadius: '103%'
                            }]
                        },

                        yAxis: {
                            min: 0,
                            max: tmax2,
                            minorTickInterval: 'auto',
                            minorTickWidth: 1,
                            minorTickLength: 10,
                            minorTickPosition: 'inside',
                            minorTickColor: '#666',

                            tickPixelInterval: 30,
                            tickWidth: 2,
                            tickPosition: 'inside',
                            tickLength: 10,
                            tickColor: '#666',
                            labels: {
                                step: 2,
                                rotation: 'auto'
                            },
                            title: {
                                text: '万元'
                            },
                            plotBands: [{
                                from: 0,
                                to: target[1] * 0.25,
                                color: '#DF5353'
                            }, {
                                from: target[1] * 0.25,
                                to: target[1] * 0.5,
                                color: '#DDDF0D'
                            }, {
                                from: target[1] * 0.5,
                                to: target[1] * 0.75,
                                color: '#FF9900'
                            }, {
                                from: target[1] * 0.75,
                                to: target[1],
                                color: '#55BF3B'
                            }, {
                                from: target[1],
                                to: tmax2,
                                color: '#66FF33'
                            }]
                        },

                        series: [{
                            name: '销售额',
                            data: [date[1] * 1],
                            tooltip: {
                                valueSuffix: '万元'
                            }
                        }]

                    },
                      function (chart) {
                      });

                }, "json");

                $.post('/json/PublicHandler.ashx?Method=SearchBaihuoTaskBySeason&year=' + vYear + "&month=" + vMon, function (item) {
                    var target = item[1];
                    var date = item[0];
                    var CST = item[2];
                    var CR = item[3];
                    var tmax1 = 1.25 * target[0];
                    var tmax2 = 1.25 * target[1];
                    document.getElementById("cst3").innerHTML = CST[0] + "%";
                    document.getElementById("cst4").innerHTML = CST[1] + "%";
                    document.getElementById("cr3").innerHTML = CR[0]  + "%";
                    document.getElementById("cr4").innerHTML = CR[1]  + "%";
                    $('#container3').highcharts({
                        chart: {
                            type: 'gauge',
                            plotBackgroundColor: null,
                            plotBackgroundImage: null,
                            plotBorderWidth: 0,
                            plotShadow: false,
                            marginTop: 22,
                            marginBottom: 0
                        },
                        title: {
                            text: topic1 + "(" + parseInt((parseInt(vMon) + 2) / 3) + " 季度目标:" + target[0]+"万元)",

                            style: {
                                fontSize: '12px',
                                textAlign: 'left'
                            },
                        },

                        pane: {
                            startAngle: -150,
                            endAngle: 150,
                            background: [{
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#FFF'],
                                        [1, '#333']
                                    ]
                                },
                                borderWidth: 0,
                                outerRadius: '109%'
                            }, {
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#333'],
                                        [1, '#FFF']
                                    ]
                                },
                                borderWidth: 1,
                                outerRadius: '107%'
                            }, {
                            }, {
                                backgroundColor: '#DDD',
                                borderWidth: 0,
                                outerRadius: '105%',
                                innerRadius: '103%'
                            }]
                        },
                        yAxis: {
                            min: 0,
                            max: tmax1,
                            minorTickInterval: 'auto',
                            minorTickWidth: 1,
                            minorTickLength: 10,
                            minorTickPosition: 'inside',
                            minorTickColor: '#666',

                            tickPixelInterval: 30,
                            tickWidth: 2,
                            tickPosition: 'inside',
                            tickLength: 10,
                            tickColor: '#666',
                            labels: {
                                step: 2,
                                rotation: 'auto'
                            },
                            title: {
                                text: '万元'
                            },
                            plotBands: [{
                                from: 0,
                                to: target[0] * 0.25,
                                color: '#DF5353'
                            }, {
                                from: target[0] * 0.25,
                                to: target[0] * 0.5,
                                color: '#DDDF0D'
                            }, {
                                from: target[0] * 0.5,
                                to: target[0] * 0.75,
                                color: '#FF9900'
                            }, {
                                from: target[0] * 0.75,
                                to: target[0],
                                color: '#55BF3B'
                            }, {
                                from: target[0],
                                to: tmax1,
                                color: '#66FF33'
                            }]
                        },

                        series: [{
                            name: '销售额',
                            data: [date[0] * 1],
                            tooltip: {
                                valueSuffix: '万元'
                            }
                        }]

                    },
                function (chart) {
                });

                    $('#container4').highcharts({
                        chart: {
                            type: 'gauge',
                            plotBackgroundColor: null,
                            plotBackgroundImage: null,
                            plotBorderWidth: 0,
                            plotShadow: false,
                            marginTop: 22,
                            marginBottom: 0
                        },

                        title: {
                            text: topic2 + "(" + parseInt((parseInt(vMon) + 2) / 3) + " 季度目标:" + target[1]+"万元)",

                            style: {
                                fontSize: '12px',
                                padding: '0 20',
                                textAlign: 'left'
                            }
                        },

                        pane: {
                            startAngle: -150,
                            endAngle: 150,
                            background: [{
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#FFF'],
                                        [1, '#333']
                                    ]
                                },
                                borderWidth: 0,
                                outerRadius: '109%'
                            }, {
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#333'],
                                        [1, '#FFF']
                                    ]
                                },
                                borderWidth: 1,
                                outerRadius: '107%'
                            }, {

                            }, {
                                backgroundColor: '#DDD',
                                borderWidth: 0,
                                outerRadius: '105%',
                                innerRadius: '103%'
                            }]
                        },

                        yAxis: {
                            min: 0,
                            max: tmax2,
                            minorTickInterval: 'auto',
                            minorTickWidth: 1,
                            minorTickLength: 10,
                            minorTickPosition: 'inside',
                            minorTickColor: '#666',

                            tickPixelInterval: 30,
                            tickWidth: 2,
                            tickPosition: 'inside',
                            tickLength: 10,
                            tickColor: '#666',
                            labels: {
                                step: 2,
                                rotation: 'auto'
                            },
                            title: {
                                text: '万元'
                            },
                            plotBands: [{
                                from: 0,
                                to: target[1] * 0.25,
                                color: '#DF5353'
                            }, {
                                from: target[1] * 0.25,
                                to: target[1] * 0.5,
                                color: '#DDDF0D'
                            }, {
                                from: target[1] * 0.5,
                                to: target[1] * 0.75,
                                color: '#FF9900'
                            }, {
                                from: target[1] * 0.75,
                                to: target[1],
                                color: '#55BF3B'
                            }, {
                                from: target[1],
                                to: tmax2,
                                color: '#66FF33'
                            }]
                        },

                        series: [{
                            name: '销售额',
                            data: [date[1] * 1],
                            tooltip: {
                                valueSuffix: '万元'
                            }
                        }]

                    },
                      function (chart) {
                      });
                }, "json");

                $.post('/json/PublicHandler.ashx?Method=SearchBaihuoTaskByYear&year=' + vYear, function (item) {
                    var target = item[1];
                    var date = item[0];
                    var CST = item[2];
                    var CR = item[3];
                    var tmax1 = 1.25 * target[0];
                    var tmax2 = 1.25 * target[1];
                    document.getElementById("cst5").innerHTML = CST[0] + "%";
                    document.getElementById("cst6").innerHTML = CST[1] + "%";
                    document.getElementById("cr5").innerHTML = CR[0] + "%";
                    document.getElementById("cr6").innerHTML = CR[1] + "%";
                    $('#container5').highcharts({
                        chart: {
                            type: 'gauge',
                            plotBackgroundColor: null,
                            plotBackgroundImage: null,
                            plotBorderWidth: 0,
                            plotShadow: false,
                            marginTop: 22,
                            marginBottom: 0
                        },
                        title: {
                            text: topic1 + "(年度目标:" + target[0] + "万元)",

                            style: {
                                fontSize: '12px',
                                textAlign: 'left'
                            },
                        },

                        pane: {
                            startAngle: -150,
                            endAngle: 150,
                            background: [{
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#FFF'],
                                        [1, '#333']
                                    ]
                                },
                                borderWidth: 0,
                                outerRadius: '109%'
                            }, {
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#333'],
                                        [1, '#FFF']
                                    ]
                                },
                                borderWidth: 1,
                                outerRadius: '107%'
                            }, {
                            }, {
                                backgroundColor: '#DDD',
                                borderWidth: 0,
                                outerRadius: '105%',
                                innerRadius: '103%'
                            }]
                        },
                        yAxis: {
                            min: 0,
                            max: tmax1,
                            minorTickInterval: 'auto',
                            minorTickWidth: 1,
                            minorTickLength: 10,
                            minorTickPosition: 'inside',
                            minorTickColor: '#666',

                            tickPixelInterval: 30,
                            tickWidth: 2,
                            tickPosition: 'inside',
                            tickLength: 10,
                            tickColor: '#666',
                            labels: {
                                step: 2,
                                rotation: 'auto'
                            },
                            title: {
                                text: '万元'
                            },
                            plotBands: [{
                                from: 0,
                                to: target[0] * 0.25,
                                color: '#DF5353'
                            }, {
                                from: target[0] * 0.25,
                                to: target[0] * 0.5,
                                color: '#DDDF0D'
                            }, {
                                from: target[0] * 0.5,
                                to: target[0] * 0.75,
                                color: '#FF9900'
                            }, {
                                from: target[0] * 0.75,
                                to: target[0],
                                color: '#55BF3B'
                            }, {
                                from: target[0],
                                to: tmax1,
                                color: '#66FF33'
                            }]
                        },

                        series: [{
                            name: '销售额',
                            data: [date[0] * 1],
                            tooltip: {
                                valueSuffix: '万元'
                            }
                        }]

                    },
                function (chart) {
                });

                    $('#container6').highcharts({
                        chart: {
                            type: 'gauge',
                            plotBackgroundColor: null,
                            plotBackgroundImage: null,
                            plotBorderWidth: 0,
                            plotShadow: false,
                            marginTop: 22,
                            marginBottom: 0
                        },

                        title: {
                            text: topic2 + "(年度目标:" + target[1] + "万元)",

                            style: {
                                fontSize: '12px',
                                padding: '0 20',
                                textAlign: 'left'
                            }
                        },

                        pane: {
                            startAngle: -150,
                            endAngle: 150,
                            background: [{
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#FFF'],
                                        [1, '#333']
                                    ]
                                },
                                borderWidth: 0,
                                outerRadius: '109%'
                            }, {
                                backgroundColor: {
                                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                    stops: [
                                        [0, '#333'],
                                        [1, '#FFF']
                                    ]
                                },
                                borderWidth: 1,
                                outerRadius: '107%'
                            }, {

                            }, {
                                backgroundColor: '#DDD',
                                borderWidth: 0,
                                outerRadius: '105%',
                                innerRadius: '103%'
                            }]
                        },

                        yAxis: {
                            min: 0,
                            max: tmax2,
                            minorTickInterval: 'auto',
                            minorTickWidth: 1,
                            minorTickLength: 10,
                            minorTickPosition: 'inside',
                            minorTickColor: '#666',

                            tickPixelInterval: 30,
                            tickWidth: 2,
                            tickPosition: 'inside',
                            tickLength: 10,
                            tickColor: '#666',
                            labels: {
                                step: 2,
                                rotation: 'auto'
                            },
                            title: {
                                text: '万元'
                            },
                            plotBands: [{
                                from: 0,
                                to: target[1] * 0.25,
                                color: '#DF5353'
                            }, {
                                from: target[1] * 0.25,
                                to: target[1] * 0.5,
                                color: '#DDDF0D'
                            }, {
                                from: target[1] * 0.5,
                                to: target[1] * 0.75,
                                color: '#FF9900'
                            }, {
                                from: target[1] * 0.75,
                                to: target[1],
                                color: '#55BF3B'
                            }, {
                                from: target[1],
                                to: tmax2,
                                color: '#66FF33'
                            }]
                        },

                        series: [{
                            name: '销售额',
                            data: [date[1] * 1],
                            tooltip: {
                                valueSuffix: '万元'
                            }
                        }]

                    },
                      function (chart) {
                      });
                }, "json");


                $.post('/json/PublicHandler.ashx?Method=SearchBaihuoTrendbyMonth&year=' + vYear + "&month=" + vMon, function (item) {
                    var sale = item[0];
                    var date = item[1];

                    $('#trend').highcharts({
                        title: {
                            text: '番禺又一城销售额走势图',
                            x: 25
                        },
                        xAxis: {
                            categories: date
                        },
                        yAxis: {
                            title: {
                                text: '销售额 (万元)'
                            },
                            plotLines: [{
                                value: 0,
                                width: 1,
                                color: '#808080'
                            }]
                        },
                        tooltip: {
                            valueDecimals: 2,
                            valueSuffix: '万元'
                        },
                        series: [{
                            name: '销售额',
                            data: sale
                        }]
                    });

                    
                    loading.style.display = "none";
                    

                }, "json");

            });
        });
    </script>
    <script>
        $(function () {
            $('#dowebok').fullpage({
                navigation: true,
                verticalCentered: false,
                slidesNavigation: true,
                slidesNavPosition: 'bottom'
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
            <div id="dowebok">
                <div class="section">
                    <div class="slide">
                    <div id="container1" style="min-width: 107px; height: 190px; text-align: center"></div>

                    <div style="text-align: center; font-weight: 600">同比增长<span id="cst1" style="color: red"></span>销售完成率<span id="cr1" style="color: red"></span></div>
                    <div id="container2" style="min-width: 107px; height: 190px; text-align: center"></div>

                    <div style="text-align: center; font-weight: 600">同比增长<span id="cst2" style="color: red"></span>销售完成率<span id="cr2" style="color: red"></span></div>
                    </div>
                    <div class="slide"><div style="text-align:center"><img id="loading" src="images/loading.gif"/></div><div id="trend";style="min-width: 107px; height: 190px;"></div></div>
                </div>
                <div class="section">
                    <div id="container3" style="min-width: 107px; height: 190px; text-align: center"></div>

                    <div style="text-align: center; font-weight: 600">同比增长<span id="cst3" style="color: red"></span>销售完成率<span id="cr3" style="color: red"></span></div>
                    <div id="container4" style="min-width: 102px; height: 180px; text-align: center"></div>

                    <div style="text-align: center; font-weight: 600">同比增长<span id="cst4" style="color: red"></span>销售完成率<span id="cr4" style="color: red"></span></div>
                </div>
                   <div class="section">
                    <div id="container5" style="min-width: 107px; height: 190px; text-align: center"></div>

                    <div style="text-align: center; font-weight: 600">同比增长<span id="cst5" style="color: red"></span>销售完成率<span id="cr5" style="color: red"></span></div>
                    <div id="container6" style="min-width: 102px; height: 180px; text-align: center"></div>

                    <div style="text-align: center; font-weight: 600">同比增长<span id="cst6" style="color: red"></span>销售完成率<span id="cr6" style="color: red"></span></div>
                </div>
            </div>
            </div>
    </form>
    <script>
        var d = new Date();
        var vYear = d.getFullYear();
        var vMon = d.getMonth() + 1;
        $('#year').val(vYear);
        $('#month').val(vMon);
        var topic1 = 'A座销售达成情况';
        var topic2 = 'A+B座销售达成情况';
        if (vMon < 10) {
            vMon = "0" + vMon;
        }
        $.post('/json/PublicHandler.ashx?Method=SearchBaihuoTaskByMonth&year=' + vYear + "&month=" + vMon, function (item) {
            var target = item[1];
            var date = item[0];
            var CST = item[2];
            var CR = item[3];
            if (vMon == "02") {
                var tmax1 = 1.8 * target[0];
                var tmax2 = 1.8 * target[1];

            }
            else {
                var tmax1 = 1.25 * target[0];
                var tmax2 = 1.25 * target[1];
            }
            document.getElementById("cst1").innerHTML = CST[0]  + "%";
            document.getElementById("cst2").innerHTML = CST[1]  + "%";
            document.getElementById("cr1").innerHTML = CR[0]  + "%";
            document.getElementById("cr2").innerHTML = CR[1]  + "%";
            $('#container1').highcharts({
                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    marginTop: 22,
                    marginBottom: 0
                },
                title: {
                    text: topic1 + "(本月销售目标：" + target[0] + "万元)",
                    style: {
                        fontSize: '14px',
                    },
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },
                yAxis: {
                    min: 0,
                    max: tmax1,
                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: '万元'
                    },
                    plotBands: [{
                        from: 0,
                        to: target[0] * 0.25,
                        color: '#DF5353'
                    }, {
                        from: target[0] * 0.25,
                        to: target[0] * 0.5,
                        color: '#DDDF0D'
                    }, {
                        from: target[0] * 0.5,
                        to: target[0] * 0.75,
                        color: '#FF9900'
                    }, {
                        from: target[0] * 0.75,
                        to: target[0],
                        color: '#55BF3B'
                    }, {
                        from: target[0],
                        to: tmax1,
                        color: '#66FF33'
                    }]
                },

                series: [{
                    name: '销售额',
                    data: [date[0] * 1],
                    tooltip: {
                        valueSuffix: '万元'
                    }
                }]

            },
        function (chart) {
        });

            $('#container2').highcharts({
                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    marginTop: 22,
                    marginBottom: 0
                },

                title: {
                    text: topic2 + "(本月销售目标：" + target[1] + "万元)",
                    style: {
                        fontSize: '14px',
                        padding: '0 20'
                    }
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {

                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                yAxis: {
                    min: 0,
                    max: tmax2,
                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: '万元'
                    },
                    plotBands: [{
                        from: 0,
                        to: target[1] * 0.25,
                        color: '#DF5353'
                    }, {
                        from: target[1] * 0.25,
                        to: target[1] * 0.5,
                        color: '#DDDF0D'
                    }, {
                        from: target[1] * 0.5,
                        to: target[1] * 0.75,
                        color: '#FF9900'
                    }, {
                        from: target[1] * 0.75,
                        to: target[1],
                        color: '#55BF3B'
                    }, {
                        from: target[1],
                        to: tmax2,
                        color: '#66FF33'
                    }]
                },

                series: [{
                    name: '销售额',
                    data: [date[1] * 1],
                    tooltip: {
                        valueSuffix: '万元'
                    }
                }]

            },
              function (chart) {
              });
        }, "json");

        $.post('/json/PublicHandler.ashx?Method=SearchBaihuoTaskBySeason&year=' + vYear + "&month=" + vMon, function (item) {
            var target = item[1];
            var date = item[0];
            var CST = item[2];
            var CR = item[3];
            var tmax1 = 1.25 * target[0];
            var tmax2 = 1.25 * target[1];
            document.getElementById("cst3").innerHTML = CST[0]  + "%";
            document.getElementById("cst4").innerHTML = CST[1]  + "%";
            document.getElementById("cr3").innerHTML = CR[0]  + "%";
            document.getElementById("cr4").innerHTML = CR[1]  + "%";
            $('#container3').highcharts({
                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    marginTop: 22,
                    marginBottom: 0
                },
                title: {
                    text: topic1 + "(" + parseInt((parseInt(vMon) + 2) / 3) + " 季度目标:" + target[0]+"万元)",
                    style: {
                        fontSize: '12px',
                      
                    },
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },
                yAxis: {
                    min: 0,
                    max: tmax1,
                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: '万元'
                    },
                    plotBands: [{
                        from: 0,
                        to: target[0] * 0.25,
                        color: '#DF5353'
                    }, {
                        from: target[0] * 0.25,
                        to: target[0] * 0.5,
                        color: '#DDDF0D'
                    }, {
                        from: target[0] * 0.5,
                        to: target[0] * 0.75,
                        color: '#FF9900'
                    }, {
                        from: target[0] * 0.75,
                        to: target[0],
                        color: '#55BF3B'
                    }, {
                        from: target[0],
                        to: tmax1,
                        color: '#66FF33'
                    }]
                },

                series: [{
                    name: '销售额',
                    data: [date[0] * 1],
                    tooltip: {
                        valueSuffix: '万元'
                    }
                }]

            },
        function (chart) {
        });

            $('#container4').highcharts({
                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    marginTop: 22,
                    marginBottom: 0
                },

                title: {
                text: topic2 + "("+parseInt((parseInt(vMon)+2)/3) +" 季度目标:"+ target[1]+"万元)",
                    style: {
                        fontSize: '12px',
                        padding: '0 20',
                        
                    }
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {

                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                yAxis: {
                    min: 0,
                    max: tmax2,
                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: '万元'
                    },
                    plotBands: [{
                        from: 0,
                        to: target[1] * 0.25,
                        color: '#DF5353'
                    }, {
                        from: target[1] * 0.25,
                        to: target[1] * 0.5,
                        color: '#DDDF0D'
                    }, {
                        from: target[1] * 0.5,
                        to: target[1] * 0.75,
                        color: '#FF9900'
                    }, {
                        from: target[1] * 0.75,
                        to: target[1],
                        color: '#55BF3B'
                    }, {
                        from: target[1],
                        to: tmax2,
                        color: '#66FF33'
                    }]
                },

                series: [{
                    name: '销售额',
                    data: [date[1] * 1],
                    tooltip: {
                        valueSuffix: '万元'
                    }
                }]

            },
              function (chart) {
              });
        }, "json");


        $.post('/json/PublicHandler.ashx?Method=SearchBaihuoTaskByYear&year=' + vYear, function (item) {
            var target = item[1];
            var date = item[0];
            var CST = item[2];
            var CR = item[3];
            var tmax1 = 1.25 * target[0];
            var tmax2 = 1.25 * target[1];
            document.getElementById("cst5").innerHTML = CST[0] + "%";
            document.getElementById("cst6").innerHTML = CST[1] + "%";
            document.getElementById("cr5").innerHTML = CR[0] + "%";
            document.getElementById("cr6").innerHTML = CR[1] + "%";
            $('#container5').highcharts({
                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    marginTop: 22,
                    marginBottom: 0
                },
                title: {
                    text: topic1 + "(年度目标:" + target[0] + "万元)",

                    style: {
                        fontSize: '12px',
                        textAlign: 'left'
                    },
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {
                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },
                yAxis: {
                    min: 0,
                    max: tmax1,
                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: '万元'
                    },
                    plotBands: [{
                        from: 0,
                        to: target[0] * 0.25,
                        color: '#DF5353'
                    }, {
                        from: target[0] * 0.25,
                        to: target[0] * 0.5,
                        color: '#DDDF0D'
                    }, {
                        from: target[0] * 0.5,
                        to: target[0] * 0.75,
                        color: '#FF9900'
                    }, {
                        from: target[0] * 0.75,
                        to: target[0],
                        color: '#55BF3B'
                    }, {
                        from: target[0],
                        to: tmax1,
                        color: '#66FF33'
                    }]
                },

                series: [{
                    name: '销售额',
                    data: [date[0] * 1],
                    tooltip: {
                        valueSuffix: '万元'
                    }
                }]

            },
        function (chart) {
        });

            $('#container6').highcharts({
                chart: {
                    type: 'gauge',
                    plotBackgroundColor: null,
                    plotBackgroundImage: null,
                    plotBorderWidth: 0,
                    plotShadow: false,
                    marginTop: 22,
                    marginBottom: 0
                },

                title: {
                    text: topic2 + "(年度目标:" + target[1] + "万元)",

                    style: {
                        fontSize: '12px',
                        padding: '0 20',
                        textAlign: 'left'
                    }
                },

                pane: {
                    startAngle: -150,
                    endAngle: 150,
                    background: [{
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#FFF'],
                                [1, '#333']
                            ]
                        },
                        borderWidth: 0,
                        outerRadius: '109%'
                    }, {
                        backgroundColor: {
                            linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                            stops: [
                                [0, '#333'],
                                [1, '#FFF']
                            ]
                        },
                        borderWidth: 1,
                        outerRadius: '107%'
                    }, {

                    }, {
                        backgroundColor: '#DDD',
                        borderWidth: 0,
                        outerRadius: '105%',
                        innerRadius: '103%'
                    }]
                },

                yAxis: {
                    min: 0,
                    max: tmax2,
                    minorTickInterval: 'auto',
                    minorTickWidth: 1,
                    minorTickLength: 10,
                    minorTickPosition: 'inside',
                    minorTickColor: '#666',

                    tickPixelInterval: 30,
                    tickWidth: 2,
                    tickPosition: 'inside',
                    tickLength: 10,
                    tickColor: '#666',
                    labels: {
                        step: 2,
                        rotation: 'auto'
                    },
                    title: {
                        text: '万元'
                    },
                    plotBands: [{
                        from: 0,
                        to: target[1] * 0.25,
                        color: '#DF5353'
                    }, {
                        from: target[1] * 0.25,
                        to: target[1] * 0.5,
                        color: '#DDDF0D'
                    }, {
                        from: target[1] * 0.5,
                        to: target[1] * 0.75,
                        color: '#FF9900'
                    }, {
                        from: target[1] * 0.75,
                        to: target[1],
                        color: '#55BF3B'
                    }, {
                        from: target[1],
                        to: tmax2,
                        color: '#66FF33'
                    }]
                },

                series: [{
                    name: '销售额',
                    data: [date[1] * 1],
                    tooltip: {
                        valueSuffix: '万元'
                    }
                }]

            },
              function (chart) {
              });
        }, "json");

        $.post('/json/PublicHandler.ashx?Method=SearchBaihuoTrendbyMonth&year=' + vYear + "&month=" + vMon, function (item) {
                var sale = item[0];
                var date = item[1];

                $('#trend').highcharts({
                    title: {
                        text: '番禺又一城销售额走势图',
                        x: 25
                    },
                    xAxis: {
                        categories: date
                    },
                    yAxis: {
                        title: {
                            text: '销售额 (万元)'
                        },
                        plotLines: [{
                            value: 0,
                            width: 1,
                            color: '#808080'
                        }]
                    },
                    tooltip: {
                        valueDecimals: 2,
                        valueSuffix: '万元'
                    },
                    series: [{
                        name: '销售额',
                        data: sale
                    }]
                });

                var loading = document.getElementById("loading");
                loading.style.display = "none";

            }, "json");
    </script>
</body>
</html>
