<?php

require_once './iReservable.php';
require_once './EReservationException.php';

function __autoload($className) {
require_once ("./" . $className . ".class.php");
}

$singleRoom = new SingleRoom(1408, 99);
$guest = new Guest("Svetlin", "Nakov", 8003224277);
$startDate = strtotime("24.10.2014");
$endDate = strtotime("26.10.2014");
$reservation = new Reservation($startDate, $endDate, $guest);
//var_dump($room);
//var_dump($guest);
BookingManager::bookRoom($singleRoom, $reservation);
echo '<br />';
BookingManager::bookRoom($singleRoom, $reservation);
$startDate2 = strtotime("20.10.2014");
$endDate2 = strtotime("26.10.2014");
$newReservation = new Reservation($startDate2, $endDate2, $guest);
BookingManager::bookRoom($singleRoom, $newReservation);
$bedRoom1 = new Bedroom(15, 150);
$bedRoom2 = new Bedroom(16, 155);
$apartment1 = new Apartment(111, 200);
$apartment2 = new Apartment(112, 250);
$apartment3 = new Apartment(113, 260);
$roomsArray = [$singleRoom, $bedRoom1, $bedRoom2, $apartment1, $apartment2, $apartment3];

$expensiveBedroomsApartments = array_filter($roomsArray, function ($n){
    return ($n->getRoomType()=="Gold"||$n->getRoomType()=="Diamond")&&($n->getPrice()>=250);
});
echo '<pre>'. print_r($expensiveBedroomsApartments, true)."</pre>";
$balconyRooms = array_filter($roomsArray, function ($n){
    return $n->getHasBalcony()==1;
});
echo '<pre>'. print_r($balconyRooms, true)."</pre>";

$bathtubRooms = array_filter($roomsArray, function ($n){
    return strpos($n->getExtras(), "bathtub")!=FALSE;
});
echo '<pre>'. print_r($bathtubRooms, true)."</pre>";
