<?php
$now = new DateTime();
$start = new DateTime( $now->format('m/01/Y'));
$end = new DateTime( $now->format('m/t/Y'));
$interval = new DateInterval('P1D'); //1-day-interval
$period = new DatePeriod( $start, $interval, $end );
foreach( $period as $date ){
    if( $date->format('w') == 0 ){
        echo $date->format('jS F, Y');
        echo "<br>";
    }
}
 