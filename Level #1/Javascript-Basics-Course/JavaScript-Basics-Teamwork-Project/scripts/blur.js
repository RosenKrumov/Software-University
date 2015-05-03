//$('element').attr('id','value');

$(document).on('click', function () {
    if (drunk >= 0 && drunk < 4) {
        $('#memory_board').foggy({
            blurRadius: 0,          // In pixels.
            opacity: 1,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 4 && drunk < 8) {
        $('#memory_board').foggy({
            blurRadius: 1,          // In pixels.
            opacity: 0.9,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 8 && drunk < 12) {

        $('#memory_board').foggy({
            blurRadius: 2,          // In pixels.
            opacity: 0.9,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 12 && drunk < 16) {
        $('#memory_board').foggy({
            blurRadius: 3,          // In pixels.
            opacity: 0.9,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 16 && drunk < 20) {
        $('#memory_board').foggy({
            blurRadius: 4,          // In pixels.
            opacity: 0.9,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 20 && drunk < 24) {
        $('#memory_board').foggy({
            blurRadius: 5,          // In pixels.
            opacity: 0.9,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 24 && drunk < 28) {
        $('#memory_board').foggy({
            blurRadius: 6,          // In pixels.
            opacity: 0.9,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 28 && drunk < 32) {
        $('#memory_board').foggy({
            blurRadius: 7,          // In pixels.
            opacity: 0.9,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 32 && drunk < 36) {
        $('#memory_board').foggy({
            blurRadius: 8,          // In pixels.
            opacity: 0.9,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 36 && drunk < 40) {
        $('#memory_board').foggy({
            blurRadius: 9,          // In pixels.
            opacity: 0.9,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 40 && drunk < 44) {
        $('#memory_board').foggy({
            blurRadius: 10,          // In pixels.
            opacity: 0.9,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 44 && drunk < 48) {
        $('#memory_board').foggy({
            blurRadius: 11,          // In pixels.
            opacity: 0.8,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 48 && drunk < 52) {
        $('#memory_board').foggy({
            blurRadius: 12,          // In pixels.
            opacity: 0.75,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 52) {
        $('#memory_board').foggy({
            blurRadius: 13,          // In pixels.
            opacity: 0.7,           // Falls back to a filter for IE.
            cssFilterSupport: true  // Use "-webkit-filter" where available.
        });
    }
    if (drunk >= 64) {
        drunk = 0;
    }

});

//if(drunk > 3){
//    $(document).ready( function(){
//        $('#memory_board').foggy({
//            blurRadius: 5,          // In pixels.
//            opacity: 0.9,           // Falls back to a filter for IE.
//            cssFilterSupport: true  // Use "-webkit-filter" where available.
//        });
//
//    });
//}