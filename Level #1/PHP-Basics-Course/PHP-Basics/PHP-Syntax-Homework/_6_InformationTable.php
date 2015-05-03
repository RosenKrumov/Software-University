<?php
    $name = 'Gosho';
    $number = '0882-321-423';
    $age = 24;
    $address = 'Hadji Dimitar';
?>

<html>
<head>
    <title>Info Table</title>
</head>
<body>
<table border="1" cellpadding="0" cellspacing="0">
    <tbody>
        <tr>
            <td>Name</td>
            <td>
                <?php echo $name; ?>
            </td>
        </tr>
        <tr>
            <td>Phone number</td>
            <td>
                <?= $number; ?>
            </td>
        </tr>
        <tr>
            <td>Age</td>
            <td>
                <?= $age; ?>
            </td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <?= $address; ?>
            </td>
        </tr>
    </tbody>
</table>
</body>
</html>
 