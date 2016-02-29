<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baihuoVIPDayReport.aspx.cs" Inherits="highsunMobileOA.baihuoVIPDayReport" %>

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
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <script src="js/jquery.fullPage.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#eday').change(function () {

                var loading = document.getElementById("loading");
                loading.style.display = "inline-block";

                var vipreport = document.getElementById("vipreport");
                vipreport.style.display = "none";

               

                var sYear = $('#syear').val();
                var sMon = $('#smonth').val();
                var sDay = $('#sday').val();

                if (sMon < 10) {
                    sMon = "0" + sMon;
                }

                if (sDay < 10) {
                    sDay = "0" + sDay;
                }
                var sdate = sYear + '-' + sMon + '-' + sDay;
                
                var eYear = $('#eyear').val();
                var eMon = $('#emonth').val();
                var eDay = $('#eday').val();

                if (eMon < 10) {
                    eMon = "0" + eMon;
                }

                if (eDay < 10) {
                    eDay = "0" + eDay;
                }
                var edate = eYear + '-' + eMon + '-' + eDay;

                $.post('/json/PublicHandler.ashx?Method=SearchBaihuoVIPDayReport&sdate=' + sdate + '&edate=' + edate, function (item) {
                          var result = item[0];
                          var KDS = item[1];
                          var VIPKDS = item[2];
                          var KDSProportion = item[3];
                          var TotalXFJE = item[4];
                          var VIPXFJE = item[5];
                          var VIPXFJEProportion = item[6];
                          var text = "";
                          if (result.length != 0) {
                              for (var i = 0; i < result.length; i++) {
                                  text = text + result[i];
                              }
                              $("#vipreport").html(text);
                              $('#container').highcharts({
                                  chart: {
                                      type: 'bar'
                                  },
                                  title: {
                                      text: '又一城百货会员消费占比分析'
                                  },

                                  xAxis: {
                                      categories: '又一城百货会员消费占比分析',
                                      title: {
                                          text: null
                                      }
                                  },
                                  yAxis: {
                                      min: 0,
                                      title: {
                                          text: '客单数(笔)/消费额(元)',
                                          align: 'high'
                                      },
                                      labels: {
                                          overflow: 'justify'
                                      }
                                  },
                                  tooltip: {
                                      valueSuffix: ''
                                  },
                                  plotOptions: {
                                      bar: {
                                          dataLabels: {
                                              enabled: true
                                          }
                                      }
                                  },
                                  legend: {
                                      layout: 'vertical',
                                      align: 'right',
                                      verticalAlign: 'top',
                                      x: -5,
                                      y: 40,
                                      floating: true,
                                      borderWidth: 1,
                                      backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
                                      shadow: true
                                  },
                                  credits: {
                                      enabled: false
                                  },
                                  series: [{
                                      name: '客单数',
                                      data: KDS
                                  }, {
                                      name: '会员客单数',
                                      data: VIPKDS
                                  }, {
                                      name: '会员客单数占比',
                                      data: KDSProportion
                                  }, {
                                      name: '总消费金额',
                                      data: TotalXFJE
                                  }, {
                                      name: '会员消费金额',
                                      data: VIPXFJE
                                  }, {
                                      name: '会员消费金额占比',
                                      data: VIPXFJEProportion
                                  }]
                              });
                          }
                          else {
                              alert("无可用数据！");
                          }

                          loading.style.display = "none";
                          vipreport.style.display = "block";

                      }, "json");

            });

            $('#sday').change(function () {

                var loading = document.getElementById("loading");
                loading.style.display = "inline-block";

                var vipreport = document.getElementById("vipreport");
                vipreport.style.display = "none";


                var sYear = $('#syear').val();
                var sMon = $('#smonth').val();
                var sDay = $('#sday').val();

                if (sMon < 10) {
                    sMon = "0" + sMon;
                }

                if (sDay < 10) {
                    sDay = "0" + sDay;
                }
                var sdate = sYear + '-' + sMon + '-' + sDay;

                var eYear = $('#eyear').val();
                var eMon = $('#emonth').val();
                var eDay = $('#eday').val();

                if (eMon < 10) {
                    eMon = "0" + eMon;
                }

                if (eDay < 10) {
                    eDay = "0" + eDay;
                }
                var edate = eYear + '-' + eMon + '-' + eDay;

                $.post('/json/PublicHandler.ashx?Method=SearchBaihuoVIPDayReport&sdate=' + sdate + '&edate=' + edate, function (item) {
                    var result = item[0];
                    var KDS = item[1];
                    var VIPKDS = item[2];
                    var KDSProportion = item[3];
                    var TotalXFJE = item[4];
                    var VIPXFJE = item[5];
                    var VIPXFJEProportion = item[6];
                    var text = "";
                    if (result.length != 0) {
                        for (var i = 0; i < result.length; i++) {
                            text = text + result[i];
                        }
                        $("#vipreport").html(text);
                        $('#container').highcharts({
                            chart: {
                                type: 'bar'
                            },
                            title: {
                                text: '又一城百货会员消费占比分析'
                            },

                            xAxis: {
                                categories: '又一城百货会员消费占比分析',
                                title: {
                                    text: null
                                }
                            },
                            yAxis: {
                                min: 0,
                                title: {
                                    text: '客单数(笔)/消费额(元)',
                                    align: 'high'
                                },
                                labels: {
                                    overflow: 'justify'
                                }
                            },
                            tooltip: {
                                valueSuffix: ''
                            },
                            plotOptions: {
                                bar: {
                                    dataLabels: {
                                        enabled: true
                                    }
                                }
                            },
                            legend: {
                                layout: 'vertical',
                                align: 'right',
                                verticalAlign: 'top',
                                x: -5,
                                y: 40,
                                floating: true,
                                borderWidth: 1,
                                backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
                                shadow: true
                            },
                            credits: {
                                enabled: false
                            },
                            series: [{
                                name: '客单数',
                                data: KDS
                            }, {
                                name: '会员客单数',
                                data: VIPKDS
                            }, {
                                name: '会员客单数占比',
                                data: KDSProportion
                            }, {
                                name: '总消费金额',
                                data: TotalXFJE
                            }, {
                                name: '会员消费金额',
                                data: VIPXFJE
                            }, {
                                name: '会员消费金额占比',
                                data: VIPXFJEProportion
                            }]
                        });
                    }
                    else {
                        alert("无可用数据！");
                    }

                    loading.style.display = "none";
                    vipreport.style.display = "block";

                }, "json");

            });
        });

    </script>
</head>
<body>



    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="header" data-theme="b">
                <h1>番禺又一城会员分析表</h1>
            </div>
            <div data-role="fieldcontain">

                <fieldset data-role="controlgroup" data-type="horizontal">

                    <select name="syear" id="syear">
                        <option value="2015">2015</option>
                        <option value="2016">2016</option>
                        <option value="2017">2017</option>
                        <option value="2018">2018</option>
                        <option value="2019">2019</option>
                        <option value="2020">2020</option>
                    </select>

                    <select name="smonth" id="smonth">
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

                    <select name="sday" id="sday">
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

                <fieldset data-role="controlgroup" data-type="horizontal">
                    <select name="eyear" id="eyear">
                        <option value="2015">2015</option>
                        <option value="2016">2016</option>
                        <option value="2017">2017</option>
                        <option value="2018">2018</option>
                        <option value="2019">2019</option>
                        <option value="2020">2020</option>
                    </select>

                    <select name="emonth" id="emonth">
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

                    <select name="eday" id="eday">
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
                <div class="ui-grid-d" id="vipreport">
                <div id="container" style="min-width: 280px; height: 400px"></div>
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
        var vMon = d.getMonth() + 1;
        var vDay = d.getDate();
        $('#syear').val(vYear);
        $('#smonth').val(vMon);
        $('#sday').val(vDay);
        $('#eyear').val(vYear);
        $('#emonth').val(vMon);
        $('#eday').val(vDay);
        if (vMon < 10) {
            vMon = "0" + vMon;
        }

        if (vDay < 10) {
            vDay = "0" + vDay;
        }
        var today = $('#year').val() + '-' + vMon + '-' + vDay;
        $.post('/json/PublicHandler.ashx?Method=SearchBaihuoVIPDayReport&sdate=' + today + '&edate='+ today, function (item) {
                  var result = item[0];
                  var KDS = item[1];
                  var VIPKDS = item[2];
                  var KDSProportion = item[3];
                  var TotalXFJE = item[4];
                  var VIPXFJE = item[5];
                  var VIPXFJEProportion = item[6];
                  var text = "";
                  if (result.length != 0) {
                      for (var i = 0; i < result.length; i++) {
                          text = text + result[i];
                      }
                      $("#vipreport").html(text);
                      $('#container').highcharts({
                          chart: {
                              type: 'bar'
                          },
                          title: {
                              text: '又一城百货会员消费占比分析'
                          },

                          xAxis: {
                              categories: '又一城百货会员消费占比分析',
                              title: {
                                  text: null
                              }
                          },
                          yAxis: {
                              min: 0,
                              title: {
                                  text: '客单数(笔)/消费额(元)',
                                  align: 'high'
                              },
                              labels: {
                                  overflow: 'justify'
                              }
                          },
                          tooltip: {
                              valueSuffix: ''
                          },
                          plotOptions: {
                              bar: {
                                  dataLabels: {
                                      enabled: true
                                  }
                              }
                          },
                          legend: {
                              layout: 'vertical',
                              align: 'right',
                              verticalAlign: 'top',
                              x: -5,
                              y: 40,
                              floating: true,
                              borderWidth: 1,
                              backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
                              shadow: true
                          },
                          credits: {
                              enabled: false
                          },
                          series: [{
                              name: '客单数',
                              data: KDS
                          }, {
                              name: '会员客单数',
                              data: VIPKDS
                          }, {
                              name: '会员客单数占比',
                              data: KDSProportion
                          }, {
                              name: '总消费金额',
                              data: TotalXFJE
                          }, {
                              name: '会员消费金额',
                              data: VIPXFJE
                          }, {
                              name: '会员消费金额占比',
                              data: VIPXFJEProportion
                          }]
                      });
                  }
                  else {
                      alert("无可用数据！");
                  }

                  var loading = document.getElementById("loading");
                  loading.style.display = "none";

              }, "json");

    </script>
</body>
</html>
