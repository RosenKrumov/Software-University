/**
 * Created by Rosen on 18.11.2014 г..
 */
function displayProperties() {
    var arr = Object.getOwnPropertyNames([document]);
    arr.sort(
        function (a, b) {
            return a.toLowerCase() > b.toLowerCase();
        }
    );
    console.log(arr.join('\n'));
}

displayProperties();

/*  I DO NOT KNOW WHY BUT THIS PROGRAM IS NOT WORKING...
    I SAW ALL THE POSTED HOMEWORKS ON THE FORUM AND
    THE CODE WAS ABSOLUTELY THE SAME... IF YOU CAN
    TELL ME WHY IS THIS HAPPENING ...    */