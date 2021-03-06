﻿

function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

var ajaxRequest = {};
var _tool = {};
(function () {
    _tool.loading = function () {
        $(".loading").show();
    }
    _tool.removeLoading = function () {
        $(".loading").hide();
    }
    window.alert = function (str,callbcak) {
        var $alert = $(".alert-default");
        var $text = $(".alert-default span");
        $text.text(str);
        var textWidth = $alert.width() / 2;
        var bodyWidth = $("body").width() / 2;
        var moveWidth = parseInt(bodyWidth - textWidth);
        console.log(moveWidth);
        $alert.css("transform", "translate3d(" + moveWidth + "px,0,0)");
        setTimeout(function () {
            $alert.css("transform", "translate3d(" + -bodyWidth + "px,0,0)");
            if (!!callbcak) {
                callbcak();
            }
        }, 3000);
    }
})()

ajaxRequest.get = function (data, url) {
    _tool.loading();
    return $.ajax({
        url: url,
        method: "get",
        dataType: "JSON"
    }).always(function () { _tool.removeLoading(); });
}

ajaxRequest.post = function (data, url) {
    _tool.loading();
    return $.ajax({
        url: url,
        method: "post",
        dataType: "JSON",
        data: data
    }).always(function () { _tool.removeLoading(); });
}

var config = {
    client_id: "f7d394427a6c3d3e5689",
    client_secret: "b3216c98eca8c5301b5f09525f7e6863c0250b8c",
    scope: ['user'],
    redirect_uri: _config.rootpath + '/home/redirect',
    api_url: _config.rootpath + '/api',

}

var GitOauth = (function () {
    function gitOauth() {
        this.init();
    }
    gitOauth.prototype.init = function () {
        var _this = this;
        $("#gitSignIn").click(function () {
            _this.signIn();
        });
        $("#icon_signOut").click(function () {
            _this.signOut();
        });

    }

    gitOauth.prototype.signIn = function () {
        var path = 'https://github.com/login/oauth/authorize';
        path += '?client_id=' + config.client_id;
        path += '&scope=' + config.scope;
        path += '&redirect_uri=' + config.redirect_uri;
        window.location.href = path;
    }

    gitOauth.prototype.getToken = function () {
        var code = getQueryString("code");
        if (!!!code) return;
        var url = config.api_url + "/GitApi/SigninByGit";
        var data = {
            client_id: config.client_id,
            client_secret: config.client_secret,
            code: code
        };
        ajaxRequest.post(data, url).done(function (d) {
            window.location.href = "/home/index";

        });
        return false;
    }
    gitOauth.prototype.signOut = function () {
        var url = config.api_url + "/GitApi/SignOut";
        ajaxRequest.post({}, url).done(function (d) {
            console.log(d);
            window.location.href = "/";
        });

    }


    return gitOauth;

})()


var git = new GitOauth();







