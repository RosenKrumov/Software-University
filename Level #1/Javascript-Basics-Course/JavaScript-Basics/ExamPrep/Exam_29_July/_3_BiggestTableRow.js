/**
 * Created by Rosen on 22.11.2014 г..
 */
function biggestRow(arr) {
    var rows = [];
    var maxIndex = -1;
    var maxSum = Number.NEGATIVE_INFINITY;

    for (var i = 2; i < arr.length - 1; i++) {
        rows[i - 2] = arr[i].match(/[-+]?([0-9]*\.[0-9]+|[0-9]+)/g);
    }



    for (var i = 0; i < rows.length; i++) {
        if(rows[i] == null) {
            continue;
        } else {
            var currSum = 0;
            for (var j = 0; j < rows[i].length; j++) {
                currSum += parseFloat(rows[i][j]);
            }
            if (maxSum < currSum) {
                maxSum = currSum;
                maxIndex = i;
            }
        }
    }

    if(maxIndex == -1) {
        console.log('no data');
        return;
    }

    var maxArr = rows[maxIndex];

    console.log(maxSum + ' = ' + maxArr.join(' + '));
}


biggestRow([
'<table>',
'<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
'<tr><td>Pleven</td><td>-100</td><td>-200</td><td>-</td></tr>',
'<tr><td>Varna</td><td>-100</td><td>-</td><td>-300</td></tr>',
'<tr><td>Rousse</td><td>-</td><td>-200</td><td>-100</td></tr>',
'</table>'
]);