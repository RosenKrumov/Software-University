/**
 * Created by Rosen on 18.11.2014 г..
 */
function replaceSpaces(str) {
    var strArr = str.split('');
    for (var i = 0; i < strArr.length; i++) {
        if(strArr[i] == ' ') {
            strArr[i] = '';
        }
    }
    console.log(strArr.join(''));
}

replaceSpaces('But you were living in another world tryin\' ' +
'to get your message through');