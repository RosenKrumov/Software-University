<?php

class EReservationException extends Exception {

    function __construct() {
        parent::__construct("Reservation already exists", 102, null);
    }    
}
