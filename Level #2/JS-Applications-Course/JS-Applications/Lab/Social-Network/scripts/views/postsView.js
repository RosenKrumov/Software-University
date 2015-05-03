var app = app || {};

app.postsView = (function () {
    function postsView(selector, data) {
        $.get('templates/posts.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).append(output);
        });
    }

    return {
        load: function (selector, data) {
            return postsView(selector, data);
        }
    }
})();