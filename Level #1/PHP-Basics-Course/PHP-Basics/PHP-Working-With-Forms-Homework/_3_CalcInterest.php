<html>
    <head>
        <title>Calculate Interest</title>
    </head>
    <body>
    <form action="" method="post">
        Enter Amount <input type="text" name="amount"/> <br/>
        <input type="radio" value="USD" name="currency"/> USD
        <input type="radio" value="EUR" name="currency"/> EUR
        <input type="radio" value="BGN" name="currency"/> BGN <br/>
        Compound Interest Amount <input type="text" name="compoundInt"/> <br/>
        <select name="period">
            <option value="6">6 Months</option>
            <option value="12">1 Year</option>
            <option value="24">2 Years</option>
            <option value="60">5 Years</option>
        </select>
        <input type="submit" value="Calculate"/>
    </form>
    </body>
</html>

<?php
    if(isset($_POST['amount']) &&
        isset($_POST['currency']) &&
        isset($_POST['compoundInt']) &&
        isset($_POST['period'])) {

        $amount = $_POST['amount'];
        $currency = $_POST['currency'];
        $interest = $_POST['compoundInt'];
        $monthInterest = 100 + $interest/12;
        $period = $_POST['period'];
        $sum = $amount;

        for ($i = 0; $i < $period; $i++) {
            $sum *= $monthInterest/100;
        }

        $sum = number_format($sum, 2, '.', '');
        if($currency == 'USD') {
            echo "$ $sum";
        } elseif($currency == 'EUR') {
            echo "EUR $sum";
        } else {
            echo "BGN $sum";
        }
    }
?>
 