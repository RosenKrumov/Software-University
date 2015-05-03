<html>
    <head>
        <title>Modify String</title>
    </head>
    <body>
        <form action="" method="post">
            <input type="text" name="input"/>
            <input type="radio" name="operation" value="Check Palindrome"/> Check Palindrome
            <input type="radio" name="operation" value="Reverse String"/> Reverse String
            <input type="radio" name="operation" value="Split"/> Split
            <input type="radio" name="operation" value="Hash String"/> Hash String
            <input type="radio" name="operation" value="Shuffle String"/> Shuffle String
            <input type="submit" value="Submit"/>
        </form>
    </body>
</html>

<?php
$_POST['input'] = 'aslkdjlaksd';
$_POST['operation'] = 'Shuffle';
    if(isset($_POST['input'], $_POST['operation'])) {
        $input = htmlentities($_POST['input']);
        $operation = $_POST['operation'];
        if($operation == 'Check Palindrome') {
            $inputLow = strtolower($input);
            $inputLowArr = str_split($inputLow);
            $reversedInput = array_reverse($inputLowArr);
            $output = implode($reversedInput, '');
            if($input == $output){
                echo "$input is a palindrome!";
            } else {
                echo "$input is not a palindrome!";
            }
        } elseif($operation == 'Reverse String') {
            $inputArr = str_split($input);
            $output = array_reverse($inputArr);
            echo implode($output);
        } elseif($operation == 'Split') {
            $output = str_split(preg_replace("/[0-9,.!?]/", "", $input));
            echo implode(' ', $output);
        } elseif($operation == 'Hash String') {
            echo crypt($input);
        } else {
            $arr = str_split($input);
            shuffle($arr);
            $output = implode($arr);
            echo $output;
        }
    }
?>
 