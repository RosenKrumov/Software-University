function getTowns(id) {
    var APP_ID = 'tr7y5vhvY3syKapTbJu5WrVrtsD0s1UZ9KbPTsB7';
    var REST_KEY = 'd2Mi2Tg88c3bdj30dzeAJIMyj5z5Vw8l0adclaIk';
    var CONDITION =
        'where={"country":{"__type":"Pointer","className":"Country","objectId":"' + id + '"}}&include=country';

    if(!sessionStorage.alreadyListed) {
        $.ajax({
            method: 'GET',
            headers: {
                'X-Parse-Application-Id': APP_ID,
                'X-Parse-REST-API-Key': REST_KEY
            },
            url: 'https://api.parse.com/1/classes/Town?' + CONDITION
        }).success(function(data){
            sessionStorage['alreadyListed'] = true;
            var heading = $('<h3>');
            heading.text('Towns by country: ' + data.results[0].country.name);
            heading.appendTo($('#results'));
            for (var r in data.results) {
                var town = data.results[r];
                var townItem = $('<li>');
                townItem.text(town.name);
                townItem.appendTo($("#results"));
            }
            $('#logger').append('Towns loaded successfully<br>');
        }).error(function() {
            $('#logger').append('Cannot load towns<br>');
        });
    } else {
        $('#logger').append('Towns already listed<br>');
    }
}

if(window.location.reload) {
    sessionStorage.clear();
}