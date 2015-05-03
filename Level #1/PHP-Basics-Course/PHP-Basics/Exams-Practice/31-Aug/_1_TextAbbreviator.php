<?php
$list = $_GET['list'];
$maxSize = $_GET['maxSize'];
$output = "<ul>";
$lines = explode("\n", $list);
foreach ($lines as $l) {
    $l = trim($l);
    if($l == '') {
        continue;
    }
    if(strlen($l) <= (int)$maxSize) {
        $output .= '<li>' . htmlspecialchars($l) . '</li>';
    } else {
        $output .= '<li>' . htmlspecialchars(substr($l, 0, (int)$maxSize)) . '...</li>';
    }
}
$output .= "</ul>";
echo $output;
?>
