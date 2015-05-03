/**
 * Created by Rosen on 14.11.2014 г..
 */
function solve(arr) {
    var text = arr[0].split(/\s+/g);
    var keywords = [];
    var matches = false;
    var matchWords = [];


    for (var i = 1; i < arr.length; i++) {
        keywords[i-1] = arr[i].toLowerCase();
    }

    for (var i = 0; i < keywords.length; i++) {
        for (var j = 0; j < text.length; j++) {
            if (text[j].toLowerCase().indexOf(keywords[i].toLowerCase()) == 0) {
                matches = true;
                matchWords.push(text[j]);
            }
        }
        if (matches == true) {
            matchWords.sort(function (a, b) {
                return a.length - b.length;
            });
            var firstWordLength = matchWords[0].length;
            for (var k = 0; k < matchWords.length; k++) {
                if (matchWords[k].length > firstWordLength) {
                    matchWords.splice(k, 1);
                    k--;
                }
            }
            if (matchWords.length > 1) {
                matchWords.sort(function (a, b) {
                    return a.toLowerCase().localeCompare(b.toLowerCase());
                });
            }
            console.log(matchWords[0]);
            matchWords = [];
            matches = false;
        } else {
            console.log('-');
        }
    }
}

solve([ 'wolf woak screammm screech speech wolf', 'bas', 'wo', 'scr', 's' ]);