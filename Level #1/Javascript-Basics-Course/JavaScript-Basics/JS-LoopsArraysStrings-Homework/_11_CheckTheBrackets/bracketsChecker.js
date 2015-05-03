/**
 * Created by Rosen on 18.11.2014 г..
 */
function checkBrackets(str) {
    var strArr = [];
    for (var i = 0; i < str.length; i++) {
        strArr[i] = str[i];
    }

    var bracketsArr = [];

    for (var i = 0, j = 0; i < strArr.length; i++) {
        if(strArr[i] == '(' || strArr[i] == ')') {
            bracketsArr[j] = strArr[i];
            j++;
        }
    }

    var leftBracketsCount = 0;
    var rightBracketsCount = 0;

    for (var i = 0; i < bracketsArr.length; i++) {
        if(bracketsArr[i] == '(') {
            leftBracketsCount++;
        } else {
            rightBracketsCount++;
        }
    }

    if(leftBracketsCount == rightBracketsCount) {
        console.log('correct');
    } else {
        console.log('incorrect');
    }
}

checkBrackets('( ( a + b ) / 5 – d )');
checkBrackets(') ( a + b ) )');
checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )');