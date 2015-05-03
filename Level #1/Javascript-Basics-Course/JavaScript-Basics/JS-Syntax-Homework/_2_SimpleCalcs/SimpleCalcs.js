var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter a number: ", function(number) {
    roundNumber(number);
    rl.close();
});

function roundNumber(number) {
    console.log(Math.floor(number));
    console.log(Math.round(number));
}