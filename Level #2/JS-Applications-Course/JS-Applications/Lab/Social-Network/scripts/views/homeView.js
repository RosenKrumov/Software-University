var app = app || {};

app.homeView = (function () {
    function HomeView(selector) {
        $.get('templates/guest-home.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
            $('#header').empty();
        });
    }

    return {
        load: function (selector) {
            return HomeView(selector);
        }
    }
})();