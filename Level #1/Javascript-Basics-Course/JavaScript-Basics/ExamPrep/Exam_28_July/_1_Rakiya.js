/**
 * Created by Rosen on 18.11.2014 г..
 */
function rakiyaNums(arr) {
    var startNum = arr[0];
    var endNum = arr[1];

    console.log('<ul>');
    for (var i = parseInt(startNum); i <= parseInt(endNum); i++) {
        if(isRakiyaNum(i)) {
            console.log('<li><span class=\'rakiya\'>' + i + '</span><a href="view.php?id=' + i + '>View</a></li>');
        } else {
            console.log('<li><span class=\'num\'>' + i + '</span></li>');
        }
    }
    console.log('</ul>');

    function isRakiyaNum(num) {
        for (var i = 0; i < num.toString().length; i++) {
            var index = i + 2;
            while(index < num.toString().length) {
                var digits = num.toString()[i] + num.toString()[i + 1] + '';
                var secondDigits = num.toString()[index] + num.toString()[index + 1] + '';
                if(digits == secondDigits) {
                    return true;
                }
                index++;
            }
        }
        return false;
    }
}

rakiyaNums(['55555', '55560']);