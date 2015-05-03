/**
 * Created by Rosen on 18.11.2014 г..
 */
function findCardFrequency(str) {
    var cards = str.split(/[♥♣♦♠ ]+/g);
    var cardFrequencies = { };
    var totalCards = 0;

    for (var i = 0; i < cards.length; i++) {
        if(cards[i] == '') {
            continue;
        } else {
            if(cardFrequencies[cards[i]] == undefined) {
                cardFrequencies[cards[i]] = 1;
            } else {
                cardFrequencies[cards[i]]++;
            }
            totalCards++;
        }
    }

    for (var card in cardFrequencies) {
        var count = cardFrequencies[card];
        var percent = parseFloat(count)/totalCards*100;
        percent = percent.toFixed(2);
        console.log(card + ' -> ' + percent + '%');
    }
}

findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
console.log();
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
console.log();
findCardFrequency('10♣ 10♥');