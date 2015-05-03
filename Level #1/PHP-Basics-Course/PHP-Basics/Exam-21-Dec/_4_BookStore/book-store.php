<?php

date_default_timezone_set('Europe/Sofia');

$text = $_GET['text'];
$min_price = $_GET['min-price'];
$max_price = $_GET['max-price'];
$criteria = $_GET['sort'];
$order = $_GET['order'];

$lines = preg_split('/[\r\n]+/', $text, -1, PREG_SPLIT_NO_EMPTY);

$books = [];

foreach ($lines as $line) {
    $contents = preg_split('/\s*\/\s*/', $line, -1, PREG_SPLIT_NO_EMPTY);
    $author = $contents[0];
    $name = $contents[1];
    $genre = $contents[2];
    $price = $contents[3];
    $publish_date = $contents[4];
    $info = $contents[5];

    $data = [
        "author" => $author,
        "name" => $name,
        "genre" => $genre,
        "price" => $price,
        "publish date" => $publish_date,
        "info" => $info
    ];

    if($price >= $min_price &&
        $price <= $max_price) {
        $books[] = $data;
    }
}

if($criteria == 'genre') {
    usort($books, function($a, $b) use ($order, $books) {
        if($a['genre'] == $b['genre']) {
            return strtotime($a['publish date']) - strtotime($b['publish date']);
        } else {
            if($order == 'ascending') {
                return strcmp($a['genre'], $b['genre']) > 0;
            } else {
                return strcmp($a['genre'], $b['genre']) < 0;
            }
        }
    });
} else if ($criteria == 'author') {
    usort($books, function($a, $b) use ($order, $books) {
        if($a['author'] == $b['author']) {
            return strtotime($a['publish date']) - strtotime($b['publish date']);
        } else {
            if($order == 'ascending') {
                return strcmp($a['author'], $b['author']) > 0;
            } else {
                return strcmp($a['author'], $b['author']) < 0;
            }
        }
    });
} else {
    usort($books, function($a, $b) use ($order, $books) {
        if($order == 'ascending') {
            return strtotime($a['publish date']) - strtotime($b['publish date']);
        } else {
            return strtotime($b['publish date']) - strtotime($a['publish date']);
        }
    });
}

$output = "";

foreach ($books as $book) {
    $output_name = htmlspecialchars($book['name']);
    $output_author = htmlspecialchars($book['author']);
    $output_price = htmlspecialchars(($book['price']));
    $output_date = htmlspecialchars($book['publish date']);
    $output_genre = htmlspecialchars($book['genre']);
    $output_info = htmlspecialchars($book['info']);

    $output .= "<div>";
    $output .= "<p>$output_name</p>";
    $output .= "<ul>";
    $output .= "<li>$output_author</li>";
    $output .= "<li>$output_genre</li>";
    $output .= "<li>$output_price</li>";
    $output .= "<li>$output_date</li>";
    $output .= "<li>$output_info</li>";
    $output .= "</ul>";
    $output .= "</div>";
}

echo $output;

?>
