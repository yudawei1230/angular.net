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
    <script src="js/ajaxfileupload.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#istcomp").click(function () {
                var data = { fullname: $("#fullname").val(), phone: $("#phone").val(), code: $("#code").val(), askdetail: $("#askdetail").val() }
                $.ajaxFileUpload({
                    url: '/json/PublicHandler.ashx?Method=insertComplain',
                    data: data,
                    secureuri: false,
                    fileElementId: ['fileToUpload0', 'fileToUpload1', 'fileToUpload2'],
                    dataType: 'json',
                    success: function (result) {                       
                        if (result.success) {
                            $("#popdiv").popup("open");
                            $("#popdiv").html(result.msg);
                            setTimeout(function () { $("#popdiv").popup("close"); location.reload(true); }, 2000);
                        } else {
                           
                            $("#popdiv").popup("open");
                            $("#popdiv").html(result.msg);
                            setTimeout(function () { $("#popdiv").popup("close"); }, 2000);
                        }
                    },
                    error: function (data, status, e) {
                        $("#popdiv").html(e.msg);
                    }
                });
            });
        });


    </script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" data-ajax='false'>
        <div id="home" data-role="page" class="type-interior">
            <div data-role="header" data-theme="b">
                <%--<a href="#log" data-role="button" data-icon="star">记录</a>--%>
                <h1>投诉建议</h1>
                <%--<a href="#link" data-role="button" data-icon="grid">投诉</a>--%>
            </div>
            <div data-role="content">
                <div class="content-primary">

                    <h3>一、信访举报受理范围</h3>
                    对海印公司集团总部、下属企业单位，及由公司管理的全体党员干部和职工群众违纪违法行为的举报。
                    <h3>二、信访举报基本要求</h3>
                    <ol>
                        <li>鼓励实名举报。举报人需提供有效联系电话，便于工作人员核实举报内容以便及时反馈办理情况。公司纪委、纪律管理委员会对署实名举报件实行优先办理。涉及到个人荣誉的，必须实名举报，否则不予受理。</li>
                        <li>实事求是反映问题。举报人应对自己的举报行为负责，不得捏造事实、制造假证、诬告陷害他人，或以举报为名制造事端。若对公司或个人造成侵权行为，将移送公安机关并依法追究责任。</li>
                        <li>正规渠道申诉举报。举报人必须通过公司纪委、纪律管理委员会已公开的举报方式进行正常申诉或举报，除正常渠道以外的举报内容，有权不予受理。</li>
                        <li>信访举报人应当尽可能据实告知被举报人的姓名、工作单位（部门）、违法违纪事实的具体情节和证据。</li>
                        <li>对借举报故意捏造事实，诬告陷害他人的，或者以举报为名制造事端，干扰公司纪委、纪律管理委员会正常工作的，依照有关规定严肃处理，构成犯罪的，移送司法机关处理。</li>
                    </ol>
                    <h3>三、其他信访举报渠道</h3>
                    <ol>
                        <li>公司纪委邮箱：jw000861@126.com；</li>
                        <li>纪委电话：020-28828080、28828068；</li>
                        <li>来信地址：广州市越秀区东华南路98号海印中心31楼海印集团纪委  邮编：510100。</li>
                    </ol>

                    <a href="#link" data-role="button">我接受</a>
                </div>
            </div>
        </div>

        <!-- /page -->
        <div data-role="page" id="link">
            <div data-role="header" data-theme="b">
                <h1>填写投诉</h1>
            </div>
            <!-- /header -->
            <div data-role="content">
                <p>请您确认已认真阅读《投诉举报说明》后，如实填写以下信息，我们将对投诉举报信息内容严格保密。</p>
                <input type="text" name="fullname" id="fullname" placeholder="填写真实姓名" />
                
                <div id="popdiv" data-role="popup" data-overlay-theme="a" data-corners="false" data-tolerance="30,15" style="width:300px;height:50px;line-height:50px; text-align:center;"></div>
                <input type="text" name="phone" id="phone" placeholder="填写手机号码" />

                <textarea name="askdetail" id="askdetail" rows="9" placeholder="填写投诉内容..."></textarea>
                <div class="edit_product_pic">
                    <span class="u_uploadBtn add_pic">
                        <a data-role="none">+</a>
                        <input type="file" data-role="none" id="fileToUpload0" name="fileToUpload0" accept="image/*" capture="camera" filename="" onchange="previewImage(this)" id="File0" />
                    </span><span class="u_uploadBtn add_pic" style="display: none;">
                        <a data-role="none">+</a>
                        <input data-role="none" type="file" id="fileToUpload1" name="fileToUpload1" accept="image/*" capture="camera" filename="" onchange="previewImage(this)" id="File1" />
                    </span><span class="u_uploadBtn add_pic" style="display: none;">
                        <a data-role="none">+</a>
                        <input data-role="none" type="file" id="fileToUpload2" name="fileToUpload2" accept="image/*" capture="camera" filename="" onchange="previewImage(this)" id="File2" />
                    </span>
                </div>
                <div data-role="fieldcontain">
                    <table>
                        <tr>
                            <td>
                                <input type="text" name="code" id="code" placeholder="验证码" />
                            </td>
                            <td>
                                <img id="refreshCode" src="ValidCode.aspx" align="middle" onclick="this.src='ValidCode.aspx?Get='+Math.random()" />
                            </td>
                        </tr>
                    </table>
                </div>
                <a data-role="button" id="istcomp" data-rel="popup">提交</a>
                <%--<asp:Button ID="Button1" runat="server" Text="提交" />--%>
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
