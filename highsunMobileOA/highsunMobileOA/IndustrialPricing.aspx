 
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndustrialPricing.aspx.cs" Inherits="highsunMobileOA.IndustrialPricing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>工业定价</title>
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/cookies_oper.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/highcharts-more.js"></script>
    <style type="text/css">
        .left{
            width:40%;
            height:50px;
            margin:10px 0px;
            padding:5px;
            background:linear-gradient(#9dd2ea, #8bceec);
            background:-o-linear-gradient(#9dd2ea, #8bceec);
            background:-webkit-linear-gradient(#9dd2ea, #8bceec);
            background:-moz-linear-gradient(#9dd2ea, #8bceec);
            border-radius:5px;
            box-shadow:0 7px 8px #0000ff;
            float: left;
        }

        #proID{
            width:70px;
        }

        .allmsg{
            height: 80px;
            padding: 0px;
            width:100%;
            float:left;
        }

        .middle{
            height:auto;
            float: left;
            margin: 3px 3px;
        }
        .right {
            float:left;
            width:53%;
        }
        .r2 {
            width:100%;
            height:25px;
            margin:0px 0px;
            padding:3px;
            vertical-align:middle;
            line-height:16px;
            background:linear-gradient(#9dd2ea, #8bceec);
            background:-o-linear-gradient(#9dd2ea, #8bceec);
            background:-webkit-linear-gradient(#9dd2ea, #8bceec);
            background:-moz-linear-gradient(#9dd2ea, #8bceec);
            border-radius:5px;
            box-shadow:0 2px 3px #0000ff;
            clear:left
        }
        .input {
            width:60%;
            height:10px !important;
            padding:0px;
            margin-top: 0px;
            margin-bottom: 0px;
            
        }
        .input.ui-input-text, textarea.ui-input-text{
            width: 20px;
            height: 12px;
            padding-bottom: 0px;
            padding: 0px 5px 0px 5px;
            margin-top: 0px;
            margin-bottom: 0px;
            float:right;
        }
        .ui-input-text ui-body-c {            
            padding-top: 0px;
            padding-bottom: 0px;
            width: 20px;
            height: 12px;
            margin-top: 0px;
            margin-bottom: 0px;
        }
        .ui-input-text ui-shadow-inset ui-corner-all ui-btn-shadow ui-body-c {
            width: 100px;
            height: 12px;            
            margin-top: 0px;
            margin-bottom: 0px;
        }
        .ui-input-search, div.ui-input-text {
            
            margin-top: 0px;
            margin-bottom: 0px;
            padding-right: 5px;
            padding-left: 5px;            
            height:22px;
            min-height: 10px !important;
            line-height:10px !important;
        }
        .rightDetail {
            float:left;
            line-height: 22px;
            width:50%;
            text-align:center
        }

        .rightDetailInput {
        margin:0px;
        width:50%;
        float:right;
        }
        .leftDetail {
            margin:0px 0px;
            text-align:center;
        }
        .ui-btn {
            height: 30px;
            margin:0px auto;
            width:100px;
            margin-left:10px;
        }
        .ui-btn-inner {
            padding:0px 0px;
            line-height:30px;
        }
        #Cost {
            padding:0px;
            margin-top:3px;
            text-align:center;
        }
        #ProductSales {
            padding:0px;
            margin-top:3px;
            text-align:center;
        }
        .btn-div {
            width:100%;
            text-align:center;
            float:left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
           
            <div data-role="content">
                <div class="allmsg">
                    <div class="left">
                        <div class="leftDetail">销售额</div>
                        <div id="ProductSales"></div>
                    </div>        
                    <div class="middle"><h2><strong>=</strong></h2></div>
                    <div class="right">
                        <div class="r2"><div class="rightDetail">单价</div><div class="rightDetailInput"><input id="price" type="text" style="padding:0px;text-align:center" value="" /></div></div>
                        <h2 style="margin-bottom: 0px;margin-top: 0px;text-align: center;">×</h2>
                        <div class="r2" ><div class="rightDetail">产量</div><div class="rightDetailInput"><input id="output" type="text" style="padding:0px;text-align:center" value="" /></div></div>
                    </div>
                </div>

                <div style="width:15%;height:5px;float:left;">&nbsp</div><div style="width:10%;height:5px;float:left;border-top:3px solid"></div>
                <div class="allmsg">
                    <div class="left">
                        <div class="leftDetail">原料成本</div>
                        <div id="Cost"></div>
                    </div>        
                    <div class="middle"><h2><strong>=</strong></h2></div>
                    <div class="right">
                        <div class="r2"><div class="rightDetail">原料单价</div><div class="rightDetailInput"><input id="rawMaterialUnitPrice" type="text" style="padding:0px;text-align:center" value="" /></div></div>
                        <h2 style="margin-bottom: 0px;margin-top: 0px;text-align: center;">×</h2>
                        <div class="r2"><div class="rightDetail">用量</div><div class="rightDetailInput"><input id="rawMaterialInput" type="text" style="padding:0px;text-align:center" value="" /></div></div>
                    </div>
                </div>


                <div style="width:15%;height:5px;float:left;">&nbsp</div><div style="width:10%;height:5px;float:left;border-top:3px solid"></div>
                <div class="allmsg">
                    <div class="left">
                        <div class="leftDetail">其他成本</div>
                        <div class="rightDetailInput" style="width:100%"><input id="otherCost" type="text" style="padding:0px;text-align:center" value="" /></div>
                    </div>
                </div>

                <div style="width:15%;height:10px;float:left;">&nbsp</div><div style="width:10%;height:10px;float:left;border-top:3px solid;border-bottom:3px solid"></div>
                <div class="allmsg">
                    <div class="left">
                        <div class="leftDetail">目标利润</div>
                        <div class="rightDetailInput" style="width:100%"><input id="targetProfit" type="text" style="padding:0px;text-align:center" value="" /></div>
                    </div>
                </div>
                <div class="btn-div">
                 <input type="button" value="计算" onclick='calculate()' data-inline="true"/>
                 <input type="button" value="清除" onclick='clean()' data-inline="true"/> 
                </div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2015 海印股份</p>
            </div>
        </div>
    </form>
    <script>
        $(document).ready(function () {
            $('#rawMaterialInput,#rawMaterialUnitPrice').blur(function () {
                $('#Cost')[0].innerHTML = accMul($('#rawMaterialUnitPrice').val(), $('#rawMaterialInput').val());
                if ($('#price').val() == 0 || $('#output').val() == 0) {
                    $('#ProductSales')[0].innerHTML = accAdd(accAdd($('#targetProfit').val(), $('#otherCost').val()), $('#Cost').html());
                }
            });
            $('#targetProfit,#otherCost').blur(function () {
                if ($('#price').val() == 0 || $('#output').val() == 0) {
                    $('#ProductSales')[0].innerHTML = accAdd(accAdd($('#targetProfit').val(), $('#otherCost').val()), $('#Cost').html());
                }
            });
            $('#price,#output').blur(function () {
                if ($('#price').val() != 0 && $('#output').val() != 0) {
                    $('#ProductSales')[0].innerHTML = accMul($('#price').val(), $('#output').val());
                }
            });

        })
        var msg="";
        function calculate() {
            if(
            /^[0-9]+(.[0-9]{1,3})?$/.test($('#price').val())&&
            /^[0-9]+(.[0-9]{1,3})?$/.test($('#output').val()) &&
            /^[0-9]+(.[0-9]{1,3})?$/.test($('#rawMaterialUnitPrice').val()) &&
            /^[0-9]+(.[0-9]{1,3})?$/.test($('#rawMaterialInput').val()) &&
            /^[0-9]+(.[0-9]{1,3})?$/.test($('#otherCost').val()) &&
            /^[0-9]+(.[0-9]{1,3})?$/.test($('#targetProfit').val())){
                msg = "计算前请确保需计算值为空";
                alert(msg);
            }
            else if (                                                            //计算单价
            checkOutput($('#output').val()) ==true &&
            (checkRawMaterialUnitPrice($('#rawMaterialUnitPrice').val()) ==true)  &&
            (checkRawMaterialInput($('#rawMaterialInput').val()) ==true)  &&
            (checkOtherCost($('#otherCost').val()) ==true) &&
            (checkTargetProfit($('#targetProfit').val()) == true) &&
            ($('#price').val()=="")) {
                $('#Cost')[0].innerHTML = accMul($('#rawMaterialUnitPrice').val(), $('#rawMaterialInput').val());
                var ProductSales =accAdd(accAdd($('#targetProfit').val(),$('#otherCost').val()),$('#Cost').html());
                $('#ProductSales')[0].innerHTML = ProductSales;
                $('#price').val(Math.round(accDiv($('#ProductSales').html(), $('#output').val()) * 1000) / 1000);
            }else if(                                                       //计算产量   
            checkPrice($('#price').val()) ==true &&
            checkRawMaterialUnitPrice($('#rawMaterialUnitPrice').val()) ==true  &&
            checkRawMaterialInput($('#rawMaterialInput').val()) ==true  &&
            checkOtherCost($('#otherCost').val()) ==true &&
            checkTargetProfit($('#targetProfit').val()) == true &&
            $('#output').val() == "") {
                $('#Cost')[0].innerHTML = accMul($('#rawMaterialUnitPrice').val(), $('#rawMaterialInput').val());
                var ProductSales = accAdd(accAdd($('#targetProfit').val(), $('#otherCost').val()), $('#Cost').html());
                $('#ProductSales')[0].innerHTML = ProductSales;
                $('#output').val(Math.round(accDiv($('#ProductSales').html(), $('#price').val()) * 1000) / 1000);
            } else if (                                                     //计算原料单价
            checkPrice($('#price').val()) == true &&
            checkOutput($('#output').val()) == true &&
            checkRawMaterialInput($('#rawMaterialInput').val()) == true &&
            checkOtherCost($('#otherCost').val()) == true &&
            checkTargetProfit($('#targetProfit').val()) == true &&
            $('#rawMaterialUnitPrice').val() == "") {
                $('#ProductSales')[0].innerHTML = accMul($('#price').val(), $('#output').val());
                $('#Cost')[0].innerHTML = Subtr(Subtr($('#ProductSales').html(), $('#otherCost').val()), $('#targetProfit').val());
                $('#rawMaterialUnitPrice').val(Math.round(accDiv($('#Cost').html(), $('#rawMaterialInput').val()) * 1000) / 1000);
            } else if (                                                     //计算原料用量
            checkPrice($('#price').val()) == true &&
            checkOutput($('#output').val()) == true &&
            checkRawMaterialUnitPrice($('#rawMaterialUnitPrice').val()) == true &&
            checkOtherCost($('#otherCost').val()) == true &&
            checkTargetProfit($('#targetProfit').val()) == true &&
            $('#rawMaterialInput').val() == "") {
                $('#ProductSales')[0].innerHTML = accMul($('#price').val(), $('#output').val());
                $('#Cost')[0].innerHTML = Subtr(Subtr($('#ProductSales').html(), $('#otherCost').val()), $('#targetProfit').val());
                $('#rawMaterialInput').val(Math.round(accDiv($('#Cost').html(), $('#rawMaterialUnitPrice').val())*1000)/1000);
            } else if (                                                     //计算目标利润
            checkPrice($('#price').val()) == true &&
            checkOutput($('#output').val()) == true &&
            checkRawMaterialUnitPrice($('#rawMaterialUnitPrice').val()) == true &&
            checkOtherCost($('#otherCost').val()) == true &&
            checkRawMaterialInput($('#rawMaterialInput').val()) == true &&
            $('#targetProfit').val() == "") {
                $('#ProductSales')[0].innerHTML = accMul($('#price').val(), $('#output').val());
                $('#Cost')[0].innerHTML = accMul($('#rawMaterialUnitPrice').val(), $('#rawMaterialInput').val());
                $('#targetProfit').val(Math.round(Subtr(Subtr($('#ProductSales').html(), $('#Cost').html()), $('#otherCost').val())*1000)/1000);
            }
            else {
                    alert(msg);
            }
            msg = "";
        }

        function clean() {
            msg = "";
            $('#price').val("");
            $('#output').val("");
            $('#rawMaterialUnitPrice').val("");
            $('#rawMaterialInput').val("");
            $('#ProductSales')[0].innerHTML = null;
            $('#otherCost').val("");
            $('#Cost')[0].innerHTML = null;
            $('#targetProfit').val("");
        }

        function checkPrice(price) {
            if (/^[0-9]+(.[0-9]{1,3})?$/.test(price)) {
                return true;
            } else {
                msg = "产品单价必须是3位小数以内的正实数";
                return false;
            }
        }

        function checkOutput(output) {
            if (/^[0-9]+(.[0-9]{1,3})?$/.test(output)) {
                return true;
            } else {
                msg ="产量必须是3位小数以内的正实数";
                return false;
            }
        }

        function checkRawMaterialUnitPrice(rawMaterialUnitPrice) {
            if (/^[0-9]+(.[0-9]{1,3})?$/.test(rawMaterialUnitPrice)) {
                return true;
            } else {
                msg = "原材料单价必须是3位小数以内的正实数";
                return false;
            }
        }
        
        function checkRawMaterialInput(rawMaterialInput) {
            if (/^[0-9]+(.[0-9]{1,3})?$/.test(rawMaterialInput)) {
                return true;
            } else {
                msg = "原材料用量必须是3位小数以内的正实数";
                return false;
            }
        }
        
        function checkOtherCost(otherCost) {
            if (/^[0-9]+(.[0-9]{1,3})?$/.test(otherCost)) {
                return true;
            } else {
                msg = "其他成本必须是3位小数以内的正实数";
                return false;
            }
        }

        function checkTargetProfit(targetProfit) {
            if (/^[0-9]+(.[0-9]{1,3})?$/.test(targetProfit)) {
                return true;
            } else {
                msg = "目标利润必须是3位小数以内的正实数";
                return false;
            }
        }
        

        function accMul(arg1, arg2) {           //去精度乘法
            var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
            try { m += s1.split(".")[1].length } catch (e) { }
            try { m += s2.split(".")[1].length } catch (e) { }
            return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m)
        }

        function accAdd(arg1, arg2) {           //去精度加法
            var r1, r2, m;
            try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
            try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
            m = Math.pow(10, Math.max(r1, r2))  
            return (arg1 * m + arg2 * m) / m
        }
        function Subtr(arg1, arg2) {            //去精度减法
            var r1, r2, m, n;
            try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
            try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
            m = Math.pow(10, Math.max(r1, r2));
            //last modify by deeka
            //动态控制精度长度
            n = (r1 >= r2) ? r1 : r2;
            return ((arg1 * m - arg2 * m) / m).toFixed(n);
        }
        function accDiv(arg1, arg2) {            //去精度除法
            var t1 = 0, t2 = 0, r1, r2;
            try { t1 = arg1.toString().split(".")[1].length } catch (e) { }
            try { t2 = arg2.toString().split(".")[1].length } catch (e) { }
            with (Math) {
                r1 = Number(arg1.toString().replace(".", ""))
                r2 = Number(arg2.toString().replace(".", ""))
                return (r1 / r2) * pow(10, t2 - t1);
            }
        }



    </script>

</body>
</html>

 
