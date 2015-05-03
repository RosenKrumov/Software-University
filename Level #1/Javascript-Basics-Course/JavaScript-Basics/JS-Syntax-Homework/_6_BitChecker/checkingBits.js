/**
 * Created by Rosen on 9.11.2014 г..
 */
var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter a number: ", function(number) {
    bitChecker(number);
    rl.close();
});

function bitChecker (number) {
    var bit = (number >> 3) & 1;
    if (bit == 1) {
        console.log("true");
    } else {
        console.log("false");
    }
}