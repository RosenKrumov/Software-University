/**
 * Created by Rosen on 12.11.2014 г..
 */
function solve(arr) {
    var output = [];

    for (var i = 0; i < arr.length; i++) {
        output[i] = arr[i].split('');
    }

    for (var i = 1; i < output.length; i++) {
        for (var j = 1; j < output[i].length; j++) {
            var a = arr[i-1][j];
            var b = arr[i][j-1];
            var c = arr[i][j];
            var d = arr[i][j+1];
            if(a == b &&
                a == c &&
                    a == d) {
                output[i-1][j] = '*';
                output[i][j-1] = '*';
                output[i][j] = '*';
                output[i][j+1] = '*'
            }
        }
    }
    for (var k = 0; k < output.length; k++) {
        console.log(output[k].join(''));
    }
}

solve(['dffdsgyefg',
    'ffffeyeee',
    'jbfffays',
    'dagfffdsss',
    'dfdfa',
    'dadaaadddf',
    'sdaaaaa',
    'daaaaaaasf'
]);