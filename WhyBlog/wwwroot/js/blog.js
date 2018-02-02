
var Blog;
(function () {
    function blog(containerId) {

        this.init(containerId);
    }
    Blog = blog;
    blog.prototype.init = function (id) {
        this.$container = $(id);
    }
    blog.prototype.newBlock = function (data) {
        
        var $li = $("<li></li>").appendTo(this.$container);
        var $block = $("<div class='block'></div>").appendTo($li);
        var $head = this.newHead(data).appendTo($block);
        var $content = this.newContent(data.summary, data.picSummary).appendTo($block);
        var $tail = this.newTail(data).appendTo($block);


    }
    blog.prototype.newBlogDetail = function (data) {
        
        var $block = $("<div class='block'></div>").appendTo(this.$container);
        var $head = this.newHead(data).appendTo($block);
        var $tail = this.newTail(data).appendTo($block);
        var $content = this.newContentDetail(data).appendTo($block);
    }
    blog.prototype.newHead = function (data) {

        var $head = $("<div class='head'></div>");

        var $icon = $("<div class='icon'><img src=" + data.userPic + " /></div>").appendTo($head);
        var $title = $("<div class='title'><a href=/blog/index/" + data.id + ">" + data.title + "</a></div>").appendTo($head);
        return $head;
    }

    blog.prototype.newContent = function (summary, picSummary) {
        var $content = $("<div class='content'></div>");
        if (!!picSummary) {
            var $picSummary = $("<div class='pic'>" + picSummary + "</div>").appendTo($content);
        }
        if (!!summary) {
            var $summary = $("<div>" + summary + "...</div>").appendTo($content);
        }
        return $content;
    }
    blog.prototype.newContentDetail = function (data) {
        var $content = $("<div class='content'></div>");

        var $html = $("<div>" + data.html + "</div>").appendTo($content);
        return $content;
    }
    blog.prototype.newTail = function (data) {
        var $tail = $("<div class='tail'>☆" + data.nickName + "☆ " + data.createTime + "</div>");
        return $tail;
    }
})()