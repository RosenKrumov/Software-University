<html>
<head>
    <title>Word Mapper</title>
</head>
<body>
<form action="" method="post">
    <textarea name="text"></textarea> <br/>
    <input type="submit" value="Count words"/>
</form>
</body>
</html>

<?php
    if(isset($_POST['text'])) {
?>
    <table border="1">
        <?php
        $text = htmlentities($_POST['text']);
        $words = preg_split('/((^\p{P}+)|(\p{P}*\s+\p{P}*)|(\p{P}+$))/', $text, -1, PREG_SPLIT_NO_EMPTY);
        $words = array_map('strtolower', $words);
        $output = array_count_values($words);
        arsort($output);
        foreach ($output as $key => $value) {
            echo "<tr><td>$key</td><td>$value</td></tr>";
        }
        ?>
    </table>
<?php
    }
?>
 