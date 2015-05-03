/**
 * Created by Rosen on 18.11.2014 г..
 */
function createArray() {
    var arr = new Array(20);

    for (var i = 0; i < arr.length; i++) {
        arr[i] = 5*i;
    }

    console.log(arr.join(' '));
}

createArray();

/* There is a mistake in the output, it should be to 95, not 100 */