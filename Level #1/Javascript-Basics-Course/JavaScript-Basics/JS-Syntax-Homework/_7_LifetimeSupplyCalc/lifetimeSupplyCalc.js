/*** Created by Rosen on 9.11.2014 г..*/
var DAYS_PER_YEAR = 365;

var age = 38;
var maxAge = 118;
var food = "chocolate";
var foodPerDay = 0.5;

function calcSupply(age, maxAge, food, foodPerDay) {
    var remainingAges = maxAge - age;
    var sum = remainingAges * foodPerDay * DAYS_PER_YEAR;
    console.log(sum + "kg of " + food +
        " would be enough until I am " + maxAge + " years old");
}

calcSupply(age, maxAge, food, foodPerDay);

age = 20;
maxAge = 87;
food = "fruits";
foodPerDay = 2;
calcSupply(age, maxAge, food, foodPerDay);

age = 16;
maxAge = 102;
food = "nuts";
foodPerDay = 1.1;
calcSupply(age, maxAge, food, foodPerDay);