/**
 * Created by Rosen on 9.11.2014 г..
 */
var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter a number: ", function(number) {
    evenNumber(number);
    rl.close();
});

function evenNumber(number) {
    if (number % 2 == 0) {
        console.log("true");
    } else {
        console.log("false");
    }
}