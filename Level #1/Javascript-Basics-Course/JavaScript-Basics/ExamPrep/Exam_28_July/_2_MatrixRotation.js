/**
* Created by Rosen on 18.11.2014 г..
*/
function rotate(arr) {
    var angle = arr[0].split(/\D+/g).slice(0).slice(1,2);
    var rotateAngle = parseInt(angle);
    var matrix = [];
    var buffer = [];
    for (var i = 1; i < arr.length; i++) {
        matrix[i - 1] = arr[i].split('');
        buffer[i - 1] = arr[i].split('');
    }

    var sorted = buffer.sort(function(a, b){return a.length <
    b.length});

    var maxlength = sorted[0].length;

    for (var i = 0; i < matrix.length; i++) {
        for (var j = matrix[i].length; j < maxlength; j++) {
            matrix[i].push(' ');
        }
    }
    var k = 0;
    var index90 = arr.length - 2;
    var index180 = matrix[0].length - 1;
    var index270 = matrix[0].length - 1;
    if(rotateAngle == 90 || rotateAngle % 360 == 90) {
        var outputMatrix = new Array(matrix[0].length);
        for (var i = 0; i < outputMatrix.length; i++) {
            outputMatrix[i] = new Array(arr.length - 1);
        }
        for (var i = 0; i < matrix[0].length; i++) {
            for (var j = 0; j < arr.length - 1; j++) {
                outputMatrix[i][j] = matrix[index90][k];
                index90--;
            }
            k++;
            index90 = arr.length - 2;
        }
    } else if (rotateAngle == 180 || rotateAngle % 360 == 180) {
        k = arr.length - 2;
        var outputMatrix = new Array(arr.length - 1);
        for (var i = 0; i < outputMatrix.length; i++) {
            outputMatrix[i] = new Array(matrix[0].length);
        }
        for (var i = 0; i < arr.length - 1; i++) {
            for (var j = 0; j < matrix[0].length; j++) {
                outputMatrix[i][j] = matrix[k][index180];
                index180--;
            }
            k--;
            index180 = matrix[0].length - 1;
        }
    } else if (rotateAngle == 270 || rotateAngle % 360 == 270) {
        k = 0;
        var outputMatrix = new Array(matrix[0].length);
        for (var i = 0; i < outputMatrix.length; i++) {
            outputMatrix[i] = new Array(arr.length - 1);
        }
        for (var i = 0; i < matrix[0].length; i++) {
            for (var j = 0; j < arr.length - 1; j++) {
                outputMatrix[i][j] = matrix[k][index270];
                k++;
            }
            index270--;
            k = 0;
        }
    } else {
        for (var i = 0; i < matrix.length; i++) {
            console.log(matrix[i].join(''));
        }
        return;
    }
    for (var i = 0; i < outputMatrix.length; i++) {
        console.log(outputMatrix[i].join(''));
    }
}
