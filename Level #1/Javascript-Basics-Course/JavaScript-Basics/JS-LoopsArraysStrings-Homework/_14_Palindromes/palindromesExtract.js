/**
 * Created by Rosen on 18.11.2014 г..
 */
function findPalindromes(str) {
    var strArr = str.split(/\W+/g);
    var palindromes = [];
    var index = 0;
    for (var i = 0; i < strArr.length; i++) {
        if(strArr[i] == '') {
            continue;
        }
        else {
            if(strArr[i].toLowerCase().split('').reverse().join('')
                == strArr[i].toLowerCase()) {
                  palindromes[index] = strArr[i];
                index++;
            }
        }
    }
    console.log(palindromes);
}

findPalindromes('There is a man, his name was Bob.');