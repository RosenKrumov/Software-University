/**
 * Created by Rosen on 18.11.2014 г..
 */
function findMostFreqNum(arr) {
    var obj = { };

    for (var i = 0; i < arr.length; i++) {
        if(obj[arr[i]] == undefined) {
            obj[arr[i]] = 1;
        } else {
            obj[arr[i]]++;
        }
    }

    var mostFreqNum = 0;
    var frequency = 0;

    for (var num in obj) {
        var currFreq = obj[num];
        if(frequency < currFreq) {
            mostFreqNum = num;
            frequency = obj[num];
        }
    }

    console.log('%d (%d times)', mostFreqNum, frequency);

}

findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]);
findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]);
findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]);