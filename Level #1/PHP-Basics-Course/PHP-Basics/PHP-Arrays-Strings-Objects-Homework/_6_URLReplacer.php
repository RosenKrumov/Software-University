<html>
<head>
    <title>Tag Replacer</title>
</head>
<body>
<form action="" method="post">
    <textarea name="text"></textarea> <br/>
    <input type="submit"/>
</form>
</body>
</html>

<?php
    if(isset($_POST['text'])) {
        $text = $_POST['text'];
        $pattern = '/<a\shref([^>]+)>([^<]+)<\/a>/';
        $replaceStr = "[URL$1]$2[/URL]";
        preg_match_all($pattern, $text, $matches);
        $output = preg_replace($pattern, $replaceStr, $text);
        echo $output;
    }
?>
 