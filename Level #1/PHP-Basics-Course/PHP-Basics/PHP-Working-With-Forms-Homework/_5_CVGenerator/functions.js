var index = 1;
var langIndex = 1;
function addCompLang() {
    var inner = document.createElement("div");
    inner.setAttribute('id', 'compInput'+index);
    index++;
    inner.innerHTML = "<input type=\"text\" name=\"compLangs[]\"/> "+
    "<select name=\"compSkills[]\">"+
    "<option value=\"Beginner\">Beginner</option>"+
    "<option value=\"Intermediate\">Intermediate</option>"+
    "<option value=\"Advanced\">Advanced</option>"+
    "</select><br/>";
    document.getElementById('compParent').appendChild(inner);
}
function removeCompLang() {
    var inputBox = document.getElementById('compParent').lastChild;
    if(inputBox.nodeName.toLowerCase() === "div") {
        document.getElementById('compParent').removeChild(inputBox);
        index--;
    }
}
function addLang() {
    var langInner = document.createElement("div");
    langInner.setAttribute('id', 'langInput'+langIndex);
    langIndex++;
    langInner.innerHTML = "<input type=\"text\" name=\"langs[]\"/> "+
    "<select name=\"comprehensions[]\">"+
    "<option value=\"a\" selected disabled>-Comprehension</option>"+
    "<option value=\"Beginner\">Beginner</option>"+
    "<option value=\"Intermediate\">Intermediate</option>"+
    "<option value=\"Advanced\">Advanced</option>"+
    "</select> "+
    "<select name=\"readings[]\">"+
    "<option value=\"a\" selected disabled>-Reading-</option>"+
    "<option value=\"Beginner\">Beginner</option>"+
    "<option value=\"Intermediate\">Intermediate</option>"+
    "<option value=\"Advanced\">Advanced</option>"+
    "</select> "+
    "<select name=\"writings[]\">"+
    "<option value=\"a\" selected disabled>-Writing-</option>"+
    "<option value=\"Beginner\">Beginner</option>"+
    "<option value=\"Intermediate\">Intermediate</option>"+
    "<option value=\"Advanced\">Advanced</option>"+
    "</select><br/>";
    document.getElementById('langParent').appendChild(langInner);
}
function removeLang() {
    var langBox = document.getElementById('langParent').lastChild;
    if(langBox.nodeName.toLowerCase() === "div") {
        document.getElementById('langParent').removeChild(langBox);
        langIndex--;
    }
}