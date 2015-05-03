/**
 * Created by Rosen on 18.11.2014 г..
 */
function sortArray(arr) {
    selectionSort(arr);

    console.log(arr.join(', '));
}

function selectionSort (arr) {
    var i, j, tmp, tmp2;
    for (i = 0; i < arr.length - 1; i++) {
        tmp = i;
        for (j = i + 1; j < arr.length; j++) {
            if (arr[j] < arr[tmp]) {
                tmp = j;
            }
        }
        if (tmp != i) {
            tmp2 = arr[tmp];
            arr[tmp] = arr[i];
            arr[i] = tmp2;
        }
    }
}
sortArray([5, 4, 3, 2, 1]);
sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]);