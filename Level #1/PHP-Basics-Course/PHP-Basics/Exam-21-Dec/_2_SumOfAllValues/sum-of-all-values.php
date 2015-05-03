<?php

$keys_string = $_GET['keys'];
$text_string = $_GET['text'];
$pattern = '/([A-Za-z_]+)(?=\d*\.\d+).+(?<=\d*\.\d+)([A-Za-z_]+)/';

$sum = 0.0;

preg_match($pattern, $keys_string, $matches);

$matches = array_filter($matches);

if(count($matches) < 3) {
    echo "<p>A key is missing</p>";
    die();
}

$start_key = $matches[1];
$end_key = $matches[2];

function get_string_between($string, $start, $end)
{
    $string = " " . $string;
    $ini = strpos($string, $start);
    if ($ini == 0) return "";
    $ini += strlen($start);
    $len = strpos($string, $end, $ini) - $ini;
    return substr($string, $ini, $len);
}

$values = [];

while (strlen($text_string) > strlen($start_key . $end_key)) {
    $parsed = get_string_between($text_string, $start_key, $end_key);
    $values[] = $parsed;
    $begin = strpos($text_string, $end_key) + strlen($end_key);
    $text_string = substr($text_string, $begin, strlen($text_string) - $begin);
}

$values = array_filter($values);
$values = array_unique($values);


foreach ($values as $val) {
    if (is_numeric($val)) {

        $sum += floatval($val);
    }
}

if ($sum == 0) {
    echo "<p>The total value is: <em>nothing</em></p>";
} else {
    echo "<p>The total value is: <em>$sum</em></p>";
}

?>