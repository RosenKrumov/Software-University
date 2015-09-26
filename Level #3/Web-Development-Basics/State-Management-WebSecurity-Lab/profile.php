<?php
require_once 'index.php';

if(!$app->isLogged()) {
    header("Location: login.php");
    $_SESSION['VerificationToken'] = uniqid();
}

loadTemplate("profile", $app->getUser());

if(isset($_POST['edit'])){
    if($_POST['password'] != $_POST['confirm'] || empty($_POST['password']) || $_POST['verificationToken'] != $_SESSION['VerificationToken']) {
        header('Location: profile.php?error=1');
        $_SESSION['VerificationToken'] = uniqid();
    }

    $user = new \Core\User(
        ($_POST['username']),
        ($_POST['password']),
        $_SESSION['id']
    );

    if($app->editUser($user)){
        header("Location: profile.php?success=1");
        $_SESSION['VerificationToken'] = uniqid();
        exit;
    }

    header("Location: profile.php?error=1");
    $_SESSION['VerificationToken'] = uniqid();
    exit;
}