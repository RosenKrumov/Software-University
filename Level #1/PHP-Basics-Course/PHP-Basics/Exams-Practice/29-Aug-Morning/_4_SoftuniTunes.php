<?php
$text = $_GET['text'];
$artist = $_GET['artist'];
$sorting = $_GET['property'];
$order = $_GET['order'];

$song_lines = preg_split('/[\r\n]+/', $text, -1, PREG_SPLIT_NO_EMPTY);

$songs = [];

foreach ($song_lines as $song_line) {
    $song_data = preg_split('/\s*\|\s*/', $song_line, -1, PREG_SPLIT_NO_EMPTY);
    $name = $song_data[0];
    $genre = $song_data[1];
    $artists = $song_data[2];
    $downloads = $song_data[3];
    $rating = floatval($song_data[4]);

    $data = [
        "name" => $name,
        "genre" => $genre,
        "artists" => $artists,
        "downloads" => $downloads,
        "rating" => $rating
    ];

    if(strpos($artists, $artist) !== false) {
        $songs[] = $data;
    }
}

if($sorting == 'downloads') {
    usort($songs, function($a, $b) use ($order, $songs) {
        if($a['downloads'] == $b['downloads']) {
            return strcmp($a['name'], $b['name']) > 0;
        } else {
            if ($order == 'ascending') {
                return $a['downloads'] - $b['downloads'];
            } else {
                return $b['downloads'] - $a['downloads'];
            }
        }
    });
} elseif($sorting == 'rating') {
    usort($songs, function($a, $b) use ($order, $songs) {
       if($a['rating'] == $b['rating']) {
            return strcmp($a['name'], $b['name']) > 0;
       } else {
           if($order == 'ascending'){
               return $a['rating'] > $b['rating'] ? 1 : -1;
           } else {
               return $a['rating'] < $b['rating'] ? 1 : -1;
           }
       }
    });
} elseif($sorting == 'genre') {
    usort($songs, function($a, $b) use ($order, $songs) {
       if($a['genre'] == $b['genre']) {
           return strcmp($a['name'], $b['name']) > 0;
       } else {
           if($order == 'ascending') {
               return strcmp($a['genre'], $b['genre']) > 0;
           } else {
               return strcmp($a['genre'], $b['genre']) < 0;
           }
       }
    });
} else {
    usort($songs, function($a, $b) use ($order) {
        if($order == 'ascending') {
            return strcmp($a['name'], $b['name']) > 0;
        } else {
            return strcmp($a['name'], $b['name']) < 0;
        }
    });
}

foreach ($songs as $song) {
    $artistsArr = explode(', ', $song['artists']);
    sort($artistsArr);
    $str = implode(', ', $artistsArr);
}

$output = "<table>\n";
$output .= "<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>\n";

foreach ($songs as $song) {
    $output .= '<tr>';
    $index = 0;
    foreach ($song as $k => $v) {
        if($index == 2) {
            $artistsArr = explode(', ', $v);
            sort($artistsArr);
            $str = implode(', ', $artistsArr);
            $str = htmlspecialchars($str);
            $output .= "<td>$str</td>";
            $index++;
            continue;
        }
        $v = htmlspecialchars($v);
        $output .= "<td>$v</td>";
        $index++;
    }
    $output .= "</tr>\n";
}

$output .= "</table>\n";

echo $output;
?>
