(function listCountries() {
    var APP_ID = 'tr7y5vhvY3syKapTbJu5WrVrtsD0s1UZ9KbPTsB7';
    var REST_KEY = 'd2Mi2Tg88c3bdj30dzeAJIMyj5z5Vw8l0adclaIk';

    $.ajax({
        method: 'GET',
        headers: {
            'X-Parse-Application-Id': APP_ID,
            'X-Parse-REST-API-Key': REST_KEY
        },
        url: 'https://api.parse.com/1/classes/Country'
    }).success(function(data){
        for (var r in data.results) {
            var country = data.results[r];
            var countryItem = $('<li>');
            countryItem.attr('id', country.objectId);
            countryItem.text(country.name + ', id: ' + country.objectId);
            countryItem.appendTo($("#countries"));
        }
        $('#logger').append('Countries loaded successfully');
    }).error(function(data) {
        console.log(data.responseText);
        $('#logger').append('Cannot load countries');
    });
})();

