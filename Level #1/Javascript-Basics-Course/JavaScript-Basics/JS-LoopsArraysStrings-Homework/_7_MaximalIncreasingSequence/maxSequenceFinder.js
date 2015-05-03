/**
 * Created by Rosen on 18.11.2014 г..
 */
function findMaxSequence(arr)  {
    var maxCount = 1;
    var tempCount = 1;
    var lastIndex = 0;
    var tempIndex = 0;
    var resultArr = [];
    var sequenceFound = false;

    for(var i = 0; i < arr.length - 1; i++) {
        if(arr[i] < arr[i + 1]) {
            tempCount++;
            tempIndex = i + 1;
            sequenceFound = true;
            if(i === arr.length - 2){
                if (tempCount > maxCount) {
                    maxCount = tempCount;
                    lastIndex = tempIndex;
                }
            }
        } else {
            if (tempCount > maxCount) {
                maxCount = tempCount;
                lastIndex = tempIndex;
            }
            tempCount = 1;
        }
    }

    if (sequenceFound == false) {
        console.log('no');
        return;
    } else {
        var startIndex = lastIndex - maxCount + 1;

        for (var i = startIndex, j = 0; i < startIndex + maxCount; i++, j++) {
            resultArr[j] = arr[i];
        }
        console.log(resultArr);
    }
}

findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);
findMaxSequence([3, 2, 1]);