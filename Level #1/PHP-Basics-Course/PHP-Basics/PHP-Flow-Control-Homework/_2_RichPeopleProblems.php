<html>
    <head>
        <title>Car Randomizer</title>
    </head>
    <body>
        <form action="" method="post">
            <label for="cars">Enter cars</label>
            <input type="text" name="cars" id="cars"/>
            <input type="submit" value="Show result"/>
        </form>
    </body>
</html>

<?php
    if(isset($_POST['cars'])) :
        $input = htmlentities($_POST['cars']);
        $cars = explode(", ", $input);
        $colors = ['red', 'green', 'blue', 'yellow', 'white'];
        $quantities = [1, 2, 3, 4, 5];
?>

<table border="1">
    <tr>
        <th>Car</th><th>Color</th><th>Count</th>
    </tr>
    <?php
    foreach($cars as $car):
    ?>
        <tr>
            <td><?=$car?></td>
            <td><?=$colors[array_rand($colors)]?></td>
            <td><?=$quantities[array_rand($quantities)]?></td>
        </tr>
    <?php endforeach; ?>
</table>

<?php  endif; ?>
 