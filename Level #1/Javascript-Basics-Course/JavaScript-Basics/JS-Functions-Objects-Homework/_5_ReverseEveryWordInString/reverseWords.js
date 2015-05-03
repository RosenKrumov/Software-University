function reverseWordsInString(str) {
    //var arrayOfWords = str.match(/([\w'\w]+)|('\w+)|(\w+')|(\w+)/g);

    var arrayOfWords = str.split(" ");
    var retString = "";
    for (var i = 0; i < arrayOfWords.length; i++) {

        retString += reverseWord(arrayOfWords[i]) + " ";
    }
    return retString;

    function reverseWord(word) {
        return word.split("").reverse().join("");
    }
}

console.log(reverseWordsInString('Hello, how are you.'));
console.log(reverseWordsInString("Life is pretty good, isn't it?"));