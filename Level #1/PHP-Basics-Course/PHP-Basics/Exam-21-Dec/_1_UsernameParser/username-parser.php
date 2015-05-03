<?php

$list = $_GET['list'];
$length = $_GET['length'];

$names = preg_split('/[\n\r]/', $list, -1, PREG_SPLIT_NO_EMPTY);

$output = "<ul>";

foreach ($names as $name) {
    if(isset($_GET['show'])) {
        if(strlen($name) >= $length) {
            $output .= "<li>".htmlspecialchars($name)."</li>";
        } else if (strlen($name) < $length) {
            $output .= "<li style=\"color: red;\">".htmlspecialchars($name)."</li>";
        }
    } else {
        if(strlen($name) >= $length) {
            $output .= "<li>".htmlspecialchars($name)."</li>";
        }
    }
}

$output .= '</ul>';

echo $output;

?>
