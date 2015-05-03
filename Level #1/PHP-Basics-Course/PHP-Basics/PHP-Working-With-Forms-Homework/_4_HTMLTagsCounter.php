<html>
    <head>
        <title>Tags Counter</title>
    </head>
    <body>
        <form action="" method="post">
            <label for="tag">Enter HTML tags:</label><br/>
            <input type="text" name="tag" id="tag"/>
            <input type="submit" value="Submit"/>
        </form>
    </body>
</html>

<?php
    $allTags = ['html', 'head', 'body', 'div', 'span', 'title',
    'link', 'meta', 'style', 'p', 'h1', 'h2', 'h3', 'h4', 'h5',
    'h6', 'strong', 'em', 'abbr', 'acronym', 'address', 'bdo',
    'blockquote', 'cite', 'q', 'code', 'ins', 'del', 'pre', 'i',
    'samp', 'br', 'a', 'img', 'area', 'ul', 'ol', 'li', 'dl',
    'dt', 'dd', 'table', 'tr', 'td', 'th', 'tbody', 'thead',
    'tfoot', 'caption', 'form', 'input', 'textarea', 'select',
    'option', 'button', 'label', 'legend', 'script', 'hr', 'b',];
    $_SESSION['count'] = 0;
    $score = 0;
    if(isset($_POST['tag'])) {
        session_start();
        $tag = $_POST['tag'];
        if(in_array($tag, $allTags)) {
            $_SESSION['count']++;
            $score = $_SESSION['count'];
            echo "<b>Valid HTML tag! <br> Score: $score</b>";
        } else {
            $score = $_SESSION['count'];
            echo "<b>Invalid HTML tag! <br> Score: $score</b>";
        }
    }
?>
 