window.blazorHelpers = {
    getScrollHeight: function (element) {
        return element ? element.scrollHeight : 0;
    },
    getScrollTop: function (element) {
        return element ? element.scrollTop : 0;
    },
    getClientHeight: function (element) {
        return element ? element.clientHeight : 0;
    }
};
