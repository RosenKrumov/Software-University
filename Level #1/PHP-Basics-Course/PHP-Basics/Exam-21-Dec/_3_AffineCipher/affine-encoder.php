<?php

$json = $_GET['jsonTable'];
$data = json_decode($json);

$words = $data[0];
$words = array_filter($words);
$first_key = $data[1][0];
$second_key = $data[1][1];

$max_length = 0;

foreach ($words as $w) {
    if($max_length < strlen($w)) {
        $max_length = strlen($w);
    }
}

$alphabet_count = 26;

$output_matrix = [];


foreach ($words as $word) {
    $row = [];

    for ($i = 0; $i < strlen($word); $i++) {
        if(ctype_alpha($word[$i])) {
            $sum = 0;
            $position = ord(strtoupper($word[$i])) - ord('A');
            $sum +=((($first_key * $position) + $second_key) % $alphabet_count) + 65;
            $row[] = chr($sum);
        } else {
            if(!ctype_space($word[$i])) {
                $row[] = $word[$i];
            }
        }
    }
    for ($i = count($row); $i < $max_length; $i++) {
        $row[] = '';
    }

    $output_matrix[] = $row;
}

if(count($output_matrix) > 0) {
    $output = "<table border='1' cellpadding='5'>";

    foreach ($output_matrix as $output_row) {
        $output .= "<tr>";
        foreach ($output_row as $cell) {
            if($cell != '') {
                $output .= "<td style='background:#CCC'>$cell</td>";
            } else {
                $output .= "<td>$cell</td>";
            }
        }
        $output .= "</tr>";
    }

    $output .= "</table>";


} else {
    $output = "<table border='1' cellpadding='5'><tr><td></td></tr></table>";
}

echo $output;


?>
