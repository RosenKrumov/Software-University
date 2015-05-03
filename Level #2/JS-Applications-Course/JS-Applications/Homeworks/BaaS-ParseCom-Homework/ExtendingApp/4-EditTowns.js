function deleteTown(id) {
    var APP_ID = 'tr7y5vhvY3syKapTbJu5WrVrtsD0s1UZ9KbPTsB7';
    var REST_KEY = 'd2Mi2Tg88c3bdj30dzeAJIMyj5z5Vw8l0adclaIk';

    $.ajax({
        method: 'DELETE',
        headers: {
            'X-Parse-Application-Id': APP_ID,
            'X-Parse-REST-API-Key': REST_KEY
        },
        url: 'https://api.parse.com/1/classes/Town' + '/' + id
    }).success(function(){
        $('#logger').append('Town deleted successfully<br>');
    }).error(function() {
        $('#logger').append('Cannot delete town<br>');
    });
}

function addTown(name, countryId) {
    var APP_ID = 'tr7y5vhvY3syKapTbJu5WrVrtsD0s1UZ9KbPTsB7';
    var REST_KEY = 'd2Mi2Tg88c3bdj30dzeAJIMyj5z5Vw8l0adclaIk';

    $.ajax({
        method: 'POST',
        headers: {
            'X-Parse-Application-Id': APP_ID,
            'X-Parse-REST-API-Key': REST_KEY,
            'Content-Type': 'application/json'
        },
        url: 'https://api.parse.com/1/classes/Town',
        data: '{"name":"' + name + '", "country": { "__type":"Pointer", "className":"Country", "objectId":"' + countryId + '"}}'
    }).success(function() {
        $('#logger').append('Town added successfully<br>');
    }).error(function() {
        $('#logger').append('Cannot add town<br>');
    });
}

function editTown(id, newName) {
    var APP_ID = 'tr7y5vhvY3syKapTbJu5WrVrtsD0s1UZ9KbPTsB7';
    var REST_KEY = 'd2Mi2Tg88c3bdj30dzeAJIMyj5z5Vw8l0adclaIk';

    $.ajax({
        method: 'PUT',
        headers: {
            'X-Parse-Application-Id': APP_ID,
            'X-Parse-REST-API-Key': REST_KEY,
            'Content-Type': 'application/json'
        },
        url: 'https://api.parse.com/1/classes/Town/' + id,
        data: '{"name":"' + newName + '"}'
    }).success(function() {
        $('#logger').append('Town edited successfully<br>');
    }).error(function() {
        $('#logger').append('Cannot edit town<br>');
    });
}