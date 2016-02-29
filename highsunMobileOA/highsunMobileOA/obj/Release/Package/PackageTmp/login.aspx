<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="highsunMobileOA.login" %>

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
            $("#login").click(function () {
                $.post('/json/PublicHandler.ashx?Method=UserLogin&user=' + $('#username').val() + '&pwd=' + $('#password').val(), function (result) {

                    if (result.success) {
                        location.href = "attendance.aspx";
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
                <h1>用户登录</h1>
            </div>
            <div data-role="content">
                <div data-role="fieldcontain">

                    <input id="username" name="username" type="text" placeholder="请输入登录账号" />
                    <br />
                    <input id="password" name="password" type="password" placeholder="请输入登录密码" />
                    <br />
                    <input id="login" type="button" value="登录" />
                </div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2014 海印股份</p>
            </div>

        </div>
    </form>
</body>
</html>
