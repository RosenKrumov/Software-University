function add(num) {

    var sum = num;
    
    function f(arg) {
        sum += arg;
        return f;
    }
    
    f.toString = function() {
        return sum;
    }

    return f;
}

var addTwo = +add(2);
console.log(addTwo);

addTwo = add(2);
console.log(+addTwo(3));