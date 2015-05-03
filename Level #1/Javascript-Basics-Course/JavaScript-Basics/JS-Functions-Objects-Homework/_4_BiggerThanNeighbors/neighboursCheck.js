function biggerThanNeighbors(index, arr) {
    var len = arr.length;
    var maxIndex = arr.length - 1;
    var minIndex = 0;

    if (len == 0 || index >= maxIndex || index <= minIndex) { //empty array or index out of range
        return undefined;
    } else {
        if ( arr[index] > arr[index - 1] && arr[index] > arr[index + 1] ) {
            return "Bigger";
        }
        else {
            return "Not bigger"
        }
    }

}

console.log(biggerThanNeighbors(5, [1, 2, 5, 3, 4]));
console.log(biggerThanNeighbors(2, [1, 2, 3, 3, 5]));
console.log(biggerThanNeighbors(2, [1, 2, 5, 3, 4]));
console.log(biggerThanNeighbors(0, [1, 2, 5, 3, 4]));