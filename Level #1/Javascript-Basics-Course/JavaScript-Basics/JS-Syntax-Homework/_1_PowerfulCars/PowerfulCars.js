/**
 * Created by Rosen on 9.11.2014 г..
 */
var readline = require('readline');
var HORSE_POWER = 0.745699872;

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter kW: ", function(number) {
    convertKWtoHP(number);
    rl.close();
});

function convertKWtoHP (number) {
    var horsePowerOfKW = number / HORSE_POWER;
    horsePowerOfKW = horsePowerOfKW.toFixed(2);
    console.log(number122 + " kws = " + horsePowerOfKW + " hp.");
}