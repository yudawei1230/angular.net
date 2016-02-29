<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news_list.aspx.cs" Inherits="highsunMobileOA.news_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />    
    <link href="css/default.css" rel="stylesheet" />
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="page" class="type-interior">
            <div data-role="header" data-theme="b">
                <h1><%=Tlt %></h1>
            </div>
            <!-- /header -->

            <div data-role="content">
                <div class="content-primary">
                    <ul data-role="listview">
                        <%=Str %>
                    </ul>
                </div>
                <!--/content-primary -->



            </div>
            <!-- /content -->

            <div data-role="footer" class="footer-docs" data-theme="c">
                <p class="jqm-version"></p>
                <p>&copy; 2014 海印股份</p>
            </div>

        </div>
    </form>
</body>
</html>
