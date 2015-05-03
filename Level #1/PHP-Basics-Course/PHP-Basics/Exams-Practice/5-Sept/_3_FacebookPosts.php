<?php

date_default_timezone_set('Europe/Sofia');
$text = $_GET['text'];

$posts = preg_split('/[\n\r]+/', $text, -1, PREG_SPLIT_NO_EMPTY);

$posts_by_date = [];

foreach ($posts as $post) {
    $parts = explode(';', $post);
    $name = htmlspecialchars(trim($parts[0]));
    $date = htmlspecialchars(trim($parts[1]));
    $body = htmlspecialchars(trim($parts[2]));
    $likes = htmlspecialchars(trim($parts[3]));
    $comments = htmlspecialchars(trim($parts[4]));
    $comments_arr = preg_split('/\s*\/\s*/', $comments, -1, PREG_SPLIT_NO_EMPTY);
    $date_int = strtotime($date);
    $date_output = date('j F Y', $date_int);
    $posts_by_date[$date_int] = render($name, $date_output, $body, $likes, $comments_arr);

}

krsort($posts_by_date);
foreach ($posts_by_date as $k => $v) {
    echo $v;
}


function render($name, $date_output, $body, $likes, $comments_arr) {
    $html = '<article>';
    $html .= "<header><span>$name</span><time>$date_output</time></header>";
    $html .= "<main><p>$body</p></main>";
    $html .= "<footer><div class=".'"likes"'.">$likes people like this</div>";
    if(count($comments_arr) > 0) {
        $html .= "<div class=".'"comments"'.">";
        foreach ($comments_arr as $comment) {
            $html .= "<p>$comment</p>";
        }
        $html .= "</div>";
    }
    $html .= "</footer></article>";

    return $html;
}

?>
