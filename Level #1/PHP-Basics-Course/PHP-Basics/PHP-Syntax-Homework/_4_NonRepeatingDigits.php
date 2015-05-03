<?php
    $n = 1234;
    $output = [];

    if($n >= 100) {
        for ($i = 100; $i <= $n; $i++) {
            if ($i > 999) {
                break;
            }
            $leftDig = (int)($i / 100);
            $midDig = (int)(($i / 10) % 10);
            $rightDig = ($i % 100) % 10;
            if ($leftDig != $midDig) {
                if ($midDig != $rightDig) {
                    if ($leftDig != $rightDig) {
                        $output[] = $i;
                    }
                }
            }
        }
        echo implode($output, ', ');
    } else {
        echo 'no';
    }
?>
 