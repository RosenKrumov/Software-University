var app = app || {};

app.loggedInHomeView = (function () {
    function loggedInHomeView(selector, data) {
        $.get('templates/header.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
            $('#main').empty();
        });
    }

    return {
        load: function (selector, data) {
            return loggedInHomeView(selector, data);
        }
    }
})();