<form action="" method="get">
    <label for="number">Enter a number: </label>
    <input type="text" id="number" name="number">
    <input type="submit" value="Guess">
</form>

<?php
session_start();

if(isset($_GET['number']) && isset($_SESSION['randomNumber'])){
    if(empty(trim($_GET['number'])) || !is_numeric(trim($_GET['number']))){ ?>
        <h1>Invalid number</h1>
    <?php } else {
        if($_GET['number'] > $_SESSION['randomNumber']) { ?>
            <h1>Down</h1>
        <?php } else if($_GET['number'] < $_SESSION['randomNumber']){ ?>
            <h1>Up</h1>
        <?php } else { ?>
            <h1>Congratulations</h1>
            <?php session_destroy(); ?>
            <a href="index.php">Play again</a>
        <?php    }
    }
}