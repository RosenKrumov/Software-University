/**
 * Created by Rosen on 18.11.2014 г..
 */
function compareChars(arr1, arr2) {

    if(arr1.length < arr2.length || arr2.length < arr1.length) {
        console.log('Not equal');
        return;
    }

    for (var i = 0, j = 0; i < arr1.length; i++, j++) {
        if(arr1[i] != arr2[i]) {
            console.log(('Not equal'));
            return;
        } else {
            continue;
        }
    }

    console.log('Equal');
}

compareChars(   ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'],
                ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']  );

compareChars(   ['3', '5', 'g', 'd'],
                ['5', '3', 'g', 'd']    );

compareChars( ['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'],
              ['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r'] );