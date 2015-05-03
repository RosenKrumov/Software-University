<?php

class Reservation {

    private $startDate;
    private $endDate;
    private $guest;

    function __construct($startDate, $endDate, $guest) {
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
        $this->setGuest($guest);
    }

    public function getStartDate() {
        $startDate = date("d-m-Y", $this->startDate);
        return $startDate;
    }

    public function getEndDate() {
        $endDate = date("d-m-Y", $this->endDate);
        return $endDate;
    }

    public function getGuest() {
        return $this->guest;
    }

    public function setStartDate($startDate) {
        if ($startDate <= 0) {
            throw new InvalidArgumentException("date is invalid");
        }

        $this->startDate = $startDate;
    }

    public function setEndDate($endDate) {
        if ($endDate <= 0) {
            throw new InvalidArgumentException("date is invalid");
        }

        $this->endDate = $endDate;
    }

    public function setGuest(Guest $guest) {
        if ($guest == null) {
            throw new InvalidArgumentException("guest must be exists");
        }

        $this->guest = $guest;
    }

    public function __toString() {
        return "<br />Reservation for {$this->getGuest()}, from {$this->getStartDate()} to {$this->getEndDate()}";
    }

}
