<?php

class Guest {

    private $firstName;
    private $lastName;
    private $id;

    function __construct($firstName, $lastName, $id) {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
        $this->setId($id);
    }

    public function getFirstName() {
        return $this->firstName;
    }

    public function getLastName() {
        return $this->lastName;
    }

    public function getId() {
        return $this->id;
    }

    public function setFirstName($firstName) {
        if ($firstName == "" || $firstName == NULL) {
            throw new InvalidArgumentException("first name can't be empty");
        }

        $this->firstName = $firstName;
    }

    public function setLastName($lastName) {
        if ($lastName == "" || $lastName == NULL) {
            throw new InvalidArgumentException("last name can't be empty");
        }

        $this->lastName = $lastName;
    }

    public function setId($id) {
        if ($id <= 0) {
            throw new InvalidArgumentException("id must be positive number");
        }

        $this->id = $id;
    }

    public function __toString() {
        return $this->getFirstName() . " " . $this->getLastName() . ", ID= " . $this->getId();
    }

}
