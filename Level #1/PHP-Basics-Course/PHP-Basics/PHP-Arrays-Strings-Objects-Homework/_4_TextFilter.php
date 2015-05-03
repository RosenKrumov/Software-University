<html>
<head>
    <title>Text Filter</title>
</head>
<body>
<form action="" method="post">
    <textarea name="text"></textarea> <br/>
    Ban list: <input type="text" name="banned"/> <br/>
    <input type="submit"/>
</form>
</body>
</html>

<?php
    if(isset($_POST['text'], $_POST['banned'])) {
        $text = htmlentities($_POST['text']);
        $bannedWords = explode(', ', htmlentities($_POST['banned']));
        foreach ($bannedWords as $b) {
            $replacer = str_repeat('*', strlen($b));
            $text = str_replace($b, $replacer, $text);
        }
        echo $text;
    }
?>
 