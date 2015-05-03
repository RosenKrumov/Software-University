/**
 * Created by Rosen on 9.11.2014 г..
 */
var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Enter input: ", function(input) {
    var arr = input.split(/[\D]+/);
    treeHouseCompare(arr);
    rl.close();
});

function treeHouseCompare (arr) {
    var houseSquare = arr[1]/3;
    var treeSquare = arr[2]/3;

    var a = arr[1];
    var b = arr[2];

    var houseArea = (Math.pow(a, 2)) + (a * houseSquare);
    var treeArea =
        (treeSquare * b) + (Math.PI * Math.pow((treeSquare*2), 2));

    if(houseArea > treeArea) {

        houseArea = houseArea.toFixed(2);
        console.log("house/" + houseArea);

    } else if (houseArea < treeArea) {

        treeArea = treeArea.toFixed(2);
        console.log("tree/" + treeArea);

    } else {

        houseArea = houseArea.toFixed(2);
        console.log("equal/" + houseArea);

    }
}