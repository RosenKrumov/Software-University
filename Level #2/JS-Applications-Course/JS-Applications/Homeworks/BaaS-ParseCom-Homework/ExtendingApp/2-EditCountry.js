function deleteCountry(id) {
    var APP_ID = 'tr7y5vhvY3syKapTbJu5WrVrtsD0s1UZ9KbPTsB7';
    var REST_KEY = 'd2Mi2Tg88c3bdj30dzeAJIMyj5z5Vw8l0adclaIk';

    $.ajax({
        method: 'DELETE',
        headers: {
            'X-Parse-Application-Id': APP_ID,
            'X-Parse-REST-API-Key': REST_KEY
        },
        url: 'https://api.parse.com/1/classes/Country' + '/' + id
    }).success(function(){
        $('#logger').append('Country deleted successfully<br>');
        $('#' + id).remove();
    }).error(function() {
        $('#logger').text('Cannot delete country<br>');
    });
}

function addCountry(name) {
    var APP_ID = 'tr7y5vhvY3syKapTbJu5WrVrtsD0s1UZ9KbPTsB7';
    var REST_KEY = 'd2Mi2Tg88c3bdj30dzeAJIMyj5z5Vw8l0adclaIk';

    $.ajax({
        method: 'POST',
        headers: {
            'X-Parse-Application-Id': APP_ID,
            'X-Parse-REST-API-Key': REST_KEY,
            'Content-Type': 'application/json'
        },
        url: 'https://api.parse.com/1/classes/Country',
        data: '{"name":"' + name + '"}'
    }).success(function() {
        $('#logger').append('Country added successfully<br>');
        var country = $('<li>').text(name);
        $('#countries').append(country);
    }).error(function() {
        $('#logger').append('Cannot add country<br>');
    });
}

function editCountry(id, newName) {
    var APP_ID = 'tr7y5vhvY3syKapTbJu5WrVrtsD0s1UZ9KbPTsB7';
    var REST_KEY = 'd2Mi2Tg88c3bdj30dzeAJIMyj5z5Vw8l0adclaIk';

    $.ajax({
        method: 'PUT',
        headers: {
            'X-Parse-Application-Id': APP_ID,
            'X-Parse-REST-API-Key': REST_KEY,
            'Content-Type': 'application/json'
        },
        url: 'https://api.parse.com/1/classes/Country/' + id,
        data: '{"name":"' + newName + '"}'
    }).success(function() {
        $('#logger').append('Country edited successfully<br>');
        $('#' + id).text(newName);
    }).error(function() {
        $('#logger').append('Cannot edit country<br>');
    });
}