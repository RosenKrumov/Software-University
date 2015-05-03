/**
 * Created by Rosen on 9.11.2014 г..
 */
var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter a number: ", function(number) {
    divisionBy3(number);
    rl.close();
});

function divisionBy3 (number) {
    var digitSum = 0;

    while(number > 0) {
        digitSum += number % 10;
        number = parseInt(number/10);
    }

    if (digitSum % 3 == 0) {
        console.log("the number is divided by 3 without remainder");
    } else {
        console.log("the number is not divided by 3 without remainder");
    }
}

