<html>
    <head>
        <title>Sidebar Builder</title>
    </head>
    <body>
        <form action="" method="post">
            <label for="cat">Categories: </label>
            <input type="text" name="categories" id="cat"/><br/>
            <label for="tag">Tags: </label>
            <input type="text" name="tags" id="tag"/><br/>
            <label for="months">Months: </label>
            <input type="text" name="months" id="months"/><br/>
            <input type="submit" value="Generate"/>
        </form>
    </body>
</html>

<?php
    if(isset($_POST['categories'], $_POST['tags'], $_POST['months'])) {
        $categories = explode(', ', $_POST['categories']);
        $tags = explode(', ', $_POST['tags']);
        $months = explode(', ', $_POST['months']);
?>

<div>
    Categories <br/>
    <ul type="disk">
        <?php
        foreach($categories as $c) {
            echo "<li>$c</li>";
        }
        ?>
    </ul>
</div> <br/>

<div>
    Tags <br/>
    <ul type="disk">
        <?php
        foreach($tags as $t) {
            echo "<li>$t</li>";
        }
        ?>
    </ul>
</div> <br/>

<div>
    Months <br/>
    <ul type="disk">
        <?php
        foreach($months as $m) {
            echo "<li>$m</li>";
        }
        ?>
    </ul>
</div>

<?php
    }
?>
 