/**
 * Created by Rosen on 14.11.2014 г..
 */
function solve(arr) {

    var input = [];
    for(var i = 0; i < arr.length; i++) {
        input[i] = arr[i].split(/\s+/g);
    }

    for (var i = 0; i < input.length; i++) {
        var k = input[i][0];
        input[i][0] = input[i][1];
        input[i][1] = k;
    }

    input.sort();
    var n = input.length - 1;
    for (var i = 0; i < input.length - 1; i++) {
        if(input[i][0] == input[i+1][0]) {
            input[i][1] = input[i][1] + "\",\"" + input[i+1][1];
            input[i][2] = parseFloat(input[i][2]) + parseFloat(input[i+1][2]);
            input.splice(i+1, 1);
            i--;
        }
    }
    var output = '{';
    for (var i = 0; i < input.length; i++) {
            output += '\"' + input[i][0] + "\":{\"files\":[\"" + input[i][1] + "\"],\"memory\":\"" +
            parseFloat(input[i][2]).toFixed(2) + "\"},";
    }
    output = output.substr(0,output.length-1);
    output+='}';
    console.log(output);
}

solve([ 'sentinel .exe 15MB',
    'zoomIt .msi 3MB',
    'skype .exe 45MB',
    'trojanStopper .bat 23MB',
    'kindleInstaller .exe 120MB',
    'setup .msi 33.4MB',
    'winBlock .bat 1MB' ]);