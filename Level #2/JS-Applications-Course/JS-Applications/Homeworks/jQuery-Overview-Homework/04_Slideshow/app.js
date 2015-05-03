$(document).ready(function () {
    var pics = [$("#main"), $("#second"), $("#third")];
    var index = 0;
    var checkRight = false;
    var checkLeft = false;
    var sec = 5;
    var timerCheck = true;
    var slideRight = ($("#right").click(function () {
        checkRight = true;
        timerCheck = false;
        if (checkRight == true) {
            $(pics[index]).hide(1500);
            index += 1;
            $(pics[index]).show(4000);
        }
        if (index == pics.length) {
            $(pics[0]).show(1500);
            index = 0;
        }
        return index,
            timerCheck;
    }));
    var slideLeft = $("#left").click(function () {
        checkLeft = true;
        if (checkLeft == true) {
            $(pics[index]).hide(1500);
            index -= 1;
            $(pics[index]).show(4000);
        }
        if (index == -1) {
            $(pics[2]).show(1500);
            index = 2;
        }
        timerCheck = false;
        return timerCheck;
    });
    var timer = (setInterval(function () {
        sec--;
        if (sec == 0) {
            $(pics[index]).hide(1500);
            index += 1;
            $(pics[index]).show(4000);
            sec = 5;

        }
        if (timerCheck == false) {
            sec = 5;
        }
        return index;
    }, 1000));
});