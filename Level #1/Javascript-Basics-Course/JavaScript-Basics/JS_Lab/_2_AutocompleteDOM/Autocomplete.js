/**
 * Created by Rosen on 14.11.2014 г..
 */
function solve() {
    var arr = [softuni, baivan, pesho, gosho, kiko];
    var text = arr[0].split(/\s+/g);
    var keyword = document.getElementById('input').value;
    var matches = false;
    var matchWords = [];
    var match = document.getElementById('output');

    for (var i = 0; i < keyword.length; i++) {
        for (var j = 0; j < text.length; j++) {
            if (text[j].toLowerCase().indexOf(keyword.toLowerCase()) == 0) {
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
            match = matchWords[0];

            matchWords = [];
            matches = false;
        } else {
            console.log('-');
        }
    }
}
