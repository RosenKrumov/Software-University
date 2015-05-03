<?php

class BookingManager {

    static function bookRoom(Room $room, Reservation $reservation) {

        try {
            $result = $room->addReservation($reservation);
//            echo $result;
            if ($result > 0) {
                echo "Room <strong>{$room->getRoomNumber()}</strong> "
                . "successfully booked for <strong>{$reservation->getGuest()->getFirstName()} {$reservation->getGuest()->getLastName()}</strong>"
                . " from <time>{$reservation->getStartDate()}</time> to <time>{$reservation->getEndDate()}</time>!";
            } else {
                throw new EReservationException();
            }
        } catch (EReservationException $ex) {
            echo $ex->getMessage() . "<br />";
        }
    }

}
