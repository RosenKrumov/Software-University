<?php
require_once 'index.php';

if(!$app->isLogged()) {
    header("Location: login.php");
    $_SESSION['VerificationToken'] = uniqid();
}

$buildings = $app->createBuildings();

if(isset($_GET['id']) && $_GET['verificationToken'] == $_SESSION['VerificationToken']){
    $buildings->evolve($_GET['id']);
    header("Location: buildings.php");
    $_SESSION['VerificationToken'] = uniqid();
    exit;
}

loadTemplate('buildings', $buildings);