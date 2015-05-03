(function() {
    if (!localStorage['name']) {
        $('#login').on('click', importUserName);
    } else {
        $('#input').hide();
        var greeting = $('<p>Hello ' + localStorage['name'] + '</p>');
        $('body').append(greeting);
    }

    if (!localStorage['visits']) {
        localStorage.setItem('visits', 0);
    }

    if (!sessionStorage['visits']) {
        sessionStorage.setItem('visits', 0);
    }

    localStorage['visits']++;
    sessionStorage['visits']++;

    var totalVisits = $('<p>Total visits: ' + localStorage['visits'] +'</p>');
    var sessionVisits = $('<p>Session visits: ' + sessionStorage['visits'] +'</p>');

    $('body').append(totalVisits).append(sessionVisits);

    function importUserName() {
        var name = $('#name').val();
        localStorage.setItem('name', name);
        location.reload();
    }
})();
