/**
 * Created by Rosen on 9.11.2014 г..
 */
var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter a number: ", function(number) {
    isPrime(number);
    rl.close();
});

function isPrime(number) {
    var prime = true;

    if (number > 1) {

        for (var i = 2; i <= Math.sqrt(number); i++) {
            if (number % i == 0) {
                prime = false;
            }
        }
        console.log(prime);

    } else {
        console.log("Enter a bigger number.")
    }
}
