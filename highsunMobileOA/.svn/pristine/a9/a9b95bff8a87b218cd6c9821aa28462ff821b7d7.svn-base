<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buy.aspx.cs" Inherits="highsunMobileOA.buy" %>

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
</head>
<body>


    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="header" data-theme="b">
                <h1>消费记录</h1>
            </div>

            <div data-role="content">                
                <div class="ui-grid-b" id="buylgo">
                    
                </div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2014 海印股份</p>
            </div>

        </div>
    </form>
    <script>
        $(document).ready(function () {
            $.post('/json/PublicHandler.ashx?Method=BuyLog&name=' + getCookie("LoginName"), function (result) {
                if (result.success) {
                    $("#buylgo").html(result.msg);
                }
                else {

                    alert(result.msg);
                }

            }, "json");
        });
    </script>
</body>
</html>
