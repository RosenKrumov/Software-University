<html>
<head>
    <title>Primes in range</title>
    <style>
        div {
            width:50%;
        }
    </style>
</head>
<body>
<form action="" method="post">
    <label for="start">Starting Index:</label>
    <input type="text" name="start" id="start"/>
    <label for="end">End:</label>
    <input type="text" name="end" id="end"/>
    <input type="submit" value="Submit"/>
</form>
</body>
</html>

<div>
    <?php
        if(isset($_POST['start'], $_POST['end'])) {
            $start = htmlentities($_POST['start']);
            $end = htmlentities($_POST['end']);
            $isNum = is_numeric($start) && is_numeric($end);
            if(!$isNum) {
                die('Please enter valid nums!');
            }
            function isPrime($num) {
                $prime = true;
                if($num == 2 ||
                    $num == 3) {
                    return $prime;
                }
                for ($i = 2; $i <= sqrt($num); $i++) {
                    if($num % $i == 0) {
                        $prime = false;
                    }
                }
                return $prime;
            }
            for ($i = $start; $i <= $end; $i++) {
                if($i == $end) {
                    if(isPrime($i)) {
    ?>
                        <b><?=$i?></b>
              <?php } else { ?>
                        <?=$i?>
              <?php }
                } else {
                    if(isPrime($i)) {
                    ?>
                        <b><?=$i?></b>,
              <?php } else { ?>
                        <?=$i?>,
    <?php
                    }
                }
            }
        }

    ?>
</div>
