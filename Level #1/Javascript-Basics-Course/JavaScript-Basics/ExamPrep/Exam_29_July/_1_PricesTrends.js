/**
 * Created by Rosen on 22.11.2014 г..
 */
function pricesTrends(arr) {
    var numbers = [];

    for (var i = 0; i < arr.length; i++) {
        numbers[i] = parseFloat(arr[i]);
    }

    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');
    console.log('<tr><td>'+numbers[0].toFixed(2)+
    '</td><td><img src="fixed.png"/></td></td>');
    for (var i = 1; i < numbers.length; i++) {
        var nextOutputNum = numbers[i].toFixed(2);
        var previousOutputNum = numbers[i-1].toFixed(2);
        if(parseFloat(nextOutputNum) > parseFloat(previousOutputNum)) {
            console.log('<tr><td>'+nextOutputNum+
            '</td><td><img src="up.png"/></td></td>');
        } else if(parseFloat(nextOutputNum) < parseFloat(previousOutputNum)) {
            console.log('<tr><td>'+nextOutputNum+
            '</td><td><img src="down.png"/></td></td>');
        } else {
            console.log('<tr><td>'+nextOutputNum+
            '</td><td><img src="fixed.png"/></td></td>');
        }
    }

    console.log('</table>');
}

pricesTrends(['36.333', '36.5', '37.019', '35.4',
    '35', '35.001', '36.225']);