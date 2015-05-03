/**
 * Created by Rosen on 18.11.2014 г..
 */
function replaceATag(str) {
    str = str.replace(/<a/g, '[URL');
    str = str.replace(/<\/a>/g, '[/URL]');
    console.log(str);
}

replaceATag('<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>');

/*CAN NOT MAKE THE NEW LINES*/