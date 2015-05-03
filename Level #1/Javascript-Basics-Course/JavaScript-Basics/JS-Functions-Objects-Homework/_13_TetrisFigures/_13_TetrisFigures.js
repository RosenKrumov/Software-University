/**
 * Created by Rosen on 22.11.2014 г..
 */
function tetrisFigures(arr) {
    var obj = { };
    var field = [];

    obj['I'] = 0;
    obj['L'] = 0;
    obj['J'] = 0;
    obj['O'] = 0;
    obj['Z'] = 0;
    obj['S'] = 0;
    obj['T'] = 0;

    for (var i = 0; i < arr.length; i++) {
        field[i] = arr[i].split('');
    }

    if(field.length >= 4) {
        for (var i = 0; i < field.length - 3; i++) {
            for (var j = 0; j < field[i].length; j++) {
                if (field[i][j] == 'o' &&
                    field[i + 1][j] == 'o' &&
                    field[i + 2][j] == 'o' &&
                    field[i + 3][j] == 'o') {

                    obj['I'] += 1;

                }
            }
        }
    }

    if (field.length >= 3) {
        for (var i = 0; i < field.length - 2; i++) {
            for (var j = 1; j < field[i].length; j++) {
                if (field[i][j - 1] == 'o' &&
                    field[i + 1][j - 1] == 'o' &&
                    field[i + 2][j - 1] == 'o' &&
                    field[i + 2][j] == 'o') {

                    obj['L'] += 1;

                }
                if (field[i][j] == 'o' &&
                    field[i + 1][j] == 'o' &&
                    field[i + 2][j] == 'o' &&
                    field[i + 2][j - 1] == 'o') {

                    obj['J'] += 1;

                }
            }
        }
    }

    if (field.length >= 2) {
        for (var i = 0; i < field.length - 1; i++) {
            for (var j = 1; j < field[i].length; j++) {
                if (field[i][j - 1] == 'o' &&
                    field[i][j] == 'o' &&
                    field[i + 1][j] == 'o' &&
                    field[i + 1][j - 1] == 'o') {

                    obj['O'] += 1;

                }

                if (field[i][j] == 'o' &&
                    field[i][j - 1] == 'o' &&
                    field[i + 1][j] == 'o' &&
                    field[i + 1][j + 1] == 'o') {

                    obj['Z'] += 1;

                }

                if (field[i][j] == 'o' &&
                    field[i][j + 1] == 'o' &&
                    field[i + 1][j] == 'o' &&
                    field[i + 1][j - 1] == 'o') {

                    obj['S'] += 1;

                }

                if (field[i][j] == 'o' &&
                    field[i][j - 1] == 'o' &&
                    field[i][j + 1] == 'o' &&
                    field[i + 1][j] == 'o') {

                    obj['T'] += 1;

                }
            }
        }
    }

    console.log(JSON.stringify(obj));
}

tetrisFigures(['oo','oo']);