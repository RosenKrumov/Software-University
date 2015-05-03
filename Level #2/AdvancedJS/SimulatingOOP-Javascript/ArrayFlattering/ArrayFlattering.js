Array.prototype.flatten = function() {
    var flattened = [];
    var index = 0;

    function flatten(elements) {
        for (var i = 0; i < elements.length; i++) {
            if (Object.prototype.toString.call(elements[i]) === "[object Array]") {
                flatten(elements[i]);
            } else {
                flattened[index] = elements[i];
                index++;
            }
        }
    }

    flatten(this);
    return flattened;
};
var array = [1, 2, 3, 4, [5, 6]];
console.log(array.flatten());