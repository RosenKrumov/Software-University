<?php
require_once 'Db.php';
require_once 'Localization.php';

$db = Db::getInstance();
$resTranslations = $db->query("SELECT id, tag, text_en, text_bg FROM translations");
$translations = $resTranslations->fetchAll(PDO::FETCH_ASSOC);
?>

<form method="POST">
    <?php foreach ($translations as $translation): ?>
        <div class="source_translation">
            <?= $translation['text_'.Localization::$LANG_DEFAULT]; ?>
        </div>
        <textarea name="text_bg[<?=$translation['id']?>]" cols="20" rows="5"><?=
            $translation['text_'.Localization::LANG_BG];
        ?></textarea><br><br>
    <?php endforeach; ?>
    <input type="submit" value="Save"> (refresh to see the results)
</form>

<?php
    if (isset($_POST['text_bg'])) {
        foreach ($_POST['text_bg'] as $key => $value) {
            $sql = "UPDATE translations SET text_bg = :text_bg WHERE id = :id";
            $query = $db->prepare($sql);
            $query->bindParam(':text_bg', $value, PDO::PARAM_STR);
            $query->bindParam(':id', $key, PDO::PARAM_INT);
            $query->execute();
        }

        header('Location'.$_SERVER['REQUEST_URI']);
    }
?>