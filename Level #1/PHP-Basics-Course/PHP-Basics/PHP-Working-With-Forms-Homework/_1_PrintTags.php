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
    for ($i = 0; $i < count($tagsArr); $i++) {
        echo "$i:$tagsArr[$i]<br>";
    }
}
?>
 