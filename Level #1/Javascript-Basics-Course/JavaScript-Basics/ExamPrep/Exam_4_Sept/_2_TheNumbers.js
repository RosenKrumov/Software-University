/**
 * Created by Rosen on 12.11.2014 г..
 */
function solve(arr) {
    var input = arr[0];
    var numbers = [];
    numbers = input.split(/([\D]+)/g);
    for (var i = 0; i < numbers.length; i++) {
        numbers[i] = parseInt(numbers[i]);
        if(numbers[i] == 0) {
            continue;
        }
        if(isNaN(numbers[i]) || numbers[i] == "") {
            numbers.splice(i,1);
            i--;
        }
    }

    for (var i = 0; i < numbers.length; i++) {
        numbers[i] = Number(numbers[i]).toString(16).toUpperCase();
        while(numbers[i].length != 4) {
            numbers[i] = "0" + numbers[i];
        }
        numbers[i] = "0x" + numbers[i];
    }
    var output = "";
    for (var i = 0; i < numbers.length; i++) {
        output += numbers[i];
        if (i != numbers.length - 1) {
            output += "-";
        }
    }
    console.log(output);
}

solve(["34t8fmjfi83jnmcsjwnd99Dsdkf,b.0.0.-0-0-0-10-0-0-0--0-0-"]);