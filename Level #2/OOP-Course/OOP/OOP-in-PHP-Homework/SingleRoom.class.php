<?php

class SingleRoom extends Room {

    function __construct($roomNumber, $price) {
        parent::__construct($roomNumber, $price, $roomInformation = "1 bed, Standard room, with restroom, no balcony", 
                $reservations = [], $roomType = "Standart", $hasRestroom = 1, $balcony = 0, RoomType::Standart,
                $extras = "TV, air-conditioner");
    }

    public function __toString() {
        return "Single room: {$this->getRoomNumber()} with price: {$this->getPrice()}, room information: {$this->getRoomInformation()}, "
        . " room type: {$this->getRoomType()}, extras: {$this->getExtras()})";
    }
}
