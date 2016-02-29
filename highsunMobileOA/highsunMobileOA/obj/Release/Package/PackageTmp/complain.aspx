<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="complain.aspx.cs" Inherits="highsunMobileOA.complain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/default.css" rel="stylesheet" />
    <link href="css/themes/default/jquery.mobile-1.3.0-beta.1.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mobile-1.3.0-beta.1.js"></script>
    <script src="js/jquery.iosslider.js"></script>
    <script src="js/common.js?ver=5678"></script>
    <script src="js/add_product.js"></script>
    <%--<script src="js/jquery.confirm.js"></script>--%>

    <script type="text/javascript">
        $(function () {
           
            $(".DelComplain").bind("click", function () {
                
                if (confirm('确认删除吗？')) {

                    $.post('/json/PublicHandler.ashx?Method=DelItem&id=' + $(this).attr("id"), function (r) {
                        if (r.success)
                        {
                            location.reload(true);


                            //$('#myList').listview('refresh');
                        }
                    }, 'json');
                }
                // confirmJQM('确认删除吗?', function () { alert($(this).attr("id")); });
            });
            
        });

        
    </script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" data-ajax='false'>
        <div id="home" data-role="page" class="type-interior">

            <div data-role="header" data-theme="b">
                <a href="#log" data-role="button" data-icon="star">记录</a>
                <h1>投诉建议</h1>
                <a href="#link" data-role="button" data-icon="grid">投诉</a>
            </div>
            <div data-role="content">
                <div class="content-primary">
                    <%=ComplainList(string.Empty, "All", string.Empty, 20) %>                   
                </div>
            </div>
            <div data-role="footer" class="footer-docs" data-theme="c" data-position="fixed" data-tap-toggle="false">
                <div data-role="navbar">
                    <ul>
                        <li><a href="#nav1">行政类</a></li>
                        <li><a href="#nav2">薪酬类</a></li>
                        <li><a href="#nav3">物业类</a></li>
                        <li><a href="#nav4">日常类</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div data-role="page" id="log">
            <div data-role="header" data-theme="b">
                <a href="#home" data-role="button" data-icon="home">返回</a>
                <h1>行政类</h1>
                <a href="#link" data-role="button" data-icon="grid">投诉</a>
            </div>
            <!-- /header -->
            <div data-role="content">
                <div class="content-primary">
                    <%=ComplainList(WebSite.Comman.CookieSession.GetCookie("LoginName"), "My", string.Empty, 20) %>
                </div>
            </div>
            <!-- /content -->
            <%--<div data-role="footer" class="footer-docs" data-theme="c" data-position="fixed" data-tap-toggle="false">
                <div data-role="navbar">
                    <ul>
                        <li><a href="#nav1">行政类</a></li>
                        <li><a href="#nav2">薪酬类</a></li>
                        <li><a href="#nav3">物业类</a></li>
                        <li><a href="#nav4">日常类</a></li>
                    </ul>
                </div>
            </div>--%>
            <!-- /footer -->
        </div>
        <div data-role="page" id="nav1">
            <div data-role="header" data-theme="b">
                <a href="#log" data-role="button" data-icon="home">记录</a>
                <h1>行政类</h1>
                <a href="#link" data-role="button" data-icon="grid">投诉</a>
            </div>
            <!-- /header -->
            <div data-role="content">
                <div class="content-primary">
                    <%=ComplainList(string.Empty, "Nav1", "行政类", 20) %>
                </div>
            </div>
            <!-- /content -->
            <div data-role="footer" class="footer-docs" data-theme="c" data-position="fixed" data-tap-toggle="false">
                <div data-role="navbar">
                    <ul>
                        <li><a href="#nav1" class="ui-btn-active">行政类</a></li>
                        <li><a href="#nav2">薪酬类</a></li>
                        <li><a href="#nav3">物业类</a></li>
                        <li><a href="#nav4">日常类</a></li>
                    </ul>
                </div>
            </div>
            <!-- /footer -->
        </div>
        <!-- /page -->
        <div data-role="page" id="nav2">
            <div data-role="header" data-theme="b">
                <a href="#log" data-role="button" data-icon="home">记录</a>
                <h1>薪酬类</h1>
                <a href="#link" data-role="button" data-icon="grid">投诉</a>
            </div>
            <!-- /header -->
            <div data-role="content">
                <div class="content-primary">
                    <%=ComplainList(string.Empty, "Nav2", "薪酬类", 20) %>
                </div>
            </div>
            <!-- /content -->
            <div data-role="footer" class="footer-docs" data-theme="c" data-position="fixed" data-tap-toggle="false">
                <div data-role="navbar">
                    <ul>
                        <li><a href="#nav1">行政类</a></li>
                        <li><a href="#nav2" class="ui-btn-active">薪酬类</a></li>
                        <li><a href="#nav3">物业类</a></li>
                        <li><a href="#nav4">日常类</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- /page -->
        <div data-role="page" id="nav3">
            <div data-role="header" data-theme="b">
                <a href="#log" data-role="button" data-icon="home">记录</a>
                <h1>物业类</h1>
                <a href="#link" data-role="button" data-icon="grid">投诉</a>
            </div>
            <!-- /header -->
            <div data-role="content">
                <div class="content-primary">
                    <%=ComplainList(string.Empty, "Nav3", "物业类", 20) %>
                </div>
            </div>
            <!-- /content -->
            <div data-role="footer" class="footer-docs" data-theme="c" data-position="fixed" data-tap-toggle="false">
                <div data-role="navbar">
                    <ul>
                        <li><a href="#nav1">行政类</a></li>
                        <li><a href="#nav2">薪酬类</a></li>
                        <li><a href="#nav3" class="ui-btn-active">物业类</a></li>
                        <li><a href="#nav4">日常类</a></li>
                    </ul>
                </div>
            </div>
            <!-- /footer -->
        </div>
        <!-- /page -->
        <div data-role="page" id="nav4">
            <div data-role="header" data-theme="b">
                <a href="#log" data-role="button" data-icon="home">记录</a>
                <h1>日常类</h1>
                <a href="#link" data-role="button" data-icon="grid">投诉</a>
            </div>
            <!-- /header -->
            <div data-role="content">
                <div class="content-primary">
                    <%=ComplainList(string.Empty, "Nav4", "日常类", 20) %>
                </div>
            </div>
            <!-- /content -->
            <div data-role="footer" class="footer-docs" data-theme="c" data-position="fixed" data-tap-toggle="false">
                <div data-role="navbar">
                    <ul>
                        <li><a href="#nav1">行政类</a></li>
                        <li><a href="#nav2">薪酬类</a></li>
                        <li><a href="#nav3">物业类</a></li>
                        <li><a href="#nav4" class="ui-btn-active">日常类</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- /page -->
        <div data-role="page" id="link">
            <div data-role="header" data-theme="b">
                <a href="#home" data-role="button" data-icon="home">返回</a>
                <h1>填写投诉</h1>
                
            </div>
            <!-- /header -->
            <div data-role="content">
                <div class="edit_product_pic">
                    <span class="u_uploadBtn add_pic">
                        <a data-role="none">+</a>
                        <input type="file" data-role="none" id="fileToUpload0" name="fileToUpload0" accept="image/*" capture="camera" filename="" onchange="previewImage(this)" id="File0" />
                    </span><span class="u_uploadBtn add_pic" style="display: none;">
                        <a data-role="none">+</a>
                        <input data-role="none" type="file" name="fileToUpload1" accept="image/*" capture="camera" filename="" onchange="previewImage(this)" id="File1" />
                    </span><span class="u_uploadBtn add_pic" style="display: none;">
                        <a data-role="none">+</a>
                        <input data-role="none" type="file" name="fileToUpload2" accept="image/*" capture="camera" filename="" onchange="previewImage(this)" id="File2" />
                    </span>
                </div>
                <select name="complain_type" id="complain_type" data-native-menu="false">
                    <option value="行政类">行政类</option>
                    <option value="薪酬类">薪酬类</option>
                    <option value="物业类">物业类</option>
                    <option value="日常类">日常类</option>
                </select>
                <textarea name="askdetail" id="askdetail" rows="9" placeholder="填写投诉内容..."></textarea>
                <%--<a href="#" data-role="button">提交</a>--%>
                <asp:Button ID="Button1" runat="server" Text="提交" />
            </div>
            <!-- /content -->
            <div data-role="footer" class="footer-docs" data-theme="c" data-position="fixed" data-tap-toggle="false">
                <p class="jqm-version"></p>
                <p>&copy; 2014 海印股份</p>
            </div>
        </div>
    </form>
</body>
</html>
