function printArgsInfo() {
    for (var i = 0; i < arguments.length; i++) {
        if (Array.isArray(arguments[i])) {
            console.log(arguments[i] + " (array)");
        } else {
            console.log(arguments[i] + " (" + typeof (arguments[i]) + ")");
        }
    }
}

//printArgsInfo.call(null, 2, 3, 2.5, -110.5564, false);
//printArgsInfo.call();
//printArgsInfo.apply(null, [[1, 2], ["string", "array"], ["single value"]]);
//printArgsInfo.apply();
//printArgsInfo.apply(null, [[1, [2, [3, [4, 5]]]], ["string", "array"]]);