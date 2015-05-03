<?php

date_default_timezone_set('Europe/Sofia');

$text = $_GET['text'];

$articles = preg_split('/[\n\r]+/', $text, -1, PREG_SPLIT_NO_EMPTY);

$pattern = '/\s*([A-Za-z -]+)\s*%\s*([A-Za-z\. -]+)\s*;\s*(\d{2}-\d{2}-\d{4})\s*-\s*(.+)\s*/';
$outputArr = [];

foreach ($articles as $article) {
    preg_match($pattern, $article, $parts);

    if(count($parts) != 5) {
        continue;
    }

    $article_name = trim($parts[1]);
    $article_name = htmlspecialchars($article_name);

    $article_author = trim($parts[2]);
    $article_author = htmlspecialchars($article_author);

    $parts[3] = trim($parts[3]);
    $article_date = date_create_from_format("d-m-Y", $parts[3], timezone_open('Europe/Sofia'));
    if(!$article_date || !isset($article_date)) {
        continue;
    }
    $month = date_format($article_date, "F");

    $article_body = substr(trim($parts[4]), 0, 100) . "...";

    $output = "<div>\n";
    $output .= "<b>Topic:</b> <span>$article_name</span>\n";
    $output .= "<b>Author:</b> <span>$article_author</span>\n";

    $output .= "<b>When:</b> <span>$month</span>\n";

    $article_body = htmlspecialchars($article_body);

    $output .= "<b>Summary:</b> <span>$article_body</span>\n";

    $output .= "</div>";

    $outputArr[] = $output;
}

    echo implode("\n", $outputArr);

?>
