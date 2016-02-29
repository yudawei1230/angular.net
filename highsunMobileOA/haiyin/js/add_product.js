//上传图片预览
function previewImage(file, prvid) {
    var curfileObjId = file.id;
    var btnObj = $("#" + curfileObjId).prev("button");
    $(btnObj).find("img").remove();
    //setTimeout(function () { ajaxFileUpload(file); }, 1);
    var tip = "Expect jpg or png or gif!"; // 设定提示信息
    var filters = {
        "jpeg": "/9j/4",
        "gif": "R0lGOD",
        "png": "iVBORw"
    }
    //var prvbox = document.getElementById(prvid);
    //prvbox.innerHTML = "";
    if (window.FileReader) { // html5方案
        for (var i = 0, f; f = file.files[i]; i++) {
            var fr = new FileReader();
            fr.onload = function (e) {
                var src = e.target.result;
                if (!validateImg(src)) {
                    alert(tip)
                } else {
                    //showPrvImg(src);
                    showPrvImg(src, btnObj);
                }
            }
            fr.readAsDataURL(f);
        }
    } else { // 降级处理
        if (!/\.jpg$|\.png$|\.gif$/i.test(file.value)) {
            alert(tip);
        } else {
            showPrvImg(file.value);
        }
    }

    function validateImg(data) {
        var pos = data.indexOf(",") + 1;
        for (var e in filters) {
            if (data.indexOf(filters[e]) === pos) {
                return e;
            }
        }
        return null;
    }

    function showPrvImg(src, btnObj) {
        //$(btnObj).css({ background: "url(" + src + ")" });
        var img = document.createElement("img");
        img.src = src;
        $(img).css({ width: 65, height: 65});
        $(img).appendTo(btnObj);
    }
}