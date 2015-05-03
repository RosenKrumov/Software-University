<?php

function compSkillsTable(){
    $return = '';
    for ($i = 0; $i <= count($_POST['compLangs']); $i++) {
        if($i == 0) {
            $return .= "<tr><td rowspan=".(count($_POST['compLangs'])+1).">Programming Languages</td><td>Language</td><td>Skill Level</td></tr>";
        } else {
            $return .= "<tr><td>".htmlentities($_POST['compLangs'][$i - 1])."</td><td>".htmlentities($_POST['compSkills'][$i - 1])."</td></tr>";
        }
    }

    return $return;
}

function langsTable(){
    $returnLangs = '';
    for ($i = 0; $i <= count($_POST['langs']); $i++) {
        if($i == 0) {
            $returnLangs .= "<tr><td rowspan=".(count($_POST['langs'])+1).">Languages</td><td>Language</td><td>Comprehension</td><td>Reading</td><td>Writing</td></tr>";
        } else {
            $returnLangs .= "<tr><td>".htmlentities($_POST['langs'][$i - 1])."</td><td>".htmlentities($_POST['comprehensions'][$i - 1])."</td><td>".htmlentities($_POST['readings'][$i - 1])."</td><td>".htmlentities($_POST['writings'][$i - 1])."</td></tr>";
        }
    }
    $returnLangs .= "<tr><td>Driver's license</td><td colspan='4'>".join(', ', $_POST['license'])."</td></tr>";

    return $returnLangs;

}

function isFormSubmitted()
{
    $requiredFields = ["firstName", "lastName", "gender", "phone", "email", "birthDate", "nationality", "compSkills",
        "company", "from", "to", "compLangs", "langs", "comprehensions", "readings", "writings", "license"];

    foreach ($requiredFields as $v) {
        if (!isset($_POST[$v])) {
            return false;
        }
        return true;
    }
}

function validateInput()
{
    $nameAndLangReg = '/[^A-Za-z]/';
    $emailReg = '/^[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z]+$/';
    $companyReg = '/[^A-Za-z0-9]/';
    $phoneReg = '/[^0-9-\+ ]+/';

    if(preg_match($nameAndLangReg, $_POST['firstName']) ||
        strlen($_POST['firstName']) < 2 ||
        strlen($_POST['firstName']) > 20) {
        die ('Enter valid first name!');
    }
    if(preg_match($nameAndLangReg, $_POST['lastName']) ||
        strlen($_POST['lastName']) < 2 ||
        strlen($_POST['lastName']) > 20) {
        die ('Enter valid last name!');
    }
    foreach ($_POST['compLangs'] as $compLang) {
        if(strlen($compLang) < 2 ||
            strlen($compLang) > 20) {
            die ('Enter valid programming language!');
        }
    }
    foreach ($_POST['langs'] as $lang) {
        if(preg_match($nameAndLangReg, $lang) ||
            strlen($lang) < 2 ||
            strlen($lang) > 20) {
            die ('Enter valid language!');
        }
    }

    if(!preg_match($emailReg, $_POST['email'])) {
        die ('Enter valid email!');
    }
    if(preg_match($companyReg, $_POST['company']) ||
        strlen($_POST['company']) < 2 ||
        strlen($_POST['company']) > 20) {
        die ('Enter valid company name!');
    }
    if(preg_match($phoneReg, $_POST['phone'])) {
        die ('Enter valid phone number!');
    }
}
?>
<?php if(isFormSubmitted()):
        validateInput();
    ?>
        <h1>CV</h1>
        <table border='1'>
                <thead>
                    <tr><th colspan='2'>Personal Information</th></tr>
                </thead>
                <tr>
                    <td>First Name</td>
                    <td><?=htmlentities($_POST['firstName']);?></td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td><?=htmlentities($_POST['lastName']);?></td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td><?=htmlentities($_POST['email']);?></td>
                </tr>
                <tr>
                    <td>Phone Number</td>
                    <td><?=htmlentities($_POST['phone']);?></td>
                </tr>
                <tr>
                    <td>Gender</td>
                    <td><?=htmlentities($_POST['gender']);?></td>
                </tr>
                <tr>
                    <td>Birth Date</td>
                    <td><?=htmlentities($_POST['birthDate']);?></td>
                </tr>
                <tr>
                    <td>Nationality</td>
                    <td><?=htmlentities($_POST['nationality']);?></td>
                </tr>
        </table><br>
        <table border='1'>
                  <thead>
                      <tr><th colspan='2'>Last Work Position</th></tr>
                  </thead>
                  <tr>
                     <td>Company Name</td>
                     <td><?=htmlentities($_POST['company']);?></td>
                  </tr>
                  <tr>
                     <td>From</td>
                     <td><?=htmlentities($_POST['from']);?></td>
                  </tr>
                  <tr>
                     <td>To</td>
                     <td><?=htmlentities($_POST['to']);?></td>
                  </tr>
        </table><br>
        <table border='1'>
            <thead>
                <tr><th colspan='3'>Computer Skills</th></tr>
            </thead>
            <tr>

                <?=compSkillsTable();?>
            </tr>

        </table>
        <br/>
        <table border="1">
            <thead>
                <tr><th colspan="5">Other Skills</th></tr>
            </thead>
            <tr>
                <?=langsTable();?>
            </tr>
        </table>
<?php endif; ?>

 