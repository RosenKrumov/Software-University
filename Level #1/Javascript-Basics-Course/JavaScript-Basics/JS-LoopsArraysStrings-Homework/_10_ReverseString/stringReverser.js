/**
 * Created by Rosen on 18.11.2014 г..
 */
function reverseString(str) {
    var strArr = [];

    for (var i = 0; i < str.length; i++) {
        strArr[i] = str[i];
    }

    strArr.reverse();

    console.log(strArr.join(''));
}

reverseString('sample');
reverseString('softUni');
reverseString('java script');