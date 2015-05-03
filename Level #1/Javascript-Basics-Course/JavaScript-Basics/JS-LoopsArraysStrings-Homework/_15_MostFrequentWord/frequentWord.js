/**
 * Created by Rosen on 18.11.2014 г..
 */
function findMostFreqWord(str) {
    var strArr = str.toLowerCase().split(/\W+/g);
    var obj = { };

    for (var i = 0; i < strArr.length; i++) {
        if(strArr[i] == ' ') {
            continue;
        } else {
            if(obj[strArr[i]] == undefined) {
                obj[strArr[i]] = 1;
            } else {
                obj[strArr[i]]++;
            }
        }
    }

    var outputObj = { };

    var maxFrequency = 0;

    for (var word in obj) {
        var currFreq = obj[word];
        if(maxFrequency < currFreq) {
            maxFrequency = currFreq;
        }
    }

    for (var word in obj) {
        var currFreq = obj[word];
        if(currFreq == maxFrequency) {
            outputObj[word] = obj[word];
        }
    }

    var keys = [],
        k, i, len;

    for (k in outputObj)
    {
        if (outputObj.hasOwnProperty(k))
        {
            keys.push(k);
        }
    }

    keys.sort();

    len = keys.length;

    for (i = 0; i < len; i++)
    {
        k = keys[i];
        console.log(k + ' -> ' + outputObj[k] + ' times');
    }
}

findMostFreqWord('in the middle of the night');
findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.');
findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.');