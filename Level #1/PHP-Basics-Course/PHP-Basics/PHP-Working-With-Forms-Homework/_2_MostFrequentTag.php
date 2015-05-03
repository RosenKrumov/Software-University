<html>
    <head>
        <title>Print Tags</title>
    </head>
    <body>
        <form action="" method="post">
            <p>Enter Tags:</p>
            <input type="text" name="tags"/>
            <input type="submit"/>
        </form>
    </body>
</html>

<?php
if(isset($_POST['tags'])) {
    $tags = $_POST['tags'];
    $tagsArr = explode(", ", $tags);
    $output = array_count_values($tagsArr);
    arsort($output);
    foreach ($output as $key => $value) {
        echo "$key: $value times <br>";
    }
    echo "<br>";
    $mostFrequentWord = array_search(max($output), $output);
    echo "Most Frequent Tag is: $mostFrequentWord";


}
?>
 