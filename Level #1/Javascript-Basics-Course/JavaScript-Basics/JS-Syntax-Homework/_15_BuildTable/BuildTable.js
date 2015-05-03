/**
 * Created by Rosen on 11.11.2014 г..
 */
function solve(arr) {
    var start = parseInt(arr[0]);
    var end = parseInt(arr[1]);
    console.log("<table>");
    console.log("<tr><th>Num</th><th>Square</th><th>Fib</th></tr>");
    for (var i = start; i <= end ; i++) {
        var perfSq1 = 5*i*i + 4;
        var perfSq2 = 5*i*i - 4;
        var s1 = Math.floor(Math.sqrt(perfSq1));
        var s2 = Math.floor(Math.sqrt(perfSq2));
        var resultSq1 = (s1*s1 == perfSq1);
        var resultSq2 = (s2*s2 == perfSq2);
        if(resultSq1 || resultSq2) {
            var fib = "yes";
        } else {
            var fib = "no";
        }

        console.log("<tr><td>"+i+"</td><td>"+i*i+"</td><td>"+fib+"</td></tr>");
    }
    console.log("</table>");
}

solve([2,6]);
solve([55,56]);


