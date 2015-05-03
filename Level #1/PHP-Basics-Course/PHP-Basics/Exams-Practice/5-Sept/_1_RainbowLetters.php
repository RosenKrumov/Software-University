<?php
$text = $_GET['text'];
$red = $_GET['red'];
$green = $_GET['green'];
$blue = $_GET['blue'];
$nth = $_GET['nth'];
$index = (int)$nth - 1;

$redHex = dechex((int)$red);
$blueHex = dechex((int)$blue);
$greenHex = dechex((int)$green);

if(strlen($redHex) < 2) {
    $redHex = '0'.$redHex;
}
if(strlen($blueHex) < 2) {
    $blueHex = '0'.$blueHex;
}
if(strlen($greenHex) < 2){
    $greenHex = '0'.$greenHex;
}

$color = '#'.$redHex.$greenHex.$blueHex;
$output = '<p>';
for ($i = 0; $i < strlen($text); $i++) {
    if($i != $index) {
        $output .= htmlspecialchars($text[$i]);
    } else {
        $output .= '<span style="color: '.$color.'">'.htmlspecialchars($text[$i]).'</span>';
        $index += (int)$nth;
    }
}
$output .= '</p>';
echo $output;
?>
