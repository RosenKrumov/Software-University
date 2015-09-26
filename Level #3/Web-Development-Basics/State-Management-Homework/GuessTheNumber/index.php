<?php
session_start();
?>

<form action="" method="post">
    <label for="username">Enter your username:</label>
    <input type="text" id="username" name="username">
    <input type="submit" value="Play!">
</form>

<?php
if(isset($_POST['username'])) :
    if (!empty(trim($_POST['username'])) && !is_numeric(trim($_POST['username']))) {
        $_SESSION['username'] = trim($_POST['username']);
        $randomNumber = rand(1, 100);
        $_SESSION['randomNumber'] = $randomNumber;
        header('Location: play.php');
    } else { ?>
        <h1>Invalid username</h1>
    <?php }
endif;

