<?php

namespace Core;


class Statement
{
    private $stmt;

    public function __construct($stmt){
        $this->stmt = $stmt;
    }

    public function fetch($fetchStyle = \PDO::FETCH_ASSOC){
        return $this->stmt->fetch($fetchStyle);
    }

    public function fetchAll($fetchStyle = \PDO::FETCH_ASSOC){
        return $this->stmt->fetchAll($fetchStyle);
    }

    public function bindParam($parameter, $variable, $dataType = \PDO::PARAM_STR, $length = null, $driver_options = null){
        return $this->stmt->bindParam($parameter, $variable, $dataType, $length, $driver_options);
    }

    public function execute(array $parameters = []){
        return $this->stmt->execute($parameters);
    }

    public function rowCount(){
        return $this->stmt->rowCount();
    }

    public function error() {
        return $this->stmt->errorInfo();
    }
}