<table border="1">
    <tr><th>Number</th><th>Square</th></tr>
<?php
$sum = 0;
for ($i = 0; $i <= 100; $i++) :
    if($i % 2 == 0) : ?>
     <tr>
         <td><?= $i ?></td>
         <td>
             <?php
             echo (float)number_format(sqrt($i), 2);
             $sum += (float)number_format(sqrt($i), 2)
             ?>
         </td>
     </tr>
<?php    endif;
endfor;
?>
    <tr><td><b>Total:</b></td><td><?= $sum ?></td></tr>
</table>
 