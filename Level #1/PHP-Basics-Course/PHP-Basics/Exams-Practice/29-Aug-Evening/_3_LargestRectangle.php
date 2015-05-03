<?php

$json = $_GET['jsonTable'];
$data = json_decode($json);
$maxSize = 0;
$maxStartRow = 0;
$maxStartCol = 0;
$maxEndRow = 0;
$maxEndCol = 0;

$biggestRectangle = array(
    'startRow' => 0,
    'startColumn'=> 0,
    'width' => 1,
    'height' => 1,
    'area' => 1
) ;

for ($i=0; $i < count($data) ; $i++) {
    for ($j=0; $j < count($data[0]); $j++) {
        //we take all starting positions with the first two loops
        for ($k=$i; $k < count($data); $k++) {
            for ($l=$j; $l < count($data[0]) ; $l++) {
                //we take all possible squares from the current starting position with these two loops
                $isRectangle = isRectangle($i, $j, $k, $l, $data);
                if($isRectangle){
                    rectangleUpdate($i, $j, $k, $l, $biggestRectangle);
                }
            }
        }
    }

}

$table = "<table border='1' cellpadding='5'>";
for ($i=0; $i < count($data); $i++) {
    $table .= "<tr>";
    for ($j=0; $j < count($data[0]); $j++) {
        if(isOnBorder($i, $j, $biggestRectangle)){
            $table .= "<td style='background:#CCC'>".($data[$i][$j])."</td>";
        }
        else{
            $table .= "<td>".($data[$i][$j])."</td>";
        }

    }
    $table .= "</tr>";
}
$table .= "</table>";

echo $table;

function isRectangle($startRow, $startColumn, $endRow, $endColumn, $matrix){

    $symbol = $matrix[$startRow][$startColumn];
    for ($i=$startRow; $i <= $endRow; $i++) {
        if(($matrix[$i][$startColumn]!=$symbol)||($matrix[$i][$endColumn]!=$symbol)){
            return FALSE;
        }
    }
    for ($i=$startColumn; $i <= $endColumn; $i++) {
        if(($matrix[$startRow][$i]!=$symbol)||($matrix[$endRow][$i]!=$symbol)){
            return FALSE;
        }
    }
    return TRUE;
}

function rectangleUpdate($startRow, $startColumn, $endRow, $endColumn, &$biggestRectangle){
    $height = $endRow - $startRow + 1;
    $width = $endColumn - $startColumn + 1;
    $area = $width*$height;
    if($area>$biggestRectangle['area']){
        $biggestRectangle['startRow'] = $startRow;
        $biggestRectangle['startColumn'] = $startColumn;
        $biggestRectangle['width'] = $width;
        $biggestRectangle['height'] = $height;
        $biggestRectangle['area'] = $area;
    }

}

function isOnBorder($row, $column, $biggestRectangle){
    $startRow = $biggestRectangle['startRow'];
    $endRow = $biggestRectangle['startRow'] + $biggestRectangle['height'] - 1;
    $startColumn = $biggestRectangle['startColumn'];
    $endColumn = $biggestRectangle['startColumn'] + $biggestRectangle['width'] - 1;
    if(((($row==$startRow)||($row==$endRow))&&($column>=$startColumn)&&($column<=$endColumn))||((($column==$startColumn)||($column==$endColumn))&&($row>=$startRow)&&($row<=$endRow))){
        return TRUE;
    }
    else{
        return FALSE;
    }
}

?>