<?php

    $firstNum = 2;
    $secondNum = 5;
    $sum = $firstNum + $secondNum;

    $firstNum1 = 1.567808;
    $secondNum1 = 0.356;
    $sum1 = $firstNum1 + $secondNum1;

    $firstNum2 = 1234.5678;
    $secondNum2 = 333;
    $sum2 = $firstNum2 + $secondNum2;

    $sum = number_format(round($sum, 2), 2, '.', '');
    $sum1 = number_format(round($sum1, 2), 2, '.', '');
    $sum2 = number_format(round($sum2, 2), 2, '.', '');

    echo "$sum <br> $sum1 <br> $sum2";

?>
 