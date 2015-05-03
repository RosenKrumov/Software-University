/**
 * Created by Rosen on 23.11.2014 г..
 */
function solve(arr) {
    var concerts = { };

    for (var i = 0; i < arr.length; i++) {
        var currentLine = arr[i].match(/[\w ]+/g);
        var band = currentLine[0].trim();
        var city = currentLine[1].trim();
        var stadium = currentLine[5].trim();

        if(!concerts[city]) {
            concerts[city] = { };
            concerts[city][stadium] = [];
        }

        if(concerts[city][stadium] == undefined) {
            concerts[city][stadium] = [];
        }

        if(concerts[city][stadium].indexOf(band) == -1) {
            concerts[city][stadium].push(band);
        }
    }

    var concertsKeys = Object.keys(concerts).sort();
    var output = { };

    for (var i = 0; i < concertsKeys.length; i++) {
        output[concertsKeys[i]] = concerts[concertsKeys[i]];
    }

    for (var stadium in output) {
        var stadiumKeys = Object.keys(output[stadium]).sort();
        var stadiums = {};

        for (var i = 0; i < stadiumKeys.length; i++) {
            stadiums[stadiumKeys[i]] = output[stadium][stadiumKeys[i]];
            stadiums[stadiumKeys[i]].sort();
        }

        output[stadium] = stadiums;
    }

    console.log(JSON.stringify(output));

}

solve([
    'ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
    'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
    'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
    'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
    'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
    'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
    'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium',
    'Helloween | London | 28-Jul-2014 | Wembley Stadium',
    'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
    'Metallica | London | 03-Oct-2014 | Olympic Stadium',
    'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium',
    'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium'

]);