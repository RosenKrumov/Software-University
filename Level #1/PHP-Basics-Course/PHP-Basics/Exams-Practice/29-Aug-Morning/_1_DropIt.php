<?php
        $text = $_GET['text'];
        $minFontSize = $_GET['minFontSize'];
        $maxFontSize = $_GET['maxFontSize'];
        $step = $_GET['step'];
        $prevStep = 0;
        $index = $minFontSize;
        $output = '';
        for ($i = 0; $i < strlen($text); $i++) {
            if (ord($text[$i]) % 2 == 0) {
                $output .= "<span style='font-size:$index;text-decoration:line-through;'>".htmlspecialchars($text[$i])."</span>";
            } else {
                $output .= "<span style='font-size:$index;'>".htmlspecialchars($text[$i])."</span>";
            }

            if(ctype_alpha($text[$i])) {
                if($i == 0) {
                    $prevStep = $index;
                    $index += $step;
                } else {
                    if($index > $prevStep && $index < $maxFontSize ) {
                        $prevStep = $index;
                        $index += $step;
                    } elseif($index > $prevStep && $index >= $maxFontSize) {
                        $prevStep = $index;
                        $index -= $step;
                    } elseif($index < $prevStep && $index > $minFontSize) {
                        $prevStep = $index;
                        $index -= $step;
                    } elseif($index < $prevStep && $index <= $minFontSize) {
                        $prevStep = $index;
                        $index += $step;
                    }
                }
            }
        }
        echo $output;
?>
