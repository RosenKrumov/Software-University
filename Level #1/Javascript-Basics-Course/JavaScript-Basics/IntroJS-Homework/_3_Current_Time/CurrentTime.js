/**
 * Created by Rosen on 4.11.2014 г..
 */
var currentTime = new Date();
var currentHour = currentTime.getHours();
var currentMins = currentTime.getMinutes();
if (currentMins < 10) {
    currentMins = "0" + currentMins;
}
console.log(currentHour + ":" + currentMins);