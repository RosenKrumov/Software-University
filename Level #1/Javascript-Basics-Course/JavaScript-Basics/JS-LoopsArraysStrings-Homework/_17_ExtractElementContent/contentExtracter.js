/**
 * Created by Rosen on 18.11.2014 г..
 */
function extractContent(str) {
    var regex = /(<([^>]+)>)/ig;
    var result = str.replace(regex, "");

    console.log(result);
}

extractContent('<p>Hello</p><a href=\'http://w3c.org\'>W3C</a>');