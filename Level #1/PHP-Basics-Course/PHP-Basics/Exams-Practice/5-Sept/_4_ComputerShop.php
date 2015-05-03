<?php

$text = $_GET['list'];
$min_price = $_GET['minPrice'];
$max_price = $_GET['maxPrice'];
$type = $_GET['filter'];
$order = $_GET['order'];

$product_lines = preg_split('/[\r\n]+/', $text, -1, PREG_SPLIT_NO_EMPTY);

$products = [];
$id = 1;

foreach ($product_lines as $product_line) {
    $product_data = explode(' | ', $product_line);
    $name = $product_data[0];
    $product_type = $product_data[1];
    $components = explode(', ', $product_data[2]);
    $price = floatval($product_data[3]);

    $data = [
        "name" => $name,
        "type" => $type,
        "components" => $components,
        "price" => $price,
        "id" => $id
    ];

    if($price >= $min_price && $price <= $max_price &&
        ($product_type == $type || $type == 'all')) {

        $products[] = $data;
    }

    $id++;
}

usort($products, function($a, $b) use ($order) {
    if($a['price'] == $b['price']) {
        return $a['id'] - $b['id'];
    }
    if($order == 'ascending'){
        return $a['price'] > $b['price'] ? 1 : -1;
    } else {
        return $a['price'] < $b['price'] ? 1 : -1;
    }
});

foreach ($products as $product) {
    echo render($product);
}

function render($product) {
    $name = htmlspecialchars($product['name']);
    $type = htmlspecialchars($product['type']);
    $components = $product['components'];
    $price = number_format(htmlspecialchars($product['price']), 2, '.', '');
    $id = $product['id'];

    $html = '';
    $html .= "<div class=".'"product"'." id=".'"product'.$id.'"'.">";
    $html .= "<h2>$name</h2>";
    $html .= "<ul>";

    foreach ($components as $component) {
        $component = htmlspecialchars($component);
        $html .= "<li class=".'"component"'.">$component</li>";
    }

    $html .= "</ul>";
    $html .= "<span class=".'"price"'.">$price</span>";
    $html .= "</div>";

    return $html;
}

?>
