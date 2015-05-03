<?php

$html = $_GET['html'];
$pattern = '/<div\s*.*?\s*(id\s*=\s*\"(\w+)\"|class\s*=\s*\"(\w+)\")|<!--\s*\w+\s*-->/';


preg_match_all($pattern, $html, $attributes, PREG_SET_ORDER);


foreach ($attributes as $attribute) {
    $attribute = array_filter($attribute);
    $attribute = array_values($attribute);

    if(count($attribute) > 1) {
        $attr_name = $attribute[1];
        $attr = $attribute[2];
        $html = str_replace($attr_name, '', $html);
        $html = str_replace('div', $attr, $html);
        $html = str_replace('  ', ' ', $html);
    } else {
        $attr = $attribute[0];
        $html = str_replace($attr, '', $html);
        $html = str_replace('  ', ' ', $html);
    }

}

$lines = explode("\n", $html);

foreach ($lines as $line) {
    $line = trim($line);
    if($line[strlen($line) - 2] == ' ') {
        $line = substr($line, 0, strlen($line) - 2).'>';
    }
    echo "$line\n";
}

$html = implode("\n", $lines);



?>
