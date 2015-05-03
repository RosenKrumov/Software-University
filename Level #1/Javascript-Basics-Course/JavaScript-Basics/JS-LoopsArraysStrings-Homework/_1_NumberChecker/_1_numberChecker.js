/**
 * Created by Rosen on 18.11.2014 г..
 */
function printNumbers(number) {
    var output = [];
    for (var i = 1; i <= number; i++) {
        if((i % 4 != 0) && (i % 5 != 0)) {
            output.push(i);
        }
    }
    if(output.length == 0) {
        console.log('no');
    } else {
        console.log(output.join(', '));
    }
}

printNumbers(20);
printNumbers(-5);
printNumbers(13);
