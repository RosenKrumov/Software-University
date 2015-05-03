<?php

class Apartment extends Room{
    
    function __construct($roomNumber, $price) {
        parent::__construct($roomNumber, $price, $roomInformation = "4 beds, Diamond room, with restroom and balcony", 
                $reservations = [], $roomType = "Diamond", $hasRestroom = 1, $balcony = 1, RoomType::Diamond,
                $extras = "TV, air-conditioner, refrigerator, kitchen box, mini-bar, bathtub, free Wi-fi");
    }

    public function __toString() {
        return "Apartment: {$this->getRoomNumber()} with price: {$this->getPrice()}, room information: {$this->getRoomInformation()}, "
        . " room type: {$this->getRoomType()}, extras: {$this->getExtras()})";
    }
}
