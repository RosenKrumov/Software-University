<?php
require_once 'index.php';

if(isset($_POST['username'], $_POST['password'])){
    try {
        $user = ($_POST['username']);
        $pass = ($_POST['password']);
        $app->login($user, $pass);
        header('Location: profile.php');
        $_SESSION['VerificationToken'] = uniqid();
    } catch (Exception $e) {
        echo $e->getMessage();
    }
}

loadTemplate("login");