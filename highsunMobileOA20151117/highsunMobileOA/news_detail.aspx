<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news_detail.aspx.cs" Inherits="highsunMobileOA.news_detail" %>

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
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="content">
            <%=Str %>
        </div>
    </form>
    <script type="text/ecmascript">
        $(function () {
            $("img").attr("style", "");
            //$("img").after("<br>");
            //$("img").css("max-width", "320px");
        });
    </script>
    
</body>
</html>
