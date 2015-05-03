/*** Created by Rosen on 9.11.2014 г..*/
var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter input: ", function(input) {
    var arr = input.split(/[\D]+/);
    calcCylinderVol(arr);
    rl.close();
});
function calcCylinderVol(arr) {
    var radius = arr[1];
    var height = arr[2];
    var volume = Math.PI * Math.pow(radius, 2) * height;
    volume = volume.toFixed(3);
    console.log(volume);
}