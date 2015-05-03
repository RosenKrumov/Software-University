/**
 * Created by Rosen on 18.11.2014 г..
 */
function countSubstringOccur(arr) {

    var keyword = arr[0];
    var text = arr[1];
    var occurences = 0;
    for (var i = 0; i < text.length; i++) {
        if(text.substr(i, keyword.length) === keyword) {
            occurences++;
        }
    }
    console.log(occurences);
}

countSubstringOccur(['in', 'We are living in a yellow submarine. We don\'t have anything else. ' +
'Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.']);