<?php
require_once 'Localization.php';
require_once 'Db.php';

function filterPossibleLanguages($var) {
    return strpos($var['Field'], 'text_') === 0;
}

function replaceLanguageStrings($var) {
    return str_replace('text_', '', $var);
}

function __($tag) {
    $lang = isset($_COOKIE['lang'])
        ? $_COOKIE['lang']
        : Localization::LANG_DEFAULT;

    $query = Db::getInstance()->query("
        SELECT
            text_{$lang}
        FROM
            translations
        WHERE
            tag = '$tag';
    ");

    $row = $query->fetch(PDO::FETCH_NUM);

    return $row[0];
}

$db = Db::getInstance();
$res = $db->query("SHOW COLUMNS FROM translations");
$columns = $res->fetchAll(PDO::FETCH_ASSOC);
$filtered = array_filter($columns, "filterPossibleLanguages");
$possibleLanguages = [];

foreach ($filtered as $value) {
    $possibleLanguages[] = $value['Field'];
}

$possibleLanguages = array_map('replaceLanguageStrings', $possibleLanguages);

if (isset($_GET['lang'])) {
    $lang = $_GET['lang'];
    if (!in_array($lang, $possibleLanguages)) {
        throw new Exception("Wrong language");
    }

    setcookie('lang', $lang);
    $_COOKIE['lang'] = $lang;
}

Localization::$LANG_DEFAULT = $possibleLanguages[0];