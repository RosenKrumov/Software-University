function sumTwoHugeNumbers(value) {
    var x = value[0];
    var y = value[1];

    var lenX = x.length - 1;
    var lenY = y.length - 1;
    var sum = "";
    var carry = 0;
    while (true) {
        if (lenX < 0 && lenY < 0) {
            return sum;
        }

        var tempX = parseInt(x.charAt(lenX));
        var tempY = parseInt(y.charAt(lenY));

        tempX = isNaN(tempX) ? 0 : tempX;
        tempY = isNaN(tempY) ? 0 : tempY;

        var tempSum = tempX + tempY + carry;

        carry = (tempSum > 9) ? 1 : 0;

        if (carry) {
            var partial = tempSum.toString();
            sum = partial.substr(partial.length - 1, 1) + sum;
        } else {
            sum = tempSum.toString() + sum;
        }

        lenX--;
        lenY--;
    }
}

console.log(sumTwoHugeNumbers(['155', '65']));
console.log(sumTwoHugeNumbers(['123456789', '123456789']));
console.log(sumTwoHugeNumbers(['887987345974539','4582796427862587']));
console.log(sumTwoHugeNumbers(['347135713985789531798031509832579382573195807',
    '817651358763158761358796358971685973163314321']));