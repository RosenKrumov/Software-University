var button = document.getElementById("button1");
button.addEventListener("click", buttonClicked);

if (button.value == '') {
    button.value = 'LIKE'
}

function buttonClicked() {

    if (button.value == 'LIKE') {
        button.value = 'UNLIKE';
    } else {
        button.value = 'LIKE';
    }
}


