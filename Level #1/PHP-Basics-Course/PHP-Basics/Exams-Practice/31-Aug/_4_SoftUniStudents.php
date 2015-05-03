<?php
$text = $_GET['students'];
$sorting_type = $_GET['column'];
$order = $_GET['order'];

$lines = preg_split('/[\r\n]+/', $text, -1, PREG_SPLIT_NO_EMPTY);

$students = [];
$id = 1;

foreach ($lines as $line) {
    $line_data = explode(',', $line);
    $user_name = trim($line_data[0]);
    $email = trim($line_data[1]);
    $type = trim($line_data[2]);
    $result = trim($line_data[3]);

    $data = [
        "id" => $id,
        "username" => $user_name,
        "email" => $email,
        "type" => $type,
        "result" => $result
    ];

    $students[] = $data;
    $id++;
}

if($sorting_type == 'id') {
    usort($students, function($a, $b) use ($order) {
        if($order == 'ascending'){
            return $a['id'] - $b['id'];
        } else {
            return $b['id'] - $a['id'];
        }
    });
} elseif($sorting_type == 'username') {
    usort($students, function($a, $b) use ($order) {
        if($a['username'] == $b['username']) {
            if($order == 'ascending') {
                return $a['id'] - $b['id'];
            } else {
                return $b['id'] - $a['id'];
            }
        } else {
            if($order == 'ascending') {
                return strcmp($a['username'], $b['username']) > 0;
            } else {
                return strcmp($a['username'], $b['username']) < 0;
            }
        }
    });
} else {
    usort($students, function($a, $b) use ($order) {
        if($a['result'] == $b['result']) {
            if($order == 'ascending') {
                return $a['id'] - $b['id'];
            } else {
                return $b['id'] - $a['id'];
            }
        }
        if($order == 'ascending'){
            return $a['result'] > $b['result'] ? 1 : -1;
        } else {
            return $a['result'] < $b['result'] ? 1 : -1;
        }
    });
}

$output = '<table><thead>';
$output .= '<tr><th>Id</th>';
$output .= '<th>Username</th>';
$output .= '<th>Email</th>';
$output .= '<th>Type</th>';
$output .= '<th>Result</th>';
$output .= '</tr></thead>';

foreach($students as $student) {
    $student_id = htmlspecialchars($student['id']);
    $student_username = htmlspecialchars($student['username']);
    $student_email = htmlspecialchars($student['email']);
    $student_type = htmlspecialchars($student['type']);
    $student_result = htmlspecialchars($student['result']);

    $output .= "<tr><td>$student_id</td>";
    $output .= "<td>$student_username</td>";
    $output .= "<td>$student_email</td>";
    $output .= "<td>$student_type</td>";
    $output .= "<td>$student_result</td></tr>";
}

$output .= "</table>";

echo $output;

?>
