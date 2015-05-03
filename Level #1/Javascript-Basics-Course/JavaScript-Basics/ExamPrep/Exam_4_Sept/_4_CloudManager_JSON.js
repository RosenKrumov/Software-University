/**
 * Created by Rosen on 14.11.2014 г..
 */
function solve(arr) {
    var inputs = [];
    var obj = { };
    for (var i = 0; i < arr.length; i++) {
        inputs[i] = arr[i].split(/\s+/g);
    }

    for (var i = 0; i < inputs.length; i++) {
        var k = inputs[i][0];
        inputs[i][0] = inputs[i][1];
        inputs[i][1] = k;
    }

    inputs.sort();

    for (var i = 0; i < inputs.length; i++) {
        var key = inputs[i][0];
        if(obj[key] == undefined){
            obj[key] = { 'files':[], 'memory': 0 };
        }
        obj[key]['files'].push(inputs[i][1]);
        obj[key]['memory'] += parseFloat(inputs[i][2]);
    }
    for (var h in obj) {
        obj[h]['memory'] = obj[h]['memory'].toFixed(2);
    }
    console.log(JSON.stringify(obj));

}

solve([ 'sentinel .exe 15MB',
    'zoomIt .msi 3MB',
    'skype .exe 45MB',
    'trojanStopper .bat 23MB',
    'kindleInstaller .exe 120MB',
    'setup .msi 33.4MB',
    'winBlock .bat 1MB' ]);