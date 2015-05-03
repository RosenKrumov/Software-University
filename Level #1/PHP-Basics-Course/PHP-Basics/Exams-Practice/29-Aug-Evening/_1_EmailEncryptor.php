<?php
$recipient = $_GET['recipient'];
$subject = $_GET['subject'];
$body = $_GET['body'];
$key = $_GET['key'];
$escapedBody = htmlspecialchars($body);
$escapedRecipient = htmlspecialchars($recipient);
$escapedSubject = htmlspecialchars($subject);
$text = "<p class='recipient'>$escapedRecipient</p><p class='subject'>$escapedSubject</p><p class='message'>$escapedBody</p>";
$values = array();

for ($i = 0, $j = 0; $j < strlen($text); $i++, $j++) {
    $bodyChar = $text[$j];
    $keyChar = $key[$i];
    $bodyCharVal = ord($text[$j]);
    $keyCharVal = ord($key[$i]);
    $values[] = dechex($bodyCharVal*$keyCharVal);
    if($i == strlen($key) - 1) {
//        $bodyCharVal = ord($text[$j]);
//        $keyCharVal = ord($key[$i]);
//        $values[] = dechex($bodyCharVal*$keyCharVal);
        $i = -1;
    }
}

$output = '|';
$output .= implode('|', $values);
$output .= '|';

echo $output;

?>
