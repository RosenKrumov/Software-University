/**
 * Created by Rosen on 12.11.2014 г..
 */
function solve(arr) {
    var firstStar = arr[0];
    firstStar = firstStar.split(/[ ,]+/);
    var secondStar = arr[1];
    secondStar = secondStar.split(/[ ,]+/);
    var thirdStar = arr[2];
    thirdStar = thirdStar.split(/[ ,]+/);
    var spaceShip = arr[3];
    spaceShip = spaceShip.split(/[ ,]+/);
    var turns = parseFloat(arr[4]);

    var firstStarName = firstStar[0];
    var firstStarX = parseFloat(firstStar[1]);
    var firstStarY = parseFloat(firstStar[2]);

    var secondStarName = secondStar[0];
    var secondStarX = parseFloat(secondStar[1]);
    var secondStarY = parseFloat(secondStar[2]);

    var thirdStarName = thirdStar[0];
    var thirdStarX = parseFloat(thirdStar[1]);
    var thirdStarY = parseFloat(thirdStar[2]);

    var spaceShipX = parseFloat(spaceShip[0]);
    var spaceShipY = parseFloat(spaceShip[1]);

    for (var i = 0; i <= turns; i++) {

        if((spaceShipX >= firstStarX - 1) && (spaceShipX <= firstStarX + 1) &&
            (spaceShipY >= firstStarY - 1) && (spaceShipY <= firstStarY + 1)) {

            console.log(firstStarName.toLowerCase());
        } else if((spaceShipX >= secondStarX - 1) && (spaceShipX <= secondStarX + 1) &&
            (spaceShipY >= secondStarY - 1) && (spaceShipY <= secondStarY + 1)) {

            console.log(secondStarName.toLowerCase());
        } else if((spaceShipX >= thirdStarX - 1) && (spaceShipX <= thirdStarX + 1) &&
            (spaceShipY >= thirdStarY - 1) && (spaceShipY <= thirdStarY + 1)) {

            console.log(thirdStarName.toLowerCase());
        } else {
            console.log("space");
        }
        spaceShipY++;
    }
}

solve(["Sirius 3 7",
    "Alpha-Centauri 7 5",
    "Gamma-Cygni 10 10",
    "8 1",
    "6"
]);