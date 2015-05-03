<?php

$text = $_GET['text'];
$length = $_GET['lineLength'];
$index = 0;
if(strlen($text) % $length != 0) {
    $rows = strlen($text) / (int)$length + 1;
} else {
    $rows = strlen($text) / (int)$length;
}

$matrix = [];

$line = [];

for ($i = 0; $i < (int)$rows; $i++) {
    for ($j = 0; $j < (int)$length; $j++) {
        if($index == strlen($text)) {
            $line[] = ' ';
        } else {
            $line[] = $text[$index];
            $index++;
        }
    }
    $matrix[] = $line;

    $line = [];
}

for ($i = count($matrix) - 2; $i >= 0; $i--) {
    for ($j = count($matrix[$i]) - 1; $j >= 0; $j--) {
        if(($matrix[$i+1][$j] == ' ') && $matrix[$i][$j] != ' ') {
            $index1 = $i + 1;
            $a = $i;
            while($index1 < count($matrix) && $matrix[$index1][$j] == ' ') {
                $matrix[$i + 1][$j] = $matrix[$i][$j];
                $matrix[$i][$j] = ' ';
                $index1++;
                $i++;
            }
            $i = $a;
        }
    }
}

$output = "<table>";

for ($i = 0; $i < count($matrix); $i++) {
    $output .= "<tr>";
    for ($j = 0; $j < count($matrix[0]); $j++) {
        $output .= "<td>".htmlspecialchars($matrix[$i][$j])."</td>";
    }
    $output .= "</tr>";
}

$output .= "<table>";

echo $output;

?>
