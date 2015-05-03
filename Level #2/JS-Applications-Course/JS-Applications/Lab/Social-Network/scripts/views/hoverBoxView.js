var app = app || {};

app.hoverBoxView = (function () {
    function hoverBoxView(data) {
        $.get('templates/hover-box.html', function (template) {
            var output = Mustache.render(template, data);
            $('.hover-box').html(output);
        });
    }

    return {
        load: function (data) {
            return hoverBoxView(data);
        }
    }
})();