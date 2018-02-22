var Datetime = {
    Format: function (now, mask) {
        var d = now;
        var zeroize = function (value, length) {
            if (!length) length = 2;
            value = String(value);
            for (var i = 0, zeros = ''; i < (length - value.length); i++) {
                zeros += '0';
            }
            return zeros + value;
        };

        return mask.replace(/"[^"]*"|'[^']*'|\b(?:d{1,4}|m{1,4}|yy(?:yy)?|([hHMstT])\1?|[lLZ])\b/g, function ($0) {
            switch ($0) {
                case 'd': return d.getDate();
                case 'dd': return zeroize(d.getDate());
                case 'ddd': return ['Sun', 'Mon', 'Tue', 'Wed', 'Thr', 'Fri', 'Sat'][d.getDay()];
                case 'dddd': return ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'][d.getDay()];
                case 'M': return d.getMonth() + 1;
                case 'MM': return zeroize(d.getMonth() + 1);
                case 'MMM': return ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'][d.getMonth()];
                case 'MMMM': return ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'][d.getMonth()];
                case 'yy': return String(d.getFullYear()).substr(2);
                case 'yyyy': return d.getFullYear();
                case 'h': return d.getHours() % 12 || 12;
                case 'hh': return zeroize(d.getHours() % 12 || 12);
                case 'H': return d.getHours();
                case 'HH': return zeroize(d.getHours());
                case 'm': return d.getMinutes();
                case 'mm': return zeroize(d.getMinutes());
                case 's': return d.getSeconds();
                case 'ss': return zeroize(d.getSeconds());
                case 'l': return zeroize(d.getMilliseconds(), 3);
                case 'L': var m = d.getMilliseconds();
                    if (m > 99) m = Math.round(m / 10);
                    return zeroize(m);
                case 'tt': return d.getHours() < 12 ? 'am' : 'pm';
                case 'TT': return d.getHours() < 12 ? 'AM' : 'PM';
                case 'Z': return d.toUTCString().match(/[A-Z]+$/);
                // Return quoted strings with the surrounding quotes removed
                default: return $0.substr(1, $0.length - 2);
            }
        });
    }
};

//时间格式化
var dateFormmatter = function (value) {
    return Datetime.Format(new Date(value), "yyyy-MM-dd HH:mm:ss");
}


//自定义插件
var $Zaolazi = {
    //confirm提示框jquery插件
    confirmModal: function (content, callBack) {
        //移除绑定事件
        $('#zlz-confirm-modal .confirm-btn').unbind();  
        //移除模态框
        $("#zlz-confirm-modal").remove();
        //增加模态框
        var modalHtml = '<div class="modal fade in" id="zlz-confirm-modal" data-backdrop="static" aria-hidden="false" style="display: none;">' +
            '<div class="modal-dialog">' +
            '<div class="modal-content">' +
            '<div class="modal-header">' +
            '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>' +
            '<h4 class="modal-title">系统提示</h4>' +
            '</div>' +
            '<div class="modal-body">' +
            '<h4>' + content + '</h4>' + 
            '</div>' +
            '<div class="modal-footer">' +
            '<button type="button" class="btn btn-white" data-dismiss="modal">取消</button>' +
            '<button type="button" class="btn btn-primary confirm-btn">确定</button>' +
        '</div></div></div></div>';
        $("body").append(modalHtml);
        //添加监听事件
        $(document).unbind().on("click", "#zlz-confirm-modal .confirm-btn", function () {
            //点击确定按钮回掉
            callBack();
            //隐藏模态框
            $("#zlz-confirm-modal").modal('hide');
        });
        //展示模态框
        $('#zlz-confirm-modal').modal('show', { backdrop: 'static' });
    }
}