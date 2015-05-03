var app = app || {};

app.editProfileView = (function () {
    function editProfileView(selector, data) {
        $.get('templates/edit-profile.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
            $('input[type="radio"][value=' + data.gender + ']')
                .attr('checked', true);
            $('#header').empty();
            $('#edit-save').click(function() {
                location.href = '#/Edited';
            });
            $('#edit-cancel').click(function() {
                location.href = '#/Home';
            });
        });
    }

    return {
        load: function (selector, data) {
            return editProfileView(selector, data);
        }
    }
})();