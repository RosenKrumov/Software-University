<?php

$input = $_GET['priceList'];
$pattern = '/<td>\s*([^<]+)\s*<\/td>/';
preg_match_all($pattern, $input, $matches, PREG_SET_ORDER);

$obj = [];

for ($i = 0; $i < count($matches); $i+=4) {
    $name = $matches[$i][1];
    $name = trim($name);
    $name = html_entity_decode($name);

    $type = $matches[$i+1][1];
    $type = trim($type);
    $type = html_entity_decode($type);

    $price = $matches[$i+2][1];
    $price = trim($price);
    $price = html_entity_decode($price);

    $currency = $matches[$i+3][1];
    $currency = trim($currency);
    $currency = html_entity_decode($currency);

    if(!isset($obj[$type])) {
        $obj[$type] = [];
    }

    $data = [
        "product" => $name,
        "price" => $price,
        "currency" => $currency
    ];

    $obj[$type][] = $data;
}

ksort($obj);
$output = '{';
//foreach($obj as $k => $v) {
//    var_dump($k);
//}

foreach ($obj as $k => $products) {

    $output .= '"'.$k.'":';
    usort($products, function($a, $b){
        return strcmp($a['product'], $b['product']) > 0;

    });
    $output .= json_encode($products);
    $output .= ",";
}
$output = rtrim($output, ",");
$output .= "}";
echo $output;




?>
