function findNthDigit(arr) {
    var num = arr[1];
    var n = arr[0];

    num = num.toString().split("").reverse().join("").replace(/[.,\-\+]/g, "");

    if (n <= num.length) {
        return num.charAt(n - 1);
    } else {
        return undefined;
    }
}

console.log(findNthDigit([1, 6]));
console.log(findNthDigit([2, -55]));
console.log(findNthDigit([6, 923456]));
console.log(findNthDigit([3, 1451.78]));
console.log(findNthDigit([6, 888.88]));