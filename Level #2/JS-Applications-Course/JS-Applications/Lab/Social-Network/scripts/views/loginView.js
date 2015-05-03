var app = app || {};

app.loginView = (function () {
    function LoginView(selector) {
        $.get('templates/login.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
            $('#log-button').click(function() {
                location.href = '#/Logged';
            })
        });
    }

    return {
        load: function (selector) {
            return LoginView(selector);
        }
    }
})();