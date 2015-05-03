<?php

function doubleWordLetters($rev) {
    $double = '';

    for ($i = 0; $i < strlen($rev); $i++) {
        $double .= $rev[$i] . $rev[$i];
    }

    return $double;
}

function checkUpper($word){
    if(ctype_upper($word)) {
        $rev = strrev($word);
        if($rev == $word) {
            $word = doubleWordLetters($rev);
        } else {
            $word = $rev;
        }
    }

    return $word;
}

$text = htmlspecialchars($_GET['text']);

$word = '';
$result = '';

for ($i = 0; $i < strlen($text); $i++) {
    if(ctype_alpha($text[$i])) {
        $word .= $text[$i];
    } else {

        $word = checkUpper($word);

        $result .= $word.$text[$i];

        $word = '';
    }
}

$word = checkUpper($word);

$result .= $word;

echo "<p>$result</p>";

?>
