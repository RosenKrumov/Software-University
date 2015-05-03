/**
 * Created by Rosen on 9.11.2014 г..
 */
var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter a number: ", function(number) {
    checkDigit(number);
    rl.close();
});

function checkDigit (number) {
    for(var i = 0; i < 3; i++) {
        if (i == 2) {
            var digit = parseInt(number % 10);
        } else {
            number /= 10;
        }
    }
    if(digit == 3) {
        console.log("true");
    } else {
        console.log("false");
    }
}