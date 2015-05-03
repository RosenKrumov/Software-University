/**
 * Created by Rosen on 9.11.2014 г..
 */
var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter a number: ", function(value) {
    convertDigitToWord(value);
    rl.close();
});

function convertDigitToWord (value) {
    switch(value) {
        case '1': console.log("one"); break;
        case '2': console.log("two"); break;
        case '3': console.log("three"); break;
        case '4': console.log("four"); break;
        case '5': console.log("five"); break;
        case '6': console.log("six"); break;
        case '7': console.log("seven"); break;
        case '8': console.log("eight"); break;
        case '9': console.log("nine"); break;

    }
}