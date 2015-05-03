<?php

class Room implements iReservable {

    private $roomInformation;
    private $reservations;
    private $roomType;
    private $hasRestroom;
    private $hasBalcony;
    private $bedCount;
    private $roomNumber;
    private $extras;
    private $price;

    function __construct($roomNumber, $price, $roomInformation, $reservations, $roomType, $hasRestroom, $hasBalcony
    , $bedCount, $extras) {
        $this->setRoomInformation($roomInformation);
        $this->setReservations($reservations);
        $this->setRoomType($roomType);
        $this->setHasRestroom($hasRestroom);
        $this->setHasBalcony($hasBalcony);
        $this->setBedCount($bedCount);
        $this->setRoomNumber($roomNumber);
        $this->setExtras($extras);
        $this->setPrice($price);
    }

    public function getRoomType() {
        return $this->roomType;
    }

    public function getHasRestroom() {
        return $this->hasRestroom;
    }

    public function getHasBalcony() {
        return $this->hasBalcony;
    }

    public function getBedCount() {
        return $this->bedCount;
    }

    public function getRoomNumber() {
        return $this->roomNumber;
    }

    public function getExtras() {
        return $this->extras;
    }

    public function getPrice() {
        return $this->price;
    }

    public function getRoomInformation() {
        return $this->roomInformation;
    }

    public function getReservations() {
        $result = "";
        echo '<br />';
        foreach ($this->reservations as $reservation) {
            $result.="Guest: {$reservation->getGuest()->getFirstName()}, from: {$reservation->getStartDate()}, "
                    . "to: {$reservation->getEndDate()}<br />";
        }

        return $result;
    }

    public function setRoomType($roomType) {
        $this->roomType = $roomType;
    }

    public function setHasRestroom($hasRestroom) {
        $this->hasRestroom = $hasRestroom;
    }

    public function setHasBalcony($hasBalcony) {
        $this->hasBalcony = $hasBalcony;
    }

    public function setBedCount($bedCount) {
        $this->bedCount = $bedCount;
    }

    public function setRoomNumber($roomNumber) {
        if ($roomNumber <= 0) {
            throw new InvalidArgumentException("Room number must be positive!");
        }

        $this->roomNumber = $roomNumber;
    }

    public function setExtras($extras) {
        if ($extras == null || $extras == "") {
            throw new InvalidArgumentException("details can't be empty!");
        }

        $this->extras = $extras;
    }

    public function setPrice($price) {
        if ($price <= 0) {
            throw new InvalidArgumentException("price must be positive number!");
        }

        $this->price = $price;
    }

    public function setRoomInformation($roomInformation) {
        if ($roomInformation == null || empty($roomInformation)) {
            throw new InvalidArgumentException("room details is mandatory!");
        }

        $this->roomInformation = $roomInformation;
    }

    public function setReservations(array $reservations) {
        $this->reservations = $reservations;
    }

    public function addReservation(Reservation $reservation) {
        $unsuccessfulBooking = 'invalid data of your reservation';
        if (gettype($reservation) != "object") {
            return $unsuccessfulBooking;
        } else {
            if (empty($this->reservations)) {
                $success = array_push($this->reservations, $reservation);
                return $success;
            }
            foreach ($this->reservations as $bookedReservation) {
                $startDateNewReservation = strtotime($reservation->getStartDate());
                $endDateNewReservation = strtotime($reservation->getEndDate());
                $startDateBooked = strtotime($bookedReservation->getStartDate());
                $endDateBooked = strtotime($bookedReservation->getEndDate());
                $startInPeriod = $startDateNewReservation >= $startDateBooked && $startDateNewReservation <= $endDateBooked;
                $endInPeriod = $endDateNewReservation >= $startDateBooked && $endDateNewReservation <= $endDateBooked;

                if ($startInPeriod == true || $endInPeriod == true 
                        || ($startDateNewReservation <= $startDateBooked && $endDateNewReservation >= $endDateBooked)) {
                    return "Already have a booking for that period!";
                } else {
                    $success = array_push($this->reservations, $reservation);
                    return $success;
                }
            }
        }
    }

    public function removeReservation(Reservation $reservation) {
        $key = array_search($reservation, $this->reservations);
        array_splice($this->reservations, $key, 1);
    }

}
