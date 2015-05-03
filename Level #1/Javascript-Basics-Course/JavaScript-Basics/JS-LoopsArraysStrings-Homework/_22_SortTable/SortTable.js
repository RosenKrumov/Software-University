/**
 * Created by Rosen on 20.11.2014 г..
 */
function sortTable(arr) {
    var output = [];
    console.log(arr[0]);
    console.log(arr[1]);
    arr.sort();
    for(var i = 2; i < arr.length - 1; i++) {
        var row = arr[i].match(/(\d*[.])?\d+/g);
        var key = parseFloat(row[row.length-2]);
        output[i - 2] = [key, arr[i]];
    }
    output.sort(
        function(a, b) {
            return a[0] - b[0];
        }
    );
    for (var i = 0, j = 1; i < output.length; i++) {
        console.log(output[i][j]);
    }
    console.log(arr[0]);
}

sortTable([  '<table>',
            '<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
            '<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
            '<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
            '<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>',
            '<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
            '<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>',
            '<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
            '</table>'
]);