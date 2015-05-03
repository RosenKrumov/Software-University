/**
 * Created by Rosen on 18.11.2014 г..
 */
function findMinAndMax(arr) {
    var min;
    var max;
    arr.sort(
        function(a, b) {
            return a > b;
        }
    );
    min = arr[0];
    max = arr[arr.length - 1];
    console.log('Min -> ' + min);
    console.log('Max -> ' + max);
}

findMinAndMax([1, 2, 1, 15, 20, 5, 7, 31]);
findMinAndMax([2, 2, 2, 2, 2]);
findMinAndMax([500, 1, -23, 0, -300, 28, 35, 12]);