var app = app || {};

app.registerView = (function () {
    function registerView(selector) {
        $.get('templates/register.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
            $('#reg-button').click(function(){
                location.href = '#/Registered';
            });
        });
    }

    return {
        load: function (selector) {
            return registerView(selector);
        }
    }
})();