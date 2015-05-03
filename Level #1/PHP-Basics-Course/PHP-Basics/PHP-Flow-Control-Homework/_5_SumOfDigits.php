<html>
    <head>
        <title>Sum of digits</title>
    </head>
    <body>
        <form action="" method="post">
            <label for="input">Input string:</label>
            <input type="text" name="input" id="input"/>
            <input type="submit" value="Submit"/>
        </form>
    </body>
</html>


<?php
  if(isset($_POST['input'])) :
?>
<table border="1">
    <?php
      $nums = explode(", ", $_POST['input']);
      foreach($nums as $n):
          if(!is_numeric($n)) :
    ?>
              <tr><td><?= $n ?></td><td>I cannot sum that</td></tr>
    <?php
          continue;
          endif;
          $sum = array_sum(str_split($n));
    ?>
          <tr><td><?= $n ?></td><td><?= $sum ?></td></tr>
      <?php endforeach; ?>
</table>
<?php
  endif;
?>
 