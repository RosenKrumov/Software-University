var drunk = 0;
var memory_array = ['A', 'A', 'B', 'B', 'C', 'C', 'D', 'D', 'E', 'E', 'F', 'F', 'G', 'G', 'H', 'H', 'I', 'I', 'J', 'J', 'K', 'K', 'L', 'L'];
var memory_values = [];
var memory_tile_ids = [];
var tiles_flipped = 0;
Array.prototype.memory_tile_shuffle = function () {
    var i = this.length, j, temp;
    while (--i > 0) {
        j = Math.floor(Math.random() * (i + 1));
        temp = this[j];
        this[j] = this[i];
        this[i] = temp;
    }
}
function newBoard() {

    tiles_flipped = 0;
    var output = '';
    memory_array.memory_tile_shuffle();
    for (var i = 0; i < memory_array.length; i++) {
        output += '<div id="tile_' + i + '" onclick="memoryFlipTile(this,\'' + memory_array[i] + '\')"></div>';
    }
    document.getElementById('memory_board').innerHTML = output;
    document.getElementById('win').style.display='none';
    clearScreen();
    drunk=0;

}
function memoryFlipTile(tile, val) {
    if (tile.innerHTML == "" && memory_values.length < 2) {

        tile.innerHTML = val;
        switch (val) {
            case 'A':
                tile.innerHTML="<img src='Images/blackLabel.png' width='100' height='140'>";
                break;
            case 'B':
                tile.innerHTML="<img src='Images/blue_label.png' width='100' height='140'>";
                break;
            case 'C':
                tile.innerHTML="<img src='Images/chivas.png' width='100' height='140'>";
                break;
            case 'D':
                tile.innerHTML="<img src='Images/gentleman.png' width='100' height='140'>";
                break;
            case 'E':
                tile.innerHTML="<img src='Images/Grants.png' width='100' height='140'>";
                break;
            case 'F':
                tile.innerHTML="<img src='Images/greenLabel.png' width='100' height='140'>";
                break;
            case 'G':
                tile.innerHTML="<img src='Images/Jack.png' width='100' height='140'>";
                break;
            case 'H':
                tile.innerHTML="<img src='Images/Jack-Honey.png' width='100' height='140'>";
                break;
            case 'I':
                tile.innerHTML="<img src='Images/johnnie.png' width='100' height='140'>";
                break;
            case 'J':
                tile.innerHTML="<img src='Images/premier.png' width='100' height='140'>";
                break;
            case 'K':
                tile.innerHTML="<img src='Images/turkey.png' width='100' height='140'>";
                break;
            case 'L':
                tile.innerHTML="<img src='Images/whistlepig.png' width='100' height='140'>";
                break;
        }
        if (memory_values.length == 0) {
            memory_values.push(val);
            memory_tile_ids.push(tile.id);
            rotate(tile.id)

        } else if (memory_values.length == 1) {
            memory_values.push(val);
            memory_tile_ids.push(tile.id);
            rotate(tile.id);

            if (memory_values[0] == memory_values[1]) {
                tiles_flipped += 2;
                // Clear both arrays
                memory_values = [];
                memory_tile_ids = [];
                // Check to see if the whole board is cleared
                if (tiles_flipped == memory_array.length) {
                    setTimeout(hideBoardShowWin, 1900);
                }
            } else {
                function flip2Back() {

                    drunk += 2;
                    if(drunk >= 64){
                        youTooDrunkMotherFucka();
                        drunk = 0;
                    }
                    // Flip the 2 tiles back over
                    var tile_1 = document.getElementById(memory_tile_ids[0]);
                    var tile_2 = document.getElementById(memory_tile_ids[1]);



                    // Clear both arrays
                    rotateBack(memory_tile_ids[0]);

                    rotateBack(memory_tile_ids[1]);

                    setTimeout(function () {
                        tile_2.innerHTML = "";
                    }, 435);

                    setTimeout(function () {
                        tile_1.innerHTML = "";
                    }, 435);


                    memory_values = [];
                    memory_tile_ids = [];

                }

                setTimeout(flip2Back, 2500);
            }
        }
    }

}

function rotate(ids) {
    var div = document.getElementById(ids);
    var insideDiv = div.innerHTML;
    div.innerHTML = '';
    console.log(insideDiv);
    div.style.transform = 'rotateY(180deg)';
    div.style.transition = '2s';
    setTimeout(function () {
        div.innerHTML = insideDiv
    }, 634);
}
function rotateBack(idsb) {
    var div = document.getElementById(idsb);
    var insideDiv = div.innerHTML;

    div.style.transition = '1.5s';
    div.style.transform = 'rotateY(0deg)';

}
function hideBoardShowWin(){
    document.getElementById('win').style.display = 'block';
    var k = document.getElementById('memory_board');
    k.style.display = 'none';
    var c = document.getElementById('canvas');
    c.style.display='block';
    var b = document.getElementsByTagName('body');
    b.style.overflow='hidden';




}
function youTooDrunkMotherFucka(){
    var r = document.getElementById('memory_board');
    r.style.display = 'none';
    var p = document.getElementById('lose');
    p.style.display = 'block';
    $('body').css("background","black");
}
function clearScreen(){
    var r = document.getElementById('memory_board');
    r.style.display = 'block';
    var p = document.getElementById('lose');
    p.style.display = 'none';
    document.getElementById("canvas").style.display='none'
    document.getElementById("win").style.display='none !important;';

    $('body').css("background","white");


}



