<?php

class Db
{
    private static $db;

    public static function getInstance() {
        if (static::$db === null) {
            static::$db = new PDO("mysql:host=localhost;dbname=localization;charset=UTF8", "root", "");
        }

        return static::$db;
    }
}