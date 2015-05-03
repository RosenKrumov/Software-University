<?php
    date_default_timezone_set('Europe/Sofia');
    $currentTime = trim($_GET['currentDate']);
    $input = trim($_GET['messages']);
    $messages = preg_split('/\r?\n/', $input);
    $obj = array();
    foreach ($messages as $k => $v) {
        $splitted = preg_split('/ \/ /', $v);
        $obj[trim($splitted[0])] = trim($splitted[1]);
    }

    function compare_func($a, $b)
    {
        $t1 = strtotime($a);
        $t2 = strtotime($b);

        return ($t1 - $t2);
    }

    uasort($obj, "compare_func");

    foreach ($obj as $k => $v) {
        echo "<div>".htmlspecialchars($k)."</div>\n";
    }

    $currDate = DateTime::createFromFormat('d-m-Y H:i:s',$currentTime);
    $lastTime = end($obj);
    $lastDate = DateTime::createFromFormat('d-m-Y H:i:s',$lastTime);
    $interval = $lastDate -> diff($currDate);

    $years =  $interval -> format('%y');
    $months = $interval -> format('%m');
    $days = $interval -> format('%d');
    $hours = $interval -> format('%h');
    $minutes = $interval -> format('%i');
    $seconds = $interval -> format('%s');

    if($years == 0 &&
        $months == 0 &&
        $currDate->format('d') - $lastDate->format('d') == 0 &&
        $hours == 0 &&
        $minutes == 0) {
        echo "<p>Last active: <time>a few moments ago</time></p>";
    } elseif ($years == 0 &&
        $months == 0 &&
        $days == 0 &&
        $hours == 0 &&
        $minutes != 0) {
        echo "<p>Last active: <time>$minutes minute(s) ago</time></p>";
    } elseif($years == 0 &&
        $months == 0 &&
        $currDate->format('d') - $lastDate->format('d') == 0 &&
        $hours != 0) {
        echo "<p>Last active: <time>$hours hour(s) ago</time></p>";
    } elseif($years == 0 &&
        $months == 0 &&
        $currDate->format('d') - $lastDate->format('d') == 1) {
        echo "<p>Last active: <time>yesterday</time></p>";
    } else {
        echo "<p>Last active: <time>".$lastDate->format('d-m-Y')."</time></p>";
    }
?>