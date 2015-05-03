<?php

class Bedroom extends Room {

    function __construct($roomNumber, $price) {
        parent::__construct($roomNumber, $price, $roomInformation = "2 beds, Gold room, with restroom and balcony",
                $reservations = [], $roomType = "Gold", $hasRestroom = 1, $balcony = 1, RoomType::Gold, $extras = "TV, air-conditioner, refrigerator, mini-bar, bathtub");
    }

    public function __toString() {
        return "Bedroom: {$this->getRoomNumber()} with price: {$this->getPrice()}, room information: {$this->getRoomInformation()}, "
                . " room type: {$this->getRoomType()}, extras: {$this->getExtras()})";
    }

}
