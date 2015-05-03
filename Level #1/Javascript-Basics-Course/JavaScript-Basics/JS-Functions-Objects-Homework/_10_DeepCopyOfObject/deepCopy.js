function clone(obj) {
    var out = {};
    for (var property in obj) {
        if (obj[property] != null && typeof obj[property] === "object") {
            out[property] = obj[property];
        }
    }
    return out;
}

function compareObjects(obj, objCopy) {
    if (a == b ) {
        return true;
    } else {
        return false;
    }
}

var a = {name: 'Pesho', age: 21, wealth: [12, 32, 'dsds']};
var b = clone(a); // a deep copy

console.log("a == b --> " + compareObjects(a, b));

