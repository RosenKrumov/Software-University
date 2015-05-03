/**
 * Created by Rosen on 12.11.2014 г..
 */
function solve(arr) {
    var bill = arr[0];
    var mood = arr[1];
    if(mood == "happy") {
        var tip = bill/10;
        tip = tip.toFixed(2);
        console.log(tip);
    } else if (mood == "married") {
        var tip = 0.0005 * bill;
        tip = tip.toFixed(2);
        console.log(tip);
    } else if (mood == "drunk") {
        var tempTip = 15 * bill / 100;
        var tempTipInt = parseInt(tempTip);
        while (tempTipInt > 0) {
            var firstDig = parseInt(tempTipInt % 10);
            tempTipInt /= 10;
            tempTipInt = parseInt(tempTipInt);
        }
        var tip = Math.pow(tempTip, firstDig);
        tip = tip.toFixed(2);
        console.log(tip);
    } else {
        var tip = bill/20;
        tip = tip.toFixed(2);
        console.log(tip);
    }
}

