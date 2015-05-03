String.prototype.startsWith = function (substring) {
    var count = substring.length;
    return this.substr(0, count) === substring;
}

String.prototype.endsWith = function (substring) {
    var count = substring.length;
    var substrStart = this.length - count;
    return this.substr(substrStart, count) === substring;
}

String.prototype.left = function (count) {
    return this.substr(0, count);
}

String.prototype.right = function (count) {
    if (count < this.length) {
        var substrStart = this.length - count;
    } else {
        substrStart = 0;
    }
    return this.substr(substrStart, count);
}

String.prototype.padLeft = function (count, character) {
    character = character || " ";
    if (character.length > 1) {
        character = character.substr(0, 1);
    }
    var output = "";
    return output + character.repeat(count) + this;
}

String.prototype.padRight = function(count, character) {
    character = character || " ";
    if (character.length > 1) {
        character = character.substr(0, 1);
    }
    var output = "";
    return output + this + character.repeat(count);
}

String.prototype.repeat = function(count) {
    var output = "";
    for (var i = 0; i < count; i++) {
        output += this;
    }
    return output;
}