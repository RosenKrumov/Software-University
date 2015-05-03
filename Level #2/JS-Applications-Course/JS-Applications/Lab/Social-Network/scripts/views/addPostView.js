var app = app || {};

app.addPostView = (function () {
    function addPostView(selector) {
        $.get('templates/add-post.html', function (template) {
            var output = Mustache.render(template);
            $(selector).prepend(output);
            $('#add-post').click(function() {
                location.href = '#/Posted';
            });
        });
    }

    return {
        load: function (selector) {
            return addPostView(selector);
        }
    }
})();