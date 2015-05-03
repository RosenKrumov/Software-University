<html>
    <head>
        <title>Annual Expenses</title>
    </head>
    <body>
        <form action="" method="post">
            <label for="years">Enter number of years:</label>
            <input type="text" name="years" id="years"/>
            <input type="submit" value="Show costs"/>
        </form>
    </body>
</html>

<?php
    if(isset($_POST['years'])) :
        if(!is_numeric($_POST['years'])) {
            die('Please enter a valid year.');
        }
        function createExpenses()
        {
            $return = "";
            $return .= "<tr><th>Year</th>";

            for ($i = 1; $i <= 12; $i++){
                $monthNum  = $i;
                $dateObj   = DateTime::createFromFormat('!m', $monthNum);
                $monthName = $dateObj->format('F');
                $return .= "<th>$monthName</th>";
            }
            $return .= "<th>Total:</th></tr>";

            $currentYear = 2014;
            $years = $_POST['years'];
            $endYear = $currentYear - $years;

            for ($i = $currentYear; $i > $endYear; $i--){
                $sum = 0;
                $return .= "<tr><td>$i</td>";
                for ($j = 0; $j < 12; $j++){
                        $currentExpense = rand(0,999);
                        $sum += $currentExpense;
                        $return .= "<td>$currentExpense</td>";
                }
                $return .= "<td>$sum</td></tr>";
            }
            return $return;
        }
?>

<table border="1">
    <?php
    echo createExpenses();
    endif;
    ?>
</table>


 