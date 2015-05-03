<?php
$text = $_GET['text'];
$hashValue = htmlentities($_GET['hashValue']);
$fontSize = htmlentities($_GET['fontSize']);
$style = htmlentities($_GET['fontStyle']);
$fontStyle = getTag($style);
$output = '';

for ($i = 0; $i < strlen($text); $i++) {
    $code = ord($text[$i]);
    if($i % 2 == 0) {
        $code += (int)$hashValue;
        $text[$i] = chr($code);
    } else {
        $code -= (int)$hashValue;
        $text[$i] = chr($code);
    }
}

$output .= "<p style=\"font-size:$fontSize;$fontStyle\">";
$output.= $text;
$output .= '</p>';
echo $output;

function getTag($style) {
    switch ($style) {
        case "normal":
        case "italic":
            return "font-style:$style;";
        case "bold":
            return "font-weight:bold;";
        default: return "";
    }
}
?>
