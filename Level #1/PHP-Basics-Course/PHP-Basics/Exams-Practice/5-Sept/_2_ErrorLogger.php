<?php

$error_log = $_GET['errorLog'];

$pattern = '/Exception in thread \"\w+\" java.*\.(\w+): .*\s+at \w+\.(\w+)\((\w+\.\w+):(\d+)\)/';
preg_match_all($pattern, $error_log, $matches, PREG_SET_ORDER);

$result = '<ul>';

foreach ($matches as $match) {
    $exception = htmlspecialchars($match[1]);
    $method = htmlspecialchars($match[2]);
    $file_name = htmlspecialchars($match[3]);
    $line = htmlspecialchars($match[4]);
    $result .= '<li>line ';
    $result .= "<strong>$line</strong> - <strong>$exception</strong> in <em>$file_name:$method</em>";
    $result .= '</li>';
}

$result .= '</ul>';

echo $result;

?>
