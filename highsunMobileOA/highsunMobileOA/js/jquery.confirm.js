function confirmJQM(text, callback) {
    var popupDialogId = 'popupDialogC'; $('<div data-role="popup" id="' + popupDialogId + '" data-confirmed="no" data-position-to="window" data-transition="pop" data-theme="b" data-dismissible="false" style="max-width:500px;">' + '<div role="main" class="ui-content" style="text-align: center;">' + '<h3 class="ui-title">' + text + '</h3>' + '<p></p>' + '<a data-role="button" data-theme="b" class="optionCancel" data-mini="true" data-inline="true" onclick="$(\'#popupDialogC\').popup(\'close\');" >取消</a>' + '<a data-role="button" data-theme="b" class="optionConfirm" data-transition="flow" data-inline="true" data-mini="true">确定</a>' + '</div>' + '</div>').appendTo($.mobile.pageContainer); var popupDialogObj = $('#' + popupDialogId); popupDialogObj.trigger('create');  //动态加载时 需要重新刷新下 也就是给popup赋上jqm对应的css        
    //初始化popup    
    popupDialogObj.popup({
        //关闭时 绑定的事件        
        afterclose: function (event, ui) {
            popupDialogObj.find(".optionConfirm").first().off('click');
            //关闭时 需要清除确定按钮上 绑定的事件            
            $(event.target).remove();//删除 创建的 popup        
        },
        //显示时 绑定的事件        
        afteropen: function (event, ui) { popupDialogObj.find(".optionConfirm").first().on('click', function () { popupDialogObj.attr('data-confirmed', 'no'); $('#popupDialogC').popup('close'); if (callback && callback instanceof Function) { callback(); } }); }
    });
    //打开   
    popupDialogObj.popup('open');
}