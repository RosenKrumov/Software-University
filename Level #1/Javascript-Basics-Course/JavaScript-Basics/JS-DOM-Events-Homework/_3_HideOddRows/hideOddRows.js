var b = document.getElementById("btnHideOddRows");
b.addEventListener("click", hideOddRows, false);

function hideOddRows() {

    var tbl = document.getElementById("myTable");
    var tr = tbl.rows;


    for (var i = 0; i < tr.length; i = i + 2) {
        tr.item(i).style.display = 'none';
    }
}